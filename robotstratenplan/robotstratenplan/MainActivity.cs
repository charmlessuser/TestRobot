using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace robotstratenplan
{
	[Activity (Label = "robotstratenplan", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private Stratenplan stratenplan;
		private Robot robot;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			Button btn_voorwaarts = FindViewById<Button> (Resource.Id.btn_voorwaarts);
			Button btn_linksom = FindViewById<Button> (Resource.Id.btn_linksom);
			Button btn_detail = FindViewById<Button> (Resource.Id.btn_detail);
			Button btn_bevat = FindViewById<Button> (Resource.Id.btn_bevat);

			EditText et_coordinaten = FindViewById<EditText> (Resource.Id.et_coordinaten);

			TextView tv_stratenplan_output = FindViewById<TextView> (Resource.Id.tv_stratenplan);
			TextView tv_debug = FindViewById<TextView> (Resource.Id.tv_debug);

			stratenplan = new Stratenplan();
			robot = new Robot(stratenplan);


			btn_voorwaarts.Click+= delegate {

				robot.voorwaarts(stratenplan);
				tv_stratenplan_output.Text = stratenplan.StartPlan();
			};

			btn_linksom.Click += delegate {
				robot.linksom();
				tv_debug.Text = robot.state.ToString();
				tv_stratenplan_output.Text = stratenplan.StartPlan ();
			};

			btn_detail.Click += delegate {
				tv_debug.Text = robot.toon();
			};

			btn_bevat.Click += delegate {

				string temp_str = et_coordinaten.Text;
				string[] tijdelijk = temp_str.Split(new String[]{ "," }, StringSplitOptions.None);
				int temp_x = Convert.ToInt32 (tijdelijk [0]) ;
				int temp_y = Convert.ToInt32 (tijdelijk [1]) ; 
				if (temp_x < 8&&temp_y <11){
					if (stratenplan.bevat(temp_x,temp_y)){
						tv_debug.Text = "De coördinaten ("+temp_x.ToString()+","+temp_y.ToString()+")" + " Zitten in dit stratenplan";
					}
					else{
						tv_debug.Text = "De coördinaten ("+temp_x.ToString()+","+temp_y.ToString()+")" + " Zitten niet in dit stratenplan";
					}
				}
				else{
					tv_debug.Text = "De gekozen coördinaten liggen buiten het bereik.";
				}

			};
		
			tv_stratenplan_output.Text = stratenplan.StartPlan ();
		}
	}
}


