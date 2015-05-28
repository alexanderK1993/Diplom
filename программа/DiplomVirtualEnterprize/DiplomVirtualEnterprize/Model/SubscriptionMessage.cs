using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize.Model
{
    /// <summary>
    /// Хранит сообщения от подписок
    /// </summary>
    class SubscriptionMessage
    {
        /// <summary>
        /// Код сообщения подписки
        /// </summary>
        public int IdPostSubscription{ set; get; }
        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        public string Content { set; get; }
        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime DateStart { set; get; }
        /// <summary>
        /// Код подписки
        /// </summary>
        public int IdSubscription { set; get; }
    }
}
