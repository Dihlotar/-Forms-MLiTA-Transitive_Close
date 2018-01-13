using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _Forms__MLiTA_Transitive_Close
{
    public partial class TransClose : Form
    {
        #region Global
        List<string> nodesList;
        ulong[] matrix;
        #endregion

        /// <summary>
        /// Инициализация построения транзитивного замыкания
        /// </summary>
        /// <param name="edges">Список ребер</param>
        /// <param name="nodesList">Список Вершин</param>
        public TransClose(List<string> nodesList, ulong[] matrix)
        {
            InitializeComponent();

            this.matrix = matrix;
            this.nodesList = nodesList;

            Trans_DataGridView.AllowUserToAddRows = false;
            Trans_DataGridView.ReadOnly = true;

            DataGridViewCellStyle CustomStyle = new DataGridViewCellStyle();
            CustomStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CustomStyle.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 15);
            Trans_DataGridView.DefaultCellStyle = CustomStyle;
            Trans_DataGridView.ColumnHeadersDefaultCellStyle = CustomStyle;
            Trans_DataGridView.RowHeadersDefaultCellStyle = CustomStyle;

            Trans_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Trans_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //Trans_DataGridView.RowHeadersWidth = 100;
            this.MinimumSize = new System.Drawing.Size(180, 180);
            this.MaximumSize = Screen.PrimaryScreen.Bounds.Size;

            DrawBase();
        }

        private void DrawBase()
        {
            const int CellSize = 40;
            Trans_DataGridView.Columns.Clear();
            Trans_DataGridView.Rows.Clear();

            foreach (string i in nodesList)
            {
                Trans_DataGridView.Columns.Add(i, i);
                Trans_DataGridView.Columns[Trans_DataGridView.Columns.Count - 1].Width = CellSize;

                Trans_DataGridView.Rows.Add();
                Trans_DataGridView.Rows[Trans_DataGridView.Rows.Count - 1].HeaderCell.Value = i;
                Trans_DataGridView.Rows[Trans_DataGridView.Rows.Count - 1].Height = CellSize;
                if (Trans_DataGridView.RowHeadersWidth < i.Length * 15)
                    Trans_DataGridView.RowHeadersWidth = i.Length * 15;
            }

            for (int i = 0; i < nodesList.Count; i++)
                for (int k = 0; k < nodesList.Count; k++)
                    Trans_DataGridView.Rows[i].Cells[k].Value = ((matrix[i] >> k) & 1).ToString();

            FormSizeChanged(true);
        }

        public void DrawRow(int row, ulong value)
        {
            matrix[row] = value;
            for (int i = 0; i < nodesList.Count; i++)
                Trans_DataGridView.Rows[row].Cells[i].Value = ((value >> i) & 1).ToString();
        }

        public void DrawEdge(int row, int column)
        {
            Trans_DataGridView.Rows[row].Cells[column].Value = "1";
            matrix[row] |= ((ulong)1 << column);
        }

        private void Trans_DataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            Trans_DataGridView.Columns[Trans_DataGridView.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void TransClose_SizeChanged(object sender, EventArgs e)
        {
            FormSizeChanged(false);
        }

        private void FormSizeChanged(bool isFormSize)
        {
            const int uselessHeight = 47;
            const int uselessWidth = 17;
            System.Drawing.Size size = new System.Drawing.Size(Trans_DataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + Trans_DataGridView.RowHeadersWidth, Trans_DataGridView.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + Trans_DataGridView.ColumnHeadersHeight);

            if (isFormSize)
                this.Size = new System.Drawing.Size(size.Width + uselessWidth, size.Height + uselessHeight);

            Trans_DataGridView.Update();
            if (this.Size.Width < size.Width)
                Trans_DataGridView.Size = new System.Drawing.Size(this.Width - uselessWidth, Trans_DataGridView.Width);
            else
                Trans_DataGridView.Size = size;

            if (this.Size.Height < size.Height)
                Trans_DataGridView.Size = new System.Drawing.Size(Trans_DataGridView.Size.Width, this.Height - uselessHeight);
            else
                Trans_DataGridView.Size = new System.Drawing.Size(Trans_DataGridView.Size.Width, size.Height);
        }
    }
}
