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
	else if (strcmp(argv[1], "/b") == 0){
		string start = argv[2], end = argv[3];
		subway.Dijkstra(start, end);
	}
	else if (strcmp(argv[1], "/a") == 0) {
		string start = argv[2];
		subway.Euler(start);
	}
	return;
}