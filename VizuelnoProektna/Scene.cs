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
        public Ball ball { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public Scene(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            blocks = new List<Blocks>();
            ball = new Ball(5);
            colors = new Color[3];
            for (int i = 0; i < 3; i++) { 
                int red = Random.Next(0, 255);
                int green = Random.Next(0, 255);
                int blue = Random.Next(0, 255);
                colors[i]=Color.FromArgb(red, green, blue);
            }
        }

        public void addBlocks(Blocks block)
        {
            blocks.Add(block);
        }

        public void Draw(Graphics g)
        {
            foreach(Blocks b in blocks)
            {
                b.Draw(g, colors[Random.Next(3)]);
            }
            hPlayer.Draw(g, this.Width, this.Height);
            VPlayer.Draw(g, this.Width, this.Height);
            ball.Draw(g, this.Width, this.Height);

        }



    }
}
