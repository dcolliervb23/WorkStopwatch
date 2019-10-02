using System;
using System.Collections.Generic;

namespace WorkStopwatch
{
    public class DailyTimeDataModel
    {
        public DailyTimeDataModel()
        {
            ProjectTime = new List<ProjectTimeDataModel>(9);
        }

        public DateTime StartTime { get; set; }
        public DateTime SaveTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public string DailySummary { get; set; }
        public List<ProjectTimeDataModel> ProjectTime { get; set; }
    }
}