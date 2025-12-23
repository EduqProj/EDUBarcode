using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace EduBarcode
{
    public partial class FPCaptureVerify : Form
    {
        TMF20FPLibrary fpLibrary = new TMF20FPLibrary();
        CaptureResult captrslt1, captrslt2;
        DeviceInfo deviceInfo;
        byte[] rawBytes = new byte[300 * 400];
        public FPCaptureVerify()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            fingerCapture1();
        }

        #region FPCaptureVerify_Load
        private void FPCaptureVerify_Load(object sender, EventArgs e)
        {
            lblNRollNo.Text = MainFrm.Hdoc.GetElementById("txtRegNo").GetAttribute("value");
        }
        #endregion

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
                    Bitmap bmp = CreateGreyscaleBitmap(rawBytes, 300, 400);
                    String sfilename = Environment.CurrentDirectory + "\\" + lblNRollNo.Text + ".txt";
                    File.WriteAllBytes(sfilename, captrslt1.fmrBytes);
                    using (WebClient oclient = new WebClient())
                    {
                        Byte[] responseArray = oclient.UploadFile(MainFrm.url + "getuploadfile.aspx?ImgType=FPTEXIT", "POST", sfilename);
                        oclient.Dispose();
                        FileInfo fi = new FileInfo(sfilename);
                        fi.Delete();
                    }
                    VerifyFingerPrint(captrslt1.fmrBytes);
                }
                else
                {
                    MessageBox.Show(captrslt1.errorString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //this.Dispose();
                //this.Close();
            }
        }
        #endregion

        #region VerifyFingerPrint
        public void VerifyFingerPrint(byte[] srcFP)
        {
            byte[] destFP = null;
            string destFilePath = ConfigurationSettings.AppSettings["ServerAdd"].ToString() + "/FingerPrints/" + lblNRollNo.Text + ".txt";
            using (WebClient webClt = new WebClient())
            {
                destFP = webClt.DownloadData(destFilePath);
            }
            if (destFP == null)
            {
                MessageBox.Show("Destination Finger print not found.");
                return;
            }
            bool isMatched = fpLibrary.matchIsoTemplates(srcFP, destFP);
            if (isMatched)
            {
                MainFrm.Hdoc.GetElementById("txtVerified").SetAttribute("value", "1");
                MainFrm.Hdoc.GetElementById("btnupdate").InvokeMember("click");
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fingerprint Not successful");
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

        #region btnContinue_Click
        private void btnContinue_Click(object sender, EventArgs e)
        {
            MainFrm.Hdoc.GetElementById("txtVerified").SetAttribute("value", "0");
            MainFrm.Hdoc.GetElementById("hcomment").SetAttribute("value", comment.Text);
            MainFrm.Hdoc.GetElementById("btnupdate").InvokeMember("click");
            this.Dispose();
            this.Close();
        }
        #endregion
    }
}
