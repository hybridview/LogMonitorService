using System.Windows.Forms;

namespace LogMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RawDataOutputTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Settings_PortTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LoggerDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FollowTailEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.PauseResumeListenerButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.LogInterfaceUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.messageTargetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoggerDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageDataItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RawDataOutputTextBox
            // 
            this.RawDataOutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawDataOutputTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RawDataOutputTextBox.Location = new System.Drawing.Point(3, 3);
            this.RawDataOutputTextBox.Multiline = true;
            this.RawDataOutputTextBox.Name = "RawDataOutputTextBox";
            this.RawDataOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RawDataOutputTextBox.Size = new System.Drawing.Size(949, 365);
            this.RawDataOutputTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 83);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Settings_PortTextBox);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 49);
            this.panel1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Port:";
            // 
            // Settings_PortTextBox
            // 
            this.Settings_PortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Settings_PortTextBox.Location = new System.Drawing.Point(57, 3);
            this.Settings_PortTextBox.Name = "Settings_PortTextBox";
            this.Settings_PortTextBox.Size = new System.Drawing.Size(45, 20);
            this.Settings_PortTextBox.TabIndex = 14;
            this.Settings_PortTextBox.Text = "6514";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 117);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(963, 397);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LoggerDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(955, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Table View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LoggerDataGridView
            // 
            this.LoggerDataGridView.AllowUserToAddRows = false;
            this.LoggerDataGridView.AllowUserToDeleteRows = false;
            this.LoggerDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoggerDataGridView.AutoGenerateColumns = false;
            this.LoggerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LoggerDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.LoggerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoggerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messageTargetDataGridViewTextBoxColumn,
            this.messageSourceDataGridViewTextBoxColumn,
            this.messageTextDataGridViewTextBoxColumn});
            this.LoggerDataGridView.DataSource = this.messageDataItemBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoggerDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.LoggerDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.LoggerDataGridView.Location = new System.Drawing.Point(6, 6);
            this.LoggerDataGridView.Name = "LoggerDataGridView";
            this.LoggerDataGridView.RowHeadersWidth = 20;
            this.LoggerDataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.LoggerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LoggerDataGridView.ShowCellErrors = false;
            this.LoggerDataGridView.ShowRowErrors = false;
            this.LoggerDataGridView.Size = new System.Drawing.Size(943, 359);
            this.LoggerDataGridView.TabIndex = 0;
            this.LoggerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoggerDataGridView_CellContentClick);
            this.LoggerDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoggerDataGridView_RowEnter);
            this.LoggerDataGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.LoggerDataGridView_Scroll);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RawDataOutputTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(955, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Text View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FollowTailEnabledCheckBox
            // 
            this.FollowTailEnabledCheckBox.AutoSize = true;
            this.FollowTailEnabledCheckBox.Checked = true;
            this.FollowTailEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FollowTailEnabledCheckBox.Location = new System.Drawing.Point(2, 7);
            this.FollowTailEnabledCheckBox.Name = "FollowTailEnabledCheckBox";
            this.FollowTailEnabledCheckBox.Size = new System.Drawing.Size(75, 17);
            this.FollowTailEnabledCheckBox.TabIndex = 24;
            this.FollowTailEnabledCheckBox.Text = "Follow tail.";
            this.FollowTailEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // PauseResumeListenerButton
            // 
            this.PauseResumeListenerButton.Location = new System.Drawing.Point(83, 3);
            this.PauseResumeListenerButton.Name = "PauseResumeListenerButton";
            this.PauseResumeListenerButton.Size = new System.Drawing.Size(114, 23);
            this.PauseResumeListenerButton.TabIndex = 25;
            this.PauseResumeListenerButton.Text = "Pause";
            this.PauseResumeListenerButton.UseVisualStyleBackColor = true;
            this.PauseResumeListenerButton.Click += new System.EventHandler(this.PauseResumeListenerButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.PauseResumeListenerButton);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.FollowTailEnabledCheckBox);
            this.panel2.Location = new System.Drawing.Point(781, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 58);
            this.panel2.TabIndex = 26;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "IMPORTANT: For this tool to see logs being sent from the local machine, logs MUST" +
    " target 127.0.0.1.";
            // 
            // LogInterfaceUpdateTimer
            // 
            this.LogInterfaceUpdateTimer.Enabled = true;
            this.LogInterfaceUpdateTimer.Interval = 1000;
            this.LogInterfaceUpdateTimer.Tick += new System.EventHandler(this.LogInterfaceUpdateTimer_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(117, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 49);
            this.panel3.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Time stamp regex:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(102, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "E(?<TAG>700)";
            // 
            // messageTargetDataGridViewTextBoxColumn
            // 
            this.messageTargetDataGridViewTextBoxColumn.DataPropertyName = "MessageTarget";
            this.messageTargetDataGridViewTextBoxColumn.DividerWidth = 1;
            this.messageTargetDataGridViewTextBoxColumn.FillWeight = 20F;
            this.messageTargetDataGridViewTextBoxColumn.HeaderText = "Log File";
            this.messageTargetDataGridViewTextBoxColumn.MinimumWidth = 120;
            this.messageTargetDataGridViewTextBoxColumn.Name = "messageTargetDataGridViewTextBoxColumn";
            this.messageTargetDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // messageSourceDataGridViewTextBoxColumn
            // 
            this.messageSourceDataGridViewTextBoxColumn.DataPropertyName = "MessageSource";
            this.messageSourceDataGridViewTextBoxColumn.FillWeight = 1F;
            this.messageSourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.messageSourceDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.messageSourceDataGridViewTextBoxColumn.Name = "messageSourceDataGridViewTextBoxColumn";
            this.messageSourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // messageTextDataGridViewTextBoxColumn
            // 
            this.messageTextDataGridViewTextBoxColumn.DataPropertyName = "MessageText";
            this.messageTextDataGridViewTextBoxColumn.FillWeight = 450F;
            this.messageTextDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageTextDataGridViewTextBoxColumn.MinimumWidth = 200;
            this.messageTextDataGridViewTextBoxColumn.Name = "messageTextDataGridViewTextBoxColumn";
            this.messageTextDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // messageDataItemBindingSource
            // 
            this.messageDataItemBindingSource.DataSource = typeof(LogMonitor.Core.ViewModels.MessageDataItem);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 526);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Udp Listener - A.Moore 20110407";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoggerDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageDataItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RawDataOutputTextBox;
        private GroupBox groupBox2;
        private Panel panel1;
        private Label label4;
        private TextBox Settings_PortTextBox;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView LoggerDataGridView;
        private TabPage tabPage2;
        private BindingSource messageDataItemBindingSource;
        private DataGridViewTextBoxColumn messageTargetDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn messageSourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn messageTextDataGridViewTextBoxColumn;
        private CheckBox FollowTailEnabledCheckBox;
        private Button PauseResumeListenerButton;
        private Panel panel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label label1;
        private Timer LogInterfaceUpdateTimer;
        private Panel panel3;
        private Label label2;
        private TextBox textBox1;

    }
}

