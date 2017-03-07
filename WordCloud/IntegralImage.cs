using System;
using System.Diagnostics;
using System.Linq;
namespace WordCloudSharp
{
	internal class IntegralImage
	{
		public IntegralImage(int outputImgWidth, int outputImgHeight)
		{
		    this.Integral = new uint[outputImgWidth,outputImgHeight];
		    this.OutputImgWidth = outputImgWidth;
		    this.OutputImgHeight = outputImgHeight;
		}

        public IntegralImage(FastImage image)
        {
            this.Integral = new uint[image.Width, image.Height];
            this.OutputImgWidth = image.Width;
            this.OutputImgHeight = image.Height;
            InitUpdate(image, 0, 0);
        }

        public void InitUpdate(FastImage image, int posX, int posY)
        {
            if (posX < 1) posX = 1;
            if (posY < 1) posY = 1;
            var pixelSize = Math.Min(3, image.PixelFormatSize);
            for (var i = posY; i < image.Height; ++i)
            {
                for (var j = posX; j < image.Width; ++j)
                {
                    byte pixel = 0;
                    for (var p = 0; p < pixelSize; ++p)
                    {
                        pixel |= image.Data[i * image.Stride + j * image.PixelFormatSize + p];
                    }
                    if (pixel != 0) pixel = 1;
                    this.Integral[j, i] = pixel + this.Integral[j - 1, i] + this.Integral[j, i - 1] - this.Integral[j - 1, i - 1];
                }
            }
#if DEBUG

            //var oResult = new uint[this.OutputImgWidth * this.OutputImgHeight];
            //Buffer.BlockCopy(Integral, 0, oResult, 0, Integral.Length * 4);
            //foreach (var g in oResult.GroupBy(n => n))
            //{
            //    Debug.WriteLine(g.Key + ", " + g.Count());
            //}
#endif
        }
        public void Update(FastImage image, int posX, int posY)
		{
			if (posX < 1) posX = 1;
			if (posY < 1) posY = 1;
		    var pixelSize = Math.Min(3, image.PixelFormatSize);
			for (var i = posY; i < image.Height; ++i)
			{
				for (var j = posX; j < image.Width; ++j)
				{
					byte pixel = 0;
					for (var p = 0; p < pixelSize; ++p)
					{
						pixel |= image.Data[i * image.Stride + j * image.PixelFormatSize + p];
					}
				    this.Integral[j, i] = pixel + this.Integral[j - 1, i] + this.Integral[j, i - 1] - this.Integral[j - 1, i - 1];
				}
			}
        }

		public ulong GetArea(int xPos, int yPos, int sizeX, int sizeY)
		{
			ulong area = this.Integral[xPos, yPos] + this.Integral[xPos + sizeX, yPos + sizeY];
			area -= this.Integral[xPos + sizeX, yPos] + this.Integral[xPos, yPos + sizeY];
			return area;
		}

		public int OutputImgWidth { get; set; }

		public int OutputImgHeight { get; set; }

		protected uint[,] Integral { get; set; }
	}
}
