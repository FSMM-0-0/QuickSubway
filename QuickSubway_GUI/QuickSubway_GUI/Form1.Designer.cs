namespace QuickSubway_GUI
{
	/************************************************************************************
	* Copyright (c) 2019 All Rights Reserved.
	*命名空间：QuickSubway_GUI
	*文件名： Form1
	*创建人： XCyclone
	*创建时间：2019/1/14 17:35:14
	*描述
	************************************************************************************/

	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_sta = new System.Windows.Forms.Label();
            this.label_next = new System.Windows.Forms.Label();
            this.label_now = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tBox_output = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.线路查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no1 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no2 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no4 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no5 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no6 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no7 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no8 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no9 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no10 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no13 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no14e = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no14w = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no15 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_no16 = new System.Windows.Forms.ToolStripMenuItem();
            this.line_batong = new System.Windows.Forms.ToolStripMenuItem();
            this.line_changping = new System.Windows.Forms.ToolStripMenuItem();
            this.line_yizhuang = new System.Windows.Forms.ToolStripMenuItem();
            this.line_fangshan = new System.Windows.Forms.ToolStripMenuItem();
            this.line_jichang = new System.Windows.Forms.ToolStripMenuItem();
            this.line_xijiao = new System.Windows.Forms.ToolStripMenuItem();
            this.line_yanfang = new System.Windows.Forms.ToolStripMenuItem();
            this.line_s1 = new System.Windows.Forms.ToolStripMenuItem();
            this.最短路查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortest_trans = new System.Windows.Forms.ToolStripMenuItem();
            this.shortest_sta = new System.Windows.Forms.ToolStripMenuItem();
            this.全遍历查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.all_trans = new System.Windows.Forms.ToolStripMenuItem();
            this.all_sta = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tBox_output);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 745);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_sta);
            this.panel2.Controls.Add(this.label_next);
            this.panel2.Controls.Add(this.label_now);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label_time);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(1049, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 262);
            this.panel2.TabIndex = 15;
            // 
            // label_sta
            // 
            this.label_sta.AutoSize = true;
            this.label_sta.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_sta.ForeColor = System.Drawing.Color.DarkRed;
            this.label_sta.Location = new System.Drawing.Point(130, 104);
            this.label_sta.Name = "label_sta";
            this.label_sta.Size = new System.Drawing.Size(45, 29);
            this.label_sta.TabIndex = 12;
            this.label_sta.Text = "00";
            // 
            // label_next
            // 
            this.label_next.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_next.Location = new System.Drawing.Point(78, 191);
            this.label_next.Name = "label_next";
            this.label_next.Size = new System.Drawing.Size(150, 40);
            this.label_next.TabIndex = 9;
            this.label_next.Text = "魏公村";
            this.label_next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_now
            // 
            this.label_now.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_now.Location = new System.Drawing.Point(81, 151);
            this.label_now.Name = "label_now";
            this.label_now.Size = new System.Drawing.Size(147, 40);
            this.label_now.TabIndex = 8;
            this.label_now.Text = "魏公村";
            this.label_now.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 40);
            this.label3.TabIndex = 7;
            this.label3.Text = "下一站";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "当前站";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 92);
            this.label1.TabIndex = 4;
            this.label1.Text = "当前时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_time
            // 
            this.label_time.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_time.ForeColor = System.Drawing.Color.DarkRed;
            this.label_time.Location = new System.Drawing.Point(112, 0);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(119, 92);
            this.label_time.TabIndex = 5;
            this.label_time.Text = "1:21:34";
            this.label_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 58);
            this.label7.TabIndex = 11;
            this.label7.Text = "站数";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(749, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 84);
            this.label5.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-1, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 83);
            this.label4.TabIndex = 13;
            // 
            // tBox_output
            // 
            this.tBox_output.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tBox_output.CausesValidation = false;
            this.tBox_output.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBox_output.Location = new System.Drawing.Point(1049, 262);
            this.tBox_output.Multiline = true;
            this.tBox_output.Name = "tBox_output";
            this.tBox_output.ReadOnly = true;
            this.tBox_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBox_output.Size = new System.Drawing.Size(231, 280);
            this.tBox_output.TabIndex = 12;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::QuickSubway_GUI.Properties.Resources.subway_bg80;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(1049, 540);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(242, 245);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::QuickSubway_GUI.Properties.Resources.LOGO2;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(260, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(493, 84);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.线路查询ToolStripMenuItem,
            this.最短路查询ToolStripMenuItem,
            this.全遍历查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 线路查询ToolStripMenuItem
            // 
            this.线路查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.line_no1,
            this.line_no2,
            this.line_no4,
            this.line_no5,
            this.line_no6,
            this.line_no7,
            this.line_no8,
            this.line_no9,
            this.line_no10,
            this.line_no13,
            this.line_no14e,
            this.line_no14w,
            this.line_no15,
            this.line_no16,
            this.line_batong,
            this.line_changping,
            this.line_yizhuang,
            this.line_fangshan,
            this.line_jichang,
            this.line_xijiao,
            this.line_yanfang,
            this.line_s1});
            this.线路查询ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.线路查询ToolStripMenuItem.Name = "线路查询ToolStripMenuItem";
            this.线路查询ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.线路查询ToolStripMenuItem.Text = "线路查询";
            // 
            // line_no1
            // 
            this.line_no1.Name = "line_no1";
            this.line_no1.Size = new System.Drawing.Size(180, 26);
            this.line_no1.Text = "1号线";
            this.line_no1.Click += new System.EventHandler(this.line_no1_Click);
            // 
            // line_no2
            // 
            this.line_no2.Name = "line_no2";
            this.line_no2.Size = new System.Drawing.Size(180, 26);
            this.line_no2.Text = "2号线";
            this.line_no2.Click += new System.EventHandler(this.line_no2_Click);
            // 
            // line_no4
            // 
            this.line_no4.Name = "line_no4";
            this.line_no4.Size = new System.Drawing.Size(180, 26);
            this.line_no4.Text = "4号线";
            this.line_no4.Click += new System.EventHandler(this.line_no4_Click);
            // 
            // line_no5
            // 
            this.line_no5.Name = "line_no5";
            this.line_no5.Size = new System.Drawing.Size(180, 26);
            this.line_no5.Text = "5号线";
            this.line_no5.Click += new System.EventHandler(this.line_no5_Click);
            // 
            // line_no6
            // 
            this.line_no6.Name = "line_no6";
            this.line_no6.Size = new System.Drawing.Size(180, 26);
            this.line_no6.Text = "6号线";
            this.line_no6.Click += new System.EventHandler(this.line_no6_Click);
            // 
            // line_no7
            // 
            this.line_no7.Name = "line_no7";
            this.line_no7.Size = new System.Drawing.Size(180, 26);
            this.line_no7.Text = "7号线";
            this.line_no7.Click += new System.EventHandler(this.line_no7_Click);
            // 
            // line_no8
            // 
            this.line_no8.Name = "line_no8";
            this.line_no8.Size = new System.Drawing.Size(180, 26);
            this.line_no8.Text = "8号线";
            this.line_no8.Click += new System.EventHandler(this.line_no8_Click);
            // 
            // line_no9
            // 
            this.line_no9.Name = "line_no9";
            this.line_no9.Size = new System.Drawing.Size(180, 26);
            this.line_no9.Text = "9号线";
            this.line_no9.Click += new System.EventHandler(this.line_no9_Click);
            // 
            // line_no10
            // 
            this.line_no10.Name = "line_no10";
            this.line_no10.Size = new System.Drawing.Size(180, 26);
            this.line_no10.Text = "10号线";
            this.line_no10.Click += new System.EventHandler(this.line_no10_Click);
            // 
            // line_no13
            // 
            this.line_no13.Name = "line_no13";
            this.line_no13.Size = new System.Drawing.Size(180, 26);
            this.line_no13.Text = "13号线";
            this.line_no13.Click += new System.EventHandler(this.line_no13_Click);
            // 
            // line_no14e
            // 
            this.line_no14e.Name = "line_no14e";
            this.line_no14e.Size = new System.Drawing.Size(180, 26);
            this.line_no14e.Text = "14号线东线";
            this.line_no14e.Click += new System.EventHandler(this.line_no14e_Click);
            // 
            // line_no14w
            // 
            this.line_no14w.Name = "line_no14w";
            this.line_no14w.Size = new System.Drawing.Size(180, 26);
            this.line_no14w.Text = "14号线西线";
            this.line_no14w.Click += new System.EventHandler(this.line_no14w_Click);
            // 
            // line_no15
            // 
            this.line_no15.Name = "line_no15";
            this.line_no15.Size = new System.Drawing.Size(180, 26);
            this.line_no15.Text = "15号线";
            this.line_no15.Click += new System.EventHandler(this.line_no15_Click);
            // 
            // line_no16
            // 
            this.line_no16.Name = "line_no16";
            this.line_no16.Size = new System.Drawing.Size(180, 26);
            this.line_no16.Text = "16号线";
            this.line_no16.Click += new System.EventHandler(this.line_no16_Click);
            // 
            // line_batong
            // 
            this.line_batong.Name = "line_batong";
            this.line_batong.Size = new System.Drawing.Size(180, 26);
            this.line_batong.Text = "八通线";
            this.line_batong.Click += new System.EventHandler(this.line_batong_Click);
            // 
            // line_changping
            // 
            this.line_changping.Name = "line_changping";
            this.line_changping.Size = new System.Drawing.Size(180, 26);
            this.line_changping.Text = "昌平线";
            this.line_changping.Click += new System.EventHandler(this.line_changping_Click);
            // 
            // line_yizhuang
            // 
            this.line_yizhuang.Name = "line_yizhuang";
            this.line_yizhuang.Size = new System.Drawing.Size(180, 26);
            this.line_yizhuang.Text = "亦庄线";
            this.line_yizhuang.Click += new System.EventHandler(this.line_yizhuang_Click);
            // 
            // line_fangshan
            // 
            this.line_fangshan.Name = "line_fangshan";
            this.line_fangshan.Size = new System.Drawing.Size(180, 26);
            this.line_fangshan.Text = "房山线";
            this.line_fangshan.Click += new System.EventHandler(this.line_fangshan_Click);
            // 
            // line_jichang
            // 
            this.line_jichang.Name = "line_jichang";
            this.line_jichang.Size = new System.Drawing.Size(180, 26);
            this.line_jichang.Text = "机场线";
            this.line_jichang.Click += new System.EventHandler(this.line_jichang_Click);
            // 
            // line_xijiao
            // 
            this.line_xijiao.Name = "line_xijiao";
            this.line_xijiao.Size = new System.Drawing.Size(180, 26);
            this.line_xijiao.Text = "西郊线";
            this.line_xijiao.Click += new System.EventHandler(this.line_xijiao_Click);
            // 
            // line_yanfang
            // 
            this.line_yanfang.Name = "line_yanfang";
            this.line_yanfang.Size = new System.Drawing.Size(180, 26);
            this.line_yanfang.Text = "燕房线";
            this.line_yanfang.Click += new System.EventHandler(this.line_yanfang_Click);
            // 
            // line_s1
            // 
            this.line_s1.Name = "line_s1";
            this.line_s1.Size = new System.Drawing.Size(180, 26);
            this.line_s1.Text = "S1线";
            this.line_s1.Click += new System.EventHandler(this.line_s1_Click);
            // 
            // 最短路查询ToolStripMenuItem
            // 
            this.最短路查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shortest_trans,
            this.shortest_sta});
            this.最短路查询ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.最短路查询ToolStripMenuItem.Name = "最短路查询ToolStripMenuItem";
            this.最短路查询ToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.最短路查询ToolStripMenuItem.Text = "最短路查询";
            // 
            // shortest_trans
            // 
            this.shortest_trans.Name = "shortest_trans";
            this.shortest_trans.Size = new System.Drawing.Size(144, 26);
            this.shortest_trans.Text = "最少换乘";
            this.shortest_trans.Click += new System.EventHandler(this.shortest_trans_Click);
            // 
            // shortest_sta
            // 
            this.shortest_sta.Name = "shortest_sta";
            this.shortest_sta.Size = new System.Drawing.Size(144, 26);
            this.shortest_sta.Text = "最少站数";
            this.shortest_sta.Click += new System.EventHandler(this.shortest_sta_Click);
            // 
            // 全遍历查询ToolStripMenuItem
            // 
            this.全遍历查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.all_trans,
            this.all_sta});
            this.全遍历查询ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.全遍历查询ToolStripMenuItem.Name = "全遍历查询ToolStripMenuItem";
            this.全遍历查询ToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.全遍历查询ToolStripMenuItem.Text = "全遍历查询";
            // 
            // all_trans
            // 
            this.all_trans.Name = "all_trans";
            this.all_trans.Size = new System.Drawing.Size(144, 26);
            this.all_trans.Text = "最少换乘";
            this.all_trans.Click += new System.EventHandler(this.all_trans_Click);
            // 
            // all_sta
            // 
            this.all_sta.Name = "all_sta";
            this.all_sta.Size = new System.Drawing.Size(144, 26);
            this.all_sta.Text = "最少站数";
            this.all_sta.Click += new System.EventHandler(this.all_sta_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1050, 667);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1280, 745);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1300, 820);
            this.MinimumSize = new System.Drawing.Size(1300, 726);
            this.Name = "Form1";
            this.Text = "Quick Subway";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 线路查询ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem line_no1;
		private System.Windows.Forms.ToolStripMenuItem line_no2;
		private System.Windows.Forms.ToolStripMenuItem line_no4;
		private System.Windows.Forms.ToolStripMenuItem line_no5;
		private System.Windows.Forms.ToolStripMenuItem line_no6;
		private System.Windows.Forms.ToolStripMenuItem line_no7;
		private System.Windows.Forms.ToolStripMenuItem line_no8;
		private System.Windows.Forms.ToolStripMenuItem line_no9;
		private System.Windows.Forms.ToolStripMenuItem line_no10;
		private System.Windows.Forms.ToolStripMenuItem line_no13;
		private System.Windows.Forms.ToolStripMenuItem line_no14e;
		private System.Windows.Forms.ToolStripMenuItem 最短路查询ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shortest_trans;
		private System.Windows.Forms.ToolStripMenuItem shortest_sta;
		private System.Windows.Forms.ToolStripMenuItem 全遍历查询ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem all_trans;
		private System.Windows.Forms.ToolStripMenuItem all_sta;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox tBox_output;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label_next;
		private System.Windows.Forms.Label label_now;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label_time;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.ToolStripMenuItem line_no14w;
		private System.Windows.Forms.ToolStripMenuItem line_no15;
		private System.Windows.Forms.ToolStripMenuItem line_no16;
		private System.Windows.Forms.ToolStripMenuItem line_batong;
		private System.Windows.Forms.ToolStripMenuItem line_changping;
		private System.Windows.Forms.ToolStripMenuItem line_yizhuang;
		private System.Windows.Forms.ToolStripMenuItem line_fangshan;
		private System.Windows.Forms.ToolStripMenuItem line_jichang;
		private System.Windows.Forms.ToolStripMenuItem line_xijiao;
		private System.Windows.Forms.ToolStripMenuItem line_yanfang;
		private System.Windows.Forms.ToolStripMenuItem line_s1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label_sta;
	}
}

