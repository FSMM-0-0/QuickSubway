using QuickSubway_GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

	public partial class Form1 : Form
	{
		public static Graphics graphics = null;
		public bool isMove;
		public Point mouseDownPoint;
		public Size size;
		public int sta;
		public Thread thread;
		public Thread thread2;
		public Dictionary<string, Point> map = new Dictionary<string, Point>();
		string now = null;
		string next = null;

		Rectangle rect = new Rectangle();


		[DllImport("QuickSubway_Dll.dll", EntryPoint = "ConsoleInterface", CallingConvention =CallingConvention.Cdecl)]
		public static extern void ConsoleInterface(int type, ref byte input, ref byte output);

		AutoSizeFormClass asc = new AutoSizeFormClass();

		public Form1()
		{
			//加载控件
			InitializeComponent();
			//定时触发
			timer1.Start();

			//鼠标滚路、点击事件
			this.MouseWheel += Form1_MouseWheel;
			this.size = this.pictureBox1.Size;
			this.pictureBox1.MouseUp += new MouseEventHandler(this.pictureBox1_MouseUp);
			this.pictureBox1.MouseDown += new MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);

			this.tBox_output.Select(this.tBox_output.Text.Length, 1);
			Form1.graphics = pictureBox1.CreateGraphics();
			rect = Screen.GetWorkingArea(this);

			//读取北京地铁信息
			this.ReadFile();
		}

		//
		//读取地铁信息文件
		//
		public void ReadFile()
		{
			FileStream file = new FileStream("beijing-subway1.txt",FileMode.Open, FileAccess.Read);
			StreamReader streamReader = new StreamReader(file, System.Text.Encoding.Default);
			streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
			Point p = new Point();
			string node = streamReader.ReadLine();
			while(node != null)
			{
				string[] sArray = node.Split(' ');
				if (sArray[0] != "#") break;
				p.X = int.Parse(sArray[3]);
				p.Y = int.Parse(sArray[4]);
				map.Add(sArray[2], p);
				node = streamReader.ReadLine();
			}
			streamReader.Close();

		}
		//
		//重置地图
		//
		public void ResetMap()
		{
			sta = 0;
			now = null;
			next = null;
			if (thread != null && thread.IsAlive) thread.Abort();
			tBox_output.Clear();
			Bitmap bitmap = new Bitmap(Resources.subway_map);
			Rectangle r = new Rectangle(0, 0,
				this.pictureBox1.Size.Width, this.pictureBox1.Size.Height);
			Form1.graphics.DrawImage(bitmap, r);
		}
		//
		//点坐标
		//
		public Point Node_Location(Point point)
		{
			int x = (int)(point.X * rect.Width / 1440.0);
			int y = (int)(point.Y * rect.Height / 860.0);
			point.X = x;
			point.Y = y;
			return point;
		}
		//
		//全遍历绘图
		//
		public void DrawPicA(object obj)
		{
			string ans = obj.ToString();
			ans = ans.Trim('\0');
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = 0;
			Draw draw = new Draw();
			draw.DrawPointY(graphics, Node_Location(map[sArray[1]]));
			Thread.Sleep(10);
			for (int i = 2; i < size; i++)
			{
				if (map.ContainsKey(sArray[i]))
				{
					sta++;
					if (map.ContainsKey(sArray[i - 1])) draw.DrawPointG(graphics, Node_Location(map[sArray[i - 1]]));
					if (map.ContainsKey(sArray[i - 2])) draw.DrawPointG(graphics, Node_Location(map[sArray[i - 2]]));
					draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
					Thread.Sleep(10);
				}
				if (!map.ContainsKey(sArray[i]))
				{
					draw.DrawLine(graphics, Node_Location(map[sArray[i - 1]]), Node_Location(map[sArray[i + 1]]));
					sta++;
					if (map.ContainsKey(sArray[i - 1])) draw.DrawPointG(graphics, Node_Location(map[sArray[i - 1]]));
					next = sArray[i + 1];
					now = sArray[i - 1];
					i++;
				}
				else
				{
					next = sArray[i];
					now = sArray[i - 1];
					draw.DrawLine(graphics, Node_Location(map[sArray[i - 1]]), Node_Location(map[sArray[i]]));
				}
			}
			sta++;
			if (map.ContainsKey(sArray[size - 2])) draw.DrawPointG(graphics, map[sArray[size - 2]]);
			else if (map.ContainsKey(sArray[size - 3])) draw.DrawPointG(graphics, map[sArray[size - 3]]);
			draw.DrawPointY(graphics, Node_Location(map[sArray[size - 1]]));
			Thread.Sleep(10);
			draw.DrawPointG(graphics, Node_Location(map[sArray[size - 1]]));
		}
		//
		//最短路绘图
		//
		public void DrawPicS(object obj)
		{
			string ans = obj.ToString();
			ans = ans.Trim('\0');
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = 0;
			Draw draw = new Draw();
			draw.DrawPointY(graphics, Node_Location(map[sArray[1]]));
			Thread.Sleep(500);
			for (int i = 2; i < size; i++)
			{
				if (map.ContainsKey(sArray[i]))
				{
					sta++;
					if (map.ContainsKey(sArray[i - 1])) draw.DrawPointG(graphics, Node_Location(map[sArray[i - 1]]));
					else if (map.ContainsKey(sArray[i - 2])) draw.DrawPointG(graphics, Node_Location(map[sArray[i - 2]]));
					draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
					Thread.Sleep(500);
				}
				if (!map.ContainsKey(sArray[i]))
				{
					draw.DrawLine(graphics, Node_Location(map[sArray[i - 1]]), Node_Location(map[sArray[i + 1]]));
					sta++;
					if (map.ContainsKey(sArray[i - 1])) draw.DrawPointG(graphics, Node_Location(map[sArray[i - 1]]));
					next = sArray[i + 1];
					now = sArray[i - 1];
					i++;
				}
				else
				{
					next = sArray[i];
					now = sArray[i - 1];
					draw.DrawLine(graphics, Node_Location(map[sArray[i - 1]]), Node_Location(map[sArray[i]]));
				}
			}
			sta++;
			if (map.ContainsKey(sArray[size - 2])) draw.DrawPointG(graphics, Node_Location(map[sArray[size - 2]]));
			else if (map.ContainsKey(sArray[size - 3])) draw.DrawPointG(graphics, Node_Location(map[sArray[size - 3]]));
			draw.DrawPointY(graphics, Node_Location(map[sArray[size - 1]]));
			Thread.Sleep(500);
			draw.DrawPointG(graphics, Node_Location(map[sArray[size - 1]]));
		}
		//
		//输出文本路径信息
		//
		public void Output_sta(string ans)
		{
			ans = ans.Trim('\0');
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			string str = null;
			int k = 0;
			for (int i = 1; i < size; i++)
			{
				if (map.ContainsKey(sArray[i])) str += "\r\n";
				else str += " ";
				str += sArray[i];
			}
			tBox_output.AppendText(str);
		}
		//
		//鼠标滚轮控制图片大小
		//
		public void Form1_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta > 0) 
			{
				pictureBox1.Size = new Size(pictureBox1.Width + 50, pictureBox1.Height + 50);
			}
			else
			{
				if(pictureBox1.Size.Height > this.size.Height)
					pictureBox1.Size = new Size(pictureBox1.Width - 50, pictureBox1.Height - 50);
			}
			//设置图片在窗体居中
			//pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, (this.Height - pictureBox1.Height) / 2);
		}
		//
		//鼠标点击拖动图片
		//
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				mouseDownPoint.X = Cursor.Position.X;   
				mouseDownPoint.Y = Cursor.Position.Y;
				isMove = true;
				pictureBox1.Focus();    
			}
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				isMove = false;
			}
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			pictureBox1.Focus();    
			if (isMove)
			{
				int x, y;           
				int moveX, moveY;   
				moveX = Cursor.Position.X - mouseDownPoint.X;
				moveY = Cursor.Position.Y - mouseDownPoint.Y;
				x = pictureBox1.Location.X + moveX;
				y = pictureBox1.Location.Y + moveY;
				pictureBox1.Location = new Point(x, y);
				mouseDownPoint.X = Cursor.Position.X;
				mouseDownPoint.Y = Cursor.Position.Y;
			}
		}
		//
		//选择查询某条地铁线路
		//
		private void line_no1_Click(object sender, EventArgs e)
		{
			//pictureBox1.BackgroundImage = Image.FromFile("subway_map.jpg");
			ResetMap();
			string argv = "1号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for(int i = 0;i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}			

		}

		private void line_no2_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "2号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no4_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "4号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no5_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "5号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no6_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "6号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no7_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "7号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no8_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "8号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no9_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "9号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no10_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "10号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no13_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "13号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no14e_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "14号线东线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no14w_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "14号线西线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no15_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "15号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_no16_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "16号线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_batong_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "八通线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_changping_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "昌平线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_yizhuang_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "亦庄线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_fangshan_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "房山线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_jichang_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "机场线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_xijiao_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "西郊线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_yanfang_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "燕房线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}

		private void line_s1_Click(object sender, EventArgs e)
		{
			ResetMap();
			string argv = "S1线";
			byte[] byteInput = Encoding.Default.GetBytes(argv);
			byte[] byteOutput = new byte[10240];
			ConsoleInterface(5, ref byteInput[0], ref byteOutput[0]);
			string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
			tBox_output.Clear();
			string[] sArray = ans.Split(' ');
			int size = sArray.Length;
			sta = size - 1;
			Draw draw = new Draw();
			for (int i = 0; i < size - 1; i++)
			{
				draw.DrawPointY(graphics, Node_Location(map[sArray[i]]));
				tBox_output.AppendText(sArray[i] + '\n');
			}
		}
		//
		//最短路（最少换乘）查询
		//
		private void shortest_trans_Click(object sender, EventArgs e)
		{
			ResetMap();
			Shortest shortest_t = new Shortest();
			shortest_t.ShowDialog();
			if (shortest_t.start == null && shortest_t.end == null) { }
			else if (map.ContainsKey(shortest_t.start) && map.ContainsKey(shortest_t.end))
			{
				string argv = shortest_t.start + " " + shortest_t.end;
				byte[] byteInput = Encoding.Default.GetBytes(argv);
				byte[] byteOutput = new byte[10240];
				ConsoleInterface(3, ref byteInput[0], ref byteOutput[0]);
				string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
				tBox_output.Clear();
				Output_sta(ans);
				thread = new Thread(new ParameterizedThreadStart(DrawPicS));
				thread.Start(ans);
			}
			else
				MessageBox.Show("站点输入错误！");
			shortest_t.Close();
		}
		//
		//最短路（最少站点）查询
		//
		private void shortest_sta_Click(object sender, EventArgs e)
		{
			ResetMap();
			Shortest shortest_s = new Shortest();
			shortest_s.ShowDialog();
			if (shortest_s.start == null && shortest_s.end == null) { }
			else if (map.ContainsKey(shortest_s.start) && map.ContainsKey(shortest_s.end))
			{
				string argv = shortest_s.start + " " + shortest_s.end;
				byte[] byteInput = Encoding.Default.GetBytes(argv);
				byte[] byteOutput = new byte[10240];
				ConsoleInterface(2, ref byteInput[0], ref byteOutput[0]);
				string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
				tBox_output.Clear();
				Output_sta(ans);
				thread = new Thread(new ParameterizedThreadStart(DrawPicS));
				thread.Start(ans);
			}
			else
				MessageBox.Show("站点输入错误！");

			shortest_s.Close();

		}
		//
		//全遍历（最少换乘）查询
		//
		private void all_trans_Click(object sender, EventArgs e)
		{
			ResetMap();
			All all_t = new All();
			all_t.ShowDialog();
			if (all_t.Tag == null) { }
			else if (map.ContainsKey(all_t.Tag.ToString()))
			{
				string argv = all_t.Tag.ToString();
				byte[] byteInput = Encoding.Default.GetBytes(argv);
				byte[] byteOutput = new byte[10240];
				ConsoleInterface(4, ref byteInput[0], ref byteOutput[0]);
				string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
				tBox_output.Clear();
				Output_sta(ans);
				thread = new Thread(new ParameterizedThreadStart(DrawPicA));
				thread.Start(ans);
			}
			else
			{
				MessageBox.Show("站点输入错误！");
			}	
			all_t.Close();
		}
		//
		//全遍历（最少站点）查询
		//
		private void all_sta_Click(object sender, EventArgs e)
		{
			ResetMap();
			All all_s = new All();
			all_s.ShowDialog();
			if (all_s.Tag == null) { }
			else if (map.ContainsKey(all_s.Tag.ToString()))
			{
				string argv = all_s.Tag.ToString();
				byte[] byteInput = Encoding.Default.GetBytes(argv);
				byte[] byteOutput = new byte[10240];
				ConsoleInterface(1, ref byteInput[0], ref byteOutput[0]);
				string ans = System.Text.Encoding.Default.GetString(byteOutput, 0, byteOutput.Length);
				tBox_output.Clear();
				Output_sta(ans);
				thread = new Thread(new ParameterizedThreadStart(DrawPicA));
				thread.Start(ans);
				Output_sta(ans);
			}
			else
			{
				MessageBox.Show("站点输入错误！");
			}
			all_s.Close();
		}
		//
		//更新显示信息（时间、站数、当前站、下一站）
		//
		private void timer1_Tick(object sender, EventArgs e)
		{
			DateTime dt = System.DateTime.Now;
			label_time.Text = dt.ToLongTimeString();
			label_sta.Text = sta.ToString();
			label_now.Text = this.now;
			label_next.Text = this.next;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			asc.controllInitializeSize(this, panel1);
			Rectangle rect = new Rectangle();
			rect = Screen.GetWorkingArea(this);
			int width = (int)(1300.0 * rect.Width / 1440.0);
			int height = (int)(820.0 * rect.Height / 860.0);
			this.Width = width;
			this.Height = height;
			asc.controlAutoSize(this, panel1);
			pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
		}
	}
}
