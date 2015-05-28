using System.Data.SqlClient;
using DiplomVirtualEnterprize.Model;
using System.Collections.Generic;
using System;
namespace DiplomVirtualEnterprize
{
    /// <summary>
    /// Отвечает за обмен данными с базой данных
    /// </summary>
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
        /// <param name="idVirtualEnterprise"></param>
        /// <returns>возвращает все проекты предприятия</returns>
        public List<Project> FindAllProject(int idVirtualEnterprise)
        {
            var listProject = new List<Project>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = @"
                          select *                        
                        from 
                            Project
                        where 
                            idVE=@idVirtualEnterprise
                    ";
                    cmd.Parameters.AddWithValue("@idVirtualEnterprise", idVirtualEnterprise);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var project = new Project
                            {
                                IdProject = reader.GetInt32(reader.GetOrdinal("idProject")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Deadline = reader.GetDateTime(reader.GetOrdinal("deadline")),
                                IdVirtualEnterprise = reader.GetInt32(reader.GetOrdinal("idVE")),
                            };
                            listProject.Add(project);
                        }
                    }
                }
            }
            return listProject;
        }
        /// <summary>
        /// Найти все задачи проекта
        /// </summary>
        /// <param name="idProject">код проекта</param>
        /// <returns>возвращает все задачи проекта</returns>
        public List<Task> FindTasksProject(int idProject)
        {
            var listTask = new List<Task>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = @"
                          select *                        
                        from 
                            Tasks
                        where 
                            idProject=@idProject
                    ";
                    cmd.Parameters.AddWithValue("@idProject", idProject);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var task = new Task
                            {
                                TaskId = reader.GetInt32(reader.GetOrdinal("taskId")),
                                IdProject = reader.GetInt32(reader.GetOrdinal("idProject")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Deadline = reader.GetDateTime(reader.GetOrdinal("deadline")),
                                DataCreation = reader.GetDateTime(reader.GetOrdinal("dateCreation")),
                                WastedTime = reader.GetInt32(reader.GetOrdinal("wastedTime")),
                                IdExecutor = reader.GetInt32(reader.GetOrdinal("idExecutor")),
                                isTaskComplete = reader.GetBoolean(reader.GetOrdinal("isTaskComplete")),
                                Author = reader.GetInt32(reader.GetOrdinal("idAuthor")),
                            };
                            listTask.Add(task);
                        }
                    }
                }
            }
            return listTask;
        }
        /// <summary>
        /// Найти всех сотрудников предприятия
        /// </summary>
        /// <param name="idVirtualEnterprise">код виртуально предприятия</param>
        /// <returns>вовращает всех сотрудников</returns>
        public List<Employee> FindAllEmployee(int idVirtualEnterprise)
        {
            var listEmployee = new List<Employee>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = @"
                          select *                        
                        from 
                            Employees,CompanyEmployee
                        where 
                            idVE=@idVirtualEnterprise and
                        Employees.employeeId=CompanyEmployee.idEmployee
                    ";
                    cmd.Parameters.AddWithValue("@idVirtualEnterprise", idVirtualEnterprise);
                    listEmployee = GetEmployees(cmd);
                }
            }
            return listEmployee;
        }
        /// <summary>
        /// Найти участников проекта
        /// </summary>
        /// <param name="idproject">код проекта</param>
        /// <returns>возвращает всех участников проекта</returns>
        public List<Employee> FindParticipantProject(int idProject)
        {
            var listEmployee = new List<Employee>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = @"
                          select *                        
                        from 
                            Employees
                        where 
                            idProject=@idProject
                    ";
                    cmd.Parameters.AddWithValue("@idProject", idProject);
                    listEmployee = GetEmployees(cmd);
                }
            }
            return listEmployee;
        }

        /// <summary>
        /// Считывает данные сотрудников из базы данных
        /// </summary>
        /// <param name="cmd">sql-команда с запросом</param>
        /// <returns>возвращает лист сотрудников</returns>
        private List<Employee> GetEmployees(SqlCommand cmd)
        {
            var listEmployee = new List<Employee>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        IdEmployee = reader.GetInt32(reader.GetOrdinal("idEmployee")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Family = reader.GetString(reader.GetOrdinal("family")),
                        Patronymic = reader.GetString(reader.GetOrdinal("patronymic")),
                        Mail = reader.GetString(reader.GetOrdinal("mail")),
                        Password = reader.GetString(reader.GetOrdinal("passwordEmployee")),
                        Position = reader.GetString(reader.GetOrdinal("position")),
                    };
                    listEmployee.Add(employee);
                }
            }
            return listEmployee;
        }
        /// <summary>
        /// Добавить сотрудника в проект
        /// </summary>
        /// <param name="idEmployee">код сотрудника</param>
        /// <param name="idProject">код проекта</param>
        public void AddEmployeeInProject(int idEmployee, int idProject)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string addEmployee = @"insert into ParticipantProject
                                        (
                                            idEmployee,
                                            idProject
                                        )
                                        values
                                        (
                                            @idEmployee,
                                            
                                        )
                                    ";
                connection.Open();

                using (var cmd = new SqlCommand(addEmployee, connection))
                {
                    cmd.Parameters.AddWithValue("@idEmployee", idEmployee);
                    cmd.Parameters.AddWithValue("@idProject", idProject);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Изменить статус выполнения задачи
        /// </summary>
        /// <param name="idTask">код задачи</param>
        public void ChangeStatusTask(int idTask)
        {
            bool isTaskComplete;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = @"
                        select isTaskComplete
                        from Tasks
                        where taskId=@idTask";
                    cmd.Parameters.AddWithValue("@idTask", idTask);
                    isTaskComplete = (bool)cmd.ExecuteScalar();
                }
                    isTaskComplete = !isTaskComplete;
                    int taskComplete=0;
                    if (isTaskComplete)
                    {
                        taskComplete = 1;
                    }
                    using (var cmd = connection.CreateCommand())
                    {
                    cmd.CommandText = @"
                       update Tasks
                       set isTaskComplete=@taskComplete
                       where taskId=@idTask";
                      cmd.Parameters.AddWithValue("@taskComplete", taskComplete);
                      cmd.Parameters.AddWithValue("@idTask", idTask);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить сотрудника из проекта
        /// </summary>
        /// <param name="idEmployee">код сотрудника</param>
        /// <param name="idProject">код проекта</param>
        public void RemoveEmployeeFromProject(int idEmployee, int idProject)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = @"
                        delete from ParticipantProject
                        where idEmployee=@idEmployee
                        and idProject=@idProject";
                    cmd.Parameters.AddWithValue("@idEmployee", idEmployee);
                    cmd.Parameters.AddWithValue("@idProject", idProject);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="deadline">срок завершения</param>
        /// <param name="idAuthor">код автора</param>
        /// <param name="idExecutor">код исполнителя</param>
        /// <param name="idProject">код проекта</param>
        public void AddTask(string name, DateTime? deadline, int idAuthor, int idExecutor, int idProject)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                //текущее время
                DateTime? curTime = DateTime.Now;
                string addTask = @"insert into Tasks
                                        (
                                            name,
                                            dataCreation,
                                            deadline,
                                            idAuthor,
                                            idExecutor,
                                            idProject
                                        )
                                        values
                                        (
                                            @name,
                                            @dataCreation,
                                            @deadline,
                                            @idAuthor,
                                            @idExecutor
                                            @idProject,                                            
                                        )
                                    ";
                connection.Open();

                using (var cmd = new SqlCommand(addTask, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@dataCreation", curTime);
                    cmd.Parameters.AddWithValue("@deadline", deadline);
                    cmd.Parameters.AddWithValue("@idAuthor",idAuthor);
                    cmd.Parameters.AddWithValue("@idExecutor", idExecutor);
                    cmd.Parameters.AddWithValue("@idProject", idProject);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="idTask">код задачи</param>
        /// <param name="deadline">срок завершения</param>
        /// <param name="idExecutor">код исполнителя</param>
        /// <param name="idProject">код проекта</param>
        public void ChangeTask(int idTask, DateTime? deadline, int idExecutor, int idProject)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {              
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                       update Tasks
                       set deadline=@deadline,
                        idExecutor=@idExecutor,
                        idProject=@idProject
                       where taskId=@idTask";
                    cmd.Parameters.AddWithValue("@deadline", deadline);
                    cmd.Parameters.AddWithValue("@idExecutor", idExecutor);
                    cmd.Parameters.AddWithValue("@idProject", idProject);
                    cmd.Parameters.AddWithValue("@idTask", idTask);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="idTask">код задачи</param>
        public void DeleteTask(int idTask)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = @"
                        delete from Tasks
                        where idTask=@idTask";
                    cmd.Parameters.AddWithValue("@idEmployee", idTask);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Добавить время потраченное на задачу
        /// </summary>
        /// <param name="idTask">код задачи</param>
        /// <param name="countTime">количество времени</param>
        public void AddTimeInTask(int idTask, int countTime)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                       update Tasks
                       set wastedTime=wastedTime+ @countTime
                       where taskId=@idTask";
                    cmd.Parameters.AddWithValue("@countTime",countTime);
                    cmd.Parameters.AddWithValue("@idTask", idTask);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Message> FindAllMessageDialogue(int idDialogue)
        {
            var listMessage = new List<Message>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = @"
                          select *                        
                        from 
                            Message
                        where 
                            idDialogue=@idDialogue 
                    ";
                    cmd.Parameters.AddWithValue("@idDialogue", idDialogue);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var message = new Message
                            {
                                IdMessage = reader.GetInt32(reader.GetOrdinal("idMessage")),
                                Content = reader.GetString(reader.GetOrdinal("content")),
                                IdDialogue = reader.GetInt32(reader.GetOrdinal("idDialogue")),
                                DateStart = reader.GetDateTime(reader.GetOrdinal("dateStart")),
                            };
                            listMessage.Add(message);
                        }
                    }
                }
            }
            return listMessage;
        }
        /// <summary>
        /// Добавить сообщение в диалог
        /// </summary>
        /// <param name="idDialogue">код диалога</param>
        /// <param name="message">сообщение</param>
        public void AddMessage(int idDialogue, Message message)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                //текущее время
                DateTime? curTime = DateTime.Now;
                string addTask = @"insert into Tasks
                                        (
                                            idMessage,
                                            content,
                                            idDialogue,
                                            dateStart,
                                        )
                                        values
                                        (
                                            @idMessage,
                                            @content,
                                            @idDialogue,
                                            @dateStart                                         
                                        )
                                    ";
                connection.Open();

                using (var cmd = new SqlCommand(addTask, connection))
                {
                    cmd.Parameters.AddWithValue("@idMessage", message.IdMessage);
                    cmd.Parameters.AddWithValue("@content",message.Content);
                    cmd.Parameters.AddWithValue("@idDialogue",message.IdDialogue);
                    cmd.Parameters.AddWithValue("@dateStart", message.DateStart);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// найти все диалоги сотрудника
        /// </summary>
        /// <param name="idEmployee">код сотрудника</param>
        /// <returns>возвращает диалоги сотрудника</returns>
        public List<Dialogue> FindAllDialogueEmployee(int idEmployee)
        {
            var listDialogue = new List<Dialogue>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = @"
                          select *                        
                        from 
                            Dialogue,DialogueEmployee
                        where 
                            idEmployee=@idEmployee and
                            Dialogue.idDialogueEmployee=
                            DialogueEmployee.idDialogueEmployee
                    ";
                    cmd.Parameters.AddWithValue("@idEmployee", idEmployee);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dialogue = new Dialogue
                            {
                                IdDialogue = reader.GetInt32(reader.GetOrdinal("idDialogue")),
                                IdDialogueEmployee = reader.GetInt32(reader.GetOrdinal("idDialogueEmployee")),
                            };
                            listDialogue.Add(dialogue);
                        }
                    }
                }
            }
            return listDialogue;
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
        public void AddSubscription(int idSignedEmployee, int idFellowSubscription)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string addSubscription = @"insert into Subscription
                                        (
                                            idSignedEmployee,
                                            idFellowSubscription,
                                        )
                                        values
                                        (
                                            @idSignedEmployee,
                                            @idFellowSubscription,                                        
                                        )
                                    ";
                connection.Open();

                using (var cmd = new SqlCommand(addSubscription, connection))
                {
                    cmd.Parameters.AddWithValue("@idSignedEmployee", idSignedEmployee);
                    cmd.Parameters.AddWithValue("@idFellowSubscription", idFellowSubscription);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Отписаться от подписки
        /// </summary>
        /// <param name="idSignedEmployee">код подписывающегося сотрудника</param>
        /// <param name="idFellowSubscription">код сотрудника на которого подписываются</param>
        public void RemoveSubscription(int idSignedEmployee, int idFellowSubscription)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = @"
                        delete from Subscription
                        where idSignedEmployee=@idSignedEmployee 
                        and idFellowSubscription=@idFellowSubscription ";
                    cmd.Parameters.AddWithValue("@idFellowSubscription", idFellowSubscription);
                    cmd.Parameters.AddWithValue("@idSignedEmployee", idSignedEmployee);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Найти все сообщения от подписок
        /// </summary>
        /// <param name="idSignedEmployee">код подписавшегося сотрудника</param>
        /// <returns>сообщения от подписок</returns>
        public List<SubscriptionMessage> FindAllSubscriptionMessage(int idSignedEmployee)
        {
            var listSubscriptionMessage = new List<SubscriptionMessage>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = @"
                          select *                        
                        from 
                            Subscription,PostSuscription
                        where 
                            Subscription.idSubscription=
                            PostSuscription.PostSuscription 
                            and idSignedEmployee=@idSignedEmployee
                    ";
                    cmd.Parameters.AddWithValue("@idSignedEmployee", idSignedEmployee);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subscriptionMessage = new SubscriptionMessage
                            {
                                 IdPostSubscription= reader.GetInt32(reader.GetOrdinal("IdPostSubscription")),
                                 Content = reader.GetString(reader.GetOrdinal("[content]")),
                                 DateStart = reader.GetDateTime(reader.GetOrdinal("dateStart")),
                                 IdSubscription = reader.GetInt32(reader.GetOrdinal("idSubscription")),
                            };
                            listSubscriptionMessage.Add(subscriptionMessage);
                        }
                    }
                }
            }
            return listSubscriptionMessage;
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
            var employee=new Employee();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();

                    cmd.CommandText = @"
                          select *                        
                        from 
                            Employees
                        where 
                            idEmployee=@idEmployee
                    ";
                    cmd.Parameters.AddWithValue("@idEmployee", idEmployee);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          employee.Name= reader.GetString(reader.GetOrdinal("name"));
                            employee.IdEmployee=reader.GetInt32(reader.GetOrdinal("employeeId"));
                            employee.Family=reader.GetString(reader.GetOrdinal("family"));
                             employee.Patronymic=reader.GetString(reader.GetOrdinal("patronymic"));
                             employee.Password=reader.GetString(reader.GetOrdinal("passwordEmployee"));
                             employee.Mail=reader.GetString(reader.GetOrdinal("mail"));
                             employee.Position = reader.GetString(reader.GetOrdinal("position"));                
                        }
                    }
                    }
                }
             return employee;
            }        
        
        /// <summary>
        /// Изменить инофрмацию сотрудника
        /// </summary>
        /// <param name="employee">сотрудник</param>
        public void ChangeEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                       update Employees
                       set  name,
                            family, 
                            patronymic,
                            mail,
                            password,
                            position
                       where emloyeeId=@idEmployee";
                    cmd.Parameters.AddWithValue("@name",employee.Name);
                    cmd.Parameters.AddWithValue("@family", employee.Family);
                    cmd.Parameters.AddWithValue("@patronymic", employee.Patronymic );
                    cmd.Parameters.AddWithValue("@mail",employee.Mail);
                    cmd.Parameters.AddWithValue("@password", employee.Password);
                    cmd.Parameters.AddWithValue("@position", employee.Position);
                    cmd.Parameters.AddWithValue("@idEmployee", employee.IdEmployee);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
