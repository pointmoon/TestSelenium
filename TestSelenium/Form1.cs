using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.IO;


namespace TestSelenium
{
    public partial class Form1 : Form
    {
        private IWebDriver Browser;
        private StreamWriter fout = new StreamWriter("instagram" + DateTime.Now.ToString("HH-mm-ss") + ".dat");
        private Random random_str = new Random(Environment.TickCount);
        private string UserAgent = "";

        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAgent = UserAgentTextBox.Text;
            button1.Enabled = false;
            UserAgentTextBox.Enabled = false;

            OpenQA.Selenium.Firefox.FirefoxProfile profile = new OpenQA.Selenium.Firefox.FirefoxProfile();
            OpenQA.Selenium.Firefox.FirefoxOptions option = new OpenQA.Selenium.Firefox.FirefoxOptions();
            profile.SetPreference("general.useragent.override", UserAgent);
            option.Profile = profile;
            Browser = new OpenQA.Selenium.Firefox.FirefoxDriver(option);

            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://www.instagram.com/");
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //----------------эл.адрес----------------
            IWebElement email = Browser.FindElement(By.Name("emailOrPhone"));
            string str_email_1 = RandomString(11, "LetterAndNumber");
            string str_email_2 = "@" + "yandex.ru";
            string str_email = str_email_1 + str_email_2;
            SendToPage(email, str_email_1);
            SendToPage(email, str_email_2);
            //антиБОТ
            System.Threading.Thread.Sleep(1000);

            //----------------имя и фамилия----------------
            IWebElement name = Browser.FindElement(By.Name("fullName"));
            string str_name_1 = RandomString(7, "Letter");
            string str_name_2 = " ";
            string str_name_3 = RandomString(8, "Letter");
            string str_name = str_name_1 + str_name_2 + str_name_3;
            SendToPage(name, str_name_1);
            SendToPage(name, str_name_2);
            SendToPage(name, str_name_3);
            //антиБОТ
            System.Threading.Thread.Sleep(1000);

            //----------------имя пользователя----------------
            IWebElement username = Browser.FindElement(By.Name("username"));
            string str_username_1 = RandomString(5, "LetterAndNumber");
            string str_username_2 = RandomString(5, "LetterAndNumber");
            string str_username = str_username_1 + str_username_2;
            SendToPage(username, str_username_1);
            SendToPage(username, str_username_2);
            //антиБОТ
            System.Threading.Thread.Sleep(1000);

            //----------------пароль----------------
            IWebElement password = Browser.FindElement(By.Name("password"));
            string str_password_1 = RandomString(2, "LetterAndNumber");
            string str_password_2 = RandomString(4, "LetterAndNumber");
            string str_password_3 = RandomString(4, "LetterAndNumber");
            string str_password = str_password_1 + str_password_2 + str_password_3;
            SendToPage(password, str_password_1);
            SendToPage(password, str_password_2);
            SendToPage(password, str_password_3);
            //антиБОТ
            System.Threading.Thread.Sleep(10304);

            password.SendKeys(OpenQA.Selenium.Keys.Enter);

            //----------------вывод в программу----------------
            textBox1.AppendText("Эл. адрес: " + str_email + "\n");
            textBox1.AppendText("Имя и Файмилия: " + str_name + "\n");
            textBox1.AppendText("Имя пользователя: " + str_username + "\n");
            textBox1.AppendText("Пароль: " + str_password + "\n");
            //----------------вывод в файл----------------
            fout.WriteLine("Эл. адрес: " + str_email + "\n");
            fout.WriteLine("Имя и Файмилия: " + str_name + "\n");
            fout.WriteLine("Имя пользователя: " + str_username + "\n");
            fout.WriteLine("Пароль: " + str_password + "\n");


            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser.Quit();
        }

        //функция для генерации рандомного символа
        public string RandomString(int length, string dictionary)
        {
            string chars="";
            switch (dictionary)
            {
                case "Letter":
                    chars = "abcdefghijklmnopqrstuvwxyz";
                    break;
                case "LetterAndNumber":
                    chars = "_1234567890abcdefghijklmnopqrstuvwxyz";
                    break;
            }
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; ++i)
            {
                builder.Append(chars[random_str.Next(chars.Length)]);
            }
            return builder.ToString();
        }

        //процедура для заполнения поля ввода на странице
        public void SendToPage(IWebElement elem, string str)
        {
            for(int i = 0; i< str.Length; i++)
            {
                elem.SendKeys(str[i].ToString());
                System.Threading.Thread.Sleep(631);
            }
        }

        // обработчик кнопки "Завершение работы"
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            fout.Close();
        }

        //обработчик кнопки "Повторить"
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        //обработчик кнопки "Пометить как рабочий"
        private void button4_Click(object sender, EventArgs e)
        {
            fout.WriteLine("Рабочий.");
            textBox1.AppendText("Пометка добавлена!\n");
        }
    }
}
