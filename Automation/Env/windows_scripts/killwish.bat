rem - kill off all wish & winrunner procs
REM killapp.exe automation.exe 

REM - qtp launched via wscript from controller - must kill all pieces of this
taskkill /f /t /im automation.exe 2> nul
taskkill /f /t /im automation.exe 2> nul
taskkill /f /t /im PDS.exe 2> nul
REM - Added back to kill UIC
taskkill /f /t /im java.exe 2> nul
taskkill /f /t /im javaw.exe 2> nul
taskkill /f /t /im wscript.exe 2> nul
taskkill /f /t /im qtautomationagent.exe 2> nul
taskkill /f /t /im qtpro.exe 2> nul
REM - QTP 12
taskkill /f /t /im uft.exe 2> nul
taskkill /f /t /im python.exe 2> nul
exit



