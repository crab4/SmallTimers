using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace TimeBack {
    class DoomTimer {
        public DateTime m_endingTime;
        public DateTime m_startTime;
        public DoomTimer(TimeSpan timeEnd) {
            m_endingTime = DateTime.Now.Add(timeEnd);
            m_startTime = DateTime.Now;
        }
        //Constructor for restore Timer, if programm was ending
        public DoomTimer(TimeSpan timeEnd, DateTime timeStart){
            m_endingTime = timeStart.Add(timeEnd);
            m_startTime = new DateTime(timeStart.Ticks);
        }
        public TimeSpan RemainTime() {
            if (DateTime.Now > m_endingTime)
                return new TimeSpan(0);
            else
                return m_endingTime.Subtract(DateTime.Now);
        }
    }
}
