#
#
#                    /^\/^\
#                  _|__|  O|              Created: 2/24/17
#         \/     /~     \_/ \             Author: Russ 
#          \____|__________/  \
#                 \_______      \
#                         `\     \                 \
#                           |     |                  \
#                          /      /                    \
#                         /     /                       \\
#                       /      /                         \ \
#                      /     /                            \  \
#                    /     /             _----_            \   \
#                   /     /           _-~      ~-_         |   |
#                  (      (        _-~    _--_    ~-_     _/   |
#                   \      ~-____-~    _-~    ~-_    ~-_-~    /
#                     ~-_           _-~          ~-_       _-~
#                        ~--______-~                ~-___-~
# This script uses grep to look for all instances of 'error' or 'exception
# in the current days trace files. This script is ran as apart of Linux post conditions
# and is called from the checkTraceFiles proc  within scripts\procs\proc_Linux.scl

import commands as cmds
import re
import sys
import python_utils as pu

whitelistFile = "data/$::gProject/tracewhitelist.txt"

def main():   
   (user, project) = validateInputs()
   print "Checking for tracefile issues for " + str(user)
   if not user:
      print "No User"
      exit()
   listTraceErrors(user, project)
   listTraceExceptions(user, project)
   #getPotentialTraceIssues(user)

def validateInputs():
   #Need one inputs: user
   #Verify 2 arguments because script name is counted here   
   if not len(sys.argv) == 3:
      print "Usage:"
      print "python " + str(sys.argv[0]) +" <user> <project>"
      print "Example: python " + str(sys.argv[0]) + " leest CN"
      return False
   else:
      return sys.argv[1], sys.argv[2]

def getPotentialTraceIssues (user, project):
   #Default results to a failure
   result = "FAILURE"
   resDetails = "Found issue(s) in trace files for user " + str(user)
   
   #Command is to grep the trace file directory for all trace files that have "error" or "exception" in them/
   #$DBGOUTDIR points to the location of the trace files for the current day
   errorCommand = "egrep -i 'error|exception' $DBGOUTDIR/*.trc"
   errorList = cmds.getoutput(errorCommand)

   #If errors exceptions found, list each line in the results manager
   if errorList == "":
      resDetails = "No issues found in trace files"
      result = "OK"      
   for error in errorList.splitlines():
      errorFile = pu.responseString(action = "TRACE ISSUE", resultString = "", details = str(error))
      pu.writeResponse(errorFile, user)
   response = pu.responseString(action = "List trace issues", resultString = result, details = resDetails)

   pu.writeResponse(response, user)

def listTraceErrors (user, project):
   #Default results to a failure
   result = "FAILURE - TRACE ERROR"
   resDetails = "Found errors in trace files for user " + str(user)
   
   #Command is to grep the trace file directory for all trace files that have "error" in them/
   #$DBGOUTDIR points to the location of the trace files for the current day
   errorCommand = "grep -i 'error' $DBGOUTDIR/*.trc"
   errorList = cmds.getoutput(errorCommand)

   errorList = expungeDuplicates(errorList)
   whiteList = getWhiteList(project)
   errorList = expungeWhitelist(errorList, whiteList)
   
   #If errors found, list each line in the results manager
   if errorList == "":
      resDetails = "No errors found in trace files"
      result = "OK"      
   for error in errorList:
      errorFile = pu.responseString(action = "TRACE ERROR", resultString = "FAILURE - TRACE ERROR", details = str(error))
      pu.writeResponse(errorFile, user)
   response = pu.responseString(action = "List trace errors", resultString = result, details = resDetails)

   pu.writeResponse(response, user)
    
def listTraceExceptions (user, project):
   #Default results to a failure
   result = "FAILURE - TRACE EXCEPTION"
   resDetails = "Found exceptions in trace files for user " + str(user)
   
   #Command is to grep the trace file directory for all trace files that have "exception" in them/
   #$DBGOUTDIR points to the location of the trace files for the current day
   exceptionCommand = "grep -i 'exception' $DBGOUTDIR/*.trc"
   exceptionList = cmds.getoutput(exceptionCommand)

   exceptionList = expungeDuplicates(exceptionList)
   whiteList = getWhiteList(project)
   exceptionList = expungeWhitelist(exceptionList, whiteList)
   
   #If exceptions found, list each line in the results manager
   if exceptionList == "":
      resDetails = "No exceptions found in trace files"
      result = "OK"      
   for exception in exceptionList:
      exceptionFile = pu.responseString(action = "TRACE EXCEPTION", resultString = "FAILURE - TRACE EXCEPTION", details = str(exception))
      pu.writeResponse(exceptionFile, user)
   response = pu.responseString(action = "List trace exceptions", resultString = result, details = resDetails)

   pu.writeResponse(response, user)
   
   #parse the white list file into a list
def getWhiteList (project):
   whitelistFile = "data/"+project+"/tracewhitelist.txt"
   #read in white list file
   with open(whitelistFile) as f:
      rawList = f.readlines()

   #strip white space from list entries
   whiteList = []
   for item in rawList:
      whiteList.append(item.strip())
   return whiteList

#Remove the duplicates 
def expungeDuplicates (errorExceptionList):
   expungedList = [] 
   
   for trace in errorExceptionList.splitlines():
             
      #expunge the timestamp so we can purge duplicate messages.
      trace = re.sub(r"trc:.*\(\d{2}:\d{2}:\d{2}\)", "trc:", trace)
      trace = re.sub(r",", " ", trace)

      #compare to items already in list and only add first instance to new list
      if trace not in expungedList:
          expungedList.append(trace)

   return expungedList

def expungeWhitelist (errorExceptionList, whiteList):
   expungedList = [] 
   
   for trace in errorExceptionList:
      found = False
      for entry in whiteList: 
         regexp = re.compile(entry) 
         if regexp.search(trace):
            print "Found match"
            found = True
            break
      
      #only add if not found in the whitelist
      if not found:
         expungedList.append(trace)
                
   return expungedList
main()
