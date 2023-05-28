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
        public Form1()
        {
            InitializeComponent();
            scene = new Scene(this.Width, this.Height);
            DoubleBuffered = true;
            timer1.Start();
            TimePassed = 0;
            Point block = new Point(0, 10);
            for(int i = 0; i < 4; i++)
            {
                block = new Point(block.X + 10, block.Y);
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
            
        }
    }
}
