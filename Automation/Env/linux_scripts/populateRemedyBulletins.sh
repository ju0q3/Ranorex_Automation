#!/bin/bash

VERBOSE=true

usage()

{

cat << EOF

   usage ${0} [options]
   
   
   Options:

     -u <user>          Change the default user (${USER})

     -x                 XML configurable file name used to populate remedy bulletins

     -r                 MLBINT Server to connect to for PDS

     -h or -?           Show this message and exit


EOF

}

verboseEcho() {

   if [ $VERBOSE == true ]

   then

      echo "$*"

   fi

}

while getopts "u:x:r:" OPTION

   do

      case $OPTION in

         u) LABOPT="    USER" USER="${OPTARG}";;

         x) LABOPT="    XML_FILE" XML_FILE="${OPTARG}";;

         r) LABOPT="    HOST" V_HOST="${OPTARG}";;

         h) usage; exit 1;;

         ?) usage; exit 1;;

      esac

         verboseEcho "          ${LABOPT} ... ${OPTARG}"

   done

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

XML_FILE_PATH="${DIR}/${XML_FILE}"

scp ${XML_FILE_PATH} ${USER}@${V_HOST}:~

ssh ${USER}@${V_HOST} 'bash -l -c "gviews && echo 'y' | PopulateBulletinTypes -e -r ./'${XML_FILE}'"'