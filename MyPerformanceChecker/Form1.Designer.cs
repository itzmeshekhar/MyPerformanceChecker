namespace MyPerformanceChecker
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxSiteList = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.buttonClientIp = new System.Windows.Forms.Button();
            this.clientIPComboBox = new System.Windows.Forms.ComboBox();
            this.clientIpLabel = new System.Windows.Forms.Label();
            this.dataGridViewClientIP = new System.Windows.Forms.DataGridView();
            this.comboBoxIISLogList = new System.Windows.Forms.ComboBox();
            this.iigLogFilesLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTimeTakenFilter = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelOR = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSelectedPath = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientIP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(939, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 94);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxSiteList
            // 
            this.comboBoxSiteList.FormattingEnabled = true;
            this.comboBoxSiteList.Location = new System.Drawing.Point(97, 21);
            this.comboBoxSiteList.Name = "comboBoxSiteList";
            this.comboBoxSiteList.Size = new System.Drawing.Size(199, 24);
            this.comboBoxSiteList.TabIndex = 1;
            this.comboBoxSiteList.SelectedIndexChanged += new System.EventHandler(this.comboBoxSiteList_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 530);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(2361, 278);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(2361, 321);
            this.dataGridView1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Status Code";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(162, 39);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(205, 24);
            this.statusComboBox.TabIndex = 14;
            // 
            // buttonClientIp
            // 
            this.buttonClientIp.Location = new System.Drawing.Point(15, 825);
            this.buttonClientIp.Name = "buttonClientIp";
            this.buttonClientIp.Size = new System.Drawing.Size(514, 23);
            this.buttonClientIp.TabIndex = 15;
            this.buttonClientIp.Text = "Get Client IP wise details";
            this.buttonClientIp.UseVisualStyleBackColor = true;
            this.buttonClientIp.Click += new System.EventHandler(this.button2_Click);
            // 
            // clientIPComboBox
            // 
            this.clientIPComboBox.FormattingEnabled = true;
            this.clientIPComboBox.Location = new System.Drawing.Point(205, 868);
            this.clientIPComboBox.Name = "clientIPComboBox";
            this.clientIPComboBox.Size = new System.Drawing.Size(321, 24);
            this.clientIPComboBox.TabIndex = 16;
            this.clientIPComboBox.SelectedIndexChanged += new System.EventHandler(this.clientIPComboBox_SelectedIndexChanged);
            // 
            // clientIpLabel
            // 
            this.clientIpLabel.AutoSize = true;
            this.clientIpLabel.Location = new System.Drawing.Point(12, 871);
            this.clientIpLabel.Name = "clientIpLabel";
            this.clientIpLabel.Size = new System.Drawing.Size(173, 16);
            this.clientIpLabel.TabIndex = 17;
            this.clientIpLabel.Text = "Select client IP to get details";
            this.clientIpLabel.Click += new System.EventHandler(this.clientIpLabel_Click);
            // 
            // dataGridViewClientIP
            // 
            this.dataGridViewClientIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientIP.Location = new System.Drawing.Point(12, 920);
            this.dataGridViewClientIP.Name = "dataGridViewClientIP";
            this.dataGridViewClientIP.RowHeadersWidth = 51;
            this.dataGridViewClientIP.RowTemplate.Height = 24;
            this.dataGridViewClientIP.Size = new System.Drawing.Size(2358, 150);
            this.dataGridViewClientIP.TabIndex = 18;
            // 
            // comboBoxIISLogList
            // 
            this.comboBoxIISLogList.FormattingEnabled = true;
            this.comboBoxIISLogList.Location = new System.Drawing.Point(112, 173);
            this.comboBoxIISLogList.Name = "comboBoxIISLogList";
            this.comboBoxIISLogList.Size = new System.Drawing.Size(573, 24);
            this.comboBoxIISLogList.TabIndex = 19;
            this.comboBoxIISLogList.SelectedIndexChanged += new System.EventHandler(this.comboBoxIISLogList_SelectedIndexChanged);
            // 
            // iigLogFilesLabel
            // 
            this.iigLogFilesLabel.AutoSize = true;
            this.iigLogFilesLabel.Location = new System.Drawing.Point(12, 176);
            this.iigLogFilesLabel.Name = "iigLogFilesLabel";
            this.iigLogFilesLabel.Size = new System.Drawing.Size(75, 16);
            this.iigLogFilesLabel.TabIndex = 20;
            this.iigLogFilesLabel.Text = "IIS Log files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Time taken (ms) >";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBoxTimeTakenFilter
            // 
            this.comboBoxTimeTakenFilter.FormattingEnabled = true;
            this.comboBoxTimeTakenFilter.Location = new System.Drawing.Point(162, 75);
            this.comboBoxTimeTakenFilter.Name = "comboBoxTimeTakenFilter";
            this.comboBoxTimeTakenFilter.Size = new System.Drawing.Size(205, 24);
            this.comboBoxTimeTakenFilter.TabIndex = 22;
            // 
            // labelOR
            // 
            this.labelOR.AutoSize = true;
            this.labelOR.Location = new System.Drawing.Point(164, 59);
            this.labelOR.Name = "labelOR";
            this.labelOR.Size = new System.Drawing.Size(27, 16);
            this.labelOR.TabIndex = 24;
            this.labelOR.Text = "OR";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSelectedPath);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.comboBoxSiteList);
            this.groupBox1.Controls.Add(this.labelOR);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 155);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IIS Log Location";
            // 
            // labelSelectedPath
            // 
            this.labelSelectedPath.AutoSize = true;
            this.labelSelectedPath.Location = new System.Drawing.Point(23, 126);
            this.labelSelectedPath.Name = "labelSelectedPath";
            this.labelSelectedPath.Size = new System.Drawing.Size(0, 16);
            this.labelSelectedPath.TabIndex = 26;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(97, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Select Log File Location";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.statusComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxTimeTakenFilter);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(499, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 143);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1237, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 100);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 71);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 71);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2385, 1097);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.iigLogFilesLabel);
            this.Controls.Add(this.comboBoxIISLogList);
            this.Controls.Add(this.dataGridViewClientIP);
            this.Controls.Add(this.clientIpLabel);
            this.Controls.Add(this.clientIPComboBox);
            this.Controls.Add(this.buttonClientIp);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.auto);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientIP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxSiteList;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button buttonClientIp;
        private System.Windows.Forms.ComboBox clientIPComboBox;
        private System.Windows.Forms.Label clientIpLabel;
        private System.Windows.Forms.DataGridView dataGridViewClientIP;
        private System.Windows.Forms.ComboBox comboBoxIISLogList;
        private System.Windows.Forms.Label iigLogFilesLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTimeTakenFilter;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label labelOR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelSelectedPath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

