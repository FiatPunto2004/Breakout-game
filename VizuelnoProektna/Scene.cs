using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizuelnoProektna
{
    public class Scene
    {
        public HorizontalPlayer hPlayer { set; get; }
        public VerticalPlayer vPlayer { set; get; }
        public List<Blocks> blocks { set; get; }
        public Ball ball { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public static Random Random = new Random();
        public Color[] colors { set; get; }
        public Scene(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            hPlayer = new HorizontalPlayer(this.Width, this.Height);
            vPlayer = new VerticalPlayer(this.Width, this.Height);
            blocks = new List<Blocks>();
            ball = new Ball(5, this.Width, this.Height);
            colors = new Color[3];
            for (int i = 0; i < 3; i++) { 
                int red = Random.Next(0, 256);
                int green = Random.Next(0, 256);
                int blue = Random.Next(0, 256);
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
            hPlayer.Draw(g);
            vPlayer.Draw(g);
            ball.Draw(g);

        }

        public void MoveVerticaly(int dy)
        {
            vPlayer.Move(0, dy);
        }

        public void MoveHorizontaly(int dx)
        {
            hPlayer.Move(dx, 0);
        }

        public void moveBall(int dx, int dy)
        {
     
            ball.Move(dx, dy);
        }

    }
}
