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
   command = "mkdir -p " + homePds + "/java"
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)
   command = "chmod -R 777 " + homePds
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)

   #copy files
   files = createFileList()

   for file in files:
      command = "cp -r " + file + " " + homePds + "/java/"
      results = cmds.getoutput(command)
      if results:
         print "ERROR: " + str(results)

   properties = "/vobs/ACAD/system/data/config/properties"
   command = "cp -r " + properties + " " + homePds + "/data/config/"

   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)

def createFileList():
   javaPath = "/vobs/ACAD/system/java"

   files = [
               javaPath + "/lib",
               javaPath + "/oem_lib",
               javaPath + "/pvc",
               javaPath + "/bin"
               ]

   return files

def fixSymLinks ():
   #Replace symlinks with the proper files
   uicommander = "/vobs/ACAD/system/java/uicommander"
   localBin = homePds + "/java/bin/"
   properties = "/vobs/ACAD/system/data/config/properties"
   localProps = homePds + "/data/config/properties/"

   source = uicommander + "/UICommander.sh"
   destination = localBin + "/UICommander.sh"
   command = "rm -f " + destination
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)
   command = "cp " + source + " " + localBin
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)

   source = uicommander + "/UICommander.bat"
   destination = localBin + "/UICommander.bat"
   command = "rm -f " + destination
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)
   command = "cp " + source + " " + localBin
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)

   source = uicommander + "/UICommander.xml"
   destination = localBin + "/UICommander.xml"
   command = "rm -f " + destination
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)
   command = "cp " + source + " " + localBin
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)



   source = properties + "/client.properties.template"
   destination = localProps + "/client.properties.template"
   command = "rm -f " + destination
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)
   command = "cp " + source + " " + localProps
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)

   source = properties + "/clientSIM.properties.template"
   destination = localProps + "/clientSIM.properties.template"
   command = "rm -f " + destination
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)
   command = "cp " + source + " " + localProps
   results = cmds.getoutput(command)
   if results:
      print "ERROR: " + str(results)

def main():
    createPdsDir()
    fixSymLinks()

main()



