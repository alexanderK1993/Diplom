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
        CurrentWindow currentWindow;
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
            ToolStripMenuItemNameEmployee.Text = login;
            currentWindow = CurrentWindow.Company;
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

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void panelEmployee_Paint(object sender, PaintEventArgs e)
        {

        }

        private void необходимоВыполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentWindow(currentWindow, CurrentWindow.NeedCompleteTask);
        }
        /// <summary>
        /// Меняет элементы главной формы в зависимости от окна которое нужно показать
        /// </summary>
        /// <param name="currentWindow">Текущее окно</param>
        /// <param name="nextWindow">Окно которое будет</param>
        private void SetCurrentWindow(CurrentWindow currentWindow,CurrentWindow nextWindow)
        {

            switch (currentWindow)
            {
                case CurrentWindow.Company:
                    HideCompanyWindow();
                    break;
                case CurrentWindow.NeedCompleteTask:
                    break;
            }
            this.currentWindow = nextWindow;
            switch (nextWindow)
            {
                case CurrentWindow.NeedCompleteTask:
                    ShowCompanyWindow();
                    break;
                case CurrentWindow.MyTasks:
                    ShowMyTaskWindow();
                    break;
            }
        }

        /// <summary>
        /// Прячет все элементы окна "компания"
        /// </summary>
        private void HideCompanyWindow()
        {
            panelNewEmployee.Visible=false;
            panelEmployee.Visible = false;
            panelProject.Visible = false;
            ToolStripMenuItemCompany.ForeColor = Color.AliceBlue;
        }

        /// <summary>
        /// Показать все элементы окна "компания"
        /// </summary>
        private void ShowCompanyWindow()
        {
            panelNewEmployee.Visible =true;
            panelEmployee.Visible = true;
            panelProject.Visible = true;
            ToolStripMenuItemCompany.ForeColor = Color.DarkTurquoise;
        }

        /// <summary>
        /// Показать все элементы окна "мои задачи"
        /// </summary>
        private void ShowMyTaskWindow()
        {
            panelMyTask.Visible = true;
            ToolStripMenuItemTask.ForeColor = Color.DarkTurquoise;
        }
        /// <summary>
        /// Показать все элементы окна "необходимо выполнить"
        /// </summary>
        private void ShowNeedCompleteTaskWindow()
        {
            ToolStripMenuItemTask.ForeColor = Color.DarkTurquoise;
        }

        private void моиЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentWindow(currentWindow, CurrentWindow.MyTasks);
        }

        private void panelMyTask_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
