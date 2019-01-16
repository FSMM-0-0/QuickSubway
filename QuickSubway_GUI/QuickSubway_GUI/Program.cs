using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;

namespace QuickSubway_GUI
{
	/************************************************************************************
	* Copyright (c) 2019 All Rights Reserved.
	*命名空间：QuickSubway_GUI
	*文件名： Program
	*创建人： XCyclone
	*创建时间：2019/1/14 17:35:14
	*描述
	************************************************************************************/
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		
		[DllImport("QuickSubway_Dll.dll", EntryPoint = "ConsoleInterface", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConsoleInterface(int type, ref byte input, ref byte output);

		[STAThread]

		static void Main(string[] args)
		{
			if(args.Length == 1 && args[0].ToLower() == "/g")
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
			if (args.Length == 2 && args[0].ToLower() == "/g")
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1(args[1]));

			}

		}
	}
}
