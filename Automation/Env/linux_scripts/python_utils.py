############################################
#                                          #
#            .=     ,        =.            #
#    _  _   /'/    )\,/,/(_   \ \          #
#     `//-.|  (  ,\\)\//\)\/_  ) |         #
#     //___\   `\\\/\\/\/\\///'  /         #
#  ,-"~`-._ `"--'_   `"""`  _ \`'"~-,_     #
#  \       `-.  '_`.      .'_` \ ,-"~`/    #
#   `.__.-'`/   (-\        /-) |-.__,'     #
#     ||   |     \O)  /^\ (O/  |           #
#     `\\  |         /   `\    /           #
#       \\  \       /      `\ /            #
#        `\\ `-.  /' .---.--.\             #
#          `\\/`~(, '()      ('            #
#           /(O) \\   _,.-.,_)             #
#          //  \\ `\'`      /              #
#         / |  ||   `""""~"`               #
#       /'  |__||                          #
#             `o                           #
#                                          #
############################################


from __future__ import print_function
import sys
from sys import platform

try:
   import commands as cmds
except:
   import subprocess as cmds
 
import os.path
from datetime import datetime


scriptDir = "/home/smoker"; #todo: change this in other scripts to reference back to this.
outfileLocation = "/tmp/responses"

cleartool = "/usr/atria/bin/cleartool "

stepInfoLoc = "/tmp/responses/current_step_info.txt"

numResponses = 0


#     set afilename "$::gTempDir/automation/results/controller.$error_level.$count_str.response"
#     writeFile $afilename $response

#returns the hostname
def getHost():
   if platform != "win32":
      command = "hostname"
      host = cmds.getoutput(command)
   else:
      host = os.environ['COMPUTERNAME']

   return host

#creates response string to write to .response file
def responseString(action="", resultString="", host="", details="", parameters="", step="", expectFail=""):
   currentDate = datetime.now()
   dateString = currentDate.strftime("%m-%d-%Y %I:%M:%S %p")
   if not host:
      host = getHost()
   action = removeCommas(action)
   resultString = removeCommas(resultString)
   details = removeCommas(details)
   stepData = getStepData()
   parameters = removeCommas(parameters)
   #temp fix to pass in stepData information
   if stepData == "":
      stepData = step

   if expectFail == "1" or expectFail == 1:
      if resultString.startswith("OK -"):
         resultString = resultString.replace("OK -", "UNEXPECTED PASS -")
      elif resultString.startswith("PASS -"):
         resultString = resultString.replace("PASS -", "UNEXPECTED PASS -")
      elif resultString.startswith("FAILURE -"):
         resultString = resultString.replace("FAILURE -", "UNEXPECTED FAILURE -")

   response = str(host) + "," + str(dateString) + "," + str(action) + "," + \
      str(resultString) + "," + str(details) + "," + str(parameters) + "," + \
      str(stepData)

   print (response)
   return response

#writes .response file to linux and windows system.  will need to be copied to correct location after
def writeResponse(response, user=""):
   #create response files in a temporary directory.  they will be copied to the correct
   #directory by runpython.sh
   fileDirectory = ""

   if platform != "win32":
      fileDirectory = "/tmp/responses/" + str(user)

      createResponseDir(user)

   else:
      fileDirectory = os.path.join(os.getenv('TEMP'), "Automation\Results")


   currentDate = datetime.now()
   dateString = currentDate.strftime("%m%d%Y%I%M%S")
   
   global numResponses
   numResponses += 1

   fileName = fileDirectory + '/' + dateString + str(numResponses) + ".response"
   with open(fileName, 'w+') as responseFile:
      responseFile.write(response)

   responseFile.close()

def removeCommas(someString):
   newString = someString.replace(',',' ')
   return newString

def getStepData():
   #check if step info exists, if not return empty string
   #this would happen if the script is being run from somewhere
   #other than the automation controller.
   stepData = ""
   if os.path.exists(stepInfoLoc):
      dataFile = open(stepInfoLoc, "r")
      for line in dataFile:
         stepData = stepData + str(line).rstrip()
   return stepData

def createResponseDir(user):
   command = "mkdir -p /tmp/responses/" + str(user) + "/output"
   out = cmds.getoutput(command)
