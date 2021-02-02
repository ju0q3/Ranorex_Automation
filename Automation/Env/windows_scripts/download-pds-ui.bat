@echo off
C:
SET label=%1
SET error=0

SET max_retries=1
SET num_retries=0

COPY C:\Ste\regression_test\PDSTest\data\config\properties\connection.properties %USERPROFILE%\pds-config\properties\connection.properties
COPY C:\Ste\regression_test\PDSTest\data\config\properties\client.properties %USERPROFILE%\pds-config\properties\client.properties

IF NOT EXIST C:\PDS\%label% mkdir C:\PDS\%label%
IF NOT EXIST C:\PDS\%label%\pds-ns-config GOTO clone 
IF EXIST C:\PDS\%label%\pds-ns-config GOTO pull

:clone   
    @ECHO Performing git clone
    CD C:\PDS\%label%
    git clone git@github.build.ge.com:NS-UTCS/pds-ns-config.git
    GOTO pull

 
:pull
    @ECHO Performing fetch and checkout of %label%
    CD C:\PDS\%label%\pds-ns-config      
    git tag -d %label%
    git fetch --all
    git checkout %label%
    SET error=%errorlevel%


    IF "%error%"=="0" GOTO end
    IF NOT "%error%"=="0" GOTO end_failure


:end
    @ECHO Successfully Completed Download
	EXIT /B 0
	
:end_failure
    @ECHO Failure to Download
	EXIT /B 1