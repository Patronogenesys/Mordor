using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mordor.Interfaces
{
    public interface IMovable : IDrawable
    {
        void MoveToPoint(Point point);
    }
}
