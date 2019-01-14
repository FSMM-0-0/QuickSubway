#include "subway.h"
#include "stdafx.h"
#define INF 0x3f3f3f3f
using namespace std;

//@Author:ZhuJingjing
//@Description:Euler��·dfs
//@Prameter:
//@Return:
//@Date:2019-1-13
void Subway::Euler_dfs(int st)
{
	for (int i = 1; i <= euler_edge; i++) {
		if (!euler_vis[i] && euler_graph[st][i].to) {
			euler_vis[i] = true;
			Euler_dfs(euler_graph[st][i].to);
			euler_path[++path_cot] = st;
		}
	}
}

//@Author:ZhuJingjing
//@Description:���캯������ȡ�����ļ���Ϣ
//@Prameter:
//@Return:
//@Date:2019-1-12
Subway::Subway()
{
	ifstream infile;
	ofstream outfile;

	euler_edge = 0;
	memset(euler_graph, 0, sizeof(euler_graph));

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
			graph[y].push_back(make_pair(x, mp_line[name]));

			node_edge.to = y; node_edge.name = mp_line[name];
			euler_graph[x][++euler_edge] = node_edge;
			node_edge.to = x; node_edge.name = mp_line[name];
			euler_graph[y][euler_edge] = node_edge;
		}
		else if (type == '-') {  //ȫ������Ҫɾ�ı�
			infile >> x >> y >> name;
			graph[x].push_back(make_pair(y, mp_line[name]));
			graph[y].push_back(make_pair(x, mp_line[name]));
		}
		else if (type == '+') { //ȫ������Ҫ���ӵı�
			infile >> x >> y >> name;
			node_edge.to = y; node_edge.name = mp_line[name];
			euler_graph[x][++euler_edge] = node_edge;
			node_edge.to = x; node_edge.name = mp_line[name];
			euler_graph[y][euler_edge] = node_edge;
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
	if (tmp_line == "������" || tmp_line == "4����/������") tmp_line = "4����";
	
	if (mp_line.find(tmp_line) == mp_line.end()) {
		cout << "δ�ҵ�����·" << endl;
		return;
	}
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
	if (mp_node.find(s_node) == mp_node.end() || mp_node.find(e_node) == mp_node.end()) {
		cout << "δ�ҵ���Ӧվ��" << endl;
		return;
	}

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
					if (path[top.first].second == 0)   //��һ��վ
						change[to.first] = 0;
					else if (path[top.first].second == to.second)  //������
						change[to.first] = 0;			
					else  //����
						change[to.first] = to.second;
										
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

//@Author:ZhuJingjing
//@Description:Euler��·��ȫվ�����
//@Prameter:���վ��
//@Return:
//@Date:2019-1-13
void Subway::Euler(string s_node)
{
	if (mp_node.find(s_node) == mp_node.end()) {
		cout << "δ�ҵ���Ӧվ��" << endl;
		return;
	}

	memset(euler_vis, false, sizeof(euler_vis));
	memset(euler_path, 0, sizeof(euler_path));
	path_cot = 0;
	euler_start = mp_node[s_node];
	euler_path[++path_cot] = euler_start;
	Euler_dfs(euler_start);
	cout << path_cot << endl;
	for (int i = path_cot; i >= 1; i--) {
		cout << node[euler_path[i]]->name << endl;
		//cout << i << ": " << node[euler_path[i]]->name << endl;
	}
}
