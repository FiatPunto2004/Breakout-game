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
        public Random Random { get; set; } = new Random();
        public int State { get; set; }
        public Blocks(Point Position) { 
            this.Position = Position;
            State = Random.Next(3);
            switch (State)
            {
                case 0:
                    Color = Color.Red;
                    break;
                case 1:
                    Color = Color.Green;
                    break;
                case 2:
                    Color = Color.Blue;
                    break;
            }
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);

            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, 40, 20));
            brush.Dispose();
        }

        public bool isHit(Point point)
        {
            return false;
        }

    }
}
