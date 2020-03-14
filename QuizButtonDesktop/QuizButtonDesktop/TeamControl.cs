using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Media;

namespace QuizButtonDesktop
{
    [XmlRoot("Team")]
    public partial class TeamControl : UserControl
    {
        private Team _team;
        public Team Team
        {
            get { return _team; }
            set { _team = value; DisplayTeam(); }
        }

        public TeamControl()
        {
            InitializeComponent();
            _team = new Team();
            DisplayTeam();
        }

        private void DisplayTeam()
        {
            txtName.Text = _team.Name;
            picTeamImage.Image = _team.Image;
            lblButtonId.Text = _team.ButtonId == "" ? "--none--" : _team.ButtonId;
        }

        private void btnLoadTeamImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG image (.png)|*.png";
            ofd.AddExtension = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                _team.Image = Image.FromFile(ofd.FileName);
                DisplayTeam();
            }
        }

        private void btnLoadSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WAVE file (.wav)|*.wav";
            ofd.AddExtension = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    _team.Sound = new byte[fs.Length];
                    fs.Read(_team.Sound, 0, (int)fs.Length);
                }
            }
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            using (SoundPlayer player = new SoundPlayer(new MemoryStream(_team.Sound)))
            {
                player.Play();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _team.Name = txtName.Text;
        }
    }
}
