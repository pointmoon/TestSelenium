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
        private StreamWriter fout = new StreamWriter("instagram.dat");
        private Random random_str = new Random(Environment.TickCount);

        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            OpenQA.Selenium.Firefox.FirefoxProfile profile = new OpenQA.Selenium.Firefox.FirefoxProfile();
            OpenQA.Selenium.Firefox.FirefoxOptions option = new OpenQA.Selenium.Firefox.FirefoxOptions();
            profile.SetPreference("general.useragent.override", "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.66 Safari/537.36");
            option.Profile = profile;
            Browser = new OpenQA.Selenium.Firefox.FirefoxDriver(option);

            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://www.instagram.com/");
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //эл.адрес
            IWebElement email = Browser.FindElement(By.Name("emailOrPhone"));
            string str_email_1 = RandomString(7);
            string str_email_2 = "@" + "yandex.com";
            string str_email = str_email_1 + str_email_2;
            email.SendKeys(str_email_1);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);
            email.SendKeys(str_email_2);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);

            //имя и фамилия
            IWebElement name = Browser.FindElement(By.Name("fullName"));
            string str_name_1 = RandomString(7);
            string str_name_2 = " ";
            string str_name_3 = RandomString(8);
            string str_name = str_name_1 + str_name_2 + str_name_3;
            name.SendKeys(str_name_1);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);
            name.SendKeys(str_name_2);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);
            name.SendKeys(str_name_3);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);

            //имя пользователя
            IWebElement username = Browser.FindElement(By.Name("username"));
            string str_username_1 = RandomString(5);
            string str_username_2 = RandomString(5);
            string str_username = str_username_1 + str_username_2;
            username.SendKeys(str_username_1);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);
            username.SendKeys(str_username_2);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);

            //пароль
            IWebElement password = Browser.FindElement(By.Name("password"));
            string str_password_1 = RandomString(2);
            string str_password_2 = RandomString(4);
            string str_password_3 = RandomString(4);
            string str_password = str_password_1 + str_password_2 + str_password_3;
            password.SendKeys(str_password_1);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);
            password.SendKeys(str_password_2);
            //антиБОТ
            System.Threading.Thread.Sleep(5000);
            password.SendKeys(str_password_3);
            //антиБОТ
            System.Threading.Thread.Sleep(10000);

            password.SendKeys(OpenQA.Selenium.Keys.Enter);

            //вывод в программу
            textBox1.AppendText("Эл. адрес: " + str_email + "\n");
            textBox1.AppendText("Имя и Файмилия: " + str_name + "\n");
            textBox1.AppendText("Имя пользователя: " + str_username + "\n");
            textBox1.AppendText("Пароль: " + str_password + "\n");
            //вывод в файл
            fout.Write("Эл. адрес: " + str_email + "\n");
            fout.Write("Имя и Файмилия: " + str_name + "\n");
            fout.Write("Имя пользователя: " + str_username + "\n");
            fout.Write("Пароль: " + str_password + "\n");


            button3.Enabled = true;
            //----------------------------------------------------------------------
            //Browser.Navigate().GoToUrl("https://accounts.google.com/signup/v2/webcreateaccount?continue=https%3A%2F%2Fwww.google.com%2F&hl=ru&flowName=GlifWebSignIn&flowEntry=SignUp");

            ////имя
            //IWebElement firstName = Browser.FindElement(By.Id("firstName"));
            //firstName.SendKeys(RandomString(7));

            ////фамилия
            //IWebElement lastName = Browser.FindElement(By.Id("lastName"));
            //lastName.SendKeys(RandomString(7));

            ////имя пользователя
            //IWebElement username = Browser.FindElement(By.Id("username"));
            //username.SendKeys(RandomString(14));

            ////пароль
            //string pass = RandomString(14);
            //IWebElement passwd = Browser.FindElement(By.Name("Passwd"));
            //passwd.SendKeys(pass);
            //IWebElement ConfirmPasswd = Browser.FindElement(By.Name("ConfirmPasswd"));
            //ConfirmPasswd.SendKeys(pass + OpenQA.Selenium.Keys.Enter);

            ////телефон
            //IWebElement phoneNumber = Browser.FindElement(By.Id("gradsIdvPhoneNext"));
            //username.SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser.Quit();
        }

        //функция для генерации рандомных строк указанной длинны
        public string RandomString(int length)
        {
            string chars = "_1234567890abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);
            for(int i=0; i<length; ++i)
            {
                builder.Append(chars[random_str.Next(chars.Length)]);
            }
            return builder.ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            fout.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
