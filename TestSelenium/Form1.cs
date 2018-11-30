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

namespace TestSelenium
{
    public partial class Form1 : Form
    {
        private IWebDriver Browser;
        private Random random_str = new Random(Environment.TickCount);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Browser = new OpenQA.Selenium.Firefox.FirefoxDriver();
            Browser.Manage().Window.Maximize();
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
            string chars = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);
            for(int i=0; i<length; ++i)
            {
                builder.Append(chars[random_str.Next(chars.Length)]);
            }
            return builder.ToString();
        }
    }
}
