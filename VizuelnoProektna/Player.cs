using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProektna
{
    public abstract class Player
    {
        public int Width { set; get; }
        public int Height { set; get; }
        public Point Position { get; set; }
        public Color Color { get; set; }

        protected Player(int width, int height, Point position, Color color)
        {
            Width = width;
            Height = height;
            Position = position;
            Color = color;
        }

        public abstract void Draw(Graphics g);
        public abstract void Move(int dx, int dy);
    }
}
