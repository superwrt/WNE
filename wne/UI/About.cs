using System;
using System.Windows.Forms;

namespace wne.UI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            labelVersion.Text = Application.ProductVersion.ToString();
        }
    }
}
