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
    public partial class frmShowScore : Form
    {
        List<Team> teams;

        public frmShowScore()
        {
            InitializeComponent();
            this.Focus();
        }

        public frmShowScore(List<Team> teams, int index, int teamDelay) : this()
        {
            if(index < 0 || index > Screen.AllScreens.Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.teams = teams.OrderByDescending(x => x.Score).ToList<Team>();

            int i = 0;
            foreach (Team team in this.teams)
            {
                TeamScorePanel panel = new TeamScorePanel(team.Image, team.Name, team.Score);
                if (teamDelay > 0 || i < 3)
                {
                    panel.Visible = false;
                }
                i++;
                this.Controls.Add(panel);
            }
            WindowState = FormWindowState.Normal;
            Size = new Size(1, 1);
            Show();
            Location = Screen.AllScreens[index].Bounds.Location;
            Size = Screen.AllScreens[index].Bounds.Size;
            BringToFront();
            TopMost = true;
            
            frmShowScore_Resize(this, null);

            if (teamDelay > 0)
            {
                tmrNextTeam.Interval = teamDelay;
                tmrNextTeam.Start();
            }
        }

        private void frmShowScore_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                int x = 0, y, width;
                float teamHeight;
                if (teams.Count <= 8)
                {
                    //One column
                    float partHeight = this.Height / teams.Count;
                    //Don't let the score get too big when there's only a few teams
                    teamHeight = Math.Min(partHeight, this.Width / 4);
                    //Always space the teams evenly across the screen, even if they have been made smaller
                    y = (int)Math.Round(i * partHeight + (partHeight - teamHeight) / 2);
                    width = this.Width;
                }
                else
                {
                    int rows = (teams.Count + (teams.Count % 2)) / 2;
                    //Two columns
                    //Always have an even number of spots
                    //Because there are at least 9 teams, we don't need to scale anything down
                    teamHeight = this.Height / rows;
                    y = (int)Math.Round((i % rows) * teamHeight);
                    x = i < rows ? 0 : this.Width / 2;
                    width = this.Width / 2;
                }
                Controls[i].Location = new Point(x, y);
                Controls[i].Size = new Size(width, (int)teamHeight);
            }
        }

        private void tmrCloseOverlay_Tick(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void tmrNextTeam_Tick(object sender, EventArgs e)
        {
            if (!nextTeam())
            {
                tmrNextTeam.Stop();
            }
        }

        private bool nextTeam()
        {
            int index = this.Controls.Count - 1;
            while (index >= 0)
            {
                if (!Controls[index].Visible)
                {
                    Controls[index].Visible = true;
                    return true;
                }
                index--;
            }
            return false;
        }

        private void frmShowScore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Escape)
            {
                if (!nextTeam())
                {
                    this.Close();
                    this.Dispose();
                }
            }
        }
    }
}
