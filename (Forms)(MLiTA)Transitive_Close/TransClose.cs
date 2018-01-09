using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _Forms__MLiTA_Transitive_Close
{
    public partial class TransClose : Form
    {
        #region Global
        List<string> edges;
        List<string> nodesList;
        bool[,] Matrix;
        bool[] IsBlack;
        #endregion

        /// <summary>
        /// Инициализация построения транзитивного замыкания
        /// </summary>
        /// <param name="edges">Список ребер</param>
        /// <param name="nodesList">Список Вершин</param>
        public TransClose(List<string> edges, List<string> nodesList)
        {
            InitializeComponent();

            this.nodesList = nodesList;
            this.edges = edges;

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
            this.MinimumSize = new System.Drawing.Size(25, 15);
            this.MaximumSize = Screen.PrimaryScreen.Bounds.Size;
        }

        private void Draw()
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
                    Trans_DataGridView.Rows[i].Cells[k].Value = (Matrix[i, k]) ? "1" : "0";

            FormSizeChanged(true);
        }

        public void EdgeAdded(string edge)
        {
            string[] nodes = edge.Split(new char[] { '<', '-', '>' });
            //edges.Add(edge);
            Trans_DataGridView.Rows[nodesList.FindIndex(x => x == nodes[0])].Cells[nodesList.FindIndex(x => x == nodes[nodes.Length - 1])].Value = "1";

            for (int i = 0; i < nodesList.Count; i++)
                if (ToMatrix(i, nodesList.FindIndex(x => x == nodes[0])))
                    for (int k = 0; k < nodesList.Count; k++)
                        Trans_DataGridView.Rows[i].Cells[k].Value = (ToMatrix(i, k) || ToMatrix(nodesList.FindIndex(x => x == nodes[0]), k) || ToMatrix(nodesList.FindIndex(y => y == nodes[nodes.Length - 1]), k)) ? "1" : "0";
            //Matrix[i, k] = Matrix[i, k] || Matrix[nodesList.FindIndex(x => x == nodes[0]), k] || Matrix[nodesList.FindIndex(x => x == nodes[nodes.Length - 1]), k];
        }

        /// <summary>
        /// Перевод в матричное представление
        /// </summary>
        /// <param name="rowIndex">Индекс строки</param>
        /// <param name="columnIndex">Индекс столбца</param>
        private bool ToMatrix(int rowIndex, int columnIndex)
        {
            if (Trans_DataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "1")
                return true;
            return false;
        }

        public void Measurement(List<string> nodesList, List<string> edges)
        {
            this.nodesList = nodesList;
            this.edges = edges;

            Matrix = new bool[nodesList.Count, nodesList.Count];

            for (int i = 0; i < nodesList.Count; i++)
            {
                IsBlack = new bool[nodesList.Count];
                if (!IsBlack[i])
                    Rec(i, i);
            }

            Draw();
        }

        private void Rec(int i, int j)
        {
            IsBlack[j] = true;
            Matrix[i, j] = true;
            for (int k = 0; k < nodesList.Count; k++)
                if ((!IsBlack[k]) && (edges.Contains(nodesList[j] + "->-" + nodesList[k])))
                    Rec(i, k);
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
            //if (this.Size.Width < size.Width)
            //    Trans_DataGridView.Size = new System.Drawing.Size(this.Width - uselessWidth, Trans_DataGridView.Width);
            //else
            //    Trans_DataGridView.Size = size;

            //if (this.Size.Height < size.Height)
            //    Trans_DataGridView.Size = new System.Drawing.Size(Trans_DataGridView.Size.Width, this.Height - uselessHeight);
            //else
            //    Trans_DataGridView.Size = new System.Drawing.Size(Trans_DataGridView.Size.Width, size.Height);
        }
    }
}
