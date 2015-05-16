﻿using System.Net;
using System.Net.Mail;

namespace DiplomVirtualEnterprize
{
    class Mail
    {
        private string smtp = "smtp.mail.ru";
        private string from = "VirtualEnterprize@mail.ru";
        private string subject = "";
        private string to = "";
        private string body = "";
        private string login = "";
        private string password = "";

        /// <summary>
        /// Отправляет письмо
        /// </summary>
        /// <param name="login">Почта с который будет отправляться</param>
        /// <param name="password">пароль от почты</param>
        /// <param name="sendTo">адресат письма</param>
        /// <param name="subject">тема письма</param>
        /// <param name="body">содержание письма в формате html</param>
        public void Send(string login, string password, string sendTo, string subject, string body)
        {
            this.from = login;
            this.login = login;
            this.password = password;
            this.to = sendTo;
            this.body = body;
            this.subject = subject;
            SmtpClient smtpServer = new SmtpClient(smtp, 25);
            smtpServer.Credentials = new NetworkCredential(login, password);
            smtpServer.EnableSsl = true;
            smtpServer.Send(GetMessage());
        }

        /// <summary>
        /// Получить сообщение
        /// </summary>
        /// <returns>возвращает обьект письмо</returns>
        private MailMessage GetMessage()
        {
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(login);
            Message.To.Add(new MailAddress(to));
            Message.Subject = subject;
            Message.IsBodyHtml = true;
            Message.Body = body;
            return Message;
        }
       
    }
}
