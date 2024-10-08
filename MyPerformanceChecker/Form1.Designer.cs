﻿namespace MyPerformanceChecker
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.label5 = new System.Windows.Forms.Label();
            this.labelSelectedPath = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelTotalNoOfRequests = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTop20SlowReqs = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewTop25SlowUrls = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridViewRequestPerHour = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.chartCustomRange = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewCustomRange = new System.Windows.Forms.DataGridView();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.richTextBoxVoiceCommand = new System.Windows.Forms.RichTextBox();
            this.buttonRecordCommand = new System.Windows.Forms.Button();
            this.comboBoxEndTime = new System.Windows.Forms.ComboBox();
            this.labelCustomeRangeEndtime = new System.Windows.Forms.Label();
            this.labellabelCustomeRangeStarttime = new System.Windows.Forms.Label();
            this.comboBoxStartTime = new System.Windows.Forms.ComboBox();
            this.comboBoxIISLogsCustomeRange = new System.Windows.Forms.ComboBox();
            this.labelCustomeTimeRange = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelPageInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientIP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop20SlowReqs)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop25SlowUrls)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestPerHour)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1479, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxSiteList
            // 
            this.comboBoxSiteList.FormattingEnabled = true;
            this.comboBoxSiteList.Location = new System.Drawing.Point(107, 20);
            this.comboBoxSiteList.Name = "comboBoxSiteList";
            this.comboBoxSiteList.Size = new System.Drawing.Size(240, 24);
            this.comboBoxSiteList.TabIndex = 1;
            this.comboBoxSiteList.SelectedIndexChanged += new System.EventHandler(this.comboBoxSiteList_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(20, 498);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(2321, 246);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(2321, 329);
            this.dataGridView1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Status Code";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(145, 14);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(205, 24);
            this.statusComboBox.TabIndex = 14;
            // 
            // buttonClientIp
            // 
            this.buttonClientIp.Location = new System.Drawing.Point(20, 764);
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
            this.clientIPComboBox.Location = new System.Drawing.Point(213, 793);
            this.clientIPComboBox.Name = "clientIPComboBox";
            this.clientIPComboBox.Size = new System.Drawing.Size(321, 24);
            this.clientIPComboBox.TabIndex = 16;
            this.clientIPComboBox.SelectedIndexChanged += new System.EventHandler(this.clientIPComboBox_SelectedIndexChanged);
            // 
            // clientIpLabel
            // 
            this.clientIpLabel.AutoSize = true;
            this.clientIpLabel.Location = new System.Drawing.Point(17, 796);
            this.clientIpLabel.Name = "clientIpLabel";
            this.clientIpLabel.Size = new System.Drawing.Size(173, 16);
            this.clientIpLabel.TabIndex = 17;
            this.clientIpLabel.Text = "Select client IP to get details";
            this.clientIpLabel.Click += new System.EventHandler(this.clientIpLabel_Click);
            // 
            // dataGridViewClientIP
            // 
            this.dataGridViewClientIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientIP.Location = new System.Drawing.Point(20, 826);
            this.dataGridViewClientIP.Name = "dataGridViewClientIP";
            this.dataGridViewClientIP.RowHeadersWidth = 51;
            this.dataGridViewClientIP.RowTemplate.Height = 24;
            this.dataGridViewClientIP.Size = new System.Drawing.Size(2321, 150);
            this.dataGridViewClientIP.TabIndex = 18;
            // 
            // comboBoxIISLogList
            // 
            this.comboBoxIISLogList.FormattingEnabled = true;
            this.comboBoxIISLogList.Location = new System.Drawing.Point(237, 86);
            this.comboBoxIISLogList.Name = "comboBoxIISLogList";
            this.comboBoxIISLogList.Size = new System.Drawing.Size(443, 24);
            this.comboBoxIISLogList.TabIndex = 19;
            this.comboBoxIISLogList.SelectedIndexChanged += new System.EventHandler(this.comboBoxIISLogList_SelectedIndexChanged);
            // 
            // iigLogFilesLabel
            // 
            this.iigLogFilesLabel.AutoSize = true;
            this.iigLogFilesLabel.Location = new System.Drawing.Point(17, 92);
            this.iigLogFilesLabel.Name = "iigLogFilesLabel";
            this.iigLogFilesLabel.Size = new System.Drawing.Size(214, 16);
            this.iigLogFilesLabel.TabIndex = 20;
            this.iigLogFilesLabel.Text = "IIS Log files for Site or Log Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Time taken (ms) >";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBoxTimeTakenFilter
            // 
            this.comboBoxTimeTakenFilter.FormattingEnabled = true;
            this.comboBoxTimeTakenFilter.Location = new System.Drawing.Point(506, 15);
            this.comboBoxTimeTakenFilter.Name = "comboBoxTimeTakenFilter";
            this.comboBoxTimeTakenFilter.Size = new System.Drawing.Size(205, 24);
            this.comboBoxTimeTakenFilter.TabIndex = 22;
            // 
            // labelOR
            // 
            this.labelOR.AutoSize = true;
            this.labelOR.Location = new System.Drawing.Point(376, 26);
            this.labelOR.Name = "labelOR";
            this.labelOR.Size = new System.Drawing.Size(27, 16);
            this.labelOR.TabIndex = 24;
            this.labelOR.Text = "OR";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelSelectedPath);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.comboBoxSiteList);
            this.groupBox1.Controls.Add(this.labelOR);
            this.groupBox1.Location = new System.Drawing.Point(20, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 72);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IIS Log Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Select a Site";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
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
            this.button2.Location = new System.Drawing.Point(432, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 23);
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
            this.groupBox2.Location = new System.Drawing.Point(725, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 66);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(18, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2355, 1011);
            this.tabControl1.TabIndex = 27;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelPageInfo);
            this.tabPage1.Controls.Add(this.buttonNext);
            this.tabPage1.Controls.Add(this.buttonPrevious);
            this.tabPage1.Controls.Add(this.labelTotalNoOfRequests);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.dataGridViewClientIP);
            this.tabPage1.Controls.Add(this.comboBoxIISLogList);
            this.tabPage1.Controls.Add(this.clientIPComboBox);
            this.tabPage1.Controls.Add(this.clientIpLabel);
            this.tabPage1.Controls.Add(this.iigLogFilesLabel);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.buttonClientIp);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2347, 982);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic IIS Log Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelTotalNoOfRequests
            // 
            this.labelTotalNoOfRequests.AutoSize = true;
            this.labelTotalNoOfRequests.Location = new System.Drawing.Point(17, 429);
            this.labelTotalNoOfRequests.Name = "labelTotalNoOfRequests";
            this.labelTotalNoOfRequests.Size = new System.Drawing.Size(0, 16);
            this.labelTotalNoOfRequests.TabIndex = 27;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dataGridViewTop20SlowReqs);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2347, 982);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Top 20 slow requests";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Top 20 slow requests";
            // 
            // dataGridViewTop20SlowReqs
            // 
            this.dataGridViewTop20SlowReqs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTop20SlowReqs.Location = new System.Drawing.Point(38, 81);
            this.dataGridViewTop20SlowReqs.Name = "dataGridViewTop20SlowReqs";
            this.dataGridViewTop20SlowReqs.RowHeadersWidth = 51;
            this.dataGridViewTop20SlowReqs.Size = new System.Drawing.Size(2258, 621);
            this.dataGridViewTop20SlowReqs.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewTop25SlowUrls);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(2347, 982);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Top 25 slow URLs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTop25SlowUrls
            // 
            this.dataGridViewTop25SlowUrls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTop25SlowUrls.Location = new System.Drawing.Point(25, 16);
            this.dataGridViewTop25SlowUrls.Name = "dataGridViewTop25SlowUrls";
            this.dataGridViewTop25SlowUrls.RowHeadersWidth = 51;
            this.dataGridViewTop25SlowUrls.RowTemplate.Height = 24;
            this.dataGridViewTop25SlowUrls.Size = new System.Drawing.Size(2295, 839);
            this.dataGridViewTop25SlowUrls.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridViewRequestPerHour);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(2347, 982);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Request per hour";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRequestPerHour
            // 
            this.dataGridViewRequestPerHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequestPerHour.Location = new System.Drawing.Point(25, 50);
            this.dataGridViewRequestPerHour.Name = "dataGridViewRequestPerHour";
            this.dataGridViewRequestPerHour.RowHeadersWidth = 51;
            this.dataGridViewRequestPerHour.RowTemplate.Height = 24;
            this.dataGridViewRequestPerHour.Size = new System.Drawing.Size(2307, 876);
            this.dataGridViewRequestPerHour.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Request per hour";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.chartCustomRange);
            this.tabPage5.Controls.Add(this.dataGridViewCustomRange);
            this.tabPage5.Controls.Add(this.pictureBoxLoading);
            this.tabPage5.Controls.Add(this.richTextBoxVoiceCommand);
            this.tabPage5.Controls.Add(this.buttonRecordCommand);
            this.tabPage5.Controls.Add(this.comboBoxEndTime);
            this.tabPage5.Controls.Add(this.labelCustomeRangeEndtime);
            this.tabPage5.Controls.Add(this.labellabelCustomeRangeStarttime);
            this.tabPage5.Controls.Add(this.comboBoxStartTime);
            this.tabPage5.Controls.Add(this.comboBoxIISLogsCustomeRange);
            this.tabPage5.Controls.Add(this.labelCustomeTimeRange);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(2347, 982);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Custom Time Range";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // chartCustomRange
            // 
            chartArea6.Name = "ChartArea1";
            this.chartCustomRange.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartCustomRange.Legends.Add(legend6);
            this.chartCustomRange.Location = new System.Drawing.Point(32, 677);
            this.chartCustomRange.Name = "chartCustomRange";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartCustomRange.Series.Add(series6);
            this.chartCustomRange.Size = new System.Drawing.Size(2276, 300);
            this.chartCustomRange.TabIndex = 10;
            this.chartCustomRange.Text = "chart2";
            // 
            // dataGridViewCustomRange
            // 
            this.dataGridViewCustomRange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomRange.Location = new System.Drawing.Point(32, 348);
            this.dataGridViewCustomRange.Name = "dataGridViewCustomRange";
            this.dataGridViewCustomRange.RowHeadersWidth = 51;
            this.dataGridViewCustomRange.RowTemplate.Height = 24;
            this.dataGridViewCustomRange.Size = new System.Drawing.Size(2276, 312);
            this.dataGridViewCustomRange.TabIndex = 9;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoading.BackgroundImage")));
            this.pictureBoxLoading.Location = new System.Drawing.Point(1433, 9);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(475, 282);
            this.pictureBoxLoading.TabIndex = 8;
            this.pictureBoxLoading.TabStop = false;
            this.pictureBoxLoading.Visible = false;
            // 
            // richTextBoxVoiceCommand
            // 
            this.richTextBoxVoiceCommand.Location = new System.Drawing.Point(428, 103);
            this.richTextBoxVoiceCommand.Name = "richTextBoxVoiceCommand";
            this.richTextBoxVoiceCommand.Size = new System.Drawing.Size(999, 98);
            this.richTextBoxVoiceCommand.TabIndex = 7;
            this.richTextBoxVoiceCommand.Text = "";
            this.richTextBoxVoiceCommand.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // buttonRecordCommand
            // 
            this.buttonRecordCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRecordCommand.Location = new System.Drawing.Point(753, 36);
            this.buttonRecordCommand.Name = "buttonRecordCommand";
            this.buttonRecordCommand.Size = new System.Drawing.Size(264, 61);
            this.buttonRecordCommand.TabIndex = 6;
            this.buttonRecordCommand.Text = "Start";
            this.buttonRecordCommand.UseVisualStyleBackColor = true;
            this.buttonRecordCommand.Click += new System.EventHandler(this.buttonRecordCommand_Click);
            // 
            // comboBoxEndTime
            // 
            this.comboBoxEndTime.FormattingEnabled = true;
            this.comboBoxEndTime.Location = new System.Drawing.Point(1048, 267);
            this.comboBoxEndTime.Name = "comboBoxEndTime";
            this.comboBoxEndTime.Size = new System.Drawing.Size(187, 24);
            this.comboBoxEndTime.TabIndex = 5;
            this.comboBoxEndTime.Visible = false;
            // 
            // labelCustomeRangeEndtime
            // 
            this.labelCustomeRangeEndtime.AutoSize = true;
            this.labelCustomeRangeEndtime.Location = new System.Drawing.Point(962, 267);
            this.labelCustomeRangeEndtime.Name = "labelCustomeRangeEndtime";
            this.labelCustomeRangeEndtime.Size = new System.Drawing.Size(65, 16);
            this.labelCustomeRangeEndtime.TabIndex = 4;
            this.labelCustomeRangeEndtime.Text = "End Time";
            this.labelCustomeRangeEndtime.Visible = false;
            // 
            // labellabelCustomeRangeStarttime
            // 
            this.labellabelCustomeRangeStarttime.AutoSize = true;
            this.labellabelCustomeRangeStarttime.Location = new System.Drawing.Point(627, 267);
            this.labellabelCustomeRangeStarttime.Name = "labellabelCustomeRangeStarttime";
            this.labellabelCustomeRangeStarttime.Size = new System.Drawing.Size(68, 16);
            this.labellabelCustomeRangeStarttime.TabIndex = 3;
            this.labellabelCustomeRangeStarttime.Text = "Start Time";
            this.labellabelCustomeRangeStarttime.Visible = false;
            // 
            // comboBoxStartTime
            // 
            this.comboBoxStartTime.FormattingEnabled = true;
            this.comboBoxStartTime.Location = new System.Drawing.Point(709, 267);
            this.comboBoxStartTime.Name = "comboBoxStartTime";
            this.comboBoxStartTime.Size = new System.Drawing.Size(187, 24);
            this.comboBoxStartTime.TabIndex = 2;
            this.comboBoxStartTime.Visible = false;
            // 
            // comboBoxIISLogsCustomeRange
            // 
            this.comboBoxIISLogsCustomeRange.FormattingEnabled = true;
            this.comboBoxIISLogsCustomeRange.Location = new System.Drawing.Point(709, 219);
            this.comboBoxIISLogsCustomeRange.Name = "comboBoxIISLogsCustomeRange";
            this.comboBoxIISLogsCustomeRange.Size = new System.Drawing.Size(526, 24);
            this.comboBoxIISLogsCustomeRange.TabIndex = 1;
            this.comboBoxIISLogsCustomeRange.Visible = false;
            // 
            // labelCustomeTimeRange
            // 
            this.labelCustomeTimeRange.AutoSize = true;
            this.labelCustomeTimeRange.Location = new System.Drawing.Point(627, 227);
            this.labelCustomeTimeRange.Name = "labelCustomeTimeRange";
            this.labelCustomeTimeRange.Size = new System.Drawing.Size(55, 16);
            this.labelCustomeTimeRange.TabIndex = 0;
            this.labelCustomeTimeRange.Text = "IIS Logs";
            this.labelCustomeTimeRange.Visible = false;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(20, 451);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 28;
            this.buttonPrevious.Text = "<<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(332, 451);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 29;
            this.buttonNext.Text = ">>";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelPageInfo
            // 
            this.labelPageInfo.AutoSize = true;
            this.labelPageInfo.Location = new System.Drawing.Point(101, 454);
            this.labelPageInfo.Name = "labelPageInfo";
            this.labelPageInfo.Size = new System.Drawing.Size(0, 16);
            this.labelPageInfo.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2385, 1026);
            this.Controls.Add(this.tabControl1);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop20SlowReqs)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop25SlowUrls)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestPerHour)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridView dataGridViewTop20SlowReqs;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTop25SlowUrls;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridViewRequestPerHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalNoOfRequests;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ComboBox comboBoxIISLogsCustomeRange;
        private System.Windows.Forms.Label labelCustomeTimeRange;
        private System.Windows.Forms.ComboBox comboBoxEndTime;
        private System.Windows.Forms.Label labelCustomeRangeEndtime;
        private System.Windows.Forms.Label labellabelCustomeRangeStarttime;
        private System.Windows.Forms.ComboBox comboBoxStartTime;
        private System.Windows.Forms.Button buttonRecordCommand;
        private System.Windows.Forms.RichTextBox richTextBoxVoiceCommand;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.DataGridView dataGridViewCustomRange;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCustomRange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelPageInfo;
    }
}

