#!/bin/bash

PARENTDIR=C:\\Users\\r07000021\\rx
GITDIR=${PARENTDIR}\\janus
OUTDIR=${PARENTDIR}\\output
BRANCH=$1
LABEL=$2

if [ -d ${OUTDIR} ]
then
    "removing executables directory ..."
    rm -rf ${OUTDIR}
fi


if [ -e ${GITDIR} ]
then
    echo "checking out branch: '${BRANCH}' ..."
    cd ${GITDIR} && git fetch --all && git pull
    cd ${GITDIR} && git checkout ${BRANCH}
    
    echo "checking out server label: '${LABEL}' ..."
    cd ${GITDIR} && git checkout ${LABEL}
fi