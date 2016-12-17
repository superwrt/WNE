using System;
using System.Windows.Forms;

namespace wne.UI
{
    public partial class EditNameValue : Form
    {
        public string name;
        public string value;
        private bool isSave;

        public EditNameValue()
        {
            InitializeComponent();
        }

        private void EditNameValue_Load(object sender, EventArgs e)
        {
            textBoxName.Text = name;
            textBoxValue.Text = value;
        }

        private void EditNameValue_FormClosing(object sender, FormClosingEventArgs e)
        {
            name = textBoxName.Text;
            value = textBoxValue.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            isSave = true;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ifSave()
        {
            return isSave;
        }
    }
}
