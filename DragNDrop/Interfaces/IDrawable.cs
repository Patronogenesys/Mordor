using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mordor.Interfaces
{
    public interface IDrawable
    {
        public Point Position { get; }
        public Size Size { get; }
        public void Draw(Graphics gr);
    }
}
