using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickSubway_GUI
{
	/************************************************************************************
	* Copyright (c) 2019 All Rights Reserved.
	*命名空间：QuickSubway_GUI
	*文件名： Draw
	*创建人： XCyclone
	*创建时间：2019/1/15 0:58:03
	*描述
	************************************************************************************/



	public class Draw
	{
		//
		//绘制黄色点
		//
		public void DrawPointY(Graphics g, Point p)
		{
			Pen pen = new Pen(Brushes.Yellow,5);
			Size size = new Size(5, 5);
			Rectangle rectangle = new Rectangle(p, size);
			g.DrawEllipse(pen, rectangle);
			
		}
		//
		//绘制蓝色点
		//
		public void DrawPointB(Graphics g, Point p)
		{
			Pen pen = new Pen(Color.FromArgb(51,166,184), 5);
			Size size = new Size(5, 5);
			Rectangle rectangle = new Rectangle(p, size);
			g.DrawEllipse(pen, rectangle);

		}
		//
		//绘制红色点
		//
		public void DrawPointR(Graphics g, Point p)
		{
			Pen pen = new Pen(Brushes.Red, 2);
			Size size = new Size(2, 2);
			Rectangle rectangle = new Rectangle(p, size);
			g.DrawEllipse(pen, rectangle);
		}
		//
		//绘制粉色点
		//
		public void DrawPointP(Graphics g, Point p)
		{
			Pen pen = new Pen(Color.FromArgb(225, 107, 140), 5);
			Size size = new Size(5, 5);
			Rectangle rectangle = new Rectangle(p, size);
			g.DrawEllipse(pen, rectangle);
		}
		//
		//绘制绿色点
		//
		public void DrawPointG(Graphics g, Point p)
		{
			Pen pen = new Pen(Brushes.Green, 5);
			Size size = new Size(5, 5);
			Rectangle rectangle = new Rectangle(p, size);
			g.DrawEllipse(pen, rectangle);
		}
		//
		//绘制两点连线
		//
		public void DrawLine(Graphics g, Point p1, Point p2)
		{
			Pen pen = new Pen(Brushes.Black, 3);
			pen.EndCap = LineCap.ArrowAnchor;
			g.DrawLine(pen, p1, p2);
		}

	}
}