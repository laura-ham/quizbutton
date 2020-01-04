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
    public partial class frmButtonPressed : Form
    {
        public frmButtonPressed()
        {
            InitializeComponent();
        }

        public frmButtonPressed(string text) : this()
        {
            lblText.Text = text;
        }

        private void lblText_Resize(object sender, EventArgs e)
        {
            lblText.Font = new Font("Arial", splitContainer1.Panel1.Height * 0.5f, FontStyle.Bold, GraphicsUnit.Pixel);
        }
    }
}
