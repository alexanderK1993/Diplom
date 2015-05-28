using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomVirtualEnterprize
{
    public partial class Login : Form
    {
     
        
        Data data = new Data();
        Mail mail = new Mail();
        Password password = new Password();
        const string login = "VirtualEnterprize@mail.ru";
        const string pass = "19930511q";
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabelRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelRegistration.Visible = false;
            linkLabelEnter.Visible = true;
            labelEnter.Visible = false;
            labelRegistration.Visible = true;
            buttonRegistration.Visible = true;
            buttonEnter.Visible = false;
            this.Text = "Регистрация";
        }

        private void linkLabelEnter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelRegistration.Visible = true;
            linkLabelEnter.Visible = false;
            labelEnter.Visible = true;
            labelRegistration.Visible = false;
            buttonRegistration.Visible = false;
            buttonEnter.Visible = true;
            this.Text = "Вход в систему";
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {            
            if (data.Registration(textBoxMail.Text, textBoxPassword.Text) == true)
            {
                //отправляем письмо на почту с регистрационными данными
                string body = "Благодарим за регистрацию в нашем сервисе <br />" +
                    "Ваш логин в системе:" + textBoxMail.Text + "<br />" +
                    "Ваш пароль:" + textBoxPassword.Text + "<br />" +
                "Данное письмо создано и отправлено автоматически,на него не нужно отвечать";
                mail.Send(textBoxMail.Text, "регистрация в системе", body);
            }
            else
            {
                labelError.Visible = true;
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (data.Login(textBoxMail.Text, textBoxPassword.Text) > 0)
            {
                MainMenu formMain = new MainMenu();
                this.Hide();
                formMain.SetLogin(textBoxMail.Text);
                formMain.Show();
            }
        }
    }
}
