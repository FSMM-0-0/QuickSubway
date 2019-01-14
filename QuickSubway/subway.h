#pragma once
#include "stdafx.h"

using namespace std;

class Node  //����վ��
{
private:
	int id;
	int x, y;  //���ڽ�����ʾ����
public:
	string name;
	Node(int _id = 0, int _x = 0, int _y = 0, string _name = NULL) : id(_id), x(_x), y(_y), name(_name){}
};

class Line  //��������
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
	Node *node[350];  //����վ��
	int node_num;
	map<string, int> mp_node;  //վ���Ӧid
	Line *line[30];  //����վ��
	int line_num;
	map<string, int> mp_line; //����վ�߶�Ӧid
	vector<pair<int, int>> graph[350];  //������·ͼ

	//dijkstra���·
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
	int euler_start;  //��ʼ��
	int euler_edge;  //ŷ��ͼ�еı߱��
	int path_cot;   //���·�������߹���ĸ���
	int add_cot;    //����+3�ĸ��ӵ����
	struct Node_Edge {
		int to;
		int name;
	}euler_graph[350][2000], node_edge, euler_path[2000];
	//  ŷ��ͼ��                            ·����¼
	bool euler_vis[2000];
	void Euler_dfs(int st);
public:
	Subway();
	void GetLine(string line);  //�õ�line���ϵ�����վ
	void Dijkstra(string s_node, string e_node, bool exchange); //���s��e��վ��������·
	void Euler(string s_node, bool exchange); //��s��ʼվ��ȫ����
};