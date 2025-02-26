::
:: Can neve runinstall/install due to service not registered, but instlaler tries to unregister it during uninstall. Causes fatal error and program is left!!!!
::


:: INSTALL the service to Windows.
cd "C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\"
InstallUtil.exe "c:\GKServices\ABM.LogMonitor.ServerService\ABM.LogMonitor.ServerService.exe"


:: Setup the windows service.
cd C:\GKServices\ABM.LogMonitor.ServerService
ABM.LogMonitor.ServerService.exe /service