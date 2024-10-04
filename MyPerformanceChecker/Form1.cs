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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.AxHost;
using System.Data.Common;
using System.Drawing.Drawing2D;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Drawing.Printing;

namespace MyPerformanceChecker
{
    public partial class Form1 : Form
    {
        DataTable dataTable = new DataTable();
        List<KeyValuePair<string, string>> siteLogLocation = new List<KeyValuePair<string, string>>();
        private System.Windows.Forms.ToolTip chartToolTip = new System.Windows.Forms.ToolTip();
        List<int> indexList = new List<int>();
        private System.Drawing.Image start;
        private System.Drawing.Image stop;
        private bool isImage1Active;
        private int PageSize = 500;
        private int PageNo = 1;
        private int totalRecordsInLog = 0;
        public Form1()
        {
            InitializeComponent();
            ListIISSites();
            // Set the selected index to 0 to select the first item
            if (comboBoxSiteList.Items.Count > 0)
            {
                comboBoxSiteList.SelectedIndex = 0; // Selects the first option in the ComboBox
            }
            chart1.Visible = false;

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

            pictureBoxLoading.Visible = false;

            buttonNext.Visible = false;
            buttonPrevious.Visible = false;

        }

        private DataTable GetPaginatedData(DataTable data, int pageNumber, int pageSize)
        {
            buttonPrevious.Visible = true;
            buttonNext.Visible = true;

            // Calculate the number of items to skip
            int skip = (pageNumber - 1) * pageSize;
            skip = skip < 0 ? 0 : skip;
            int currentTotal = skip + pageSize;
            int currentPage = currentTotal / pageSize;
            double totalPages = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(totalRecordsInLog) / Convert.ToDouble(pageSize)));

            labelPageInfo.Text = $"Showing page {currentPage} of total pages {totalPages}";

