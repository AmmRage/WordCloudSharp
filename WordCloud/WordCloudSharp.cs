using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace WordCloudSharp
{
	/// <summary>
	/// Class to draw word clouds.
	/// </summary>
	public class WordCloud
	{
        public event Action<double> OnProgress;
#if DEBUG
        public event Action<Image> OnStepDrawResultImg;

        public event Action<Image> OnStepDrawIntegralImg;

	    private AutoResetEvent DrawWaitHandle;

	    public bool StepDrawMode { get; set; }
#endif

        #region attributes
        /// <summary>
        /// Gets font colour or random if font wasn't set
        /// </summary>
        private Color FontColor
        {
            get { return this._mFontColor ?? GetRandomColor(); }
            set { this._mFontColor = value; }
        }


        private Color? _mFontColor;


        /// <summary>
        /// Used to select random colors.
        /// </summary>
        private Random Random { get; set; }


        /// <summary>
        /// Working image.
        /// </summary>
        private FastImage WorkImage { get; set; }


        /// <summary>
        /// Keeps track of word positions using integral image.
        /// </summary>
        private OccupancyMap Map { get; set; }


        /// <summary>
        /// Gets or sets the maximum size of the font.
        /// </summary>
        private float MaxFontSize { get; set; }


        /// <summary>
        /// User input order instead of frequency
        /// </summary>
        private bool UseRank { get; set; }

        /// <summary>
        /// Amount to decrement font size each time a word won't fit.
        /// </summary>
        private int FontStep { get; set; }

        #endregion

	    /// <summary>
	    /// Initializes a new instance of the <see cref="WordCloud"/> class.
	    /// </summary>
	    /// <param name="width">The width of word cloud.</param>
	    /// <param name="height">The height of word cloud.</param>
	    /// <param name="useRank">if set to <c>true</c> will ignore frequencies for best fit.</param>
	    /// <param name="fontColor">Color of the font.</param>
	    /// <param name="maxFontSize">Maximum size of the font.</param>
	    /// <param name="fontStep">The font step to use.</param>
	    /// <param name="mask">mask image</param>
	    public WordCloud(int width, int height, bool useRank = false, Color? fontColor = null, float maxFontSize = -1,
			int fontStep = 1, Image mask = null)
		{
	        if (mask == null)
	        {
	            this.Map = new OccupancyMap(width, height);
	            this.WorkImage = new FastImage(width, height, PixelFormat.Format32bppArgb);
	        }
	        else
	        {
	            this.Map = new OccupancyMap(mask);
                this.WorkImage = new FastImage(mask);
            }

            this.MaxFontSize = maxFontSize < 0 ? (float)height : maxFontSize;
		    this.FontStep = fontStep;
		    this._mFontColor = fontColor;
		    this.UseRank = useRank;
		    this.Random = new Random(Environment.TickCount);

#if DEBUG
            this.DrawWaitHandle = new AutoResetEvent(false);
            this.StepDrawMode = false;
#endif
        }

        /// <summary>
        /// Gets a random color.
        /// </summary>
        /// <returns>Color</returns>
        private Color GetRandomColor()
        {
            return Color.FromArgb(this.Random.Next(0, 255), this.Random.Next(0, 255), this.Random.Next(0, 255));
        }

		/// <summary>
		/// Draws the specified word cloud given list of words and frequecies
		/// </summary>
		/// <param name="words">List of words ordered by occurance.</param>
		/// <param name="freqs">List of frequecies.</param>
		/// <returns>Image of word cloud.</returns>
		/// <exception cref="System.ArgumentException">
		/// Arguments null.
		/// or
		/// Must have the same number of words as frequencies.
		/// </exception>
		public Image Draw(List<string> words, List<int> freqs)
		{
#if DEBUG
            ShowIntegralImgStepDraw(this.Map.IntegralImageToBitmap());
#endif
            this.DrawWaitHandle.Reset();
            var fontSize = this.MaxFontSize;
			if (words == null || freqs == null)
			{
				throw new ArgumentException("Arguments null.");
			}
			if (words.Count != freqs.Count)
			{
				throw new ArgumentException("Must have the same number of words as frequencies.");
			}

			using (var g = Graphics.FromImage(this.WorkImage.Bitmap))
			{
				//g.Clear(Color.Transparent); !!
				g.TextRenderingHint = TextRenderingHint.AntiAlias;
			    var lastProgress = 0.0d;
				for (var i = 0; i < words.Count; ++i)
				{
				    var progress = (double) i/words.Count;
				    if (progress - lastProgress > 0.01)
				    {
				        ShowProgress(progress);
				    }
				    lastProgress = progress;
                    if (!this.UseRank)
					{
						fontSize =  (float) Math.Min(fontSize, 100*Math.Log10(freqs[i] + 100));
					}
					var format = StringFormat.GenericTypographic;
                    format.FormatFlags &= ~StringFormatFlags.LineLimit;
                    
                    Point p;
                    var foundPosition = false;
					Font font;
				    var size = new SizeF();
					do
					{
						font = new Font(FontFamily.GenericSansSerif, fontSize, GraphicsUnit.Pixel);
						size = g.MeasureString(words[i], font, new PointF(0, 0), format);
						foundPosition = this.Map.GetRandomUnoccupiedPosition((int) size.Width, (int) size.Height, out p);
						if (!foundPosition) fontSize -= this.FontStep;
					} while (fontSize > 0 && !foundPosition);

					if (fontSize <= 0) break;
					g.DrawString(words[i], font, new SolidBrush(this.FontColor), p.X, p.Y, format);
				    this.Map.Update(this.WorkImage, p.X, p.Y);
#if DEBUG
				    if (this.StepDrawMode)
				    {
                        ShowResultStepDraw(new Bitmap(this.WorkImage.Bitmap));
                        ShowIntegralImgStepDraw(this.Map.IntegralImageToBitmap());
                        this.DrawWaitHandle.WaitOne();
				    }
#endif
				}
			}
            var result = new Bitmap(ReviseBackground(this.WorkImage.Bitmap));
            //var result = new Bitmap(this.WorkImage.Bitmap);
            this.WorkImage.Dispose();
            return result;
		}

	    private void ShowProgress(double progress)
	    {
	        OnProgress?.Invoke(progress);
	    }

        private Bitmap ReviseBackground(Bitmap bmp)
        {
            var bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            var len = bmpdata.Stride * bmp.Height;
            var buffer = new byte[len];
            var pixelformatsize = bmpdata.Stride / bmp.Width;
            var pixelSize = Math.Min(3, pixelformatsize);
            Marshal.Copy(bmpdata.Scan0, buffer, 0, buffer.Length);

            for (var i = 0; i < bmp.Width * bmp.Height * pixelformatsize; i += pixelformatsize)
            {
                var zeroValue = false;
                for (var j = 0; j < pixelSize; j++)
                {
                    if (buffer[i + j] != 0)
                    {
                        zeroValue = true;
                    }
                }
                if (!zeroValue)
                {
                    for (var j = 0; j < pixelSize; j++)
                    {
                        buffer[i + j] = 255;
                    }
                }
            }
            Marshal.Copy(buffer, 0, bmpdata.Scan0, buffer.Length);

            bmp.UnlockBits(bmpdata);
            return bmp;
        }

#if DEBUG
        private void ShowResultStepDraw(Bitmap bmp)
        {
            OnStepDrawResultImg?.Invoke(bmp);
        }

        private void ShowIntegralImgStepDraw(Bitmap bmp)
        {
            OnStepDrawIntegralImg?.Invoke(bmp);
        }

        public void ContinueDrawing()
	    {
            this.DrawWaitHandle.Set();
	    }
#endif
    }
}
