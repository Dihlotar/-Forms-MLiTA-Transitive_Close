using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace _Forms__MLiTA_Transitive_Close
{
    public partial class Graph : Form
    {
        #region Global
        TransClose trc;
        Graphics graph;
        Graphics tgraph;
        GraphInfo gi;
        StepArgs sa = new StepArgs();
        #endregion

        private struct GraphInfo
        {
            public List<string> nodesList;
            public List<PointF> nodesCoords;
            public List<string> edges;
            public Point center;
            public ulong[] matrix;
            public bool isSpain;

            public GraphInfo(List<string> nodesList, List<string> edges, bool isSpain)
            {
                this.nodesList = nodesList;
                this.edges = edges;
                matrix = new ulong[nodesList.Count];
                nodesCoords = new List<PointF>(nodesList.Count);
                center = new Point(200, 300);
                this.isSpain = isSpain;

                MatrixReflex();
                MeasureMatrix();
                MeasureCoords();
            }

            /// <summary>
            /// Единицы по главной диагонали
            /// </summary>
            private void MatrixReflex()
            {
                for (int i = 0; i < matrix.Length; i++)
                    matrix[i] = (ulong)1 << i;
            }

            /// <summary>
            /// Расчет координат точек на графе
            /// </summary>
            private void MeasureCoords()
            {
                double fi = 2 * Math.PI / nodesList.Count;
                int scale = 200;

                for (int i = 0; i < nodesList.Count; i++)
                {
                    nodesCoords.Add(new PointF((float)Math.Cos(fi * i) * scale + center.X, (float)Math.Sin(fi * i) * scale + center.Y));
                }
            }

            /// <summary>
            /// Расчет матрицы смежности
            /// </summary>
            private void MeasureMatrix()
            {
                foreach (string edge in edges)
                {
                    Indexes indexes = AddEdge(edge);
                    for (int k = 0; k < nodesList.Count; k++)
                        AddSubEdge(indexes, k);
                }
            }

            /// <summary>
            /// Добавить ребро в матрицу
            /// </summary>
            /// <param name="edge">Добавляемое ребро</param>
            /// <returns></returns>
            public Indexes AddEdge(string edge)
            {
                string[] nodes = edge.Split(new char[] { '-', '>' });
                Indexes i = new Indexes(nodesList.IndexOf(nodes[0]), nodesList.IndexOf(nodes[nodes.Length - 1]));

                matrix[i.strartIndex] |= (ulong)1 << i.endIndex;

                return i;
            }

            /// <summary>
            /// Добавление одного из новообразовнных ребер из других вершин в матрицу
            /// </summary>
            /// <param name="indexes">Индексы начальной и конечной точки ребра</param>
            /// <param name="index">Индекс обрабатываемой вершины</param>
            public bool AddSubEdge(Indexes indexes, int index)
            {
                if (index != indexes.endIndex && (((matrix[index] >> indexes.strartIndex) & 1) == 1))
                {
                    matrix[index] |= matrix[indexes.endIndex];
                    return true;
                }
                return false;
            }
        }

        private struct Indexes
        {
            public int strartIndex;
            public int endIndex;

            public Indexes(int startIndex, int endIndex)
            {
                this.strartIndex = startIndex;
                this.endIndex = endIndex;
            }
        }

        private struct StepArgs
        {
            public int step;
            public bool isStep;
            public string edge;
            public string[] nodes;
            public Indexes ixes;
            public int xEntry;

            public StepArgs(string edge)
            {
                step = 0;
                isStep = false;
                this.edge = edge;
                nodes = new string[2];
                ixes = new Indexes();
                xEntry = 0;
            }
        }

        public Graph(List<string> nodesList, List<string> edges, bool isSpain)
        {
            InitializeComponent();

            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(Form1.ActiveForm.Location.X + Form1.ActiveForm.Width, Form1.ActiveForm.Location.Y);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.Size = new Size(500, 450);

            gi = new GraphInfo(nodesList, edges, isSpain);
            trc = new TransClose(nodesList, gi.matrix);
            trc.Show();
        }

        private void Graph_PictureBox_Paint(object sender, PaintEventArgs e)
        {
            const float beta = 0.2f;
            const float step = 0.2f;
            graph = e.Graphics;
            Pen pen1 = new Pen(Color.MediumAquamarine);
            Pen pen2 = pen1;
            Pen pen3 = new Pen(Color.Red);

            for (int i = 0; i < gi.edges.Count; i++)
            {
                string[] nodes = gi.edges[i].Split(new char[] { '-', '>' });
                if (gi.isSpain)
                {
                    if ((((gi.matrix[gi.nodesList.IndexOf(nodes[nodes.Length - 1])]) >> gi.nodesList.IndexOf(nodes[0])) & 1) == 1)
                        pen1 = new Pen(Color.MediumVioletRed);
                    GraphicsExtension.DrawBSpline(graph, pen1, pen2, pen3, new PointF[] { gi.nodesCoords[gi.nodesList.IndexOf(nodes[0])], gi.center, gi.nodesCoords[gi.nodesList.IndexOf(nodes[nodes.Length - 1])] }, beta, step);
                    pen1 = new Pen(Color.MediumAquamarine);
                }
                else
                    DrawEdge(gi.nodesList.IndexOf(nodes[0]), gi.nodesList.IndexOf(nodes[nodes.Length - 1]), graph);
            }
            DrawNodes(graph);
        }

        private void TGraph_PictureBox_Paint(object sender, PaintEventArgs e)
        {
            const float beta = 0.2f;
            const float step = 0.2f;
            tgraph = e.Graphics;
            Pen pen1 = new Pen(Color.MediumAquamarine);
            Pen pen2 = pen1;
            Pen pen3 = new Pen(Color.Red);

            for (int i = 0; i < gi.matrix.Length; i++)
            {
                ulong num = gi.matrix[i];
                int k = 0;
                while (num != 0)
                {
                    if ((i != k) && ((num & 1) == 1))
                        if (gi.isSpain)
                        {
                            if (((gi.matrix[k] >> i) & 1) == 1)
                                pen1 = new Pen(Color.MediumVioletRed);
                            GraphicsExtension.DrawBSpline(tgraph, pen1, pen2, pen3, new PointF[] { gi.nodesCoords[i], gi.center, gi.nodesCoords[k] }, beta, step);
                            pen1 = new Pen(Color.MediumAquamarine);
                        }
                        else
                            DrawEdge(i, k, tgraph);
                    k++;
                    num = num >> 1;
                }
            }
            DrawNodes(tgraph);
        }

        private void Graph_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (trc != null)
            {
                trc.Close();
                trc = null;
            }
        }

        private void DrawNodes(Graphics graph) //Разобраться с названиями
        {
            const int radius = 2;
            const int strCorrect = 5;
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font(FontFamily.GenericMonospace, 10);

            for (int i = 0; i < gi.nodesCoords.Count; i++)
            {
                float xCorrect = strCorrect * ((gi.nodesCoords[i].X < 0) ? -1 : 1);
                float yCorrect = strCorrect * ((gi.nodesCoords[i].Y < 0) ? -1 : 1);
                graph.DrawEllipse(pen, gi.nodesCoords[i].X - radius, gi.nodesCoords[i].Y - radius, 2 * radius, 2 * radius);
                graph.DrawString(gi.nodesList[i], font, brush, gi.nodesCoords[i].X + xCorrect, gi.nodesCoords[i].Y + yCorrect); //Лажа
            }

            pen.Dispose();
            brush.Dispose();
            font.Dispose();
        }

        public void DrawEdge(int indexOfStart, int indexOfEnd, Graphics graph)
        {
            Pen pen = new Pen(Color.MediumAquamarine, 2);
            SolidBrush brush = new SolidBrush(Color.Blue);

            const int ArrowLength = 20;
            const int ArrowAngle = 10;
            float ArrowWidth = ArrowLength * (float)Math.Tan(ArrowAngle * Math.PI / 180);

            PointF[] nodes = new PointF[] { gi.nodesCoords[indexOfStart], gi.nodesCoords[indexOfEnd] };
            graph.DrawLine(pen, nodes[0], nodes[1]);

            Point center = new Point(200, 200);
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

        public void ChangeVisual(bool isSpain)
        {
            gi.isSpain = isSpain;
            Graph_PictureBox.Refresh();
            TGraph_PictureBox.Refresh();
        }

        public void AddEdge(string edge)
        {
            Indexes indexes = gi.AddEdge(edge);
            gi.edges.Add(edge);
            trc.DrawEdge(indexes.strartIndex, indexes.endIndex);

            for (int i = 0; i < gi.nodesList.Count; i++)
                if (gi.AddSubEdge(indexes, i))
                    trc.DrawRow(i, gi.matrix[i]);

            Graph_PictureBox.Refresh();
            TGraph_PictureBox.Refresh();
        }

        #region Steps
        private void NextStep_Button_Click(object sender, EventArgs e)
        {
            if (sa.isStep)
            {
                if (sa.step == 1)
                {
                    AddEdgeStep_1();
                    return;
                }

                if ((sa.step - 2) == (gi.nodesList.Count))
                {
                    AddEdge_F();
                    return;
                }

                switch (sa.xEntry)
                {
                    case -1: AddEdge_X_0(sa.step - 2); break;
                    case 0: AddEdge_X(sa.step - 2); break;
                    case 1: AddEdge_X_1(sa.step - 2); break;
                    case 2: AddEdge_X_2(sa.step - 2); break;
                }
            }
        }

        public void AddEdgeStep(string edge)
        {
            if (!sa.isStep)
            {
                sa.isStep = true;
                sa.step = 0;
                sa.edge = edge;
                NextStep_Button.Visible = true;
                AddEdgeStep_0();
            }
        }

        private void AddEdgeStep_0()
        {
            sa.nodes = sa.edge.Split(new char[] { '-', '>' });
            sa.ixes = new Indexes(gi.nodesList.IndexOf(sa.nodes[0]), gi.nodesList.IndexOf(sa.nodes[sa.nodes.Length - 1]));
            ulong arg1 = (ulong)1 << sa.ixes.endIndex;
            ulong arg2 = gi.matrix[sa.ixes.strartIndex] | arg1;

            Step_TextBox.Text = Step_TextBox.Text.Insert(0, "Применяем побитовое ИЛИ: " + DecToBin(gi.matrix[sa.ixes.strartIndex]) + " | " + DecToBin(arg1) + " = " + DecToBin(arg2) + " (" + arg2.ToString() + " в 10 с/с).\r\n\r\n");
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, "1 сдвигаем на " + sa.ixes.endIndex.ToString() + " бит влево, 1 << " + sa.ixes.endIndex.ToString() + " = " + DecToBin(arg1) + " (" + arg1.ToString() + " в 10 с/с).\r\n");
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, "В двоичной с/с: " + DecToBin(gi.matrix[sa.ixes.strartIndex]) + " (0-вой бит двоичной записи соответствует 0-вому столбцу матрицы).\r\n");
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, ">>Возьмем значение строки, соответствующей вершине '" + sa.nodes[0] + "': " + gi.matrix[sa.ixes.strartIndex].ToString() + ".\r\n");

            sa.step++;
        }

        private void AddEdgeStep_1()
        {
            sa.ixes = gi.AddEdge(sa.edge);

            trc.DrawEdge(sa.ixes.strartIndex, sa.ixes.endIndex);
            Graph_PictureBox.Refresh();
            TGraph_PictureBox.Refresh();

            Step_TextBox.Text = Step_TextBox.Text.Insert(0, "Теперь будем добавлять вершинам, из которых есть путь в '" + sa.nodes[0] + "', пути, ведущие из '" + sa.nodes[sa.nodes.Length - 1] + "'.\r\n\r\n");
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, ">>Таким образом установлен путь из '" + sa.nodes[0] + "' в '" + sa.nodes[sa.nodes.Length - 1] + "'.\r\n");

            sa.step++;
        }

        private void AddEdge_X(int i)
        {
            if (i != sa.ixes.endIndex)
            {
                ulong arg1 = gi.matrix[i] >> sa.ixes.strartIndex;
                ulong arg2 = arg1 & 1;

                Step_TextBox.Text = Step_TextBox.Text.Insert(0, "Применим к результату и к 1 побитовое И: " + DecToBin(arg1) + " & 1 = " + arg2.ToString() + "\r\n\r\n");
                Step_TextBox.Text = Step_TextBox.Text.Insert(0, "Сдвинем его на " + sa.ixes.strartIndex + " битов вправо. " + DecToBin(gi.matrix[i]) + " >> " + sa.ixes.strartIndex + " = " + DecToBin(arg1) + " (" + arg1.ToString() + " в 10 с/с).\r\n");
                Step_TextBox.Text = Step_TextBox.Text.Insert(0, ">>Возьмем значение, соответствующее вершине '" + gi.nodesList[i] + "': " + DecToBin(gi.matrix[i]) + " (" + gi.matrix[i].ToString() + " в 10 с/с).\r\n");

                if (arg2 == 1)
                    sa.xEntry = 1;
                else
                    sa.xEntry = -1;
            }
            else
                sa.step++;
        }

        private void AddEdge_X_1(int i)
        {
            ulong arg1 = gi.matrix[i] >> sa.ixes.strartIndex;
            ulong arg2 = arg1 & 1;

            arg1 = gi.matrix[i] | gi.matrix[sa.ixes.endIndex];

            Step_TextBox.Text = Step_TextBox.Text.Insert(0, "соответствующим вешинам '" + gi.nodesList[i] + " и " + gi.nodesList[sa.ixes.endIndex] + " побитовое ИЛИ: " + DecToBin(gi.matrix[i]) + " | " + DecToBin(gi.matrix[sa.ixes.endIndex]) + " = " + DecToBin(arg1) + " (" + arg1.ToString() + " в 10 с/с).\r\n\r\n");
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, "Применяем к значениям " + DecToBin(gi.matrix[i]) + " (" + gi.matrix[i].ToString() + " в 10 с/с) и " + DecToBin(gi.matrix[sa.ixes.endIndex]) + " (" + gi.matrix[sa.ixes.endIndex].ToString() + " в 10 с/с),");
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, ">>Результат равен 1, следовательно из '" + gi.nodesList[i] + "' существует путь в '" + sa.nodes[0] + "', а значит кол-во путей из '" + gi.nodesList[i] + "' могло измениться.\r\n");

            sa.xEntry = 2;
        }

        private void AddEdge_X_2(int i)
        {
            if (gi.AddSubEdge(sa.ixes, i))
                trc.DrawRow(i, gi.matrix[i]);
            TGraph_PictureBox.Refresh();

            Step_TextBox.Text = Step_TextBox.Text.Insert(0, ">>Теперь из '" + gi.nodesList[i] + "' можно попасть в вершины, в которые можно попасть из '" + sa.nodes[sa.nodes.Length - 1] + "'.\r\n\r\n");

            sa.xEntry = 0;
            sa.step++;
        }

        private void AddEdge_X_0(int i)
        {
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, ">>Результат равен 0, следовательно из '" + gi.nodesList[i] + "' не существует пути в '" + sa.nodes[0] + "', а значит кол-во путей из '" + gi.nodesList[i] + "' не меняется.\r\n\r\n");

            sa.xEntry = 0;
            sa.step++;
        }

        private void AddEdge_F()
        {
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, ">>Матрица смежности транзитивного замыкания построена\r\n\r\n");
            Step_TextBox.Text = Step_TextBox.Text.Insert(0, "=====================================================\r\n\r\n");

            sa.isStep = false;
            NextStep_Button.Visible = false;
        }

        private string DecToBin(ulong dec)
        {
            string str = "";
            while (dec != 0)
            {
                str += (dec & 1).ToString();
                dec = dec >> 1;
            }

            char[] ch = str.ToCharArray();
            Array.Reverse(ch);
            str = string.Join("", ch);

            return (str != "") ? str : "0";
        }
        #endregion
    }
    #region B-Spain_Visualisation
    static class GraphicsExtension
    {
        private static void DrawCubicCurve(this Graphics graphics, Pen pen, float beta, float step, PointF start, PointF end, float a3, float a2, float a1, float a0, float b3, float b2, float b1, float b0)
        {
            float xPrev, yPrev;
            float xNext, yNext;
            bool stop = false;

            xPrev = beta * a0 + (1 - beta) * start.X;
            yPrev = beta * b0 + (1 - beta) * start.Y;

            for (float t = step; ; t += step)
            {
                if (stop)
                    break;

                if (t >= 1)
                {
                    stop = true;
                    t = 1;
                }

                xNext = beta * (a3 * t * t * t + a2 * t * t + a1 * t + a0) + (1 - beta) * (start.X + (end.X - start.X) * t);
                yNext = beta * (b3 * t * t * t + b2 * t * t + b1 * t + b0) + (1 - beta) * (start.Y + (end.Y - start.Y) * t);

                graphics.DrawLine(pen, xPrev, yPrev, xNext, yNext);

                xPrev = xNext;
                yPrev = yNext;
            }
        }

        internal static void DrawBSpline(this Graphics graphics, Pen pen1, Pen pen2, Pen pen3, PointF[] points, float beta, float step)
        {
            if (points == null)
                throw new ArgumentNullException("The point array must not be null.");

            if (beta < 0 || beta > 1)
                throw new ArgumentException("The bundling strength must be >= 0 and <= 1.");

            if (step <= 0 || step > 1)
                throw new ArgumentException("The step must be > 0 and <= 1.");

            if (points.Length <= 1)
                return;

            if (points.Length == 2)
            {
                graphics.DrawLine(pen1, points[0], points[1]);
                return;
            }

            float a3, a2, a1, a0, b3, b2, b1, b0;
            float deltaX = (points[points.Length - 1].X - points[0].X) / (points.Length - 1);
            float deltaY = (points[points.Length - 1].Y - points[0].Y) / (points.Length - 1);
            PointF start, end;

            {
                a0 = points[0].X;
                b0 = points[0].Y;

                a1 = points[1].X - points[0].X;
                b1 = points[1].Y - points[0].Y;

                a2 = 0;
                b2 = 0;

                a3 = (points[0].X - 2 * points[1].X + points[2].X) / 6;
                b3 = (points[0].Y - 2 * points[1].Y + points[2].Y) / 6;

                start = points[0];
                end = new PointF
                (
                  points[0].X + deltaX,
                  points[0].Y + deltaY
                );

                graphics.DrawCubicCurve(pen1, beta, step, start, end, a3, a2, a1, a0, b3, b2, b1, b0);
            }

            for (int i = 1; i < points.Length - 2; i++)
            {
                a0 = (points[i - 1].X + 4 * points[i].X + points[i + 1].X) / 6;
                b0 = (points[i - 1].Y + 4 * points[i].Y + points[i + 1].Y) / 6;

                a1 = (points[i + 1].X - points[i - 1].X) / 2;
                b1 = (points[i + 1].Y - points[i - 1].Y) / 2;

                a2 = (points[i - 1].X - 2 * points[i].X + points[i + 1].X) / 2;
                b2 = (points[i - 1].Y - 2 * points[i].Y + points[i + 1].Y) / 2;

                a3 = (-points[i - 1].X + 3 * points[i].X - 3 * points[i + 1].X + points[i + 2].X) / 6;
                b3 = (-points[i - 1].Y + 3 * points[i].Y - 3 * points[i + 1].Y + points[i + 2].Y) / 6;

                start = new PointF
                (
                  points[0].X + deltaX * i,
                  points[0].Y + deltaY * i
                );

                end = new PointF
                (
                  points[0].X + deltaX * (i + 1),
                  points[0].Y + deltaY * (i + 1)
                );

                graphics.DrawCubicCurve(pen2, beta, step, start, end, a3, a2, a1, a0, b3, b2, b1, b0);
            }

            {
                a0 = points[points.Length - 1].X;
                b0 = points[points.Length - 1].Y;

                a1 = points[points.Length - 2].X - points[points.Length - 1].X;
                b1 = points[points.Length - 2].Y - points[points.Length - 1].Y;

                a2 = 0;
                b2 = 0;

                a3 = (points[points.Length - 1].X - 2 * points[points.Length - 2].X + points[points.Length - 3].X) / 6;
                b3 = (points[points.Length - 1].Y - 2 * points[points.Length - 2].Y + points[points.Length - 3].Y) / 6;

                start = points[points.Length - 1];

                end = new PointF
                (
                  points[0].X + deltaX * (points.Length - 2),
                  points[0].Y + deltaY * (points.Length - 2)
                );

                graphics.DrawCubicCurve(pen3, beta, step, start, end, a3, a2, a1, a0, b3, b2, b1, b0);
            }
        }
    }
    #endregion
}