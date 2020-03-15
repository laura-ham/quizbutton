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

        public frmButtonPressed(string text, int index, int timeout) : this()
        {
            lblText.Text = text;
            if(index < 0 || index > Screen.AllScreens.Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            WindowState = FormWindowState.Normal;
            Size = new Size(1, 1);
            Show();
            Location = Screen.AllScreens[index].Bounds.Location;
            Size = Screen.AllScreens[index].Bounds.Size;
            BringToFront();
            TopMost = true;
            lblText_Resize(this, null);

            tmrCloseOverlay.Interval = timeout;
            tmrCloseOverlay.Start();
        }

        private void lblText_Resize(object sender, EventArgs e)
        {
            lblText.Size = splitContainer1.Panel2.ClientSize;
            lblText.Font = new Font("Arial", splitContainer1.Panel1.Height * 0.5f, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        private void tmrCloseOverlay_Tick(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
