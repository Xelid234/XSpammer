using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XSpammer
{
    public partial class XSpammer : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        public static Process curpro;

        public static bool spamming = false;

        public static Process thispro;

        public XSpammer()
        {
            InitializeComponent();
        }

        private void XSpammer_Load(object sender, EventArgs e)
        {
            randomrenk();
            getcurrentprocesstimer.Start();
            thispro = Process.GetCurrentProcess();
        }

        public async void randomrenk()
        {
            Random rand1 = new Random();
            Color generated = new Color();

            while (true)
            {
                generated = Color.FromArgb(rand1.Next(30, 255), rand1.Next(30, 255), rand1.Next(30, 255));
                label3.ForeColor = generated;
                button1.BackColor = generated;
                button2.BackColor = generated;
                await Task.Delay(100);
            }
        }

        private void getcurrentprocesstimer_Tick(object sender, EventArgs e)
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            curpro = p;
            textBox2.Text = p.ProcessName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            spamming = true;
            spam();
        }

        public async void spam()
        {
            Clipboard.SetText(textBox1.Text);
            do
            {
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                await Task.Delay(Convert.ToInt32(numericUpDown1.Value * 5));
            }
            while(spamming);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            spamming = false;
        }
    }
}
