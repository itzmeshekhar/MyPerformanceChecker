using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyPerformanceChecker
{
    public partial class Form1 : Form
    {
        DataTable dataTable = new DataTable();
        List<KeyValuePair<string, string>> siteLogLocation = new List<KeyValuePair<string, string>>();

        public Form1()
        {
            InitializeComponent();
            ListIISSites();
            // Set the selected index to 0 to select the first item
            if (comboBoxSiteList.Items.Count > 0)
            {
                comboBoxSiteList.SelectedIndex = 0; // Selects the first option in the ComboBox
            }
            //comboBoxDuration.Items.Add(1);
            //comboBoxDuration.Items.Add(2);
            //comboBoxDuration.Items.Add(3);
            //comboBoxDuration.Items.Add(4);
            //comboBoxDuration.Items.Add(5);
            //comboBoxDuration.SelectedIndex = 0;
            chart1.Visible = false;
            //chart2.Visible = false;
            //chart3.Visible = false;
            //chart4.Visible = false;
            //chart5.Visible = false;

            statusComboBox.Items.Add("All");
            statusComboBox.Items.Add(200);
            statusComboBox.Items.Add(301);
            statusComboBox.Items.Add(400);
            statusComboBox.Items.Add(401);
            statusComboBox.Items.Add(404);
            statusComboBox.Items.Add(500);
            statusComboBox.SelectedIndex = 0;


            comboBoxTimeTakenFilter.Items.Add("All");
            comboBoxTimeTakenFilter.Items.Add(1000);
            comboBoxTimeTakenFilter.Items.Add(2000);
            comboBoxTimeTakenFilter.Items.Add(3000);
            comboBoxTimeTakenFilter.Items.Add(5000);
            comboBoxTimeTakenFilter.Items.Add(7000);
            comboBoxTimeTakenFilter.Items.Add(10000);
            comboBoxTimeTakenFilter.SelectedIndex = 0;

            comboBoxSiteList.Items.Insert(0, "Select Site");

            clientIPComboBox.Visible = false;
            clientIpLabel.Visible = false;

            dataGridViewClientIP.Visible = false;
            buttonClientIp.Visible = false;
            dataGridView1.Visible = false;
            comboBoxIISLogList.Visible = false;
            iigLogFilesLabel.Visible = false;

            labelOR.Visible = true;

            // comboBoxDuration.Visible = false;

        }
        public void ListIISSites()
        {
            using (ServerManager serverManager = new ServerManager())
            {
                // Clear any existing items in the ListBox (if present)
                comboBoxSiteList.Items.Clear();


                // Loop through each site in IIS
                foreach (Microsoft.Web.Administration.Site site in serverManager.Sites)
                {
                    // Add the site name and ID to the ListBox
                    comboBoxSiteList.Items.Add(site.Name);
                    //ConfigurationSection logFileSection = site.GetWebConfiguration().GetSection("system.applicationHost/log");

                    // Retrieve the log file directory
                    // string logFileDirectory = logFileSection["directory"].ToString();
                    // siteLogLocation.Add(new KeyValuePair<string, string>(site.Name, logFileDirectory));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //chart2.Visible = false;
            //chart3.Visible = false;
            //chart4.Visible = false;
            //chart5.Visible = false;
            // dataGridView1.Rows.Clear();


            string siteName = comboBoxSiteList.SelectedItem.ToString();
            var selectedValue = comboBoxIISLogList.SelectedItem;
            if (string.Equals(siteName.ToLower(), "select site") && selectedValue == null)
            {
                MessageBox.Show("Please select a site or log path");
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Visible = true;
                chart1.Visible = false;
                int? siteId = GetSiteId(siteName);

                if (siteId.HasValue || selectedValue != null)
                {
                    labelSelectedPath.Text = siteId != null ? string.Empty : labelSelectedPath.Text;
                    AnalyseIssLogs(siteId);
                }
                else
                {
                    MessageBox.Show($"Site '{siteName}' not found.");
                }

                buttonClientIp.Visible = true;
                clientIPComboBox.Visible = false;
                clientIpLabel.Visible = false;
                dataGridViewClientIP.Visible = false;
                comboBoxIISLogList.Visible = true;
                iigLogFilesLabel.Visible = true;
            }
        }

        private int? GetSiteId(string siteName)
        {
            // Create a new instance of the ServerManager class
            using (ServerManager serverManager = new ServerManager())
            {
                // Loop through each site in IIS
                foreach (Microsoft.Web.Administration.Site site in serverManager.Sites)
                {
                    // Check if the site name matches the specified site name
                    if (site.Name.Equals(siteName, StringComparison.OrdinalIgnoreCase))
                    {
                        // Return the Site ID
                        return (int)site.Id;
                    }
                }
            }

            // Return null if the site is not found
            return null;
        }

        public void AnalyseIssLogs(int? siteId)
        {
            DataTable dataTable = new DataTable();
            string logContent = string.Empty;
            string firstFile = string.Empty;
            //int duration = (int)comboBoxDuration.SelectedItem;
            try
            {
                if (comboBoxIISLogList.SelectedItem != null)
                {
                    firstFile = comboBoxIISLogList.SelectedItem != null ? comboBoxIISLogList.SelectedItem.ToString() : "";
                }
                else
                {
                    string[] files = GetIisFiles(siteId);
                    if (files.Length > 0)
                    {
                        comboBoxIISLogList.Items.Clear();
                        comboBoxIISLogList.Items.AddRange(files);
                        comboBoxIISLogList.SelectedIndex = 0;
                    }
                    firstFile = files[0];
                }

                if (firstFile.Length > 0)
                {
                    logContent = System.IO.File.ReadAllText(firstFile);
                }
                else
                {
                    MessageBox.Show("No log files found.", "Information");
                }
                byte[] byteArray = Encoding.UTF8.GetBytes(logContent);
                ReadLog(byteArray);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied. Please ensure you have the correct permissions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ReadLog(byte[] byteArray)
        {
            dataTable = new DataTable();
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                // Create a StreamReader from the MemoryStream
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    string line;
                    bool columnsCreated = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip comment lines (starting with #)
                        if (line.StartsWith("#"))
                        {
                            // Extract column names from the header line (if available)
                            if (line.StartsWith("#Fields:"))
                            {
                                string[] fields = line.Substring(8).Split(' '); // Remove "#Fields: " prefix and split by space
                                foreach (string field in fields)
                                {
                                    if (!dataTable.Columns.Contains(field) && !string.IsNullOrEmpty(field))
                                    {
                                        dataTable.Columns.Add(field);
                                    }
                                }
                                columnsCreated = true;
                            }
                            continue;
                        }

                        // Ensure columns are created before adding rows
                        if (!columnsCreated)
                        {
                            throw new InvalidOperationException("Log file does not contain a valid #Fields header line.");
                        }

                        // Split the line into fields
                        string[] values = line.Split(' ');

                        // Add a new row to the DataTable
                        DataRow row = dataTable.NewRow();
                        for (int i = 0; i < values.Length; i++)
                        {
                            row[i] = values[i];
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }

            InitializeChart(dataTable);
        }
        public void InitializeChart(DataTable dataTable)
        {
            Chart chart = chart1;
            List<int> timeTakenValues = new List<int>();

            chart.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainChartArea");
            chart.ChartAreas.Add(chartArea);

            // Create a new Series and add it to the Chart control
            Series series = new Series("Time taken for the site: ")
            {
                ChartType = SeriesChartType.Line, // Set the chart type (Line, Bar, Pie, etc.)
                BorderWidth = 2
            };
            chart.Series.Clear();
            chart.Series.Add(series);
            string selectStatusCode = statusComboBox.SelectedItem.ToString();
            string selectTimeTaken = comboBoxTimeTakenFilter.SelectedItem.ToString().ToLower();
            var filteredRows = string.Equals(selectStatusCode.ToLower(), "all") ? dataTable.AsEnumerable() : dataTable.AsEnumerable().Where(x => x.Field<string>("sc-status") == selectStatusCode);
            if (filteredRows.FirstOrDefault() != null)
            {
                dataTable = filteredRows.CopyToDataTable();
                filteredRows = string.Equals(selectTimeTaken, "all") ? dataTable.AsEnumerable() : dataTable.AsEnumerable().Where(x =>
                {
                    string timeTakenInTable = x.Field<string>("time-taken");
                    int selectedTimeTakenFilter = int.Parse(selectTimeTaken);
                    int timeTakenInTableNum = int.Parse(timeTakenInTable);
                    return timeTakenInTableNum >= selectedTimeTakenFilter;
                });
                dataTable = filteredRows.FirstOrDefault() != null ? filteredRows.CopyToDataTable() : null;
            }
            else
            {
                dataTable = new DataTable();
                //NoDataRow();
            }

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable?.Rows)
                {

                    if (string.Equals(selectStatusCode.ToLower(), "all"))
                    {
                        // Access the value of the specified column
                        object timeTaken = row["time-taken"];
                        int timeTakenValue = int.Parse(timeTaken.ToString());
                        timeTakenValues.Add(timeTakenValue);
                        object time = row["time"];
                        series.Points.AddXY(time, timeTaken);
                    }
                    else if (string.Equals(selectStatusCode.ToLower(), row["sc-status"].ToString()))
                    {
                        // Access the value of the specified column

                        object timeTaken = row["time-taken"];
                        int timeTakenValue = int.Parse(timeTaken.ToString());
                        timeTakenValues.Add(timeTakenValue);
                        object time = row["time"];
                        series.Points.AddXY(time, timeTaken);
                    }
                }
            }
            else
            {
                dataTable = new DataTable();
                //NoDataRow();
                chart.Titles.Clear();
            }
            //}
            if (timeTakenValues.Count > 0)
            {
                // Customize the Chart
                chart.Titles.Clear();
                string title = String.Format("Time taken trend(ms), Min value: {0}, Max value: {1}, Avg value: {2}", timeTakenValues.Min(), timeTakenValues.Max(), Math.Round(timeTakenValues.Average(), 2));
                chart.Titles.Add(title);
                //chart.Titles.Add("Min value: " + timeTakenValues.Min());
                //chart.Titles.Add("Max value: " + timeTakenValues.Max());
                //chart.Titles.Add("Avg value: " + timeTakenValues.Average());
                chart.ChartAreas[0].AxisX.Title = "time";
                chart.ChartAreas[0].AxisY.Title = "time taken";
                chart.Series[0].Color = System.Drawing.Color.Blue;
                chart.Visible = true;
            }
            if (dataTable.Rows.Count <= 0)
            {
                DataTable dataTableCustom = new DataTable("CustomTable");

                // Define columns
                dataTableCustom.Columns.Add("NoData", typeof(string));

                // Step 2: Create a new DataRow
                DataRow newRow = dataTableCustom.NewRow();

                // Step 3: Assign values to the DataRow, including a custom message
                newRow["NoData"] = "No data matching the selected criteria, please change the filter and try again";

                // Step 4: Add the DataRow to the DataTable
                dataTableCustom.Rows.Add(newRow);
                dataTable = dataTableCustom;
            }
            dataGridView1.DataSource = dataTable;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string siteName = comboBox1.SelectedItem.ToString();
        //    int? siteId = GetSiteId(siteName);
        //    string[] iisFiles = GetIisFiles(siteId);
        //    iisfilesComboBox.Items.AddRange(iisFiles);
        //}

        private string[] GetIisFiles(int? siteId)
        {
            var selectedValue = comboBoxIISLogList.SelectedItem;
            string filePath = @"C:\inetpub\logs\LogFiles\W3SVC" + siteId;

            string[] files = Directory.GetFiles(filePath);
            //  iisfilesComboBox.Items.AddRange(files);
            Array.Sort(files, (x, y) => string.Compare(y, x));

            if (files.Length == 0)
            {
                MessageBox.Show("No files found in the selected directory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return files;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void auto(object sender, ScrollEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Use LINQ to get unique values from the "Category" column
            var uniqueCategories = dataTable.AsEnumerable()
                                            .Select(row => row.Field<string>("c-ip"))
                                            .Distinct()
                                            .ToList();
            clientIPComboBox.Items.Clear();
            // Output unique categories
            foreach (var category in uniqueCategories)
            {
                clientIPComboBox.Items.Add(category);
            }
            clientIPComboBox.SelectedIndex = 0;
            clientIPComboBox.Visible = true;
            clientIpLabel.Visible = true;
            dataGridViewClientIP.Visible = true;
        }

        private void clientIPComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filteredRows = dataTable.AsEnumerable()
                              .Where(row => row.Field<string>("c-ip") == clientIPComboBox.SelectedItem.ToString());

            DataTable clientIpWiseList = filteredRows.CopyToDataTable();
            dataGridViewClientIP.DataSource = clientIpWiseList;
            dataGridViewClientIP.Visible = true;
        }

        private void comboBoxIISLogList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iisLogContent = string.Empty;
            string selectedIisLogFile = comboBoxIISLogList.SelectedItem.ToString();
            if (selectedIisLogFile.Length > 0)
            {
                iisLogContent = System.IO.File.ReadAllText(selectedIisLogFile);
            }
            else
            {
                MessageBox.Show("No log files found.", "Information");
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(iisLogContent);
            ReadLog(byteArray);
            clientIPComboBox.Visible = false;
            clientIpLabel.Visible = false;
            dataGridViewClientIP.Visible = false;
            chart1.Visible = true;
        }

        private void clientIpLabel_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            // FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            //  DialogResult result = folderDlg.ShowDialog();
            string folderPath = folderDlg.SelectedPath;
            if (result == DialogResult.OK)
            {

                //   
                // textBox1.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                // textBox1.Text = folderDlg.SelectedPath;
                //  Environment.SpecialFolder root = folderDlg.RootFolder;
                if (Directory.Exists(folderPath))
                {
                    // Get all files in the specified directory
                    string[] files = Directory.GetFiles(folderPath);
                    comboBoxIISLogList.Items.Clear();
                    comboBoxIISLogList.Items.AddRange(files);
                    comboBoxIISLogList.SelectedIndex = 0;
                    comboBoxIISLogList.Visible = true;
                    dataGridView1.Visible = true;
                    buttonClientIp.Visible = true;
                }
                else
                {
                    MessageBox.Show("Directory does not exist.");
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            // FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            //  DialogResult result = folderDlg.ShowDialog();
            string folderPath = folderDlg.SelectedPath;
            if (result == DialogResult.OK)
            {
                if (Directory.Exists(folderPath))
                {
                    // Get all files in the specified directory
                    string[] files = Directory.GetFiles(folderPath);
                    comboBoxIISLogList.Items.Clear();
                    comboBoxIISLogList.Items.AddRange(files);
                    comboBoxIISLogList.SelectedIndex = 0;
                    comboBoxIISLogList.Visible = true;
                    dataGridView1.Visible = true;
                    buttonClientIp.Visible = true;
                    comboBoxSiteList.SelectedIndex = 0;
                    labelSelectedPath.Text = "Selected Path: " + folderPath;
                }
                else
                {
                    MessageBox.Show("Directory does not exist.");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void NoDataRow()
        {
            DataTable dataTableCustom = new DataTable("CustomTable");

            // Define columns
            dataTableCustom.Columns.Add("NoData", typeof(string));

            // Step 2: Create a new DataRow
            DataRow newRow = dataTableCustom.NewRow();

            // Step 3: Assign values to the DataRow, including a custom message
            newRow["NoData"] = "No data matching the selected criteria, please change the filter and try again";

            // Step 4: Add the DataRow to the DataTable
            dataTableCustom.Rows.Add(newRow);
            dataTable = dataTableCustom;
        }

        private void comboBoxSiteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIISLogList.Items.Clear();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int currentTabIndex = tabControl1.SelectedIndex;
            MessageBox.Show($"Current Tab Index: {currentTabIndex}");
            if (currentTabIndex == 1)
            {
                DataTable dtTop20SlowReq = dataTable.AsEnumerable().OrderByDescending(row => row.Field<string>("time-taken")).Take(20).CopyToDataTable();

            }

        }
    }

    class ComboItem
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }
}
