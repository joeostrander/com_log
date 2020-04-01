namespace com_log
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.comboBoxComPort1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelReceived = new System.Windows.Forms.Label();
            this.labelBytesReceivedValue = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelFilename = new System.Windows.Forms.LinkLabel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxAppend = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.comboBoxFlowControl = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.LabelParity = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.LabelDataBits = new System.Windows.Forms.Label();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.LabelBitsPerSecond = new System.Windows.Forms.Label();
            this.comboBoxBitsPerSecond = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(288, 70);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 12;
            this.buttonConnect.Text = "&Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxComPort1
            // 
            this.comboBoxComPort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPort1.FormattingEnabled = true;
            this.comboBoxComPort1.Location = new System.Drawing.Point(11, 71);
            this.comboBoxComPort1.Name = "comboBoxComPort1";
            this.comboBoxComPort1.Size = new System.Drawing.Size(271, 21);
            this.comboBoxComPort1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "COM Port:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 230);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(398, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // labelReceived
            // 
            this.labelReceived.AutoSize = true;
            this.labelReceived.Location = new System.Drawing.Point(8, 173);
            this.labelReceived.Name = "labelReceived";
            this.labelReceived.Size = new System.Drawing.Size(80, 13);
            this.labelReceived.TabIndex = 17;
            this.labelReceived.Text = "Bytes received:";
            // 
            // labelBytesReceivedValue
            // 
            this.labelBytesReceivedValue.AutoSize = true;
            this.labelBytesReceivedValue.Location = new System.Drawing.Point(102, 173);
            this.labelBytesReceivedValue.Name = "labelBytesReceivedValue";
            this.labelBytesReceivedValue.Size = new System.Drawing.Size(13, 13);
            this.labelBytesReceivedValue.TabIndex = 18;
            this.labelBytesReceivedValue.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "&Filename:";
            // 
            // linkLabelFilename
            // 
            this.linkLabelFilename.AutoSize = true;
            this.linkLabelFilename.Location = new System.Drawing.Point(102, 121);
            this.linkLabelFilename.Name = "linkLabelFilename";
            this.linkLabelFilename.Size = new System.Drawing.Size(58, 13);
            this.linkLabelFilename.TabIndex = 14;
            this.linkLabelFilename.TabStop = true;
            this.linkLabelFilename.Text = "click to set";
            this.linkLabelFilename.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFilename_LinkClicked);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(219, 161);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(144, 42);
            this.buttonStart.TabIndex = 19;
            this.buttonStart.Text = "&Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkBoxAppend
            // 
            this.checkBoxAppend.AutoSize = true;
            this.checkBoxAppend.Location = new System.Drawing.Point(105, 146);
            this.checkBoxAppend.Name = "checkBoxAppend";
            this.checkBoxAppend.Size = new System.Drawing.Size(40, 17);
            this.checkBoxAppend.TabIndex = 16;
            this.checkBoxAppend.Text = "No";
            this.checkBoxAppend.UseVisualStyleBackColor = true;
            this.checkBoxAppend.CheckedChanged += new System.EventHandler(this.checkBoxAppend_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Append:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(277, 11);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(68, 13);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Flow Control:";
            // 
            // comboBoxFlowControl
            // 
            this.comboBoxFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlowControl.FormattingEnabled = true;
            this.comboBoxFlowControl.Items.AddRange(new object[] {
            "None",
            "Xon / Xoff",
            "Hardware",
            "Both"});
            this.comboBoxFlowControl.Location = new System.Drawing.Point(280, 27);
            this.comboBoxFlowControl.Name = "comboBoxFlowControl";
            this.comboBoxFlowControl.Size = new System.Drawing.Size(83, 21);
            this.comboBoxFlowControl.TabIndex = 9;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(217, 11);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(51, 13);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Stop bits:";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(220, 27);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(54, 21);
            this.comboBoxStopBits.TabIndex = 7;
            // 
            // LabelParity
            // 
            this.LabelParity.AutoSize = true;
            this.LabelParity.Location = new System.Drawing.Point(157, 11);
            this.LabelParity.Name = "LabelParity";
            this.LabelParity.Size = new System.Drawing.Size(36, 13);
            this.LabelParity.TabIndex = 4;
            this.LabelParity.Text = "Parity:";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboBoxParity.Location = new System.Drawing.Point(160, 27);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(54, 21);
            this.comboBoxParity.TabIndex = 5;
            // 
            // LabelDataBits
            // 
            this.LabelDataBits.AutoSize = true;
            this.LabelDataBits.Location = new System.Drawing.Point(97, 11);
            this.LabelDataBits.Name = "LabelDataBits";
            this.LabelDataBits.Size = new System.Drawing.Size(53, 13);
            this.LabelDataBits.TabIndex = 2;
            this.LabelDataBits.Text = "Data Bits:";
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.comboBoxDataBits.Location = new System.Drawing.Point(100, 27);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(54, 21);
            this.comboBoxDataBits.TabIndex = 3;
            // 
            // LabelBitsPerSecond
            // 
            this.LabelBitsPerSecond.AutoSize = true;
            this.LabelBitsPerSecond.Location = new System.Drawing.Point(8, 11);
            this.LabelBitsPerSecond.Name = "LabelBitsPerSecond";
            this.LabelBitsPerSecond.Size = new System.Drawing.Size(86, 13);
            this.LabelBitsPerSecond.TabIndex = 0;
            this.LabelBitsPerSecond.Text = "Bits Per Second:";
            // 
            // comboBoxBitsPerSecond
            // 
            this.comboBoxBitsPerSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBitsPerSecond.FormattingEnabled = true;
            this.comboBoxBitsPerSecond.Items.AddRange(new object[] {
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.comboBoxBitsPerSecond.Location = new System.Drawing.Point(11, 27);
            this.comboBoxBitsPerSecond.Name = "comboBoxBitsPerSecond";
            this.comboBoxBitsPerSecond.Size = new System.Drawing.Size(83, 21);
            this.comboBoxBitsPerSecond.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 252);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.comboBoxFlowControl);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.LabelParity);
            this.Controls.Add(this.comboBoxParity);
            this.Controls.Add(this.LabelDataBits);
            this.Controls.Add(this.comboBoxDataBits);
            this.Controls.Add(this.LabelBitsPerSecond);
            this.Controls.Add(this.comboBoxBitsPerSecond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxAppend);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.linkLabelFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelBytesReceivedValue);
            this.Controls.Add(this.labelReceived);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxComPort1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ComboBox comboBoxComPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label labelReceived;
        private System.Windows.Forms.Label labelBytesReceivedValue;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabelFilename;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.CheckBox checkBoxAppend;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox comboBoxFlowControl;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox comboBoxStopBits;
        internal System.Windows.Forms.Label LabelParity;
        internal System.Windows.Forms.ComboBox comboBoxParity;
        internal System.Windows.Forms.Label LabelDataBits;
        internal System.Windows.Forms.ComboBox comboBoxDataBits;
        internal System.Windows.Forms.Label LabelBitsPerSecond;
        internal System.Windows.Forms.ComboBox comboBoxBitsPerSecond;
    }
}

