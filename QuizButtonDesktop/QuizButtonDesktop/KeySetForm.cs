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
    public partial class KeySetForm : Form
    {
        private string _key = "";
        public string Key
        {
            get { return _key; }
        }

        public KeySetForm()
        {
            InitializeComponent();

            QuizButton.LineReceived += QuizButton_LineReceived;
        }

        private void QuizButton_LineReceived(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(QuizButton_LineReceived), text);
                return;
            }
            if (text.StartsWith("Line claimed: "))
            {
                _key = String.Concat(text.Skip("Line claimed: ".Length));
                lblButton.Text = _key;
            }
        }

        private void KeySetForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!new Keys[] { Keys.Escape, Keys.Enter, Keys.PageUp, Keys.PageDown }.Contains(e.KeyCode) && e.KeyValue > 32 && e.KeyValue < 127)
            {
                string value = String.Concat((char)e.KeyValue);
                lblButton.Text = value;
                _key = value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
