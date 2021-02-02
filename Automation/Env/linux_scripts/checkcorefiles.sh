#!/bin/bash



usage()

{

cat << EOF



   usage ${0} [options]

   Options:

     -u <user>          Change the default user (${USER})

     -r                 MLBINT Server to connect to for PDS

     -h or -?           Show this message and exit



EOF

}



typeset ScriptName=$( basename ${0} )

readonly ScriptName



# These variables are being reset ... 

# These should be read from command line to start this process

# If they remain blank, the process will close and prompt for user input

USER=

V_HOST=

# These variables are set to begin and changed as the script moves forward

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

while getopts "u:r:h:" OPTION



   do

      case $OPTION in

         u) LABOPT="    USER" USER="${OPTARG}";;

         r) LABOPT="    HOST" V_HOST="${OPTARG}";;

         h) usage; exit 1;;

         ?) usage; exit 1;;

      esac

         verboseEcho "          ${LABOPT} ... ${OPTARG}" | tee -a C:\\ste\\regression_test\\Wink_Label.txt

   done

shift $((OPTIND-1)); OPTIND=1;

ssh ${USER}@${V_HOST} ls -l /tms/corefiles | grep ${USER}


