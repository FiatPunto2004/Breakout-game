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

        public Ball(int speed) {
            this.speed = speed;
        }

        public void Draw(Graphics g, int Width, int Height) {
            Color color = Color.Orange;
            Brush brush = new SolidBrush(color);
            Position = new Point(Width / 2 - 20, Height - 100);
            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, width, height));
            brush.Dispose();
        }

        public void Move(int dx, int dy) {
            Position = new Point(Position.X + dx, Position.Y + dy);
        }

    }
}
