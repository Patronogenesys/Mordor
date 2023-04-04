using Mordor.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mordor
{
    public class Ellipse : IDrawable
    {
        protected Point position;
        protected Size size;
        protected Color color;

        protected RectangleF innerRect;

        public Ellipse(Point position, Size size, Color color)
        {
            this.Position = position;
            this.Size = size;
            this.Color = color;
            float sqrt = MathF.Sqrt(2);
            float x = this.Position.X + this.Size.Width * (2 - sqrt) * 0.25f;
            float y = this.Position.Y + this.Size.Height * (2 - sqrt) * 0.25f;
            float width = this.Size.Width * sqrt * 0.5f;
            float height = this.Size.Height * sqrt * 0.5f;
            InnerRect = new RectangleF(x, y, width, height);
        }

        public Point Position { get => position; protected set => position = value; }
        public Size Size { get => size; protected set => size = value; }
        public Color Color { get => color; set => color = value; }
        public RectangleF InnerRect { get => innerRect; protected set => innerRect = value; }

        public void Draw(Graphics gr)
        {
            Rectangle rect = new Rectangle(position, size);
            SolidBrush brush = new SolidBrush(color);
            gr.FillEllipse(brush, rect);
            //gr.FillRectangle(Brushes.Magenta, innerRect);
        }
    }
}
