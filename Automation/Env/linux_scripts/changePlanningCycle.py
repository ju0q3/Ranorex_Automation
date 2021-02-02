import commands as cmds
import sys
import subprocess as sp
from time import sleep
import python_utils as pu

cleartool = "/usr/atria/bin/cleartool "

def validateInputs():
	#Need three inputs: user, cycle time in seconds, and division number
	#Verify 3 arguments because script name is counted here
	if not len(sys.argv) == 4:
		print "Usage:"
		print "python " + str(sys.argv[0]) +" <user> <cycle time (seconds)> <div number>"
		print "Example: python " + str(sys.argv[0]) + " leest 120 1"
		return False, False, False
	else:
		return sys.argv[1], sys.argv[2], sys.argv[3]	

def getLoid(division):
	print "Getting loid..."
	command = "db2tty -i sft_Timer | sgrep GENERATE"
	timerData = cmds.getoutput(command)
	
	print timerData
	
	div = "div" + str(division)
	print("Searching for loid in " + div)
	
	loid = ""
	partsDiv = timerData.split("## L")
	foundDiv = False
	for part in partsDiv:
		if div in part:
			print("Found division in db2tty results")
			foundDiv = part
	
	if not foundDiv:
		print("ERROR: Unable to find division in db2tty results")
		return loid
	
	partsFirst = foundDiv.split('[')
	partsSecond = partsFirst[1].split(':')
	loid = partsSecond[0]
	print "loid: " + str(loid)
		
	return loid
		
def setCycleTime(user, cycle, loid):
	print "Setting cycle time for " + str(loid) + " to " + str(cycle)
	command = "twkdb -u " + str(user) + " -r cause -e -v " + str(cycle) + \
		" -f sft_Timer::_timerPeriod -o " + str(loid)
	cmdList = command.split(" ")
		
	prompt = "modifying database object"
		
	p = sp.Popen(command, shell=True, stdin=sp.PIPE)
	p.stdin.write("y")
		

def main():
	
   user, cycle, division = validateInputs()
   if not user:
      exit()
		
   loid = getLoid(division)

   if loid:
      print("Setting new cycle time")
      result = "OK - determined loid.  Can attempt to change planning cycle."
      response = pu.responseString(action = "Change planning cycle", resultString = result)
      pu.writeResponse(response, user)
      setCycleTime(user, cycle, loid)
     
   else:
      print("ERROR: Failed to find loid")
      result = "FAILURE - Error finding loid"
      response = pu.responseString(action = "Change planning cycle", resultString = result)
      pu.writeResponse(response, user)
      exit()

	

main()

