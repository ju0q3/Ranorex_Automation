#!/bin/bash
# ro / 2/05/2019 - created

usage()

{
cat << EOF



   usage ${0} [options] [branch]

   Options:

     -u <user>          Change the default user (${USER})
     
     -r <vhost>         Server

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




UNIX_VIEW_EXISTS=false

VERBOSE=true

LABOPT=

#textMode=transparent

#

# Get Settings Used for Script

#



while getopts "u:r:f:t:h:" OPTION



   do

      case $OPTION in

         u) LABOPT="           USER" USER="${OPTARG}";;

         r) LABOPT="           HOST" V_HOST="${OPTARG}";;
         
         f) LABOPT="           FROM" FROM="${OPTARG}";;
         
         t) LABOPT="           TO" TO="${OPTARG}";;
         
         h) usage; exit 1;;

         ?) usage; exit 1;;

      esac

   done
   
   
ssh ${USER}@${V_HOST} 'cd ./../../../pdslogs/javalog; rm -rf output.log'
ssh ${USER}@${V_HOST} 'cd ./../../../pdslogs/javalog; awk '\''$1>="'${FROM}'" && $1<="'${TO}'"'\'' chicagoRailinc.COP.log >> output.log'
scp ${USER}@${V_HOST}:../../../pdslogs/javalog/output.log .