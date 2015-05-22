using System.Net;
using System.Net.Mail;

namespace DiplomVirtualEnterprize
{
    /// <summary>
    /// Отвечает за отправку писем на электронную почту
    /// </summary>
    class Mail
    {
        /// <summary>
        /// smtp-сервер
        /// </summary>
        private string smtp = "smtp.mail.ru";
        /// <summary>
        /// отправитель
        /// </summary>
        private string from = "VirtualEnterprize@mail.ru";
        /// <summary>
        /// пароль почты
        /// </summary>
        private string password = "19930511q";
        /// <summary>
        /// тема письма
        /// </summary>
        private string subject = "";
        /// <summary>
        /// Адресат
        /// </summary>
        private string to = "";
        /// <summary>
        /// Содержание письма
        /// </summary>
        private string body = "";
        /// <summary>
        /// Логин
        /// </summary>
        private string login = "VirtualEnterprize@mail.ru";
       
        /// <summary>
        /// Отправляет письмо
        /// </summary>
        /// <param name="sendTo">адресат письма</param>
        /// <param name="subject">тема письма</param>
        /// <param name="body">содержание письма в формате html</param>
        public void Send(string sendTo, string subject, string body)
        {
            this.from = login;
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
