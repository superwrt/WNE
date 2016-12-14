namespace wne.UI
{
    partial class ConfigEnv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlConfigEnv = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.buttonOtherServStopEdit = new System.Windows.Forms.Button();
            this.buttonOtherServStartEdit = new System.Windows.Forms.Button();
            this.checkBoxUseScript = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonEnvValEdit = new System.Windows.Forms.Button();
            this.buttonEnvValDel = new System.Windows.Forms.Button();
            this.buttonEnvValAdd = new System.Windows.Forms.Button();
            this.listViewEnvValues = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageNginx = new System.Windows.Forms.TabPage();
            this.textBoxNginxSiteConf = new System.Windows.Forms.TextBox();
            this.checkBoxUseNginx = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxNginxSite = new System.Windows.Forms.ComboBox();
            this.buttonNginxSiteDel = new System.Windows.Forms.Button();
            this.buttonNginxSiteAdd = new System.Windows.Forms.Button();
            this.tabPagePhp = new System.Windows.Forms.TabPage();
            this.buttonPhpDefConfPro = new System.Windows.Forms.Button();
            this.buttonPhpDefConfDev = new System.Windows.Forms.Button();
            this.comboBoxPhpVersion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxPhpExts = new System.Windows.Forms.CheckedListBox();
            this.numericUpDownPhpProces = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownPhpPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxUsePHP = new System.Windows.Forms.CheckBox();
            this.tabPageMaria = new System.Windows.Forms.TabPage();
            this.textBoxMariaDbBind = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxMariaDbDefCharset = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownMariaDbPort = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxUseMariaDb = new System.Windows.Forms.CheckBox();
            this.tabPageMongoDb = new System.Windows.Forms.TabPage();
            this.textBoxMongoDbBind = new System.Windows.Forms.TextBox();
            this.numericUpDownMongoDbPort = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxUseMongoDb = new System.Windows.Forms.CheckBox();
            this.tabPageRedis = new System.Windows.Forms.TabPage();
            this.textBoxRedisBind = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxRedisLogLevel = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownRedisPort = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxUseRedis = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlConfigEnv.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageNginx.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPagePhp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhpProces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhpPort)).BeginInit();
            this.tabPageMaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMariaDbPort)).BeginInit();
            this.tabPageMongoDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMongoDbPort)).BeginInit();
            this.tabPageRedis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRedisPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlConfigEnv
            // 
            this.tabControlConfigEnv.Controls.Add(this.tabPageGeneral);
            this.tabControlConfigEnv.Controls.Add(this.tabPageNginx);
            this.tabControlConfigEnv.Controls.Add(this.tabPagePhp);
            this.tabControlConfigEnv.Controls.Add(this.tabPageMaria);
            this.tabControlConfigEnv.Controls.Add(this.tabPageMongoDb);
            this.tabControlConfigEnv.Controls.Add(this.tabPageRedis);
            this.tabControlConfigEnv.Location = new System.Drawing.Point(12, 12);
            this.tabControlConfigEnv.Name = "tabControlConfigEnv";
            this.tabControlConfigEnv.SelectedIndex = 0;
            this.tabControlConfigEnv.Size = new System.Drawing.Size(533, 308);
            this.tabControlConfigEnv.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.buttonOtherServStopEdit);
            this.tabPageGeneral.Controls.Add(this.buttonOtherServStartEdit);
            this.tabPageGeneral.Controls.Add(this.checkBoxUseScript);
            this.tabPageGeneral.Controls.Add(this.groupBox2);
            this.tabPageGeneral.Controls.Add(this.label5);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(525, 282);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // buttonOtherServStopEdit
            // 
            this.buttonOtherServStopEdit.Location = new System.Drawing.Point(330, 20);
            this.buttonOtherServStopEdit.Name = "buttonOtherServStopEdit";
            this.buttonOtherServStopEdit.Size = new System.Drawing.Size(90, 23);
            this.buttonOtherServStopEdit.TabIndex = 8;
            this.buttonOtherServStopEdit.Text = "Edit Stop";
            this.buttonOtherServStopEdit.UseVisualStyleBackColor = true;
            this.buttonOtherServStopEdit.Click += new System.EventHandler(this.buttonOtherServStopEdit_Click);
            // 
            // buttonOtherServStartEdit
            // 
            this.buttonOtherServStartEdit.Location = new System.Drawing.Point(223, 20);
            this.buttonOtherServStartEdit.Name = "buttonOtherServStartEdit";
            this.buttonOtherServStartEdit.Size = new System.Drawing.Size(90, 23);
            this.buttonOtherServStartEdit.TabIndex = 7;
            this.buttonOtherServStartEdit.Text = "Edit Start";
            this.buttonOtherServStartEdit.UseVisualStyleBackColor = true;
            this.buttonOtherServStartEdit.Click += new System.EventHandler(this.buttonOtherServStartEdit_Click);
            // 
            // checkBoxUseScript
            // 
            this.checkBoxUseScript.AutoSize = true;
            this.checkBoxUseScript.Location = new System.Drawing.Point(163, 24);
            this.checkBoxUseScript.Name = "checkBoxUseScript";
            this.checkBoxUseScript.Size = new System.Drawing.Size(42, 16);
            this.checkBoxUseScript.TabIndex = 6;
            this.checkBoxUseScript.Text = "Use";
            this.checkBoxUseScript.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonEnvValEdit);
            this.groupBox2.Controls.Add(this.buttonEnvValDel);
            this.groupBox2.Controls.Add(this.buttonEnvValAdd);
            this.groupBox2.Controls.Add(this.listViewEnvValues);
            this.groupBox2.Location = new System.Drawing.Point(6, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 154);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional Environment Value";
            // 
            // buttonEnvValEdit
            // 
            this.buttonEnvValEdit.Location = new System.Drawing.Point(432, 20);
            this.buttonEnvValEdit.Name = "buttonEnvValEdit";
            this.buttonEnvValEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEnvValEdit.TabIndex = 3;
            this.buttonEnvValEdit.Text = "Edit";
            this.buttonEnvValEdit.UseVisualStyleBackColor = true;
            this.buttonEnvValEdit.Click += new System.EventHandler(this.buttonEnvValEdit_Click);
            // 
            // buttonEnvValDel
            // 
            this.buttonEnvValDel.Location = new System.Drawing.Point(432, 90);
            this.buttonEnvValDel.Name = "buttonEnvValDel";
            this.buttonEnvValDel.Size = new System.Drawing.Size(75, 23);
            this.buttonEnvValDel.TabIndex = 2;
            this.buttonEnvValDel.Text = "Delete";
            this.buttonEnvValDel.UseVisualStyleBackColor = true;
            this.buttonEnvValDel.Click += new System.EventHandler(this.buttonEnvValDel_Click);
            // 
            // buttonEnvValAdd
            // 
            this.buttonEnvValAdd.Location = new System.Drawing.Point(432, 60);
            this.buttonEnvValAdd.Name = "buttonEnvValAdd";
            this.buttonEnvValAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonEnvValAdd.TabIndex = 1;
            this.buttonEnvValAdd.Text = "Add";
            this.buttonEnvValAdd.UseVisualStyleBackColor = true;
            this.buttonEnvValAdd.Click += new System.EventHandler(this.buttonEnvValAdd_Click);
            // 
            // listViewEnvValues
            // 
            this.listViewEnvValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewEnvValues.FullRowSelect = true;
            this.listViewEnvValues.GridLines = true;
            this.listViewEnvValues.HideSelection = false;
            this.listViewEnvValues.Location = new System.Drawing.Point(16, 20);
            this.listViewEnvValues.MultiSelect = false;
            this.listViewEnvValues.Name = "listViewEnvValues";
            this.listViewEnvValues.Size = new System.Drawing.Size(410, 128);
            this.listViewEnvValues.TabIndex = 0;
            this.listViewEnvValues.UseCompatibleStateImageBehavior = false;
            this.listViewEnvValues.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 250;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Other Services Script:";
            // 
            // tabPageNginx
            // 
            this.tabPageNginx.Controls.Add(this.textBoxNginxSiteConf);
            this.tabPageNginx.Controls.Add(this.checkBoxUseNginx);
            this.tabPageNginx.Controls.Add(this.groupBox3);
            this.tabPageNginx.Location = new System.Drawing.Point(4, 22);
            this.tabPageNginx.Name = "tabPageNginx";
            this.tabPageNginx.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNginx.Size = new System.Drawing.Size(525, 282);
            this.tabPageNginx.TabIndex = 1;
            this.tabPageNginx.Text = "Nginx";
            this.tabPageNginx.UseVisualStyleBackColor = true;
            // 
            // textBoxNginxSiteConf
            // 
            this.textBoxNginxSiteConf.AcceptsReturn = true;
            this.textBoxNginxSiteConf.AcceptsTab = true;
            this.textBoxNginxSiteConf.Location = new System.Drawing.Point(20, 82);
            this.textBoxNginxSiteConf.MaxLength = 65535;
            this.textBoxNginxSiteConf.Multiline = true;
            this.textBoxNginxSiteConf.Name = "textBoxNginxSiteConf";
            this.textBoxNginxSiteConf.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxNginxSiteConf.Size = new System.Drawing.Size(482, 188);
            this.textBoxNginxSiteConf.TabIndex = 2;
            this.textBoxNginxSiteConf.WordWrap = false;
            // 
            // checkBoxUseNginx
            // 
            this.checkBoxUseNginx.AutoSize = true;
            this.checkBoxUseNginx.Location = new System.Drawing.Point(25, 20);
            this.checkBoxUseNginx.Name = "checkBoxUseNginx";
            this.checkBoxUseNginx.Size = new System.Drawing.Size(78, 16);
            this.checkBoxUseNginx.TabIndex = 0;
            this.checkBoxUseNginx.Text = "Use Nginx";
            this.checkBoxUseNginx.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxNginxSite);
            this.groupBox3.Controls.Add(this.buttonNginxSiteDel);
            this.groupBox3.Controls.Add(this.buttonNginxSiteAdd);
            this.groupBox3.Location = new System.Drawing.Point(6, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 236);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sites";
            // 
            // comboBoxNginxSite
            // 
            this.comboBoxNginxSite.FormattingEnabled = true;
            this.comboBoxNginxSite.Location = new System.Drawing.Point(20, 16);
            this.comboBoxNginxSite.Name = "comboBoxNginxSite";
            this.comboBoxNginxSite.Size = new System.Drawing.Size(185, 20);
            this.comboBoxNginxSite.TabIndex = 1;
            this.comboBoxNginxSite.SelectedIndexChanged += new System.EventHandler(this.comboBoxNginxSite_SelectedIndexChanged);
            this.comboBoxNginxSite.TextUpdate += new System.EventHandler(this.comboBoxNginxSite_TextUpdate);
            // 
            // buttonNginxSiteDel
            // 
            this.buttonNginxSiteDel.Location = new System.Drawing.Point(292, 14);
            this.buttonNginxSiteDel.Name = "buttonNginxSiteDel";
            this.buttonNginxSiteDel.Size = new System.Drawing.Size(75, 23);
            this.buttonNginxSiteDel.TabIndex = 4;
            this.buttonNginxSiteDel.Text = "Delete";
            this.buttonNginxSiteDel.UseVisualStyleBackColor = true;
            this.buttonNginxSiteDel.Click += new System.EventHandler(this.buttonNginxSiteDel_Click);
            // 
            // buttonNginxSiteAdd
            // 
            this.buttonNginxSiteAdd.Location = new System.Drawing.Point(211, 14);
            this.buttonNginxSiteAdd.Name = "buttonNginxSiteAdd";
            this.buttonNginxSiteAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonNginxSiteAdd.TabIndex = 3;
            this.buttonNginxSiteAdd.Text = "Add";
            this.buttonNginxSiteAdd.UseVisualStyleBackColor = true;
            this.buttonNginxSiteAdd.Click += new System.EventHandler(this.buttonNginxSiteAdd_Click);
            // 
            // tabPagePhp
            // 
            this.tabPagePhp.Controls.Add(this.buttonPhpDefConfPro);
            this.tabPagePhp.Controls.Add(this.buttonPhpDefConfDev);
            this.tabPagePhp.Controls.Add(this.comboBoxPhpVersion);
            this.tabPagePhp.Controls.Add(this.label4);
            this.tabPagePhp.Controls.Add(this.groupBox1);
            this.tabPagePhp.Controls.Add(this.numericUpDownPhpProces);
            this.tabPagePhp.Controls.Add(this.label3);
            this.tabPagePhp.Controls.Add(this.numericUpDownPhpPort);
            this.tabPagePhp.Controls.Add(this.label2);
            this.tabPagePhp.Controls.Add(this.checkBoxUsePHP);
            this.tabPagePhp.Location = new System.Drawing.Point(4, 22);
            this.tabPagePhp.Name = "tabPagePhp";
            this.tabPagePhp.Size = new System.Drawing.Size(525, 282);
            this.tabPagePhp.TabIndex = 2;
            this.tabPagePhp.Text = "PHP";
            this.tabPagePhp.UseVisualStyleBackColor = true;
            // 
            // buttonPhpDefConfPro
            // 
            this.buttonPhpDefConfPro.Location = new System.Drawing.Point(25, 230);
            this.buttonPhpDefConfPro.Name = "buttonPhpDefConfPro";
            this.buttonPhpDefConfPro.Size = new System.Drawing.Size(184, 23);
            this.buttonPhpDefConfPro.TabIndex = 13;
            this.buttonPhpDefConfPro.Text = "Default Production Config";
            this.buttonPhpDefConfPro.UseVisualStyleBackColor = true;
            this.buttonPhpDefConfPro.Click += new System.EventHandler(this.buttonPhpDefConfPro_Click);
            // 
            // buttonPhpDefConfDev
            // 
            this.buttonPhpDefConfDev.Location = new System.Drawing.Point(25, 200);
            this.buttonPhpDefConfDev.Name = "buttonPhpDefConfDev";
            this.buttonPhpDefConfDev.Size = new System.Drawing.Size(184, 23);
            this.buttonPhpDefConfDev.TabIndex = 12;
            this.buttonPhpDefConfDev.Text = "Default Development Config";
            this.buttonPhpDefConfDev.UseVisualStyleBackColor = true;
            this.buttonPhpDefConfDev.Click += new System.EventHandler(this.buttonPhpDefConfDev_Click);
            // 
            // comboBoxPhpVersion
            // 
            this.comboBoxPhpVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhpVersion.FormattingEnabled = true;
            this.comboBoxPhpVersion.Location = new System.Drawing.Point(109, 107);
            this.comboBoxPhpVersion.Name = "comboBoxPhpVersion";
            this.comboBoxPhpVersion.Size = new System.Drawing.Size(114, 20);
            this.comboBoxPhpVersion.TabIndex = 11;
            this.comboBoxPhpVersion.SelectedIndexChanged += new System.EventHandler(this.comboBoxPhpVersion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "PHP Version:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBoxPhpExts);
            this.groupBox1.Location = new System.Drawing.Point(230, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 239);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PHP Extensions";
            // 
            // checkedListBoxPhpExts
            // 
            this.checkedListBoxPhpExts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxPhpExts.FormattingEnabled = true;
            this.checkedListBoxPhpExts.Location = new System.Drawing.Point(3, 17);
            this.checkedListBoxPhpExts.Name = "checkedListBoxPhpExts";
            this.checkedListBoxPhpExts.Size = new System.Drawing.Size(280, 219);
            this.checkedListBoxPhpExts.TabIndex = 0;
            // 
            // numericUpDownPhpProces
            // 
            this.numericUpDownPhpProces.Location = new System.Drawing.Point(158, 78);
            this.numericUpDownPhpProces.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPhpProces.Name = "numericUpDownPhpProces";
            this.numericUpDownPhpProces.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownPhpProces.TabIndex = 8;
            this.numericUpDownPhpProces.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "FastCGI Processes:";
            // 
            // numericUpDownPhpPort
            // 
            this.numericUpDownPhpPort.Location = new System.Drawing.Point(158, 48);
            this.numericUpDownPhpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPhpPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPhpPort.Name = "numericUpDownPhpPort";
            this.numericUpDownPhpPort.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownPhpPort.TabIndex = 6;
            this.numericUpDownPhpPort.Value = new decimal(new int[] {
            9001,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "FastCGI Port:";
            // 
            // checkBoxUsePHP
            // 
            this.checkBoxUsePHP.AutoSize = true;
            this.checkBoxUsePHP.Location = new System.Drawing.Point(25, 20);
            this.checkBoxUsePHP.Name = "checkBoxUsePHP";
            this.checkBoxUsePHP.Size = new System.Drawing.Size(66, 16);
            this.checkBoxUsePHP.TabIndex = 0;
            this.checkBoxUsePHP.Text = "Use PHP";
            this.checkBoxUsePHP.UseVisualStyleBackColor = true;
            // 
            // tabPageMaria
            // 
            this.tabPageMaria.Controls.Add(this.textBoxMariaDbBind);
            this.tabPageMaria.Controls.Add(this.label13);
            this.tabPageMaria.Controls.Add(this.comboBoxMariaDbDefCharset);
            this.tabPageMaria.Controls.Add(this.label7);
            this.tabPageMaria.Controls.Add(this.numericUpDownMariaDbPort);
            this.tabPageMaria.Controls.Add(this.label6);
            this.tabPageMaria.Controls.Add(this.checkBoxUseMariaDb);
            this.tabPageMaria.Location = new System.Drawing.Point(4, 22);
            this.tabPageMaria.Name = "tabPageMaria";
            this.tabPageMaria.Size = new System.Drawing.Size(525, 282);
            this.tabPageMaria.TabIndex = 3;
            this.tabPageMaria.Text = "MariaDB";
            this.tabPageMaria.UseVisualStyleBackColor = true;
            // 
            // textBoxMariaDbBind
            // 
            this.textBoxMariaDbBind.Location = new System.Drawing.Point(109, 49);
            this.textBoxMariaDbBind.Name = "textBoxMariaDbBind";
            this.textBoxMariaDbBind.Size = new System.Drawing.Size(114, 21);
            this.textBoxMariaDbBind.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "Bind Address:";
            // 
            // comboBoxMariaDbDefCharset
            // 
            this.comboBoxMariaDbDefCharset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMariaDbDefCharset.FormattingEnabled = true;
            this.comboBoxMariaDbDefCharset.Items.AddRange(new object[] {
            "utf8",
            "gb2312",
            "gbk",
            "big5",
            "cp1250",
            "cp1251",
            "cp1256",
            "cp1257",
            "greek",
            "hebrew",
            "koi8r",
            "koi8u",
            "latin1",
            "latin2",
            "latin5",
            "latin7"});
            this.comboBoxMariaDbDefCharset.Location = new System.Drawing.Point(158, 107);
            this.comboBoxMariaDbDefCharset.Name = "comboBoxMariaDbDefCharset";
            this.comboBoxMariaDbDefCharset.Size = new System.Drawing.Size(65, 20);
            this.comboBoxMariaDbDefCharset.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Default Character set:";
            // 
            // numericUpDownMariaDbPort
            // 
            this.numericUpDownMariaDbPort.Location = new System.Drawing.Point(158, 78);
            this.numericUpDownMariaDbPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownMariaDbPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMariaDbPort.Name = "numericUpDownMariaDbPort";
            this.numericUpDownMariaDbPort.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownMariaDbPort.TabIndex = 2;
            this.numericUpDownMariaDbPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Port:";
            // 
            // checkBoxUseMariaDb
            // 
            this.checkBoxUseMariaDb.AutoSize = true;
            this.checkBoxUseMariaDb.Location = new System.Drawing.Point(25, 20);
            this.checkBoxUseMariaDb.Name = "checkBoxUseMariaDb";
            this.checkBoxUseMariaDb.Size = new System.Drawing.Size(90, 16);
            this.checkBoxUseMariaDb.TabIndex = 0;
            this.checkBoxUseMariaDb.Text = "Use MariaDB";
            this.checkBoxUseMariaDb.UseVisualStyleBackColor = true;
            // 
            // tabPageMongoDb
            // 
            this.tabPageMongoDb.Controls.Add(this.textBoxMongoDbBind);
            this.tabPageMongoDb.Controls.Add(this.numericUpDownMongoDbPort);
            this.tabPageMongoDb.Controls.Add(this.label10);
            this.tabPageMongoDb.Controls.Add(this.label9);
            this.tabPageMongoDb.Controls.Add(this.checkBoxUseMongoDb);
            this.tabPageMongoDb.Location = new System.Drawing.Point(4, 22);
            this.tabPageMongoDb.Name = "tabPageMongoDb";
            this.tabPageMongoDb.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMongoDb.Size = new System.Drawing.Size(525, 282);
            this.tabPageMongoDb.TabIndex = 5;
            this.tabPageMongoDb.Text = "MongoDB";
            this.tabPageMongoDb.UseVisualStyleBackColor = true;
            // 
            // textBoxMongoDbBind
            // 
            this.textBoxMongoDbBind.Location = new System.Drawing.Point(109, 47);
            this.textBoxMongoDbBind.Name = "textBoxMongoDbBind";
            this.textBoxMongoDbBind.Size = new System.Drawing.Size(114, 21);
            this.textBoxMongoDbBind.TabIndex = 6;
            // 
            // numericUpDownMongoDbPort
            // 
            this.numericUpDownMongoDbPort.Location = new System.Drawing.Point(158, 78);
            this.numericUpDownMongoDbPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownMongoDbPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMongoDbPort.Name = "numericUpDownMongoDbPort";
            this.numericUpDownMongoDbPort.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownMongoDbPort.TabIndex = 5;
            this.numericUpDownMongoDbPort.Value = new decimal(new int[] {
            27017,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "Bind Address:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Port:";
            // 
            // checkBoxUseMongoDb
            // 
            this.checkBoxUseMongoDb.AutoSize = true;
            this.checkBoxUseMongoDb.Location = new System.Drawing.Point(25, 20);
            this.checkBoxUseMongoDb.Name = "checkBoxUseMongoDb";
            this.checkBoxUseMongoDb.Size = new System.Drawing.Size(90, 16);
            this.checkBoxUseMongoDb.TabIndex = 0;
            this.checkBoxUseMongoDb.Text = "Use MongoDB";
            this.checkBoxUseMongoDb.UseVisualStyleBackColor = true;
            // 
            // tabPageRedis
            // 
            this.tabPageRedis.Controls.Add(this.textBoxRedisBind);
            this.tabPageRedis.Controls.Add(this.label14);
            this.tabPageRedis.Controls.Add(this.comboBoxRedisLogLevel);
            this.tabPageRedis.Controls.Add(this.label12);
            this.tabPageRedis.Controls.Add(this.numericUpDownRedisPort);
            this.tabPageRedis.Controls.Add(this.label11);
            this.tabPageRedis.Controls.Add(this.checkBoxUseRedis);
            this.tabPageRedis.Location = new System.Drawing.Point(4, 22);
            this.tabPageRedis.Name = "tabPageRedis";
            this.tabPageRedis.Size = new System.Drawing.Size(525, 282);
            this.tabPageRedis.TabIndex = 4;
            this.tabPageRedis.Text = "Redis";
            this.tabPageRedis.UseVisualStyleBackColor = true;
            // 
            // textBoxRedisBind
            // 
            this.textBoxRedisBind.Location = new System.Drawing.Point(109, 47);
            this.textBoxRedisBind.Name = "textBoxRedisBind";
            this.textBoxRedisBind.Size = new System.Drawing.Size(114, 21);
            this.textBoxRedisBind.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 10;
            this.label14.Text = "Bind Address:";
            // 
            // comboBoxRedisLogLevel
            // 
            this.comboBoxRedisLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRedisLogLevel.FormattingEnabled = true;
            this.comboBoxRedisLogLevel.Items.AddRange(new object[] {
            "debug",
            "verbose",
            "notice",
            "warning"});
            this.comboBoxRedisLogLevel.Location = new System.Drawing.Point(158, 107);
            this.comboBoxRedisLogLevel.Name = "comboBoxRedisLogLevel";
            this.comboBoxRedisLogLevel.Size = new System.Drawing.Size(65, 20);
            this.comboBoxRedisLogLevel.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "Log Level:";
            // 
            // numericUpDownRedisPort
            // 
            this.numericUpDownRedisPort.Location = new System.Drawing.Point(158, 78);
            this.numericUpDownRedisPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownRedisPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRedisPort.Name = "numericUpDownRedisPort";
            this.numericUpDownRedisPort.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownRedisPort.TabIndex = 7;
            this.numericUpDownRedisPort.Value = new decimal(new int[] {
            6379,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "Port:";
            // 
            // checkBoxUseRedis
            // 
            this.checkBoxUseRedis.AutoSize = true;
            this.checkBoxUseRedis.Location = new System.Drawing.Point(25, 20);
            this.checkBoxUseRedis.Name = "checkBoxUseRedis";
            this.checkBoxUseRedis.Size = new System.Drawing.Size(78, 16);
            this.checkBoxUseRedis.TabIndex = 0;
            this.checkBoxUseRedis.Text = "Use Redis";
            this.checkBoxUseRedis.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(346, 322);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(457, 322);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ConfigEnv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 353);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.tabControlConfigEnv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConfigEnv";
            this.Text = "ConfigEnv";
            this.Load += new System.EventHandler(this.ConfigEnv_Load);
            this.tabControlConfigEnv.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPageNginx.ResumeLayout(false);
            this.tabPageNginx.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPagePhp.ResumeLayout(false);
            this.tabPagePhp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhpProces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhpPort)).EndInit();
            this.tabPageMaria.ResumeLayout(false);
            this.tabPageMaria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMariaDbPort)).EndInit();
            this.tabPageMongoDb.ResumeLayout(false);
            this.tabPageMongoDb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMongoDbPort)).EndInit();
            this.tabPageRedis.ResumeLayout(false);
            this.tabPageRedis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRedisPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlConfigEnv;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageNginx;
        private System.Windows.Forms.TabPage tabPagePhp;
        private System.Windows.Forms.TabPage tabPageMaria;
        private System.Windows.Forms.TabPage tabPageRedis;
        private System.Windows.Forms.CheckBox checkBoxUseNginx;
        private System.Windows.Forms.CheckBox checkBoxUsePHP;
        private System.Windows.Forms.CheckBox checkBoxUseMariaDb;
        private System.Windows.Forms.CheckBox checkBoxUseRedis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownPhpProces;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownPhpPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxPhpExts;
        private System.Windows.Forms.ComboBox comboBoxPhpVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPhpDefConfPro;
        private System.Windows.Forms.Button buttonPhpDefConfDev;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPageMongoDb;
        private System.Windows.Forms.CheckBox checkBoxUseMongoDb;
        private System.Windows.Forms.Button buttonNginxSiteDel;
        private System.Windows.Forms.Button buttonNginxSiteAdd;
        private System.Windows.Forms.ComboBox comboBoxNginxSite;
        private System.Windows.Forms.TextBox textBoxNginxSiteConf;
        private System.Windows.Forms.ComboBox comboBoxMariaDbDefCharset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownMariaDbPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownMongoDbPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxRedisLogLevel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownRedisPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonEnvValEdit;
        private System.Windows.Forms.Button buttonEnvValDel;
        private System.Windows.Forms.Button buttonEnvValAdd;
        private System.Windows.Forms.ListView listViewEnvValues;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxUseScript;
        private System.Windows.Forms.Button buttonOtherServStopEdit;
        private System.Windows.Forms.Button buttonOtherServStartEdit;
        private System.Windows.Forms.TextBox textBoxMariaDbBind;
        private System.Windows.Forms.TextBox textBoxMongoDbBind;
        private System.Windows.Forms.TextBox textBoxRedisBind;
    }
}