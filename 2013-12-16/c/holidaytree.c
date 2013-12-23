#include <stdlib.h>
#include <stdio.h>
#define ERRUSAGE() fprintf(stderr, "Usage: %s HEIGHT BASECHAR TREECHAR\n" \
		"Where:\n" \
		"\tHEIGHT is between 3 and 21 inclusive " \
		"and is odd,\n" \
		"\tand BASECHAR and TREECHAR are single characters.\n", argv[0]); \
return 1;
#define DITER(x, y) for (int x = 0; x < y; x++)
#define ITER(z) DITER(i, z)
#define basechar argv[2][0]
#define treechar argv[3][0]

int main(int argc, char * argv[])
{
	if (argc != 4) { ERRUSAGE(); }

	char rows = (char) strtol(argv[1], NULL, 10);

	// implicit error checking: 0 is invalid anyway
	if ( rows < 3 || rows > 21 || (rows % 2) != 1 ) {
		ERRUSAGE();
	}

	char tree_rows = rows - 1;

	char final_row_width = (tree_rows * 2) - 1;

	ITER(tree_rows) {
		char padding = (final_row_width / 2) - i;
		char row_width = ((i * 2) + 1);
		DITER(j, padding) putchar((int)' ');
		DITER(j, row_width) putchar((int)treechar);
		putchar('\n');
	}

	char bottom_padding = (final_row_width - 3) / 2;
	ITER(bottom_padding) putchar((int)' ');

	ITER(3) putchar((int)basechar);

	putchar('\n');
	return EXIT_SUCCESS;
}
