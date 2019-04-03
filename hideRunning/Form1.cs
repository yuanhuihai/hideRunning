using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hideRunning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1.将Form属性ShowInTaskbar改为false，这样程序将不会在任务栏中显示。
            //2.将Form属性WindowState选择为 Minimized，以便起来自动最小化隐藏。
            string startup = Application.ExecutablePath;       //取得程序路径   
            int pp = startup.LastIndexOf("\\");
            startup = startup.Substring(0, pp);

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide(); //或者是this.Visible = false;
                this.notifyIcon1.Visible = true;
            }

        }

        //二 双击窗体上的菜单项，添加相关代码
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }

        }

        private void hideMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();

        }

        //三 转到窗体设计模式，右击notifyIcon1 ，选择属性，双击其中DoubleClick，添加相关代码
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;

                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }

        }
    }
}
