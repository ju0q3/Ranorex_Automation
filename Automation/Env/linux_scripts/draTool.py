
import commands as cmds
import sys
import subprocess as sp
import python_utils as pu

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
   resDetails = "DRA recalc tool failed"
   command = "DRATool -c recalc_dras"
   health = cmds.getoutput(command)
   print health
   if "DRA Recalculation complete" in health:
      resDetails = "DRA Recalculation complete!"
      result = "OK"
   else:
      resDetails += ": " + str(health)

   response = pu.responseString(action = "Check DRA recalc tool", resultString = result, details = resDetails)
   pu.writeResponse(response, user)


def main():
   user = validateInputs()
   if not user:
      exit()
   checkHealth(user)

main()
