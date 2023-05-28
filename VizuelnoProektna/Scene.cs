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
        public HorizonralPlayer hPlayer = new HorizonralPlayer(40, 20, new Point(0, 0), Color.Black);
        public List<VerticalPlayer> vPlayers { set; get; }
        public List<Blocks> blocks { set; get; }
        public int Widht { set; get; }
        public int Height { set; get; }
        public Scene(int Width, int Height)
        {
            this.Widht = Widht;
            this.Height = Height;
            vPlayers = new List<VerticalPlayer>();
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
            hPlayer.Draw(g, this.Widht, this.Height);
            foreach(VerticalPlayer v in vPlayers)
            {
                v.Draw(g, this.Widht, this.Height);
            }
        }



    }
}
