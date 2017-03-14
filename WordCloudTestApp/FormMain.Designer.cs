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
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonDrawWithMask = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.progressBarDraw = new System.Windows.Forms.ProgressBar();
            this.panelPicbox = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxIntegralImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.panelControls.SuspendLayout();
            this.panelPicbox.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntegralImg)).BeginInit();
            this.SuspendLayout();
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPictureBox.Location = new System.Drawing.Point(3, 3);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(440, 518);
            this.resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultPictureBox.TabIndex = 0;
            this.resultPictureBox.TabStop = false;
            // 
            // buttonDraw
            // 
            this.buttonDraw.AutoSize = true;
            this.buttonDraw.Location = new System.Drawing.Point(3, 5);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonDrawWithMask
            // 
            this.buttonDrawWithMask.AutoSize = true;
            this.buttonDrawWithMask.Location = new System.Drawing.Point(84, 5);
            this.buttonDrawWithMask.Name = "buttonDrawWithMask";
            this.buttonDrawWithMask.Size = new System.Drawing.Size(97, 23);
            this.buttonDrawWithMask.TabIndex = 0;
            this.buttonDrawWithMask.Text = "DrawWithMask";
            this.buttonDrawWithMask.UseVisualStyleBackColor = true;
            this.buttonDrawWithMask.Click += new System.EventHandler(this.buttonDrawWithMask_Click);
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.buttonDraw);
            this.panelControls.Controls.Add(this.buttonDrawWithMask);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(893, 33);
            this.panelControls.TabIndex = 3;
            // 
            // progressBarDraw
            // 
            this.progressBarDraw.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarDraw.Location = new System.Drawing.Point(0, 557);
            this.progressBarDraw.Name = "progressBarDraw";
            this.progressBarDraw.Size = new System.Drawing.Size(893, 10);
            this.progressBarDraw.TabIndex = 4;
            // 
            // panelPicbox
            // 
            this.panelPicbox.AutoSize = true;
            this.panelPicbox.Controls.Add(this.tableLayoutPanelMain);
            this.panelPicbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicbox.Location = new System.Drawing.Point(0, 33);
            this.panelPicbox.Name = "panelPicbox";
            this.panelPicbox.Size = new System.Drawing.Size(893, 524);
            this.panelPicbox.TabIndex = 5;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.resultPictureBox, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxIntegralImg, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(893, 524);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // pictureBoxIntegralImg
            // 
            this.pictureBoxIntegralImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIntegralImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxIntegralImg.Location = new System.Drawing.Point(449, 3);
            this.pictureBoxIntegralImg.Name = "pictureBoxIntegralImg";
            this.pictureBoxIntegralImg.Size = new System.Drawing.Size(441, 518);
            this.pictureBoxIntegralImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIntegralImg.TabIndex = 0;
            this.pictureBoxIntegralImg.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(893, 567);
            this.Controls.Add(this.panelPicbox);
            this.Controls.Add(this.progressBarDraw);
            this.Controls.Add(this.panelControls);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WordCloudTestApp";
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelPicbox.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntegralImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonDrawWithMask;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.ProgressBar progressBarDraw;
        private System.Windows.Forms.Panel panelPicbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.PictureBox pictureBoxIntegralImg;
    }
}

