using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace iTOLEDOservice
{
    public partial class Service1 : ServiceBase
    {
        Process process;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ProcessStartInfo info = new ProcessStartInfo(@"C:\iTOLEDO\iTOLEDO.exe");
            info.UseShellExecute = false;
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.CreateNoWindow = false;
            info.ErrorDialog = false;
            info.WorkingDirectory = @"C:\iTOLEDO\";
            info.WindowStyle = ProcessWindowStyle.Hidden;
            process = Process.Start(info);
        }

        protected override void OnStop()
        {
            process.Kill();
        }
    }
}
