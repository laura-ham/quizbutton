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
            this.btnChooseButton = new System.Windows.Forms.Button();
            this.numPoints = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.txtButtonId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTeamImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Location = new System.Drawing.Point(3, 0);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(35, 13);
            this.lblTeamName.TabIndex = 0;
            this.lblTeamName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(106, 31);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // picTeamImage
            // 
            this.picTeamImage.Location = new System.Drawing.Point(3, 79);
            this.picTeamImage.Name = "picTeamImage";
            this.picTeamImage.Size = new System.Drawing.Size(106, 97);
            this.picTeamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTeamImage.TabIndex = 2;
            this.picTeamImage.TabStop = false;
            // 
            // lblTeamImage
            // 
            this.lblTeamImage.AutoSize = true;
            this.lblTeamImage.Location = new System.Drawing.Point(3, 58);
            this.lblTeamImage.Name = "lblTeamImage";
            this.lblTeamImage.Size = new System.Drawing.Size(36, 13);
            this.lblTeamImage.TabIndex = 3;
            this.lblTeamImage.Text = "Image";
            // 
            // btnLoadTeamImage
            // 
            this.btnLoadTeamImage.Location = new System.Drawing.Point(45, 53);
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
            this.lblTeamSound.Location = new System.Drawing.Point(3, 179);
            this.lblTeamSound.Name = "lblTeamSound";
            this.lblTeamSound.Size = new System.Drawing.Size(38, 13);
            this.lblTeamSound.TabIndex = 5;
            this.lblTeamSound.Text = "Sound";
            // 
            // btnLoadSound
            // 
            this.btnLoadSound.Location = new System.Drawing.Point(2, 195);
            this.btnLoadSound.Name = "btnLoadSound";
            this.btnLoadSound.Size = new System.Drawing.Size(39, 23);
            this.btnLoadSound.TabIndex = 6;
            this.btnLoadSound.Text = "Load";
            this.btnLoadSound.UseVisualStyleBackColor = true;
            this.btnLoadSound.Click += new System.EventHandler(this.btnLoadSound_Click);
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.Location = new System.Drawing.Point(45, 195);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(52, 23);
            this.btnPlaySound.TabIndex = 7;
            this.btnPlaySound.Text = "Play";
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // lblButton
            // 
            this.lblButton.AutoSize = true;
            this.lblButton.Location = new System.Drawing.Point(3, 221);
            this.lblButton.Name = "lblButton";
            this.lblButton.Size = new System.Drawing.Size(38, 13);
            this.lblButton.TabIndex = 8;
            this.lblButton.Text = "Button";
            // 
            // btnChooseButton
            // 
            this.btnChooseButton.Location = new System.Drawing.Point(45, 232);
            this.btnChooseButton.Name = "btnChooseButton";
            this.btnChooseButton.Size = new System.Drawing.Size(52, 23);
            this.btnChooseButton.TabIndex = 9;
            this.btnChooseButton.Text = "Choose";
            this.btnChooseButton.UseVisualStyleBackColor = true;
            this.btnChooseButton.Click += new System.EventHandler(this.btnChooseButton_Click);
            // 
            // numPoints
            // 
            this.numPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPoints.Location = new System.Drawing.Point(6, 297);
            this.numPoints.Name = "numPoints";
            this.numPoints.Size = new System.Drawing.Size(91, 49);
            this.numPoints.TabIndex = 11;
            this.numPoints.ValueChanged += new System.EventHandler(this.numPoints_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Points:";
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPoint.Location = new System.Drawing.Point(6, 352);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(91, 49);
            this.btnAddPoint.TabIndex = 13;
            this.btnAddPoint.Text = "+1";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // txtButtonId
            // 
            this.txtButtonId.Location = new System.Drawing.Point(3, 234);
            this.txtButtonId.Name = "txtButtonId";
            this.txtButtonId.Size = new System.Drawing.Size(38, 20);
            this.txtButtonId.TabIndex = 14;
            this.txtButtonId.TextChanged += new System.EventHandler(this.txtButtonId_TextChanged);
            // 
            // TeamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtButtonId);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPoints);
            this.Controls.Add(this.btnChooseButton);
            this.Controls.Add(this.lblButton);
            this.Controls.Add(this.btnPlaySound);
            this.Controls.Add(this.btnLoadSound);
            this.Controls.Add(this.lblTeamSound);
            this.Controls.Add(this.btnLoadTeamImage);
            this.Controls.Add(this.lblTeamImage);
            this.Controls.Add(this.picTeamImage);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTeamName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TeamControl";
            this.Size = new System.Drawing.Size(113, 411);
            ((System.ComponentModel.ISupportInitialize)(this.picTeamImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).EndInit();
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
        private System.Windows.Forms.Button btnChooseButton;
        private System.Windows.Forms.Label lblButtonId;
        private System.Windows.Forms.NumericUpDown numPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.TextBox txtButtonId;
    }
}
