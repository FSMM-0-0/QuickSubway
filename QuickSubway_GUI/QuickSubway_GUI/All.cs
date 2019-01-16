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
	*文件名： All
	*创建人： XCyclone
	*创建时间：2019/1/15 00:08:28
	*描述
	************************************************************************************/
	public partial class All : Form
	{
		public All()
		{
			InitializeComponent();
		}

		private void btn_all_Click(object sender, EventArgs e)
		{
			//传递站点信息
			this.Tag = all_input.Text;
			this.Hide();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
