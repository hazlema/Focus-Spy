using System;
using System.Drawing;
using System.Windows.Forms;

namespace FocusSpy
{
    public partial class Log : Form {
        public Log() {
            InitializeComponent();
        }

        public void add(string dest, string src) {
            exListViewItem lv = new exListViewItem(DateTime.Now.ToShortDateString() + ": " + DateTime.Now.ToShortTimeString());
            lv.SubItems.Add(dest);
            lv.SubItems.Add(src);
            LogView.Items.Add(lv);

            LogView.ClearHilights();
            LogView.ToggleHilight("Focus Attack", false, 1, 2);
            LogView.ToggleHilight("Reset Focus", false, 2, 2);
            LogView.ToggleHilight("Forced Focus", false, 2, 2);
            LogView.ToggleHilight("Forced Kill", false, 2, 2);

            lv.EnsureVisible();
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e) {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
