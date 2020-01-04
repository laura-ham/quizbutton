using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizButtonDesktop
{
    public partial class frmMain : Form
    {
        List<Form> itemsToClose;

        QuizButton masterButton = new QuizButton();

        public frmMain()
        {
            itemsToClose = new List<Form>();
            InitializeComponent();
            refreshPortList();
            masterButton.LineReceived += MasterButton_LineReceived;
        }

        private void MasterButton_LineReceived(string text)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action<string>(MasterButton_LineReceived), text);
                return;
            }
            txtConsole.Text += text;
            if (text.StartsWith("Line claimed: "))
            {
                showOverlay(String.Concat(text.Skip("Line claimed: ".Length)), 5000);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void refreshPortList()
        {
            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();
            this.cmbPort.Items.Clear();
            this.cmbPort.Items.AddRange(portNames);
            string defaultSetting = (string)Properties.Settings.Default["defaultPort"];
            if (this.cmbPort.Items.Count > 0)
            {
                string itemToSelect = portNames.FirstOrDefault(x => x.Equals(defaultSetting, StringComparison.OrdinalIgnoreCase));
                if (itemToSelect != null)
                {
                    this.cmbPort.SelectedItem = itemToSelect;
                }
                else
                {
                    this.cmbPort.SelectedIndex = 0;
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void showOverlay(string text, int milliseconds)
        {
            frmButtonPressed buttonPressed = new frmButtonPressed(text);
            buttonPressed.WindowState = FormWindowState.Maximized;
            buttonPressed.Show();
            buttonPressed.BringToFront();
            buttonPressed.TopMost = true;
            itemsToClose.Add(buttonPressed);
            tmrCloseOverlay.Interval = 5000;
            tmrCloseOverlay.Start();
        }

        private void tmrCloseOverlay_Tick(object sender, EventArgs e)
        {
            tmrCloseOverlay.Stop();
            foreach(Form form in itemsToClose)
            {
                form.Close();
                form.Dispose();
            }
            itemsToClose.Clear();
        }

        private void lblRefresh_Click(object sender, EventArgs e)
        {
            refreshPortList();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            masterButton.connect(cmbPort.SelectedItem.ToString());
        }
    }
}
