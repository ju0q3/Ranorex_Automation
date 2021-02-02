#!/bin/bash
# dd / 8/16/2016 - update to linux file

usage()
{
cat << EOF
   usage ${0}

   Runs upgradeDbs -F to force an update of an existing database.
   
   Options:
      NONE

EOF
}

typeset ScriptName=$( basename ${0} )

readonly ScriptName

#export CMTOOL=//mlbnfs04.tms.ad.trans.ge.com/apps/cadapps/cmtool/cmtool.bat

#echo ${CMTOOL}


#if ! [ -f ${CMTOOL} ]
#then
#   echo "Unable to access cmtool at ${CMTOOL}"
#      
#   exit 1
#fi

# These variables are being reset ... 
# These should be read from command line to start this process
# If they remain blank, the process will close and prompt for user input
TAG=
USER=
STE_TAG=
V_HOST=
PREV_TAG=
CRNT_TAG=

# These variables are set to begin and changed as the script moves forward
CREATEVIEW=1
UNIX_VIEW_EXISTS=false
VERBOSE=true
LABOPT=
#textMode=transparent

# These variables are hard coded and willnot be chagned in the script 
# These varibales should be limited to paths or file names that are not altered

SYNC_VIEW=/homes/smoker/.bin/syncView.py

verboseEcho() {
   if [ $VERBOSE == true ]
   then
      echo "$*"
   fi
}

verboseEcho "       ... Script Commence" | tee C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "           ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt


#
# Get Settings Used for Script
#

verboseEcho "Section Header ... Get Settings" | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "               ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

DB=GA
RESET_TMDS="0"

while getopts "v:t:u:s:r:p:d:m:h:" OPTION

   do
      case $OPTION in
         v) LABOPT="   VTYPE" VTYPE="${OPTARG}";;
         t) LABOPT="     TAG" TAG="${OPTARG}";;
         u) LABOPT="    USER" USER="${OPTARG}";;
         s) LABOPT="     STE" STE_TAG="${OPTARG}";;
         r) LABOPT="    HOST" V_HOST="${OPTARG}";;
         p) LABOPT="    PREV" V_PREV="${OPTARG}";;
         d) LABOPT="      DB" DB="${OPTARG}";;
         m) LABOPT="    TDMS" RESET_TDMS="${OPTARG}";;

         h) usage; exit 1;;
         ?) usage; exit 1;;
      esac

      verboseEcho "          ${LABOPT} ... ${OPTARG}" | tee -a C:\\ste\\regression_test\\upgradeDbs.txt
      
   done

shift $((OPTIND-1)); OPTIND=1;

verboseEcho "               ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "Section Footer ... Get Settings" | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "           ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt


#
# resetDbs
#

verboseEcho "Section Header ... Run upgradeDbs.sh" | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "               ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

NEW_VIEW=${USER}_cad_${TAG}

verboseEcho "               ... NEW_VIEW: ${NEW_VIEW}" | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "               ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt



verboseEcho "               ... Run upgradeDbs -F" | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "               ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt


ssh ${USER}@${V_HOST} bash -l -c '"cleartool setview -login -exec '"'upgradeDbs -F'"' '${NEW_VIEW}'"'


verboseEcho "               ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "Section Footer ... Run upgradeDbs.sh" | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

verboseEcho "           ..." | tee -a C:\\ste\\regression_test\\upgradeDbs.txt



cmd /c call C:\\ste\\automation\\bin\\cygwin.bat



verboseEcho "       ... Script Complete" | tee -a C:\\ste\\regression_test\\upgradeDbs.txt

