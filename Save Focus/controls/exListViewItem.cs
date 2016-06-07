using System.Drawing;
using System.Windows.Forms;

namespace FocusSpy {
    class exListViewItem : ListViewItem {
        // Hilghting
        //
        public bool  Hilight        { get; set; }
        public int   HilightIndex   { get; set; }
        public Color HilightColor   { get; set; }
        public Color HilightColor2  { get; set; }

        // Constructer(s)
        //
        private void customInit() {
            this.Hilight = false;
            this.HilightIndex = 1;
            this.HilightColor = Color.FromArgb(165, 42, 42);
            this.HilightColor2 = Color.FromArgb(80, 114, 167);
        }

        public exListViewItem() {
            this.customInit();
        }

        public exListViewItem(string item) {
            this.customInit();
            base.Text = item;
        }

        public exListViewItem(string item, bool hilight) {
            this.customInit();
            this.Hilight = true;
            base.Text = item;
        }

        public exListViewItem(string item, bool hilight, int HilightIndex) {
            this.customInit();
            this.Hilight = true;
            this.HilightIndex = HilightIndex;
            base.Text = item;
        }
    }
}
