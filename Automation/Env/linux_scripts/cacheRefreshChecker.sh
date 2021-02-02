#!/bin/bash



# ro / 2/05/2019 - created



usage()

{

cat << EOF



   usage ${0} [options] [branch]



   Gets the cache status for a particular district



   Options:

     -t <tag>           Use this view tag (${USER}_cad_<branch>)

     -u <user>          Change the default user (${USER})

     -d <district>      What District you want the cache refresh status from
     
     -i <division>      What Division the district is under (div1, div2.... div10)
     
     -e <messageType>   What messages you want to see from the cache refresh (GD)
     
     -m                 If you want the Machine Status for the cache refresh
     
     -c                 If you want the messages from the cache refresh
     
     -a                 If you want both the Machine Status and messages from the cache refresh

     -h or -?           Show this message and exit



EOF

}



typeset ScriptName=$( basename ${0} )

readonly ScriptName



export CMTOOL=//mlbnfs04.tms.ad.trans.ge.com/apps/cadapps/cmtool/cmtool.bat

echo ${CMTOOL}

if ! [ -f ${CMTOOL} ]

then

   echo "Unable to access cmtool at ${CMTOOL}"

   exit 1

fi



# These variables are being reset ... 

# These should be read from command line to start this process

# If they remain blank, the process will close and prompt for user input

TAG=

USER=

DISTRICT=

V_HOST=

MACHINE_STATUS=0

CACHED_MESSAGES=0

ALL=0

DIVISION="div1"

# These variables are set to begin and changed as the script moves forward

UNIX_VIEW_EXISTS=false

VERBOSE=true

LABOPT=

#textMode=transparent



verboseEcho() {

   if [ $VERBOSE == true ]

   then

      echo "$*"

   fi

}



#

# Get Settings Used for Script

#



while getopts "t:u:r:d:i:m c e:a h:" OPTION



   do

      case $OPTION in

         t) LABOPT="        TAG" TAG="${OPTARG}";;

         u) LABOPT="       USER" USER="${OPTARG}";;

         r) LABOPT="       HOST" V_HOST="${OPTARG}";;

         d) LABOPT="   DISTRICT" DISTRICT="${OPTARG}";;
         
         i) LABOPT="   DIVISION" DIVISION="${OPTARG}";;

         m) LABOPT="MACHINESTAT" MACHINE_STATUS=1;;

         c) LABOPT=" CACHEDMSGS" CACHED_MESSAGES=1;;
         
         e) LABOPT="MESSAGETYPE" MESSAGE_TYPE="${OPTARG}";;
         
         a) LABOPT="        ALL" ALL=1;;

         h) usage; exit 1;;

         ?) usage; exit 1;;

      esac

   done

   

shift $((OPTIND-1)); OPTIND=1;

echo ALL ${ALL}
echo MACHINE_STATUS ${MACHINE_STATUS}
echo CACHED_MESSAGES ${CACHED_MESSAGES}

VIEW=${USER}_cad_${TAG}

echo ${VIEW}

if [ ${ALL} == 1 ]
then
   ssh ${USER}@${V_HOST} '. /etc/profile; ./../../tms/pdsgit/'${USER}'/pds-server; gviews; source env.sh; ptcInfo -c "'${MESSAGE_TYPE}'" -l "'${DIVISION}'" -d "'${DISTRICT}'" -I -m;'
   #Old clearcase version
   #ssh ${USER}@${V_HOST} '. /etc/profile; cleartool setview -login -exec "ptcInfo -c '${MESSAGE_TYPE}' -l '${DIVISION}' -d \"'${DISTRICT}'\" -I -m" '${VIEW}''
elif [ ${MACHINE_STATUS} == 1 ]
then
   ssh ${USER}@${V_HOST} '. /etc/profile; ./../../tms/pdsgit/'${USER}'/pds-server; gviews; source env.sh; ptcInfo -c "'${MESSAGE_TYPE}'" -l "'${DIVISION}'" -d "'${DISTRICT}'" -I;'
   #Old clearcase version
   #ssh ${USER}@${V_HOST} '. /etc/profile; cleartool setview -login -exec "ptcInfo -c '${MESSAGE_TYPE}' -l '${DIVISION}' -d \"'${DISTRICT}'\" -I" '${VIEW}''
elif [ ${CACHED_MESSAGES} == 1 ]
then 
   ssh ${USER}@${V_HOST} '. /etc/profile; ./../../tms/pdsgit/'${USER}'/pds-server; gviews; source env.sh; ptcInfo -c "'${MESSAGE_TYPE}'" -l "'${DIVISION}'" -d "'${DISTRICT}'" -m;'
   #Old clearcase version
   #ssh ${USER}@${V_HOST} '. /etc/profile; cleartool setview -login -exec "ptcInfo -c '${MESSAGE_TYPE}' -l '${DIVISION}' -d \"'${DISTRICT}'\" -m" '${VIEW}''
fi
