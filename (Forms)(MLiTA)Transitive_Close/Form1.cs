using System;
using System.Windows.Input;
using System.IO;
using System.Collections.Generic;

using System.Windows.Forms;

namespace _Forms__MLiTA_Transitive_Close
{
    public partial class Form1 : Form
    {
        #region Global
        /// <summary>
        /// Ориентация добавляеммого ребра
        /// </summary>
        public byte ButtonState;
        public Graph graph = new Graph();
        /// <summary>
        /// Список точек графа
        /// </summary>
        List<string> nodesList = new List<string>();
        #endregion

        public Form1()
        {
            InitializeComponent();

            //ActiveForm.Width= 527;
            //ActiveForm.Height = 659;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            ButtonState = 0;
            //ChangeArrowDirrection();

            Edges_DataGridView.AllowUserToAddRows = false;
            Edges_DataGridView.ColumnHeadersVisible = false;
            Edges_DataGridView.RowHeadersVisible = false;
            Edges_DataGridView.Columns[0].Width = Edges_DataGridView.Width;
            Edges_DataGridView.AllowDrop = true;

            Nodes_DataGridView.AllowUserToAddRows = false;
            Nodes_DataGridView.ColumnHeadersVisible = false;
            Nodes_DataGridView.RowHeadersVisible = false;
            Nodes_DataGridView.Columns[0].Width = Nodes_DataGridView.Width;
            Nodes_DataGridView.AllowDrop = true;
        }

        /// <summary>
        /// Добавление ребра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEdge_Button_Click(object sender, EventArgs e)
        {
            ANode_TextBox.Text = ANode_TextBox.Text.Trim('_');
            BNode_TextBox.Text = BNode_TextBox.Text.Trim('_');

            if ((ANode_TextBox.Text != "") && (BNode_TextBox.Text != "") && NodeExist(ANode_TextBox.Text) && NodeExist(BNode_TextBox.Text))
            {
                EdgeErrorInput_Label.Text = "";
                Edges_DataGridView.Rows.Add(ANode_TextBox.Text + Arrow_Label.Text + BNode_TextBox.Text);
                ANode_TextBox.Text = "";
                BNode_TextBox.Text = "";
            }
            else
                EdgeErrorInput_Label.Text = "Неккоректное имя вершины";
            ANode_TextBox.Focus();

            if ((graph.Created) && (graph.Visible))
            {
                //CreateGraph_Button_Click(sender, e);
                graph.AddEdge(Edges_DataGridView.Rows[Edges_DataGridView.Rows.Count - 1], true);
                //graph.DrawEdge(Edges_DataGridView.Rows.Count - 1);
            }
        }

        /// <summary>
        /// Присутствует ли эта вершина в списке
        /// </summary>
        /// <param name="node">Вершина, проверяемая на присутствие</param>
        /// <returns></returns>
        private bool NodeExist(string node)
        {
            foreach (DataGridViewRow i in Nodes_DataGridView.Rows)
                if (i.Cells[0].Value.ToString() == node)
                    return true;
            return false;
        }

        private void ANode_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
                AddEdge_Button_Click(sender, e);

            //if ((ModifierKeys == Keys.Control) && Keyboard.IsKeyDown(Key.Q))
            //ChangeArrowDirrection();

            if ((ModifierKeys == Keys.Control) && Keyboard.IsKeyDown(Key.W))
                CreateGraph_Button_Click(sender, e);

