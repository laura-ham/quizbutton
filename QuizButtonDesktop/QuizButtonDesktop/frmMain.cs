using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizButtonDesktop
{
    public partial class frmMain : Form
    {
        String loadedConfiguration;
        
        Quiz quiz;

        QuizButton masterButton = new QuizButton();

        int mainScreenIndex;

        public frmMain()
        {
            loadedConfiguration = new Quiz().Serialize();
            InitializeComponent();

            refreshPortList();
            QuizButton.LineReceived += MasterButton_LineReceived;

            quiz = new Quiz();

            UpdateTeamDisplay();
        }

        private void UpdateTeamDisplay()
        {
            UpdateTeamCount();
            flowLayoutPanel1.Controls.Clear();
            int index = 0;
            foreach(Team team in quiz.Teams)
            {
                TeamControl control = new TeamControl() { Team = team };
                flowLayoutPanel1.Controls.Add(control);
                index++;
            }
        }

        private void UpdateTeamCount()
        {
            while (quiz.Teams.Count > numTeams.Value)
            {
                //We need to remove a team
                quiz.Teams.RemoveAt(quiz.Teams.Count - 1);
            }
            while (quiz.Teams.Count < numTeams.Value)
            {
                //We need to add a team

                //Check if there are more teams in the loaded configuration, we can recover them instead of loading new ones
                Quiz loadedQuiz = Quiz.Deserialize(loadedConfiguration);
                while (quiz.Teams.Count < numTeams.Value)
                {
                    if (loadedQuiz.Teams.Count > quiz.Teams.Count)
                    {
                        //We can recover a team
                        foreach(Team team in loadedQuiz.Teams)
                        {
                            if(!quiz.Teams.Contains(team))
                            {
                                quiz.Teams.Add(team);
                                break;
                            }
                        }
                    }
                    else
                    {
                        //We need to make a new team
                        quiz.Teams.Add(new Team() { Name = String.Format("Team {0}", quiz.Teams.Count + 1) });
                    }
                }
            }
        }

        private void MasterButton_LineReceived(string text)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action<string>(MasterButton_LineReceived), text);
                return;
            }
            txtConsole.Text += text + "\r\n";
            if (text.StartsWith("Line claimed: "))
            {
                String id = String.Concat(text.Skip("Line claimed: ".Length).Take(1));
                Team team = quiz.Teams.FirstOrDefault(x => x.ButtonId != null && x.ButtonId.Equals(id));
                if (team == null)
                {
                    showOverlay(id, null, 5000);
                }
                else
                {
                    if (team.Sound != null && team.Sound.Length > 0)
                    {
                        using (SoundPlayer player = new SoundPlayer(new MemoryStream(team.Sound)))
                        {
                            player.Play();
                        }
                    }
                    showOverlay(team.Name, team.Image, 5000);
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
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

        private int OverlayScreenIndex()
        {
            int index = 0;
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (mainScreenIndex != i)
                {
                    index = i;
                }
            }
            return index;
        }

        private void showOverlay(string text, Image image, int milliseconds)
        {
            frmButtonPressed buttonPressed = new frmButtonPressed(text, image, OverlayScreenIndex(), 5000);
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
            UpdateTeamDisplay();
        }

        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = ".quizcfg",
                OverwritePrompt = true
            };
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
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Quiz configuration (.quizcfg)|*.quizcfg",
                AddExtension = true,
                CheckFileExists = true,
                Multiselect = false
            };
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    quiz = Quiz.Deserialize(sr.ReadToEnd());
                    loadedConfiguration = quiz.Serialize();
                    numTeams.Value = quiz.Teams.Count;
                    UpdateTeamDisplay();
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

        private void frmMain_LocationChanged(object sender, EventArgs e)
        {
            if(this.WindowState != FormWindowState.Minimized)
            {
                for(int i=0;i<Screen.AllScreens.Length;i++)
                {
                    if(Screen.AllScreens[i].Bounds.Contains(this.Location + new Size(this.Width/2, this.Height/2)))
                    {
                        mainScreenIndex = i;
                    }
                }
            }
        }

        private void btnTestOverlay_Click(object sender, EventArgs e)
        {
            showOverlay("Test", null, 1000);
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGreen;
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            this.BackColor = Color.LightPink;
        }

        private void btnFocusOnQuiz_Click(object sender, EventArgs e)
        {
            ProcessHelper.FocusPowerpoint();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown)
            {
                ProcessHelper.FocusPowerpoint();
                ProcessHelper.PowerPointNext();
            }
            else if(e.KeyCode == Keys.PageUp)
            {
                ProcessHelper.FocusPowerpoint();
                ProcessHelper.PowerPointPrevious();
            }
        }

        private void btnShowScore_Click(object sender, EventArgs e)
        {
            frmShowScore showScore = new frmShowScore(quiz.Teams, OverlayScreenIndex(), (int)numScoreDelay.Value);
        }
    }
}
