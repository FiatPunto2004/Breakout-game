using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProektna
{
    public class HorizonralPlayer : Player
    {

        public HorizonralPlayer() : base()
        {
        }

        public override void Draw(Graphics g, int Width, int Height)
        {
            Brush brush = new SolidBrush(Color.Black);
            Position = new Point((Width / 2)-125, Height-65);
            
            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, 250, 10));
            brush.Dispose();
        }

        public override void Move(int dx, int dy)
        {
            Position = new Point(dx + Position.X, dy + Position.Y);
        }
    }
}
