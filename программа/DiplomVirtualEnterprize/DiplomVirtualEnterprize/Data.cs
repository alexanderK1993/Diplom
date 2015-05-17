using System.Data.SqlClient;

namespace DiplomVirtualEnterprize
{
    class Data
    {
        private string dataSource;
        private string initialCatalog;
        private string integratedSecurity;
        private string userID = "";
        private string password = "";
        private static readonly string ConnectionString = @"Data Source=USER-ПК\SQLEXPRESS;Initial Catalog=virtual_enterprise;Integrated security=true";
        public bool Registration(string login, string password)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
             connection.Open();
             string findMail = @"select count (mail)
                                from employees
                                where mail=@mail";
                int countMail;
                using (var cmd = new SqlCommand(findMail, connection))
                {
                    cmd.Parameters.AddWithValue("@mail", login);
                    countMail=(int)cmd.ExecuteScalar();
                }
                if (countMail == 0)
                {
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
                        cmd.Parameters.AddWithValue("@mail", login);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@name", login);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                else return false;
            }
        }
    }
}
