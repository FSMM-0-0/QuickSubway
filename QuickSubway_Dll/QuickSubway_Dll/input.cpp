#include "input.h"
#include "subway.h"

void Input(int type, char *input, char *output)
{
	bool file = true;
	Subway *subway;
	subway = new Subway(output, file);

	string str_output;
	if (file == false) {
		str_output = "地铁信息文件读取失败";
		strcpy(output, str_output.c_str());
		return;
	}

	if (type == 5) {  //线路上的所有站点,5
		string line = input;
		subway->GetLine(line, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 2) {  //两站之间的最短线路(站数最少),2
		string s = input, start, end;
		istringstream is(s);
		is >> start >> end;
		subway->Dijkstra(start, end, false, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 1) { //全遍历,1
		string start = input;
		subway->Euler(start, false, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 3) { //两站之间的最短线路(换乘+3),3
		string s = input, start, end;
		istringstream is(s);
		is >> start >> end;
		subway->Dijkstra(start, end, true, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 4) {  //全遍历(换乘+3),4
		string start = input;
		subway->Euler(start, true, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 6) {  //测试,6
		string filename = input;
		subway->Test(filename, str_output);
		strcpy(output, str_output.c_str());
	}
	return;
}