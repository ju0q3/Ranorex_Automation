#!/bin/ksh



ScriptName=$( basename ${0} )

readonly ScriptName



if [[ $(cleartool pwv -short) == "** NONE **" ]]

then

   print -u2 -- "Must be in a view to run ${ScriptName}"

   exit 1

fi



# Load useful functions

. /homes/hmorgan/bin/clearcaseutils.ksh

. /homes/hmorgan/bin/environmentutils.ksh



PATH="/homes/hmorgan/bin:${PATH}"



. ${TOOLDIR}/functions/myinfo.sh

. ${TOOLDIR}/functions/orafuncs.sh



typeset CDMS_CONFIG=/homes/hmorgan/bin/cdmsConfig



typeset debug=0



typeset RunPDS=0

typeset PDSCmd=

typeset Ste=

typeset STECAD=

typeset Clean=1

typeset CleanAltDataDir=1

typeset RecreateDb=1

typeset EnableBackflow=0

typeset EnablePlayback=0

typeset SteMpEOn=0

typeset DatabaseArgument=""

typeset AdditionalVolumes=1

typeset VersantReset=1

typeset VersantMassage=0

typeset AdmsReset=1

typeset CdmsReset=1

typeset PdmsReset=1

typeset TdmsReset=1

typeset DatabaseType=GA

typeset EnablePdms=0

typeset PopulateUsers=0

typeset AddSharedMemory=1



typeset div1=R

typeset div2=R

typeset div3=R

typeset div4=R

typeset div5=R

typeset div6=R

typeset div7=R

typeset div8=R

typeset div9=R

typeset div10=R

typeset div11=R

typeset ConfiguredAtLeast1Division=0





#===============================================================================

function usage

{

print -- "

  usage: ${ScriptName} [options]



DESCRIPTION:

  The purpose of this script is to make it a one-step process to start a PDS

  system for development purposes, using a clean environment to maximize the

  chances of the system starting up properly.



  It performs the following steps:

    1.  Creates a new database with makeTestDb.

          (default: creates a prod a.k.a Georgia database)

    2.  Evolve the database schema.

    3.  Makes the database public via:

          dbuser -add -P \${O_DBNAME}

    4.  Runs stopPDS and cleanPDS to remove any remnants of an old running

        PDS system.

        Also cleans out the \$ALTDATADIR directory.

    5.  Runs startPDS.

          (default: turns SteMpE off and performs a CDMS reset)

    6.  Repopulates the users in the Versant database.





OPTIONS:



  -adms          Reset ADMS (default is to NOT reset ADMS)

  -backflow      Enables Backflow by setting the environment variable

                 PT_BACKFLOW_RUNTIME to ENABLE if it is not already set.

  -copydb xxxx   Passes '-s xxxx' to the makeTestDb script to allow the user

                 to create a copy of a different database.  For example, if

                 '-copydb xxxx' is supplied, then 'makeTestDb -s xxxx' is run.

  -d xxxx        Passes '-xxxx' to the makeTestDb script to allow the user

                 to select a different database.  For example, if '-d FL'

                 is supplied, then 'makeTestDb -FL' is run.

                 (default: runs 'makeTestDb' with no arguments)

  -dbtar xxxx    Passes '-f xxxx' to the makeTestDb script to allow the user

                 to create a database from a tar file (backup).

  -field         Creates a database by passing -field to makeTestDb

  -noaltdata     Does not clean the \$ALTDATADIR directory

  -nobackup      Does not run backupdb to backup your Versant database

  -nocdms        Does not reset CDMS before restarting.

  -noclean       Doesn't run cleanPDS before starting the system.  Also

                 will not clean the \$ALTDATADIR

  -nodb          Does not run makeTestDb to recreate your database.

                 This also skips schema evolution of the database and

                 does not backup the database.  Also does not repopulate users.

  -notdms        Does not reset the TDMS database.

  -nouser        Does not repopulate users in the Versant Database.

  -run           Automatically starts the PDS system rather than leaving the

                 main menu of the startPDS script up

  -playback      Enables Playback by setting the environment variable

                 PLAYBACK_MODE to ENABLE.  Note:  this requires Backflow to

                 be enabled, so it also enables Backflow (implies -backflow).

  -pdms          Reset PDMS (default is to NOT reset PDMS).

                 Also enables PDMS archiving by setting the environment

                 variable PDMS_ARCHIVE to ENABLE.

  -stempe        Turns on SteMpE

  -ste xx        Uses the specified STE (e.g. '-ste 98' for CAD_98)

  -vol           Specifies the number of additional 2GB volumes to allocate

                 in the makeTestDb command.

  div(1-11)      Enables the specified division





EXAMPLES:



  ${ScriptName} -ste 98 -field div1 div3 -run

  ${ScriptName} -ste 98 div1 -run



"

}





