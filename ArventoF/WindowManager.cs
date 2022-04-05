using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace _134KO
{
    public class WindowManager
    {
        public static int GetWindowProcessIDByWindowName(String windowName)
        {
            int processID = -1;
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.IndexOf(windowName, StringComparison.InvariantCulture) > -1)
                {
                    processID = process.Id;
                    break;
                }
            }
            return processID;
        }

        public static void SetWindowNameByProcessID(int processID, String windowName)
        {
            Process process = Process.GetProcessById(processID);
            Win32.SetWindowText(process.MainWindowHandle, windowName);
        }

        public static IntPtr GetProcessHandle(int processID)
        {
            Process process = Process.GetProcessById(processID);
            return process.MainWindowHandle;
        }

        public static List<ProcessItem> GetWindows()
        {
            List<ProcessItem> processes = new List<ProcessItem>();
            foreach (Process proc in Process.GetProcesses())
            {
                if (!String.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    processes.Add(new ProcessItem() { ProcessName = (proc.Id + " - " + proc.MainWindowTitle), ProcessID = proc.Id, WindowName = proc.MainWindowTitle });
                }
            }
            return processes;
        }
    }
}
