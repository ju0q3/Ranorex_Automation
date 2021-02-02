import commands as cmds
import sys
import subprocess as sp
import python_utils as pu

whitelistFile = "data/$::gProject/errqwhitelist.txt"
#whitelisted error queues should appear in the following format:
#  <error queue number>:<type>
# e.g.
#  div1QS17:ART_CIRCUIT_OCCUPANCY_MSG

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

#parse the white list file into a list
def getWhiteList (project):
   whitelistFile = "data/"+project+"/errqwhitelist.txt"
   #read in white list file
   with open(whitelistFile) as f:
      rawList = f.readlines()

   #strip white space from list entries
   whiteList = []
   for item in rawList:
      whiteList.append(item.strip())
   return whiteList

#run checkQ -z and get the list of error queues
def checkQ (user):
   command = "checkQ -z | grep errQ"
   errQs = cmds.getoutput(command)
   qs = []

   #todo verify actually this works for no errqs found
   pu.createResponseDir(user)
   filename = pu.outfileLocation + '/' + user  + "/output/checkQ.out"
   f = open(filename, 'w')
   if errQs == "":
      resDetails = "No errQs found for " + str(user)
      result = "OK"
   else:
      for q in errQs.splitlines():
         if q:
            f.write(q + "\n")
            parts = q.split(':')
            que = parts[-1].strip() + " " + parts[0].strip()
            qs.append(que)
   f.close()
   return qs

#run peekQ
def peekQ (errQs, user):
   types = []
   pu.createResponseDir(user)
   filename = pu.outfileLocation + '/' + user  + "/output/peekQ.out"
   f = open(filename, 'w')
   for q in errQs :
      peekOut = cmds.getoutput("peekQ " + str(q))
      f.write(str(peekOut) + "\n\n")
      f.write("------------------------------------\n\n")
      messages = peekOut.splitlines()
      for message in messages:
         splitter = ":MSG_DEL:"
         if splitter in message:
            qParts = q.split()
            errorNum = qParts[0]
            msgParts = message.split(splitter)
            msg = str(errorNum) + ":" + str(msgParts[2])
            types.append(msg)
   f.close()

   if ((errQs) and (not types)):
         print("Error running peekQ, check peekQ.out for details")
         result = "FAILURE - Error running peekQ, check peekQ.out for details"
         response = pu.responseString(action = "Check error queues", resultString = result)
         pu.writeResponse(response, user)

   return types


#check error queues against the white list
def verifyErrors (user, whiteList, errorTypes):
   numTrueErrors = 0
   numForgivenErrors = 0
   forgiveableSet = set(whiteList)
   errorSet = set(errorTypes)
   trueErrors = list(errorSet - forgiveableSet)
   for error in trueErrors:
      numTrueErrors += 1
   forgivenErrors = forgiveableSet.intersection(errorTypes)
   for error in forgivenErrors:
      numForgivenErrors += 1

   if numTrueErrors > 0:
      result = "FAILURE - Found error queues not on white list"
      response = pu.responseString(action = "Check error queues", resultString = result)
      pu.writeResponse(response, user)
      for error in trueErrors:
         result = "FAILURE - Found error queues: " + str(error)
         response = pu.responseString(action = "Check error queues", resultString = result)
         pu.writeResponse(response, user)
   if numForgivenErrors > 0:
      result = "WARNING - Found white listed error queues"
      response = pu.responseString(action = "Check error queues", resultString = result)
      pu.writeResponse(response, user)
      for error in forgivenErrors:
         result = "Found white listed error queues: " + str(error)
         response = pu.responseString(action = "Check error queues", resultString = result)
         pu.writeResponse(response, user)

   if (numTrueErrors == 0) and (numForgivenErrors == 0):
      print("No error queues found")
      result = "OK - No error queues found"
      response = pu.responseString(action = "Check error queues", resultString = result)
      pu.writeResponse(response, user)

def main():
   (user, project) = validateInputs()
   if not user:
      exit()
   print "Checking error queues"
   whiteList = getWhiteList(project)
   errorQueues = checkQ(user)
   errorTypes = peekQ(errorQueues, user)
   verifyErrors(user, whiteList, errorTypes)

main()