            if (currentTotal >= totalRecordsInLog)
            {
                buttonNext.Enabled = false;
            }
            else
            {
                buttonNext.Enabled = true;
            }
            if (currentTotal <= pageSize)
            {
                buttonPrevious.Enabled = false;
            }
            else
            {
                buttonPrevious.Enabled = true;

            }
            // Get the paginated data using Skip and Take
            return data.AsEnumerable().Skip(skip).Take(pageSize).CopyToDataTable();

        }
        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            // Check if the byte array is valid
            if (byteArray == null || byteArray.Length == 0)
            {
                return null;
            }

            // Create a memory stream from the byte array
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                // Return an Image object created from the memory stream
                return System.Drawing.Image.FromStream(ms);
            }
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
                    comboBoxSiteList.Items.Add(site.Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

                        comboBoxIISLogsCustomeRange.Items.Clear();
                        comboBoxIISLogsCustomeRange.Items.AddRange(files);
                        comboBoxIISLogsCustomeRange.SelectedIndex = 0;


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
            dataTable = ConvertColumnType(dataTable, "time-taken", typeof(int));
            dataTable = ConvertColumnType(dataTable, "time", typeof(DateTime));
            totalRecordsInLog = dataTable.Rows.Count;
            DataTable newDataTable = GetPaginatedData(dataTable, PageNo, PageSize);
            InitializeChart(newDataTable, chart1);
        }
        public void InitializeChart(DataTable dataTable, Chart chart)
        {
            //Chart chart = chart1;
            List<int> timeTakenValues = new List<int>();

            chart.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainChartArea");
            chart.ChartAreas.Add(chartArea);

            // Create a new Series and add it to the Chart control
            Series series = new Series("Time taken for the site: ")
            {
                ChartType = SeriesChartType.Line, // Set the chart type (Line, Bar, Pie, etc.)
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,  // Set the marker style to dot (circle)
                MarkerSize = 8,                    // Size of the marker (dot)
                MarkerColor = System.Drawing.Color.Red
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
                    //string timeTakenInTable = x.Field<string>("time-taken");
                    int selectedTimeTakenFilter = int.Parse(selectTimeTaken);
                    int timeTakenInTableNum = x.Field<int>("time-taken");
                    // int timeTakenInTableNum = int.Parse(timeTakenInTable);
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
                    // var dateTimeVal = Convert.ToDateTime(row["time"]);
                    // var dateTimeNewVal = new DateTime(dateTimeVal.Year, dateTimeVal.Month, dateTimeVal.Day, dateTimeVal.Hour, dateTimeVal.Minute, dateTimeVal.Second);
                    //DateTime datePart1 = DateTime.Parse(row["date"].ToString());
                    DateTime dateTimeNewVal = DateTime.Parse(row["time"].ToString());

                    if (string.Equals(selectStatusCode.ToLower(), "all"))
                    {
                        // Access the value of the specified column
                        object timeTaken = row["time-taken"];
                        int timeTakenValue = int.Parse(timeTaken.ToString());
                        timeTakenValues.Add(timeTakenValue);
                        // object time = row["time"];
                        series.Points.AddXY(dateTimeNewVal, timeTaken);
                    }
                    else if (string.Equals(selectStatusCode.ToLower(), row["sc-status"].ToString()))
                    {
                        // Access the value of the specified column

                        object timeTaken = row["time-taken"];
                        int timeTakenValue = int.Parse(timeTaken.ToString());
                        timeTakenValues.Add(timeTakenValue);
                        // object time = row["time"];
                        series.Points.AddXY(dateTimeNewVal, timeTaken);
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
            chart.MouseMove += Chart_MouseMove;
            //labelTotalNoOfRequests.Text = "Total number of requests are: " + dataTable.Rows.Count;

            dataGridView1.DataSource = dataTable;
        }
        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chart = sender as Chart;
            HitTestResult result = chart.HitTest(e.X, e.Y);
            DataPoint dataPoint = null;
            DateTime xDate = new DateTime();
            DataGridViewRow newRow = dataGridView1.Rows[0];
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                dataPoint = chart.Series[0].Points[result.PointIndex];
                xDate = DateTime.FromOADate(dataPoint.XValue); // Convert XValue to DateTime

                // Show tooltip with formatted date and value
                chartToolTip.Show($"Date: {xDate:dd-MM-yyyy}, Value: {dataPoint.YValues[0]}",
                                  chart, e.X, e.Y - 15);
                newRow = dataGridView1.Rows
                 .Cast<DataGridViewRow>()
                 .FirstOrDefault(row => Convert.ToDateTime(row.Cells["time"].Value) == xDate && Convert.ToInt64(row.Cells["time-taken"].Value) == dataPoint.YValues[0]);

                dataGridView1.FirstDisplayedScrollingRowIndex = newRow.Index; // Scroll to the row if needed
                indexList.Add(newRow.Index);
                newRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                chartToolTip.Hide(chart);
                if (indexList.Count > 0)
                {
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        DataGridViewRow row = dataGridView1.Rows[indexList[i]];
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
                    }
                    indexList = new List<int>();
                }
                // dataGridView1.FirstDisplayedScrollingRowIndex = newRow.Index; // Scroll to the row if needed

            }
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

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

                    comboBoxIISLogsCustomeRange.Items.Clear();
                    comboBoxIISLogsCustomeRange.Items.AddRange(files);
                    comboBoxIISLogsCustomeRange.SelectedIndex = 0;


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

                    comboBoxIISLogsCustomeRange.Items.Clear();
                    comboBoxIISLogsCustomeRange.Items.AddRange(files);
                    comboBoxIISLogsCustomeRange.SelectedIndex = 0;


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
            switch (currentTabIndex)
            {
                case 1:
                    dataTable.AsEnumerable().OrderByDescending(x => x.Field<int>("time-taken")).CopyToDataTable();
                    DataView sortedView = new DataView(dataTable);
                    sortedView.Sort = "time-taken desc";
                    dataTable = sortedView.ToTable();
                    dataGridViewTop20SlowReqs.DataSource = dataTable.AsEnumerable().Take(20).CopyToDataTable();
                    break;

                case 2:
                    DataTable resultTable = GroupByAndFindMinMax(dataTable, "cs-uri-stem");
                    // Bind the result DataTable to a DataGridView
                    dataGridViewTop25SlowUrls.DataSource = resultTable.AsEnumerable().Take(25).CopyToDataTable();
                    break;

                case 3:
                    DataTable dtPerHour = GroupByRequestPerHour(dataTable);
                    dataGridViewRequestPerHour.DataSource = dtPerHour;
                    break;

                case 4:
                    //List<DateTime> dateTimeStrings = dataTable.AsEnumerable().Select(x => x.Field<DateTime>("time")).Distinct().ToList();
                    //string[] dateStrings = dateTimeStrings.ConvertAll(date => date.ToString("HH:mm:ss")).ToArray();
                    //Thread.Sleep(2000);
                    //pictureBoxLoading.Visible = false;
                    //comboBoxStartTime.Items.AddRange(dateStrings);
                    //comboBoxStartTime.SelectedIndex = 0;
                    //comboBoxEndTime.Items.AddRange(dateStrings);
                    //comboBoxEndTime.SelectedIndex = 0;
                    break;

                default:
                    break;
            }
        }
        static DataTable ConvertColumnType(DataTable oldTable, string columnName, Type newType)
        {
            DataTable newTable = new DataTable();

            // Copy the schema from the old table but with the new column type
            foreach (DataColumn column in oldTable.Columns)
            {
                if (column.ColumnName == columnName)
                {
                    newTable.Columns.Add(column.ColumnName, newType);
                }
                else
                {
                    newTable.Columns.Add(column.ColumnName, column.DataType);
                }
            }

            // Copy rows and convert the column type
            foreach (DataRow row in oldTable.Rows)
            {
                DataRow newRow = newTable.NewRow();
                foreach (DataColumn column in oldTable.Columns)
                {
                    if (column.ColumnName == columnName)
                    {
                        if (columnName == "time")
                        {
                            DateTime datePart = DateTime.Parse(row["date"].ToString());
                            TimeSpan timePart = TimeSpan.Parse(row["time"].ToString());
                            DateTime combinedDateTime = datePart.Date + timePart;
                            newRow[column.ColumnName] = combinedDateTime;
                        }
                        else
                            // Convert the column value to the new type
                            newRow[column.ColumnName] = Convert.ChangeType(row[column.ColumnName], newType);
                    }
                    else
                    {
                        newRow[column.ColumnName] = row[column.ColumnName];
                    }
                }
                newTable.Rows.Add(newRow);
            }

            return newTable;
        }

        private DataTable GroupByAndFindMinMax(DataTable dt, string groupByColumn)
        {
            var groupedData = dt.AsEnumerable()
                .GroupBy(row => row.Field<string>("cs-uri-stem"))
                .Select(g => new
                {
                    Group = g.Key,
                    MaxValue = g.Max(row => row.Field<int>("time-taken")),
                    MinValue = g.Min(row => row.Field<int>("time-taken"))
                })
                .ToList();

            // Create a new DataTable to hold the results
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("Group", typeof(string));
            resultTable.Columns.Add("MaxValue", typeof(int));
            resultTable.Columns.Add("MinValue", typeof(int));
            resultTable.Columns.Add("Avg", typeof(int));

            // Populate the result DataTable
            foreach (var data in groupedData)
            {
                DataRow row = resultTable.NewRow();
                row["Group"] = data.Group;
                int minVal = data.MinValue;
                int maxVal = data.MaxValue;
                row["MaxValue"] = maxVal;
                row["MinValue"] = minVal;
                row["Avg"] = (minVal + maxVal) / 2;
                resultTable.Rows.Add(row);
            }
            return resultTable;
        }

        private DataTable GroupByRequestPerHour(DataTable dt)
        {
            var result = dt.AsEnumerable()
                           .GroupBy(row => row.Field<DateTime>("time").ToString("yyyy-MM-dd HH:00:00")) // Group by hour
                           .Select(g => new
                           {
                               Hour = g.Key,
                               RequestCount = g.Count()
                           });

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("Hour", typeof(DateTime));
            resultTable.Columns.Add("RequestCount", typeof(int));

            // Populate the result DataTable
            foreach (var data in result)
            {
                DataRow row = resultTable.NewRow();
                row["Hour"] = data.Hour;
                row["RequestCount"] = data.RequestCount;
                resultTable.Rows.Add(row);
            }
            return resultTable;
        }

        private void buttonRecordCommand_Click(object sender, EventArgs e)
        {
            string btnText = buttonRecordCommand.Text.ToLower();
            if (string.Equals(btnText, "start"))
            {
                richTextBoxVoiceCommand.Text = "Recording.....";
                buttonRecordCommand.Text = "Stop";
            }
            else
            {
                pictureBoxLoading.Visible = true;
                using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\Users\csahu\Downloads\Loading-Windows-HTML-CSS.gif", System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    fs.CopyTo(ms);
                    pictureBoxLoading.Image = System.Drawing.Image.FromStream(ms);
                }
                //Thread.Sleep(2000);
                pictureBoxLoading.Visible = false;
                richTextBoxVoiceCommand.Text = "Pull iis records for September 5th from 07.00PM to 07.20PM";
                buttonRecordCommand.Text = "Start";

                List<DateTime> dateTimeStrings = dataTable.AsEnumerable().Select(x => x.Field<DateTime>("time")).Distinct().ToList();
                string[] dateStrings = dateTimeStrings.ConvertAll(date => date.ToString("HH:mm:ss")).ToArray();
                //Thread.Sleep(2000);
                pictureBoxLoading.Visible = false;
                comboBoxStartTime.Items.AddRange(dateStrings);
                comboBoxStartTime.SelectedIndex = 0;
                comboBoxStartTime.Visible = true;
                comboBoxEndTime.Items.AddRange(dateStrings);
                comboBoxEndTime.SelectedIndex = 4;
                comboBoxEndTime.Visible = true;
                comboBoxIISLogsCustomeRange.Visible = true;
                labelCustomeRangeEndtime.Visible = true;
                labelCustomeTimeRange.Visible = true;
                labellabelCustomeRangeStarttime.Visible = true;
                DataTable dtCustomRange = dataTable.AsEnumerable().Take(17).CopyToDataTable();
                InitializeChart(dtCustomRange, chartCustomRange);
                dataGridViewCustomRange.DataSource = dtCustomRange;

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            PageNo++;
            DataTable dt = GetPaginatedData(dataTable, PageNo, PageSize);
            dataGridView1.DataSource = dt;
            chart1 = new Chart();
            InitializeChart(dt, chart1);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            PageNo--;
            DataTable dt = GetPaginatedData(dataTable, PageNo, PageSize);
            dataGridView1.DataSource = dt;
            chart1 = new Chart();
            InitializeChart(dt, chart1);
        }
    }
    class ComboItem
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }
}
