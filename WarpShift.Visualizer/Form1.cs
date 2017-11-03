using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarpShift.Visualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += (s, e) =>
            {
                this.pictureBox1.Paint += PictureBox1_Paint;
            };
        }
        private string mapString;
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mapString != null)
            {
                //var drawFactor = 16;
                //e.Graphics.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);

                //for (int i = 0; i < state.Width; i++)
                //{
                //    for (int j = 0; j < state.Height; j++)
                //    {
                //        e.Graphics.FillRectangle(state[i, j] == Tile.Water ? Brushes.DarkBlue : Brushes.LimeGreen, i * drawFactor, j * drawFactor, drawFactor, drawFactor);
                //    }
                //}

                //for (int i = 0; i < cc.ClusterCount; i++)
                //{
                //    for (int j = 0; j < cc.ClusterCount; j++)
                //    {
                //        var cluster = cc[i, j];

                //        e.Graphics.DrawRectangle(Pens.Black, cluster.Position.Col * drawFactor, cluster.Position.Row * drawFactor, cluster.ClusterSize.Col * drawFactor, cluster.ClusterSize.Row * drawFactor);

                //        foreach (var transit in cluster.TransistPoints)
                //        {
                //            e.Graphics.FillRectangle(Brushes.Red, transit.Col * drawFactor, transit.Row * drawFactor, drawFactor, drawFactor);

                //            foreach (TransitNode connection in transit.Edges)
                //            {
                //                if ((connection - transit).Length() < 50)
                //                    e.Graphics.DrawLine(Pens.DodgerBlue, transit.Col * drawFactor + drawFactor / 2, transit.Row * drawFactor + drawFactor / 2, connection.Col * drawFactor + drawFactor / 2, connection.Row * drawFactor + drawFactor / 2);
                //            }

                //        }
                //    }
                //}

                //if (path != null)
                //{
                //    for (int i = 1; i < path.Count; i++)
                //    {
                //        e.Graphics.DrawLine(Pens.Aqua, path[i - 1].Col * drawFactor + drawFactor / 2, path[i - 1].Row * drawFactor + drawFactor / 2,
                //                            path[i].Col * drawFactor + drawFactor / 2, path[i].Row * drawFactor + drawFactor / 2);
                //    }
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mapString = textBox1.Text;
            pictureBox1.Invalidate();
        }

    }
}
