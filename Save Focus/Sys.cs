using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusSpy {

    public class SimpleProcs {
        public string Name { get; set; }
        public int id { get; set; }
        public string idStr {
            set { this.id = Convert.ToInt32(value); }
            get { return this.id.ToString(); }
        }


        public SimpleProcs() { }

        public SimpleProcs(string Name, string ID) {
            this.Name = Name;
            this.id = Convert.ToInt32(ID);
        }

        public SimpleProcs(string Name, int ID) {
            this.Name = Name;
            this.id = ID;
        }
    }

    public static class Sys {

        public static List<SimpleProcs> GellAll() {
            List<SimpleProcs> tmp = new List<SimpleProcs>();

            foreach (Process p in Process.GetProcesses()) {
                tmp.Add(new SimpleProcs(p.ProcessName, p.Id));
            }

            return tmp;
        }

        public static string GetNameById(int pid) {
            string result = "Undefined";

            try { result = Process.GetProcessById(pid).ProcessName; } catch { }
            return result;
        }
        public static string GetNameById(string pidStr) {
            return GetNameById(Convert.ToInt32(pidStr));
        }


        public static bool isStartup() {
            RegistryKey rk;
            bool found = false;

            rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);

            foreach (string key in rk.GetValueNames()) {
                if (key.ToUpper() == "Focus Spy".ToUpper())
                    found = true;
            }

            return found;
        }

        public static void setStartup(bool on) {
            string path = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            string found = "";

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            foreach (string key in rk.GetValueNames()) {
                if (key.ToUpper() == "Focus Spy".ToUpper()) 
                    found = key;
            }

            if (on) {
                rk.SetValue("Focus Spy", "\"" + path + "\\Focus Spy.exe\" -min");
            } else {
                if (found != "")
                    rk.DeleteValue(found, false);
            }
        }
    }
}
