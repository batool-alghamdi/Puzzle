using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Shapes
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private bool isSelected;
        bool isSelected2 = false;
        Rectangle rect;
        int Xrect1 = 0;
        int Yrect1 = 0;
        int Xrect2 = 0;
        int Yrect2 = 0;
        RectangleF shapeContainer = new RectangleF();
        RectangleF shapeContainer1 = new RectangleF();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = this.CreateGraphics();
            GraphicsPath path = new GraphicsPath(FillMode.Alternate);
            path.StartFigure();
            Rectangle rect5 = new Rectangle(Xrect1, Yrect1, 50, 50);
            Rectangle rect6 = new Rectangle(Xrect1, Yrect1+50, 50, 50);
            Rectangle rect7 = new Rectangle(Xrect1+50, Yrect1+50, 50, 50);
            Rectangle rect8 = new Rectangle(Xrect1+100, Yrect1+50, 50, 50);
            Rectangle rect9 = new Rectangle(Xrect1+100, Yrect1, 50, 50);

            path.AddRectangle(rect5);
            path.AddRectangle(rect6);
            path.AddRectangle(rect7);
            path.AddRectangle(rect8);
            path.AddRectangle(rect9);
            path.CloseAllFigures();

            Pen redPen = new Pen(Color.Red, 2);
            g.DrawPath(redPen, path);
            g.FillPath(new SolidBrush(Color.Red), path);

            //new path
            GraphicsPath path1 = new GraphicsPath(FillMode.Alternate);
            path1.StartFigure();
            Rectangle rect1 = new Rectangle(Xrect2+300, Yrect2+100, 50, 50);
            Rectangle rect2 = new Rectangle(Xrect2+350, Yrect2+100, 50, 50);
            Rectangle rect3 = new Rectangle(Xrect2+350, Yrect2+150, 50, 50);
            Rectangle rect4 = new Rectangle(Xrect2+400, Yrect2+100, 50, 50);

            path1.AddRectangle(rect1);
            path1.AddRectangle(rect2);
            path1.AddRectangle(rect3);
            path1.AddRectangle(rect4);
            path1.CloseAllFigures();

            g.DrawPath(redPen, path1);
            g.FillPath(new SolidBrush(Color.Red), path1);

            /*Rectangle selectRect = new Rectangle(300, 100, 150, 50);
            Pen bluePen = new Pen(Color.Blue, 2);
            e.Graphics.DrawRectangle(bluePen, selectRect);*/

            // Rectangle selectRect1 = new Rectangle(350, 100, 50, 100);
            // e.Graphics.DrawRectangle(bluePen, selectRect1);
            shapeContainer = path.GetBounds();
            shapeContainer1 = path1.GetBounds();

            redPen.Dispose();
            g.Dispose();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle area = new Rectangle(e.Location.X, e.Location.Y, 10, 10);
            this.isSelected = this.shapeContainer.IntersectsWith(area);
            this.Invalidate();
            this.isSelected2 = this.shapeContainer1.IntersectsWith(area);
            this.Invalidate();
        }

        public bool check(MouseEventArgs mouse)
        {
            var rect1 = new System.Drawing.Rectangle(300, 100, 150, 50);
            var rect2 = new System.Drawing.Rectangle(mouse.X, mouse.Y, 10, 10);
            return rect1.IntersectsWith(rect2);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelected == true)
            {
                this.Xrect1 = e.Location.X - (int)(shapeContainer.Width / 2);
                this.Yrect1 = e.Location.Y - (int)(shapeContainer1.Height / 2);
                this.Invalidate();
            }
            else if (isSelected2 == true)
            {
                this.Xrect2 = e.Location.X - (int)(shapeContainer.Width / 2);
                this.Yrect2 = e.Location.Y - (int)(shapeContainer.Height / 2);
                this.Invalidate();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle area = new Rectangle(e.Location.X, e.Location.Y, 10, 10);
            this.isSelected = this.shapeContainer.IntersectsWith(area);
            this.Invalidate();
            this.isSelected2 = this.shapeContainer1.IntersectsWith(area);
            this.Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isSelected = false;
            isSelected2 = false;
        }
    }
}
