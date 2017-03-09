using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
		    //BuildBmp();return;
            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormMain());
		}

	    private static void BuildBmp()
	    {
	        var width = 1000;
	        var height = 1000;
            using (var bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed))
            {
                var bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite,
                    PixelFormat.Format8bppIndexed);
                var len = bmpdata.Stride * bmp.Height;
                var buffer = new byte[len];
                var bufIndex = 0;

                for (var i = 0 ; i < height ; i++)
                {
                    for (var j = 0; j < width; j++)
                    {
                        if(j < 800 && j > 200 && i < 800 && i > 200)
                            buffer[bufIndex++] = 0;
                        else
                            buffer[bufIndex++] = 255;
                    }
                }

                Marshal.Copy(buffer, 0, bmpdata.Scan0, buffer.Length);
                bmp.UnlockBits(bmpdata);

                bmp.Save(Path.GetRandomFileName() + ".bmp");
            }
        }


	    private static void DrawStrOnBmp()
	    {
	    }
	}
}
