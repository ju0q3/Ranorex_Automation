#!/bin/ksh



if [ -e ~/ste.dat ] 

then

    cp ~/ste.dat ${ALTDATADIR}/ste.dat

    chmod 777 ${ALTDATADIR}/ste.dat

fi

