namespace WordCloudTestApp
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonDrawWithMask = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBarDraw = new System.Windows.Forms.ProgressBar();
            this.panelPicbox = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxIntegralImg = new System.Windows.Forms.PictureBox();
            this.panelProgress = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.panelPicbox.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntegralImg)).BeginInit();
            this.panelProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxResult.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(440, 532);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResult.TabIndex = 0;
            this.pictureBoxResult.TabStop = false;
            // 
            // buttonDraw
            // 
            this.buttonDraw.AutoSize = true;
            this.buttonDraw.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDraw.Location = new System.Drawing.Point(3, 3);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(42, 23);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonDrawWithMask
            // 
            this.buttonDrawWithMask.AutoSize = true;
            this.buttonDrawWithMask.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDrawWithMask.Location = new System.Drawing.Point(51, 3);
            this.buttonDrawWithMask.Name = "buttonDrawWithMask";
            this.buttonDrawWithMask.Size = new System.Drawing.Size(90, 23);
            this.buttonDrawWithMask.TabIndex = 0;
            this.buttonDrawWithMask.Text = "DrawWithMask";
            this.buttonDrawWithMask.UseVisualStyleBackColor = true;
            this.buttonDrawWithMask.Click += new System.EventHandler(this.buttonDrawWithMask_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.AutoSize = true;
            this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelButtons.Controls.Add(this.flowLayoutPanelButtons);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(893, 29);
            this.panelButtons.TabIndex = 3;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonDraw);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonDrawWithMask);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(893, 29);
            this.flowLayoutPanelButtons.TabIndex = 1;
            // 
            // progressBarDraw
            // 
            this.progressBarDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarDraw.Location = new System.Drawing.Point(0, 0);
            this.progressBarDraw.MinimumSize = new System.Drawing.Size(0, 10);
            this.progressBarDraw.Name = "progressBarDraw";
            this.progressBarDraw.Size = new System.Drawing.Size(893, 10);
            this.progressBarDraw.TabIndex = 4;
            // 
            // panelPicbox
            // 
            this.panelPicbox.AutoSize = true;
            this.panelPicbox.Controls.Add(this.tableLayoutPanelMain);
            this.panelPicbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicbox.Location = new System.Drawing.Point(0, 29);
            this.panelPicbox.Name = "panelPicbox";
            this.panelPicbox.Size = new System.Drawing.Size(893, 538);
            this.panelPicbox.TabIndex = 5;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxResult, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxIntegralImg, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(893, 538);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // pictureBoxIntegralImg
            // 
            this.pictureBoxIntegralImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIntegralImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxIntegralImg.Location = new System.Drawing.Point(449, 3);
            this.pictureBoxIntegralImg.Name = "pictureBoxIntegralImg";
            this.pictureBoxIntegralImg.Size = new System.Drawing.Size(441, 532);
            this.pictureBoxIntegralImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIntegralImg.TabIndex = 0;
            this.pictureBoxIntegralImg.TabStop = false;
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.progressBarDraw);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelProgress.Location = new System.Drawing.Point(0, 557);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(893, 10);
            this.panelProgress.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 567);
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.panelPicbox);
            this.Controls.Add(this.panelButtons);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WordCloudTestApp";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.panelPicbox.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntegralImg)).EndInit();
            this.panelProgress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonDrawWithMask;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.ProgressBar progressBarDraw;
        private System.Windows.Forms.Panel panelPicbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.PictureBox pictureBoxIntegralImg;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
    }
}

