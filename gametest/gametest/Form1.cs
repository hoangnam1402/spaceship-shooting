using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gametest
{
    public partial class Form1 : Form
    {
        int score = 0, speed = 5;
        Random rand = new Random();
        int rate = 0;
        bool up = false, down = false, left = false, right = false;
        int heart = 3, type = 0, cours = 100;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (score % 20 == 0 && score != 0)
                type += 1;

            if (cours != 0) { cours -= 10; }

            //buttel deplay
            rate += 20;
            if (rate == 100) 
            { 
                makebuttel();
                rate = 0;
            }

            //set rock speed
            rock1.Top = rock1.Top + speed + (score / 100);
            rock2.Top = rock2.Top + speed + (score / 100);
            rock3.Top = rock3.Top + speed + (score / 100);
            
            label1.Text = "Score: " + score;
            label2.Text = "" + heart;

            //set rock
            if (rock1.Top>600)
            {
                rock1.Top = -40;
                rock1.Left = rand.Next(0, 360);
            }
            if (rock2.Top > 600)
            {
                rock2.Top = -40;
                rock2.Left = rand.Next(0, 360);
            }
            if (rock3.Top > 600)
            {
                rock3.Top = -40;
                rock3.Left = rand.Next(0, 360);
            }

            //got hit
            if(cours == 0)
            {
                if (ship.Bounds.IntersectsWith(rock1.Bounds)||
                    ship.Bounds.IntersectsWith(rock2.Bounds)||
                    ship.Bounds.IntersectsWith(rock3.Bounds))
                {
                    if (heart > 0)
                    {
                        heart -= 1;
                        type = 0;
                        rock1.Top = -40;
                        rock1.Left = rand.Next(0, 360);
                        rock2.Top = -40;
                        rock2.Left = rand.Next(0, 360);
                        rock3.Top = -40;
                        rock3.Left = rand.Next(0, 360);
                        ship.Left = 190;
                        ship.Top = 500;
                        cours = 100;
                    }
                    else
                    {
                        timer1.Stop();
                        TextBox end = new End(score);
                        Controls.Remove(ship);
                        Controls.Add(end);
                    }
                }
            }

            //x = buttel
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20;
                    if(x.Top<-5)
                    {
                        this.Controls.Remove(x);
                    }
                    if(x.Bounds.IntersectsWith(rock1.Bounds))
                    {
                        score += 1;
                        this.Controls.Remove(x);
                        rock1.Top = -40;
                        rock1.Left = rand.Next(0, 360);
                    }
                    if (x.Bounds.IntersectsWith(rock2.Bounds))
                    {
                        score += 1;
                        this.Controls.Remove(x);
                        rock2.Top = -40;
                        rock2.Left = rand.Next(0, 360);
                    }
                    if (x.Bounds.IntersectsWith(rock3.Bounds))
                    {
                        score += 1;
                        this.Controls.Remove(x);
                        rock3.Top = -40;
                        rock3.Left = rand.Next(0, 360);
                    }
                }
            }

            //move
            if (up) { if (ship.Top > 0) { ship.Top -= 10; } }
            if (down) { if (ship.Top < 560) { ship.Top += 10; } }
            if (left) { if (ship.Left > 0) { ship.Left -= 10; } }
            if (right) { if (ship.Left < 360) { ship.Left += 10; } }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //BackgroundImage = Properties.Resources._1253106;
        }

        //move
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { up = true; } 
            if (e.KeyCode == Keys.Down) { down = true; } 
            if (e.KeyCode == Keys.Left) { left = true; } 
            if (e.KeyCode == Keys.Right) { right = true; } 
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { up = false; }
            if (e.KeyCode == Keys.Down) { down = false; }
            if (e.KeyCode == Keys.Left) { left = false; }
            if (e.KeyCode == Keys.Right) { right = false; }
        }

        //create buttel
        private void makebuttel()
        {
            if (type == 0)
            {
                PictureBox bullet = new bullet(ship.Left + (ship.Width / 2) - 3, ship.Top, "bullet", Color.Yellow);
                this.Controls.Add(bullet);
            }
            else
            {
                PictureBox bullet1 = new bullet(ship.Left, ship.Top, "bullet", Color.Yellow);
                this.Controls.Add(bullet1);
                PictureBox bullet2 = new bullet(ship.Left + ship.Width - 5, ship.Top, "bullet", Color.Yellow);
                this.Controls.Add(bullet2);
            }
        }
    }
}
