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
    public partial class FormMain : Form
    {
        Data data = new Data();
        private string login = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxEmployee.Text = login;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void SetLogin(string login)
        {
            this.login = login;
        }

        private void linkLabelInviteEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelNewEmployee.Height = 65;
            linkLabelInviteEmployee.Visible = false;
            labelInviteEmployee.Visible = true;
            panelEmployee.Height -= 30;
            panelEmployee.Location = new Point(panelEmployee.Location.X, panelEmployee.Location.Y + 30);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panelNewEmployee.Height = 35;
            linkLabelInviteEmployee.Visible = true;
            labelInviteEmployee.Visible = false;
            panelEmployee.Height += 30;
            panelEmployee.Location = new Point(panelEmployee.Location.X, panelEmployee.Location.Y - 30);
        }

        private void buttonInvite_Click(object sender, EventArgs e)
        {
            Mail mail = new Mail();
            Password password=new Password();
            string pass = password.GeneratePassword();
            if (data.Registration(textBoxMail.Text, pass) == true)
            {
                //отправляем письмо на почту с регистрационными данными
                string body = "Вас пригласили в систему VirtualEnterprise <br />" +
                    "Ваш логин в системе:" + textBoxMail.Text + "<br />" +
                    "Ваш пароль:" + pass + "<br />" +
                "Данное письмо создано и отправлено автоматически,на него не нужно отвечать";
                mail.Send(textBoxMail.Text, "регистрация в системе", body);
                labelError.Visible = false;
            }
            else
            {
                labelError.Visible = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
