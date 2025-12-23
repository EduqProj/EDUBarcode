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
    public partial class VerifyFP : Form
    {
        TMF20FPLibrary fpLibrary = new TMF20FPLibrary();
        CaptureResult captrslt1, captrslt2;
        DeviceInfo deviceInfo;
        byte[] rawBytes = new byte[300 * 400];
        public VerifyFP()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            fingerCapture1();
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
                    //Bitmap bmp = CreateGreyscaleBitmap(rawBytes, 300, 400);
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
                    String sfilename = Environment.CurrentDirectory + "\\ftp_" + MainFrm.AppNo + ".txt";
                    //File.WriteAllBytes(sfilename, captrslt1.fmrBytes);
                    byte[] destFTP = File.ReadAllBytes(sfilename);
                    bool isMatched = fpLibrary.matchIsoTemplates(captrslt1.fmrBytes, destFTP);
                    if (isMatched)
                        MessageBox.Show("Fingerprint match successful");
                    else
                        MessageBox.Show("Fingerprint Not successful");

                    //}
                    //using (WebClient oclient = new WebClient())
                    //{
                    //    Byte[] responseArray = oclient.UploadFile(MainFrm.url + "getuploadfile.aspx?ImgType=FPTJPG", "POST", sfilename);
                    //    oclient.Dispose();
                    //    FileInfo fi = new FileInfo(sfilename);
                    //    fi.Delete();
                    //}
                    //MainFrm.Hdoc.GetElementById("btnsubmit").InvokeMember("click");
                }
                else
                {
                    //pictureBox.ImageLocation = @"image\wrong.bmp";
                    //pictureBox1.ImageLocation = @"image\wrong1.bmp";
                    //statusBox.Text = captrslt1.errorString;
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
            response = fpLibrary.captureFingerprint(captrslt, 10000);
            rawBytes = captrslt.rawImageBytes;
            //btn_save.Enabled = true;
            return response;
        }

       
        #endregion
    }
}
