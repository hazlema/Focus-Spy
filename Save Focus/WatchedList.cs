using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace FocusSpy {
    public class WatchedList : List<string> {
        public WatchedList() {
        }

        public void save() {
            string output = string.Join(",", this);

            RegistryKey key;
            key = Registry.CurrentUser.CreateSubKey("FocusSpy");
            key.SetValue("Watched", output);
            key.Close();
        }

        public void Load() {
            RegistryKey key;

            try {
                key = Registry.CurrentUser.OpenSubKey("FocusSpy");
                string output = key.GetValue("Watched").ToString();
                key.Close();

                foreach (string elements in output.Split(',')) {
                    this.Add(elements);
                }
            } catch {
            } 

        }
    }
}