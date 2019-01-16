using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

	public partial class Shortest : Form
	{
		public string start, end;
		public Shortest()
		{
			InitializeComponent();
		}

		private void shortest_btn_Click(object sender, EventArgs e)
		{
			//传递站点信息
			this.start = shortest_input1.Text + "";
			this.end = shortest_input2.Text + "";
			this.Hide();
		}

		private void shortest_input_TextChanged(object sender, EventArgs e)
		{
		}
	}
}
