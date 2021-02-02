import commands as cmds
import sys
import subprocess as sp
from time import sleep
import string
import python_utils as pu
import os
import os.path

#scriptDir = "/home/smoker"

def fileLength(file):
    i = 0
    for i, l in enumerate(file):
       pass
    return i + 1

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

def copyStatsDir():
    print "Copying stats directory from smoker"
    command = "cp -rf " + pu.scriptDir + "/stats ~"
    copyOut = cmds.getoutput(command)
    print copyOut

def fetchStats(user):
    print "Running fetch_stats_linux.sh script"
    statsFile = "stats/Mp1.pstats.csv"
    #remove Mp1.pstats.csv
    os.remove(statsFile)
    command = "~/stats/fetch_stats_wo.sh"
    fetchOut = cmds.getoutput(command)
    statsGenerated = os.path.isfile(statsFile)
    if statsGenerated:
       result = "OK"
       resDetails = "fetch_stats_linux.sh run successfully"
    else:
       result = "FAILURE"
       resDetails = "Failed to run fetch_stats_linux.sh"
    response = pu.responseString(action = "Fetch MP6x6 Stats", resultString = result, details = resDetails)
    pu.writeResponse(response, user)

def trimData():
    print "Backing up original Mp1.pstats.csv file"
    backup = "stats/Mp1.pstats.csv.bak"
    trimmedFile = "stats/Mp1.pstats.csv"
    command = "mv -f ~/" + trimmedFile + " ~/" + backup
    backupOut = cmds.getoutput(command)
    print backupOut

    command = "touch " + trimmedFile
    backupOut = cmds.getoutput(command)
    print backupOut

    print "Trimming zeroes from Mp1.pstats.csv file"

    originalStats = open(backup, "r")
    newStats = open(trimmedFile, "w")

    temp = ""
    numTrains = 0
    prevTrains = 0
    firstTrains = False

    for line in originalStats:
        parts = string.split(line,',')
        numTrains = parts[6]
        if not numTrains.isdigit():
           prevTrains = -1
        elif not firstTrains:
           if int(numTrains) > 0:
              firstTrains = True
        else:
           newStats.write(temp)
           if (int(numTrains) == 0):
              if (int(prevTrains) == 0):
                 break
           prevTrains = numTrains

        temp = line

    originalStats.close()
    newStats.close()

def runStats(user):
    print "Deleting old output folder"
    command = "rm -rf ~/stats/output"
    delOut = cmds.getoutput(command)
    command = "ls -ld ~/stats/output"
    outputListing = cmds.getoutput(command)
    if "No such" in outputListing:
       result = "OK"
       resDetails = "Successfully deleted output directory"
    else:
       result = "FAILURE"
       resDetails = "Failed to remove output directory"
    response = pu.responseString(action = "Fetch MP6x6 Stats", resultString = result, details = resDetails)
    pu.writeResponse(response, user)
    print "Running run_stats.sh script"
    command = "cd ~/stats; ./run_stats_wo.sh"
    runOut = cmds.getoutput(command)
    command = "ls -ld ~/stats/output"
    outputListing = cmds.getoutput(command)
    if not "No such" in outputListing:
       result = "OK"
       resDetails = "Successfully generated output"
    else:
       result = "FAILURE"
       resDetails = "Failed to generate output"
    response = pu.responseString(action = "Fetch MP6x6 Stats", resultString = result, details = resDetails)
    pu.writeResponse(response, user)

def main():
    #Need user for writing response files
    user = validateInputs()

    copyStatsDir()

    fetchStats(user)

    trimData()

    runStats(user)
	

main()

