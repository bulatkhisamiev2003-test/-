using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсовой_Проект__такси_
{
    public partial class Taxi : Form
    {
        string status_taxi = "Отдых";
        string[,] zapis = new string[10000, 5];
        int proverka_massiva = 0;
        public Taxi()
        {
            InitializeComponent();
            label2.Text = status_taxi;
            zakaz();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(status_taxi == "Отдых")
            {
                int id = (int)e.KeyChar;
                if ((id < 48 | id > 57) & id != 8)
                    e.Handled = true;
            }
            if (status_taxi == "Доставляет")
            {
                e.Handled = true;
            }

        }
        private void zakaz()//Заполнение таблицы
        {
            dataGridView1.Rows.Clear();
            string[] lines = File.ReadAllLines("zakaz.txt");
            int i = 0, j = 0;
            foreach (string line in lines)
            {
                zapis[i, j] = line;
                j++;
                if (j == 5)
                {
                    j = 0;
                    i++;
                }
            }
            int z = 0;
            while (z < i)
            {
                if (zapis[z, 4] == "+")
                {
                    dataGridView1.Rows.Add(zapis[z, 0], zapis[z, 1], zapis[z, 2], zapis[z, 3]);
                }
                z++;
            }
            proverka_massiva = i - 1;
        }
        private void zapis_v_notepad()
        {
            string filePath = "zakaz.txt", text_notepad = "";
            int z = 0, i = 0, j = 0;
            while (proverka_massiva >= i)
            {
                text_notepad = text_notepad + zapis[i, j] + '\n';
                j++;
                if (j == 5)
                {
                    j = 0;
                    i++;
                }
            }
            using (StreamWriter sw = new StreamWriter(filePath, false))
                sw.Write(text_notepad);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool proverka = true;
            if (status_taxi == "Доставляет")
            {
                //Тут сделать редактирование записей
                while (zapis[i, 0] != textBox1.Text & proverka_massiva > i)
                {
                    i++;
                }
                if (zapis[i, 0] == textBox1.Text & zapis[i, 4] == "*")
                {
                    zapis[i, 0] = textBox1.Text;
                    zapis[i, 4] = "-";
                    zapis_v_notepad();
                    zakaz();
                    proverka = false;
                }
                if (proverka == true)
                {
                    MessageBox.Show("Запись с таким id не существует.");
                    //СЮДА
                }
                status_taxi = "Отдых";
                MessageBox.Show("Вы доставили клиента.");
                textBox1.Text = "";
                button1.Text = "Взять заказ";
                i = -1;
            }
            if (status_taxi == "Отдых" & i==0)
            {
                //Тут сделать создание записей
                while (zapis[i, 0] != textBox1.Text & proverka_massiva > i)
                {
                    i++;
                }
                if (zapis[i, 0] == textBox1.Text & zapis[i, 4] == "+")
                {
                    zapis[i, 0] = textBox1.Text;
                    zapis[i, 4] = "*";
                    zapis_v_notepad();
                    zakaz();
                    proverka = false;
                }
                if (proverka == true)
                {
                    MessageBox.Show("Такого заказа нету.");
                    //СЮДА
                }
                status_taxi = "Доставляет";
                MessageBox.Show("Езжайте по адресу " + zapis[i, 2]);
                button1.Text = "Завершить заказ";
            }
            //конец кода
            label2.Text = status_taxi;
        }
    }
}
