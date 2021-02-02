rem - kill off the STE Remote Control Client procs

taskkill /f /t /im SteRemoteControlClient.exe 2> nul
taskkill /f /t /im VehicleSimulator.exe 2> nul
taskkill /f /t /im MessageTranslator.exe 2> nul
taskkill /f /t /im FieldDeviceSimulator.exe 2> nul
taskkill /f /t /im FieldInterfaceSimulator.exe 2> nul
taskkill /f /t /im TrainControl.exe 2> nul
taskkill /f /t /im TestInterface.exe 2> nul
taskkill /f /t /im OTCMRSimulator.exe 2> nul
taskkill /f /t /im CadSimController.exe 2> nul
taskkill /f /t /im CadInformationServer.exe 2> nul
taskkill /f /t /im SystemManager.exe 2> nul
taskkill /f /t /im SystemDirector.exe 2> nul
taskkill /f /t /im cadsimmgr.exe 2> nul

exit



