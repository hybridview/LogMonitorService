namespace LogMonitor.ServerService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogMonitorServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.LogMonitorServerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // LogMonitorServiceProcessInstaller
            // 
            this.LogMonitorServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.LogMonitorServiceProcessInstaller.Password = null;
            this.LogMonitorServiceProcessInstaller.Username = null;
            this.LogMonitorServiceProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.LogMonitorServiceProcessInstaller_AfterInstall);
            // 
            // LogMonitorServerServiceInstaller
            // 
            this.LogMonitorServerServiceInstaller.Description = "Receives UDP log messages and writes to file.";
            this.LogMonitorServerServiceInstaller.DisplayName = "LogMonitorServerService";
            this.LogMonitorServerServiceInstaller.ServiceName = "LogMonitorServerService";
            this.LogMonitorServerServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LogMonitorServiceProcessInstaller,
            this.LogMonitorServerServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller LogMonitorServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller LogMonitorServerServiceInstaller;
    }
}