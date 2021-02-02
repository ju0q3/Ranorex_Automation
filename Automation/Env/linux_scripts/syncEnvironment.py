#           o
#           |  __
#           | /__\
#           | X~~|
#           |-\|//-.
#          /|`.|'.' \
#         |,|.\~~ /||
#         |:||   ';||
#         ||||   | ||
#         \ \|     |`.
#         |\X|     | |
#         | .'     |||
#         | |   .  |||
#         |||   |  `.|
#         ||||  |   ||
#         ||||  |   ||
#         `+.__._._+~' 
#
#     Imperial Royal Guard


import commands as cmds

homePds = "~/pdsFromVob"

def createPdsDir():
   #remove stale files
   command = "rm -rf " + homePds
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)

   #create directory
   command = "mkdir -p " + homePds + "/data/config"
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)
   command = "chmod -R 777 " + homePds
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)

   properties = "/vobs/ACAD/system/data/config/properties"
   command = "cp -r " + properties + " " + homePds + "/data/config/"

   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)


def main():
    createPdsDir()

main()



