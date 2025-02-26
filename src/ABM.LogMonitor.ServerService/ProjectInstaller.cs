using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;


namespace LogMonitor.ServerService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            //System.Diagnostics.Debugger.Launch();
            Debug.Write("ProjectInstaller ctor >>>");
            InitializeComponent();
            //this.BeforeUninstall += new InstallEventHandler(ProjectInstaller_BeforeUninstall);
            //this.Committed += new InstallEventHandler(ProjectInstaller_Committed);

            Committed += StartService; // start service after installing
            BeforeInstall += StopService; // stop service from previous installers (updating)
            BeforeUninstall += StopService; // stop service before uninstalling (removing)
            Debug.Write("<<< ProjectInstaller ctor");
        }
        /*
        void ProjectInstaller_Committed(object sender, InstallEventArgs e)
        {
            ServiceController sc = new ServiceController("LogMonitorServerService");
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                sc.Start();
            }
        }

        void ProjectInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        {
            try
            {
                ServiceController sc = new ServiceController("LogMonitorServerService");
                if (sc != null && sc.Status != ServiceControllerStatus.Stopped)
                {
                    sc.Stop();
                }
            }
            catch (Exception)
            {

            }
        }
         */
        private void StopService(object sender, InstallEventArgs e)
        {
            Debug.Write("StopService");
            try
            {
                var controller = new ServiceController(LogMonitorServerServiceInstaller.ServiceName);
                if ((controller.Status != ServiceControllerStatus.Stopped) &&
                    (controller.Status != ServiceControllerStatus.StopPending))
                {
                    controller.Stop();
                }
            }
            catch (System.InvalidOperationException)
            {
                // ignore it, no such service exists
                //throw;
            }
        }

        private void StartService(object sender, InstallEventArgs e)
        {
            var controller = new ServiceController(LogMonitorServerServiceInstaller.ServiceName);
            if ((controller.Status == ServiceControllerStatus.Stopped) ||
            (controller.Status == ServiceControllerStatus.StopPending))
            {
                controller.Start();
            }
        }

        private void LogMonitorServiceProcessInstaller_AfterInstall(object sender, InstallEventArgs e)
        {

        }
        /*
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
        }*/
    }
}
