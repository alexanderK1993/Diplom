using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize.Model
{
    /// <summary>
    /// Хранит инофрмацию о диалоге сотрудника
    /// </summary>
    class DialogueEmployee
    {
        /// <summary>
        /// код диалога сотрудника
        /// </summary>
        public int IdDialogueEmployee{ set; get; }
        /// <summary>
        /// код сотрудника
        /// </summary>
        public int IdEmployee { set; get; }
    }
}
