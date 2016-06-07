using System.Drawing;
using System.Windows.Forms;

namespace FocusSpy {
    class exListView : ListView
    {
        public Color AltColor { get; set; }

        // Constructer
        //
        public exListView() {
            this.AltColor = Color.FromArgb(64, 64, 64);
            this.OwnerDraw = true;

            this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this.exDrawColumnHeader);
            this.DrawItem += new DrawListViewItemEventHandler(this.exDrawItem);
        }

        // Un-Hilight Everything.
        //
        public void ClearHilights() {
            foreach (exListViewItem item in this.Items)
                item.Hilight = false;

            this.Invalidate();
        }

        // Set an items hilight
        //
        public void ToggleHilight(int Line) {
            ((exListViewItem)this.Items[Line]).Hilight = !((exListViewItem)this.Items[Line]).Hilight;

            this.Invalidate();
        }

        public void ToggleHilight(int Line, bool value) {
            ((exListViewItem)this.Items[Line]).Hilight = value;

            this.Invalidate();
        }

        public void ToggleHilight(string match, bool isPartial) {
            foreach (exListViewItem item in this.Items) {
                if (isPartial) {
                    if (item.Text.ToUpper().Contains(match.ToUpper()))
                        item.Hilight = true;
                } else {
                    if (item.Text.ToUpper() == match.ToUpper())
                        item.Hilight = true;
                }
            }

            this.Invalidate();
        }

        public void ToggleHilight(string match, bool isPartial, int HilightIndex, int subitemNdx) {
            foreach (exListViewItem item in this.Items) {
                if (isPartial) {
                    if (item.SubItems[subitemNdx].Text.ToUpper().Contains(match.ToUpper())) {
                        item.Hilight = true;
                        item.HilightIndex = HilightIndex;
                    }
                } else {
                    if (item.SubItems[subitemNdx].Text.ToUpper() == match.ToUpper()) {
                        item.Hilight = true;
                        item.HilightIndex = HilightIndex;
                    }
                }
            }

            this.Invalidate();
        }

        public void ToggleHilight(string match, bool isPartial, int subitemNdx) {
            foreach (exListViewItem item in this.Items) {
                if (isPartial) {
                    if (item.SubItems[subitemNdx].Text.ToUpper().Contains(match.ToUpper()))
                        item.Hilight = true;
                } else {
                    if (item.SubItems[subitemNdx].Text.ToUpper() == match.ToUpper())
                        item.Hilight = true;
                }
            }

            this.Invalidate();
        }

        // Custom Drawing
        //
        public void exDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;

            if (((exListViewItem)e.Item).Hilight) {
                if (((exListViewItem)e.Item).HilightIndex == 1)
                    e.Item.BackColor = ((exListViewItem)e.Item).HilightColor;
                else
                    e.Item.BackColor = ((exListViewItem)e.Item).HilightColor2;
            } else {
                e.Item.BackColor = e.ItemIndex % 2 == 1 ? this.AltColor : this.BackColor;
            }

            e.Item.UseItemStyleForSubItems = true;
        }

        public void exDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat format = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        format.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        format.Alignment = StringAlignment.Far;
                        break;
                }

                //format.FormatFlags = StringFormatFlags.
                // Draw the standard header background.
                e.DrawBackground();
                e.DrawText(TextFormatFlags.VerticalCenter);
            }
        }
    }
}
