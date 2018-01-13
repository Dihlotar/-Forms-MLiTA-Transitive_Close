namespace _Forms__MLiTA_Transitive_Close
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ANode_TextBox = new System.Windows.Forms.TextBox();
            this.BNode_TextBox = new System.Windows.Forms.TextBox();
            this.Arrow_Label = new System.Windows.Forms.Label();
            this.Edges_DataGridView = new System.Windows.Forms.DataGridView();
            this.Edges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddEdge_Button = new System.Windows.Forms.Button();
            this.EdgeErrorInput_Label = new System.Windows.Forms.Label();
            this.DeleteAllEdges_Button = new System.Windows.Forms.Button();
            this.CreateGraph_Button = new System.Windows.Forms.Button();
            this.Nodes_DataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Node_TextBox = new System.Windows.Forms.TextBox();
            this.AddNode_Button = new System.Windows.Forms.Button();
            this.DeleteAllNodes_Button = new System.Windows.Forms.Button();
            this.NodeErrorInput_Label = new System.Windows.Forms.Label();
            this.Step_CheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Edges_DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nodes_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ANode_TextBox
            // 
            this.ANode_TextBox.Location = new System.Drawing.Point(257, 440);
            this.ANode_TextBox.Name = "ANode_TextBox";
            this.ANode_TextBox.Size = new System.Drawing.Size(73, 22);
            this.ANode_TextBox.TabIndex = 2;
            this.ANode_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ANode_TextBox_KeyPress);
            // 
            // BNode_TextBox
            // 
            this.BNode_TextBox.Location = new System.Drawing.Point(368, 440);
            this.BNode_TextBox.Name = "BNode_TextBox";
            this.BNode_TextBox.Size = new System.Drawing.Size(73, 22);
            this.BNode_TextBox.TabIndex = 3;
            this.BNode_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ANode_TextBox_KeyPress);
            // 
            // Arrow_Label
            // 
            this.Arrow_Label.AutoSize = true;
            this.Arrow_Label.Location = new System.Drawing.Point(336, 443);
            this.Arrow_Label.Name = "Arrow_Label";
            this.Arrow_Label.Size = new System.Drawing.Size(26, 17);
            this.Arrow_Label.TabIndex = 2;
            this.Arrow_Label.Text = "-->";
            this.Arrow_Label.Click += new System.EventHandler(this.Arrow_Label_Click);
            // 
            // Edges_DataGridView
            // 
            this.Edges_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Edges_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edges});
            this.Edges_DataGridView.Location = new System.Drawing.Point(202, 12);
            this.Edges_DataGridView.Name = "Edges_DataGridView";
            this.Edges_DataGridView.RowTemplate.Height = 24;
            this.Edges_DataGridView.Size = new System.Drawing.Size(291, 400);
            this.Edges_DataGridView.TabIndex = 3;
            this.Edges_DataGridView.TabStop = false;
            this.Edges_DataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Edges_DataGridView_CellMouseDoubleClick);
            this.Edges_DataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.Edges_DataGridView_DragDrop);
            this.Edges_DataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.Edges_DataGridView_DragEnter);
            this.Edges_DataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Edges_DataGridView_PreviewKeyDown);
            // 
            // Edges
            // 
            this.Edges.Frozen = true;
            this.Edges.HeaderText = "Ребра";
            this.Edges.MaxInputLength = 15;
            this.Edges.MinimumWidth = 20;
            this.Edges.Name = "Edges";
            this.Edges.ReadOnly = true;
            this.Edges.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edges.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Edges.Width = 200;
            // 
            // AddEdge_Button
            // 
            this.AddEdge_Button.Location = new System.Drawing.Point(293, 468);
            this.AddEdge_Button.Name = "AddEdge_Button";
            this.AddEdge_Button.Size = new System.Drawing.Size(118, 35);
            this.AddEdge_Button.TabIndex = 4;
            this.AddEdge_Button.Text = "Добавить";
            this.AddEdge_Button.UseVisualStyleBackColor = true;
            this.AddEdge_Button.Click += new System.EventHandler(this.AddEdge_Button_Click);
            // 
            // EdgeErrorInput_Label
            // 
            this.EdgeErrorInput_Label.AutoSize = true;
            this.EdgeErrorInput_Label.Location = new System.Drawing.Point(248, 415);
            this.EdgeErrorInput_Label.Name = "EdgeErrorInput_Label";
            this.EdgeErrorInput_Label.Size = new System.Drawing.Size(0, 17);
            this.EdgeErrorInput_Label.TabIndex = 5;
            // 
            // DeleteAllEdges_Button
            // 
            this.DeleteAllEdges_Button.Location = new System.Drawing.Point(202, 509);
            this.DeleteAllEdges_Button.Name = "DeleteAllEdges_Button";
            this.DeleteAllEdges_Button.Size = new System.Drawing.Size(291, 31);
            this.DeleteAllEdges_Button.TabIndex = 6;
            this.DeleteAllEdges_Button.Text = "Очистить";
            this.DeleteAllEdges_Button.UseVisualStyleBackColor = true;
            this.DeleteAllEdges_Button.Click += new System.EventHandler(this.DeleteAll_Button_Click);
            // 
            // CreateGraph_Button
            // 
            this.CreateGraph_Button.Location = new System.Drawing.Point(370, 565);
            this.CreateGraph_Button.Name = "CreateGraph_Button";
            this.CreateGraph_Button.Size = new System.Drawing.Size(127, 35);
            this.CreateGraph_Button.TabIndex = 7;
            this.CreateGraph_Button.Text = "Построить граф";
            this.CreateGraph_Button.UseVisualStyleBackColor = true;
            this.CreateGraph_Button.Click += new System.EventHandler(this.CreateGraph_Button_Click);
            // 
            // Nodes_DataGridView
            // 
            this.Nodes_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Nodes_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.Nodes_DataGridView.Location = new System.Drawing.Point(12, 12);
            this.Nodes_DataGridView.Name = "Nodes_DataGridView";
            this.Nodes_DataGridView.RowTemplate.Height = 24;
            this.Nodes_DataGridView.Size = new System.Drawing.Size(173, 400);
            this.Nodes_DataGridView.TabIndex = 8;
            this.Nodes_DataGridView.TabStop = false;
            this.Nodes_DataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Nodes_DataGridView_CellMouseDoubleClick);
            this.Nodes_DataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Nodes_DataGridView_PreviewKeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Вершины";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 15;
            this.dataGridViewTextBoxColumn1.MinimumWidth = 20;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // Node_TextBox
            // 
            this.Node_TextBox.Location = new System.Drawing.Point(56, 440);
            this.Node_TextBox.Name = "Node_TextBox";
            this.Node_TextBox.Size = new System.Drawing.Size(73, 22);
            this.Node_TextBox.TabIndex = 0;
            this.Node_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Node_TextBox_KeyPress);
            // 
            // AddNode_Button
            // 
            this.AddNode_Button.Location = new System.Drawing.Point(35, 468);
            this.AddNode_Button.Name = "AddNode_Button";
            this.AddNode_Button.Size = new System.Drawing.Size(118, 35);
            this.AddNode_Button.TabIndex = 1;
            this.AddNode_Button.Text = "Добавить";
            this.AddNode_Button.UseVisualStyleBackColor = true;
            this.AddNode_Button.Click += new System.EventHandler(this.AddNode_Button_Click);
            // 
            // DeleteAllNodes_Button
            // 
            this.DeleteAllNodes_Button.Location = new System.Drawing.Point(12, 509);
            this.DeleteAllNodes_Button.Name = "DeleteAllNodes_Button";
            this.DeleteAllNodes_Button.Size = new System.Drawing.Size(173, 31);
            this.DeleteAllNodes_Button.TabIndex = 5;
            this.DeleteAllNodes_Button.Text = "Очистить";
            this.DeleteAllNodes_Button.UseVisualStyleBackColor = true;
            this.DeleteAllNodes_Button.Click += new System.EventHandler(this.DeleteAllNodes_Button_Click);
            // 
            // NodeErrorInput_Label
            // 
            this.NodeErrorInput_Label.AutoSize = true;
            this.NodeErrorInput_Label.Location = new System.Drawing.Point(12, 415);
            this.NodeErrorInput_Label.Name = "NodeErrorInput_Label";
            this.NodeErrorInput_Label.Size = new System.Drawing.Size(0, 17);
            this.NodeErrorInput_Label.TabIndex = 9;
            // 
            // Step_CheckBox
            // 
            this.Step_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Step_CheckBox.AutoSize = true;
            this.Step_CheckBox.Location = new System.Drawing.Point(15, 573);
            this.Step_CheckBox.Name = "Step_CheckBox";
            this.Step_CheckBox.Size = new System.Drawing.Size(62, 21);
            this.Step_CheckBox.TabIndex = 10;
            this.Step_CheckBox.Text = "Шаги";
            this.Step_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 612);
            this.Controls.Add(this.Step_CheckBox);
            this.Controls.Add(this.NodeErrorInput_Label);
            this.Controls.Add(this.DeleteAllNodes_Button);
            this.Controls.Add(this.AddNode_Button);
            this.Controls.Add(this.Node_TextBox);
            this.Controls.Add(this.Nodes_DataGridView);
            this.Controls.Add(this.CreateGraph_Button);
            this.Controls.Add(this.DeleteAllEdges_Button);
            this.Controls.Add(this.EdgeErrorInput_Label);
            this.Controls.Add(this.AddEdge_Button);
            this.Controls.Add(this.Edges_DataGridView);
            this.Controls.Add(this.Arrow_Label);
            this.Controls.Add(this.BNode_TextBox);
            this.Controls.Add(this.ANode_TextBox);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "ИТС - 2 v.0.6";
            ((System.ComponentModel.ISupportInitialize)(this.Edges_DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nodes_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ANode_TextBox;
        private System.Windows.Forms.TextBox BNode_TextBox;
        private System.Windows.Forms.Label Arrow_Label;
        private System.Windows.Forms.DataGridView Edges_DataGridView;
        private System.Windows.Forms.Button AddEdge_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edges;
        private System.Windows.Forms.Label EdgeErrorInput_Label;
        private System.Windows.Forms.Button DeleteAllEdges_Button;
        private System.Windows.Forms.Button CreateGraph_Button;
        private System.Windows.Forms.DataGridView Nodes_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox Node_TextBox;
        private System.Windows.Forms.Button AddNode_Button;
        private System.Windows.Forms.Button DeleteAllNodes_Button;
        private System.Windows.Forms.Label NodeErrorInput_Label;
        private System.Windows.Forms.CheckBox Step_CheckBox;
    }
}

