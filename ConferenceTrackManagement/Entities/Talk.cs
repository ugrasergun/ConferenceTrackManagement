using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceTrackManagement.Helpers;

namespace ConferenceTrackManagement.Entities
{
    public class Talk:IEvent
    {
        public Talk(string EventInfo)
        {
            int duration;
            if (EventInfo.EndsWith("lightning"))
            {
                duration = 5;
            }
            else
            {
                duration = int.Parse(EventInfo.Substring(EventInfo.Length - 5, 2));
            }
            Duration = new TimeSpan(0,duration,0);
            EventName = EventInfo.Substring(0, EventInfo.Length - 6);

        }
        
        public TimeSpan StartTime{ get; private set; }

        public TimeSpan EndTime { get; private set; }

        public TimeSpan Duration { get; private set; }


        public string EventName { get; private set; }



        public bool SetStartTime(TimeSpan startTime)
        {
            if (startTime < new TimeSpan(9, 0, 0) || startTime.Between(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0), BetweenProperty.LeftInclusive))
                return false;
            if (!SetEndTime(startTime))
                return false;
            this.StartTime = startTime;
            return true;
        }

        private bool SetEndTime(TimeSpan startTime)
        {
            TimeSpan endTime = startTime + Duration;
            if (endTime.Between(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0), BetweenProperty.RightInclusive) || endTime >= new TimeSpan(17, 0, 0))
                return false;
            this.EndTime = endTime;
            return true;
        }
    }
}
