﻿namespace WordCloudTestApp
{
	partial class Form1
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
			this.drawButton = new System.Windows.Forms.Button();
			this.elapsedLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// resultPictureBox
			// 
			this.resultPictureBox.Location = new System.Drawing.Point(31, 121);
			this.resultPictureBox.Name = "resultPictureBox";
			this.resultPictureBox.Size = new System.Drawing.Size(1000, 600);
			this.resultPictureBox.TabIndex = 0;
			this.resultPictureBox.TabStop = false;
			// 
			// drawButton
			// 
			this.drawButton.Location = new System.Drawing.Point(942, 727);
			this.drawButton.Name = "drawButton";
			this.drawButton.Size = new System.Drawing.Size(75, 23);
			this.drawButton.TabIndex = 1;
			this.drawButton.Text = "Draw";
			this.drawButton.UseVisualStyleBackColor = true;
			this.drawButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// elapsedLabel
			// 
			this.elapsedLabel.AutoSize = true;
			this.elapsedLabel.Location = new System.Drawing.Point(28, 58);
			this.elapsedLabel.Name = "elapsedLabel";
			this.elapsedLabel.Size = new System.Drawing.Size(70, 13);
			this.elapsedLabel.TabIndex = 2;
			this.elapsedLabel.Text = "elapsedLabel";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1068, 774);
			this.Controls.Add(this.elapsedLabel);
			this.Controls.Add(this.drawButton);
			this.Controls.Add(this.resultPictureBox);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox resultPictureBox;
		private System.Windows.Forms.Button drawButton;
		private System.Windows.Forms.Label elapsedLabel;
	}
}

