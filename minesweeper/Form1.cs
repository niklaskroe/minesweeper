using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace minesweeper
{
    public partial class Form1 : Form
    {
        private int[,] feld;
        private Button[,] buttons;
        

        private void init(int breite, int höhe, int bomben)
        {
            feld = new int[breite, höhe];
            buttons = new Button[breite, höhe];
            Random zufall = new Random();
            while(bomben>0)
            {
                int x = zufall.Next(breite);
                int y = zufall.Next(höhe);
                if (feld[x, y] == 1) continue;
                feld[x, y] = -1;
                for (int dx=-1; dx<=1;dx++)
                {
                    for (int dy = -1;dy<=1;dy++)
                    {
                        if (x + dx < 0) continue;
                        if (y + dy < 0) continue;
                        if (x + dx >= breite) continue;
                        if (y + dy >= höhe) continue;
                        if (feld[x + dx, y + dy] != -1)
                        {
                            feld[x + dx, y + dy]++;
                        }
                    }
                    bomben--;
                }
            }
        }


        System.Timers.Timer t;
        int h, m, s;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;

            init(10, 10, 20);
            for (int x = 0; x < feld.GetLength(0); x++)
            {
                for (int y = 0; y < feld.GetLength(1); y++)
                {
                    Button b = new Button();
                    buttons[x, y] = b;
                    b.Font = new Font("Arial", 40);
                    b.Left = x * 80;
                    b.Top = y * 80;
                    b.Width = 80;
                    b.Height = 80;
                    b.Text = "";
                    Controls.Add(b);
                    b.MouseDown += B_MouseDown;
                }
            }
        }

        private void B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                t.Start();
                Button b = (Button)sender;
                int x = b.Left / 80;
                int y = b.Top / 80;
                
                if (feld[x, y] == -1)
                {
                    b.Text = "\U0001F4A3";
                    t.Stop();
                    Form2 GameOver = new Form2();
                    GameOver.Show();
                }
                else
                {
                    if (feld[x, y] == 0)
                    {
                        b.Text = "";
                        aufdecken(x, y);
                    }
                    else
                    {
                        b.Text = "" + feld[x, y];
                    }
                }
                b.Enabled = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                Button b = (Button)sender;
                if (b.Text == "\U0001F6A9")
                {
                    b.Text = "";
                }
                else
                {
                    
                    b.Text = "\U0001F6A9";
                }
            }
        }



        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                txtResult.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
        }

        

        private void btnStop_Click(object sender, EventArgs e)
        {
            t.Stop();
            Application.Restart();
            Environment.Exit(0);

        }
        private void aufdecken (int x,int y)
        {
            Stack<Point> stapel = new Stack<Point>();
            stapel.Push(new Point(x, y));
            while (stapel.Count>0)
            {
                Point p = stapel.Pop();
                if (p.X < 0 || p.Y < 0) continue;
                if (p.X >= feld.GetLength(0) || p.Y >= feld.GetLength(1)) continue;

                if (!buttons[p.X, p.Y].Enabled) continue;

                buttons[p.X, p.Y].Enabled = false;
                if (feld[p.X, p.Y]!=0)
                    buttons[p.X, p.Y].Text = "" + feld[p.X, p.Y];

                if (feld[p.X, p.Y] != 0) continue;
                stapel.Push(new Point(p.X-1, p.Y));
                stapel.Push(new Point(p.X+1, p.Y));
                stapel.Push(new Point(p.X, p.Y-1));
                stapel.Push(new Point(p.X, p.Y+1));
            }
        }
    }
}
