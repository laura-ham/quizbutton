using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizButtonDesktop
{
    public partial class frmMain : Form
    {
        List<Form> itemsToClose;
        Quiz quiz;

        QuizButton masterButton = new QuizButton();

        public frmMain()
        {
            itemsToClose = new List<Form>();
            InitializeComponent();
            refreshPortList();
            masterButton.LineReceived += MasterButton_LineReceived;

            quiz = new Quiz();
            quiz.Teams.Add(new Team());
            quiz.Teams.Add(new Team());
            DisplayQuiz();
        }

        private void DisplayQuiz()
        {
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.ColumnCount = quiz.Teams.Count;
            int index = 0;
            foreach(Team team in quiz.Teams)
            {
                TeamControl control = new TeamControl();
                control.Team = team;
                tableLayoutPanel.Controls.Add(control, index, 0);
                index++;
            }
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

        private void numTeams_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = ".quizcfg";
            sfd.OverwritePrompt = true;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sr = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.ASCII))
                {
                    sr.Write(quiz.Serialize());
                }
            }
        }

        private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Quiz configuration (.quizcfg)|*.quizcfg";
            ofd.AddExtension = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    quiz = Quiz.Deserialize(sr.ReadToEnd());
                    DisplayQuiz();
                }
            }
        }

        private void newQuizToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openQuizToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveQuizToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
