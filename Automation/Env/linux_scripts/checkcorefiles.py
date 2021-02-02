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

def listCoreFiles (user):
   result = "FAILURE"
   resDetails = "Found corefiles for user " + str(user)
   command = "ls -l " + str(corefilesDir) + " | grep " + "' " + str(user) + " '"
   listing = cmds.getoutput(command)
   if listing == "":
      resDetails = "No corefiles found for " + str(user)
      result = "OK"

   for core in listing.splitlines():
      coreFile = pu.responseString(action = "CORE FILE", resultString = "", details = str(core))
      pu.writeResponse(coreFile, user)
   response = pu.responseString(action = "List core files", resultString = result, details = resDetails)

   pu.writeResponse(response, user)


def main():
   user = validateInputs()
   print "Checking for corefiles for " + str(user)
   if not user:
      exit()
   listCoreFiles(user)

main()
