namespace _Forms__MLiTA_Transitive_Close
{
    partial class Graph
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
            this.Graph_PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Graph_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Graph_PictureBox
            // 
            this.Graph_PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph_PictureBox.Location = new System.Drawing.Point(0, 0);
            this.Graph_PictureBox.Name = "Graph_PictureBox";
            this.Graph_PictureBox.Size = new System.Drawing.Size(631, 528);
            this.Graph_PictureBox.TabIndex = 0;
            this.Graph_PictureBox.TabStop = false;
            this.Graph_PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Graph_PictureBox_Paint);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 528);
            this.Controls.Add(this.Graph_PictureBox);
            this.Name = "Graph";
            this.Text = "Граф";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Graph_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Graph_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Graph_PictureBox;
    }
}