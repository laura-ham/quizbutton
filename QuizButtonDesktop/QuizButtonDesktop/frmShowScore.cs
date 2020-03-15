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
        }

        public frmShowScore(List<Team> teams, int index, int teamDelay, int lastDelay) : this()
        {
            if(index < 0 || index > Screen.AllScreens.Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.teams = teams.OrderByDescending(x => x.Score).ToList<Team>();

            foreach (Team team in this.teams)
            {
                TeamScorePanel panel = new TeamScorePanel(team.Image, team.Name, team.Score);
                panel.Visible = false;
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

            tmrNextTeam.Interval = teamDelay;
            tmrNextTeam.Start();

            tmrCloseOverlay.Interval = teamDelay * (teams.Count - 1) + lastDelay;
            tmrCloseOverlay.Start();
        }

        private void frmShowScore_Resize(object sender, EventArgs e)
        {
            float partHeight = this.Height / teams.Count;
            float teamHeight = Math.Min(partHeight, this.Width / 4);
            for (int i = 0; i < Controls.Count; i++)
            {
                int y = (int)Math.Round(i * partHeight + (partHeight - teamHeight) / 2);
                Controls[i].Location = new Point(0, y);
                Controls[i].Size = new Size(this.Width, (int)teamHeight);
            }
        }

        private void tmrCloseOverlay_Tick(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void tmrNextTeam_Tick(object sender, EventArgs e)
        {
            int index = this.Controls.Count - 1;
            while (index >= 0)
            {
                if(!Controls[index].Visible)
                {
                    Controls[index].Visible = true;
                    return;
                }
                index--;
            }
            tmrNextTeam.Stop();
        }
    }
}
