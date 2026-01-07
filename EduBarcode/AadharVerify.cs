using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduBarcode
{
    public partial class AadharVerify : Form
    {
        string deviceInfo = string.Empty;
        string completeUrl = "https://localhost:11200/rd/capture";
        public AadharVerify()
        {
            InitializeComponent();
        }

        #region btnVerifyAadhar_Click
        private void btnVerifyAadhar_Click(object sender, EventArgs e)
        {
            try
            {
                aadharStatus.Visible = true;
                aadharStatus.Update();
                string completeUrl = "https://localhost:11200/rd/capture";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
                request.Method = "CAPTURE";
                request.Credentials = CredentialCache.DefaultCredentials;
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                string pidOptString = "<PidOptions ver=\"1.0\" env=\"P\"><Opts fCount=\"1\" fType=\"2\" format=\"0\" pidVer=\"2.0\" timeout=\"20000\" posh =\"UNKNOWN\" env=\"P\" wadh=\"\" /></PidOptions>";
                writer.WriteLine(pidOptString);
                writer.Close();
                WebResponse response = default(WebResponse);
                response = request.GetResponse();
                Stream str = response.GetResponseStream();
                StreamReader sr = new StreamReader(str);
                string finalResponse = sr.ReadToEnd();
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("Content-Type", "application/json");
                    aadhaarRequest myobj = new aadhaarRequest();
                    myobj.rdData = finalResponse;
                    myobj.regNO = MainFrm.Hdoc.GetElementById("applno").GetAttribute("value");
                    myobj.aadhaarNumber = MainFrm.Hdoc.GetElementById("txtAadharToken").GetAttribute("value");
                    string body1 = Newtonsoft.Json.JsonConvert.SerializeObject(myobj);
                    string resp = wc.UploadString(ConfigurationManager.AppSettings["apiURL"].ToString()+ "/api/EduAPI/VerifyAadhar", "POST", body1);
                    //Uri localApi = new Uri(ConfigurationManager.AppSettings["apiURL"].ToString() + "/api/EduAPI/VerifyAadhar");
                    //string t = await wc.DownloadStringAsync(localApi, "POST", body1);
                }
                MainFrm.Hdoc.GetElementById("btnsubmit").InvokeMember("click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Dispose();
                this.Close();
            }
        }
        #endregion

        #region btnSkip_Click
        private void btnSkip_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region AadharVerify_Load
        private void AadharVerify_Load(object sender, EventArgs e)
        {
            txtAppNo.Text = MainFrm.Hdoc.GetElementById("applno").GetAttribute("value");
            txtCandAadharToken.Text = MainFrm.Hdoc.GetElementById("txtAadharToken").GetAttribute("value");
        }
        #endregion

        #region btnAadharVerifyASYNC_Click
        private void btnAadharVerifyASYNC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCandAadharToken.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Aadhar no. or Tokan cannot't be blank");
                    return;
                }
                PostFPforVerify().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region PostFPforVerify
        public async Task PostFPforVerify()
        {
            lblStatus.Visible = true;
            lblStatus.Text = "Capturing Finger Print Data.";
            lblStatus.Refresh();
            string pidData = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
            request.Method = "CAPTURE";
            request.Credentials = CredentialCache.DefaultCredentials;
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            string pidOptString = "<PidOptions ver=\"1.0\" env=\"P\"><Opts fCount=\"1\" fType=\"2\" format=\"0\" pidVer=\"2.0\" timeout=\"20000\" posh =\"UNKNOWN\" env=\"P\" wadh=\"\" /></PidOptions>";
            writer.WriteLine(pidOptString);
            writer.Close();
            WebResponse response = default(WebResponse);
            response = request.GetResponse();
            Stream str = response.GetResponseStream();
            StreamReader sr = new StreamReader(str);
            aadhaarRequest myobj = new aadhaarRequest();
            myobj.rdData = sr.ReadToEnd();
            myobj.regNO = txtAppNo.Text;
            myobj.aadhaarNumber = txtCandAadharToken.Text;
            myobj.paperID = MainFrm.Hdoc.GetElementById("txtQPaperID").GetAttribute("value");
            myobj.examCode = "NIFT";
            myobj.centerID = "1";
            lblStatus.Text = "Validating Aadhar...";
            lblStatus.Refresh();
            using (var client = new HttpClient())
            {
                //client.he.Add("Content-Type", "application/json");
                string body1 = Newtonsoft.Json.JsonConvert.SerializeObject(myobj);
                HttpContent content = new StringContent(body1, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var content = new StringContent(body1, Encoding.UTF8, "application/json");
                //var resp = await client.PostAsJsonAsync(ConfigurationManager.AppSettings["apiURL"].ToString() + "/api/EduAPI/VerifyAadharAsyc", body1).ConfigureAwait(false);
                HttpResponseMessage resp = await client.PostAsync(ConfigurationManager.AppSettings["apiURL"].ToString() + "/api/EduAPI/VerifyAadharAsyc", content).ConfigureAwait(false);
                if (resp.IsSuccessStatusCode)
                {
                    string result = await resp.Content.ReadAsStringAsync();
                    aadhaarResponse objResp =  Newtonsoft.Json.JsonConvert.DeserializeObject<aadhaarResponse>(result);
                    if(objResp.status == true)
                        MainFrm.Hdoc.GetElementById("btnsubmit").InvokeMember("click");
                    else
                    {
                        lblStatus.Text = "Some error";
                        //MessageBox.Show(this, "Some error occured.", "Aadhar Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Some error occured.");
                    }
                }
                else
                {
                    MessageBox.Show("Error: " + resp.StatusCode);
                }
                //lblStatus.Text = "";
                lblStatus.Refresh();
            }
        }
        #endregion
    }

    #region aadhaarRequest
    public class aadhaarRequest
    {
        public string regNO { get; set; }
        public string paperID { get; set; }
        public string centerID { get; set; }
        public string aadhaarNumber { get; set; }
        public string examCode { get; set; }
        public string rdData { get; set; }
    }
    #endregion

    #region aadhaarResponse
    public class aadhaarResponse
    {
        public string regNO { get; set; }
        public string paperID { get; set; }
        public string centerID { get; set; }
        public bool status { get; set; }
        public string error { get; set; }
    }
    #endregion
}
