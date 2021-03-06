﻿using System;
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
            txtButtonId.Text = _team.ButtonId;
            numPoints.Value = _team.Score;
        }

        private void btnLoadTeamImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "PNG image (.png)|*.png",
                AddExtension = true,
                CheckFileExists = true,
                Multiselect = false
            };
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                _team.Image = Image.FromFile(ofd.FileName);
                DisplayTeam();
            }
        }

        private void btnLoadSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "WAVE file (.wav)|*.wav",
                AddExtension = true,
                CheckFileExists = true,
                Multiselect = false
            };
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
            if (_team.Sound != null && _team.Sound.Length > 0)
            {
                using (SoundPlayer player = new SoundPlayer(new MemoryStream(_team.Sound)))
                {
                    player.Play();
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _team.Name = txtName.Text;
        }

        private void numPoints_ValueChanged(object sender, EventArgs e)
        {
            _team.Score = (int)numPoints.Value;
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            numPoints.Value++;
        }

        private void btnChooseButton_Click(object sender, EventArgs e)
        {
            KeySetForm ksf = new KeySetForm();
            if(ksf.ShowDialog() == DialogResult.OK)
            {
                _team.ButtonId = ksf.Key;
                txtButtonId.Text = ksf.Key;
            }
        }

        private void txtButtonId_TextChanged(object sender, EventArgs e)
        {
            _team.ButtonId = txtButtonId.Text;
        }
    }
}
