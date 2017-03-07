using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WordCloud
{
	/// <summary>
	/// Image class for fast manipulation of bitmap data.
	/// </summary>
	internal class FastImage : IDisposable
	{
		public FastImage(int width, int height, PixelFormat format)
		{
		    this.PixelFormatSize = Image.GetPixelFormatSize(format) / 8;
		    this.Stride = width*this.PixelFormatSize;

		    this.Data = new byte[this.Stride * height];
		    this.Handle = GCHandle.Alloc(this.Data, GCHandleType.Pinned);
			var pData = Marshal.UnsafeAddrOfPinnedArrayElement(this.Data, 0);
		    this.Bitmap = new Bitmap(width, height, this.Stride, format, pData);
		}

		public int Width { get { return this.Bitmap.Width; } }

		public int Height { get { return this.Bitmap.Height; } }

		public int PixelFormatSize { get; set; }

		public GCHandle Handle { get; set; }

		public int Stride { get; set; }

		public byte[] Data { get; set; }

		public Bitmap Bitmap { get; set; }
		public void Dispose()
		{
		    this.Handle.Free();
		    this.Bitmap.Dispose();
		}
	}
}
