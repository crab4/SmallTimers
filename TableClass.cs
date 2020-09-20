using System;
using System.Collections.Generic;
using System.Text;

namespace TimeBack {
    class TableClass {
        //Name TypeOfAlarm TimeStart TImeEnd Remain
        string m_name;
        string m_timeStart;
        string m_timeEnd;
        string m_remain;
        public string Name { get { return m_name; } }
        public string TimeStart { get { return m_timeStart; } }
        public string TimeEnd { get { return m_timeEnd; } }
        public string Remain { get { return m_remain; } set { m_remain = value; } }
        public TableClass( string name, string timeStart, string timeEnd, string remain) {
            m_name = name;
            m_timeStart = timeStart;
            m_timeEnd = timeEnd;
            m_remain = remain;
            
        }
        
    }
}
