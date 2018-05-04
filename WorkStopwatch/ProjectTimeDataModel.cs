using System;

namespace WorkStopwatch
{
    public class ProjectTimeDataModel
    {
        public string Name { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public string Description { get; set; }
    }
}