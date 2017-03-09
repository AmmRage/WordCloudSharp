using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WordCloudSharp
{
	internal class IntegralImage
	{
        #region attributes & constructors
        public int OutputImgWidth { get; set; }

        public int OutputImgHeight { get; set; }

        protected uint[,] Integral { get; set; }

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
            //InitMask(image);
        }

        #endregion

        private void InitMask(FastImage image)
        {
            Update(CropImage(image), 1 ,1);

            //var pixelSize = Math.Min(3, image.PixelFormatSize);
            //for (var i = 1; i < image.Height; ++i)
            //{
            //    for (var j = 1; j < image.Width; ++j)
            //    {
            //        byte pixel = 0;
            //        for (var p = 0; p < pixelSize; ++p)
            //        {
            //            pixel |= image.Data[i * image.Stride + j * image.PixelFormatSize + p];
            //        }
            //        if (pixel != 0)
            //            pixel = 1;
            //        //this.Integral[j, i] = pixel + this.Integral[j - 1, i] + this.Integral[j, i - 1] - this.Integral[j - 1, i - 1];
            //        this.Integral[i, j] = pixel + this.Integral[i, j - 1] + this.Integral[i - 1,j] - this.Integral[i - 1, j - 1];
            //    }
            //}
#if DEBUG
            SaveIntegralImageToBitmap();

            //var oResult = new uint[this.OutputImgWidth * this.OutputImgHeight];
            //Buffer.BlockCopy(Integral, 0, oResult, 0, Integral.Length * 4);
            //foreach (var g in oResult.GroupBy(n => n))
            //{
            //    Debug.WriteLine(g.Key + ", " + g.Count());
            //}

            //var strbuilder = new StringBuilder();
            //for (var i = 1; i < 1000; i++)
            //{
            //    for (var j = 1; j < 1000; j++)
            //    {
            //        strbuilder.Append((this.Integral[i, j] - this.Integral[i, j - 1] - this.Integral[i - 1, j] + this.Integral[i - 1, j - 1]).ToString() + ", ");
            //    }
            //    strbuilder.Append(Environment.NewLine);
            //}
            //File.WriteAllText("integral.csv", strbuilder.ToString());
            //Debug.WriteLine("Done initalizing");
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
                    //if (pixel != 0)
                    //    pixel = 1;
                    this.Integral[j, i] = pixel + this.Integral[j - 1, i] + this.Integral[j, i - 1] - this.Integral[j - 1, i - 1];
                    //this.Integral[i, j] += pixel + this.Integral[i, j - 1] + this.Integral[i - 1, j] - this.Integral[i - 1, j - 1];
                }
            }
#if DEBUG
            //IntegralImageToBitmap(this.Integral);
            //var strbuilder = new StringBuilder();
            //string cell = "";
            //for (var i = 1; i < image.Height; i++)
            //{
            //    for (var j = 1; j < image.Width; j++)
            //    {
            //        if ((this.Integral[i, j] - this.Integral[i, j - 1] - this.Integral[i - 1, j] + this.Integral[i - 1, j - 1]) == 0)
            //            cell = "0,";
            //        else
            //            cell = "1,";
            //        strbuilder.Append(cell);
            //    }
            //    strbuilder.Append(Environment.NewLine);
            //}
            //File.WriteAllText("integral.csv", strbuilder.ToString());
            //Debug.WriteLine("Done initalizing");
#endif
        }

        public ulong GetArea(int xPos, int yPos, int sizeX, int sizeY)
		{
			ulong area = this.Integral[xPos, yPos] + this.Integral[xPos + sizeX, yPos + sizeY];
			area -= this.Integral[xPos + sizeX, yPos] + this.Integral[xPos, yPos + sizeY];
			return area;
		}

#if DEBUG

	    public Bitmap IntegralImageToBitmap()
	    {
	        var integralImage = this.Integral;
            
            using (var bmp = new Bitmap(this.OutputImgWidth, this.OutputImgHeight, PixelFormat.Format8bppIndexed))
            {
                var bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                var len = bmpdata.Stride * bmp.Height;
                var buffer = new byte[len];
                var bufIndex = 0;

                for (var i = 0; i < this.OutputImgWidth; i++)
                {
                    for (var j = 0; j < this.OutputImgHeight; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            buffer[bufIndex++] = 0;
                            continue;
                        }
                        if ((integralImage[i, j] - integralImage[i, j - 1] - integralImage[i - 1, j] + integralImage[i - 1, j - 1]) == 0)
                            buffer[bufIndex++] = 0;
                        else
                            buffer[bufIndex++] = 255;
                    }
                }

                Debug.WriteLine("Done convertion with index: " + bufIndex);
                Marshal.Copy(buffer, 0, bmpdata.Scan0, buffer.Length);
                bmp.UnlockBits(bmpdata);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return bmp.Clone() as Bitmap;
            }
        }

	    public void SaveIntegralImageToBitmap()
	    {
            IntegralImageToBitmap().Save(Path.GetRandomFileName() + ".bmp");
        }

	    private FastImage CropImage(FastImage img)
	    {
            var cropRect = new Rectangle(1, 1, img.Width -1 , img. Height - 1);
            var src = img.Bitmap;
            var target = new Bitmap(cropRect.Width, cropRect.Height);

            using (var g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }
	        return new FastImage(target);
	    }
#endif
    }
}
