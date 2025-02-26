namespace SimpleLogClient.Demo
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CurrentConfigTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ClearResultsButton = new System.Windows.Forms.Button();
            this.TestResultsListBox = new System.Windows.Forms.ListBox();
            this.SaveResultsButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.NewLoggerPerWriteCheckBox = new System.Windows.Forms.CheckBox();
            this.TestIterationsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TestMessageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOverrideConfigFile = new System.Windows.Forms.CheckBox();
            this.pnlOverrideConfigFileInputsBox = new System.Windows.Forms.Panel();
            this.UseUdpCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LogFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LogFileDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.RunTestButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.LoggerClassComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TestTypeComboBox = new System.Windows.Forms.ComboBox();
            this.txtIterDelay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestIterationsNumericUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlOverrideConfigFileInputsBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.panel5);
            this.groupBox5.Location = new System.Drawing.Point(1, 532);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(269, 113);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Config";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.CurrentConfigTextBox);
            this.panel5.Location = new System.Drawing.Point(6, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(257, 76);
            this.panel5.TabIndex = 17;
            // 
            // CurrentConfigTextBox
            // 
            this.CurrentConfigTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentConfigTextBox.Enabled = false;
            this.CurrentConfigTextBox.Location = new System.Drawing.Point(0, 0);
            this.CurrentConfigTextBox.Multiline = true;
            this.CurrentConfigTextBox.Name = "CurrentConfigTextBox";
            this.CurrentConfigTextBox.Size = new System.Drawing.Size(257, 76);
            this.CurrentConfigTextBox.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.ClearResultsButton);
            this.groupBox4.Controls.Add(this.TestResultsListBox);
            this.groupBox4.Controls.Add(this.SaveResultsButton);
            this.groupBox4.Location = new System.Drawing.Point(276, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(633, 673);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Test Results";
            // 
            // ClearResultsButton
            // 
            this.ClearResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearResultsButton.Location = new System.Drawing.Point(479, 641);
            this.ClearResultsButton.Name = "ClearResultsButton";
            this.ClearResultsButton.Size = new System.Drawing.Size(58, 26);
            this.ClearResultsButton.TabIndex = 7;
            this.ClearResultsButton.Text = "Clear";
            this.ClearResultsButton.UseVisualStyleBackColor = true;
            // 
            // TestResultsListBox
            // 
            this.TestResultsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestResultsListBox.Location = new System.Drawing.Point(16, 32);
            this.TestResultsListBox.Name = "TestResultsListBox";
            this.TestResultsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.TestResultsListBox.Size = new System.Drawing.Size(599, 576);
            this.TestResultsListBox.TabIndex = 3;
            // 
            // SaveResultsButton
            // 
            this.SaveResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveResultsButton.Location = new System.Drawing.Point(543, 641);
            this.SaveResultsButton.Name = "SaveResultsButton";
            this.SaveResultsButton.Size = new System.Drawing.Size(84, 26);
            this.SaveResultsButton.TabIndex = 6;
            this.SaveResultsButton.Text = "Save";
            this.SaveResultsButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Location = new System.Drawing.Point(1, 273);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 253);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test Data";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.NewLoggerPerWriteCheckBox);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtIterDelay);
            this.panel4.Controls.Add(this.TestIterationsNumericUpDown);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(6, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(257, 130);
            this.panel4.TabIndex = 18;
            // 
            // NewLoggerPerWriteCheckBox
            // 
            this.NewLoggerPerWriteCheckBox.Checked = true;
            this.NewLoggerPerWriteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NewLoggerPerWriteCheckBox.Location = new System.Drawing.Point(115, 63);
            this.NewLoggerPerWriteCheckBox.Name = "NewLoggerPerWriteCheckBox";
            this.NewLoggerPerWriteCheckBox.Size = new System.Drawing.Size(133, 24);
            this.NewLoggerPerWriteCheckBox.TabIndex = 17;
            this.NewLoggerPerWriteCheckBox.Text = "New logger per write.";
            // 
            // TestIterationsNumericUpDown
            // 
            this.TestIterationsNumericUpDown.Location = new System.Drawing.Point(71, 11);
            this.TestIterationsNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TestIterationsNumericUpDown.Name = "TestIterationsNumericUpDown";
            this.TestIterationsNumericUpDown.Size = new System.Drawing.Size(98, 20);
            this.TestIterationsNumericUpDown.TabIndex = 1;
            this.TestIterationsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Iterations:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.TestMessageTextBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(6, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 92);
            this.panel2.TabIndex = 18;
            // 
            // TestMessageTextBox
            // 
            this.TestMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestMessageTextBox.Enabled = false;
            this.TestMessageTextBox.Location = new System.Drawing.Point(71, 10);
            this.TestMessageTextBox.Multiline = true;
            this.TestMessageTextBox.Name = "TestMessageTextBox";
            this.TestMessageTextBox.Size = new System.Drawing.Size(175, 79);
            this.TestMessageTextBox.TabIndex = 5;
            this.TestMessageTextBox.Text = "message. message. message. message.";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Message:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOverrideConfigFile);
            this.groupBox2.Controls.Add(this.pnlOverrideConfigFileInputsBox);
            this.groupBox2.Location = new System.Drawing.Point(1, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 129);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "      Override logger config file.";
            // 
            // chkOverrideConfigFile
            // 
            this.chkOverrideConfigFile.Location = new System.Drawing.Point(10, -5);
            this.chkOverrideConfigFile.Name = "chkOverrideConfigFile";
            this.chkOverrideConfigFile.Size = new System.Drawing.Size(16, 24);
            this.chkOverrideConfigFile.TabIndex = 17;
            this.chkOverrideConfigFile.CheckedChanged += new System.EventHandler(this.chkOverrideConfigFile_CheckedChanged);
            // 
            // pnlOverrideConfigFileInputsBox
            // 
            this.pnlOverrideConfigFileInputsBox.Controls.Add(this.UseUdpCheckBox);
            this.pnlOverrideConfigFileInputsBox.Controls.Add(this.label4);
            this.pnlOverrideConfigFileInputsBox.Controls.Add(this.LogFileNameTextBox);
            this.pnlOverrideConfigFileInputsBox.Controls.Add(this.label5);
            this.pnlOverrideConfigFileInputsBox.Controls.Add(this.LogFileDirectoryTextBox);
            this.pnlOverrideConfigFileInputsBox.Location = new System.Drawing.Point(6, 19);
            this.pnlOverrideConfigFileInputsBox.Name = "pnlOverrideConfigFileInputsBox";
            this.pnlOverrideConfigFileInputsBox.Size = new System.Drawing.Size(257, 99);
            this.pnlOverrideConfigFileInputsBox.TabIndex = 17;
            // 
            // UseUdpCheckBox
            // 
            this.UseUdpCheckBox.Location = new System.Drawing.Point(174, 68);
            this.UseUdpCheckBox.Name = "UseUdpCheckBox";
            this.UseUdpCheckBox.Size = new System.Drawing.Size(53, 24);
            this.UseUdpCheckBox.TabIndex = 16;
            this.UseUdpCheckBox.Text = "UDP";
            this.UseUdpCheckBox.CheckedChanged += new System.EventHandler(this.UseUdpCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Directory:";
            // 
            // LogFileNameTextBox
            // 
            this.LogFileNameTextBox.Location = new System.Drawing.Point(71, 42);
            this.LogFileNameTextBox.Name = "LogFileNameTextBox";
            this.LogFileNameTextBox.Size = new System.Drawing.Size(177, 20);
            this.LogFileNameTextBox.TabIndex = 11;
            this.LogFileNameTextBox.Text = "%LOG_CLASS%.Test.log";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "File name:";
            // 
            // LogFileDirectoryTextBox
            // 
            this.LogFileDirectoryTextBox.Location = new System.Drawing.Point(71, 15);
            this.LogFileDirectoryTextBox.Name = "LogFileDirectoryTextBox";
            this.LogFileDirectoryTextBox.Size = new System.Drawing.Size(177, 20);
            this.LogFileDirectoryTextBox.TabIndex = 14;
            this.LogFileDirectoryTextBox.Text = "d:\\Logs\\";
            // 
            // RunTestButton
            // 
            this.RunTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RunTestButton.Location = new System.Drawing.Point(105, 651);
            this.RunTestButton.Name = "RunTestButton";
            this.RunTestButton.Size = new System.Drawing.Size(165, 42);
            this.RunTestButton.TabIndex = 25;
            this.RunTestButton.Text = "Run Test";
            this.RunTestButton.Click += new System.EventHandler(this.RunTestButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Location = new System.Drawing.Point(1, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 106);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logger tests";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.LoggerClassComboBox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.TestTypeComboBox);
            this.panel3.Location = new System.Drawing.Point(6, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 76);
            this.panel3.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Test:";
            // 
            // LoggerClassComboBox
            // 
            this.LoggerClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoggerClassComboBox.FormattingEnabled = true;
            this.LoggerClassComboBox.Items.AddRange(new object[] {
            "SimpleLogClient"});
            this.LoggerClassComboBox.Location = new System.Drawing.Point(71, 10);
            this.LoggerClassComboBox.Name = "LoggerClassComboBox";
            this.LoggerClassComboBox.Size = new System.Drawing.Size(175, 21);
            this.LoggerClassComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Logger:";
            // 
            // TestTypeComboBox
            // 
            this.TestTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TestTypeComboBox.FormattingEnabled = true;
            this.TestTypeComboBox.Items.AddRange(new object[] {
            "InitOnly",
            "InitAndWrite"});
            this.TestTypeComboBox.Location = new System.Drawing.Point(71, 37);
            this.TestTypeComboBox.Name = "TestTypeComboBox";
            this.TestTypeComboBox.Size = new System.Drawing.Size(175, 21);
            this.TestTypeComboBox.TabIndex = 9;
            this.TestTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TestTypeComboBox_SelectedIndexChanged);
            // 
            // txtIterDelay
            // 
            this.txtIterDelay.Location = new System.Drawing.Point(71, 37);
            this.txtIterDelay.Name = "txtIterDelay";
            this.txtIterDelay.Size = new System.Drawing.Size(53, 20);
            this.txtIterDelay.TabIndex = 18;
            this.txtIterDelay.Text = "10";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Iter. delay:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(130, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 700);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.RunTestButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestIterationsNumericUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnlOverrideConfigFileInputsBox.ResumeLayout(false);
            this.pnlOverrideConfigFileInputsBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox CurrentConfigTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ClearResultsButton;
        private System.Windows.Forms.ListBox TestResultsListBox;
        private System.Windows.Forms.Button SaveResultsButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox NewLoggerPerWriteCheckBox;
        private System.Windows.Forms.NumericUpDown TestIterationsNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TestMessageTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlOverrideConfigFileInputsBox;
        private System.Windows.Forms.CheckBox UseUdpCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LogFileNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LogFileDirectoryTextBox;
        private System.Windows.Forms.Button RunTestButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox LoggerClassComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TestTypeComboBox;
        private System.Windows.Forms.CheckBox chkOverrideConfigFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIterDelay;
    }
}

