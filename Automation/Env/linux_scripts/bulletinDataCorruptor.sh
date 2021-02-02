#!/bin/bash



# ro / 2/05/2019 - created



usage()

{

cat << EOF



   usage ${0} [options] [branch]



   Uses the BulletinDataCorruptor script to corrupt a bulletin



   Options:

     -t <tag>           Use this view tag (${USER}_cad_<branch>)

     -u <user>          Change the default user (${USER})
     
     -r <vhost>         Server

     -b <bulletin_number>      Bulletin Number of Bulletin to corrupt
     

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



while getopts "t:u:r:b:h:" OPTION



   do

      case $OPTION in

         t) LABOPT="            TAG" TAG="${OPTARG}";;

         u) LABOPT="           USER" USER="${OPTARG}";;

         r) LABOPT="           HOST" V_HOST="${OPTARG}";;

         b) LABOPT="BULLETIN_NUM" BULLETIN_NUM="${OPTARG}";;

         h) usage; exit 1;;

         ?) usage; exit 1;;

      esac

   done

   

shift $((OPTIND-1)); OPTIND=1;

echo Bulletin Number: ${BULLETIN_NUM}

VIEW=${USER}_cad_${TAG}

echo ${VIEW}

ssh ${USER}@${V_HOST} '. /etc/profile; ./../../tms/pdsgit/'${USER}'/pds-server; gviews; source env.sh; $TOOLDIR/RSTtools/BulletinDataCorruptor.sh -e -u '${USER}' -F -bn '${BULLETIN_NUM}' -a;'
#Old clearcase version
#ssh ${USER}@${V_HOST} '. /etc/profile; cleartool setview -login -exec "\$TOOLDIR/RSTtools/BulletinDataCorruptor.sh -e -u '${USER}' -F -bn '${BULLETIN_NUM}' -a" '${VIEW}''

