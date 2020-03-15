using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizButtonDesktop
{
    class ProcessHelper
    {
        const UInt32 WM_KEYDOWN = 0x0100;
        const int VK_PRIOR = 0x21;
        const int VK_NEXT = 0x22;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        public static bool FocusPowerpoint()
        {
            return BringToFront("POWERPNT");
        }

        public static bool BringToFront(string processName)
        {
            // get the process
            Process bProcess = Process.GetProcessesByName(processName).FirstOrDefault();

            // check if the process is running
            if (bProcess != null)
            {
                // check if the window is hidden / minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    // the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.Restore);
                }

                // set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
                return true;
            }
            return false;
        }

        public static void PowerPointKeystroke(int key)
        {
            Process powerpoint = Process.GetProcessesByName("POWERPNT").FirstOrDefault();
            
            PostMessage(powerpoint.MainWindowHandle, WM_KEYDOWN, key, 0);
        }

        public static void PowerPointNext()
        {
            PowerPointKeystroke(VK_NEXT);
        }

        public static void PowerPointPrevious()
        {
            PowerPointKeystroke(VK_PRIOR);
        }
    }
}
