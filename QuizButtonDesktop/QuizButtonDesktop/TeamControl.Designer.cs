namespace QuizButtonDesktop
{
    partial class TeamControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTeamName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.picTeamImage = new System.Windows.Forms.PictureBox();
            this.lblTeamImage = new System.Windows.Forms.Label();
            this.btnLoadTeamImage = new System.Windows.Forms.Button();
            this.lblTeamSound = new System.Windows.Forms.Label();
            this.btnLoadSound = new System.Windows.Forms.Button();
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.lblButton = new System.Windows.Forms.Label();
            this.btnSetButton = new System.Windows.Forms.Button();
            this.lblButtonId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTeamImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Location = new System.Drawing.Point(33, 15);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(35, 13);
            this.lblTeamName.TabIndex = 0;
            this.lblTeamName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(74, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(117, 31);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // picTeamImage
            // 
            this.picTeamImage.Location = new System.Drawing.Point(74, 40);
            this.picTeamImage.Name = "picTeamImage";
            this.picTeamImage.Size = new System.Drawing.Size(117, 97);
            this.picTeamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTeamImage.TabIndex = 2;
            this.picTeamImage.TabStop = false;
            // 
            // lblTeamImage
            // 
            this.lblTeamImage.AutoSize = true;
            this.lblTeamImage.Location = new System.Drawing.Point(33, 40);
            this.lblTeamImage.Name = "lblTeamImage";
            this.lblTeamImage.Size = new System.Drawing.Size(36, 13);
            this.lblTeamImage.TabIndex = 3;
            this.lblTeamImage.Text = "Image";
            // 
            // btnLoadTeamImage
            // 
            this.btnLoadTeamImage.Location = new System.Drawing.Point(4, 56);
            this.btnLoadTeamImage.Name = "btnLoadTeamImage";
            this.btnLoadTeamImage.Size = new System.Drawing.Size(64, 23);
            this.btnLoadTeamImage.TabIndex = 4;
            this.btnLoadTeamImage.Text = "Load";
            this.btnLoadTeamImage.UseVisualStyleBackColor = true;
            this.btnLoadTeamImage.Click += new System.EventHandler(this.btnLoadTeamImage_Click);
            // 
            // lblTeamSound
            // 
            this.lblTeamSound.AutoSize = true;
            this.lblTeamSound.Location = new System.Drawing.Point(30, 148);
            this.lblTeamSound.Name = "lblTeamSound";
            this.lblTeamSound.Size = new System.Drawing.Size(38, 13);
            this.lblTeamSound.TabIndex = 5;
            this.lblTeamSound.Text = "Sound";
            // 
            // btnLoadSound
            // 
            this.btnLoadSound.Location = new System.Drawing.Point(74, 143);
            this.btnLoadSound.Name = "btnLoadSound";
            this.btnLoadSound.Size = new System.Drawing.Size(53, 23);
            this.btnLoadSound.TabIndex = 6;
            this.btnLoadSound.Text = "Load";
            this.btnLoadSound.UseVisualStyleBackColor = true;
            this.btnLoadSound.Click += new System.EventHandler(this.btnLoadSound_Click);
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.Location = new System.Drawing.Point(133, 143);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(58, 23);
            this.btnPlaySound.TabIndex = 7;
            this.btnPlaySound.Text = "Play";
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // lblButton
            // 
            this.lblButton.AutoSize = true;
            this.lblButton.Location = new System.Drawing.Point(30, 177);
            this.lblButton.Name = "lblButton";
            this.lblButton.Size = new System.Drawing.Size(38, 13);
            this.lblButton.TabIndex = 8;
            this.lblButton.Text = "Button";
            // 
            // btnSetButton
            // 
            this.btnSetButton.Location = new System.Drawing.Point(133, 172);
            this.btnSetButton.Name = "btnSetButton";
            this.btnSetButton.Size = new System.Drawing.Size(58, 23);
            this.btnSetButton.TabIndex = 9;
            this.btnSetButton.Text = "Set";
            this.btnSetButton.UseVisualStyleBackColor = true;
            // 
            // lblButtonId
            // 
            this.lblButtonId.AutoSize = true;
            this.lblButtonId.Location = new System.Drawing.Point(74, 177);
            this.lblButtonId.Name = "lblButtonId";
            this.lblButtonId.Size = new System.Drawing.Size(43, 13);
            this.lblButtonId.TabIndex = 10;
            this.lblButtonId.Text = "--none--";
            // 
            // TeamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblButtonId);
            this.Controls.Add(this.btnSetButton);
            this.Controls.Add(this.lblButton);
            this.Controls.Add(this.btnPlaySound);
            this.Controls.Add(this.btnLoadSound);
            this.Controls.Add(this.lblTeamSound);
            this.Controls.Add(this.btnLoadTeamImage);
            this.Controls.Add(this.lblTeamImage);
            this.Controls.Add(this.picTeamImage);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTeamName);
            this.Name = "TeamControl";
            this.Size = new System.Drawing.Size(203, 250);
            ((System.ComponentModel.ISupportInitialize)(this.picTeamImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox picTeamImage;
        private System.Windows.Forms.Label lblTeamImage;
        private System.Windows.Forms.Button btnLoadTeamImage;
        private System.Windows.Forms.Label lblTeamSound;
        private System.Windows.Forms.Button btnLoadSound;
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.Label lblButton;
        private System.Windows.Forms.Button btnSetButton;
        private System.Windows.Forms.Label lblButtonId;
    }
}
