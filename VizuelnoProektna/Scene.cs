using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProektna
{
    public class Scene
    {
        public HorizonralPlayer hPlayer = new HorizonralPlayer();
        public VerticalPlayer VPlayer = new VerticalPlayer();
        public List<Blocks> blocks { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public Scene(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            blocks = new List<Blocks>();

        }

        public void addBlocks(Blocks block)
        {
            blocks.Add(block);
        }

        public void Draw(Graphics g)
        {
            foreach(Blocks b in blocks)
            {
                b.Draw(g);
            }
            hPlayer.Draw(g, this.Width, this.Height);
            VPlayer.Draw(g, this.Width, this.Height);
        }



    }
}
