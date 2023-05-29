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
        public static Random Random { get; set; } = new Random();
        public int State { get; set; }
        public Blocks(Point Position) { 
            this.Position = Position;
            State = Random.Next(3);

        }

        public void Draw(Graphics g, Color c)
        {
            Color color = new Color();
            switch (State)
            {
                case 0:
                    color = Color.Red;
                    break;
                case 1:
                    color = Color.Blue;
                    break;
                default:
                    color = Color.Green;
                    break;
            }
            color = c;
            Brush brush = new SolidBrush(color);

            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, 80, 30));
            brush.Dispose();
        }

        public bool isHit(Point point)
        {
            return false;
        }

    }
}
