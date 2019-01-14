#pragma once
#include "stdafx.h"

using namespace std;

class Node  //地铁站类
{
private:
	int id;
	int x, y;  //用于界面显示坐标
public:
	string name;
	Node(int _id = 0, int _x = 0, int _y = 0, string _name = NULL) : id(_id), x(_x), y(_y), name(_name){}
};

class Line  //地铁线类
{
private:
	int num;
public:
	string name;
	vector<int> vec;
	Line(int _num = 0, string _name = NULL) :num(_num), name(_name) 
	{
		vec.clear();
	};
};

class Subway
{
private:
	Node *node[350];  //地铁站点
	int node_num;
	map<string, int> mp_node;  //站点对应id
	Line *line[30];  //地铁站线
	int line_num;
	map<string, int> mp_line; //地铁站线对应id
	vector<pair<int, int>> graph[350];  //地铁线路图

	//dijkstra最短路
	bool vis[350];
	static int dis[350];
	struct cmp 
	{
		bool operator()(pair<int, int> a, pair<int, int> b){
			return dis[a.first] > dis[b.first];
		}
	};
	priority_queue<pair<int, int>, vector<pair<int, int>>, cmp> que;

	//euler
	int euler_start;  //起始点
	int euler_edge;  //欧拉图中的边编号
	int path_cot;   //输出路径，即走过点的个数
	int add_cot;    //换乘+3的附加点个数
	struct Node_Edge {
		int to;
		int name;
	}euler_graph[350][2000], node_edge, euler_path[2000];
	//  欧拉图，                            路径记录
	bool euler_vis[2000];
	void Euler_dfs(int st);
public:
	Subway();
	void GetLine(string line);  //得到line线上的所有站
	void Dijkstra(string s_node, string e_node, bool exchange); //求从s到e的站数最少线路
	void Euler(string s_node, bool exchange); //从s开始站点全遍历
};