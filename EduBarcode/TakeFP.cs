using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EduBarcode
{
    public partial class TakeFP : Form
    {
        TMF20FPLibrary fpLibrary = new TMF20FPLibrary();
        CaptureResult captrslt1, captrslt2;
        DeviceInfo deviceInfo;
        byte[] rawBytes = new byte[300 * 400];

        public TakeFP()
        {
            InitializeComponent();
            this.TopMost = true;
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //lblRollNo.Text = MainFrm.Hdoc.GetElementById("applno").GetAttribute("value");
            //txtAdrToken.Text = MainFrm.Hdoc.GetElementById("AadharTok").GetAttribute("value");
            lblNRollNo.Text = MainFrm.Hdoc.GetElementById("applno").GetAttribute("value");
            //txtVRollNo.Text = "DM920001";
            //txtAdrToken.Text = "503902048136";
        }

        #region fingerCapture1
        void fingerCapture1()
        {
            try
            {
                captrslt1 = new CaptureResult();
                int respCode;
                respCode = capture(captrslt1);
                if (TMF20ErrorCodes.SUCCESS == respCode)
                {
                    //pictureBox.ImageLocation = @"image\right.bmp";
                    //pictureBox1.ImageLocation = @"image\right1.bmp";
                    string msg = captrslt1.errorString + "\n";
                    msg += "NFIQ : " + captrslt1.nfiq + "\n";
                    msg += "Minutiae count : " + captrslt1.minutiaeCount;
                    //statusBox.Text = msg;
                    Bitmap bmp = CreateGreyscaleBitmap(rawBytes, 300, 400);
                    //String sfilename = Environment.CurrentDirectory + "\\F" + MainFrm.AppNo + ".bmp";
                    //String sfilename = Environment.CurrentDirectory + "\\FManju.bmp";
                    //bmp.Save(sfilename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //SaveFileDialog sfd = new SaveFileDialog();
                    //sfd.Filter = "Bitmap image |*.bmp";
                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    //String path = Path.GetFullPath(sfd.FileName);
                    //MessageBox.Show(sfilename);
                    //bmp.Save(sfilename);
                    String sfilename = Environment.CurrentDirectory + "\\" + lblNRollNo.Text + ".txt";
                    File.WriteAllBytes(sfilename, captrslt1.fmrBytes);
                    //}
                    using (WebClient oclient = new WebClient())
                    {
                        Byte[] responseArray = oclient.UploadFile(MainFrm.url + "getuploadfile.aspx?ImgType=FPT", "POST", sfilename);
                        oclient.Dispose();
                        FileInfo fi = new FileInfo(sfilename);
                        fi.Delete();
                    }
                    MainFrm.Hdoc.GetElementById("btnsubmit").InvokeMember("click");
                }
                else
                {
                    //pictureBox.ImageLocation = @"image\wrong.bmp";
                    //pictureBox1.ImageLocation = @"image\wrong1.bmp";
                    //statusBox.Text = captrslt1.errorString;
                    MessageBox.Show(captrslt1.errorString);
                }
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

        #region capture
        int capture(CaptureResult captrslt)
        {
            int response = -1;
            response = fpLibrary.captureFingerprint(captrslt, 60000);
            rawBytes = captrslt.rawImageBytes;
            //btn_save.Enabled = true;
            return response;
        }
        #endregion

        #region CreateGreyscaleBitmap
        public static Bitmap CreateGreyscaleBitmap(byte[] buffer, int width, int height)
        {
            try
            {
                Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bmpData.Scan0, width * height);
                bmp.UnlockBits(bmpData);

                ColorPalette pal = bmp.Palette;
                for (int i = 0; i < 256; i++)
                    pal.Entries[i] = Color.FromArgb(i, i, i);
                bmp.Palette = pal;
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ":" + ex.StackTrace, "Tatvik TMF20");
                return null;
            }
        }
        #endregion

        #region btnOffCapture_Click
        private void btnOffCapture_Click(object sender, EventArgs e)
        {
            fingerCapture1();
        }
        #endregion

        #region btn_capture_Click
        private void btn_capture_Click(object sender, EventArgs e)
        {
            //fingerCapture1();
            ////if (!chkAadhar.Checked)
            //if (txtAdrToken.Text.Trim() == "")
            //    MessageBox.Show("Please enter valid Aadhar No or Token");
            //else
            //    CheckAadhaar();
        }
        #endregion

        #region CheckAadhaar
        public void CheckAadhaar()
        {
            //PidData.Text = String.Empty;
            string str = string.Empty;
            try
            {
                
                using (WebClient wc = new WebClient())
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //string pidOptionsXml = "<PidOptions ver='1.0'><Opts env='P' fCount='1' fType='0' format='0' pType='0' pCount='0' pgCount='0' pTimeout='20000' pidVer='2.0'>" +
                    //                        "</Opts><Demo></Demo><CustOpts></CustOpts><Bios></Bios></PidOptions>";
                    //string url = "http://127.0.0.1:11101/rd/capture";
                    //string response = wc.UploadString(url, "CAPTURE", pidOptionsXml);
                    //PidData.Text = response;
                    //XmlDocument doc = new XmlDocument();
                    //doc.LoadXml(response);
                    //XmlNode nd = doc.SelectSingleNode("//PidData//Resp//@errCode");
                    //if (nd != null)
                    //{
                    //    if(nd.Value != "0")
                    //    {
                    //        MessageBox.Show("Error generating Bio xml: " + response);
                    //        return;
                    //    }
                    //}
                    //wc.Headers.Add("token", ConfigurationManager.AppSettings["APItoken"].ToString());
                    //NameValueCollection Values = new NameValueCollection
                    //{
                    //    {"roll_no", lblRollNo.Text},
                    //    {"uid", txtAdrToken.Text},
                    //    {"bio", response},
                    //};
                    //byte[] res = wc.UploadValues("https://trustview.in/api/exa/eduquity/uidauth", Values);
                    //str = Encoding.Default.GetString(res);
                    ////MessageBox.Show(str);
                    //modAdharReq retJson = JsonConvert.DeserializeObject<modAdharReq>(str);
                    //if (retJson.failed == false)
                    //{
                    //    //MessageBox.Show("Verification successful");
                    //    this.Dispose();
                    //    this.Close();
                    //    MainFrm.Hdoc.GetElementById("btnAadharOK").InvokeMember("click");
                    //}
                    //else
                    //{
                    //    LogStatus(str);
                    //    MessageBox.Show("Verification failed, try again.");
                    //}
                    #region commented
                    //string data = JsonConvert.SerializeObject(response);
                    //string resp = "{\"roll_no\": \"DM920001\", \"uid\": \"503902048136\",  \"bio\": \"" + response + "\"}";
                    //string jsonResp = "{\"roll_no\": \"DM920001\", \"uid\": \"503902048136\",  \"bio\": \"" + response + "\"}";
                    //string resp1 = JsonConvert.SerializeObject(jsonResp);
                    //string resp = "{'roll_no': '7080809809808', 'uid': '503902048136',  'bio': '"+ response +"'}";
                    //string retRes = wc.UploadString("https://trustview.in/api/exa/eduquity/uidauth", resp);
                    //RestClient client = new RestClient("https://trustview.in/");
                    //adharvalid objReq = new adharvalid();
                    //objReq.roll_no = "DM920001";
                    //objReq.uid = "503902048136";
                    //objReq.bio = response;
                    //var request = new RestRequest("api/exa/eduquity/uidauth", Method.POST);
                    //request.AddHeader("token", "p354v9othzfgkzabm4ncn37l9eel60yr");
                    //request.AddHeader("Content-type", "application/json");
                    //request.RequestFormat = DataFormat.Json;
                    //request.AddObject(objReq);
                    //IRestResponse response1 = client.Execute(request);
                    //MessageBox.Show(response1.Content);
                    //ServicePointManager.Expect100Continue = true;
                    //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                    //| SecurityProtocolType.Tls11
                    //| SecurityProtocolType.Tls12
                    //| SecurityProtocolType.Ssl3
                    //| (SecurityProtocolType)3072
                    //| (SecurityProtocolType)768
                    //| (SecurityProtocolType)12288;
                    //string response = "<PidData><Resp errCode='0' errInfo='Success' fCount='1' fType='0' pCount='0' pType='0' nmPoints='45' qScore='2'/><DeviceInfo dpId='TATVIK.TATVIK' rdsId='TATVIK.WIN.001' rdsVer='1.0.3' dc='55d90b34-0804-dfa6-e1ba-f8ee50e54f47' mi='TMF20' mc='MIIEFDCCAvygAwIBAgIGAX+W1cpWMA0GCSqGSIb3DQEBCwUAMIHVMS8wLQYDVQQDEyZEUyBUQVRWSUsgQklPU1lTVEVNUyBQUklWQVRFIExJTUlURUQgMjEwMC4GA1UEMxMnNDAyIDQwMyBQcmFnYXRpIEhvdXNlIDQ3IDQ4IE5laHJ1IFBsYWNlMRIwEAYDVQQJEwlORVcgREVMSEkxDjAMBgNVBAgTBURFTEhJMRMwEQYDVQQLEwpURUNITk9MT0dZMSowKAYDVQQKEyFUQVRWSUsgQklPU1lTVEVNUyBQUklWQVRFIExJTUlURUQxCzAJBgNVBAYTAklOMB4XDTIyMDMxNzA3NDQyN1oXDTIyMDQxNjA3NDQyN1owgaAxEzARBgNVBAMTClRNRi5UQVRWSUsxKjAoBgNVBAsTIVRBVFZJSyBCSU9TWVNURU1TIFBSSVZBVEUgTElNSVRFRDEqMCgGA1UEChMhVEFUVklLIEJJT1NZU1RFTVMgUFJJVkFURSBMSU1JVEVEMREwDwYDVQQHEwhORVdERUxISTERMA8GA1UECBMITkVXREVMSEkxCzAJBgNVBAYTAklOMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnL5hX9+3OCJfWPzqBvYvm5w0Djgb5DRfarzJ262atGNknjzFs820WGJ+uyisPz5MJU4S6t0oJBoCvhSqTzusx57U0DWhGXTMUl946rIrS5xCs0o7AcFjfSmWeCDMzFagyaoTaSoHowLt/arEZzcjaOk2DC5IlSZXfKBPzsPviaqLlIPKgwGz3VgU1yh5hxC3lBs5ac2Iawzl6LmE+eao3QOuoizMuYcNNiphHdhFkBcG3TiQPEoGYFYri72brDYUi9EaYDvMAERI+I3ifyxKRFTEmSJHKWnWkbWPq3WveJ+x6O4BrQDssCfBuTT4KdQX+fJLQZeL71DpH9fjZht0yQIDAQABox0wGzAMBgNVHRMEBTADAQH/MAsGA1UdDwQEAwIBhjANBgkqhkiG9w0BAQsFAAOCAQEAU0P3GOz5FjQRhdw70WADlZMLHV2G5TaAOJfoyUdF5/Y0GpJFkzWet5wkHrnHyEOVnoXgFFkRlFM/wgnyvPV/bPkAqZRo7pE2btbNl6hgvfiqdiTwGU9Ar2adjRNPo8mTNCWP5zB6gpDhMViV9+piFbL+3Vtu27IWS5E/MkOVGqrVRnzILX/+VZx/to13gM5F1UNs5ElGj0ZfOQJHbzXU8Jwn/EvjgEgkcU/1Rns1hV1yUaSgUIiGM7L7vhc1HQLlZTzngBJfQZmKCrksBOBKY0/BcsbB7aGAWWgRrnU0sESI2NiT9m+oF78SS2tuZRZk9s6TmgjuTYlr3Z9QJ0PLFA=='><additional_info><Param name='srno' value='17030544'/><Param name='sysid' value='PJPMF018JD30D9'/><Param name='ts' value='2022-03-19T19:05:42+05:30'/></additional_info></DeviceInfo><Skey ci='20200916'>rD7p0dwB8vdQM/Y/dW17umGzri2Y31DJt1K6A4CeMv0rqLp7VmQd36ql/fZWMle2/PSvejc9Z5qRcXo84RNqPeovoRs9bcyKZOaUr+hVJQt5A76FytV1mTqjNC9uftwPxrbaezeHSPS/Zo847Yv5RkYdGzAgpXUn5cJfIWDCao8GNJntfUnTtvQVgkMGkmz9yAK14lk/H4Kr5Iw7b0R+/0HDNx8A4qHHB6irihNDyZ+nSK1ccoWtcxKvqG6SHCNVLrMrwf719kw+Oh9Vb2S4QtEXDIcHqA2cXWXyTNDYESaG+0doeb8zHGmqRndvxW1w+YU8CuJLTHLPQPmBzVPXNg==</Skey><Hmac>wYJrkpbNQTg6OAZRRzEUEjiKcc82Rgkdveer7stj2egPqqrlVtWOmMgDLzG9uL0D</Hmac><Data type= 'X'>MjAyMi0wMy0xOVQxOTowNTo0MpCmW0DVRHNWyAD2NmoFb8EBSLG6cw+AOnbLfEBPZ0ITdlT+mkWNXEaVViKkD27rBwXniAL9xL75MvoLIbuSNcTGVoKYT66QxuLggQ7pa6yrHpoHnL13GZ65ECQDgx6Ei0u/Q49GtlhkA6aABnfwGbwHgdSxrZNKwp/zFlwfugdR2duyc47e/DGqB62rAzzz4I1xTcYMTm/KldcDsOrqvxYtHjrgexIfDuIPue1mZdfKJ1qhGqsD0Bi9hVjBY7gV7awP4w+tYYPYbifzH24He+2iersi8jjv7mI4giR1yFu8yEbYL+BDKTUep2rmHOBvF31XvTNTH5Spc4SnLXUVeSVWhOkPE1rIIyCZCNDfiSH66xdfzIMF+QbWl1s7YMYXU25PU44BHzhpeMtmxa2WoN7TrQYS1CvmKjfXn/0U1fNFv8duJnkxkz+ii8jxywtxMWLduB+160ihWCS5RrPQcTeY0UF7Xrqy+2fH0DsK30i3EA1+6zSSADyecCvFz9609ur4XTqfOOHNyYy1RCaUo4UnzBwESL/uRVd3WKZauAqMRb3+v8+zSpWmtZCzjf5XQQCcmvTv4Bkxi3WDLgU4qXXsk8+rTkjI5jIQmRZgBezOn0gqsZ74awo8dq1VY2JfLXoIzVKfsG8trrTfLQsqSzAepIkqnL0WcDyymysXTBnP/KrzK3xoiqnt/ScRVL365nlBhCFlRnbCAJ1hTTpi8hySyKN8zSpwhRBdB2gKajt4a/gPsv9TNL33bC04Rdlo8O+6n4Xbfzjj2oF2rxHfAbC+NxilHZyHr1zyV3u9V21Byo+sxElo2HZwGOXM4lOJOLS6XZ1KsJD2k67Qh2u66s3b2ovI5f+pnVBzcZ1Ypy1qBuOUjutJDYjn1A9uLsaqTW9Cp6ZVneNN9GJvz2PGumz0oquFVUZ2Q4s4WQq3kE+CAZCZqzyPLuqwYV3RRE2c0jOvfYIXBdJEgNELF7i/inDjReq5XlsV44PO/QqgttICoz/9EVLTjvEK/5Vto3JIqDFh7U/eIY4Kfd/4blMPNu0PHv+49RfW0rJfXLmwDROPmf9L1HuyyYdBPkm+cu4lwdQhD8xgmOJdYe2EcYybG6Iy4H85SenIRs/33UVbv34nlhHP8BbRr6hh+EO1kXeIkzK0011updOs6PPRD+ig5N26r1jxDNsU8ABUX3D9iJWeM7tKL66A8+TsR2/QCUyKNY2EsYFNpDb4/XTVXwkMG9gQwSTU9ysXuQ==</Data></PidData>";
                    //response = response.Replace("\r\n", "");
                    //wc.Headers.Add("Host", "trustview.in");
                    //wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    //wc.Headers[HttpRequestHeader.Authorization] = "Bearer p354v9othzfgkzabm4ncn37l9eel60yr";
                    #endregion
                    //return true;
                }
            }
            catch (Exception ex)
            {
                LogStatus(str);
                MessageBox.Show(ex.Message);
                //return false;
            }
            finally
            {
               
            }
        }
        #endregion

        #region btnAmazon_Click
        private void btnAmazon_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            try
            {
                //if (txtAdrToken.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please enter valid Aadhar No or Token");
                //    return;
                //}
                //PidData.Text = String.Empty;
                //using (WebClient wc = new WebClient())
                //{
                //    string pidOptionsXml = "<PidOptions ver='1.0'><Opts env='P' fCount='1' fType='0' format='0' pType='0' pCount='0' pgCount='0' pTimeout='20000' pidVer='2.0'>" +
                //                          "</Opts><Demo></Demo><CustOpts></CustOpts><Bios></Bios></PidOptions>";
                //    string url = "http://127.0.0.1:11101/rd/capture";
                //    string response = wc.UploadString(url, "CAPTURE", pidOptionsXml);
                //    PidData.Text = response;
                //    XmlDocument doc = new XmlDocument();
                //    doc.LoadXml(response);
                //    XmlNode nd = doc.SelectSingleNode("//PidData//Resp//@errCode");
                //    if (nd != null)
                //    {
                //        if (nd.Value != "0")
                //        {
                //            MessageBox.Show("Error generating Bio xml: " + response);
                //            return;
                //        }
                //    }
                //    wc.Headers.Add("token", ConfigurationManager.AppSettings["APItoken"].ToString());
                //    NameValueCollection Values = new NameValueCollection
                //    {
                //        {"roll_no", lblRollNo.Text},
                //        {"uid", txtAdrToken.Text},
                //        {"bio", response},
                //    };
                //    byte[] res = wc.UploadValues(ConfigurationManager.AppSettings["AWSURL"].ToString(), Values);
                //    str = Encoding.Default.GetString(res);
                //    MessageBox.Show(str);
                //    modAdharReq retJson = JsonConvert.DeserializeObject<modAdharReq>(str);
                //    if (retJson.failed == false)
                //    {
                //        this.Dispose();
                //        this.Close();
                //        MainFrm.Hdoc.GetElementById("btnAadharOK").InvokeMember("click");
                //    }
                //    else
                //    {
                //        LogStatus(str);
                //        MessageBox.Show("Verification failed, try again. " + str);
                //    }
                //}
            }
            catch (Exception ex)
            {
                LogStatus(str);
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        #region LogStatus
        public void LogStatus(string xmlData)
        {
            try
            {
                if(ConfigurationManager.AppSettings["Log"].ToString() == "1")
                {
                    //using (WebClient client = new WebClient())
                    //{
                    //    //string param = "appNo=" + lblNRollNo.Text + "&xmlData=" + xmlData;
                    //    //string URL = ConfigurationManager.AppSettings["URL"] + "?" + param;
                    //    //MessageBox.Show(URL);
                    //    ////MessageBox.Show("http://" + ServerIPAddress + ConfigurationManager.AppSettings["UploadClientSettings"] + "?" + param);
                    //    //string retRes = client.UploadString(URL, "ClientData");
                    //    NameValueCollection Values = new NameValueCollection
                    //    {
                    //        {"appNo", lblRollNo.Text},
                    //        {"xmlData", xmlData},
                    //    };
                    //    byte[] res = client.UploadValues(ConfigurationManager.AppSettings["URL"], Values);
                    //}
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
