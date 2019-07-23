using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MathWorks.MATLAB.NET.Arrays;
using convertsongLib;

using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Application = System.Windows.Forms.Application;

using NAudio.Wave;
using NAudio.Lame;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        List<string> FileNames = new List<string>();
        public string dirname = Directory.GetCurrentDirectory();
        public string[,] music;
        public string[,] time;
        public double[] dt;
        public string[,] game_music;
        public string namefile;
        public string audio_file_path;
        public string namefile_xls_m;
        public string namefile_xls_t;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Зчитуваня даних з SaveList.txt файлу та заповнення ними елемента форми Listbox1
            FileNames = File.ReadLines("SavedList.txt").ToList();
            listBox1.Items.AddRange(FileNames.ToArray());
            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Запуск діалогового вікна при натисканні
            ofd.ShowDialog();
            textBox1.Text = ofd.FileName;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            namefile = ofd.SafeFileName.Remove(ofd.SafeFileName.Length - 4, 4);
            audio_file_path = dirname + "\\AudioFile\\" + namefile + ".wav";
            namefile_xls_m = dirname + "\\SaveInfo\\" + namefile + "_m" + ".xls";
            namefile_xls_t = dirname + "\\SaveInfo\\" + namefile + "_t" + ".xls";
            bool Test = false;

            //Перевірка відтворення на існування в списку
            if (FileNames == null) Test = false;
            else
            {
                try
                {
                    for (int i = 0; i <= FileNames.Count; i++)
                    {
                        if (namefile == FileNames[i])
                        {
                            Test = true;
                            MessageBox.Show("Вже існує");
                            break;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException) { }
            }

            if (Test == false)
            {   
                FileNames.Add(namefile);

                //Конвертування .mp3 в .wav 
                if (ofd.SafeFileName.Remove(0, ofd.SafeFileName.Length - 4) == ".mp3")
                {
                    using (var reader = new Mp3FileReader(textBox1.Text))
                    using (var writer = new WaveFileWriter(audio_file_path, reader.WaveFormat))
                        reader.CopyTo(writer);
                }
                else
                {   
                    try
                    {
                        //Копіювання музичного відтворення в окрему папку проекту
                        File.Copy(textBox1.Text, audio_file_path);
                    }
                    catch (Exception) { }
                }

                //Запис всіх значень списку FileNames (назв створених відтворень) в .txt файл, для локального збереження.
                File.WriteAllLines("SavedList.txt", FileNames.ToArray());
                listBox1.Items.AddRange(FileNames.ToArray());

                //Використання бібліотеки і класу convertsong.
                convertsongClass convert = null;
                convert = new convertsongClass();
                MWCharArray song_filename = new MWCharArray(audio_file_path);
                MWCharArray m_xls_filename = new MWCharArray(namefile_xls_m);
                MWCharArray t_xls_filename = new MWCharArray(namefile_xls_t);
                convert.convertsong(song_filename, m_xls_filename, t_xls_filename);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            //Перехід до Form2
            Form2 frm2 = new Form2();
            frm2.Owner = this;
            frm2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Перехід до Form3
            Form3 frm3 = new Form3();
            frm3.Owner = this;
            frm3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Завершення роботы програми
            Application.Exit();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string item = listBox1.SelectedItem.ToString();
                textBox1.Text = dirname + "\\AudioFile\\" + item+".wav";

                string fullnamefile = dirname + "\\SaveInfo\\" + item;
                string m_namefile_xls = fullnamefile + "_m.xls";
                string t_namefile_xls = fullnamefile + "_t.xls";



                //Звернення до створених .xls фалів
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(m_namefile_xls);
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                Microsoft.Office.Interop.Excel.Application xlApp_2 = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook_2 = xlApp_2.Workbooks.Open(t_namefile_xls);
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet_2 = xlWorkbook_2.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange_2 = xlWorksheet_2.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                int rowCount_2 = xlRange_2.Rows.Count;
                int colCount_2 = xlRange_2.Columns.Count;

                //Заповнення масиву music даними створеного _m.xls файлу
                music = new string[rowCount, colCount];

                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= colCount; j++)
                    {
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            music[i - 1, j - 1] = xlRange.Cells[i, j].Value2.ToString();
                        }
                    }
                }

                //Заповнення масиву times даними створеного _t.xls файлу
                time = new string[rowCount_2, colCount_2];

                for (int i = 1; i <= rowCount_2; i++)
                {
                    for (int j = 1; j <= colCount_2; j++)
                    {
                        if (xlRange_2.Cells[i, j] != null && xlRange_2.Cells[i, j].Value2 != null)
                        {
                            time[i - 1, j - 1] = xlRange_2.Cells[i, j].Value2.ToString();
                        }
                    }
                }

                //Закриття та зупинка всіх процесіх Microsoft Office Excel
                xlWorkbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlWorkbook_2.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlApp.Application.Quit();
                xlApp_2.Application.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp_2);
                xlApp = null;
                xlApp_2 = null;
                xlWorkbook = null;
                xlWorkbook_2 = null;
                xlWorksheet = null;
                xlWorksheet_2 = null;
                System.GC.Collect();

                //Створення сконвертованого масиву time_c - типу double, с масиву time - типу string
                double[] time_c = new double[time.GetLength(0)];

                for (int i = 0; i < time.GetLength(0); i++)
                {
                    for (int j = 0; j < time.GetLength(1); j++)
                    {
                        time_c[i] = Convert.ToDouble(time[i, j]);
                    }
                }

                //Створення осного масиву dt - типу double, зі змененними значеннями масиву time_c, для використання в грі
                dt = new double[time_c.Length];
                dt[0] = time_c[0] / 44100 * 1000;

                for (int i = 1; i < time_c.Length; i++)
                {
                    dt[i] = (time_c[i] / 44100 * 1000) - (time_c[i - 1] / 44100 * 1000);
                }

                //Створення осного масиву game_music - типу string, зі змененними значеннями масиву music, для використання в грі
                game_music = new string[music.GetLength(0), music.GetLength(1) - 2];

                for (int i = 0; i < music.GetLength(0); i++)
                {
                    for (int j = 0; j < music.GetLength(1) - 2; j++)
                    {
                        if (music[i, j] == null) game_music[i, j] = "null";
                        else
                        {
                            game_music[i, j] = music[i, j].Remove(1, music[i, j].Length - 1); ;
                        }
                    }
                }

                audio_file_path = dirname + "\\AudioFile\\" + item + ".wav";
                namefile_xls_m = dirname + "\\SaveInfo\\" + item + "_m" + ".xls";
                namefile_xls_t = dirname + "\\SaveInfo\\" + item + "_t" + ".xls";

                //Перевірка створення .xls файлів
                if (File.Exists(namefile_xls_m))
                {
                    MessageBox.Show("Файл music бул створений", "MassegaBox", MessageBoxButtons.OK);
                    //Close();
                }
                else
                {
                    MessageBox.Show("Файл music не існує", "MassegaBox", MessageBoxButtons.OK);
                    //Close();
                }

                if (File.Exists(namefile_xls_t))
                {
                    MessageBox.Show("Файл times бул створений", "MassegaBox", MessageBoxButtons.OK);
                    //Close();
                }
                else
                {
                    MessageBox.Show("Файл times не існує", "MassegaBox", MessageBoxButtons.OK);
                    //Close();
                }

                if (dt != null && game_music != null) MessageBox.Show("Створення ключових даних та занесення композиції до списку завершено успішно", "MassegaBox", MessageBoxButtons.OK); else MessageBox.Show("Помилка при створенні. Масиви - порожні", "MassegaBox", MessageBoxButtons.OK);

            }
            catch (Exception) { }

            button3.Show();
        }
    }
}
