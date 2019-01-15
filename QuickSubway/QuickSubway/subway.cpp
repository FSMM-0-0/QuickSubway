#include "subway.h"

#define INF 0x3f3f3f3f
using namespace std;

int unit_test_cot = 0;
string unit_test[100];

//@Author:ZhuJingjing
//@Description:构造函数，读取地铁文件信息
//@Prameter:
//@Return:
//@Date:2019-1-12
Subway::Subway()
{
	ifstream infile;

	euler_edge = 0;
	memset(euler_graph, 0, sizeof(euler_graph));

	infile.open("beijing-subway.txt", ios::in);
	if (!infile.is_open()) {
		cout << "地铁信息文件读取失败" << endl;
		return;
	}
	char type;
	int id, x, y, num;
	string name;

	line_num = 0;
	node_num = 0;
	mp_line.clear();
	edge_exist.clear();

	while (!infile.eof()){
		infile >> type;
		if (type == '#') {  //站
			infile >> id >> name >> x >> y;
			node[++node_num] = new Node(id, x, y, name);
			mp_node[name] = id;
		}
		else if (type == '%'){  //线
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
		else if (type == '@') {  //图
			infile >> x >> y >> name;

			//dijkstra
			graph[x].push_back(make_pair(y, mp_line[name]));
			graph[y].push_back(make_pair(x, mp_line[name]));

			//euler
			node_edge.to = y; node_edge.name = mp_line[name];
			euler_graph[x][++euler_edge] = node_edge;
			node_edge.to = x; node_edge.name = mp_line[name];
			euler_graph[y][euler_edge] = node_edge;

			//test
			edge_exist[make_pair(x, y)] = true;
			edge_exist[make_pair(y, x)] = true;
		}
		else if (type == '-') {  //全遍历中要删的边
			infile >> x >> y >> name;
			
			//dijkstra
			graph[x].push_back(make_pair(y, mp_line[name]));
			graph[y].push_back(make_pair(x, mp_line[name]));

			//test
			edge_exist[make_pair(x, y)] = true;
			edge_exist[make_pair(y, x)] = true;
		}
		else if (type == '+') { //全遍历中要增加的边
			infile >> x >> y >> name;

			//euler
			node_edge.to = y; node_edge.name = mp_line[name];
			euler_graph[x][++euler_edge] = node_edge;
			node_edge.to = x; node_edge.name = mp_line[name];
			euler_graph[y][euler_edge] = node_edge;
		}
	}
	infile.close();
}

//@Author:ZhuJingjing
//@Description:得到tmp_line线路的所有站
//@Prameter:地铁线名
//@Return:
//@Date:2019-1-12
void Subway::GetLine(string tmp_line)
{
	vector<int>::iterator iter;
	if (tmp_line == "大兴线" || tmp_line == "4号线/大兴线") tmp_line = "4号线";
	
	if (mp_line.find(tmp_line) == mp_line.end()) {
		cout << "未找到该线路" << endl;
		unit_test[unit_test_cot++] = "未找到该线路";
		unit_test_cot = 0;
		return;
	}
	for (iter = line[mp_line[tmp_line]]->vec.begin(); iter != line[mp_line[tmp_line]]->vec.end(); iter++) {
		cout << node[*iter]->name << endl;
		unit_test[unit_test_cot++] = node[*iter]->name;
	}
	unit_test_cot = 0;
	cout << endl;
}

//@Author:ZhuJingjing
//@Description:dijkstra输出s_node到e_node的站数最少线路
//@Prameter:起点和终点站名,是否换乘 true or false
//@Return:
//@Date:2019-1-12
//@Update:2019-1-14
int Subway::dis[350];
void Subway::Dijkstra(string s_node, string e_node, bool exchange)
{	
	if (mp_node.find(s_node) == mp_node.end() || mp_node.find(e_node) == mp_node.end()) {
		cout << "未找到对应站名" << endl;
		unit_test[unit_test_cot++] = "未找到对应站名";
		unit_test_cot = 0;
		return;
	}

	int s = mp_node[s_node], e = mp_node[e_node];

	int change[350];
	memset(dis, INF, sizeof(dis));
	memset(vis, false, sizeof(vis));
	memset(change, 0, sizeof(change));
	vector<pair<int, int>> path(350);
	pair<int, int> top, to;
	que.push(make_pair(s, 0));
	dis[s] = 0;
	path[s] = make_pair(s, 0);

	int add_cot = 0;

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

				//换乘+3的情况
				if (exchange && path[top.first].second != 0 && path[top.first].second != to.second) 
					tmp += 3;

				if (tmp < dis[to.first]) {
					dis[to.first] = tmp;
					que.push(to);

					//路径记录
					path[to.first] = make_pair(top.first, to.second);
					if (path[top.first].second == 0)   //第一个站
						change[to.first] = 0;
					else if (path[top.first].second == to.second)  //不换乘
						change[to.first] = 0;			
					else  //换乘
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
		if (change[tmp]) {
			str = " 换乘" + line[path[tmp].second]->name + str;
			add_cot += 3;
		}
		tmp = path[tmp].first;
	}
	str = node[tmp]->name + str;
	if (exchange)
		cout << add_cot + cot + 1 << endl << str;
	else
		cout << cot + 1 << endl << str;
	unit_test[unit_test_cot++] = str;
	unit_test_cot = 0;

	if (exchange) {
		unit_test[unit_test_cot++] = to_string(add_cot + cot + 1);
		unit_test_cot = 0;
	}
}

//@Author:ZhuJingjing
//@Description:Euler回路dfs
//@Prameter:当前站st编号,是否换乘 true or false
//@Return:
//@Date:2019-1-13
void Subway::Euler_dfs(int st)
{
	for (int i = 1; i <= euler_edge; i++) {
		if (!euler_vis[i] && euler_graph[st][i].to) {
			euler_vis[i] = true;
			Euler_dfs(euler_graph[st][i].to);
			node_edge.to = euler_graph[st][i].to; node_edge.name = euler_graph[st][i].name;
			if (i != euler_edge)
				euler_path[++path_cot] = node_edge;
			if (euler_path[path_cot - 1].name != 0 && euler_path[path_cot].name != euler_path[path_cot - 1].name) 
				add_cot += 3;
		}
	}
	int ddd = 0;
	ddd++;
}

//@Author:ZhuJingjing
//@Description:Euler回路求全站点遍历
//@Prameter:起点站名,是否换乘+3 true or false
//@Return:
//@Date:2019-1-13
//@Update:2019-1-14
void Subway::Euler(string s_node, bool exchange)
{
	if (mp_node.find(s_node) == mp_node.end()) {
		cout << "未找到对应站名" << endl;
		unit_test[unit_test_cot++] = "未找到对应站名";
		unit_test_cot = 0;
		return;
	}

	memset(euler_vis, false, sizeof(euler_vis));
	memset(euler_path, 0, sizeof(euler_path));
	path_cot = 0; add_cot = 0;
	euler_start = mp_node[s_node];
	Euler_dfs(euler_start);
	node_edge.to = euler_start; node_edge.name = 0;
	euler_path[++path_cot] = node_edge;

	ofstream outfile;
	outfile.open("all_node_visit.txt", ios::out);
	if (!outfile.is_open()) {
		cout << "地铁全遍历输出文件创建失败" << endl;
		return;
	}

	if (exchange) {
		cout << path_cot + add_cot << endl;
		outfile << path_cot + add_cot << endl;
		unit_test[unit_test_cot++] = to_string(path_cot + add_cot);
		unit_test_cot = 0;
	}
	else {
		cout << path_cot << endl;
		outfile << path_cot << endl;
		unit_test[unit_test_cot++] = to_string(path_cot);
		unit_test_cot = 0;
	}

	for (int i = path_cot; i >= 1; i--) {
		if (i != path_cot && euler_path[i].name && euler_path[i + 1].name && euler_path[i].name != euler_path[i + 1].name) {
			cout << " 换乘" << line[euler_path[i].name]->name << endl;
			//outfile << " 换乘" << line[euler_path[i].name]->name << endl;
		}
		else if (i != path_cot){
			cout << endl;
		}
		cout << node[euler_path[i].to]->name;
		outfile << node[euler_path[i].to]->name << endl;

		//cout << i << ": " << node[euler_path[i]]->name << endl;
	}
	outfile.close();
}

//@Author:ZhuJingjing
//@Description:测试全遍历输出
//@Prameter:测试文件名
//@Return:
//@Date:2019-1-14
void Subway::Test(string filename)
{
	ifstream infile;

	infile.open(filename, ios::in);
	if (!infile.is_open()) {
		cout << "地铁全遍历文件读取失败" << endl;
		return;
	}

	memset(node_exist, false, sizeof(node_exist));

	bool flag = true;
	int test_path_cot;
	int st_node = 0;
	int ed_node = 0;
	int last_node = 0;
	int cot = -1;
	string node_name;
	while (!infile.eof()) {
		if (cot == -1) {  //输入总站数
			infile >> test_path_cot;
			cot = 0;
		}
		else if (cot == 0){  //起点
			infile >> node_name;
			node_exist[mp_node[node_name]] = true;
			last_node = mp_node[node_name];
			st_node = mp_node[node_name];
			cot++;
		}
		else {
			infile >> node_name;
			node_exist[mp_node[node_name]] = true;
			//车站遍历次序不合理
			if (edge_exist.find(make_pair(last_node, mp_node[node_name])) == edge_exist.end()) {
				cout << "error: " << node[last_node]->name << " " << node_name << endl;
				string str = "error: " + node[last_node]->name + " " + node_name;
				unit_test[0] = str;
				flag = false;
				break;
			}
			last_node = mp_node[node_name];
			ed_node = mp_node[node_name];
			cot++;
		}

		infile.get();
		if (infile.peek() == '\n') break;
	}
	infile.close();

	bool output = false;
	if (flag) {
		for (int i = 1; i <= node_num; i++) {
			if (node_exist[i] == false) {
				if (!output) { //有遗漏的站点
					cout << "false:" << endl;
					output = true;
				}
				cout << node[i]->name << " ";
				unit_test[0] = node[i]->name;
			}
		}
		if (!output) {
			if (test_path_cot != cot) { //车站的数量错误
				cout << "false" << endl;
				unit_test[0] = "false";
			}
			else if (st_node != ed_node) {  //起始点和终点不同
				cout << "false" << endl;
				unit_test[0] = "false";
			}
			else { //结果正确
				cout << "true" << endl;
				unit_test[0] = "true";
			}
		}
		else {
			cout << endl;
		}
	}
}
