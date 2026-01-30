using EduBarcode.Models;
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
using System.Xml;

namespace EduBarcode
{
    public partial class AadharVerify : Form
    {
        string deviceInfo = string.Empty;
        string completeUrl = "https://localhost:11200/rd/capture";
        Module mod = new Module();
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
                //string completeUrl = "https://localhost:11200/rd/capture";
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
            if(ddlReason.SelectedIndex == -1)
            {
                MessageBox.Show("Please selet reason.");
                return;
            }
            DialogResult result = MessageBox.Show(
               "Do you want to continue or cancel?", // Message text
               "Confirmation",                      // Message box title
               MessageBoxButtons.OKCancel,          // Buttons to display
               MessageBoxIcon.Question              // Icon to display
            );
            if (result == DialogResult.OK)
            {
                string skipComments = ddlReason.SelectedItem.ToString() + ", " + txtComment.Text;
                MainFrm.Hdoc.GetElementById("txtAddharVerifyComments").SetAttribute("value", skipComments);
                MainFrm.Hdoc.GetElementById("txtAadharStatus").SetAttribute("value", "0");
                MainFrm.Hdoc.GetElementById("btnSkip").InvokeMember("click");
                mod.Navigate = 1;
                this.Dispose();
                this.Close();
            }
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
        private async void btnAadharVerifyASYNC_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ConfigurationManager.AppSettings["apiURL"].ToString() + "api/EduAPI/VerifyAadharAsyc");
            try
            {
                if (txtCandAadharToken.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Aadhar no. or Token cannot't be blank.");
                    return;
                }
                if (CheckDeviceReady() == "NOTREADY")
                {
                    MessageBox.Show("Access Finger Print Device is not ready,  check properly connected.");
                    return;
                }
                HttpResponseMessage retRes = await PostFPforVerifyAsync().ConfigureAwait(true);
                string result = await retRes.Content.ReadAsStringAsync();
                modInovativeAadharResp objResp = Newtonsoft.Json.JsonConvert.DeserializeObject<modInovativeAadharResp>(result);
                if (objResp.status.ToUpper().Trim() == "SUCCESS")
                {
                    MainFrm.Hdoc.GetElementById("txtAadharStatus").SetAttribute("value", "1");
                    MainFrm.Hdoc.GetElementById("btnsubmit").InvokeMember("click");
                    mod.Navigate = 1;
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    DisplayMessage("");
                    MessageBox.Show(objResp.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region PostFPforVerify
        public async Task<HttpResponseMessage> PostFPforVerifyAsync()
        {
            DisplayMessage("Capturing finger print,  Please wait...");
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
            //aadhaarRequest myobj = new aadhaarRequest();
            //myobj.rdData = sr.ReadToEnd();//.Replace("\"", "\\\"");
            //myobj.regNO = txtAppNo.Text;
            //myobj.aadhaarNumber = txtCandAadharToken.Text;
            //myobj.paperID = MainFrm.Hdoc.GetElementById("txtQPaperID").GetAttribute("value");
            //myobj.examCode = "NIFT";
            //myobj.centerID = "1";
            InovativeAadharReq myobj = new InovativeAadharReq();
            myobj.bio = sr.ReadToEnd();
            myobj.roll_no = txtAppNo.Text.Trim();
            myobj.uid = txtCandAadharToken.Text;
            myobj.qPaperID = MainFrm.Hdoc.GetElementById("txtQPaperID").GetAttribute("value");
            DisplayMessage("Validating Aadhaar, Please wait....");
            using (var client = new HttpClient())
            {
                string body1 = Newtonsoft.Json.JsonConvert.SerializeObject(myobj);
                HttpContent content = new StringContent(body1, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await client.PostAsync(ConfigurationManager.AppSettings["apiURL"].ToString() + "api/EduAPI/VerifyAadharAsyc", content).ConfigureAwait(false);
                #region code
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var content = new StringContent(body1, Encoding.UTF8, "application/json");
                //var resp = await client.PostAsJsonAsync(ConfigurationManager.AppSettings["apiURL"].ToString() + "/api/EduAPI/VerifyAadharAsyc", body1).ConfigureAwait(false);

                //if (resp.IsSuccessStatusCode)
                //{
                //    string result = await resp.Content.ReadAsStringAsync();
                //    aadhaarResponse objResp =  Newtonsoft.Json.JsonConvert.DeserializeObject<aadhaarResponse>(result);
                //    if (objResp.status == true)
                //    {
                //        MainFrm.Hdoc.GetElementById("btnsubmit").InvokeMember("click");
                //    }
                //    else
                //    {
                //        MessageBox.Show(objResp.error);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Error: " + resp.StatusCode);
                //}
                #endregion
                //MessageBox.Show(resp.ToString());
                return resp;
            }
        }
        #endregion

        #region DisplayMessage
        public void DisplayMessage(string statusMessage)
        {
            lblStatus.Visible = true;
            lblStatus.Text = statusMessage;
            lblStatus.Refresh();
        }
        #endregion

        #region checkBox1_CheckedChanged
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                panel1.Visible = true;
            else
                panel1.Visible = false;
        }
        #endregion

        #region CheckDeviceReady
        public string CheckDeviceReady()
        {
            string completeUrl = "https://localhost:11200/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
            request.Method = "RDSERVICE";
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "text/xml";
            WebResponse response = default(WebResponse);
            response = request.GetResponse();
            Stream str = response.GetResponseStream();
            StreamReader sr = new StreamReader(str);
            string finalResponse = sr.ReadToEnd();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(finalResponse);
            // Access the document element and get the attribute value by name
            return doc.DocumentElement.GetAttribute("status");
        }
        #endregion

        #region GetDeviceInfo
        public string GetDeviceInfo()
        {
            string completeUrl = "https://localhost:11200/rd/info";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
            request.Method = "DEVICEINFO";
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "text/xml";
            WebResponse response = default(WebResponse);
            response = request.GetResponse();
            Stream str = response.GetResponseStream();
            StreamReader sr = new StreamReader(str);
            return sr.ReadToEnd();
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

    #region InovativeAadharReq
    public class InovativeAadharReq
    {
        public string bio { get; set; }
        public string roll_no { get; set; }
        public string uid { get; set; }
        public string center_code { get; set; }
        public string examCode { get; set; }
        public string examLevel { get; set; }

        public string qPaperID { get; set; }
    }
    #endregion
}
