using System;
using System.Diagnostics;

namespace WorkStopwatch
{
    public class StopwatchService
    {
        private CustomStartTimeStopwatch _internalStopwatch = new CustomStartTimeStopwatch(new TimeSpan(0));

        public TimeSpan ElapsedTime
        {
            get { return _internalStopwatch.Elapsed; }
        }

        public void SetStartTimeOffset(TimeSpan offset)
        {
            _internalStopwatch = new CustomStartTimeStopwatch(offset);
        }


        public void StartStopwatch()
        {
            _internalStopwatch.Start();
        }

        public void PauseStopwatch()
        {
            _internalStopwatch.Stop();
        }

        public void ResetStopwatch()
        {
            _internalStopwatch.Reset();
        }
    }
}