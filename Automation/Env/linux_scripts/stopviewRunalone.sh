#!/bin/bash

usage()
{
cat << EOF

    Run the doStopPDS script to shutdown a runalone system

EOF
}


# These variables are set to begin and changed as the script moves forward
VERBOSE=true

verboseEcho() {
   if [ $VERBOSE == true ]
   then
      echo "$*"
   fi
}

verboseEcho "       ... Script Commence" | tee C:\\ste\\regression_test\\Stop_Runalone.txt

ssh ${USER}@${V_HOST} bash -l -c "'cd run-alone;yes|doStopPDS'"

cmd /c call C:\\ste\\automation\\bin\\cygwin.bat

verboseEcho "       ... Script Complete" | tee -a C:\\ste\\regression_test\\Stop_Runalone.txt

