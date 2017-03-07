using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WordCloudSharp
{
    /// <summary>
    /// Image class for fast manipulation of bitmap data.
    /// </summary>
#if DEBUG
        public
#else
        internal
#endif
    class FastImage : IDisposable
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


        public FastImage(Image img)
        {
            this.PixelFormatSize = Image.GetPixelFormatSize(img.PixelFormat) / 8; 
            this.Stride = img.Width * this.PixelFormatSize;

            this.Bitmap = new Bitmap(img);

            var len = this.Stride * this.Bitmap.Height;
            this.Data = new byte[len];

            var bmpdata = this.Bitmap.LockBits(new Rectangle(0, 0, this.Bitmap.Width, this.Bitmap.Height),
                ImageLockMode.ReadOnly, this.Bitmap.PixelFormat);
            Marshal.Copy(bmpdata.Scan0, this.Data, 0, this.Data.Length);
            this.Bitmap.UnlockBits(bmpdata);
            this.Handle = GCHandle.Alloc(this.Data, GCHandleType.Pinned);
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
