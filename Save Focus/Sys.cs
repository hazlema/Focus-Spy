using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusSpy {

    public class SimpleProcs {
        public string Name { get; set;  }
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
    }
}
