using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _134KO
{
    public class ProcessItem
    {
        String processName;
        String windowName;
        int processID;

        public String WindowName
        {
            get { return windowName; }
            set { windowName = value; }
        }

        public int ProcessID
        {
            get { return processID; }
            set { processID = value; }
        }

        public String ProcessName
        {
            get { return processName; }
            set { processName = value; }
        }
    }
}
