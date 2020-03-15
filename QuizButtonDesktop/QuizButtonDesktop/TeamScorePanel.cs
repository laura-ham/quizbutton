using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizButtonDesktop
{
    public partial class TeamScorePanel : UserControl
    {
        public TeamScorePanel()
        {
            InitializeComponent();
        }

        public TeamScorePanel(Image image, String team, int score) : this()
        {
            picTeamImage.Image = image;
            lblTeam.Text = team;
            lblScore.Text = score.ToString();
        }

        private void TeamScorePanel_Resize(object sender, EventArgs e)
        {
            int usableHeight = Math.Max(1, Math.Min(this.Height, this.Width / 8));
            
            lblScore.Size = splitContainer2.Panel2.ClientSize;
            lblScore.Font = new Font("Arial", usableHeight, FontStyle.Bold, GraphicsUnit.Pixel);

            Font teamFont = lblScore.Font;
            while(TextRenderer.MeasureText(lblTeam.Text, teamFont).Width > lblTeam.Size.Width)
            {
                usableHeight--;
                teamFont = new Font("Arial", usableHeight, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            lblTeam.Size = splitContainer2.Panel1.ClientSize;
            lblTeam.Font = teamFont;
        }
    }
}
