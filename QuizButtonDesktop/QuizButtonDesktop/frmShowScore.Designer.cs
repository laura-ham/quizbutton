namespace QuizButtonDesktop
{
    partial class frmShowScore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrNextTeam = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrNextTeam
            // 
            this.tmrNextTeam.Tick += new System.EventHandler(this.tmrNextTeam_Tick);
            // 
            // frmShowScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmShowScore";
            this.Text = "frmButtonPressed";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowScore_KeyDown);
            this.Resize += new System.EventHandler(this.frmShowScore_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrNextTeam;
    }
}