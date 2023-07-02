using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProektna
{
    public class Blocks
    {
        public static int Width = 40;
        public static int Height = 20;
        public Point Position { get; set; }
        public Color Color { get; set; }
        public int State { get; set; }
        public Blocks(Point Position) { 
            this.Position = Position;

        }

        public void Draw(Graphics g, Color c)
        {
          
            Color = c;
            Brush brush = new SolidBrush(Color);

            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, 80, 30));
            brush.Dispose();
        }

        public bool isHit(Point point)
        {
            return false;
        }

    }
}
