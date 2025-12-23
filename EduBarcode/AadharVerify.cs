using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduBarcode
{
    public partial class AadharVerify : Form
    {
        public AadharVerify()
        {
            InitializeComponent();
        }
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

        private void btnSkip_Click(object sender, EventArgs e)
        {

        }
    }
}
