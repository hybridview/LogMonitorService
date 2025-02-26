using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;


namespace InstallHelper
{
    [RunInstaller(true)]
    public partial class UpgradeInstaller : System.Configuration.Install.Installer
    {
        public UpgradeInstaller()
        {
            //System.Diagnostics.Debugger.Launch();
            Debug.Write("UpgradeInstaller ctor >>>");
            InitializeComponent();
        }

        private readonly string _serviceName = "LogMonitorServerService";



        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
            StopService();
        }

        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
            StartService();
        }

        private void StartService()
        {
            using (var controller = new ServiceController(_serviceName))
            {
                if ((controller.Status == ServiceControllerStatus.Stopped) || (controller.Status == ServiceControllerStatus.StopPending))
                {
                    controller.Start();
                }
            }
        }

        private void StopService()
        {
            try
            {
                using (var controller = new ServiceController(_serviceName))
                {

                    if ((controller.Status != ServiceControllerStatus.Stopped) && (controller.Status != ServiceControllerStatus.StopPending))
                    {
                        controller.Stop();
                    }

                }
            }
            catch (InvalidOperationException)
            {
                // This exception is ignored, it happens when the service does not exist during the first time install.
                // throw;
            }
        }
    }
}
