namespace FlowTEX
{
    partial class frmFlowTex
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlowTex));
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.comboSerialFlowTex = new System.Windows.Forms.ComboBox();
            this.btnAbrirFlowTEX = new System.Windows.Forms.Button();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.imgStatus = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboFlowUnit = new System.Windows.Forms.ComboBox();
            this.btnZero = new System.Windows.Forms.Button();
            this.lblUnit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progbarZero = new System.Windows.Forms.ProgressBar();
            this.timerZero = new System.Windows.Forms.Timer(this.components);
            this.btnClrZero = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStandarization = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChangeI2CAddress = new System.Windows.Forms.Button();
            this.edtI2CAddress = new System.Windows.Forms.TextBox();
            this.trackFilterOrder = new System.Windows.Forms.TrackBar();
            this.chkEnableFilter = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnJapan = new System.Windows.Forms.Button();
            this.btnBrazil = new System.Windows.Forms.Button();
            this.icoFlowTEX = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackFilterOrder)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoFlowTEX)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // comboSerialFlowTex
            // 
            this.comboSerialFlowTex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboSerialFlowTex, "comboSerialFlowTex");
            this.comboSerialFlowTex.FormattingEnabled = true;
            this.comboSerialFlowTex.Name = "comboSerialFlowTex";
            // 
            // btnAbrirFlowTEX
            // 
            resources.ApplyResources(this.btnAbrirFlowTEX, "btnAbrirFlowTEX");
            this.btnAbrirFlowTEX.Name = "btnAbrirFlowTEX";
            this.btnAbrirFlowTEX.UseVisualStyleBackColor = true;
            this.btnAbrirFlowTEX.Click += new System.EventHandler(this.btnAbrirFlowTEX_Click);
            // 
            // lblTemperature
            // 
            this.lblTemperature.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.lblTemperature, "lblTemperature");
            this.lblTemperature.Name = "lblTemperature";
            // 
            // imgStatus
            // 
            this.imgStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgStatus.ImageStream")));
            this.imgStatus.TransparentColor = System.Drawing.Color.White;
            this.imgStatus.Images.SetKeyName(0, "OK.png");
            this.imgStatus.Images.SetKeyName(1, "Alert.png");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // lblModel
            // 
            this.lblModel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.lblModel, "lblModel");
            this.lblModel.Name = "lblModel";
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblFlow
            // 
            this.lblFlow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.lblFlow, "lblFlow");
            this.lblFlow.Name = "lblFlow";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // comboFlowUnit
            // 
            this.comboFlowUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboFlowUnit, "comboFlowUnit");
            this.comboFlowUnit.FormattingEnabled = true;
            this.comboFlowUnit.Name = "comboFlowUnit";
            this.comboFlowUnit.SelectedIndexChanged += new System.EventHandler(this.comboFlowUnit_SelectedIndexChanged);
            // 
            // btnZero
            // 
            resources.ApplyResources(this.btnZero, "btnZero");
            this.btnZero.Name = "btnZero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZero_MouseDown);
            this.btnZero.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZero_MouseUp);
            // 
            // lblUnit
            // 
            this.lblUnit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.lblUnit, "lblUnit");
            this.lblUnit.Name = "lblUnit";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblFlow);
            this.panel1.Controls.Add(this.lblUnit);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // progbarZero
            // 
            resources.ApplyResources(this.progbarZero, "progbarZero");
            this.progbarZero.Name = "progbarZero";
            this.progbarZero.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progbarZero.Value = 50;
            // 
            // timerZero
            // 
            this.timerZero.Tick += new System.EventHandler(this.timerZero_Tick);
            // 
            // btnClrZero
            // 
            resources.ApplyResources(this.btnClrZero, "btnClrZero");
            this.btnClrZero.Name = "btnClrZero";
            this.btnClrZero.UseVisualStyleBackColor = true;
            this.btnClrZero.Click += new System.EventHandler(this.btnClrZero_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // lblStandarization
            // 
            resources.ApplyResources(this.lblStandarization, "lblStandarization");
            this.lblStandarization.Name = "lblStandarization";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Name = "label9";
            // 
            // btnChangeI2CAddress
            // 
            resources.ApplyResources(this.btnChangeI2CAddress, "btnChangeI2CAddress");
            this.btnChangeI2CAddress.Name = "btnChangeI2CAddress";
            this.btnChangeI2CAddress.UseVisualStyleBackColor = true;
            this.btnChangeI2CAddress.Click += new System.EventHandler(this.btnChangeI2CAddress_Click);
            // 
            // edtI2CAddress
            // 
            this.edtI2CAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.edtI2CAddress, "edtI2CAddress");
            this.edtI2CAddress.Name = "edtI2CAddress";
            this.edtI2CAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtI2CAddress_KeyDown);
            // 
            // trackFilterOrder
            // 
            this.trackFilterOrder.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.trackFilterOrder, "trackFilterOrder");
            this.trackFilterOrder.Maximum = 50;
            this.trackFilterOrder.Minimum = 1;
            this.trackFilterOrder.Name = "trackFilterOrder";
            this.trackFilterOrder.TickFrequency = 10;
            this.trackFilterOrder.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackFilterOrder.Value = 1;
            this.trackFilterOrder.Scroll += new System.EventHandler(this.trackFilterOrder_Scroll);
            // 
            // chkEnableFilter
            // 
            resources.ApplyResources(this.chkEnableFilter, "chkEnableFilter");
            this.chkEnableFilter.Name = "chkEnableFilter";
            this.chkEnableFilter.UseVisualStyleBackColor = true;
            this.chkEnableFilter.CheckedChanged += new System.EventHandler(this.chkEnableFilter_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.trackFilterOrder);
            this.panel2.Controls.Add(this.chkEnableFilter);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.edtI2CAddress);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.lblSerialNumber, "lblSerialNumber");
            this.lblSerialNumber.Name = "lblSerialNumber";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FlowTEXMonitor.Properties.Resources.airflow1;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FlowTEXMonitor.Properties.Resources.logo;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlowTEXMonitor.Properties.Resources.Volume2;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnEnglish
            // 
            this.btnEnglish.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEnglish.BackgroundImage = global::FlowTEXMonitor.Properties.Resources.usaflag;
            resources.ApplyResources(this.btnEnglish, "btnEnglish");
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.UseVisualStyleBackColor = false;
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnJapan
            // 
            this.btnJapan.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnJapan.BackgroundImage = global::FlowTEXMonitor.Properties.Resources.jpflag;
            resources.ApplyResources(this.btnJapan, "btnJapan");
            this.btnJapan.Name = "btnJapan";
            this.btnJapan.UseVisualStyleBackColor = false;
            this.btnJapan.Click += new System.EventHandler(this.btnJapan_Click);
            // 
            // btnBrazil
            // 
            this.btnBrazil.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBrazil.BackgroundImage = global::FlowTEXMonitor.Properties.Resources.brflag;
            resources.ApplyResources(this.btnBrazil, "btnBrazil");
            this.btnBrazil.Name = "btnBrazil";
            this.btnBrazil.UseVisualStyleBackColor = false;
            this.btnBrazil.Click += new System.EventHandler(this.btnBrazil_Click);
            // 
            // icoFlowTEX
            // 
            resources.ApplyResources(this.icoFlowTEX, "icoFlowTEX");
            this.icoFlowTEX.Name = "icoFlowTEX";
            this.icoFlowTEX.TabStop = false;
            // 
            // frmFlowTex
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.btnJapan);
            this.Controls.Add(this.btnBrazil);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnChangeI2CAddress);
            this.Controls.Add(this.lblStandarization);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClrZero);
            this.Controls.Add(this.progbarZero);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.comboFlowUnit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblSerialNumber);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.icoFlowTEX);
            this.Controls.Add(this.comboSerialFlowTex);
            this.Controls.Add(this.btnAbrirFlowTEX);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFlowTex";
            this.Load += new System.EventHandler(this.frmFlowTex_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackFilterOrder)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoFlowTEX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox icoFlowTEX;
        private System.Windows.Forms.ComboBox comboSerialFlowTex;
        private System.Windows.Forms.Button btnAbrirFlowTEX;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.ImageList imgStatus;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboFlowUnit;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progbarZero;
        private System.Windows.Forms.Timer timerZero;
        private System.Windows.Forms.Button btnClrZero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStandarization;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnChangeI2CAddress;
        private System.Windows.Forms.TextBox edtI2CAddress;
        private System.Windows.Forms.Button btnBrazil;
        private System.Windows.Forms.Button btnJapan;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.TrackBar trackFilterOrder;
        private System.Windows.Forms.CheckBox chkEnableFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

