using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовой_Проект__такси_
{
    public partial class Dispatcher : Form
    {
        string status_dispatcher = "Бездействие";
        bool status_error = true;
        string[,] zapis = new string[10000, 5];
        int proverka_massiva = 0;
        public Dispatcher()
        {
            InitializeComponent();
            otobrajenie_off();
            label5.Text = status_dispatcher;
            zakaz();
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
            int z=0;
            while (z<i)
            {
                if (zapis[z,4]=="+")
                {
                    dataGridView1.Rows.Add(zapis[z, 0], zapis[z, 1], zapis[z, 2], zapis[z, 3]);
                }
                z++;
            }
            proverka_massiva = i - 1;
        }
        
        private void otobrajenie_off()
        {
            label1.Visible = false;//отображение элементов
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void otobrajenie_on()
        {
            label1.Visible = true;//отображение элементов
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void znachenie_textBox()//очистка
        {
            otobrajenie_off();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void proverka_znachenie_textBox()
        {
            string text_error="";
            status_error = true;
            if (textBox1.Text == "")
                text_error = "Заполните поле id!" + '\n';
            if(status_dispatcher!="Удаление")//реагирует на все если не статус Удаление
            {
                if (textBox2.Text == "")
                    text_error = text_error + "Заполните поле Клиент!" + '\n';
                if (textBox3.Text == "")
                    text_error = text_error + "Заполните поле Адрес!" + '\n';
                if (textBox4.Text == "")
                    text_error = text_error + "Заполните поле Сумма!" + '\n';
            }
            if (text_error == "")
                status_error = false;
            if (status_error == true)
                MessageBox.Show(text_error);
            
        }

        private void zapis_v_notepad()
        {
            string filePath = "zakaz.txt", text_notepad="";
            int z = 0,i=0,j=0;
            while (proverka_massiva>=i)
            {
                text_notepad = text_notepad + zapis[i, j]+'\n';
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
            status_dispatcher = "Создание";
            label5.Text = status_dispatcher;
            otobrajenie_on();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            status_dispatcher = "Редактирование";
            label5.Text = status_dispatcher;
            otobrajenie_on();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            status_dispatcher = "Удаление";
            label5.Text = status_dispatcher;
            otobrajenie_on();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            proverka_znachenie_textBox();
            if (status_error == false)
            {
                int i = 0;
                bool proverka = true;
                if (status_dispatcher == "Создание")
                {
                    //Тут сделать создание записей
                    while (zapis[i,0]!=textBox1.Text & proverka_massiva > i)
                    {
                        i++;
                    }
                    if(zapis[i, 0] == textBox1.Text)
                    {
                        MessageBox.Show("Запись с таким id уже имеется.");
                        proverka = false;
                    }
                    if(proverka==true)
                    {
                        i++;
                        zapis[i, 0] = textBox1.Text;
                        zapis[i, 1] = textBox2.Text;
                        zapis[i, 2] = textBox3.Text;
                        zapis[i, 3] = textBox4.Text+ " руб.";
                        zapis[i, 4] = "+";
                        proverka_massiva++;
                        zapis_v_notepad();
                        zakaz();
                        //СЮДА
                    }
                }
                if (status_dispatcher == "Редактирование")
                {
                    //Тут сделать редактирование записей
                }
                if (status_dispatcher == "Удаление")
                {
                    //Тут сделать удаление записей
                }
                //конец кода
                znachenie_textBox();
                status_dispatcher = "Бездействие";
                label5.Text = status_dispatcher;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            znachenie_textBox();
            status_dispatcher = "Бездействие";
            label5.Text = status_dispatcher;
        }
    }
}
