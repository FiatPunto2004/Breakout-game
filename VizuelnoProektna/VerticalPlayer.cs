﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProektna
{
    public class VerticalPlayer : Player
    {
        public VerticalPlayer(int width, int height, Point position, Color color) : base(height, width, position, color)
        {
        }

        public override void Draw(Graphics g, int Width, int Height)
        {
            Brush brush = new SolidBrush(Color.Black);
            Position = new Point(Width - (this.Width / 2), Height - this.Height + 5);

            g.FillRectangle(brush, new Rectangle(Position.X, Position.Y, this.Width, this.Height));
            brush.Dispose();
        }

        public override void Move(int dx, int dy)
        {
            Position = new Point(dx + Position.X, dy + Position.Y);
        }
    }
}