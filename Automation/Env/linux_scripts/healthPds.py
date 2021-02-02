
import commands as cmds
import sys
import subprocess as sp
import python_utils as pu

corefilesDir = "/tms/corefiles"

def validateInputs():
	#Need one inputs: user
	#Verify 2 arguments because script name is counted here
    if not len(sys.argv) == 2:
		print "Usage:"
		print "python " + str(sys.argv[0]) +" <user>"
		print "Example: python " + str(sys.argv[0]) + " leest"
		return False
    else:
		return sys.argv[1]

def checkHealth (user):
   result = "FAILURE"
   resDetails = "healthPDS failed"
   command = "healthPDS"
   health = cmds.getoutput(command)
   if "All processes are running" in health:
      resDetails = "All processes are running"
      result = "OK"
   else:
      resDetails += ": " + str(health)

   response = pu.responseString(action = "Check PDS health", resultString = result, details = resDetails)
   pu.writeResponse(response, user)


def main():
   user = validateInputs()
   if not user:
      exit()
   checkHealth(user)

main()
