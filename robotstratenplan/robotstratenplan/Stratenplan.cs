using System;

namespace robotstratenplan
{
	public class Stratenplan
	{
		public int startx = 5;
		public int starty = 10;
		public int nux = 0;
		public int nuy = 0;
		public string cursortype = ">";

		public string[,] plaats;
		public Stratenplan ()
		{


			plaats = new string[8, 11];
			for (int i = 0; i < plaats.GetLength (0); i++) {
				for (int j = 0; j < plaats.GetLength (1); j++) {
					plaats [i, j] = "O";
				}
			}

			string[] x_plaatsen = new string[] {
				"3,0",
				"3,1",   
				"3,2",
				"3,3",
				"3,4",
				"3,5",
				"3,6",
				"3,7",  
				"3,8", 
				"3,9", 
				"3,10",
				"1,0",
				"2,0",
				"4,0", 
				"5,0", 
				"0,3",
				"1,3", 
				"2,3",
				"4,5",
				"5,5",
				"6,5",
				"7,5",
				"1,8",
				"2,8",
				"4,8",
				"5,8",
				"6,8", 
				"4,10",   
				"5,10"
			};

			foreach (string s in x_plaatsen) {
				string[] temp = s.Split (new String[]{ "," }, StringSplitOptions.None);
				int index_x = Convert.ToInt32 (temp [0]);
				int index_y = Convert.ToInt32 (temp [1]);
				plaats [index_x, index_y] = "X";
			}
		}

		public string ShowPlan()
		{
			string output = "";
			for (int i = 0; i < plaats.GetLength (1); i++) {
				for (int j = plaats.GetLength (0)-1 ; j >= 0; j--){
					output += plaats [j, i] + " ";
			}
				output += Environment.NewLine;
		}
		return output;
		}
	
		public string StartPlan()
		{
			plaats [nux, nuy] = "X";
			plaats [startx,starty] = cursortype;
			string output = ShowPlan ();

			return output;
		}

		public bool bevat(int x, int y){
			if (plaats [x, y] == "X") {
				return true;
			} else {
				return false;
			}
		}
	
	}}

