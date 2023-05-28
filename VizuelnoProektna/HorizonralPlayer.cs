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

        public HorizonralPlayer(int width, int height, Point position, Color color) : base(width, height, position, color)
        {
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override void Move(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}
