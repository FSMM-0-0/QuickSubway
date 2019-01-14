#include "input.h"
#include "subway.h"

Subway subway;
void Input(int argc, char *argv[])
{
	if (argc == 1) {
		string line;
		while (cin >> line) {
			subway.GetLine(line);
		}
	}
	else if (strcmp(argv[1], "/b") == 0){  //两站之间的最短线路(站数最少)
		string start = argv[2], end = argv[3];
		subway.Dijkstra(start, end, false);
	}
	else if (strcmp(argv[1], "/a") == 0) { //全遍历
		string start = argv[2];
		subway.Euler(start, false);
	}
	else if (strcmp(argv[1], "/c") == 0) { //两站之间的最短线路(换乘+3)
		string start = argv[2], end = argv[3];
		subway.Dijkstra(start, end, true);
	}
	else if (strcmp(argv[1], "/d") == 0) {  //全遍历(换乘+3)
		string start = argv[2];
		subway.Euler(start, true);
	}
	return;
}