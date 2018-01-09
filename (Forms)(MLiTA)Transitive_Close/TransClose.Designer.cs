namespace _Forms__MLiTA_Transitive_Close
{
    partial class TransClose
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
            this.Trans_DataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Trans_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Trans_DataGridView
            // 
            this.Trans_DataGridView.AllowUserToAddRows = false;
            this.Trans_DataGridView.AllowUserToDeleteRows = false;
            this.Trans_DataGridView.AllowUserToResizeColumns = false;
            this.Trans_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Trans_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Trans_DataGridView.Location = new System.Drawing.Point(0, 0);
            this.Trans_DataGridView.Name = "Trans_DataGridView";
            this.Trans_DataGridView.ReadOnly = true;
            this.Trans_DataGridView.RowTemplate.Height = 24;
            this.Trans_DataGridView.Size = new System.Drawing.Size(582, 553);
            this.Trans_DataGridView.TabIndex = 1;
            this.Trans_DataGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.Trans_DataGridView_ColumnAdded);
            // 
            // TransClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.Trans_DataGridView);
            this.Name = "TransClose";
            this.Text = "Матрица транзитивного замыкания";
            this.SizeChanged += new System.EventHandler(this.TransClose_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Trans_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView Trans_DataGridView;
    }
}