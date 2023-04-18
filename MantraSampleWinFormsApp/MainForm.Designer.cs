namespace MantraSampleWinFormsApp
{
    partial class MainForm
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
            this.picFinger = new System.Windows.Forms.PictureBox();
            this.btnVersion = new System.Windows.Forms.Button();
            this.btnCheckDevice = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.chkShowPreview = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuality = new System.Windows.Forms.TextBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartCapture = new System.Windows.Forms.Button();
            this.btnStopCapture = new System.Windows.Forms.Button();
            this.chkIsDetectFinger = new System.Windows.Forms.CheckBox();
            this.btnAutoCapture = new System.Windows.Forms.Button();
            this.btnMatchISOTemplate = new System.Windows.Forms.Button();
            this.btnMatchANSITemplate = new System.Windows.Forms.Button();
            this.btnUninit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).BeginInit();
            this.SuspendLayout();
            // 
            // picFinger
            // 
            this.picFinger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.picFinger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFinger.Location = new System.Drawing.Point(263, 57);
            this.picFinger.Name = "picFinger";
            this.picFinger.Size = new System.Drawing.Size(531, 493);
            this.picFinger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFinger.TabIndex = 0;
            this.picFinger.TabStop = false;
            // 
            // btnVersion
            // 
            this.btnVersion.Location = new System.Drawing.Point(12, 57);
            this.btnVersion.Name = "btnVersion";
            this.btnVersion.Size = new System.Drawing.Size(245, 31);
            this.btnVersion.TabIndex = 1;
            this.btnVersion.Text = "Version";
            this.btnVersion.UseVisualStyleBackColor = true;
            this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
            // 
            // btnCheckDevice
            // 
            this.btnCheckDevice.Location = new System.Drawing.Point(12, 94);
            this.btnCheckDevice.Name = "btnCheckDevice";
            this.btnCheckDevice.Size = new System.Drawing.Size(245, 31);
            this.btnCheckDevice.TabIndex = 2;
            this.btnCheckDevice.Text = "Check Device";
            this.btnCheckDevice.UseVisualStyleBackColor = true;
            this.btnCheckDevice.Click += new System.EventHandler(this.btnCheckDevice_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(12, 131);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(245, 31);
            this.btnInit.TabIndex = 3;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // chkShowPreview
            // 
            this.chkShowPreview.Checked = true;
            this.chkShowPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowPreview.Location = new System.Drawing.Point(159, 168);
            this.chkShowPreview.Name = "chkShowPreview";
            this.chkShowPreview.Size = new System.Drawing.Size(98, 24);
            this.chkShowPreview.TabIndex = 4;
            this.chkShowPreview.Text = "Show Preview";
            this.chkShowPreview.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quality (1 to 100):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtQuality
            // 
            this.txtQuality.Location = new System.Drawing.Point(105, 198);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(152, 20);
            this.txtQuality.TabIndex = 6;
            this.txtQuality.Text = "55";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(105, 224);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(152, 20);
            this.txtTimeout.TabIndex = 8;
            this.txtTimeout.Text = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Timeout (ms):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStartCapture
            // 
            this.btnStartCapture.Location = new System.Drawing.Point(12, 250);
            this.btnStartCapture.Name = "btnStartCapture";
            this.btnStartCapture.Size = new System.Drawing.Size(245, 31);
            this.btnStartCapture.TabIndex = 9;
            this.btnStartCapture.Text = "Start Capture";
            this.btnStartCapture.UseVisualStyleBackColor = true;
            this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
            // 
            // btnStopCapture
            // 
            this.btnStopCapture.Location = new System.Drawing.Point(12, 287);
            this.btnStopCapture.Name = "btnStopCapture";
            this.btnStopCapture.Size = new System.Drawing.Size(245, 31);
            this.btnStopCapture.TabIndex = 10;
            this.btnStopCapture.Text = "Stop Capture";
            this.btnStopCapture.UseVisualStyleBackColor = true;
            this.btnStopCapture.Click += new System.EventHandler(this.btnStopCapture_Click);
            // 
            // chkIsDetectFinger
            // 
            this.chkIsDetectFinger.Checked = true;
            this.chkIsDetectFinger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsDetectFinger.Location = new System.Drawing.Point(159, 324);
            this.chkIsDetectFinger.Name = "chkIsDetectFinger";
            this.chkIsDetectFinger.Size = new System.Drawing.Size(98, 24);
            this.chkIsDetectFinger.TabIndex = 11;
            this.chkIsDetectFinger.Text = "Detect Finger";
            this.chkIsDetectFinger.UseVisualStyleBackColor = true;
            // 
            // btnAutoCapture
            // 
            this.btnAutoCapture.Location = new System.Drawing.Point(12, 354);
            this.btnAutoCapture.Name = "btnAutoCapture";
            this.btnAutoCapture.Size = new System.Drawing.Size(245, 31);
            this.btnAutoCapture.TabIndex = 12;
            this.btnAutoCapture.Text = "Auto Capture";
            this.btnAutoCapture.UseVisualStyleBackColor = true;
            this.btnAutoCapture.Click += new System.EventHandler(this.btnAutoCapture_Click);
            // 
            // btnMatchISOTemplate
            // 
            this.btnMatchISOTemplate.Location = new System.Drawing.Point(12, 391);
            this.btnMatchISOTemplate.Name = "btnMatchISOTemplate";
            this.btnMatchISOTemplate.Size = new System.Drawing.Size(245, 31);
            this.btnMatchISOTemplate.TabIndex = 13;
            this.btnMatchISOTemplate.Text = "Match ISO";
            this.btnMatchISOTemplate.UseVisualStyleBackColor = true;
            this.btnMatchISOTemplate.Click += new System.EventHandler(this.btnMatchISOTemplate_Click);
            // 
            // btnMatchANSITemplate
            // 
            this.btnMatchANSITemplate.Location = new System.Drawing.Point(12, 428);
            this.btnMatchANSITemplate.Name = "btnMatchANSITemplate";
            this.btnMatchANSITemplate.Size = new System.Drawing.Size(245, 31);
            this.btnMatchANSITemplate.TabIndex = 14;
            this.btnMatchANSITemplate.Text = "Match ANSI";
            this.btnMatchANSITemplate.UseVisualStyleBackColor = true;
            this.btnMatchANSITemplate.Click += new System.EventHandler(this.btnMatchANSITemplate_Click);
            // 
            // btnUninit
            // 
            this.btnUninit.Location = new System.Drawing.Point(12, 465);
            this.btnUninit.Name = "btnUninit";
            this.btnUninit.Size = new System.Drawing.Size(245, 31);
            this.btnUninit.TabIndex = 15;
            this.btnUninit.Text = "Uninit";
            this.btnUninit.UseVisualStyleBackColor = true;
            this.btnUninit.Click += new System.EventHandler(this.btnUninit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(263, 553);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(531, 30);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
            // 
            // lblSerial
            // 
            this.lblSerial.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSerial.Location = new System.Drawing.Point(0, 0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(806, 41);
            this.lblSerial.TabIndex = 17;
            this.lblSerial.Text = "Serial";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(806, 592);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnUninit);
            this.Controls.Add(this.btnMatchANSITemplate);
            this.Controls.Add(this.btnMatchISOTemplate);
            this.Controls.Add(this.btnAutoCapture);
            this.Controls.Add(this.chkIsDetectFinger);
            this.Controls.Add(this.btnStopCapture);
            this.Controls.Add(this.btnStartCapture);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuality);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkShowPreview);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnCheckDevice);
            this.Controls.Add(this.btnVersion);
            this.Controls.Add(this.picFinger);
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantra Sample App ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblSerial;

        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.Button btnUninit;

        private System.Windows.Forms.Button btnMatchISOTemplate;
        private System.Windows.Forms.Button btnMatchANSITemplate;

        private System.Windows.Forms.Button btnAutoCapture;

        private System.Windows.Forms.CheckBox chkIsDetectFinger;

        private System.Windows.Forms.Button btnStopCapture;

        private System.Windows.Forms.Button btnStartCapture;

        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox txtQuality;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.CheckBox chkShowPreview;

        private System.Windows.Forms.Button btnInit;

        private System.Windows.Forms.Button btnCheckDevice;

        private System.Windows.Forms.Button btnVersion;

        private System.Windows.Forms.PictureBox picFinger;

        #endregion
    }
}