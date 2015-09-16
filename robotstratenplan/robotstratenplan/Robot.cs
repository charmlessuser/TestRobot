using System;

namespace robotstratenplan
{
	public class Robot
	{
		public string state = "east";

		private Stratenplan stratenplan;

		public Robot (Stratenplan stratenplan)
		{
			this.stratenplan = stratenplan;


		}

		public void voorwaarts(Stratenplan stratenplan)
		{
			this.stratenplan = stratenplan;

			if (kanVoorwaarts ()) {
				
				if (state == "east") {

					stratenplan.nux = stratenplan.startx;
					stratenplan.nuy = stratenplan.starty;
					stratenplan.startx = stratenplan.startx - 1;
				}

				if (state == "north") {

					stratenplan.nux = stratenplan.startx;
					stratenplan.nuy = stratenplan.starty;
					stratenplan.starty = stratenplan.starty-1;
				}
			
				if (state == "west") {

					stratenplan.nux = stratenplan.startx;
					stratenplan.nuy = stratenplan.starty;
					stratenplan.startx = stratenplan.startx + 1;
				}

				if (state == "south") {

					stratenplan.nux = stratenplan.startx;
					stratenplan.nuy = stratenplan.starty;
					stratenplan.starty = stratenplan.starty + 1;
				}
			}
		}


		public void linksom()
		{
			if (state == "east") {
				state = "north";
				stratenplan.cursortype = "^";
			}

			else if (state == "north") {
				state = "west";
				stratenplan.cursortype = "<";
			}

			else if (state == "west") {
				state = "south";
				stratenplan.cursortype = "V";
			}

			else if (state == "south") {
				state = "east";
				stratenplan.cursortype = ">";
			}
		}

		public bool kanVoorwaarts()
		{ 
			if (stratenplan.startx != 0 && state == "east" && stratenplan.plaats [stratenplan.startx - 1, stratenplan.starty] == "X") {
				return true;
			} else if (stratenplan.starty != 0 && state == "north" && stratenplan.plaats [stratenplan.startx, stratenplan.starty - 1] == "X") {
				return true;
			} else if (stratenplan.startx != stratenplan.plaats.GetLength(0) - 1 && state == "west" && stratenplan.plaats [stratenplan.startx + 1, stratenplan.starty] == "X") {
				return true;
			} else if (stratenplan.starty != stratenplan.plaats.GetLength(1) - 1 && state =="south" && stratenplan.plaats [stratenplan.startx, stratenplan.starty + 1 ] == "X"){
				return true;
			}

			else {
				return false;
			}
		}


		public string toon()
		{
			string plek = "";
			plek = "De huidige positie = " + "(" + stratenplan.startx.ToString () + "," + stratenplan.starty.ToString () + ")";
			plek += Environment.NewLine;
			plek += "De huidige richting = " + state;

			return plek;
		}
	}
}

