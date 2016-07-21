using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bforce
{
    public partial class Form1 : Form
    {
        int bjump = 0;
        int bzähler = 0;
        int live = 5;
        int ran = 0;
        int zählerp = 0;
        int score1 = 0;
        int gameoverzähler = 0;
        

        // r random erstellen
        static Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newgame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
      


            // flappy //
            
                flappy.Location = new Point(
                flappy.Location.X, flappy.Location.Y +10);
            
            if (bjump == 1)
            {
      
                flappy.Location = new Point(
                flappy.Location.X, flappy.Location.Y -30);
                bzähler = bzähler + 1;
                if (bzähler == 5)
                {
                    bjump = 0;
                    bzähler = 0;
                }
            }
         
            if (flappy.Location.Y > 500)
            {
                flappy.Location = new Point(
                flappy.Location.X, flappy.Location.Y -10);      
            }

            // röhren

            panel1.Location = new Point(
            panel1.Location.X -10, panel1.Location.Y);
            panel2.Location = new Point(
            panel2.Location.X -10, panel2.Location.Y);
            if (panel1.Location.X == 0)
            {newpanel();}

            panel3.Location = new Point(
            panel3.Location.X - 10, panel3.Location.Y);
            panel4.Location = new Point(
            panel4.Location.X - 10, panel4.Location.Y);
            if (panel1.Location.X == 300)
            { newpanel2(); }
   

            //test

            if (panel1.Location.X == 350 || panel3.Location.X == 350)
            {
                if ((flappy.Location.Y + 10) > ran &&
                  (flappy.Location.Y + 10) < (ran + 200))
                {

                    label2.Text = Convert.ToString(zählerp);
                    zählerp = zählerp + 1;
                    if (zählerp >score1)
                    {
                        score1 = zählerp;
                        score.Text = Convert.ToString(score1);
                    }
                }
                else
                {
                    if (live >= 1)
                    {
                        live = live - 1;
                        label1.Text = Convert.ToString(live);
                    }


                    if (live == 0)
                    {
                        lblgame.Visible = true;
                        
                        gameoverzähler = gameoverzähler + 1;
                        if (gameoverzähler == 2)
                        {
                            lblgame.Visible = false;
                            newgame();
                            gameoverzähler = 0;
                        }                
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
        
                bjump = 1;

        }

        private void newpanel()
        {
            ran = r.Next(0, 300);
            panel1.Size = new Size(10, ran);
            panel2.Size = new Size(10, (300 - ran));
            panel1.Location = new Point(600, 0);
            panel2.Location = new Point(600, (ran + 200));
        }
        private void newpanel2()
        {
            ran = r.Next(0, 300);
            panel3.Size = new Size(10, ran);
            panel4.Size = new Size(10, (300 - ran));
            panel3.Location = new Point(600, 0);
            panel4.Location = new Point(600, (ran + 200));
        }
        private void newgame()
        {

            timer1.Start();
            newpanel();
            live = 5;
            zählerp = 0;
            label2.Text = Convert.ToString(zählerp);
        }

    
    }
}
