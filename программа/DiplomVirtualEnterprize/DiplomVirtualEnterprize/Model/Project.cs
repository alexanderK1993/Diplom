using System;
namespace DiplomVirtualEnterprize.Model
{
    /// <summary>
    /// Хранит информацию о проекте
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Устанавливает и возвращает код проекта
        /// </summary>
        public int IdProject { set; get; }
        /// <summary>
        /// Устанавливает и возвращает Имя проекта
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Устанавливает и возвращает срок завершения проекта
        /// </summary>
        public DateTime? Deadline { set; get; }
        /// <summary>
        /// Устанавливает и возвращает код виртуального предприятия
        /// </summary>
        public int IdVirtualEnterprise { set; get; }
    }
}
