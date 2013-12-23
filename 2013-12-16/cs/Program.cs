using System;

namespace holidaytree
{
	class MainClass
	{
		private static void ErrUsage()
		{
			const string USAGESTRING = "Usage: HEIGHT BASECHAR TREECHAR\nWhere:\n" +
			                        "\tHEIGHT is between 3 and 21 inclusive and is odd,\n" +
			                        "\tand BASECHAR and TREECHAR are single characters.";
			Console.WriteLine (USAGESTRING);
			Environment.Exit (1);
	}

		public static void Main (string[] args)
		{
			if (args.Length != 3)
				ErrUsage ();

			int rows;
			var treechar = args [2];
			var basechar = args [1];

			var result = int.TryParse(args[0], out rows);
			if (!result) ErrUsage();

			if (rows < 3 || rows > 21 || rows % 2 != 1)	ErrUsage ();
			if (treechar.Length != 1 || basechar.Length != 1) ErrUsage ();

			var tree_rows = rows - 1;
			var final_row_width = (tree_rows * 2) - 1;

			for (int i = 0; i < tree_rows; i++) {
				int padding = (final_row_width / 2) - i;
				int row_width = ((i * 2) + 1);

				for (int j = 0; j < padding; j++) Console.Write (' ');

				for (int j = 0; j < row_width; j++)	Console.Write (treechar);
				
				Console.WriteLine ();
			}

			var bottom_padding = (final_row_width - 3) / 2;
			for (int i = 0; i < bottom_padding; i++) Console.Write (' ');

			for (int i = 0; i < 3; i++) Console.Write (basechar);

			Console.WriteLine ();
		}
	}
}