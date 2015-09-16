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

			tv_stratenplan_output.Text = stratenplan.StartPlan ();
		}
	}
}


