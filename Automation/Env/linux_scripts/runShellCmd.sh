#!/bin/bash

VERBOSE=true

usage()

{

cat << EOF

   usage ${0} [options]
   
   
   Options:

     -u <user>          Change the default user (${USER})

     -s                 Shell command to be executed on server side

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

while getopts "u:s:r:" OPTION

   do

      case $OPTION in

         u) LABOPT="    USER" USER="${OPTARG}";;

         s) LABOPT="    SHELL_CMD" SHELL_CMD="${OPTARG}";;

         r) LABOPT="    HOST" V_HOST="${OPTARG}";;

         h) usage; exit 1;;

         ?) usage; exit 1;;

      esac

         verboseEcho "          ${LABOPT} ... ${OPTARG}"

   done

ssh ${USER}@${V_HOST} 'bash -l -c "gviews && '${SHELL_CMD}'"'