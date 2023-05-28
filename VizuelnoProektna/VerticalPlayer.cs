using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProektna
{
    public class VerticalPlayer : Player
    {
        public VerticalPlayer() : base()
        {
        }

        public override void Draw(Graphics g, int Width, int Height)
        {
            Brush brush = new SolidBrush(Color.Black);
            Position = new Point(10,Height/2 + Height*(1/4));

            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, 10, 150));

            Position = new Point(Width-35, Height / 2 + Height * (1 / 4));
            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, 10, 150));
            brush.Dispose()
        }

        public override void Move(int dx, int dy)
        {
            Position = new Point(dx + Position.X, dy + Position.Y);
        }
    }
}
