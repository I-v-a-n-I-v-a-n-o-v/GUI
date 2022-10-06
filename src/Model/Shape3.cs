using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw
{
    [Serializable]
    public class Shape3 : Shape
    {
        #region Constructor

        public Shape3(RectangleF rect) : base(rect)
        {
        }

        public Shape3(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion
        // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
        // В случая на правоъгълник - директно връщаме true
        public override bool Contains(PointF point)
        {
            if ((base.Contains(point) && (((Math.Pow(point.X - (Rectangle.X + Rectangle.Width / 2), 2) / Math.Pow((Rectangle.Width / 2), 2)) + (Math.Pow(point.Y - (Rectangle.Y + Rectangle.Height / 2), 2) / Math.Pow((Rectangle.Height / 2), 2))) <= 1)))
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                return true;
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);


            grfx.FillEllipse(new SolidBrush(Color.White), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(BorderColor, BorderWidth), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            float x1, y1, x2, y2, x3, y3, x4, y4, r, x0, y0;

            //first Line 
            //Formula:
            //double x1 = x0 + r * Math.Cos(angle * Math.PI / 180);
            //double y1 = y0 + r * Math.Sin(angle * Math.PI / 180);
            //where x0 and y0 are the coordinates of the center of the circle; r is the radius; x1,y1 is the edge point of the circle
            r = Rectangle.Width / 2;
            x0 = Rectangle.X + Rectangle.Width / 2;
            y0 = Rectangle.Y + Rectangle.Height / 2;

            x1 = (float)(x0 + r * Math.Cos(-135 * (Math.PI / 180)));
            y1 = (float)(y0 + r * Math.Sin(-135 * (Math.PI / 180)));

            x2 = (float)(x0 + r * Math.Cos(0 * (Math.PI / 180)));
            y2 = (float)(y0 + r * Math.Sin(0 * (Math.PI / 180)));

            //second Line
            x3 = (float)(x0 + r * Math.Cos(-180 * (Math.PI / 180)));
            y3 = (float)(y0 + r * Math.Sin(-180 * (Math.PI / 180)));

            x4 = (float)(x0 + r * Math.Cos(45 * (Math.PI / 180)));
            y4 = (float)(y0 + r * Math.Sin(45 * (Math.PI / 180)));

            grfx.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
            grfx.DrawLine(new Pen(Color.Black), x3, y3, x4, y4);
        }

    }
}
