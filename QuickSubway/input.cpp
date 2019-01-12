#include "input.h"
#include "subway.h"

void Input(int argc, char *argv[])
{
	Subway subway;

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
	return;
}