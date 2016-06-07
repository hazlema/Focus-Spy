using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FocusSpy {
    static class API {
        /// <summary>Returns true if the current application has focus, false otherwise</summary>
        public static bool ApplicationIsActivated(string txtPid) {
            Process pid;

            try {
                pid = Process.GetProcessById(Convert.ToInt32(txtPid));
            } catch {
                return false;
            } finally { }

            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero) {
                return false;       // No window is currently activated
            }

            var procId = pid.Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }

        public static bool Activate(string txtPid) {
            Process pid;

            try {
                pid = Process.GetProcessById(Convert.ToInt32(txtPid));
            } catch { Debug.WriteLine("Error setting focus"); return false; } finally { }

            Debug.WriteLine("Resetting focus");
            SetForegroundWindow((int)pid.MainWindowHandle);
            //SetFocus(pid.MainWindowHandle);

            return true;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetFocus(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);

        //SHELL_WINDOWACTIVATED
    }
}