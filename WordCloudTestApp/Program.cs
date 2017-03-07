using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCloudSharp;

namespace WordCloudTestApp
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            //using(var bmp = new Bitmap(@"C:\Users\ZhiYong\Desktop\stormtrooper_mask.png"))
            //using (var fimg = new FastImage(bmp))
            //{

            //}
            //return;


		    Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
