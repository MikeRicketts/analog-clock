using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W5.Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int WIDTH = 400, HEIGHT = 400, secondH = 185, minuteH = 150, hourH = 100;
        int cy, cx;
        Bitmap bmp1;

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
            textBox2.Text = DateTime.UtcNow.ToString();

        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            



          DateTime current = DateTime.Now;
            DateTime user = dateTimePicker1.Value;
            dateTimePicker1.Value = DateTime.Now.AddSeconds(5);
            if (current.Hour==user.Hour && current.Minute==user.Minute&& current.Second==user.Second)
            {
                
                textBox3.Text = "Alarm Activated!";
                //  int alarmstart = 60 - DateTime.Now.Second;
               // TimeSpan interval = current - user;
                // textBox3.Text = interval.ToString();


                
            }
        }

        private void btnAlarm_Click_1(object sender, EventArgs e)
        {
            timer2.Start();
           // label3.Text= Alarm.

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        Graphics g1;
        private void timer1_Tick(object sender, EventArgs e)
        {

            g1 = Graphics.FromImage(bmp1);
            int secs = DateTime.Now.Second;
            int mins = DateTime.Now.Minute;
            int hours = DateTime.Now.Hour;
            int[] hands = new int[2];


            g1.Clear(Color.Transparent);

            g1.DrawEllipse(new Pen(Color.Black, 11), 0, 0, WIDTH, HEIGHT);

            g1.DrawString("12", new Font("Broadley", 12), Brushes.Black, new Point(190, 5));
            g1.DrawString("1", new Font("Broadley", 12), Brushes.Black, new Point(285, 25));
            g1.DrawString("2", new Font("Broadley", 12), Brushes.Black, new Point(340, 85));
            g1.DrawString("3", new Font("Broadley", 12), Brushes.Black, new Point(380, 180));
            g1.DrawString("4", new Font("Broadley", 12), Brushes.Black, new Point(370, 250));
            g1.DrawString("5", new Font("Broadley", 12), Brushes.Black, new Point(320, 330));
            g1.DrawString("6", new Font("Broadley", 12), Brushes.Black, new Point(190, 375));
            g1.DrawString("7", new Font("Broadley", 12), Brushes.Black, new Point(80, 340));
            g1.DrawString("8", new Font("Broadley", 12), Brushes.Black, new Point(20, 260));
            g1.DrawString("9", new Font("Broadley", 12), Brushes.Black, new Point(5, 180));
            g1.DrawString("10", new Font("Broadley", 12), Brushes.Black, new Point(35, 85));
            g1.DrawString("11", new Font("Broadley", 12), Brushes.Black, new Point(110, 25));


            hands = minsecPoint(secs, secondH);
            g1.DrawLine(new Pen(Color.Red, 2f), new Point(cx, cy), new Point(hands[0], hands[1]));

            hands = minsecPoint(mins, minuteH);
            g1.DrawLine(new Pen(Color.Black, 4f), new Point(cx, cy), new Point(hands[0], hands[1]));

            hands = hourPoint(hours % 12, mins, hourH);
            g1.DrawLine(new Pen(Color.Gray, 3f), new Point(cx, cy), new Point(hands[0], hands[1]));

            pictureBox1.Image = bmp1;


        }
        private int[] minsecPoint(int time1, int minsec1)
        {
            int[] hand1 = new int[2];
            time1 *= 6;
            if (time1 >= 0 && time1 <= 100)
            {
                hand1[0] = cx + (int)(minsec1 * Math.Sin(Math.PI * time1 / 180));
                hand1[1] = cy - (int)(minsec1 * Math.Cos(Math.PI * time1 / 180));
            }
            else
            {
                hand1[0] = cx - (int)(minsec1 * -Math.Sin(Math.PI * time1 / 180));
                hand1[1] = cy - (int)(minsec1 * Math.Cos(Math.PI * time1 / 180));
            }
            return hand1;



        }

        private int[] hourPoint(int hourval, int minval, int hours2)
        {
            int[] hand2 = new int[2];

            int val = (int)((hourval * 30) + (minval * 0.5));
            if (val >= 0 && val <= 180)
            {
                hand2[0] = cx + (int)(hours2 * Math.Sin(Math.PI * val / 180));
                hand2[1] = cy - (int)(hours2 * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                hand2[0] = cx - (int)(hours2 * -Math.Sin(Math.PI * val / 180));
                hand2[1] = cy - (int)(hours2 * Math.Cos(Math.PI * val / 180));
            }
            return hand2;


        }





        private void Form1_Load(object sender, EventArgs e)
        {


            bmp1 = new Bitmap(WIDTH - 1, HEIGHT - 1);

            cx = WIDTH / 2;
            cy = HEIGHT / 2;

            this.BackColor = Color.White;
            timer1.Start();
            
            

            
                        
        }
    }
}




