/*
 * Copyright SuperWRT.com Terra Yang <terra@superwrt.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
