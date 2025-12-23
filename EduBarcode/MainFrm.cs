using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduBarcode
{
    public partial class MainFrm : Form
    {
        public static string strexepath = Application.StartupPath.Replace(@"\Debug", "").Replace(@"\bin", "");
        public static string url = ConfigurationSettings.AppSettings["ServerAdd"].ToString().Trim();
        public static HtmlDocument Hdoc;
        public string surl, chkurl;
        public string[] uarr1, uarr2;
        public static string AppNo;
        public static string Aadhar_Token;
        public MainFrm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(configuration.AppSettings.Settings["ServerAdd"].Value);
            //this.TopMost = true;
            if(configuration.AppSettings.Settings["ServerAdd"].Value.ToUpper().Contains("LOCALHOST"))
            {
                ManageSettings ms = new ManageSettings();
                ms.delMS += new ManageSettings.delManageSettings(ManageAppSettings);
                ms.ShowDialog();
            }
        }
        public void ManageAppSettings(object sender)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                string[] urlArr = configuration.AppSettings.Settings["ServerAdd"].Value.Split('/');
                string[] urlTestPhoto = configuration.AppSettings.Settings["TestPathURL"].Value.Split('/');
                string[] urlAPI = configuration.AppSettings.Settings["apiURL"].Value.Split('/');
                string newUrl = urlArr[0] + "/";
                newUrl += "/" + ((TextBox)(sender)).Text.Trim();

                string serverNewUrl = newUrl + "/" + urlArr[3] + "/";
                string testNewUrl = newUrl + "/" + urlTestPhoto[3] + "/";
                string apiNewUrl = newUrl + "/" + urlAPI[3] + "/";
                configuration.AppSettings.Settings["ServerAdd"].Value = serverNewUrl;
                configuration.AppSettings.Settings["TestPathURL"].Value = testNewUrl;
                configuration.AppSettings.Settings["apiURL"].Value = apiNewUrl;
                configuration.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close CloseForm = new Close();
            CloseForm.Focus();
            CloseForm.TopMost = true;
            CloseForm.Show();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            wb.Navigate(url + "/Login.aspx");
        }
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Hdoc = wb.Document;
            surl = e.Url.ToString().ToLower();
            if (surl.IndexOf("?name=") != -1)
            {
                uarr1 = surl.Split('?');
                uarr2 = uarr1[0].Split('/');
            }
            else if (surl.IndexOf("?") != -1)
            {
                uarr1 = surl.Split('?');
                uarr2 = uarr1[0].Split('/');
            }
            else
                uarr2 = surl.Split('/');

            chkurl = uarr2[uarr2.Length - 1];
            if (chkurl == "verifyaadhar.aspx")
            {
                //AppNo = Hdoc.GetElementById("applno").GetAttribute("value");
                AadharVerify objFP = new AadharVerify();
                objFP.ShowDialog();
            }
            else if (chkurl == "takefingerprint.aspx")
            {
                //AppNo = Hdoc.GetElementById("applno").GetAttribute("value");
                TakeFP objFP = new TakeFP();
                objFP.ShowDialog();
            }
            else if (chkurl == "takephoto.aspx")
            {
                //AppNo = Hdoc.GetElementById("applno").GetAttribute("value");
                TakePhoto objPhto = new TakePhoto();
                objPhto.ShowDialog();
            }
            else if (chkurl == "verifythumb.aspx")
            {
                FPCaptureVerify fp = new FPCaptureVerify();
                fp.ShowDialog();
            }
        }
    }
}
