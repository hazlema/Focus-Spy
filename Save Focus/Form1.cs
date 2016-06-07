using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FocusSpy {

    public partial class Form1 : Form {

        bool isAttack = false;
        int attacks  = 0;          // Number of attacts detected
        Log logger   = new Log();  // Log Viewer
        WatchedList Watched   = new WatchedList();
        SimpleProcs lastFocus = new SimpleProcs("Idle", 0);

        public Form1() {
            logger.Visible = false;
            InitializeComponent();
        }

        // Form & Notification
        private void Form1_Load(object sender, EventArgs e) {
            Watched.Load();
            lvProcs.ListViewItemSorter = new ListViewItemComparer(2, 0); // Set Sort Method
        }
        private void notifyIcon1_Click(object sender, EventArgs e) {
            notifyIcon1.Visible = false;
            this.Show();
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void Form1_Resize(object sender, EventArgs e) {
            if (FormWindowState.Minimized == this.WindowState) {
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "Focus Spy Minimized";
                notifyIcon1.Text = "Focus Spy";
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            } else if (FormWindowState.Normal == this.WindowState) {
                notifyIcon1.Visible = false;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            
            notifyIcon1.Dispose();
        }

        // Main Guts
        private void TimerTick(object sender, EventArgs e) {
            List<SimpleProcs> processes = Sys.GellAll();

            #region Update Listview
            // Set all listitem items tags to false
            foreach (ListViewItem lv in lvProcs.Items) lv.Tag = "false";

            // Add Any New Items and set tag to true
            foreach (SimpleProcs thisProc in processes) {

                if (!lvProcs.Items.ContainsKey(thisProc.idStr)) {
                    Debug.Write("+");

                    exListViewItem lv = new exListViewItem(thisProc.Name);
                    lv.ImageIndex = 0;
                    lv.Name = thisProc.idStr;
                    lv.Tag = "true";

                    lv.SubItems.Add(thisProc.idStr);

                    if (Watched.Contains(lv.Text))
                        lv.ImageIndex = 2;
                    else {
                        lv.ImageIndex = 1;
                        lv.Hilight = false;
                    }

                    lvProcs.Items.Add(lv);
                } else { // Existing item, set tag to true
                    exListViewItem tmp = (exListViewItem)lvProcs.Items[lvProcs.Items.IndexOfKey(thisProc.idStr)];

                    Debug.Write("=");

                    tmp.Tag = "true";
                    if (Watched.Contains(tmp.Text))
                        tmp.ImageIndex = 2;
                    else {
                        tmp.ImageIndex = 0;
                        tmp.Hilight = false;
                    }
                }
            }

            // Remove items with a tag value of false
            foreach (ListViewItem lv in lvProcs.Items) {
                if (lv.Tag.ToString() == "false") {
                    Debug.Write("-");
                    lvProcs.Items.Remove(lv);
                }
            }
            Debug.WriteLine("");
            #endregion

            #region Focus shift detection (Update List)
            foreach (exListViewItem lv in lvProcs.Items) {
                SimpleProcs thisItem = new SimpleProcs(lv.Text, lv.Name);

                // Check if the window has focus
                if (API.ApplicationIsActivated(thisItem.idStr)) {

                    // Watched pross switch
                    if (Watched.Contains(thisItem.Name)) {
                        attacks++;
                        sbAttacks.Text = "Focus Attacks: " + attacks;

                        API.Activate(lastFocus.idStr);

                        if (!isAttack) {
                            logger.add(thisItem.Name + " (" + thisItem.id + ")", "Focus Attack");
                            logger.add(lastFocus.Name + " (" + lastFocus.id + ")", "Reset Focus");
                            isAttack = true;
                        } else
                            logger.add(lastFocus.Name + " (" + lastFocus.id + ")", "Retrying Focus");

                    } else { // Normal pross switch
                        isAttack = false;

                        if (thisItem.id != lastFocus.id)
                            logger.add(thisItem.Name + " (" + thisItem.id + ")", lastFocus.Name + " (" + lastFocus.idStr + ")");

                        // Set normal focused process
                        lv.ImageIndex = 1;
                        lv.ToolTipText = "Active";
                        lv.Hilight = true;
                        lastFocus.Name = lv.Text;
                        lastFocus.idStr = lv.Name;

                        if (mnuScroll.Checked) lv.EnsureVisible();
                    }
                } else { // Reset appearance, Not focused

                    if (lv.ImageIndex == 2) {
                        lv.Hilight = true;
                        lv.HilightIndex = 2;
                    }

                    if (lv.ImageIndex == 1) {
                        lv.ImageIndex = 0;
                        lv.Hilight = false;
                    }
                }
                sbProcesses.Text = "Processes: " + lvProcs.Items.Count;
            }
            #endregion

        }

        // Pause
        private void processList_DoubleClick(object sender, EventArgs e) {
            processesUpdateTimer.Enabled = false;

            if (new paused().ShowDialog(this) == DialogResult.OK)
                processesUpdateTimer.Enabled = true;
        }

        // Toggle Auto scroll
        private void menuScroll(object sender, EventArgs e) {
            mnuScroll.Checked = !mnuScroll.Checked;
        }

        // Toggle Stay on Top
        private void menuTop(object sender, EventArgs e) {
            mnuTop.Checked = !mnuTop.Checked;
            this.TopMost = mnuTop.Checked;
        }

        // Help Menu
        private void menuHelp(object sender, EventArgs e) {
            Form frm = new AboutBox1();
            frm.ShowDialog(this);
        }

        // Log View
        private void menuLog(object sender, EventArgs e) {
            logger.Visible = true;
        }

        // Context: Force Focus a Process
        private void ctxFocus(object sender, EventArgs e) {
            ListViewItem thisObj = lvProcs.SelectedItems[0];
            logger.add($"{thisObj.Text} ({thisObj.Name})", "Forced Focus");

            try {
                API.Activate(thisObj.SubItems[1].Text);
            } catch {
                MessageBox.Show($"An error occured focusing {thisObj.SubItems[1].Text}. Not every process is focusable", "Focus Spy Error");
            }
        }

        // Context: Kill Process
        private void ctxKill(object sender, EventArgs e) {
            ListViewItem thisObj = lvProcs.SelectedItems[0];
            logger.add($"{thisObj.Text} ({thisObj.Name})", "Forced Kill");

            try {
                Process tmp = Process.GetProcessById(Convert.ToInt32(thisObj.SubItems[1].Text));
                tmp.Kill();
            } catch {
                MessageBox.Show($"An error occured focusing {thisObj.SubItems[1].Text}. Not every process can be killed", "Focus Spy Error");
            }
        }

        // Context: Add a watched process
        private void ctxAddWatch(object sender, EventArgs e) {
            ListViewItem thisObj = lvProcs.SelectedItems[0];
            if (Watched.Contains(thisObj.Text))
                Watched.Remove(thisObj.Text);
            else
                Watched.Add(thisObj.Text);

            Watched.save();
        }

        // Sorting
        private void processList_ColumnClick(object sender, ColumnClickEventArgs e) {
            int sortModifer = 0;

            if (lvProcs.Sorting == SortOrder.Ascending) {
                lvProcs.Sorting = SortOrder.Descending;
                sortModifer = 0;
            } else {
                lvProcs.Sorting = SortOrder.Ascending;
                sortModifer = 1;
            }

            lvProcs.ListViewItemSorter = new ListViewItemComparer(e.Column, sortModifer);
            lvProcs.Sort();
        }

    }

    // Sorting Comparer
    internal class ListViewItemComparer : IComparer {
        private int column;
        private int sortModifer;

        public ListViewItemComparer(int column, int sortModifer) {
            this.column = column;
            this.sortModifer = sortModifer;
        }

        public int Compare(object x, object y) {
            ListViewItem src = (ListViewItem)x;
            ListViewItem dst = (ListViewItem)y;

            if (column == 0) {
                if (String.Compare(src.Text, dst.Text) >= 0)
                    return 1 - sortModifer;
            }

            if (column == 1) {
                int srcInt = Convert.ToInt32(src.SubItems[1].Text);
                int dstInt = Convert.ToInt32(dst.SubItems[1].Text);

                if (srcInt > dstInt)
                    return 1 - sortModifer;
            }

            return 0 + sortModifer;
        }
    }
}
