using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceTrackManagement.Entities
{
    public interface IEvent
    {
        TimeSpan StartTime { get; }
        TimeSpan EndTime { get; }
        TimeSpan Duration { get;  }
        string EventName { get;  }
        bool SetStartTime(TimeSpan startTime);
    }
}
