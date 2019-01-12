#include "subway.h"
#include "stdafx.h"
#define INF 0x3f3f3f3f
using namespace std;

//@Author:ZhuJingjing
//@Description:���캯������ȡ�����ļ���Ϣ
//@Prameter:
//@Return:
//@Date:2019-1-12
Subway::Subway()
{
	ifstream infile;
	ofstream outfile;

	infile.open("beijing-subway.txt", ios::in);
	if (!infile.is_open()) {
		cout << "������Ϣ�ļ���ȡʧ��" << endl;
		return;
	}
	char type;
	int id, x, y, num;
	string name;
	node_num = 0; line_num = 0; mp_line.clear();

	while (!infile.eof()){
		infile >> type;
		if (type == '#') {  //վ
			infile >> id >> name >> x >> y;
			node[++node_num] = new Node(id, x, y, name);
			mp_node[name] = id;
		}
		else if (type == '%'){  //��
			infile >> name >> num;
			if (mp_line.find(name) == mp_line.end()) {
				mp_line[name] = ++line_num;
			}
			line[line_num] = new Line(num, name);
			for (int i = 1; i <= num; i++) {
				infile >> id;
				line[line_num]->vec.push_back(id);
			}
		}
		else if (type == '@') {  //ͼ
			infile >> x >> y >> name;
			graph[x].push_back(make_pair(y, mp_line[name]));
		}
	}
	infile.close();
}

//@Author:ZhuJingjing
//@Description:�õ�tmp_line��·������վ
//@Prameter:��������
//@Return:
//@Date:2019-1-12
void Subway::GetLine(string tmp_line)
{
	vector<int>::iterator iter;
	for (iter = line[mp_line[tmp_line]]->vec.begin(); iter != line[mp_line[tmp_line]]->vec.end(); iter++) {
		cout << node[*iter]->name << endl;
	}
	cout << endl;
}

//@Author:ZhuJingjing
//@Description:dijkstra���s_node��e_node��վ��������·
//@Prameter:�����յ�վ��
//@Return:
//@Date:2019-1-12
int Subway::dis[350];
void Subway::Dijkstra(string s_node, string e_node)
{	
	int s = mp_node[s_node], e = mp_node[e_node];

	int change[350];
	memset(dis, INF, sizeof(dis));
	memset(vis, false, sizeof(vis));
	vector<pair<int, int>> path(350);
	pair<int, int> top, to;
	que.push(make_pair(s, 0));
	dis[s] = 0;
	path[s] = make_pair(s, 0);

	bool flag = false;
	while(!que.empty()) {
	    top = que.top();
		que.pop();

		if (vis[top.first]) continue;
		vis[top.first] = true;
		
		for (unsigned int i = 0; i < graph[top.first].size(); i++) {
			to = graph[top.first][i];
			if (!vis[to.first]) {
				int tmp = dis[top.first] + 1;
				if (tmp < dis[to.first]) {
					dis[to.first] = tmp;
					que.push(to);

					//·����¼
					path[to.first] = make_pair(top.first, to.second);
					if (path[top.first].second == 0) {  //��һ��վ
						change[to.first] = 0;
					}
					else if (path[top.first].second == to.second) { //������
						change[to.first] = 0;
					}
					else { //����
						change[to.first] = to.second;
					}
					
					if (to.first == e) {
						flag = true;
						break;
					}
				}
			}
		}
		if (flag) break;
	}

	string str = "\n";
	int tmp = e;
	int cot = 0;
	while (tmp != s) {
		cot++;
		str = '\n' + node[tmp]->name + str;
		if (change[tmp])
			str = " ����" + line[path[tmp].second]->name + str;
		tmp = path[tmp].first;
	}
	str = node[tmp]->name + str;
	cout << cot + 1 << endl << str;
}
