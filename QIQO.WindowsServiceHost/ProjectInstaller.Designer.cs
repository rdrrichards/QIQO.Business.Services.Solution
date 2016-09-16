namespace QIQO.WindowsServiceHost
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
            this.QIQOServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.QIQOServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // QIQOServiceProcessInstaller
            // 
            this.QIQOServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.QIQOServiceProcessInstaller.Password = null;
            this.QIQOServiceProcessInstaller.Username = null;
            // 
            // QIQOServiceInstaller
            // 
            this.QIQOServiceInstaller.ServiceName = "QIQO Business Application Service";
            this.QIQOServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.QIQOServiceProcessInstaller,
            this.QIQOServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller QIQOServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller QIQOServiceInstaller;
    }
}