using static System.Net.Mime.MediaTypeNames;
//C:\Users\Булат\Desktop\Курсовой Проект (такси)\Курсовой Проект (такси)    C:\Users\Булат\Desktop\Курсовой Проект (такси)\Курсовой Проект (такси)\bin\Debug\net8.0-windows
namespace Курсовой_Проект__такси_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.PlaceholderText = "Логин";
            textBox2.PlaceholderText = "Пароль";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Шифрование Цезаря
            string pass_result = "";
            int shift = 3;
            foreach (char symbol in textBox2.Text)
            {
                pass_result += (char)(symbol + shift);
            }
            //Конец шифрования
            string[] lines = File.ReadAllLines("Users.txt");
            string[] users = new string[3];
            int i = -1;
            bool proverka = false;
            foreach (string line in lines)
            {
                if(line==textBox1.Text || i>=0 & i<=2)
                {
                    i++;
                    users[i] = line;
                    if (i==1 & users[1]!= pass_result)
                    {
                        MessageBox.Show("Не правильный пароль");
                        break;
                    }
                    if (i == 2)
                    {
                        proverka = true;
                        break;
                    }
                }
            }
            if (proverka==true)
            {
                // Создаём экземпляр второй формы
                Dispatcher newForm = new Dispatcher();

                // Показываем новую форму
                newForm.Show();

                // Скрываем текущую (this — ссылка на эту форму)
                this.Hide();
            }
            if (proverka == false)
            {
                MessageBox.Show("Такого профиля не существует.");
            }
        }
    }
}
