﻿namespace FYP1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accurayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpMenu = new System.Windows.Forms.GroupBox();
            this.pnlTest = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClassifier = new System.Windows.Forms.ComboBox();
            this.txtIDTest = new System.Windows.Forms.TextBox();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.txtNameTest = new System.Windows.Forms.TextBox();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblStatic2 = new System.Windows.Forms.Label();
            this.pnlTrain = new System.Windows.Forms.Panel();
            this.lblCmd = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbTrainType = new System.Windows.Forms.ComboBox();
            this.txtNameTrain = new System.Windows.Forms.TextBox();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblIDTrain = new System.Windows.Forms.Label();
            this.lblStatic1 = new System.Windows.Forms.Label();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpVisual = new System.Windows.Forms.GroupBox();
            this.hole = new System.Windows.Forms.PictureBox();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.dirPic = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.grpMenu.SuspendLayout();
            this.pnlTest.SuspendLayout();
            this.pnlTrain.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.grpVisual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dirPic)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1354, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iCPToolStripMenuItem,
            this.accurayToolStripMenuItem,
            this.sVMToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.pCAToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.optionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // iCPToolStripMenuItem
            // 
            this.iCPToolStripMenuItem.Name = "iCPToolStripMenuItem";
            this.iCPToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.iCPToolStripMenuItem.Text = "Start Mouse Service";
            this.iCPToolStripMenuItem.Click += new System.EventHandler(this.iCPToolStripMenuItem_Click);
            // 
            // accurayToolStripMenuItem
            // 
            this.accurayToolStripMenuItem.Name = "accurayToolStripMenuItem";
            this.accurayToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.accurayToolStripMenuItem.Text = "KNN Accuray";
            this.accurayToolStripMenuItem.Click += new System.EventHandler(this.accurayToolStripMenuItem_Click);
            // 
            // sVMToolStripMenuItem
            // 
            this.sVMToolStripMenuItem.Name = "sVMToolStripMenuItem";
            this.sVMToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.sVMToolStripMenuItem.Text = "SVM Accuracy";
            this.sVMToolStripMenuItem.Click += new System.EventHandler(this.sVMToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.dataToolStripMenuItem.Text = "SVM Cross Files Accuracy";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // pCAToolStripMenuItem
            // 
            this.pCAToolStripMenuItem.Name = "pCAToolStripMenuItem";
            this.pCAToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.pCAToolStripMenuItem.Text = "PCA";
            this.pCAToolStripMenuItem.Click += new System.EventHandler(this.pCAToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // grpMenu
            // 
            this.grpMenu.BackColor = System.Drawing.Color.Silver;
            this.grpMenu.Controls.Add(this.pnlTest);
            this.grpMenu.Controls.Add(this.pnlTrain);
            this.grpMenu.Controls.Add(this.pnlButton);
            this.grpMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpMenu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMenu.Location = new System.Drawing.Point(13, 28);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(287, 674);
            this.grpMenu.TabIndex = 1;
            this.grpMenu.TabStop = false;
            this.grpMenu.Text = "Menu";
            // 
            // pnlTest
            // 
            this.pnlTest.Controls.Add(this.label1);
            this.pnlTest.Controls.Add(this.cmbClassifier);
            this.pnlTest.Controls.Add(this.txtIDTest);
            this.pnlTest.Controls.Add(this.btnStartTest);
            this.pnlTest.Controls.Add(this.txtNameTest);
            this.pnlTest.Controls.Add(this.lblName2);
            this.pnlTest.Controls.Add(this.lblStatic2);
            this.pnlTest.Enabled = false;
            this.pnlTest.Location = new System.Drawing.Point(13, 371);
            this.pnlTest.Name = "pnlTest";
            this.pnlTest.Size = new System.Drawing.Size(250, 297);
            this.pnlTest.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Classifier";
            // 
            // cmbClassifier
            // 
            this.cmbClassifier.FormattingEnabled = true;
            this.cmbClassifier.Items.AddRange(new object[] {
            "select Classifier",
            "KNN",
            "SVM"});
            this.cmbClassifier.Location = new System.Drawing.Point(82, 93);
            this.cmbClassifier.Name = "cmbClassifier";
            this.cmbClassifier.Size = new System.Drawing.Size(150, 23);
            this.cmbClassifier.TabIndex = 10;
            this.cmbClassifier.Text = "Select Command";
            this.cmbClassifier.SelectedIndexChanged += new System.EventHandler(this.cmbClassifer_SelectedIndexChanged);
            // 
            // txtIDTest
            // 
            this.txtIDTest.Location = new System.Drawing.Point(82, 24);
            this.txtIDTest.Name = "txtIDTest";
            this.txtIDTest.Size = new System.Drawing.Size(150, 21);
            this.txtIDTest.TabIndex = 9;
            // 
            // btnStartTest
            // 
            this.btnStartTest.BackColor = System.Drawing.Color.Transparent;
            this.btnStartTest.BackgroundImage = global::FYP1.Properties.Resources.Media_Controls_Play_icon;
            this.btnStartTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStartTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartTest.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStartTest.FlatAppearance.BorderSize = 0;
            this.btnStartTest.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTest.Location = new System.Drawing.Point(83, 152);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(96, 96);
            this.btnStartTest.TabIndex = 8;
            this.btnStartTest.UseVisualStyleBackColor = false;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // txtNameTest
            // 
            this.txtNameTest.Location = new System.Drawing.Point(82, 60);
            this.txtNameTest.Name = "txtNameTest";
            this.txtNameTest.Size = new System.Drawing.Size(150, 21);
            this.txtNameTest.TabIndex = 7;
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(18, 66);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(42, 15);
            this.lblName2.TabIndex = 6;
            this.lblName2.Text = "Name:";
            // 
            // lblStatic2
            // 
            this.lblStatic2.AutoSize = true;
            this.lblStatic2.Location = new System.Drawing.Point(18, 30);
            this.lblStatic2.Name = "lblStatic2";
            this.lblStatic2.Size = new System.Drawing.Size(24, 15);
            this.lblStatic2.TabIndex = 4;
            this.lblStatic2.Text = "ID:";
            // 
            // pnlTrain
            // 
            this.pnlTrain.Controls.Add(this.lblCmd);
            this.pnlTrain.Controls.Add(this.btnStart);
            this.pnlTrain.Controls.Add(this.cmbTrainType);
            this.pnlTrain.Controls.Add(this.txtNameTrain);
            this.pnlTrain.Controls.Add(this.lblName1);
            this.pnlTrain.Controls.Add(this.lblIDTrain);
            this.pnlTrain.Controls.Add(this.lblStatic1);
            this.pnlTrain.Enabled = false;
            this.pnlTrain.Location = new System.Drawing.Point(13, 74);
            this.pnlTrain.Name = "pnlTrain";
            this.pnlTrain.Size = new System.Drawing.Size(250, 280);
            this.pnlTrain.TabIndex = 1;
            // 
            // lblCmd
            // 
            this.lblCmd.AutoSize = true;
            this.lblCmd.Location = new System.Drawing.Point(18, 88);
            this.lblCmd.Name = "lblCmd";
            this.lblCmd.Size = new System.Drawing.Size(36, 15);
            this.lblCmd.TabIndex = 6;
            this.lblCmd.Text = "Type:";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImage = global::FYP1.Properties.Resources.Media_Controls_Play_icon;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(82, 173);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 96);
            this.btnStart.TabIndex = 5;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            this.btnStart.MouseHover += new System.EventHandler(this.btnStart_MouseHover);
            // 
            // cmbTrainType
            // 
            this.cmbTrainType.FormattingEnabled = true;
            this.cmbTrainType.Items.AddRange(new object[] {
            "Select Command",
            "Up",
            "Down",
            "Left",
            "Right",
            "Neutral"});
            this.cmbTrainType.Location = new System.Drawing.Point(82, 85);
            this.cmbTrainType.Name = "cmbTrainType";
            this.cmbTrainType.Size = new System.Drawing.Size(150, 23);
            this.cmbTrainType.TabIndex = 4;
            this.cmbTrainType.Text = "Select Command";
            this.cmbTrainType.SelectedIndexChanged += new System.EventHandler(this.cmbTrainType_SelectedIndexChanged);
            // 
            // txtNameTrain
            // 
            this.txtNameTrain.Location = new System.Drawing.Point(82, 49);
            this.txtNameTrain.Name = "txtNameTrain";
            this.txtNameTrain.Size = new System.Drawing.Size(150, 21);
            this.txtNameTrain.TabIndex = 3;
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(16, 55);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(42, 15);
            this.lblName1.TabIndex = 2;
            this.lblName1.Text = "Name:";
            // 
            // lblIDTrain
            // 
            this.lblIDTrain.AutoSize = true;
            this.lblIDTrain.Location = new System.Drawing.Point(80, 25);
            this.lblIDTrain.Name = "lblIDTrain";
            this.lblIDTrain.Size = new System.Drawing.Size(39, 15);
            this.lblIDTrain.TabIndex = 1;
            this.lblIDTrain.Text = "label2";
            // 
            // lblStatic1
            // 
            this.lblStatic1.AutoSize = true;
            this.lblStatic1.Location = new System.Drawing.Point(16, 25);
            this.lblStatic1.Name = "lblStatic1";
            this.lblStatic1.Size = new System.Drawing.Size(24, 15);
            this.lblStatic1.TabIndex = 0;
            this.lblStatic1.Text = "ID:";
            // 
            // pnlButton
            // 
            this.pnlButton.BackColor = System.Drawing.Color.White;
            this.pnlButton.Controls.Add(this.btnTest);
            this.pnlButton.Controls.Add(this.btnTrain);
            this.pnlButton.Location = new System.Drawing.Point(13, 20);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(250, 48);
            this.pnlButton.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(136, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(111, 39);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Testing";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTrain.FlatAppearance.BorderSize = 0;
            this.btnTrain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrain.Location = new System.Drawing.Point(3, 3);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(116, 39);
            this.btnTrain.TabIndex = 0;
            this.btnTrain.Text = "Training";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grpVisual
            // 
            this.grpVisual.BackColor = System.Drawing.SystemColors.Menu;
            this.grpVisual.BackgroundImage = global::FYP1.Properties.Resources.backgound1024x768;
            this.grpVisual.Controls.Add(this.hole);
            this.grpVisual.Controls.Add(this.avatar);
            this.grpVisual.Controls.Add(this.progress);
            this.grpVisual.Controls.Add(this.dirPic);
            this.grpVisual.Enabled = false;
            this.grpVisual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpVisual.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVisual.ForeColor = System.Drawing.Color.White;
            this.grpVisual.Location = new System.Drawing.Point(320, 27);
            this.grpVisual.Name = "grpVisual";
            this.grpVisual.Size = new System.Drawing.Size(1024, 675);
            this.grpVisual.TabIndex = 2;
            this.grpVisual.TabStop = false;
            this.grpVisual.Text = "Visual";
            // 
            // hole
            // 
            this.hole.BackColor = System.Drawing.Color.Transparent;
            this.hole.Image = global::FYP1.Properties.Resources.holeL1;
            this.hole.Location = new System.Drawing.Point(818, 217);
            this.hole.Name = "hole";
            this.hole.Size = new System.Drawing.Size(200, 200);
            this.hole.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.hole.TabIndex = 3;
            this.hole.TabStop = false;
            // 
            // avatar
            // 
            this.avatar.BackColor = System.Drawing.Color.Transparent;
            this.avatar.Image = global::FYP1.Properties.Resources.bothL4;
            this.avatar.Location = new System.Drawing.Point(645, 263);
            this.avatar.Name = "avatar";
            this.avatar.Padding = new System.Windows.Forms.Padding(5);
            this.avatar.Size = new System.Drawing.Size(373, 369);
            this.avatar.TabIndex = 2;
            this.avatar.TabStop = false;
            this.avatar.Visible = false;
            // 
            // progress
            // 
            this.progress.ForeColor = System.Drawing.Color.GreenYellow;
            this.progress.Location = new System.Drawing.Point(7, 21);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(242, 28);
            this.progress.TabIndex = 1;
            this.progress.Visible = false;
            // 
            // dirPic
            // 
            this.dirPic.BackColor = System.Drawing.Color.Transparent;
            this.dirPic.Image = global::FYP1.Properties.Resources.Picture2;
            this.dirPic.Location = new System.Drawing.Point(480, 260);
            this.dirPic.Name = "dirPic";
            this.dirPic.Size = new System.Drawing.Size(118, 125);
            this.dirPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dirPic.TabIndex = 0;
            this.dirPic.TabStop = false;
            this.dirPic.Click += new System.EventHandler(this.dirPic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1354, 706);
            this.Controls.Add(this.grpVisual);
            this.Controls.Add(this.grpMenu);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brain Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpMenu.ResumeLayout(false);
            this.pnlTest.ResumeLayout(false);
            this.pnlTest.PerformLayout();
            this.pnlTrain.ResumeLayout(false);
            this.pnlTrain.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.grpVisual.ResumeLayout(false);
            this.grpVisual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dirPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpMenu;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.GroupBox grpVisual;
        private System.Windows.Forms.Panel pnlTest;
        private System.Windows.Forms.Panel pnlTrain;
        private System.Windows.Forms.TextBox txtIDTest;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.TextBox txtNameTest;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblStatic2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbTrainType;
        private System.Windows.Forms.TextBox txtNameTrain;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblIDTrain;
        private System.Windows.Forms.Label lblStatic1;
        private System.Windows.Forms.PictureBox dirPic;
        private System.Windows.Forms.Label lblCmd;
        private System.Windows.Forms.ToolStripMenuItem pCAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iCPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem accurayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVMToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClassifier;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.PictureBox hole;
    }
}

