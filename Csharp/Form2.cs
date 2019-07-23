using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            string[,] music = main.music;
            string[,] time = main.time;
            string[,] game_music = main.game_music;
            double[] dt = main.dt;

            dataGridView1.RowCount = music.GetLength(0);
            dataGridView1.ColumnCount = music.GetLength(1);

            for (int i = 0; i < music.GetLength(0); i++)
            {
                for (int j = 0; j < music.GetLength(1); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = music[i, j];
                }
            }

            dataGridView2.RowCount = time.GetLength(0);
            dataGridView2.ColumnCount = time.GetLength(1);

            for (int i = 0; i < time.GetLength(0); i++)
            {
                for (int j = 0; j < time.GetLength(1); j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = time[i, j];
                }
            }

            dataGridView3.RowCount = game_music.GetLength(0);
            dataGridView3.ColumnCount = game_music.GetLength(1);

            for (int i = 0; i < game_music.GetLength(0); i++)
            {
                for (int j = 0; j < game_music.GetLength(1); j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = game_music[i, j];
                }
            }

            dataGridView4.RowCount = dt.Length;
            dataGridView4.ColumnCount = 1;

            for (int i = 1; i < dt.Length; i++)
            {
                dataGridView4.Rows[i].Cells[0].Value = dt[i];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm_1 = new Form1();
            frm_1.Show();
            this.Hide();
        }
    }
}
