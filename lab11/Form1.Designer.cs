
namespace lab11
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ArtistsListBox = new System.Windows.Forms.ListBox();
            this.AlbumsBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ArtistsListBox
            // 
            this.ArtistsListBox.FormattingEnabled = true;
            this.ArtistsListBox.ItemHeight = 15;
            this.ArtistsListBox.Location = new System.Drawing.Point(12, 59);
            this.ArtistsListBox.Name = "ArtistsListBox";
            this.ArtistsListBox.Size = new System.Drawing.Size(189, 214);
            this.ArtistsListBox.TabIndex = 0;
            this.ArtistsListBox.SelectedIndexChanged += new System.EventHandler(this.ArtistsListBox_SelectedIndexChanged);
            // 
            // AlbumsBox
            // 
            this.AlbumsBox.FormattingEnabled = true;
            this.AlbumsBox.ItemHeight = 15;
            this.AlbumsBox.Location = new System.Drawing.Point(217, 59);
            this.AlbumsBox.Name = "AlbumsBox";
            this.AlbumsBox.Size = new System.Drawing.Size(189, 214);
            this.AlbumsBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "исполнители";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "альбомы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 296);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AlbumsBox);
            this.Controls.Add(this.ArtistsListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ArtistsListBox;
        private System.Windows.Forms.ListBox AlbumsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

