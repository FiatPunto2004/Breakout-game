using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizuelnoProektna
{
    public partial class Form1 : Form
    {
        public Scene scene { get; set; }
        public int TimePassed { get; set; } 
        public bool moveUp { get; set; }
        public bool moveDown { get; set; }
        public bool moveLeft { get; set; }
        public bool moveRight { get; set; }
        public int points { get; set; }

        public int dx { get; set; }
        public int dy { get; set; }

        public Random random { get; set; }

        public Form1()
        {
            InitializeComponent();
            Initialize();   
        }

        public void Initialize()
        {
            scene = new Scene(this.Width, this.Height);
            moveDown = moveUp = moveLeft = moveRight = false;
            DoubleBuffered = true;
            timer1.Start();
            TimePassed = 0;
            points = 0;
            toolStripStatusLabel1.Text = "Points 0";
            random = new Random();
            Point block = new Point(0, 10);
            for (int i = 0; i < 4; i++)
            {
                block = new Point(block.X + 30, block.Y);
                for (int j = 0; j < 7; j++)
                {
                    scene.addBlocks(new Blocks(block));
                    block = new Point(block.X + 85, block.Y);
                }
                block = new Point(0, block.Y + 35);
            }
            dx = 0;
            dy = -10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(moveUp == true && scene.vPlayer.PositionL.Y > 0)
            {
                scene.MoveVerticaly(-15);
            }
            if(moveDown == true && scene.vPlayer.PositionL.Y+120 < this.Height-70)
            {
                scene.MoveVerticaly(15);
            }
            if(moveLeft == true && scene.hPlayer.Position.X > 0)
            {
                scene.MoveHorizontaly(-15);
            }
            if(moveRight == true && scene.hPlayer.Position.X + 120 < this.Width-20)
            {
                scene.MoveHorizontaly(15);
            }
            moveBallGlobal();

            toolStripStatusLabel1.Text = "Points " + points;
            Invalidate(true);
        }

        public void moveBallGlobal()
        {
            Point ballPoss = scene.ball.Position;
            Point hPPoss = scene.hPlayer.Position;
            Point vPPossR = scene.vPlayer.PositionR;
            Point vPPossL = scene.vPlayer.PositionL;
            scene.moveBall(dx, dy);
            if (dy > 0 && hPPoss.Y <= ballPoss.Y + (int) Ball.height && hPPoss.Y + HorizonralPlayer.heights >= ballPoss.Y + Ball.height && hPPoss.X <= ballPoss.X + (int)Ball.width * 0.999 && hPPoss.X + HorizonralPlayer.width >= ballPoss.X + (int) Ball.width *0.0001)
            {
                dx = random.Next(-10, 11);
                dy = Set(dy);
            }
            else if (dx < 0 && vPPossL.X + VerticalPlayer.width >= ballPoss.X && vPPossL.X <= ballPoss.X && vPPossL.Y <= ballPoss.Y + (int)Ball.height * 0.999 && vPPossL.Y + VerticalPlayer.height >= ballPoss.Y + (int)Ball.height * 0.0001)
            {
                dx = Set(dx);
                dy = random.Next(-10, 11);

            }
            else if (dx > 0 && vPPossR.X <= ballPoss.X + (int)Ball.width && vPPossR.X + VerticalPlayer.width >= ballPoss.X + Ball.width && vPPossR.Y <= ballPoss.Y - (int)Ball.height * 0.999 && vPPossR.Y + VerticalPlayer.height >= ballPoss.Y + (int) Ball.height * 0.0001)
            {
                dx = Set(dx);
                dy = random.Next(-10, 11);

            }
            else if (isHit(ballPoss))
            {
                dx = random.Next(-10, 11);
                dy = Set(dy);

            }
            else if(ballPoss.Y + 20 <= 10 && dy < 0)
            {
                dx = random.Next(-10, 11);
                dy = -dy;

            }
            else
            {
                if (GameOver(ballPoss))
                {
                    timer1.Stop();
                    DialogResult dr = MessageBox.Show("Would you like to start a new game", "Game Over", MessageBoxButtons.YesNo);
                    if(dr == DialogResult.Yes)
                    {
                        Initialize();
                    }
                    else
                    { 
                        this.Close();
                    }
                }
            }

        }

        public bool GameOver(Point ball)
        {
            if((ball.X <= 0 || ball.Y + Ball.width >= this.Height || ball.X >= this.Width) || (scene.blocks.Count == 0))
            {
                return true;
            }
            return false;
        }
       

        public bool isHit(Point ballPoss)
        {
            Blocks hit = null;
            bool IsHit = false;
            foreach(Blocks block in scene.blocks)
            {
                if(block.Position.Y + Blocks.Height >= ballPoss.Y && block.Position.Y <= ballPoss.Y && block.Position.X <= ballPoss.X + (int)Ball.width * 0.9999 && block.Position.X + Blocks.Width >= ballPoss.X + (int)Ball.width * 0.0001)
                {
                    hit = block;
                    IsHit = true;
                    break;
                }
            }
            if(hit != null)
            {
                points += 10;
                scene.blocks.Remove(hit);
            }

            return IsHit;
        }

        public int Set(int d)
        {
            if(Math.Abs(d) != 10)
            {
                if(d < 0)
                {
                    d = -10;
                }
                else
                {
                    d = 10;
                }
            }
            else
            {
                d = -d;
            }
            return d;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if(e.KeyCode == Keys.Right){
                moveRight = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
