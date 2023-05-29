using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizuelnoProektna
{
    public class Ball
    {
        
        public static int height = 20;
        public static int width = 20;
        public Point Position { get; set; } 
        public int speed {  get; set; }

        public Ball(int speed, int Width, int Height) {
            this.speed = speed;
            Position = new Point(Width / 2 - 20, Height - 100);
        }

        public void Draw(Graphics g) {
            Color color = Color.Orange;
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, Position.X, Position.Y, 20, 20);
            brush.Dispose();
        }

        public void Move(int dx, int dy) {
            Position = new Point(Position.X + dx, Position.Y + dy);
        }

    }
}
