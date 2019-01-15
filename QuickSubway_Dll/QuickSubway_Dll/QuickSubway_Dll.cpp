// QuickSubway_Dll.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "input.h"

void ConsoleInterface(int type, char *input, char *output)
{
	Input(type, input, output);
	return;
}