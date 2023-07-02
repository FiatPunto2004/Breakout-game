using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProektna
{
    public class HorizontalPlayer : Player
    {

        public static int width = 120;
        public static int height = 10;

        public HorizontalPlayer(int Width, int Height) : base()
        {
            Position = new Point((Width / 2) - 60, Height - 75);
        }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            
            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, width, height));
            brush.Dispose();
        }

        public override void Move(int dx, int dy)
        {
            Position = new Point(dx + Position.X, dy + Position.Y);
        }
    }
}
