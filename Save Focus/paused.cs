using System;
using System.Windows.Forms;

namespace FocusSpy {
    public partial class paused : Form {
        public paused() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
