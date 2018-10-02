using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;

namespace LectureSelector
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public void iniWriteValue(string section, string key, string value,string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        public string iniReadValue(string section, string key, string path)
        {
            StringBuilder temp = new StringBuilder(256);
            int i = GetPrivateProfileString(section, key, "", temp, 256, path);
            return temp.ToString();
        }

        public bool initConfigure()
        {
            if (!Directory.Exists(@".\new"))
                try
                {
                    Directory.CreateDirectory(@".\new");
                }
                catch (IOException e)
                {
                    MessageBox.Show("无法创建new文件夹","错误");
                    return false;
                }
            if(!Directory.Exists(@".\old"))
                try
            {
                Directory.CreateDirectory(@".\old");
            }
            catch (IOException e)
            {
                MessageBox.Show("无法创建old文件夹", "错误");
                return false;
            }
            if (!File.Exists(@".\config.ini"))
                try
                {
                    File.CreateText(@".\config.ini");
                    iniWriteValue("State", "Next", "00", @".\config.ini");
                    iniWriteValue("State", "Vivid", "true", @".\config.ini");
                    iniWriteValue("Mapper", "Random", "true", @".\config.ini");
                }
                catch (IOException e)
                {
                    MessageBox.Show("无法创建配置文件", "错误");
                    return false;
                }
            return true;
        }

        public int high = 0, low = 0;
        public bool moved = false;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (!moved)
            {
                labelHigh.Left = Width / 2 - labelHigh.Width;
                labelLow.Left = Width / 2;
                labelHigh.Top = Height / 2 - labelHigh.Height;
                labelLow.Top = Height / 2 - labelLow.Height;
            }
            buttonClose.Left = Width - buttonClose.Width;
            buttonClose.Top = 0;
            buttonMaxiumum.Left = Width - buttonClose.Width - buttonMaxiumum.Width;
            buttonMaxiumum.Top = 0;
            buttonRun.Left = Width / 2 - buttonRun.Width / 2;
            buttonRun.Top = Height - buttonRun.Height - Height / 20;
            richTextBoxMain.Height = 4 * (Height - buttonClose.Height) / 5;
            richTextBoxMain.Width = 4 * Width / 5;
            richTextBoxMain.Left = Width / 2 - richTextBoxMain.Width / 2;
            richTextBoxMain.Top = Height / 2 - richTextBoxMain.Height / 2;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonMaxiumum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            var rnd = new Random();
            high = rnd.Next(0, 9);
            low = rnd.Next(0, 9);
            labelHigh.Text = high.ToString();
            labelLow.Text = low.ToString();
        }

        public bool state = false;
        public int number = 88;

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (state)
            {
                labelHigh.Text = ((number - number % 10) / 10).ToString();
                labelLow.Text = (number % 10).ToString();
                timerMain.Stop();
                state = false;
                buttonRun.Visible = false;
                timerFade.Start();
            }
            else
            {
                timerMain.Start();
                state = true;
                buttonRun.Text = "结束";
            }
        }


        private void timerFade_Tick(object sender, EventArgs e)
        {
            labelHigh.Visible = false;
            labelLow.Visible = false;

            labelHigh.Font = new Font("微软雅黑", 18);
            labelLow.Font = new Font("微软雅黑", 18);

            labelHigh.Left = 5;
            labelLow.Left = labelHigh.Width + 5;
            labelHigh.Top = 3;
            labelLow.Top = 3;

            labelHigh.Visible = true;
            labelLow.Visible = true;

            moved = true;

            richTextBoxMain.Visible = true;

            timerFade.Stop();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            initConfigure();
            httpDownload(@"github.com/yangrq/LectureSelector/remote.ini", @".\remote.ini");

            var cfgpath = "";

            if (iniReadValue("State", "Valid", @".\remote.ini").ToLower() == "true")
                cfgpath = @".\remote.ini";
            else
                cfgpath = @".\config.ini";

            if (iniReadValue("Mapper", "Random", cfgpath).ToLower() != "false")
            {
                var files = Directory.GetFiles(@".\new");
                number = (new Random()).Next(0, files.Length - 1);
                var path = @".\new\" + files[number].ToString() + ".txt";
                if (File.Exists(path))
                {
                    richTextBoxMain.Text = File.OpenText(path).ReadToEnd();
                    File.Move(path, @".\old\" + files[number].ToString() + ".txt");
                }
            }
            else
            {
                number = int.Parse(iniReadValue("State", "Next", cfgpath));
                var path = @".\new\" + number.ToString() + ".txt";
                if (File.Exists(path))
                {
                    richTextBoxMain.Text = File.OpenText(path).ReadToEnd();
                    File.Move(path, @".\old\" + number.ToString() + ".txt");
                }
            }
        }

        const int CURSOR_HTLEFT = 10;
        const int CURSOR_HTRIGHT = 11;
        const int CURSOR_HTTOP = 12;
        const int CURSOR_HTTOPLEFT = 13;
        const int CURSOR_HTTOPRIGHT = 14;
        const int CURSOR_HTBOTTOM = 15;
        const int CURSOR_HTBOTTOMLEFT = 16;
        const int CURSOR_HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)CURSOR_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)CURSOR_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)CURSOR_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)CURSOR_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)CURSOR_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)CURSOR_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)CURSOR_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)CURSOR_HTBOTTOM;
                    break;
                case 0x0201:                //鼠标左键按下的消息  
                    m.Msg = 0x00A1;         //更改消息为非客户区按下鼠标  
                    m.LParam = IntPtr.Zero; //默认值  
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内  
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public bool httpDownload(string url, string path)
        {
            string tempPath = Path.GetDirectoryName(path) + @"\temp";
            Directory.CreateDirectory(tempPath);
            string tempFile = tempPath + @"\" + Path.GetFileName(path) + ".temp";
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                fs.Close();
                responseStream.Close();
                File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("远程连接失败", "错误");
                return false;
            }
        }
    }
}
