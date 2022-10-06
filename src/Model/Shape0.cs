using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class Shape0 : Shape
    {
        #region Constructor

        public Shape0(RectangleF tri) : base(tri)
        {
        }

        public Shape0(TriangleShape triangle) : base(triangle)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        /// 
        private double Area(float x1, float y1, float x2,
                       float y2, float x3, float y3)
        {
            return Math.Abs((x1 * (y2 - y3) +
                             x2 * (y3 - y1) +
                             x3 * (y1 - y2)) / 2.0);
        }
        public override bool Contains(PointF point)
        {
            float x1, x2, x3, y1, y2, y3, x, y;

            x1 = Rectangle.X + Rectangle.Width / 2;
            x2 = Rectangle.X;
            x3 = Rectangle.X + Rectangle.Width;

            y1 = Rectangle.Y;
            y2 = Rectangle.Y + Rectangle.Height;
            y3 = Rectangle.Y + Rectangle.Height;

            x = point.X;
            y = point.Y;
            double A = Area(x1, y1, x2, y2, x3, y3);

            // Area of PBC 
            double A1 = Area(x, y, x2, y2, x3, y3);

            // Area of PAC 
            double A2 = Area(x1, y1, x, y, x3, y3);

            //Area of PAB 
            double A3 = Area(x1, y1, x2, y2, x, y);

            // Check if sum of A1, A2 and A3 is same as A 
            //return (A == A1 + A2 + A3);
            if (A == A1 + A2 + A3)

                return true;
            else

                return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {

            base.DrawSelf(grfx);

            base.RotateShape(grfx);

            Point[] p = { new Point((int)Rectangle.X + ((int)Rectangle.Width / 2), (int)Rectangle.Y), new Point((int)Rectangle.X, (int)(Rectangle.Y + Rectangle.Height)), new Point((int)(Rectangle.X + Rectangle.Width), (int)(Rectangle.Y + Rectangle.Height)) };
            grfx.FillPolygon(new SolidBrush(Color.White), p);
            grfx.DrawPolygon(new Pen(BorderColor, BorderWidth), p);
            grfx.DrawLine(new Pen(BorderColor), Rectangle.X + Rectangle.Width / 2, Rectangle.Y, Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
            grfx.DrawLine(new Pen(BorderColor), Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
            grfx.DrawLine(new Pen(BorderColor), Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2, Rectangle.X, Rectangle.Y + Rectangle.Height);
            grfx.ResetTransform();

        }
    }
}