using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceTrackManagement.Helpers;

namespace ConferenceTrackManagement.Entities
{
    public class NetworkingEvent:IEvent
    {
        public TimeSpan StartTime { get; private set; }

        public TimeSpan EndTime
        {
            get { return StartTime.Add(Duration); }
        }

        public TimeSpan Duration
        {
            get
            {
                return new TimeSpan(1, 0, 0);
            }

        }

        public string EventName
        {
            get
            {
                return "Networking Event";
            }
        }


        public bool SetStartTime(TimeSpan startTime)
        {
            if (!startTime.Between(new TimeSpan(16, 0, 0), new TimeSpan(17, 0, 0), BetweenProperty.Inclusive))
                return false;

            this.StartTime = startTime;
            return true;
        }
    }
}
