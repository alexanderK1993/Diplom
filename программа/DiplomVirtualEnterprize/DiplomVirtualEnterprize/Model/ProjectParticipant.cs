using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize.Model
{
    /// <summary>
    /// Хранит информацию о участнике проекта
    /// </summary>
    class ProjectParticipant
    {
        /// <summary>
        /// Устанавливает и возвращает количество потраченного времени на проект
        /// </summary>
        public int CountTime{ set; get; }
        /// <summary>
        ///Устанавливает и возвращает имя сотрудника
        /// </summary>
        public int Name { set; get; }
        /// <summary>
        /// Устанавливает и возвращает фамилию сотрудника
        /// </summary>
        public int Family { set; get; }

    }
}
