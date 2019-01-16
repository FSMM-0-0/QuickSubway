namespace QuickSubway_GUI
{
	/************************************************************************************
	* Copyright (c) 2019 All Rights Reserved.
	*命名空间：QuickSubway_GUI
	*文件名： Shortest
	*创建人： XCyclone
	*创建时间：2019/1/14 20:01:57
	*描述
	************************************************************************************/

	partial class Shortest
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shortest));
			this.shortest_input1 = new System.Windows.Forms.TextBox();
			this.shortest_btn = new System.Windows.Forms.Button();
			this.shortest_input2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// shortest_input1
			// 
			this.shortest_input1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.shortest_input1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.shortest_input1.Location = new System.Drawing.Point(138, 27);
			this.shortest_input1.Name = "shortest_input1";
			this.shortest_input1.Size = new System.Drawing.Size(140, 26);
			this.shortest_input1.TabIndex = 0;
			this.shortest_input1.TextChanged += new System.EventHandler(this.shortest_input_TextChanged);
			// 
			// shortest_btn
			// 
			this.shortest_btn.Location = new System.Drawing.Point(108, 137);
			this.shortest_btn.Name = "shortest_btn";
			this.shortest_btn.Size = new System.Drawing.Size(89, 33);
			this.shortest_btn.TabIndex = 1;
			this.shortest_btn.Text = "确定";
			this.shortest_btn.UseVisualStyleBackColor = true;
			this.shortest_btn.Click += new System.EventHandler(this.shortest_btn_Click);
			// 
			// shortest_input2
			// 
			this.shortest_input2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.shortest_input2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.shortest_input2.Location = new System.Drawing.Point(138, 75);
			this.shortest_input2.Name = "shortest_input2";
			this.shortest_input2.Size = new System.Drawing.Size(138, 26);
			this.shortest_input2.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(40, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "出发站";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(40, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "终点站";
			// 
			// Shortest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::QuickSubway_GUI.Properties.Resources.subway_lit80;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(312, 189);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.shortest_input2);
			this.Controls.Add(this.shortest_btn);
			this.Controls.Add(this.shortest_input1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Shortest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "最短路";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox shortest_input1;
		private System.Windows.Forms.Button shortest_btn;
		private System.Windows.Forms.TextBox shortest_input2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}