using System;
using System.Windows.Forms;

namespace SeeSharpTools.JY.GUI
{
    internal partial class StateOperationDialog : Form
    {
        public StateOperationDialog(string stateName)
        {
            InitializeComponent();
            this.StateName = stateName;
            textBox_stateName.Text = stateName;
        }

        public string StateName { get; private set; }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_stateName.Text))
            {
                MessageBox.Show("Illegal state name.", "View Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StateName = textBox_stateName.Text;
            this.Dispose();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
