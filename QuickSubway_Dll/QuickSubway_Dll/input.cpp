#include "input.h"
#include "subway.h"

void Input(int type, char *input, char *output)
{
	bool file = true;
	Subway *subway;
	subway = new Subway(output, file);

	string str_output;
	if (file == false) {
		str_output = "������Ϣ�ļ���ȡʧ��";
		strcpy(output, str_output.c_str());
		return;
	}

	if (type == 5) {  //��·�ϵ�����վ��,5
		string line = input;
		subway->GetLine(line, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 2) {  //��վ֮��������·(վ������),2
		string s = input, start, end;
		istringstream is(s);
		is >> start >> end;
		subway->Dijkstra(start, end, false, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 1) { //ȫ����,1
		string start = input;
		subway->Euler(start, false, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 3) { //��վ֮��������·(����+3),3
		string s = input, start, end;
		istringstream is(s);
		is >> start >> end;
		subway->Dijkstra(start, end, true, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 4) {  //ȫ����(����+3),4
		string start = input;
		subway->Euler(start, true, str_output);
		strcpy(output, str_output.c_str());
	}
	else if (type == 6) {  //����,6
		string filename = input;
		subway->Test(filename, str_output);
		strcpy(output, str_output.c_str());
	}
	return;
}