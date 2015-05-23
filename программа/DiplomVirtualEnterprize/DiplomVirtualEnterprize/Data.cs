using System.Data.SqlClient;
using DiplomVirtualEnterprize.Model;
using System.Collections.Generic;
using System;
namespace DiplomVirtualEnterprize
{
    class Data
    {
        /// <summary>
        /// Строка соединения с сервером
        /// </summary>
        private static readonly string ConnectionString = @"Data Source=USER-ПК\SQLEXPRESS;Initial Catalog=virtual_enterprise;Integrated security=true";

        /// <summary>
        /// Авторизация на сервере
        /// </summary>
        /// <param name="mail">электронная почта</param>
        /// <param name="password">пароль</param>
        /// <returns>если возвращается 1 значит соединение успешно установлено</returns>
        public int Login(string mail, string password)
        {
            int findEmployee = 0;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"select count (employeeId)
                                            from employees
                                            where mail=@mail and passwordEmployee=@password";
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@password", password);
                    findEmployee = (int)cmd.ExecuteScalar();
                }
            }
            return findEmployee;
        }


        /// <summary>
        /// Регистрация компании в системе
        /// </summary>
        /// <param name="mail">почта</param>
        /// <param name="password">пароль</param>
        /// <returns>возвращает true если регистрация успешна</returns>
        public bool Registration(string mail, string password)
        {
            if (FindMail(mail) == false)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                        insert into 
                            Employees 
                                ( 
                                mail
                                ,passwordEmployee
                                ,name
                                )
                        values 
                                (
                                @mail
                                ,@password
                                ,@name
                                )
                    ";
                        cmd.Parameters.AddWithValue("@mail", mail);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@name", mail);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            else return false;
        }

        /// <summary>
        /// Ищет конкретный адрес в базе данных
        /// </summary>
        /// <param name="mail">почта</param>
        /// <returns>возвращает true если адрес найден</returns>
        public bool FindMail(string mail)
        {
            bool mailFind = false;
            int countMail;
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string findMail = @"select count (mail)
                                from employees
                                where mail=@mail";
                using (var cmd = new SqlCommand(findMail, connection))
                {
                    cmd.Parameters.AddWithValue("@mail", mail);
                    countMail = (int)cmd.ExecuteScalar();
                }
            }

            if (countMail > 0)
            {
                mailFind = true;
            }
            return mailFind;
        }
     /// <summary>
        ///Найти все проекты предприятия
        /// </summary>
        /// <returns>возвращает все проекты предприятия</returns>
        public List<Project> FindAllProject()
        {
            return new List<Project>();
        }
        /// <summary>
        /// Найти все задачи проекта
        /// </summary>
        /// <param name="idProject">код проекта</param>
        /// <returns>возвращает все задачи проекта</returns>
        public List<Task> FindTasksProject(int idProject)
        {
            return new List<Task>();
        }
        /// <summary>
        /// Найти всех сотрудников предприятия
        /// </summary>
        /// <param name="idVirtualEnterprise">код виртуально предприятия</param>
        /// <returns>вовращает всех сотрудников</returns>
        public List<Employee> FindAllEmployee(int idVirtualEnterprise)
        {
            return new List<Employee>();
        }
        /// <summary>
        /// Найти участников проекта
        /// </summary>
        /// <param name="idproject">код проекта</param>
        /// <returns>возвращает всех участников проекта</returns>
        public List<Employee>  FindParticipantProject(int idproject)
        {
            return new List<Employee>();
        }
        /// <summary>
        /// Добавить сотрудника в проект
        /// </summary>
        /// <param name="idEmployee">код сотрудника</param>
        public void AddEmployeeInProject(int idEmployee)
        { }
        /// <summary>
        /// Изменить статсу выполнения задачи
        /// </summary>
        /// <param name="idTask">код задачи</param>
        public void ChangeStatusTask(int idTask)
        { }
        /// <summary>
        /// Удалить сотрудника из проекта
        /// </summary>
        /// <param name="idEmployee">код сотрудника</param>
        /// <param name="idProject">код проекта</param>
        public void RemoveEmployeeFromProject(int idEmployee,int idProject)
        { }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="deadline">срок завершения</param>
        /// <param name="idAuthor">код автора</param>
        /// <param name="idExecutor">код исполнителя</param>
        /// <param name="idProject">код проекта</param>
        public void AddTask(string name,DateTime? deadline,int idAuthor,int idExecutor,int idProject )
        {
        }
        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="idTask">код задачи</param>
        /// <param name="deadline">срок завершения</param>
        /// <param name="idExecutor">код исполнителя</param>
        /// <param name="idProject">код проекта</param>
        public void ChangeTask(int idTask,DateTime? deadline,int idExecutor,int idProject)
        { }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="idTask">код задачи</param>
        public void DeleteTask(int idTask)
        { }
        /// <summary>
        /// Добавить время потраченное на задачу
        /// </summary>
        /// <param name="idTask">код задачи</param>
        /// <param name="countTime">количество времени</param>
        public void AddTimeInTask(int idTask,int countTime)
        { }
        public List<Message> FindAllMessageDialogue(int idDialogue)
        {
            return new List<Message>();
        }
        /// <summary>
        /// Добавить сообщение в диалог
        /// </summary>
        /// <param name="idDialogue">код диалога</param>
        /// <param name="message">сообщение</param>
        public void AddMessage(int idDialogue,Message message)
        { }
        /// <summary>
        /// найти все диалоги сотрудника
        /// </summary>
        /// <param name="idEmployee">код сотрудника</param>
        /// <returns>возвращает диалоги сотрудника</returns>
        public List<Dialogue> FindAllDialogueEmployee(int idEmployee)
        {
            return new List<Dialogue>();
        }
    /*    /// <summary>
        /// Вклад участника в проект
        /// </summary>
        /// <param name="startDate">дата начала просмотра</param>
        /// <param name="finishDate">дата завершения просмотра</param>
        /// <param name="idEmployee">код сотрудника</param>
        /// <param name="idProject">код проекта</param>
        /// <returns>возвращает количество часов потраченных на проект в каждый день из диапозона</returns>
        public int[] ContributionToProject(DateTime startDate,DateTime finishDate,int idEmployee,int idProject)
        {
            return new int[4];
        }*/
        /// <summary>
        /// Добавляет подписку на сотрудника
        /// </summary>
        /// <param name="idSignedEmployee">код подписывающегося сотрудника</param>
        /// <param name="idFellowSubscription">код сотрудника на которого подписываются</param>
        public void AddSubscription(int idSignedEmployee,int idFellowSubscription)
        { }
        /// <summary>
        /// Отписаться от подписки
        /// </summary>
        /// <param name="idSignedEmployee">код подписывающегося сотрудника</param>
        /// <param name="idFellowSubscription">код сотрудника на которого подписываются</param>
        public void RemoveSubscription(int idSignedEmployee,int idFellowSubscription)
        {}
        /// <summary>
        /// Найти все сообщения от подписок
        /// </summary>
        /// <param name="idSignedEmployee">код подписавшегося сотрудника</param>
        /// <returns>сообщения от подписок</returns>
        public List<SubscriptionMessage> FindAllSubscriptionMessage(int idSignedEmployee)
        {
            return new List<SubscriptionMessage>();
        }

      /*  /// <summary>
        /// Вклад участников в проект
        /// </summary>
        /// <param name="idProject">код проекта</param>
        /// <returns>список участников проекта</returns>
        public List<ProjectParticipant> ContributionParticipantInProject(int idProject)
        {
            return new List<ProjectParticipant>();
        }      */      
        /// <summary>
        /// Получить иноформацию сотрудника
        /// </summary>
        /// <param name="idEmployee">код сотрудника</param>
        /// <returns>возвращает сотрудника</returns>
        public Employee GetEmployee(int idEmployee)
        {
            return new Employee();
        }
        /// <summary>
        /// Изменить инофрмацию сотрудника
        /// </summary>
        /// <param name="employee">сотрудник</param>
        public void ChangeEmployee(Employee employee)
        { }
    }  
    
}
