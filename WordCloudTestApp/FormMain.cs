using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCloudSharp;

namespace WordCloudTestApp
{
	public partial class FormMain : Form
	{
        #region attributes & constructor
        private WordCloud wc;

        private List<string> Words { get; set; }

	    private List<int> Frequencies { get; set; }

        public FormMain()
		{
			InitializeComponent();
            var lines = File.ReadLines("../../content/counts.csv").ToArray().Take(50);
		    this.Words = new List<string>(lines.Count());
		    this.Frequencies = new List<int>(lines.Count());
			foreach (var line in lines)
			{
				var textValue = line.Split(new char[] {','});
			    this.Words.Add(textValue[0]);
			    this.Frequencies.Add(int.Parse(textValue[1]));
			}
#if DEBUG
            var buttonContinueDraw = new Button();
            buttonContinueDraw.AutoSize = true;
            buttonContinueDraw.Location = new Point(187, 5);
            buttonContinueDraw.Name = "buttonContinueDraw";
            buttonContinueDraw.Size = new Size(97, 23);
            buttonContinueDraw.TabIndex = 1;
            buttonContinueDraw.Text = "ContinueDraw";
            buttonContinueDraw.UseVisualStyleBackColor = true;
            buttonContinueDraw.Click += new EventHandler(buttonContinueDraw_Click);
            buttonContinueDraw.Enabled = true;
            buttonContinueDraw.Visible = true;
            buttonContinueDraw.TabIndex = 0;
            this.Controls.Add(buttonContinueDraw);
            buttonContinueDraw.BringToFront();

            var checkBoxStepDraw = new CheckBox();
            checkBoxStepDraw.AutoSize = true;
            checkBoxStepDraw.Location = new Point(400, 9);
            checkBoxStepDraw.Name = "checkBoxStepDraw";
            checkBoxStepDraw.Size = new Size(73, 17);
            checkBoxStepDraw.TabIndex = 1;
            checkBoxStepDraw.Text = "StepDraw";
            checkBoxStepDraw.UseVisualStyleBackColor = true;
            checkBoxStepDraw.CheckedChanged += new EventHandler(checkBoxStepDraw_CheckedChanged);
            checkBoxStepDraw.Visible = true;
            checkBoxStepDraw.Enabled = true;
            checkBoxStepDraw.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.Controls.Add(checkBoxStepDraw);
            checkBoxStepDraw.BringToFront();
#endif
        }
        #endregion

        private void DrawWordcloud(int width, int height, Image mask )
        {
            this.wc = new WordCloud(width, height, mask: mask)
            {
                 StepDrawMode = (this.Controls["checkBoxStepDraw"] as CheckBox).Checked,
            };
	        this.wc.OnProgress += Wc_OnProgress;
#if DEBUG
	        this.wc.OnStepDrawResultImg += ShowResultImage;
            this.wc.OnStepDrawIntegralImg += ShowIntegralImage;
#endif
            var i = this.wc.Draw(this.Words, this.Frequencies);
            Wc_OnProgress(1);
            ShowResultImage(i);
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ControlsEnable(false);
                DrawWordcloud(1000, 600, null);
                ControlsEnable(true);
            });
        }

        private void buttonDrawWithMask_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ControlsEnable(false);
                using (var img = Image.FromFile("../../content/stormtrooper_mask.png"))
                {
                    DrawWordcloud(img.Width, img.Height, img);
                }
                ControlsEnable(true);
            });
        }

        private void Wc_OnProgress(double progress)
        {
            if (this.progressBarDraw.InvokeRequired)
                this.progressBarDraw.Invoke(new Action<double>((p) =>
                {
                    this.progressBarDraw.Value = Math.Min((int)(p * 100), this.progressBarDraw.Maximum);
                }), progress);
            else
                this.progressBarDraw.Value = Math.Min((int)(progress * 100), this.progressBarDraw.Maximum);
        }

	    private void ControlsEnable(bool enable)
	    {
            if (this.panelControls.InvokeRequired)
                this.panelControls.Invoke(new Action<bool>((e) => this.panelControls.Enabled = e), enable);
            else
                this.panelControls.Enabled = enable;
	    }

        private void ShowResultImage(Image img)
        {
            if (this.resultPictureBox.InvokeRequired)
                this.resultPictureBox.Invoke(new Action<Image>((i) => this.resultPictureBox.Image = i), img);
            else
                this.resultPictureBox.Image = img;
        }

        private void ShowIntegralImage(Image img)
        {
            if (this.pictureBoxIntegralImg.InvokeRequired)
                this.pictureBoxIntegralImg.Invoke(new Action<Image>((i) => this.pictureBoxIntegralImg.Image = i), img);
            else
                this.pictureBoxIntegralImg.Image = img;
        }

        private void buttonContinueDraw_Click(object sender, EventArgs e)
        {
#if DEBUG
            this.wc?.ContinueDrawing();
#endif
        }

        private void checkBoxStepDraw_CheckedChanged(object sender, EventArgs e)
        {
            if(this.wc != null)
                this.wc.StepDrawMode = (sender as CheckBox).Checked;
        }
    }
}
