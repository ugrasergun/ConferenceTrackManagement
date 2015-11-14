using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConferenceTrackManagement.Helpers
{
    public static class Extensions
    {
        public static bool Between(this TimeSpan ts, TimeSpan startTime, TimeSpan endTime, BetweenProperty betweenProperty = BetweenProperty.Exclusive)
        {
            if (ts > startTime && ts < endTime)
                return true;
            if ((betweenProperty == BetweenProperty.Inclusive || betweenProperty == BetweenProperty.LeftInclusive) && ts == startTime)
                return true;
            if ((betweenProperty == BetweenProperty.Inclusive || betweenProperty == BetweenProperty.RightInclusive) && ts == endTime)
                return true;
            return false;
        }
    }
}
