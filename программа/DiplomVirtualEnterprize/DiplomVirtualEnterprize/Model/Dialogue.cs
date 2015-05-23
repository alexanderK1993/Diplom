using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize.Model
{
    /// <summary>
    /// Хранит информацию о диалоге
    /// </summary>
    class Dialogue
    {
        /// <summary>
        /// Код диалога
        /// </summary>
        public int IdDialogue { set; get; }
        /// <summary>
        /// Код диалога сотрудника
        /// </summary>
        public int IdDialogueEmployee { set; get; }
    }
}
