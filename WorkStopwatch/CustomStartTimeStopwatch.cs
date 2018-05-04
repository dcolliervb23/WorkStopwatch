using System;
using System.Diagnostics;

namespace WorkStopwatch
{
    public class CustomStartTimeStopwatch : Stopwatch
    {
        private TimeSpan _startOffSet;

        public CustomStartTimeStopwatch()
        {
            _startOffSet = TimeSpan.Zero;
        }

        public CustomStartTimeStopwatch(TimeSpan startOffSet)
        {
            _startOffSet = startOffSet;
        }

        public new TimeSpan Elapsed
        {
            get
            {
                var foo = new TimeSpan();
                foo = foo.Add(_startOffSet);
                foo = foo.Add(base.Elapsed);
                return foo;
            }
        }
    }
}