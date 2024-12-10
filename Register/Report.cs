using MySql.Data.MySqlClient;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register
{
    public partial class Report : Form
    {
        MySqlConnection connection = connectionDB.GetConnection();
        public Report()
        {
            InitializeComponent();
            load_graph();
            load_metrics();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void load_metrics()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT 
                    SEC_TO_TIME(CEIL(AVG(TIME_TO_SEC(waiting_time)))) AS avg_waiting_time,
                    SEC_TO_TIME(CEIL(AVG(TIME_TO_SEC(TIMEDIFF(time, ADDTIME(start_time, waiting_time)))))) AS avg_processing_time,
                    SEC_TO_TIME(CEIL(AVG(TIME_TO_SEC(TIMEDIFF(time, start_time))))) AS avg_closing_time
                FROM completed;
                ";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    // Loop through the data reader and populate the DataGridView
                    while (reader.Read())
                    {
                        String avg_wait = reader["avg_waiting_time"].ToString();
                        String avg_proc = reader["avg_processing_time"].ToString();
                        String avg_close = reader["avg_closing_time"].ToString();

                        lblWaitingTime.Text = avg_wait;
                        lblProcessingTime.Text = avg_proc;
                        lblClosingTime.Text = avg_close;

                    }

                }
            }
        }

        private void load_graph()
        {
            // Create a new plot model
            var plotModel = new PlotModel { Title = "Times Chart" };

            // Create line series for different time measurements
            var waitingTimeSeries = new LineSeries
            {
                Title = "Waiting Time",
                MarkerType = MarkerType.Circle,
                Color = OxyColors.Blue
            };

            var processingTimeSeries = new LineSeries
            {
                Title = "Processing Time",
                MarkerType = MarkerType.Circle,
                Color = OxyColors.Green
            };

            var closingTimeSeries = new LineSeries
            {
                Title = "Closing Time",
                MarkerType = MarkerType.Circle,
                Color = OxyColors.Red
            };

            double? earliestStartTime = null; // To track the earliest start time

            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                start_time, 
                waiting_time, 
                TIMEDIFF(time, ADDTIME(start_time, waiting_time)) as processing_time, 
                TIMEDIFF(time, start_time) as closing_time 
            FROM completed 
            ORDER BY start_time ASC;";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            // Parse start_time for X-axis
                            DateTime startTime = DateTime.ParseExact(
                                reader["start_time"].ToString(),
                                "HH:mm:ss",
                                CultureInfo.InvariantCulture
                            );

                            // Convert times to TimeSpan
                            TimeSpan waitingTime = ParseTimeSpan(reader["waiting_time"].ToString());
                            TimeSpan processingTime = ParseTimeSpan(reader["processing_time"].ToString());
                            TimeSpan closingTime = ParseTimeSpan(reader["closing_time"].ToString());

                            // Calculate X-axis value (total seconds since midnight)
                            double xValue = startTime.TimeOfDay.TotalSeconds;

                            // Update earliest start time if necessary
                            if (!earliestStartTime.HasValue || xValue < earliestStartTime.Value)
                            {
                                earliestStartTime = xValue;
                            }

                            // Add data points to respective series
                            waitingTimeSeries.Points.Add(new DataPoint(xValue, waitingTime.TotalMinutes));
                            processingTimeSeries.Points.Add(new DataPoint(xValue, processingTime.TotalMinutes));
                            closingTimeSeries.Points.Add(new DataPoint(xValue, closingTime.TotalMinutes));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error parsing times: {ex.Message}\n\n" +
                                            $"Start Time: {reader["start_time"]}\n" +
                                            $"Waiting Time: {reader["waiting_time"]}\n" +
                                            $"Processing Time: {reader["processing_time"]}\n" +
                                            $"Closing Time: {reader["closing_time"]}");
                        }
                    }
                }
            }

            // Configure X-axis to start at the earliest start time
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Start Time",
                Minimum = earliestStartTime ?? 0, // Default to 0 if no data
                Maximum = 24 * 60 * 60, // 24 hours in seconds
                StringFormat = "00:00:00", // Format to show as HH:mm:ss
                LabelFormatter = seconds =>
                {
                    var timeSpan = TimeSpan.FromSeconds(seconds);
                    return timeSpan.ToString(@"hh\:mm\:ss");
                }
            };
            plotModel.Axes.Add(xAxis);

            // Add the line series to the plot model
            plotModel.Series.Add(waitingTimeSeries);
            plotModel.Series.Add(processingTimeSeries);
            plotModel.Series.Add(closingTimeSeries);

            // Assign the plot model to the PlotView control
            plotviewTimes.Model = plotModel;
        }


        // Helper method to parse time with multiple possible formats
        private TimeSpan ParseTimeSpan(string timeString)
        {
            // Try multiple parsing formats
            string[] formats = new[]
            {
                "hh\\:mm\\:ss",   // 24-hour format with leading zero
                "h\\:mm\\:ss",    // 24-hour format without leading zero
                "HH\\:mm\\:ss"    // Alternative 24-hour format
            };

            foreach (var format in formats)
            {
                if (TimeSpan.TryParseExact(timeString, format, null, out TimeSpan result))
                {
                    return result;
                }
            }

            // If no format works, throw an exception with details
            throw new FormatException($"Unable to parse time string: {timeString}");
        }

        private void test_chart()
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
