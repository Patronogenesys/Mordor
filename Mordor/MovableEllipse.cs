using Mordor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mordor
{
    public class MovableEllipse : Ellipse, IMovable
    {
        public MovableEllipse(Point position, Size size, Color color) : base(position, size, color) { }

        public void MoveToPoint(Point point)
        {
            innerRect.X += point.X - Position.X;
            innerRect.Y += point.Y - Position.Y;
            Position = point;
        }
    }
}
