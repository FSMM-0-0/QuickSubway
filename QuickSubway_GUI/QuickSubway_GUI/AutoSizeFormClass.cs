using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickSubway_GUI
{
	/************************************************************************************
	* Copyright (c) 2019 All Rights Reserved.
	*命名空间：QuickSubway_GUI
	*文件名： AutoSizeFormClass
	*创建人： XCyclone
	*创建时间：2019/1/16 17:46:52
	*描述
	************************************************************************************/

	class AutoSizeFormClass
	{
		public struct controlRect
		{
			public int Left;
			public int Top;
			public int Width;
			public int Height;
		}

		public List<controlRect> oldCtrl;
 
		public void controllInitializeSize(Form mForm, Panel panel)
		{
			{
				oldCtrl = new List<controlRect>();
				controlRect cR;
				cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;
				oldCtrl.Add(cR);
				foreach (Control c in mForm.Controls)
				{
					controlRect objCtrl;
					objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;
					oldCtrl.Add(objCtrl);
				}

				foreach (Control c in panel.Controls)
				{
					controlRect objCtrl;
					objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;
					oldCtrl.Add(objCtrl);
				}
			}
		}
		public void controlAutoSize(Form mForm, Panel panel)
		{
			
			float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;//新旧窗体之间的比例，与最早的旧窗体  
			float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;  
			int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
			int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始  
			foreach (Control c in mForm.Controls)
			{
				ctrLeft0 = oldCtrl[ctrlNo].Left;
				ctrTop0 = oldCtrl[ctrlNo].Top;
				ctrWidth0 = oldCtrl[ctrlNo].Width;
				ctrHeight0 = oldCtrl[ctrlNo].Height;
				
				c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1  
				c.Top = (int)((ctrTop0) * hScale);//  
				c.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);  
				c.Height = (int)(ctrHeight0 * hScale);//  
				ctrlNo += 1;
			}

			foreach (Control c in panel.Controls)
			{
				ctrLeft0 = oldCtrl[ctrlNo].Left;
				ctrTop0 = oldCtrl[ctrlNo].Top;
				ctrWidth0 = oldCtrl[ctrlNo].Width;
				ctrHeight0 = oldCtrl[ctrlNo].Height;
				
				c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1  
				c.Top = (int)((ctrTop0) * hScale);//  
				c.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);  
				c.Height = (int)(ctrHeight0 * hScale);//  
				ctrlNo += 1;
			}
		}

	}

}
