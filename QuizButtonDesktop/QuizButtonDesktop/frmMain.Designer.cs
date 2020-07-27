namespace QuizButtonDesktop
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.numScoreDelay = new System.Windows.Forms.NumericUpDown();
            this.btnShowScore = new System.Windows.Forms.Button();
            this.btnFocusOnQuiz = new System.Windows.Forms.Button();
            this.btnTestOverlay = new System.Windows.Forms.Button();
            this.lblNumTeams = new System.Windows.Forms.Label();
            this.numTeams = new System.Windows.Forms.NumericUpDown();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQuizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveQuizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScoreDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeams)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "QuizButton";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Quiz Button";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(996, 600);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.numScoreDelay);
            this.splitContainer2.Panel1.Controls.Add(this.btnShowScore);
            this.splitContainer2.Panel1.Controls.Add(this.btnFocusOnQuiz);
            this.splitContainer2.Panel1.Controls.Add(this.btnTestOverlay);
            this.splitContainer2.Panel1.Controls.Add(this.lblNumTeams);
            this.splitContainer2.Panel1.Controls.Add(this.numTeams);
            this.splitContainer2.Panel1.Controls.Add(this.lblRefresh);
            this.splitContainer2.Panel1.Controls.Add(this.cmbPort);
            this.splitContainer2.Panel1.Controls.Add(this.btnConnect);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtConsole);
            this.splitContainer2.Size = new System.Drawing.Size(996, 172);
            this.splitContainer2.SplitterDistance = 398;
            this.splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Delay";
            // 
            // numScoreDelay
            // 
            this.numScoreDelay.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numScoreDelay.Location = new System.Drawing.Point(297, 127);
            this.numScoreDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numScoreDelay.Name = "numScoreDelay";
            this.numScoreDelay.Size = new System.Drawing.Size(88, 20);
            this.numScoreDelay.TabIndex = 8;
            // 
            // btnShowScore
            // 
            this.btnShowScore.Location = new System.Drawing.Point(13, 124);
            this.btnShowScore.Name = "btnShowScore";
            this.btnShowScore.Size = new System.Drawing.Size(219, 23);
            this.btnShowScore.TabIndex = 7;
            this.btnShowScore.Text = "Show score";
            this.btnShowScore.UseVisualStyleBackColor = true;
            this.btnShowScore.Click += new System.EventHandler(this.btnShowScore_Click);
            // 
            // btnFocusOnQuiz
            // 
            this.btnFocusOnQuiz.Location = new System.Drawing.Point(12, 94);
            this.btnFocusOnQuiz.Name = "btnFocusOnQuiz";
            this.btnFocusOnQuiz.Size = new System.Drawing.Size(220, 23);
            this.btnFocusOnQuiz.TabIndex = 6;
            this.btnFocusOnQuiz.Text = "Focus on quiz";
            this.btnFocusOnQuiz.UseVisualStyleBackColor = true;
            this.btnFocusOnQuiz.Click += new System.EventHandler(this.btnFocusOnQuiz_Click);
            // 
            // btnTestOverlay
            // 
            this.btnTestOverlay.Location = new System.Drawing.Point(12, 65);
            this.btnTestOverlay.Name = "btnTestOverlay";
            this.btnTestOverlay.Size = new System.Drawing.Size(220, 23);
            this.btnTestOverlay.TabIndex = 5;
            this.btnTestOverlay.Text = "Test overlay";
            this.btnTestOverlay.UseVisualStyleBackColor = true;
            this.btnTestOverlay.Click += new System.EventHandler(this.btnTestOverlay_Click);
            // 
            // lblNumTeams
            // 
            this.lblNumTeams.AutoSize = true;
            this.lblNumTeams.Location = new System.Drawing.Point(64, 41);
            this.lblNumTeams.Name = "lblNumTeams";
            this.lblNumTeams.Size = new System.Drawing.Size(42, 13);
            this.lblNumTeams.TabIndex = 4;
            this.lblNumTeams.Text = "Teams:";
            // 
            // numTeams
            // 
            this.numTeams.Location = new System.Drawing.Point(112, 39);
            this.numTeams.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTeams.Name = "numTeams";
            this.numTeams.Size = new System.Drawing.Size(120, 20);
            this.numTeams.TabIndex = 3;
            this.numTeams.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTeams.ValueChanged += new System.EventHandler(this.numTeams_ValueChanged);
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRefresh.Location = new System.Drawing.Point(193, 15);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(44, 13);
            this.lblRefresh.TabIndex = 2;
            this.lblRefresh.Text = "Refresh";
            this.lblRefresh.Click += new System.EventHandler(this.lblRefresh_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(12, 12);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(94, 21);
            this.cmbPort.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(112, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(594, 172);
            this.txtConsole.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(996, 424);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQuizToolStripMenuItem,
            this.openQuizToolStripMenuItem,
            this.saveQuizToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadConfigurationToolStripMenuItem,
            this.saveConfigurationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newQuizToolStripMenuItem
            // 
            this.newQuizToolStripMenuItem.Name = "newQuizToolStripMenuItem";
            this.newQuizToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newQuizToolStripMenuItem.Text = "New quiz";
            this.newQuizToolStripMenuItem.Click += new System.EventHandler(this.newQuizToolStripMenuItem_Click);
            // 
            // openQuizToolStripMenuItem
            // 
            this.openQuizToolStripMenuItem.Name = "openQuizToolStripMenuItem";
            this.openQuizToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openQuizToolStripMenuItem.Text = "Open quiz";
            this.openQuizToolStripMenuItem.Click += new System.EventHandler(this.openQuizToolStripMenuItem_Click);
            // 
            // saveQuizToolStripMenuItem
            // 
            this.saveQuizToolStripMenuItem.Name = "saveQuizToolStripMenuItem";
            this.saveQuizToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.saveQuizToolStripMenuItem.Text = "Save quiz";
            this.saveQuizToolStripMenuItem.Click += new System.EventHandler(this.saveQuizToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.loadConfigurationToolStripMenuItem.Text = "Load configuration";
            this.loadConfigurationToolStripMenuItem.Click += new System.EventHandler(this.loadConfigurationToolStripMenuItem_Click);
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Save configuration";
            this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 624);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Quiz control";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.LocationChanged += new System.EventHandler(this.frmMain_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numScoreDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeams)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label lblRefresh;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label lblNumTeams;
        private System.Windows.Forms.NumericUpDown numTeams;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newQuizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openQuizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveQuizToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.Button btnTestOverlay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFocusOnQuiz;
        private System.Windows.Forms.Button btnShowScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numScoreDelay;
    }
}

