using Luxand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class TakePhoto : Form
    {
        Boolean bReturn;
        string strName = new String(' ', 100);
        string strVer = new String(' ', 100);
        Module mod = new Module();

        public static float FaceDetectionThreshold = 3;
        public static float FARValue = 100;
        string srcAppPhotoPath = ConfigurationSettings.AppSettings["TestPathURL"].ToString().Trim() + "//Photos//" + MainFrm.Hdoc.GetElementById("applno").GetAttribute("value") + ".jpg";
        string downloadedAppPhotoPath = Environment.CurrentDirectory + "//" + MainFrm.Hdoc.GetElementById("applno").GetAttribute("value") + "_AppPhoto.jpg";
        public TakePhoto()
        {
            InitializeComponent();
            //this.TopMost = true;
            FSDK.SetFaceDetectionParameters(false, true, 384);
            FSDK.SetFaceDetectionThreshold((int)FaceDetectionThreshold);
        }

        #region Form Action Methods
        private void TakePhoto_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
        }


        private void TakePhoto_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePreviewWindow();
        }

        private void TakePhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region btnTakePhoto_Click
        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            saveimg();
        }
        #endregion

        #region Start Camera
        private void StartCam()
        {
            try
            {
                bReturn = Module.capGetDriverDescriptionA(0, strName, 100, strVer, 100);
                if (bReturn)
                {
                    mod.iDevice = 0;
                    mod.hHwnd = Module.capCreateCaptureWindowA(string.Empty, Module.WS_VISIBLE, this.Location.X + 20, this.Location.Y + 30, 360, 280, picCapture.Handle.ToInt32(), 0);
                    if (Module.SendMessage(mod.hHwnd, Module.WM_CAP_DRIVER_CONNECT, mod.iDevice, 0) == 1)
                    {
                        Module.SendMessage(mod.hHwnd, Module.WM_CAP_SET_SCALE, 1, 0);
                        Module.SendMessage(mod.hHwnd, Module.WM_CAP_SET_PREVIEWRATE, 66, 0);
                        Module.SendMessage(mod.hHwnd, Module.WM_CAP_SET_PREVIEW, 1, 0);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Save Image
        private bool saveimg()
        {
            if (bReturn)
            {
                IDataObject data;
                Image bmap;
                Module.SendMessage(mod.hHwnd, Module.WM_CAP_EDIT_COPY, 0, 0);
                data = Clipboard.GetDataObject();
                if (data.GetDataPresent(typeof(Bitmap)))
                {
                    bmap = (Image)data.GetData(typeof(Bitmap));
                    picCapture.Image = bmap;
                    ClosePreviewWindow();
                    picCapture.Visible = false;
                    String sfilename = Environment.CurrentDirectory + "\\" + MainFrm.Hdoc.GetElementById("applno").GetAttribute("value") + ".jpg";
                    string status = "-2.0";
                    bmap.Save(sfilename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (File.Exists(downloadedAppPhotoPath))
                    {
                        status = VerifyFace(sfilename, downloadedAppPhotoPath);
                        //if(retSim == -1.0)
                        //    status = "3";
                        //else if (retSim >= 0.6)
                        //    status = "1";
                        //else if (retSim < 0.6)
                        //    status = "2";
                    }
                    try
                    {
                        if (!lblMsg.Visible)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Update();
                        }
                        using (WebClient oclient = new WebClient())
                        {
                            Byte[] responseArray = oclient.UploadFile(MainFrm.url + "getuploadfile.aspx?ImgType=PHOTO", "POST", sfilename);
                        }
                        FileInfo fi = new FileInfo(sfilename);
                        fi.Delete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Photo was not Uploaded, please upload it later" + ex.ToString());
                    }
                    finally
                    {
                        if(picAppPhoto.Image != null)
                        {
                            picAppPhoto.Image.Dispose();
                            picAppPhoto.Image = null; // Set to null after disposing
                        }
                        if (File.Exists(downloadedAppPhotoPath))
                            File.Delete(downloadedAppPhotoPath);
                        MainFrm.Hdoc.GetElementById("txtFVStatus").SetAttribute("value", status);
                        mod.Navigate = 1;
                        OnChange();
                        this.Dispose();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Webcam not installed");
                this.Dispose();
                this.Close();
            }
            return true;
        }
        #endregion

        #region VerifyFace
        public string VerifyFace(string sfilename, string downloadedAppPhotoPath)
        {
            if (FSDK.FSDKE_OK != FSDK.ActivateLibrary("VUzKxVCKWJysFe9OAsmSl1kLIbt1cFbGIOuZEw1fsDflUlbrC8RR98RAsfH1Ys3gn0BipRWwVPb2vxQd82z4QUQVpfpvTx52T9B7/suH+KQ6M01vkn3Q1WMQz/jKxwvFcUlllvoFzNtd1mbDWCaMMERBAXS5iXKSqpzMlSWuCP0="))
                MessageBox.Show("Please run the License Key Wizard");
            if (FSDK.InitializeLibrary() != FSDK.FSDKE_OK)
                MessageBox.Show("Error initializing FaceSDK!");
            TFaceRecord fr1 = new TFaceRecord();
            TFaceRecord fr2 = new TFaceRecord();
            float Similarity = 0.0f;
            try
            {
                string Res1 = GetTemplate(sfilename, ref fr1);
                string Res2 = GetTemplate(downloadedAppPhotoPath, ref fr2);
                FSDK.MatchFaces(ref fr1.Template, ref fr2.Template, ref Similarity);
                //if (Similarity < 0.8)
                //    MessageBox.Show("Face Not matching.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Similarity = -1.0f;
            }
            finally
            {
            }
            return Similarity.ToString("#.####");
        }
        #endregion

        #region GetTemplate
        public string GetTemplate(string filePath, ref TFaceRecord fr)
        {
            string retStr = string.Empty;
            fr.ImageFileName = filePath;
            fr.FacePosition = new FSDK.TFacePosition();
            fr.FacialFeatures = new FSDK.TPoint[FSDK.FSDK_FACIAL_FEATURE_COUNT];
            fr.Template = new byte[FSDK.TemplateSize];
            fr.image = new FSDK.CImage(filePath);
            fr.FacePosition = fr.image.DetectFace();
            fr.faceImage = fr.image.CopyRect((int)(fr.FacePosition.xc - Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.yc - Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.xc + Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.yc + Math.Round(fr.FacePosition.w * 0.5)));
            if (0 == fr.FacePosition.w || !File.Exists(filePath))
            {
                retStr += "No faces found/File not found, Try to lower the Minimal Face Quality parameter. ";
            }
            try
            {
                fr.FacialFeatures = fr.image.DetectEyesInRegion(ref fr.FacePosition);
            }
            catch (Exception ex)
            {
                retStr += ex.Message + ": Error detecting eyes. ";
            }
            try
            {
                fr.Template = fr.image.GetFaceTemplateInRegion(ref fr.FacePosition); // get template with higher precision
            }
            catch (Exception ex2)
            {
                retStr += ex2.Message + ": Error retrieving face template.";
            }
            return retStr;
        }
        #endregion

        #region Close the Camera Preview
        private void ClosePreviewWindow()
        {
            try
            {
                if (bReturn)
                {
                    Module.SendMessage(mod.hHwnd, Module.WM_CAP_DRIVER_DISCONNECT, mod.iDevice, 0);
                    Module.DestroyWindow(mod.hHwnd);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region OnChange
        public void OnChange()
        {
            //MainFrm.Hdoc.GetElementById("phtid").SetAttribute("value", "Y");
            MainFrm.Hdoc.GetElementById("btnsubmit").InvokeMember("click");
        }
        #endregion

        #region TakePhoto_Load
        private void TakePhoto_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            StartCam();
            using (WebClient wb = new WebClient()) 
            {
                if (!File.Exists(downloadedAppPhotoPath))
                {
                    try
                    {
                        wb.DownloadFile(srcAppPhotoPath, MainFrm.Hdoc.GetElementById("applno").GetAttribute("value") + "_AppPhoto.jpg");
                        picAppPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                        picAppPhoto.Image = Image.FromFile(downloadedAppPhotoPath);
                    }
                    catch (Exception)
                    {

                    }
                }
                //byte[] imgBytearr = wb.DownloadData(downloadedAppPhotoPath);
                //using (MemoryStream ms = new MemoryStream(imgBytearr))
                //{
                //    // Create an Image object from the MemoryStream
                //    Image image = Image.FromStream(ms);
                //    //Bitmap resizedImage = new Bitmap(image, new Size(400, 399));
                //    picAppPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                //    picAppPhoto.Image = image; // Assign the Image to the PictureBox
                //}
            }
        }
        #endregion
    }

    #region TFaceRecord
    public struct TFaceRecord
    {
        public byte[] Template; //Face Template;
        public FSDK.TFacePosition FacePosition;
        public FSDK.TPoint[] FacialFeatures; //Facial Features;

        public string ImageFileName;

        public FSDK.CImage image;
        public FSDK.CImage faceImage;
    }
    #endregion
}
