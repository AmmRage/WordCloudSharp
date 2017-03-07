using System;

namespace WordCloud
{
	internal class IntegralImage
	{
		public IntegralImage(int outputImgWidth, int outputImgHeight)
		{
		    this.Integral = new uint[outputImgWidth,outputImgHeight];
		    this.OutputImgWidth = outputImgWidth;
		    this.OutputImgHeight = outputImgHeight;
		}

		public void Update(FastImage image)
		{
			Update(image, 1, 1);
		}

		public void Update(FastImage image, int posX, int posY)
		{
			if (posX < 1) posX = 1;
			if (posY < 1) posY = 1;

			for (var i = posY; i < image.Height; ++i)
			{
				for (var j = posX; j < image.Width; ++j)
				{
					byte pixel = 0;
					for (var p = 0; p < image.PixelFormatSize; ++p)
					{
						pixel |= image.Data[i*image.Stride + j*image.PixelFormatSize + p];
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
