using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduBarcode
{
    class Module
    {
        public String AppName;
        public String AppNo;

        public String Userpass;
        public String MachineName;
        public int Navigate;
        public int fingerindex;
       
        //'public camphoto ; = System.Configuration.ConfigurationSettings.AppSettings("PhotoPath")
        //'public fptpath ; = System.Configuration.ConfigurationSettings.AppSettings("FPTPath")
        //'public fptjpgpath ; = System.Configuration.ConfigurationSettings.AppSettings("FPTJPGPath")
        //'public urlpath ; = System.Configuration.ConfigurationSettings.AppSettings("URL")



        public String camphoto = "http://" + System.Configuration.ConfigurationSettings.AppSettings["ServerAdd"] + "/eduvfpverify/";
        public String urlpath = "http://" + System.Configuration.ConfigurationSettings.AppSettings["ServerAdd"] + "/eduvfpverify/";

        public string strexepath = Application.StartupPath.Replace("\\Debug", "").Replace("\\bin", "");
        
        public String photopath;
        public String camphotopath;
        public String uploadpath;
        public String uploadpathjpg;
        public String camphotodisp;

        public const short WM_CAP = 1024;
        public const int WM_CAP_DRIVER_CONNECT = WM_CAP + 10;
        public const int WM_CAP_DRIVER_DISCONNECT = WM_CAP + 11;
        public const int WM_CAP_EDIT_COPY = WM_CAP + 30;
        public const int WM_CAP_SET_PREVIEW = WM_CAP + 50;
        public const int WM_CAP_SET_PREVIEWRATE = WM_CAP + 52;
        public const int WM_CAP_SET_SCALE = WM_CAP + 53;
        public const int WS_CHILD = 0x40000000;
        public const int WS_VISIBLE = 0x10000000;
        public const short SWP_NOMOVE = 2;
        public const short SWP_NOSIZE = 1;
        public const short SWP_NOZORDER = 4;
        public const short HWND_BOTTOM = 1;
        public int iDevice = 0;// ' Current device ID
        public int hHwnd;//  ' Handle to preview window


        [DllImport("user32", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);

        [DllImport("user32", EntryPoint = "SetWindowPos")]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);


        [DllImport("user32")]
        public static extern bool DestroyWindow(int hndw);

        [DllImport("avicap32.dll")]
        public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, short nHeight, int hWndParent, int nID);

        [DllImport("avicap32.dll")]
        public static extern bool capGetDriverDescriptionA(short wDriver, string lpszName, int cbName, string lpszVer, int cbVer);

    }
}
