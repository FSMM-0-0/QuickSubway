namespace QuickSubway_GUI
{
	/************************************************************************************
	* Copyright (c) 2019 All Rights Reserved.
	*命名空间：QuickSubway_GUI
	*文件名： All
	*创建人： XCyclone
	*创建时间：2019/1/15 00:08:28
	*描述
	************************************************************************************/

	partial class All
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(All));
			this.btn_all = new System.Windows.Forms.Button();
			this.all_input = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_all
			// 
			this.btn_all.Location = new System.Drawing.Point(116, 122);
			this.btn_all.Name = "btn_all";
			this.btn_all.Size = new System.Drawing.Size(79, 30);
			this.btn_all.TabIndex = 1;
			this.btn_all.Text = "确定";
			this.btn_all.UseVisualStyleBackColor = true;
			this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
			// 
			// all_input
			// 
			this.all_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.all_input.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.all_input.Location = new System.Drawing.Point(116, 62);
			this.all_input.Name = "all_input";
			this.all_input.Size = new System.Drawing.Size(140, 26);
			this.all_input.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(34, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "出发站";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// All
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::QuickSubway_GUI.Properties.Resources.subway_lit80;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(312, 189);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.all_input);
			this.Controls.Add(this.btn_all);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "All";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "全遍历";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btn_all;
		private System.Windows.Forms.TextBox all_input;
		private System.Windows.Forms.Label label1;
	}
}