#!/bin/bash



# 8/16/2016 - convert to linux file 



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

     -b <branch>           Use this view tag (${USER}_cad_<branch>)

     -u <user>          Change the default user (${USER})

     -p                 Path to script

     -a                 arguments to be passed to python script

     -l                 log file(s) to be copied over

     -d                 log file destination folder e.g. "Smoke"

     -r                 MLBINT Server to connect to for PDS

     -h or -?           Show this message and exit



EOF

}

#TODO instead of tag and user, do branch and user

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

BRANCH=

USER=

SCRIPT=

ARGUMENTS=

LOGFILE=

LOG_DEST=

STE_TAG=

V_HOST=

OUTFILE=

RESULTS_DIR=



# These variables are set to begin and changed as the script moves forward

CREATEVIEW=1

UNIX_VIEW_EXISTS=false

VERBOSE=true

LABOPT=

RESPONSE_DIRECTORY="${WIN_TEMP}/automation/results/"

STEP_INFO="${WIN_TEMP}/automation/current_step_info.txt"

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

ALL_PYTHON="${DIR}/*.py"

# ALL_DATA="${DIR}/data"

#textMode=transparent





verboseEcho() {

   if [ $VERBOSE == true ]

   then

      echo "$*"

   fi

}



# todo edit this to take in a script name

verboseEcho "    [note] ... Run Python Script Commence"

verboseEcho "           ..."



#

# Get Settings Used for Script

#



verboseEcho "           ..."

verboseEcho "Section Header ... Get Settings"



while getopts "b:u:p:a:l:d:r:" OPTION



   do

      case $OPTION in

         b) LABOPT="    BRANCH" BRANCH="${OPTARG}";;

         u) LABOPT="    USER" USER="${OPTARG}";;

         p) LABOPT="    SCRIPT" SCRIPT="${OPTARG}";;

         a) LABOPT="    ARGUMENTS" ARGUMENTS="${OPTARG}";;

         l) LABOPT="    LOGFILE" LOGFILE="${OPTARG}";;

         d) LABOPT="    LOG_DEST" LOG_DEST="${OPTARG}";;

         r) LABOPT="    HOST" V_HOST="${OPTARG}";;



         h) usage; exit 1;;

         ?) usage; exit 1;;

      esac

         verboseEcho "          ${LABOPT} ... ${OPTARG}"

   done

   

TAG="${USER}_cad_${BRANCH}"

RESULTS="T:\Systems\Automation\Results\PDS_Labels\\${BRANCH}"







IFS='/' read -ra PATHPARTS <<< "$SCRIPT"

IFS='.' read -ra SCRIPTPARTS <<< "${PATHPARTS[-1]}"

OUTFILE="C:\\ste\\regression_test\\runPython.txt"

   

shift $((OPTIND-1)); OPTIND=1;



verboseEcho "Section Footer ... Get Settings" | tee -a $OUTFILE

verboseEcho "           ..." | tee -a $OUTFILE





#

# Run the script

#

verboseEcho "           ..." | tee -a $OUTFILE

verboseEcho "Section Header ... Creating response directory" | tee -a $OUTFILE

verboseEcho "               ..." | tee -a $OUTFILE



ssh ${USER}@${V_HOST} 'bash -l -c "mkdir -p /tmp/responses/$USER/output"' | tee -a $OUTFILE

scp -r $STEP_INFO $USER@$V_HOST:/tmp/responses/current_step_info.txt

ssh ${USER}@${V_HOST} 'bash -l -c "chmod -R 777 /tmp/responses/"' | tee -a $OUTFILE



verboseEcho "               ..." | tee -a $OUTFILE

verboseEcho "Section Footer ... Creating response directory" | tee -a $OUTFILE

verboseEcho "           ..." | tee -a $OUTFILE



verboseEcho "               ..." | tee -a $OUTFILE

verboseEcho "Section Header ... Copying python scripts to host" | tee -a $OUTFILE

verboseEcho "           ..." | tee -a $OUTFILE



scp $ALL_PYTHON $USER@$V_HOST:~

# scp -r $ALL_DATA $USER@$V_HOST:~

ssh ${USER}@${V_HOST} 'bash -l -c "chmod 777 ~/*.py"' | tee -a $OUTFILE



verboseEcho "               ..." | tee -a $OUTFILE

verboseEcho "Section Footer ... Copying python scripts to host" | tee -a $OUTFILE

verboseEcho "           ..." | tee -a $OUTFILE



verboseEcho "           ..." | tee -a $OUTFILE

verboseEcho "Section Header ... Running script" | tee -a $OUTFILE

verboseEcho "               ..." | tee -a $OUTFILE



ssh ${USER}@${V_HOST} python $SCRIPT $ARGUMENTS



verboseEcho "               ..." | tee -a $OUTFILE

verboseEcho "Section Footer ... Running script" | tee -a $OUTFILE

verboseEcho "           ..." | tee -a $OUTFILE





verboseEcho "           ..." | tee -a $OUTFILE

verboseEcho "Section Header ... Handling Results" | tee -a $OUTFILE

verboseEcho "               ..." | tee -a $OUTFILE



if [ ! -z "$LOGFILE" ]; then

   if [ -z "$LOG_DEST" ]; then

      verboseEcho "NO DESTINATION SUPPLIED"

   else

      TIMESTAMP=$(date +"%Y%m%d-%H%M")

      RESULTS_DIR=${LOG_DEST}/results_${USER}_${TIMESTAMP}/

      mkdir -p $RESULTS_DIR

      scp -r $USER@$V_HOST:$LOGFILE $RESULTS_DIR

   fi

fi



scp -r $USER@$V_HOST:/tmp/responses/$USER/* $RESPONSE_DIRECTORY

ssh ${USER}@${V_HOST} 'bash -l -c "rm -r /tmp/responses/$USER"' | tee -a $OUTFILE



verboseEcho "               ..." | tee -a $OUTFILE

verboseEcho "Section Footer ... Handling Results" | tee -a $OUTFILE

verboseEcho "           ..." | tee -a $OUTFILE



verboseEcho "    [note] ... Script Complete" | tee -a $OUTFILE



cmd /c call C:\\ste\\automation\\bin\\cygwin.bat

