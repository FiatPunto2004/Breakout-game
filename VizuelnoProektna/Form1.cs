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
        public Form1()
        {
            InitializeComponent();
            scene = new Scene(this.Width, this.Height);
            moveDown = moveUp = moveLeft = moveRight = false;
            DoubleBuffered = true;
            timer1.Start();
            TimePassed = 0;
            Point block = new Point(0, 10);
            for(int i = 0; i < 4; i++)
            {
                block = new Point(block.X + 30, block.Y);
                for(int j =0;j< 7;j++)
                {
                    scene.addBlocks(new Blocks(block));
                    block = new Point(block.X + 85, block.Y);
                }
                block = new Point(0, block.Y + 35);
            }

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
                scene.MoveVerticaly(-10);
            }
            if(moveDown == true && scene.vPlayer.PositionL.Y+120 < this.Height-70)
            {
                scene.MoveVerticaly(10);
            }
            if(moveLeft == true && scene.hPlayer.Position.X > 0)
            {
                scene.MoveHorizontaly(-10);
            }
            if(moveRight == true && scene.hPlayer.Position.X + 120 < this.Width-20)
            {
                scene.MoveHorizontaly(10);
            }

            Invalidate(true);
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
    }
}
