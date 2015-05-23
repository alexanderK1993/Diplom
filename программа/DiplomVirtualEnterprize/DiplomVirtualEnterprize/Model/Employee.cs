using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize.Model
{
    /// <summary>
    /// Хранит информацию о сотруднике предприятия
    /// </summary>
    class Employee
    {
        /// <summary>
        /// Устанавливает и возвращает код сотрудника
        /// </summary>
        public int IdEmployee { set; get; }
        /// <summary>
        /// Устанавливает и возвращает имя
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Устанавливает и возвращает фамилию
        /// </summary>
        public string Family { set; get; }
        /// <summary>
        /// Устанавливает и возвращает отчество
        /// </summary>
        public string Patronymic { set; get; }
        /// <summary>
        /// Устанавливает и возвращает электронную почту
        /// </summary>
        public string Mail { set; get; }
        /// <summary>
        /// Устанавливает и возвращает пароль
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        /// Устанавливает и возвращает должность
        /// </summary>
        public string Position { set; get; }
    }
}
