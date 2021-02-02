#!/bin/bash



# dd / 8/16/2016 - update to linux file



usage()

{

cat << EOF



   usage ${0} [options] [branch]



   Start a unix dynamic view in Windows, synchronizing the regions

   if necessary and optionally mapping a windows drive. The 

   ClearCase view is determined as follows:

     1. If -t option is specified, it is used

     2. If [branch] parameter is specified, the view <user>_cad_<branch>

        is used

     3. Otherwise, the script will try to determine the branch

        assuming that it is running in a snapshot view. This makes it

        convenient to mount a dynamic view that corresponds to a 

        snapshot view.



   If -d is specified and the drive is currently mapped, but not

   to this view, it will be unmapped then re-mapped to the view



   Finally, the following vobs will be mounted by default:

     ${DEFAULT_VOBS_TO_MOUNT}



   Options:

  

     -v <vtype>         View Type - Label, Developer, Existing 

     -t <tag>           Use this view tag (${USER}_cad_<branch>)

     -u <user>          Change the default user (${USER})

     -s                 STE number

     -r                 MLBINT Server to connect to for PDS

     -p                 Previous PDS Label

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

VTYPE=

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





#

# Get Settings Used for Script

#



verboseEcho "Get Settings" | tee -a C:\\ste\\regression_test\\Start_Label.txt



DB=GA

RESET_TMDS="0"



# fetch the options

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

         verboseEcho "          ${LABOPT} ... ${OPTARG}" | tee -a C:\\ste\\regression_test\\Start_Label.txt

   done

   

shift $((OPTIND-1)); OPTIND=1;







#

# Prepare and Start PDS

#



verboseEcho "Prepare and Start PDS for Automation" | tee -a C:\\ste\\regression_test\\Start_Label.txt



NEW_VIEW=${USER}_cad_${TAG}



if [ ${V_PREV} == "Not_Applicable" ]

then

   PREV_VIEW=${V_PREV}

else

   PREV_VIEW=${USER}_cad_${V_PREV}

fi



   verboseEcho "                   ..." | tee -a C:\\ste\\regression_test\\Start_Label.txt

   verboseEcho "         VIEW TYPE ... ${VTYPE}" | tee -a C:\\ste\\regression_test\\Start_Label.txt

   verboseEcho "      CURRENT VIEW ... ${NEW_VIEW}" | tee -a C:\\ste\\regression_test\\Start_Label.txt

   verboseEcho "     PREVIOUS VIEW ... ${PREV_VIEW}" | tee -a C:\\ste\\regression_test\\Start_Label.txt

   verboseEcho "                DB ... ${DB}" | tee -a C:\\ste\\regression_test\\Start_Label.txt

   verboseEcho "        RESET TDMS ... ${RESET_TDMS}" | tee -a C:\\ste\\regression_test\\Start_Label.txt

   verboseEcho "                   ..." | tee -a C:\\ste\\regression_test\\Start_Label.txt

   

if [[ ${RESET_TDMS} == "0" ]]

then



   verboseEcho "                   ... Starting PDS - Skip Reset TDMS" | tee -a C:\\ste\\regression_test\\Start_Label.txt

 

   RUN_ARGS="-d ${DB} -ste ${STE_TAG} -run -notdms -pdms -adms div1"



else



   verboseEcho "                   ... Starting PDS - Reset TDMS" | tee -a C:\\ste\\regression_test\\Start_Label.txt



   RUN_ARGS="-d ${DB} -ste ${STE_TAG} -run -pdms -adms div1"



fi



ssh ${USER}@${V_HOST} bash -l -c '"cleartool' setview -login -exec ''\''/homes/smoker/preparePDSAutomation' ${RUN_ARGS}''\''  '${NEW_VIEW}'"'



verboseEcho "Prepare and Start PDS for Automation" | tee -a C:\\ste\\regression_test\\Start_Label.txt



cmd /c call C:\\ste\\automation\\bin\\cygwin.bat



verboseEcho "Complete" | tee -a C:\\ste\\regression_test\\Start_Label.txt


