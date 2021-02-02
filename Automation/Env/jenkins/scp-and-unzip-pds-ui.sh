#!/bin/bash

PDSDIR=C:\\PDS\\
DESTDIR=${PDSDIR}pds-dev-ui\\
BATDESTDIR=${DESTDIR}pds-ui\\bin\\
BATDESTFILE=${BATDESTDIR}WsApp.bat

USER=$1
SERVER=$2
BATSRCFILE=$3

# copy pds ui zip file from integration server to C:/PDS directory
cd ${PDSDIR} && scp ${USER}@${SERVER}:/tms/pdsgit/${USER}/pds-server/system/java/pds-dev-ui.zip .

if [ -d ${DESTDIR} ]
then
    echo "removing old instance of pds ui ..."
    rm -rf ${DESTDIR}
fi

# this directory should be removed because of the previous command.
if [ -d ${DESTDIR} ]
then
    echo "could not delete old instance of pds ui. process must be occupied ..."
    exit 0
fi

cd ${PDSDIR} && unzip ./pds-dev-ui.zip -d ./pds-dev-ui

# TODO: This is now a stretch goal
# the following comments out a couple of java options for TCL compatibility
# echo "updating WsApp.bat to work with TCL scripts ..."
# cp -f ${BATSRCFILE} ${BATDESTFILE}

# open a new CMD window and run WsApp.bat
echo "starting pds ui ..."
cd ${BATDESTDIR} && cmd.exe /c start WsApp.bat && exit



