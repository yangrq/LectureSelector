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

namespace LectureSelector
{
    public partial class FormMain : System.Windows.Forms.Form
    {
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
            high = rnd.Next(0,9);
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

        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 16;
        const int Guying_HTBOTTOMRIGHT = 17;

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

            while (true)
            {
                number = (new Random(Guid.NewGuid().GetHashCode())).Next(0, 100);
                var path = ".\\new\\" + number.ToString() + ".txt";
                if (File.Exists(path))
                {
                    richTextBoxMain.Text = File.OpenText(path).ReadToEnd();
                    File.Move(path, ".\\old\\" + number.ToString() + ".txt");
                    break;
                }
            }
        }

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
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
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
        
    }
}
