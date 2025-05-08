
    namespace Final_Project
    {
        partial class optionpage
        {
            private System.ComponentModel.IContainer components = null;
            private System.Windows.Forms.TrackBar trackBarVolume;
            private System.Windows.Forms.Button btnBack;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null)) components.Dispose();
                base.Dispose(disposing);
            }

            private void InitializeComponent()
            {
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(40, 30);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(300, 45);
            this.trackBarVolume.TabIndex = 0;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 50;
            // 
            // btnBack
            this.btnBack.Location = new System.Drawing.Point(140, 100);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // optionpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.trackBarVolume);
            this.Name = "optionpage";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        }
    }
