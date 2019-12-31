using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
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
            var lines = File.ReadLines("../../content/st.csv").ToArray();
		    this.Words = new List<string>(lines.Count());
		    this.Frequencies = new List<int>(lines.Count());
			foreach (var line in lines)
			{
				var textValue = line.Split(new char[] {','});
			    this.Words.Add(textValue[0]);
			    this.Frequencies.Add((int) (double.Parse(textValue[1]) * 1000));
			}
            //this.Opacity = 0.1;
            this.Size = new Size(500, 250);
#if DEBUG
            var buttonContinueDraw = new Button();
            buttonContinueDraw.AutoSize = true;
            buttonContinueDraw.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonContinueDraw.TabIndex = 1;
            buttonContinueDraw.Name = "buttonContinueDraw";
            buttonContinueDraw.Text = @"ContinueDraw";
            buttonContinueDraw.Click += new EventHandler(buttonContinueDraw_Click);

            var checkBoxStepDraw = new CheckBox();
            checkBoxStepDraw.AutoSize = true;
            checkBoxStepDraw.TabIndex = 1;
            checkBoxStepDraw.Name = "checkBoxStepDraw";
            checkBoxStepDraw.Text = @"StepDraw";
            checkBoxStepDraw.CheckedChanged += new EventHandler(checkBoxStepDraw_CheckedChanged);
#endif

            var buttonSave = new Button();
            buttonSave.AutoSize = true;
            buttonSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonSave.Text = @"Save";
            buttonSave.Name = "buttonSave";
            buttonSave.Click += (sender, e) =>
            {
                if (this.pictureBoxResult.Image == null)
                    return;
                this.pictureBoxResult.Image.Save(DateTime.Now.ToString("yyyyMMdd_hhmmss_") + "output.jpg", ImageFormat.Jpeg);
            };
            
            this.flowLayoutPanelButtons.Controls.AddRange(new Control[]
            {
                buttonSave,
#if DEBUG
                buttonContinueDraw,
                checkBoxStepDraw,
#endif
            });
        }
#endregion

        private void DrawWordcloud(int width, int height, Image mask )
        {
            this.wc = new WordCloud(width, height, mask: mask, allowVerical: true, fontname: "YouYuan");
	        this.wc.OnProgress += Wc_OnProgress;
#if DEBUG
            this.wc.StepDrawMode = ((CheckBox) this.flowLayoutPanelButtons.Controls["checkBoxStepDraw"]).Checked;
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
                using (var img = Image.FromFile("../../content/st.png"))
                {
                    DrawWordcloud(img.Width * 2, img.Height * 2, img);
                }
                ControlsEnable(true);
            });
        }

        private void Wc_OnProgress(double progress)
        {
            if (this.progressBarDraw.InvokeRequired)
                this.progressBarDraw.Invoke(new Action<double>(Wc_OnProgress), progress);
            else
            {
                this.progressBarDraw.Value = Math.Min((int)(progress * 100), this.progressBarDraw.Maximum);
                TaskbarManager.Instance.SetProgressValue((int) (progress*100), this.progressBarDraw.Maximum);
            }
        }

	    private void ControlsEnable(bool enable)
	    {
            if (this.panelButtons.InvokeRequired)
                this.panelButtons.Invoke(new Action<bool>((e) => this.panelButtons.Enabled = e), enable);
            else
                this.panelButtons.Enabled = enable;
	    }

        private void ShowResultImage(Image img)
        {
            if (this.pictureBoxResult.InvokeRequired)
                this.pictureBoxResult.Invoke(new Action<Image>((i) => this.pictureBoxResult.Image = i), img);
            else
                this.pictureBoxResult.Image = img;
        }

#if DEBUG
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
#endif

        private void FormMain_Shown(object sender, EventArgs e)
        {
            TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(0, 0, 0, 0));
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
        }
    }
}
