using Mordor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mordor
{
    internal class Morda : IDrawable
    {
        private Point position;
        private Size size;
        private List<Ellipse> staticEllipses = new();
        private List<MovableEllipse> pupils = new();
        public Morda(Point position, Size size, Color color)
        {
            // Лицо
            staticEllipses.Add(new Ellipse(position, size, color));

            // Глаз
            Size offset = new Size(size.Width / 5, size.Height / 4);
            staticEllipses.Add(new Ellipse(position + offset, new Size(size.Width / 5, size.Height / 4), Color.White));
            // Зрачок
            offset += new Size(size.Width / 5 / 3, size.Height / 4 / 3);
            pupils.Add(new MovableEllipse(position + offset, new Size(size.Width / 5 / 3, size.Height / 4 / 3), Color.Black));
            // Глаз
            offset = new Size(size.Width / 5 * 4, size.Height / 4);
            staticEllipses.Add(new Ellipse(position + offset, new Size(size.Width / 5, size.Height / 4), Color.White));
            // Зрачок
            offset += new Size(size.Width / 5 / 3, size.Height / 4 / 3);
            pupils.Add(new MovableEllipse(position + offset, new Size(size.Width / 5 / 3, size.Height / 4 / 3), Color.Black));
            // Рот
            offset = new Size(size.Width / 5, size.Height / 5 * 3);
            staticEllipses.Add(new Ellipse(position + offset, new Size(size.Width / 5 * 3, size.Height / 4), Color.Black));


            this.Position = position;
            this.Size = size;

        }

        public Point Position
        {
            get => position;
            private set => position = value;
        }

        public Size Size
        {
            get => size;
            set => size = value;
        }

        public void Draw(Graphics gr)
        {
            foreach (var ellipse in staticEllipses)
                ellipse.Draw(gr);
            foreach (var ellipse in pupils)
                ellipse.Draw(gr);
        }

        public void MovePupilsRelative(float x, float y)
        {
            MovableEllipse left = pupils[0], right = pupils[1];
            RectangleF leftEyeRect = staticEllipses[1].InnerRect, rightEyeRect = staticEllipses[2].InnerRect;
            left.MoveToPoint(new Point(
                (int)(leftEyeRect.X + (leftEyeRect.Width - left.Size.Width) * x),
                (int)(leftEyeRect.Y + (leftEyeRect.Height - left.Size.Height) * y)));
            right.MoveToPoint(new Point(
                (int)(rightEyeRect.X + (rightEyeRect.Width - right.Size.Width) * x),
                (int)(rightEyeRect.Y + (rightEyeRect.Height - right.Size.Height) * y)));
        }
    }
}
