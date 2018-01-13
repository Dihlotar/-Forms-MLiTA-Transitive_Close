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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.NextStep_Button = new System.Windows.Forms.Button();
            this.Step_TextBox = new System.Windows.Forms.TextBox();
            this.TGraph_PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Graph_PictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TGraph_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Graph_PictureBox
            // 
            this.Graph_PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph_PictureBox.Location = new System.Drawing.Point(3, 3);
            this.Graph_PictureBox.Name = "Graph_PictureBox";
            this.Graph_PictureBox.Size = new System.Drawing.Size(871, 480);
            this.Graph_PictureBox.TabIndex = 0;
            this.Graph_PictureBox.TabStop = false;
            this.Graph_PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Graph_PictureBox_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(112, 31);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 525);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Graph_PictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(877, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Исходный граф";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.NextStep_Button);
            this.tabPage2.Controls.Add(this.Step_TextBox);
            this.tabPage2.Controls.Add(this.TGraph_PictureBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Граф транзитивного замыкания и шаги";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // NextStep_Button
            // 
            this.NextStep_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NextStep_Button.Location = new System.Drawing.Point(0, 445);
            this.NextStep_Button.Name = "NextStep_Button";
            this.NextStep_Button.Size = new System.Drawing.Size(667, 41);
            this.NextStep_Button.TabIndex = 3;
            this.NextStep_Button.Text = "Следующий шаг";
            this.NextStep_Button.UseVisualStyleBackColor = true;
            this.NextStep_Button.Visible = false;
            this.NextStep_Button.Click += new System.EventHandler(this.NextStep_Button_Click);
            // 
            // Step_TextBox
            // 
            this.Step_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Step_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Step_TextBox.Location = new System.Drawing.Point(673, 3);
            this.Step_TextBox.Multiline = true;
            this.Step_TextBox.Name = "Step_TextBox";
            this.Step_TextBox.ReadOnly = true;
            this.Step_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Step_TextBox.Size = new System.Drawing.Size(201, 487);
            this.Step_TextBox.TabIndex = 2;
            // 
            // TGraph_PictureBox
            // 
            this.TGraph_PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TGraph_PictureBox.Location = new System.Drawing.Point(3, 3);
            this.TGraph_PictureBox.Name = "TGraph_PictureBox";
            this.TGraph_PictureBox.Size = new System.Drawing.Size(664, 442);
            this.TGraph_PictureBox.TabIndex = 1;
            this.TGraph_PictureBox.TabStop = false;
            this.TGraph_PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.TGraph_PictureBox_Paint);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 525);
            this.Controls.Add(this.tabControl1);
            this.Name = "Graph";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Graph_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Graph_PictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TGraph_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox Graph_PictureBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.PictureBox TGraph_PictureBox;
        private System.Windows.Forms.TextBox Step_TextBox;
        private System.Windows.Forms.Button NextStep_Button;
    }
}