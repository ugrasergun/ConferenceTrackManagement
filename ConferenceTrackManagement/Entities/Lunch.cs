using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement.Entities
{
    public class Lunch:IEvent
    {

        public TimeSpan StartTime
        {
            get
            {
                return new TimeSpan(12, 0, 0);
            }
        }

        public TimeSpan EndTime
        {
            get { return StartTime.Add(Duration); }
        }

        public TimeSpan Duration {
            get
            {
                return new TimeSpan(1, 0, 0);
            }

        }

        public string EventName
        {
            get
            {
                return "Lunch";
            }
        }


       public bool SetStartTime(TimeSpan startTime)
        {
            return true;//FixedStartTime
        }
    }
}
