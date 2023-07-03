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
        public bool speedUp { get; set; }
        public int speed {get; set; }

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
            speedUp = false;
            timer1.Interval = 60;
            speed = 10;
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
            dy = -speed;
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
            if(moveUp == true && scene.vPlayer.PositionL.Y >= 10)
            {
                scene.MoveVerticaly(-(int)(speed * 1.5));
            }
            if(moveDown == true && scene.vPlayer.PositionL.Y+120 < this.Height-80)
            {
                scene.MoveVerticaly((int)(speed * 1.5));
            }
            if(moveLeft == true && scene.hPlayer.Position.X >= 30)
            {
                scene.MoveHorizontaly(-(int)(speed * 1.5));
            }
            if(moveRight == true && scene.hPlayer.Position.X + 120 < this.Width-40)
            {
                scene.MoveHorizontaly((int)(speed * 1.5));
            }
            moveBallGlobal();

            toolStripStatusLabel1.Text = "Points " + points;

            if (points % 100 == 0 && points >= 100 && speedUp == true) 
            {
                speed += 5;
                speedUp = false;
            }

            Invalidate(true);
        }

        private void moveBallGlobal()
        {
            Point ballPoss = scene.ball.Position;
            Point hPPoss = scene.hPlayer.Position;
            Point vPPossR = scene.vPlayer.PositionR;
            Point vPPossL = scene.vPlayer.PositionL;
            if (dy > 0 && hPPoss.Y - 10 <= ballPoss.Y + (int) Ball.height  && hPPoss.Y + HorizontalPlayer.height >= ballPoss.Y && hPPoss.X - 10 <= ballPoss.X + (int)Ball.width && hPPoss.X + HorizontalPlayer.width + 10 >= ballPoss.X)
            {
                dx = random.Next(-speed, speed+1);
                dy = Set(dy);
            }
            else if (dx < 0 && vPPossL.X + VerticalPlayer.width + 10 >= ballPoss.X && vPPossL.X <= ballPoss.X + Ball.width && vPPossL.Y - 10 <= ballPoss.Y + (int)Ball.height && vPPossL.Y + VerticalPlayer.height + 10 >= ballPoss.Y)
            {
                dx = Set(dx);
                dy = random.Next(-speed, speed + 1);
            }
            else if (dx > 0 && vPPossR.X - 10 <= ballPoss.X + (int)Ball.width && vPPossR.X + VerticalPlayer.width >= ballPoss.X && vPPossR.Y - 10 <= ballPoss.Y + (int)Ball.height && vPPossR.Y + VerticalPlayer.height + 10 >= ballPoss.Y)
            {
                dx = Set(dx);
                dy = random.Next(-speed, speed + 1);
            }
            else if (isHit(ballPoss))
            {
                dx = random.Next(-speed, speed + 1);
                dy = Set(dy);

            }
            else if(ballPoss.Y + 20 <= 30 && dy < 0)
            {
                dx = random.Next(-speed, speed + 1);
                dy = Set(dy);

            }
            else
            {
                if (GameOver(ballPoss))
                {
                    timer1.Stop();
                    DialogResult dr;
                    if (points == 280)
                    {
                        dr = MessageBox.Show("You won the game!\nCongratulations!\n" + "Would you like to start a new game?", "Victory", MessageBoxButtons.YesNo);
                    }
                    else {
                        dr = MessageBox.Show("You scored " + points + " points.\n" + "Would you like to start a new game?", "Game Over", MessageBoxButtons.YesNo);
                    }
                    
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
            scene.moveBall(dx, dy);
        }

        private bool GameOver(Point ball)
        {
            if((ball.X - 20 <= 0 || ball.Y + Ball.width >= this.Height - 60 || ball.X + Ball.width >= this.Width - 30) || (scene.blocks.Count == 0))
            {
                return true;
            }
            return false;
        }
       
       
        private bool isHit(Point ballPoss)
        {
            Blocks hit = null;
            bool IsHit = false;
            foreach(Blocks block in scene.blocks)
            {
                if(block.Position.Y + Blocks.Height + 10 >= ballPoss.Y && block.Position.Y - 10 <= ballPoss.Y && block.Position.X - 15 <= ballPoss.X && block.Position.X + Blocks.Width + 15 >= ballPoss.X)
                {
                    speedUp = true;
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

        private int Set(int d)
        {
            if(Math.Abs(d) != speed)
            {
                if(d < 0)
                {
                    d = -speed;
                }
                else
                {
                    d = speed;
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
