using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize.Model
{
    /// <summary>
    /// Хранит информацию о сообщении
    /// </summary>
    class Message
    {
        /// <summary>
        /// Устанавливает и возвращает код сообщения
        /// </summary>
        public int IdMessage { set; get; }
        /// <summary>
        /// Устанавливает и возвращает контент
        /// </summary>
        public string Content { set; get; }
        /// <summary>
        /// Устанавливает и возвращает код диалога
        /// </summary>
        public int IdDialogue { set; get; }
        /// <summary>
        /// Устанавливает и возвращает дату отправки
        /// </summary>
        public DateTime DateStart { set; get; }
    }
}
