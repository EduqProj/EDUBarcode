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
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduBarcode
{
    public partial class TestAadhaar : Form
    {
        string completeUrl = "https://localhost:11200/rd/capture";
        public TestAadhaar()
        {
            InitializeComponent();
        }

        private async void btnTestInovativeAadhaar_Click(object sender, EventArgs e)
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
            DisplayMessage("Validating Aadhaar, Please wait....");
            HttpResponseMessage retRes = await ValidateAadhaarInovativeAsync(sr.ReadToEnd()).ConfigureAwait(true); ;
            string result = await retRes.Content.ReadAsStringAsync();
            modInovativeAadharResp objResp = Newtonsoft.Json.JsonConvert.DeserializeObject<modInovativeAadharResp>(result);
            if (objResp.status.ToUpper().Trim() == "SUCCESS")
                MessageBox.Show("Aadhaar Validation success.");
            else
                MessageBox.Show("Aadhaar Validation failed, "+ objResp.message);
        }

        public async Task<HttpResponseMessage> ValidateAadhaarInovativeAsync(string bioXML)
        {
            InovativeAadharReq myobj = new InovativeAadharReq();
            //myobj.examCode = "";
            //myobj.examLevel = "";
            //myobj.center_code = "";
            myobj.bio = bioXML;
            myobj.roll_no = txtAppNo.Text.Trim();
            myobj.uid = txtCandAadharToken.Text;
            using (var client = new HttpClient())
            {
                string body1 = Newtonsoft.Json.JsonConvert.SerializeObject(myobj);
                HttpContent content = new StringContent(body1, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("token", "7jxguce3hxbakziqyxa5zaz39xf2btew");
                HttpResponseMessage resp = await client.PostAsync("https://edu.trustview.in/api/exa/nic/uidauth", content).ConfigureAwait(false);
                return resp;
            }
        }

        #region DisplayMessage
        public void DisplayMessage(string statusMessage)
        {
            lblStatus.Visible = true;
            lblStatus.Text = statusMessage;
            lblStatus.Refresh();
        }
        #endregion

        private void TestAadhaar_Load(object sender, EventArgs e)
        {
            txtCandAadharToken.Text = "010030605W0y2FluqsohUxjThdF3/ZqVLXczKMlaYNEdo+t+giPBtVSQ6tJFSD769btBlROV";
        }
    }
}

     