#===============================================================================

function main

{

  # process command-line parameters

  #

  while [[ -n ${1} ]]

  do

    case ${1} in

      -h*|-\?)

        usage

        exit 1

        ;;



      -debug)

        debug=1

        ;;



      -D)

        set -x

        ;;



      -adms)

        AdmsReset=1

        ;;



      -backflow)

        EnableBackflow=1

        ;;



      -copydb)

        shift

        if [[ -z ${1} ]]

        then

          print -u2 -- "No argument supplied for -copydb option"

          usage

          exit 1

        else

          DatabaseArgument="-s ${1}"

        fi

        ;;



      -cdms)

        CdmsReset=1

        ;;



      -dbtar)

        shift

        if [[ -z ${1} ]]

        then

          print -u2 -- "No argument supplied for -dbtar option"

          usage

          exit 1

        else

          DatabaseArgument="-f ${1}"

        fi

        ;;



      -d)

        shift

        if [[ -z ${1} ]]

        then

          print -u2 -- "No argument supplied for -d option"

          usage

          exit 1

        else

          DatabaseType="${1}"

          DatabaseArgument="-${1}"

        fi

        ;;



      div+([0-9]))

        eval ${1}=E

        ConfiguredAtLeast1Division=1

        ;;



      -field)

        DatabaseType="FL"

        DatabaseArgument="-FL"

        AdditionalVolumes=4

        ;;



      -noaltdata)

        CleanAltDataDir=0

        ;;



      -noadms)

        AdmsReset=n

        ;;



      -nocdms)

        CdmsReset=n

        ;;



      -noclean)

        Clean=0

        ;;



      -nodb)

        DatabaseArgument=

        VersantReset=n

        AdmsReset=n

        CdmsReset=n

        PdmsReset=n

        TdmsReset=n

        ;;



      -nopdms)

        PdmsReset=n

        ;;



      -notdms)

        TdmsReset=n

        ;;



      -nouser)

        PopulateUsers=0

        ;;



      -playback)

        EnablePlayback=1

        # This also requires backflow

        EnableBackflow=1

        ;;



      -pdms)

        PdmsReset=1

        EnablePdms=1

        ;;



      -run)

        RunPDS=1

        ;;



      -stempe)

        SteMpEOn=1

        ;;



      -ste)

        Ste=CAD_${2}

        STECAD=${2}

        shift

        ;;



      -vol)

        shift

        if [[ -z ${1} ]]

        then

          print -u2 -- "No argument supplied for -vol option"

          usage

          exit 1

        else

          AdditionalVolumes="${1}"

        fi

        ;;



      *)

        echo "Invalid Argument: ${1}"

        usage

        exit 1

        ;;



    esac



    shift

  done



  typeset _label=$( cleartool catcs |

                      egrep "CBA|TST|PDS|MPS|R1E" |

                        sed -n -e 's/.*element \* \([0-9A-Za-z_\-]*\) -.*/\1/p' )

  typeset _branch=



  if [[ ${_label} == "CBA_"* ]]

  then

    _branch=CBA

  elif [[ ${_label} == "TST_"* ]]

  then

    _branch=TST

  elif [[ ${_label} == "CN-PDS_"* ]]

  then

    _branch=PDS

  elif [[ ${_label} == "PDS_"* ]]

  then

    _branch=PDS

  elif [[ ${_label} == "R1E_"* ]] ||

       [[ ${_label} == "MPS"* ]]

  then

    _branch=R1E

  else

    _branch=R1E

#    print -u2 -- "Unknown branch type: ${_label}"

