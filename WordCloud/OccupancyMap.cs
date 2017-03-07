using System;
using System.Collections.Generic;
using System.Drawing;

namespace WordCloudSharp
{
	internal class OccupancyMap : IntegralImage
	{
		public OccupancyMap(int outputImgWidth, int outputImgHeight) : base(outputImgWidth, outputImgHeight)
		{
		    this.Rand = new Random();
		}

		public OccupancyMap(Image mask) : base(new FastImage(mask))
		{
            this.Rand = new Random();
        }


        public bool TryFindUnoccupiedPosition(int strSizeX, int strSizeY, out int oPosX, out int oPosY)
		{
			oPosX = -1;
			oPosY = -1;

			var startPosX = this.Rand.Next(1, this.OutputImgWidth);
			var startPosY = this.Rand.Next(1, this.OutputImgHeight);

			int x, y, dx, dy;
			x = y = dx = 0;
			dy = -1;
			var width = this.OutputImgWidth - strSizeX;
			var height = this.OutputImgHeight - strSizeY;

			var t = Math.Max(width, height);
			var maxI = t * t;

			for (var i = 0; i < maxI; i++)
			{
				if ((-width / 2 <= x) && (x <= width / 2) && (-height / 2 <= y) && (y <= height / 2))
				{
					var posX = x + startPosX;
					var posY = y + startPosY;
					if (posY > 0 && posY < this.OutputImgHeight - strSizeY && posX > 0 && posX < this.OutputImgWidth - strSizeX)
					{
						if (GetArea(posX, posY, strSizeX, strSizeY) == 0)
						{
							oPosX = posX;
							oPosY = posY;
							return true;
						}
					}	
				}
				if ((x == y) || ((x < 0) && (x == -y)) || ((x > 0) && (x == 1 - y)))
				{
					t = dx;
					dx = -dy;
					dy = t;
				}
				x += dx;
				y += dy;
			}
			return false;
		}

		private List<int> XPoses { get; set; }

		private List<int> YPoses { get; set; } 

		private Random Rand { get; set; }
	}
}
