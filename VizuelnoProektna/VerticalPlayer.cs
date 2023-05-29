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
        public Point PositionR { set; get; }
        public Point PositionL { set; get; }
        public VerticalPlayer(int Width, int Height) : base()
        {
            PositionL = new Point(10, Height / 2 + Height * (1 / 4));
            PositionR = new Point(Width - 35, Height / 2 + Height * (1 / 4));
        }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);

            g.FillRectangle(brush, new Rectangle(PositionL.X, PositionL.Y, 10, 120));

            g.FillRectangle(brush, new Rectangle(PositionR.X, PositionR.Y, 10, 120));
            brush.Dispose();
        }

        public override void Move(int dx, int dy)
        {
            PositionL = new Point(dx + PositionL.X, dy + PositionL.Y);
            PositionR = new Point(dx + PositionR.X, dy + PositionR.Y);

        }
    }
}
