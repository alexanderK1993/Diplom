using System;
namespace DiplomVirtualEnterprize.Model
{
    /// <summary>
    /// хранит информацию о задаче
    /// </summary>
   public class Task
    {
        /// <summary>
        /// Устанавливает и возвращает код задачи
        /// </summary>
        public int TaskId{set;get;}
        /// <summary>
        /// Устанавливает и возвращает имя задачи
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Устанавливает и возвращает дата создания
        /// </summary>
        public string DataCreation { set; get; }
        /// <summary>
        /// Устанавливает и возвращает срок завершения
        /// </summary>
        public DateTime? Deadline {set;get;}
        /// <summary>
        /// Устанавливает и возвращает потраченное время
        /// </summary>
        public int WastedTime { set; get; }
        /// <summary>
        /// Устанавливает и возвращает код исполнителя
        /// </summary>
        public int IdExecutor{set;get;}
        /// <summary>
        /// Устанавливает и возвращает код проекта
        /// </summary>
        public int IdProject { set; get; }

    }
}