#    exit 10

  fi



  if [[ ${ConfiguredAtLeast1Division} == 0 ]]

  then

    print -u2 -- "Must configure at least 1 division (e.g. use option div1)"

    usage

    exit 2

  fi



  print -- "Branch: ${_branch} Label: ${_label}"





  # Just make sure we can ssh to the versant server...

  typeset _versantServer=$( print -- "${O_DBNAME}" | sed -e 's/.*@//' )

  ssh ${_versantServer} echo "SSH to ${_versantServer} works"



  stopPDS -s -e -u ${USER} -F



  if [[ ${debug} == 0 ]] &&

     [[ ${Clean} == 1 ]]

  then

    # Since the PDS branch and the other branches use different

    # flags to clean everything up without an interactive prompt,

    # check for which branch we are on.

    typeset CleanPdsCmd="cleanPDS -e -u ${USER} -F -cleanall y"



    echo "Executing '${CleanPdsCmd}'"

    ${CleanPdsCmd}



    typeset winkBuildCmd="winkBuild"

    echo "Executing '${winkBuildCmd}'"

    ${winkBuildCmd}



#    echo "Removing corefiles:"

#    if [ -d /tms/corefiles ]

#    then

#       (

#          cd /tms/corefiles

#       )

#    fi

  fi



  cd $( readlink -m ${LIBDIR} )

  echo "Cleaning up old copied library files..."

  rm -rf moveLibCopy.* > /dev/null 2>&1

  rm -rf *.so.bak* > /dev/null 2>&1

  rm -rf *.so.backedout* > /dev/null 2>&1



  cd $( readlink -m ${EXECDIR} )

  print -- "Cleaning up old copied applications..."

  rm -rf moveLibCopy.* > /dev/null 2>&1



  cd $( readlink -m ${EXECBIN} )

  print -- "Cleaning up old copied tools..."

  rm -rf moveLibCopy.* > /dev/null 2>&1



  # I like running from the bin directory, so the ULOG files are all

  # in the same place

  cd $( readlink -m ${EXECDIR} )



  # Clean up old ULOG files, stdout, etc....

  print -- "Cleaning up old ULOG files..."

  rm `/bin/ls ULOG.*` > /dev/null 2>&1

  print -- "Done"

  print -- "Cleaning up old stdout and stderr files..."

  rm ./stdout > /dev/null 2>&1

  rm ./stderr > /dev/null 2>&1

  print -- "Done"



  mySetupPdsDirs

  

  # if CN database, get latest one

  _tdmsLocation="/tms/pdswork/${USER}/${_label}/data/config/dat/dev/tdms.dat"

  typeset _tdmsDat="cp /home/ocalhoun/CN/tdms.dat ${_tdmsLocation}"  

  if [[ ${DatabaseType} == "CNTU"* ]]

  then

    #IF CN DB, copy the tdms.dat from Omner's folder to $ALTDATADIR

    ${_tdmsDat}

  fi

  

  # Make a new Versant database

  if [[ ${VersantReset} == 1 ]]

  then

    typeset _databaseCmd="makeTestDb -d ${O_DBNAME} -${DatabaseType}"



    if [[ ${AdditionalVolumes} != 0 ]]

    then

       _databaseCmd="${_databaseCmd} -v ${AdditionalVolumes}"

    fi



    # First remove it.  Sometimes, you can't create the database and

    # it is because it needs to be cleaned up first.

    removedb -rmdir -f ${O_DBNAME}



    print -- "${_databaseCmd}"

    ${_databaseCmd}



    if [[ ${?} != 0 ]]

    then

      print -u2 -- "makeTestDb failed, stopping"

      exit 1

    fi



    # Make the database public

    dbuser -add -P ${O_DBNAME}



    # Make sure the schema is OK

    echo "Making sure database schema is up-to-date..."

    if [[ ${VersantMassage} == 0 ]]

    then

      evolveDb

      installIndex.sh -c -e -F -u ${USER} |

         egrep -v 'E6073:|E6613:|VERSANT Utility|^$|Copyright|Creating BTREE|Creating UNIQUE BTREE|Could not create index'

    fi

  fi



  # Turn on backflow if necessary

  if [[ ${EnableBackflow} == 1 ]]

  then

    export PT_BACKFLOW_RUNTIME=ENABLE

  fi



  # Turn on PDMS archive if necessary

  if [[ ${EnablePdms} == 1 ]]

  then

    export PDMS_ARCHIVE=ENABLE

  fi



  echo "PT_BACKFLOW_RUNTIME=${PT_BACKFLOW_RUNTIME}"



  # Turn on playback if necessary

  if [[ ${EnablePlayback} == 1 ]]

  then

    export PLAYBACK_MODE=ENABLE

  fi



   if [[ -n ${PLAYBACK_MODE} ]]

   then

      echo "PLAYBACK_MODE=${PLAYBACK_MODE}"

   else

      echo "PLAYBACK_MODE not set"

   fi



   if [[ ${TdmsReset} == 1 ]]

   then

      print -- "\n\nResetting TDMS..."

      myResetTdms ${DatabaseType}

      if [[ ${?} != 0 ]]

      then

         print -u2 -- "Error Resetting TDMS, aborting"

         exit 1

      fi

   fi



   if [[ ${CdmsReset} == 1 ]]

   then

      print -- "\n\nResetting CDMS..."

      myResetCdms ${DatabaseType}

      if [[ ${?} != 0 ]]

      then

         print -u2 -- "Error Resetting CDMS, aborting"

         exit 1

      fi

   fi



   if [[ ${PdmsReset} == 1 ]]

   then

      print -- "\n\nResetting PDMS..."

      myResetPdms

      if [[ ${?} != 0 ]]

      then

         print -u2 -- "Error Resetting PDMS, aborting"

         exit 1

      fi

   fi



   if [[ ${AdmsReset} == 1 ]]

   then

      print -- "\n\nResetting ADMS..."

      myResetAdms

      if [[ ${?} != 0 ]]

      then

         print -u2 -- "Error Resetting ADMS, aborting"

         exit 1

      fi

   fi



   if [[ ${AddSharedMemory} == 1 ]]

   then

      print -- "Increasing shared memory available to TKS"

      ${CDMS_CONFIG} -u RMS_SHM_TOPOLOGY_REGION_SIZE_PER_DIVISION_MB 125

   fi



   echo "\n\nStarting PDS..."

   sleep 1



   /homes/smoker/prepareAltSte.sh



   # Start building the startPDS command line...

   PDSCmd="startPDS -e -u ${USER} -F"



   print -- "${PDSCmd}"



  if [[ ${debug} == 0 ]]

  then

    typeset Args="div1

