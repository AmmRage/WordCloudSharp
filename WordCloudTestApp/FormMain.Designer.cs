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
            this.elapsedLabel = new System.Windows.Forms.Label();
            this.buttonDrawWithMask = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.progressBarDraw = new System.Windows.Forms.ProgressBar();
            this.panelPicbox = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.panelControls.SuspendLayout();
            this.panelPicbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPictureBox.Location = new System.Drawing.Point(0, 0);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(519, 318);
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
            // elapsedLabel
            // 
            this.elapsedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.elapsedLabel.AutoSize = true;
            this.elapsedLabel.Location = new System.Drawing.Point(437, 10);
            this.elapsedLabel.Name = "elapsedLabel";
            this.elapsedLabel.Size = new System.Drawing.Size(70, 13);
            this.elapsedLabel.TabIndex = 0;
            this.elapsedLabel.Text = "elapsedLabel";
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
            this.panelControls.Controls.Add(this.elapsedLabel);
            this.panelControls.Controls.Add(this.buttonDrawWithMask);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(519, 33);
            this.panelControls.TabIndex = 3;
            // 
            // progressBarDraw
            // 
            this.progressBarDraw.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarDraw.Location = new System.Drawing.Point(0, 351);
            this.progressBarDraw.Name = "progressBarDraw";
            this.progressBarDraw.Size = new System.Drawing.Size(519, 10);
            this.progressBarDraw.TabIndex = 4;
            // 
            // panelPicbox
            // 
            this.panelPicbox.AutoSize = true;
            this.panelPicbox.Controls.Add(this.resultPictureBox);
            this.panelPicbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicbox.Location = new System.Drawing.Point(0, 33);
            this.panelPicbox.Name = "panelPicbox";
            this.panelPicbox.Size = new System.Drawing.Size(519, 318);
            this.panelPicbox.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(519, 361);
            this.Controls.Add(this.panelPicbox);
            this.Controls.Add(this.progressBarDraw);
            this.Controls.Add(this.panelControls);
            this.Name = "FormMain";
            this.Opacity = 0.3D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WordCloudTestApp";
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelPicbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Label elapsedLabel;
        private System.Windows.Forms.Button buttonDrawWithMask;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.ProgressBar progressBarDraw;
        private System.Windows.Forms.Panel panelPicbox;
    }
}

