namespace VTP_Tet
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_imei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_vtm = new System.Windows.Forms.DataGridView();
            this.btn_loadData = new System.Windows.Forms.Button();
            this.btn_checkIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_2 = new System.Windows.Forms.Label();
            this.nm_thread = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_getListItems = new System.Windows.Forms.Button();
            this.btn_sendAllGift = new System.Windows.Forms.Button();
            this.tb_sdtgift = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_offset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_combo99k = new System.Windows.Forms.CheckBox();
            this.cb_combo9k = new System.Windows.Forms.CheckBox();
            this.cb_combo999d = new System.Windows.Forms.CheckBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_openGifts = new System.Windows.Forms.Button();
            this.cb_allCombo = new System.Windows.Forms.CheckBox();
            this.rb_all = new System.Windows.Forms.RadioButton();
            this.rb_single = new System.Windows.Forms.RadioButton();
            this.rb_selectcombo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_selectBlacklist = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.nmr_delay = new System.Windows.Forms.NumericUpDown();
            this.btn_changeIP = new System.Windows.Forms.Button();
            this.tb_proxyKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_vtm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_thread)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_delay)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // col_status
            // 
            this.col_status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_status.DataPropertyName = "status";
            this.col_status.HeaderText = "Trạng thái";
            this.col_status.Name = "col_status";
            // 
            // col_token
            // 
            this.col_token.DataPropertyName = "session";
            this.col_token.HeaderText = "Token";
            this.col_token.Name = "col_token";
            // 
            // col_imei
            // 
            this.col_imei.DataPropertyName = "imei";
            this.col_imei.HeaderText = "Imei";
            this.col_imei.Name = "col_imei";
            // 
            // col_username
            // 
            this.col_username.DataPropertyName = "username";
            this.col_username.HeaderText = "SĐT";
            this.col_username.Name = "col_username";
            // 
            // col_stt
            // 
            this.col_stt.DataPropertyName = "id";
            this.col_stt.HeaderText = "STT";
            this.col_stt.Name = "col_stt";
            this.col_stt.Width = 50;
            // 
            // dtg_vtm
            // 
            this.dtg_vtm.AllowUserToAddRows = false;
            this.dtg_vtm.AllowUserToResizeColumns = false;
            this.dtg_vtm.AllowUserToResizeRows = false;
            this.dtg_vtm.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtg_vtm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_vtm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_stt,
            this.col_username,
            this.col_imei,
            this.col_token,
            this.col_status});
            this.dtg_vtm.Location = new System.Drawing.Point(6, 21);
            this.dtg_vtm.Name = "dtg_vtm";
            this.dtg_vtm.RowHeadersVisible = false;
            this.dtg_vtm.Size = new System.Drawing.Size(943, 724);
            this.dtg_vtm.TabIndex = 0;
            // 
            // btn_loadData
            // 
            this.btn_loadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_loadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loadData.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadData.ForeColor = System.Drawing.Color.White;
            this.btn_loadData.Location = new System.Drawing.Point(6, 66);
            this.btn_loadData.Name = "btn_loadData";
            this.btn_loadData.Size = new System.Drawing.Size(180, 40);
            this.btn_loadData.TabIndex = 1;
            this.btn_loadData.Text = "Load database";
            this.btn_loadData.UseVisualStyleBackColor = false;
            this.btn_loadData.Click += new System.EventHandler(this.btn_loadData_Click);
            // 
            // btn_checkIn
            // 
            this.btn_checkIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_checkIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_checkIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkIn.ForeColor = System.Drawing.Color.White;
            this.btn_checkIn.Location = new System.Drawing.Point(6, 21);
            this.btn_checkIn.Name = "btn_checkIn";
            this.btn_checkIn.Size = new System.Drawing.Size(403, 40);
            this.btn_checkIn.TabIndex = 2;
            this.btn_checkIn.Text = "Điểm danh";
            this.btn_checkIn.UseVisualStyleBackColor = false;
            this.btn_checkIn.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tổng số: ";
            // 
            // lb_2
            // 
            this.lb_2.AutoSize = true;
            this.lb_2.Location = new System.Drawing.Point(277, 253);
            this.lb_2.Name = "lb_2";
            this.lb_2.Size = new System.Drawing.Size(17, 17);
            this.lb_2.TabIndex = 5;
            this.lb_2.Text = "...";
            // 
            // nm_thread
            // 
            this.nm_thread.Location = new System.Drawing.Point(372, 135);
            this.nm_thread.Name = "nm_thread";
            this.nm_thread.Size = new System.Drawing.Size(33, 25);
            this.nm_thread.TabIndex = 6;
            this.nm_thread.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thread";
            // 
            // btn_getListItems
            // 
            this.btn_getListItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_getListItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_getListItems.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_getListItems.ForeColor = System.Drawing.Color.White;
            this.btn_getListItems.Location = new System.Drawing.Point(6, 125);
            this.btn_getListItems.Name = "btn_getListItems";
            this.btn_getListItems.Size = new System.Drawing.Size(180, 40);
            this.btn_getListItems.TabIndex = 8;
            this.btn_getListItems.Text = "Lấy list vật phẩm";
            this.btn_getListItems.UseVisualStyleBackColor = false;
            this.btn_getListItems.Click += new System.EventHandler(this.btn_getListItems_Click);
            // 
            // btn_sendAllGift
            // 
            this.btn_sendAllGift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_sendAllGift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sendAllGift.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sendAllGift.ForeColor = System.Drawing.Color.White;
            this.btn_sendAllGift.Location = new System.Drawing.Point(6, 63);
            this.btn_sendAllGift.Name = "btn_sendAllGift";
            this.btn_sendAllGift.Size = new System.Drawing.Size(180, 40);
            this.btn_sendAllGift.TabIndex = 9;
            this.btn_sendAllGift.Text = "Tặng vật phẩm";
            this.btn_sendAllGift.UseVisualStyleBackColor = false;
            this.btn_sendAllGift.Click += new System.EventHandler(this.btn_sendGift_Click);
            // 
            // tb_sdtgift
            // 
            this.tb_sdtgift.BackColor = System.Drawing.SystemColors.Control;
            this.tb_sdtgift.Location = new System.Drawing.Point(281, 72);
            this.tb_sdtgift.Name = "tb_sdtgift";
            this.tb_sdtgift.Size = new System.Drawing.Size(128, 25);
            this.tb_sdtgift.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "SĐT";
            // 
            // tb_offset
            // 
            this.tb_offset.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tb_offset.Location = new System.Drawing.Point(281, 75);
            this.tb_offset.Name = "tb_offset";
            this.tb_offset.Size = new System.Drawing.Size(128, 25);
            this.tb_offset.TabIndex = 16;
            this.tb_offset.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Vị trí";
            // 
            // cb_combo99k
            // 
            this.cb_combo99k.AutoSize = true;
            this.cb_combo99k.Location = new System.Drawing.Point(110, 31);
            this.cb_combo99k.Name = "cb_combo99k";
            this.cb_combo99k.Size = new System.Drawing.Size(94, 21);
            this.cb_combo99k.TabIndex = 20;
            this.cb_combo99k.Text = "Combo 99k";
            this.cb_combo99k.UseVisualStyleBackColor = true;
            this.cb_combo99k.CheckedChanged += new System.EventHandler(this.cb_combo99k_CheckedChanged);
            // 
            // cb_combo9k
            // 
            this.cb_combo9k.AutoSize = true;
            this.cb_combo9k.Location = new System.Drawing.Point(209, 31);
            this.cb_combo9k.Name = "cb_combo9k";
            this.cb_combo9k.Size = new System.Drawing.Size(87, 21);
            this.cb_combo9k.TabIndex = 21;
            this.cb_combo9k.Text = "Combo 9k";
            this.cb_combo9k.UseVisualStyleBackColor = true;
            this.cb_combo9k.CheckedChanged += new System.EventHandler(this.cb_combo9k_CheckedChanged);
            // 
            // cb_combo999d
            // 
            this.cb_combo999d.AutoSize = true;
            this.cb_combo999d.Location = new System.Drawing.Point(302, 31);
            this.cb_combo999d.Name = "cb_combo999d";
            this.cb_combo999d.Size = new System.Drawing.Size(103, 21);
            this.cb_combo999d.TabIndex = 22;
            this.cb_combo999d.Text = "Combo 999đ";
            this.cb_combo999d.UseVisualStyleBackColor = true;
            this.cb_combo999d.CheckedChanged += new System.EventHandler(this.cb_combo999d_CheckedChanged);
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(66)))), ((int)(((byte)(53)))));
            this.btn_stop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_stop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.ForeColor = System.Drawing.Color.White;
            this.btn_stop.Location = new System.Drawing.Point(229, 71);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(180, 40);
            this.btn_stop.TabIndex = 24;
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_openGifts
            // 
            this.btn_openGifts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_openGifts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openGifts.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_openGifts.ForeColor = System.Drawing.Color.White;
            this.btn_openGifts.Location = new System.Drawing.Point(6, 230);
            this.btn_openGifts.Name = "btn_openGifts";
            this.btn_openGifts.Size = new System.Drawing.Size(180, 40);
            this.btn_openGifts.TabIndex = 25;
            this.btn_openGifts.Text = "Mở quà";
            this.btn_openGifts.UseVisualStyleBackColor = false;
            this.btn_openGifts.Click += new System.EventHandler(this.btn_openGifts_Click);
            // 
            // cb_allCombo
            // 
            this.cb_allCombo.AutoSize = true;
            this.cb_allCombo.Location = new System.Drawing.Point(6, 31);
            this.cb_allCombo.Name = "cb_allCombo";
            this.cb_allCombo.Size = new System.Drawing.Size(98, 21);
            this.cb_allCombo.TabIndex = 26;
            this.cb_allCombo.Text = "Cả 3 combo";
            this.cb_allCombo.UseVisualStyleBackColor = true;
            this.cb_allCombo.CheckedChanged += new System.EventHandler(this.cb_allCombo_CheckedChanged);
            // 
            // rb_all
            // 
            this.rb_all.AutoSize = true;
            this.rb_all.Checked = true;
            this.rb_all.Location = new System.Drawing.Point(9, 33);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new System.Drawing.Size(108, 21);
            this.rb_all.TabIndex = 27;
            this.rb_all.TabStop = true;
            this.rb_all.Text = "Toàn bộ CSDL";
            this.rb_all.UseVisualStyleBackColor = true;
            // 
            // rb_single
            // 
            this.rb_single.AutoSize = true;
            this.rb_single.Location = new System.Drawing.Point(276, 33);
            this.rb_single.Name = "rb_single";
            this.rb_single.Size = new System.Drawing.Size(133, 21);
            this.rb_single.TabIndex = 28;
            this.rb_single.Text = "100 TK/lần (offset)";
            this.rb_single.UseVisualStyleBackColor = true;
            // 
            // rb_selectcombo
            // 
            this.rb_selectcombo.AutoSize = true;
            this.rb_selectcombo.Location = new System.Drawing.Point(130, 33);
            this.rb_selectcombo.Name = "rb_selectcombo";
            this.rb_selectcombo.Size = new System.Drawing.Size(131, 21);
            this.rb_selectcombo.TabIndex = 29;
            this.rb_selectcombo.TabStop = true;
            this.rb_selectcombo.Text = "Chọn theo combo";
            this.rb_selectcombo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btn_sendAllGift);
            this.groupBox1.Controls.Add(this.cb_allCombo);
            this.groupBox1.Controls.Add(this.cb_combo99k);
            this.groupBox1.Controls.Add(this.cb_combo9k);
            this.groupBox1.Controls.Add(this.cb_combo999d);
            this.groupBox1.Controls.Add(this.tb_sdtgift);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 121);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác tặng quà";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btn_loadData);
            this.groupBox2.Controls.Add(this.tb_offset);
            this.groupBox2.Controls.Add(this.rb_single);
            this.groupBox2.Controls.Add(this.rb_selectcombo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rb_all);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 120);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác với database";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.btn_selectBlacklist);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.nmr_delay);
            this.groupBox3.Controls.Add(this.btn_changeIP);
            this.groupBox3.Controls.Add(this.tb_proxyKey);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btn_stop);
            this.groupBox3.Controls.Add(this.btn_checkIn);
            this.groupBox3.Controls.Add(this.btn_getListItems);
            this.groupBox3.Controls.Add(this.lb_2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btn_openGifts);
            this.groupBox3.Controls.Add(this.nm_thread);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 294);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thao tác chung";
            // 
            // btn_selectBlacklist
            // 
            this.btn_selectBlacklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_selectBlacklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectBlacklist.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selectBlacklist.ForeColor = System.Drawing.Color.White;
            this.btn_selectBlacklist.Location = new System.Drawing.Point(6, 71);
            this.btn_selectBlacklist.Name = "btn_selectBlacklist";
            this.btn_selectBlacklist.Size = new System.Drawing.Size(180, 40);
            this.btn_selectBlacklist.TabIndex = 27;
            this.btn_selectBlacklist.Text = "Chọn TK trong File";
            this.btn_selectBlacklist.UseVisualStyleBackColor = false;
            this.btn_selectBlacklist.Click += new System.EventHandler(this.btn_selectBlacklist_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Delay";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(320, 253);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Dark mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // nmr_delay
            // 
            this.nmr_delay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmr_delay.Location = new System.Drawing.Point(254, 135);
            this.nmr_delay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmr_delay.Name = "nmr_delay";
            this.nmr_delay.Size = new System.Drawing.Size(57, 25);
            this.nmr_delay.TabIndex = 30;
            this.nmr_delay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // btn_changeIP
            // 
            this.btn_changeIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_changeIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_changeIP.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_changeIP.ForeColor = System.Drawing.Color.White;
            this.btn_changeIP.Location = new System.Drawing.Point(6, 178);
            this.btn_changeIP.Name = "btn_changeIP";
            this.btn_changeIP.Size = new System.Drawing.Size(180, 40);
            this.btn_changeIP.TabIndex = 29;
            this.btn_changeIP.Text = "Dùng proxy";
            this.btn_changeIP.UseVisualStyleBackColor = false;
            this.btn_changeIP.Click += new System.EventHandler(this.btn_changeIP_Click);
            // 
            // tb_proxyKey
            // 
            this.tb_proxyKey.BackColor = System.Drawing.SystemColors.Control;
            this.tb_proxyKey.Location = new System.Drawing.Point(254, 193);
            this.tb_proxyKey.Name = "tb_proxyKey";
            this.tb_proxyKey.Size = new System.Drawing.Size(155, 25);
            this.tb_proxyKey.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Proxy";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtg_vtm);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(424, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(955, 752);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bảng số liệu";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(3, 570);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(415, 186);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hướng dẫn cơ bản";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.Location = new System.Drawing.Point(6, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(403, 156);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(368, 554);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 35;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Liên hệ";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(364, 167);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(45, 13);
            this.linkLabel2.TabIndex = 36;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Mở File";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_stop;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sự kiện Tết 2024";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_vtm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_thread)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_delay)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_token;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_imei;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stt;
        private System.Windows.Forms.DataGridView dtg_vtm;
        private System.Windows.Forms.Button btn_loadData;
        private System.Windows.Forms.Button btn_checkIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_2;
        private System.Windows.Forms.NumericUpDown nm_thread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_getListItems;
        private System.Windows.Forms.Button btn_sendAllGift;
        private System.Windows.Forms.TextBox tb_sdtgift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_offset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_combo99k;
        private System.Windows.Forms.CheckBox cb_combo9k;
        private System.Windows.Forms.CheckBox cb_combo999d;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_openGifts;
        private System.Windows.Forms.CheckBox cb_allCombo;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.RadioButton rb_single;
        private System.Windows.Forms.RadioButton rb_selectcombo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btn_changeIP;
        private System.Windows.Forms.TextBox tb_proxyKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nmr_delay;
        private System.Windows.Forms.Button btn_selectBlacklist;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

