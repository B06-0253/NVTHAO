namespace WinServiceProject
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Linq;
    using TPA.Business;
    using TPA.Model;
    using TPA.Utils;
    using System.Data;
    using TPA;
    using System.Configuration;
    using System.Timers;
    using BMS;

    class WinService : System.ServiceProcess.ServiceBase
    {
        // The main entry point for the process
        static void Main()
        {
            System.ServiceProcess.ServiceBase[] ServicesToRun;
            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new WinService() };
            System.ServiceProcess.ServiceBase.Run(ServicesToRun);

            #if(!DEBUG)
                       ServiceBase[] ServicesToRun;
                       ServicesToRun = new ServiceBase[] 
	                { 
	                    new WinService() 
	                };
                       ServiceBase.Run(ServicesToRun);
            #else
                    WinService myServ = new WinService();
                    myServ.UpdateDMVT();
            #endif
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Global.DefaultFileName = "default.ini";
        }

        Timer _timer;
        string _path = "";
        private void SchedularCallback(object e)
        {
            this.UpdatePrice();
            UpdateDMVT();
        }

        public void UpdatePrice()
        {
            LibQLSX.ExcuteSQL("spGetPriceOfPart1");
        }

        public void UpdateDMVT()
        {
            DataTable dt = LibQLSX.Select("exec spGetNewModule");
            if (dt.Rows.Count == 0) return;
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    string moduleCode = TextUtils.ToString(item["FolderCode"]);
                    string _serverPathCK = string.Format("Thietke.Ck/{0}/{1}.Ck/VT.{1}.xlsm", moduleCode.Substring(0, 6), moduleCode);
                    DocUtils.InitFTPQLSX();
                    if (DocUtils.CheckExits(_serverPathCK))
                    {
                        DocUtils.DownloadFile(_path, "VT." + moduleCode + ".xlsm", _serverPathCK);
                        string filePathDMVT = _path + "VT." + moduleCode + ".xlsm";
                        if (!File.Exists(filePathDMVT)) continue;
                        DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(filePathDMVT, "DMVT");
                        TextUtils.AddDMVTfromModule(filePathDMVT);
                        File.Delete(filePathDMVT);
                    }    
                }
                catch
                {
                }                
            }
        }

        public void WriteToFile(string text)
        {
            //string path = TextUtils.ToString(System.Configuration.ConfigurationSettings.AppSettings["Path"]);
            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}
            //using (StreamWriter writer = new StreamWriter(path, true))
            //{
            //    writer.WriteLine(text);
            //    writer.Close();
            //}
        }

        private void _timer_Elapsed(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateDMVT();
        }

        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        ///  
        protected override void OnStart(string[] args)
        {
            double interval = double.Parse(System.Configuration.ConfigurationSettings.AppSettings["Interval"]);
            _path = TextUtils.ToString(System.Configuration.ConfigurationSettings.AppSettings["Path"]);
            _timer = new Timer();
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Interval = interval;
            _timer.Enabled = true;
            _timer.Start();
        }
        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            _timer.Enabled = false;
            _timer = null;
        }
    }
}