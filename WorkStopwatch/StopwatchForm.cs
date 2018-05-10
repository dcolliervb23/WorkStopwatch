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

namespace WorkStopwatch
{
    public partial class StopwatchForm : Form
    {
        private StopwatchService[] _stopwatchServices;
        private readonly int _projectCount = 9;

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
        }

        #region All The Stopwatch Control Buttons Clicks

        private void startBtn1_Click(object sender, EventArgs e)
        {
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
        }

        private void startBtn2_Click(object sender, EventArgs e)
        {
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
        }

        private void startBtn3_Click(object sender, EventArgs e)
        {
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
        }

        private void startBtn4_Click(object sender, EventArgs e)
        {
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
        }

        private void startBtn5_Click(object sender, EventArgs e)
        {
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
        }

        private void startBtn6_Click(object sender, EventArgs e)
        {
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
        }

        private void startBtn7_Click(object sender, EventArgs e)
        {
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
        }


        private void startBtn8_Click(object sender, EventArgs e)
        {
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


            ClearAllButNames();
        }

        private void ClearAllButNames()
        {
            for (int i = 0; i < _projectCount; i++)
            {
                _stopwatchServices[i].SetStartTimeOffset(TimeSpan.Zero);
                _stopwatchServices[i].ResetStopwatch();
            }

            // Reset Boosts
            timerBoost1.Value = 0;
            timerBoost2.Value = 0;
            timerBoost3.Value = 0;
            timerBoost4.Value = 0;
            timerBoost5.Value = 0;
            timerBoost6.Value = 0;
            timerBoost7.Value = 0;
            timerBoost8.Value = 0;

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
        }

        private void saveAllBtn_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData(string fileSuffix = "")
        {
            var projectData = new List<ProjectTimeDataModel>();
            for (int i = 0; i < _projectCount-1; i++)
            {
                projectData.Add(new ProjectTimeDataModel()
                {
                    ElapsedTime = _stopwatchServices[i].ElapsedTime,
                });
            }
            int manualHours = 0;
            int manualMinutes = 0;
            Int32.TryParse(manualHoursTxtBox.Text, out manualHours);
            Int32.TryParse(manualMinutesTxtbox.Text, out manualMinutes);

            projectData.Add(new ProjectTimeDataModel()
            {
                ElapsedTime = new TimeSpan(manualHours, manualMinutes, 0)
            });

            projectData[0].Name = projectNameTxtBox1.Text;
            projectData[1].Name = projectNameTxtBox2.Text;
            projectData[2].Name = projectNameTxtBox3.Text;
            projectData[3].Name = projectNameTxtBox4.Text;
            projectData[4].Name = projectNameTxtBox5.Text;
            projectData[5].Name = projectNameTxtBox6.Text;
            projectData[6].Name = projectNameTxtBox7.Text;
            projectData[7].Name = projectNameTxtBox8.Text;
            projectData[8].Name = "Manual Entry";

            projectData[0].Description = description1.Text;
            projectData[1].Description = description2.Text;
            projectData[2].Description = description3.Text;
            projectData[3].Description = description4.Text;
            projectData[4].Description = description5.Text;
            projectData[5].Description = description6.Text;
            projectData[6].Description = description7.Text;
            projectData[7].Description = description8.Text;
            projectData[8].Description = description9.Text;

            var serializedProjectData = JsonConvert.SerializeObject(projectData, Formatting.Indented);
            using (var streamWriter =
                new StreamWriter($"{Path.GetFileNameWithoutExtension(_timesheetFilename)}.{fileSuffix}json"))
            {
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
                for (int i = 0; i < _projectCount; i++)
                {
                    _stopwatchServices[i].ResetStopwatch();
                    _stopwatchServices[i].SetStartTimeOffset(previousData[i].ElapsedTime);
                }

                manualHoursTxtBox.Text = previousData.Last().ElapsedTime.Hours.ToString();
                manualMinutesTxtbox.Text = previousData.Last().ElapsedTime.Minutes.ToString();

                // Set Descriptions
                description1.Text = previousData[0].Description;
                description2.Text = previousData[1].Description;
                description3.Text = previousData[2].Description;
                description4.Text = previousData[3].Description;
                description5.Text = previousData[4].Description;
                description6.Text = previousData[5].Description;
                description7.Text = previousData[6].Description;
                description8.Text = previousData[7].Description;
                description8.Text = previousData[8].Description;
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
        #endregion
    }
}
