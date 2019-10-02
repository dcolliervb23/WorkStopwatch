using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Configuration;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace WorkStopwatch
{
    public partial class StopwatchForm : Form
    {
        private StopwatchService[] _stopwatchServices;
        private readonly int _projectCount = 10;
        private TimeSpan _lastSaved = TimeSpan.Zero;
        private DateTime _dayStartTime;

        private string _timesheetFilename =
            ConfigurationManager.AppSettings["timesheetFilename"] ?? "work_timesheet.json";

        public StopwatchForm()
        {
            InitializeComponent();
            _stopwatchServices = new StopwatchService[_projectCount];
            for (var index = 0; index < _projectCount; index++)
            {
                _stopwatchServices[index] = new StopwatchService();
            }
            appTimer.Start();

        }


        private void appTimer_Tick(object sender, EventArgs e)
        {
            timeElapsedLbl1.Text = _stopwatchServices[0].ElapsedTime.ToString("G");
            timeElapsedLbl2.Text = _stopwatchServices[1].ElapsedTime.ToString("G");
            timeElapsedLbl3.Text = _stopwatchServices[2].ElapsedTime.ToString("G");
            timeElapsedLbl4.Text = _stopwatchServices[3].ElapsedTime.ToString("G");
            timeElapsedLbl5.Text = _stopwatchServices[4].ElapsedTime.ToString("G");
            timeElapsedLbl6.Text = _stopwatchServices[5].ElapsedTime.ToString("G");
            timeElapsedLbl7.Text = _stopwatchServices[6].ElapsedTime.ToString("G");
            timeElapsedLbl8.Text = _stopwatchServices[7].ElapsedTime.ToString("G");
            timeElapsedLbl9.Text = _stopwatchServices[8].ElapsedTime.ToString("G");

            TimeSpan totalTime = new TimeSpan();
            foreach (var stopwatchService in _stopwatchServices)
            {
                if (!stopwatchService.OmitFromTotal)
                {
                    totalTime = totalTime.Add(stopwatchService.ElapsedTime);
                }
            }

            int manualHours = 0;
            int manualMinutes = 0;
            Int32.TryParse(manualHoursTxtBox.Text, out manualHours);
            Int32.TryParse(manualMinutesTxtbox.Text, out manualMinutes);
            totalTime = totalTime.Add(new TimeSpan(manualHours, manualMinutes, 0));

            totalTimeLbl.Text = totalTime.ToString("G");

            // autosave every 10 minutes
            if (_lastSaved.Add(new TimeSpan(0, Int32.Parse(ConfigurationManager.AppSettings["backupMinutes"]),
                    Int32.Parse(ConfigurationManager.AppSettings["backupSeconds"]))) < totalTime)
            {
                SaveData("backup.");
                _lastSaved = totalTime;
            }
        }

        #region All The Stopwatch Control Buttons Clicks

        private void SetStartTime()
        {
            if (!_stopwatchServices.Any(x => x.ElapsedTime > TimeSpan.Zero))
            {
                _dayStartTime = DateTime.Now;
                dayStartLabel.Text = _dayStartTime.ToLongTimeString();
            }
        }

        private void startBtn1_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[0].StartStopwatch();
            startBtn1.Enabled = false;
        }

        private void pauseBtn1_Click(object sender, EventArgs e)
        {
            _stopwatchServices[0].PauseStopwatch();
            startBtn1.Enabled = true;
        }

        private void resetBtn1_Click(object sender, EventArgs e)
        {
            _stopwatchServices[0].ResetStopwatch();
            startBtn1.Enabled = true;
            timerBoost1.Value = 0;
        }

        private void startBtn2_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[1].StartStopwatch();
            startBtn2.Enabled = false;
        }

        private void pauseBtn2_Click(object sender, EventArgs e)
        {
            _stopwatchServices[1].PauseStopwatch();
            startBtn2.Enabled = true;
        }

        private void resetBtn2_Click(object sender, EventArgs e)
        {
            _stopwatchServices[1].ResetStopwatch();
            startBtn2.Enabled = true;
            timerBoost2.Value = 0;
        }

        private void startBtn3_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[2].StartStopwatch();
            startBtn3.Enabled = false;
        }

        private void pauseBtn3_Click(object sender, EventArgs e)
        {
            _stopwatchServices[2].PauseStopwatch();
            startBtn3.Enabled = true;
        }

        private void resetBtn3_Click(object sender, EventArgs e)
        {
            _stopwatchServices[2].ResetStopwatch();
            startBtn3.Enabled = true;
            timerBoost3.Value = 0;
        }

        private void startBtn4_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[3].StartStopwatch();
            startBtn4.Enabled = false;
        }

        private void pauseBtn4_Click(object sender, EventArgs e)
        {
            _stopwatchServices[3].PauseStopwatch();
            startBtn4.Enabled = true;
        }

        private void resetBtn4_Click(object sender, EventArgs e)
        {
            _stopwatchServices[3].ResetStopwatch();
            startBtn4.Enabled = true;
            timerBoost4.Value = 0;
        }

        private void startBtn5_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[4].StartStopwatch();
            startBtn5.Enabled = false;
        }

        private void pauseBtn5_Click(object sender, EventArgs e)
        {
            _stopwatchServices[4].PauseStopwatch();
            startBtn5.Enabled = true;
        }

        private void resetBtn5_Click(object sender, EventArgs e)
        {
            _stopwatchServices[4].ResetStopwatch();
            startBtn5.Enabled = true;
            timerBoost5.Value = 0;
        }

        private void startBtn6_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[5].StartStopwatch();
            startBtn6.Enabled = false;
        }

        private void pauseBtn6_Click(object sender, EventArgs e)
        {
            _stopwatchServices[5].PauseStopwatch();
            startBtn6.Enabled = true;
        }

        private void resetBtn6_Click(object sender, EventArgs e)
        {
            _stopwatchServices[5].ResetStopwatch();
            startBtn6.Enabled = true;
            timerBoost6.Value = 0;
        }

        private void startBtn7_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[6].StartStopwatch();
            startBtn7.Enabled = false;
        }

        private void pauseBtn7_Click(object sender, EventArgs e)
        {
            _stopwatchServices[6].PauseStopwatch();
            startBtn7.Enabled = true;
        }

        private void resetBtn7_Click(object sender, EventArgs e)
        {
            _stopwatchServices[6].ResetStopwatch();
            startBtn7.Enabled = true;
            timerBoost7.Value = 0;
        }


        private void startBtn8_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[7].StartStopwatch();
            startBtn8.Enabled = false;
        }

        private void pauseBtn8_Click(object sender, EventArgs e)
        {
            _stopwatchServices[7].PauseStopwatch();
            startBtn8.Enabled = true;

        }

        private void resetBtn8_Click(object sender, EventArgs e)
        {
            _stopwatchServices[7].ResetStopwatch();
            startBtn8.Enabled = true;
            timerBoost8.Value = 0;

        }

        private void startBtn9_Click(object sender, EventArgs e)
        {
            SetStartTime();
            _stopwatchServices[8].StartStopwatch();
            startBtn9.Enabled = false;
        }


        private void pauseBtn9_Click_1(object sender, EventArgs e)
        {
            _stopwatchServices[8].PauseStopwatch();
            startBtn9.Enabled = true;
        }

        private void resetBtn9_Click(object sender, EventArgs e)
        {
            _stopwatchServices[8].ResetStopwatch();
            startBtn9.Enabled = true;
            timerBoost9.Value = 0;

        }

        #endregion

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear all project timesheet data?", "Confirm Clear",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }


            // Reset Names
            projectNameTxtBox1.Text = string.Empty;
            projectNameTxtBox2.Text = string.Empty;
            projectNameTxtBox3.Text = string.Empty;
            projectNameTxtBox4.Text = string.Empty;
            projectNameTxtBox5.Text = string.Empty;
            projectNameTxtBox6.Text = string.Empty;
            projectNameTxtBox7.Text = string.Empty;
            projectNameTxtBox8.Text = string.Empty;
            projectNameTxtBox9.Text = string.Empty;


            ClearAllButNames();
        }

        private void ClearAllButNames()
        {
            for (int i = 0; i < _projectCount; i++)
            {
                _stopwatchServices[i].SetStartTimeOffset(TimeSpan.Zero);
                _stopwatchServices[i].ResetStopwatch();
            }
            _dayStartTime = DateTime.MinValue;
            dayStartLabel.Text = string.Empty;

            // Reset Boosts
            timerBoost1.Value = 0;
            timerBoost2.Value = 0;
            timerBoost3.Value = 0;
            timerBoost4.Value = 0;
            timerBoost5.Value = 0;
            timerBoost6.Value = 0;
            timerBoost7.Value = 0;
            timerBoost8.Value = 0;
            timerBoost9.Value = 0;

            manualHoursTxtBox.Text = string.Empty;
            manualMinutesTxtbox.Text = string.Empty;

            // Reset Descriptions
            description1.Text = string.Empty;
            description2.Text = string.Empty;
            description3.Text = string.Empty;
            description4.Text = string.Empty;
            description5.Text = string.Empty;
            description6.Text = string.Empty;
            description7.Text = string.Empty;
            description8.Text = string.Empty;
            description9.Text = string.Empty;
            description10.Text = string.Empty;
        }

        private void saveAllBtn_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData(string fileSuffix = "")
        {
            var dailyData = new DailyTimeDataModel()
            {
                StartTime = _dayStartTime,
                SaveTime = DateTime.Now,
                DailySummary = dailySummary.Text
            };
            for (int i = 0; i < _projectCount-1; i++)
            {
                dailyData.ProjectTime.Add(new ProjectTimeDataModel()
                {
                    ElapsedTime = _stopwatchServices[i].ElapsedTime,
                });
                dailyData.TotalTime += _stopwatchServices[i].ElapsedTime;
            }
            int manualHours = 0;
            int manualMinutes = 0;
            Int32.TryParse(manualHoursTxtBox.Text, out manualHours);
            Int32.TryParse(manualMinutesTxtbox.Text, out manualMinutes);

            dailyData.ProjectTime.Add(new ProjectTimeDataModel()
            {
                ElapsedTime = new TimeSpan(manualHours, manualMinutes, 0)
            });

            dailyData.ProjectTime[0].Name = projectNameTxtBox1.Text;
            dailyData.ProjectTime[1].Name = projectNameTxtBox2.Text;
            dailyData.ProjectTime[2].Name = projectNameTxtBox3.Text;
            dailyData.ProjectTime[3].Name = projectNameTxtBox4.Text;
            dailyData.ProjectTime[4].Name = projectNameTxtBox5.Text;
            dailyData.ProjectTime[5].Name = projectNameTxtBox6.Text;
            dailyData.ProjectTime[6].Name = projectNameTxtBox7.Text;
            dailyData.ProjectTime[7].Name = projectNameTxtBox8.Text;
            dailyData.ProjectTime[8].Name = projectNameTxtBox9.Text;
            dailyData.ProjectTime[9].Name = "Manual Entry";

            dailyData.ProjectTime[0].Description = description1.Text;
            dailyData.ProjectTime[1].Description = description2.Text;
            dailyData.ProjectTime[2].Description = description3.Text;
            dailyData.ProjectTime[3].Description = description4.Text;
            dailyData.ProjectTime[4].Description = description5.Text;
            dailyData.ProjectTime[5].Description = description6.Text;
            dailyData.ProjectTime[6].Description = description7.Text;
            dailyData.ProjectTime[7].Description = description8.Text;
            dailyData.ProjectTime[8].Description = description9.Text;
            dailyData.ProjectTime[9].Description = description10.Text;

            var serializedProjectData = JsonConvert.SerializeObject(dailyData, Formatting.Indented);
            using (var streamWriter =
                new StreamWriter($"{Path.GetFileNameWithoutExtension(_timesheetFilename)}.{fileSuffix}json"))
            {
//                streamWriter.Write(JsonConvert.SerializeObject(dailyData, Formatting.Indented));
                streamWriter.Write(serializedProjectData);
            }

            var dailyDirectory = $"{Directory.GetCurrentDirectory()}\\daily";
            var dailySuffix = $"{_dayStartTime.Year}-{_dayStartTime.Month}-{_dayStartTime.Day}";

            if (!Directory.Exists(dailyDirectory))
            {
                Directory.CreateDirectory(dailyDirectory);
            }
            using (var streamWriter =
                new StreamWriter($"{dailyDirectory}\\{Path.GetFileNameWithoutExtension(_timesheetFilename)}.{dailySuffix}.json"))
            {
                //                streamWriter.Write(JsonConvert.SerializeObject(dailyData, Formatting.Indented));
                streamWriter.Write(serializedProjectData);
            }
        }

        private void loadSavedBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to load previously saved project timesheet data?", "Confirm Load Data",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            using (var streamReader = new StreamReader(_timesheetFilename))
            {
                var previousData = GetPreviousData(streamReader);

                // Set Names
                SetNames(previousData);

                // Set Stopwatches
                for (int i = 0; i < _stopwatchServices.Length && i < previousData.Count; i++)
                {
                    _stopwatchServices[i].ResetStopwatch();
                    _stopwatchServices[i].SetStartTimeOffset(previousData[i].ElapsedTime);
                }

                manualHoursTxtBox.Text = previousData.Last().ElapsedTime.Hours.ToString();
                manualMinutesTxtbox.Text = previousData.Last().ElapsedTime.Minutes.ToString();

                // Set Descriptions
                description1.Text = (previousData.Count > 1 ? previousData[0].Description : String.Empty);
                description2.Text = (previousData.Count > 2 ? previousData[1].Description : String.Empty);
                description3.Text = (previousData.Count > 3 ? previousData[2].Description : String.Empty);
                description4.Text = (previousData.Count > 4 ? previousData[3].Description : String.Empty);
                description5.Text = (previousData.Count > 5 ? previousData[4].Description : String.Empty);
                description6.Text = (previousData.Count > 6 ? previousData[5].Description : String.Empty);
                description7.Text = (previousData.Count > 7 ? previousData[6].Description : String.Empty);
                description8.Text = (previousData.Count > 8 ? previousData[7].Description : String.Empty);
                description8.Text = (previousData.Count > 9 ? previousData[8].Description : String.Empty);
                description9.Text = (previousData.Count > 10 ? previousData[9].Description : String.Empty);
            }
        }

        private List<ProjectTimeDataModel> GetPreviousData(StreamReader streamReader)
        {
            var previousDataString = streamReader.ReadToEnd();
            var previousData = JsonConvert.DeserializeObject<List<ProjectTimeDataModel>>(previousDataString);



            return previousData;
        }

        private void SetNames(List<ProjectTimeDataModel> previousData)
        {
            projectNameTxtBox1.Text = previousData[0].Name;
            projectNameTxtBox2.Text = previousData[1].Name;
            projectNameTxtBox3.Text = previousData[2].Name;
            projectNameTxtBox4.Text = previousData[3].Name;
            projectNameTxtBox5.Text = previousData[4].Name;
            projectNameTxtBox6.Text = previousData[5].Name;
            projectNameTxtBox7.Text = previousData[6].Name;
            projectNameTxtBox8.Text = previousData[7].Name;
            projectNameTxtBox9.Text = previousData[8].Name;
        }


        private void loadProjectNamesBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to load previously saved project timesheet data?", "Confirm Load Data",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            using (var streamReader = new StreamReader(_timesheetFilename))
            {
                var previousData = GetPreviousData(streamReader);

                // Set Names
                SetNames(previousData);
            }
        }

        private void archiveBtn_Click(object sender, EventArgs e)
        {
            var today = DateTime.Now;
            SaveData($"{today.Year}-{today.Month}-{today.Day}-{today.Hour}-{today.Minute}-{today.Second}.");
        }

        private void totalTimeLbl_Click(object sender, EventArgs e)
        {

        }

        private void clearAllButProjNames_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear all project timesheet data but the names?", "Confirm Clear",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            ClearAllButNames();
        }



        #region Omit Methods
        private void omitFromTotal_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[0].OmitFromTotal = omitFromTotal1.Checked;
        }

        private void omitFromTotal2_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[1].OmitFromTotal = omitFromTotal2.Checked;
        }

        private void omitFromTotal3_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[2].OmitFromTotal = omitFromTotal3.Checked;
        }

        private void omitFromTotal4_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[3].OmitFromTotal = omitFromTotal4.Checked;
        }

        private void omitFromTotal5_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[4].OmitFromTotal = omitFromTotal5.Checked;
        }

        private void omitFromTotal6_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[5].OmitFromTotal = omitFromTotal6.Checked;
        }

        private void omitFromTotal7_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[6].OmitFromTotal = omitFromTotal7.Checked;
        }

        private void omitFromTotal8_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[7].OmitFromTotal = omitFromTotal8.Checked;
        }

        private void omitFromTotal9_CheckedChanged(object sender, EventArgs e)
        {
            _stopwatchServices[8].OmitFromTotal = omitFromTotal9.Checked;
        }
        #endregion


        #region Timer Boost
        private void timerBoost_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[0].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost1.Value), 0);
        }

        private void timerBoost2_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[1].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost2.Value), 0);
        }

        private void timerBoost3_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[2].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost3.Value), 0);
        }

        private void timerBoost4_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[3].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost4.Value), 0);
        }

        private void timerBoost5_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[4].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost5.Value), 0);
        }

        private void timerBoost6_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[5].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost6.Value), 0);
        }

        private void timerBoost7_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[6].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost7.Value), 0);
        }

        private void timerBoost8_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[7].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost8.Value), 0);
        }

        private void timerBoost9_ValueChanged(object sender, EventArgs e)
        {
            _stopwatchServices[8].BoostTimeSpan = new TimeSpan(0, (int)(timerBoost9.Value), 0);
        }
        #endregion

        private void StopwatchForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
