using System.Data.SqlClient;

namespace DiplomVirtualEnterprize
{
    class Data
    {
        /// <summary>
        /// Строка соединения с сервером
        /// </summary>
        private static readonly string ConnectionString = @"Data Source=USER-ПК\SQLEXPRESS;Initial Catalog=virtual_enterprise;Integrated security=true";
        public int Login(string mail, string password)
        {
            int findEmployee=0;
           
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
        /// <param name="mail"></param>
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
    }
}
