using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _Forms__MLiTA_Transitive_Close
{
    public partial class Graph : Form
    {
        #region Global
        /// <summary>
        /// Список точек графа
        /// </summary>
        List<string> nodesList;
        /// <summary>
        /// Координаты точек графа
        /// </summary>
        List<PointF> nodesCoords;
        /// <summary>
        /// Ребра графа
        /// </summary>
        List<string> edges;

        Graphics graph;

        /// <summary>
        /// Для вызова конструктора транзитивного замыкания
        /// </summary>
        public TransClose trc;
        #endregion

        public Graph()
        {
            InitializeComponent();

            this.Size = new Size(700, 700);
            this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(Form1.ActiveForm.Location.X + Form1.ActiveForm.Width, Form1.ActiveForm.Location.Y);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.Size = new Size(500, 450);
        }

        private void Graph_PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.MediumAquamarine, 3);
            SolidBrush brush = new SolidBrush(Color.Blue);
            Font font = new Font(FontFamily.GenericMonospace, 10);
            graph = e.Graphics;
            const int radius = 2;
            const int ArrowLength = 20;
            const int ArrowAngle = 15;
            float ArrowWidth = ArrowLength * (float)Math.Tan(ArrowAngle * Math.PI / 180);

            foreach (string i in edges)
            {
                string[] args = i.Split('-');
                PointF[] nodes = new PointF[] { nodesCoords[nodesList.FindIndex(x => x == args[0])], nodesCoords[nodesList.FindIndex(y => y == args[2])] };
                graph.DrawLine(pen, nodes[0], nodes[1]);

                Point center = new Point(200, 200);//new Point(ActiveForm.Width / 2, ActiveForm.Height / 2);
                nodes[0] = new PointF(nodes[0].X - center.X, nodes[0].Y - center.Y);
                nodes[1] = new PointF(nodes[1].X - center.X, nodes[1].Y - center.Y);

                PointF[] C = new PointF[2];
                float fi = (float)Math.Atan((nodes[1].Y - nodes[0].Y) / (nodes[1].X - nodes[0].X));

                if (nodes[0].X > nodes[1].X)
                    fi += (float)Math.PI;
                C[1] = new PointF(nodes[1].X - ArrowLength * (float)Math.Cos(fi), nodes[1].Y - ArrowLength * (float)Math.Sin(fi)); //O
                C[0] = new PointF(C[1].X + ArrowWidth * (float)Math.Sin(fi), C[1].Y - ArrowWidth * (float)Math.Cos(fi));
                C[1] = new PointF(C[1].X - ArrowWidth * (float)Math.Sin(fi), C[1].Y + ArrowWidth * (float)Math.Cos(fi));

                C[0] = new PointF(center.X + C[0].X, center.Y + C[0].Y);
                C[1] = new PointF(center.X + C[1].X, center.Y + C[1].Y);
                nodes[0] = new PointF(center.X + nodes[0].X, center.Y + nodes[0].Y);
                nodes[1] = new PointF(center.X + nodes[1].X, center.Y + nodes[1].Y);

                graph.FillPolygon(brush, new PointF[] { nodes[1], C[0], C[1] });
            }

            pen.Color = Color.Black;
            brush = new SolidBrush(Color.Black);
            for (int i = 0; i < nodesCoords.Count; i++)
            {
                graph.DrawEllipse(pen, nodesCoords[i].X - radius, nodesCoords[i].Y - radius, 2 * radius, 2 * radius);
                graph.DrawString(nodesList[i], font, brush, nodesCoords[i]);
            }

            pen.Dispose();
            brush.Dispose();
            font.Dispose();
        }

        /// <summary>
        /// Преобразование массива строк DataGridView к списку и вычисление координат вершин
        /// </summary>
        /// <param name="rows">Массив строк</param>
        /// /// <param name="nodesList">Список вершин</param>
        public void Rewrite(DataGridViewRowCollection rows, List<string> nodesList)
        {
            this.nodesList = nodesList;
            nodesCoords = new List<PointF>();
            edges = new List<string>();

            for (int i = 0; i < rows.Count; i++)
            {
                AddEdge(rows[i], false);
            }


            Point center = new Point(200, 200); //ActiveForm.Width / 2, ActiveForm.Height / 2);
            double fi = 2 * Math.PI / nodesList.Count;
            int scale = 150;

            for (int i = 0; i < nodesList.Count; i++)
            {
                nodesCoords.Add(new PointF((float)Math.Cos(fi * i) * scale + center.X, (float)Math.Sin(fi * i) * scale + center.Y));
            }

            if ((trc == null) || (!trc.Visible))
            {
                trc = new TransClose(edges, nodesList);
                trc.Show();
            }

            if (nodesList.Count != 0)
                trc.Measurement(nodesList, edges);

            Graph_PictureBox.Refresh();
        }

        private void Graph_FormClosed(object sender, FormClosedEventArgs e)
        {
            trc.Close();
            trc = null;

        }

        /// <summary>
        /// Добавляет ребро в список
        /// </summary>
        /// <param name="row"></param>
        public void AddEdge(DataGridViewRow row, bool isRefresh)
        {
            string val = row.Cells[0].Value.ToString();
            string[] str = val.Split(new char[] { '<', '-', '>' });

            if (val.IndexOf('>') != -1)
                if (val.IndexOf('<') != -1)
                    edges.Add(str[0] + "-+-" + str[str.Length - 1]);
                else
                    edges.Add(str[0] + "->-" + str[str.Length - 1]);
            else
                edges.Add(str[str.Length - 1] + "-<-" + str[0]);

            if ((nodesList.Count != 0) && isRefresh)
                trc.EdgeAdded(val);

            if (isRefresh)
                Graph_PictureBox.Refresh();
        }

        public void DrawEdge(int edgeIndex)
        {
            Pen pen = new Pen(Color.MediumAquamarine, 3);
            SolidBrush brush = new SolidBrush(Color.Blue);

            const int ArrowLength = 20;
            const int ArrowAngle = 15;
            float ArrowWidth = ArrowLength * (float)Math.Tan(ArrowAngle * Math.PI / 180);

            string[] args = edges[edgeIndex].Split('-');
            PointF[] nodes = new PointF[] { nodesCoords[nodesList.FindIndex(x => x == args[0])], nodesCoords[nodesList.FindIndex(y => y == args[2])] };
            graph.DrawLine(pen, nodes[0], nodes[1]);

            Point center = new Point(200, 200); //ActiveForm.Width / 2, ActiveForm.Height / 2);
            nodes[0] = new PointF(nodes[0].X - center.X, nodes[0].Y - center.Y);
            nodes[1] = new PointF(nodes[1].X - center.X, nodes[1].Y - center.Y);

            PointF[] C = new PointF[2];
            float fi = (float)Math.Atan((nodes[1].Y - nodes[0].Y) / (nodes[1].X - nodes[0].X));

            if (nodes[0].X > nodes[1].X)
                fi += (float)Math.PI;
            C[1] = new PointF(nodes[1].X - ArrowLength * (float)Math.Cos(fi), nodes[1].Y - ArrowLength * (float)Math.Sin(fi)); //O
            C[0] = new PointF(C[1].X + ArrowWidth * (float)Math.Sin(fi), C[1].Y - ArrowWidth * (float)Math.Cos(fi));
            C[1] = new PointF(C[1].X - ArrowWidth * (float)Math.Sin(fi), C[1].Y + ArrowWidth * (float)Math.Cos(fi));

            C[0] = new PointF(center.X + C[0].X, center.Y + C[0].Y);
            C[1] = new PointF(center.X + C[1].X, center.Y + C[1].Y);
            nodes[0] = new PointF(center.X + nodes[0].X, center.Y + nodes[0].Y);
            nodes[1] = new PointF(center.X + nodes[1].X, center.Y + nodes[1].Y);

            graph.FillPolygon(brush, new PointF[] { nodes[1], C[0], C[1] });

            pen.Dispose();
            brush.Dispose();
        }
    }
}