${div1}

div2

${div2}

div3

${div3}

div4

${div4}

div5

${div5}

div6

${div6}

div7

${div7}

div8

${div8}

div9

${div9}

div10

${div10}

div11

${div11}

D

"

    typeset CR="

"



    # Add the STE directive

    if [[ ${Ste} != "" ]]

    then

      Args="${Args}2${CR}${STECAD}${CR}"

      [[ ${_branch} == "CBA" ]] && Args="${Args}N${CR}"

      [[ ${_branch} == "TST" ]] && Args="${Args}N${CR}"

      [[ ${_branch} == "R1E" ]] && Args="${Args}N${CR}"

      [[ ${_branch} == "MPS" ]] && Args="${Args}N${CR}"

      [[ ${_branch} == "PDS" ]] && Args="${Args}N${CR}"

    fi



    if [[ "${SteMpEOn}" == 1 ]]

    then

      Args="${Args}12${CR}y${CR}"

    fi



    # Add the run directive

    if [[ ${RunPDS} == 1 ]]

    then

      Args="${Args}r${CR}"

    else

      Args="${Args}q${CR}"

    fi



    print -- "Args:${CR}${Args}${CR}End Args"



    print -- "${Args}" | ${PDSCmd}

  fi



  if [[ ${PopulateUsers} == 1 ]]

  then

     print -- "-y${CR}y${CR}" | /homes/hmorgan/bin/popL

  fi



  sleep 15



  typeset _healthResult=$( healthPDS 2>&1 )

  echo "${_healthResult}"



  if [[ ${_healthResult} == *"PDS does not appear to be running"* ]]

  then

     exit 1

  fi



  ${CDMS_CONFIG} -u AR_ENABLE_AUTOROUTING TRUE

  [[ ${?} == 0 ]] || exit 1



  /homes/hmorgan/bin/disableSapValidations

#  /homes/hmorgan/bin/shortenTooltipDelay



#  if [[ -f ${HOME}/.userProfiles ]] &&

#     grep "User:user1_1" ${HOME}/.userProfiles

#  then

#    /homes/ocalhoun/.bin/userProf -i user1_1

#  fi



  exit 0

}



#==============================================================================

main "${@}"



# div1 blah blah blah

# D

# 2

# 9

# n

