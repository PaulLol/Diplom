using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        Bitmap DrawArea;

        public Form3()
        {
            InitializeComponent();
  
        }


        private int x = 0;
        private int y = 0;
        private int width = 45;
        private int height = 45;
        private int speed = 5;
        private string[,] game_music;
        private double[] dt;
        private SoundPlayer sp;
        private bool testequal_0=false;
        private bool testequal_1 = false;
        private bool testequal_2 = false;
        private bool testequal_3= false;
        private bool testequal_4 = false;
        private int score = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm_1 = new Form1();
            frm_1.Show();
            this.Hide();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Form1 main = this.Owner as Form1;
            game_music = main.game_music;
            dt = main.dt;
            string filepath = main.audio_file_path;

            sp = new SoundPlayer(filepath);
            sp.Play();

            for (int i = 0; i < game_music.GetLength(0); i++)
            {
                if (game_music[i, 0] != "null")
                {
                    switch (game_music[i, 0])
                    {
                        case "A":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "B":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "C":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                        case "D":
                            e.Graphics.FillEllipse(Brushes.Purple, x + 220, y, width, height);
                            break;
                        case "E":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "F":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "G":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                    }

                    if (y == this.Size.Height)
                    {
                        testequal_0 = true;
                    }

                }

                if (game_music[i, 1] != null)
                {
                    switch (game_music[i, 1])
                    {
                        case "A":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "B":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "C":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                        case "D":
                            e.Graphics.FillEllipse(Brushes.Purple, x + 220, y, width, height);
                            break;
                        case "E":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "F":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "G":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                    }

                    if (y == this.Size.Height)
                    {
                        testequal_1 = true;
                    }
                }

                if (game_music[i, 2] != null)
                {
                    switch (game_music[i, 2])
                    {
                        case "A":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "B":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "C":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                        case "D":
                            e.Graphics.FillEllipse(Brushes.Purple, x + 220, y, width, height);
                            break;
                        case "E":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "F":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "G":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                    }

                    if (y == this.Size.Height)
                    {
                        testequal_2 = true;
                    }
                }

                if (game_music[i, 3] != null)
                {
                    switch (game_music[i, 3])
                    {
                        case "A":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "B":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "C":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                        case "D":
                            e.Graphics.FillEllipse(Brushes.Purple, x + 220, y, width, height);
                            break;
                        case "E":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "F":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "G":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                    }

                    if (y == this.Size.Height)
                    {
                        testequal_3 = true;
                    }

                }

                if (game_music[i, 4] != null)
                {
                    switch (game_music[i, 4])
                    {
                        case "A":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "B":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "C":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                        case "D":
                            e.Graphics.FillEllipse(Brushes.Purple, x + 220, y, width, height);
                            break;
                        case "E":
                            e.Graphics.FillEllipse(Brushes.Red, x + 10, y, width, height);
                            break;
                        case "F":
                            e.Graphics.FillEllipse(Brushes.DeepSkyBlue, x + 80, y, width, height);
                            break;
                        case "G":
                            e.Graphics.FillEllipse(Brushes.Green, x + 150, y, width, height);
                            break;
                    }
                    if (y == this.Size.Height)
                    {
                        testequal_4 = true;
                    }
                }

                testequal_0 = false;
                testequal_1 = false;
                testequal_2 = false;
                testequal_3 = false;
                testequal_4 = false;

                SetTimer();
                Thread.Sleep((int)dt[i]);
            }

            sp.Stop();
        }

        private static System.Timers.Timer aTimer;

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(200);
            aTimer.Enabled = true;
            aTimer.AutoReset = true;
            y += speed;
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (testequal_0 == true && e.KeyCode == Keys.Q)
            {
                label2.Text = (score + 1).ToString();
            }

            if (testequal_1 == true && e.KeyCode == Keys.W)
            {
                label2.Text = (score + 1).ToString();
            }

            if (testequal_2 == true && e.KeyCode == Keys.E)
            {
                label2.Text = (score + 1).ToString();
            }

            if (testequal_3 == true && e.KeyCode == Keys.R)
            {
                label2.Text = (score + 1).ToString();
            }

            if (testequal_4 == true && e.KeyCode == Keys.T)
            {
                label2.Text = (score + 1).ToString();
            }
        }
    }

}