            //Input Check
            if (char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '_'))
                return;
            e.Handled = true;
        }

        /// <summary>
        /// Смена ориентации ребра (Вырезано)
        /// </summary>
        private void ChangeArrowDirrection()
        {
            ButtonState++;
            ButtonState %= 3;
            switch (ButtonState)
            {
                case 0: Arrow_Label.Text = "--->"; break;
                case 1: Arrow_Label.Text = "<---"; break;
                case 2: Arrow_Label.Text = "<-->"; break;
            }
        }

        /// <summary>
        /// Обработка одного ребера из файла
        /// </summary>
        /// <param name="str">Обрабатываемое ребро</param>
        private void FileStreamEdit(string str)
        {
            if (/*!str.Contains("<") && */!str.Contains(">"))
                return;
            string[] mas = str.Split(new char[] { /*'<',*/ '>', '-' });

            if (!nodesList.Contains(mas[0]))
                nodesList.Add(mas[0]);
            if (!nodesList.Contains(mas[mas.Length - 1]))
                nodesList.Add(mas[mas.Length - 1]);

            if (mas.Length != 2)
                if ((mas.Length == 3) && (mas[1] != ""))
                    return;
            foreach (char i in mas[0])
                if (!char.IsLetterOrDigit(i) && i != '_')
                    return;
            foreach (char i in mas[mas.Length - 1])
                if (!char.IsLetterOrDigit(i) && i != '_')
                    return;
            mas[0] = mas[0].Trim('_');
            mas[1] = mas[mas.Length - 1].Trim('_');
            if ((mas[0].Length == 0) || (mas[mas.Length - 1].Length == 0))
                return;

            str = mas[0] + (str.Contains("<") ? "<" : "-") + "--" + (str.Contains(">") ? ">" : "-") + mas[mas.Length - 1];

            Edges_DataGridView.Rows.Add(str);
        }

        private void Edges_DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Edges_DataGridView.Rows.RemoveAt(e.RowIndex);

            if ((graph.Created) && (graph.Visible))
                CreateGraph_Button_Click(sender, e);
        }

        private void Arrow_Label_Click(object sender, EventArgs e)
        {
            //ChangeArrowDirrection();
            ANode_TextBox.Focus();
        }

        /// <summary>
        /// Удаление ребра из списка кнопкой delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edges_DataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                Edges_DataGridView.Rows.RemoveAt(Edges_DataGridView.Rows.IndexOf(Edges_DataGridView.CurrentRow));
                if ((graph.Created) && (graph.Visible))
                    CreateGraph_Button_Click(sender, e);
            }
        }

        /// <summary>
        /// Обработка фала, сброшенного на Edges_DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edges_DataGridView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] DropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    for (int i = 0; i < DropFiles.Length; i++)
                    {
                        StreamReader sr = new StreamReader(DropFiles[i]);
                        do
                        {
                            FileStreamEdit(sr.ReadLine());
                        } while (!sr.EndOfStream);
                        sr.Close();
                    }

                    Nodes_DataGridView.Rows.Clear();
                    foreach (string i in nodesList)
                        Nodes_DataGridView.Rows.Add(i);

                    if ((graph.Created) && (graph.Visible))
                        CreateGraph_Button_Click(sender, e);
                }
                catch (Exception ex) { throw ex; }
            }
        }

        private void Edges_DataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private void DeleteAll_Button_Click(object sender, EventArgs e)
        {
            Edges_DataGridView.Rows.Clear();
            ANode_TextBox.Focus();

            if ((graph.Created) && (graph.Visible))
                CreateGraph_Button_Click(sender, e);
        }

        private void CreateGraph_Button_Click(object sender, EventArgs e)
        {
            if ((Nodes_DataGridView.Rows.Count != 0) && ((!graph.Created) || (!graph.Visible)))
            {
                graph = new Graph();
                graph.Show();
            }

            if (Nodes_DataGridView.Rows.Count != 0)
                graph.Rewrite(Edges_DataGridView.Rows, nodesList);
        }

        //Nodes
        private void AddNode_Button_Click(object sender, EventArgs e)
        {
            Node_TextBox.Text = Node_TextBox.Text.Trim('_');

            if ((Node_TextBox.Text != "") && !NodeExist(Node_TextBox.Text))
            {
                NodeErrorInput_Label.Text = "";
                Nodes_DataGridView.Rows.Add(Node_TextBox.Text);
                nodesList.Add(Node_TextBox.Text);
                Node_TextBox.Text = "";
            }
            else
                NodeErrorInput_Label.Text = "Неккоректное имя вершины";

            Node_TextBox.Focus();

            if ((graph.Created) && (graph.Visible))
                graph.Close();
        }

        private void Node_TextBox_KeyPress(object sender, KeyPressEventArgs e) //Backspace Debug
        {
            if (Keyboard.IsKeyDown(Key.Enter))
                AddNode_Button_Click(sender, e);

            if ((ModifierKeys == Keys.Control) && Keyboard.IsKeyDown(Key.W))
                CreateGraph_Button_Click(sender, e);

            //Input Check
            if (char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '_') && (e.KeyChar != (char)Keys.Back))
                return;
            e.Handled = true;
        }

        private void Nodes_DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DeleteEdgesWithNode(e.RowIndex);
            nodesList.RemoveAt(e.RowIndex);
            Nodes_DataGridView.Rows.RemoveAt(e.RowIndex);
            if ((graph.Created) && (graph.Visible))
                graph.Close();
        }

        /// <summary>
        /// Удаление вершины из списка кнопкой delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nodes_DataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                int i = Nodes_DataGridView.Rows.IndexOf(Nodes_DataGridView.CurrentRow);
                DeleteEdgesWithNode(i);
                nodesList.RemoveAt(i);
                Nodes_DataGridView.Rows.RemoveAt(i);
                if ((graph.Created) && (graph.Visible))
                    graph.Close();
            }
        }

        private void DeleteAllNodes_Button_Click(object sender, EventArgs e)
        {
            nodesList.Clear();
            Edges_DataGridView.Rows.Clear();
            Nodes_DataGridView.Rows.Clear();
            Node_TextBox.Focus();

            if ((graph.Created) && (graph.Visible))
                graph.Close();
        }

        private void DeleteEdgesWithNode(int nodeIndex)
        {
            string node = nodesList[nodeIndex];
            for (int i = 0; i < Edges_DataGridView.Rows.Count; i++)
                if (Edges_DataGridView.Rows[i].Cells[0].Value.ToString().Contains(node))
                {
                    Edges_DataGridView.Rows.RemoveAt(i);
                    i--;
                }
        }
    }
}
