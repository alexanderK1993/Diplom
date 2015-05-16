using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize
{
    class Data
    {
       private string dataSource;
       private string initialCatalog;
       private string integratedSecurity;
       private string userID = "";
       private string password = "";
       private static readonly string ConnectionString =@"Data Source=USER-ПК\SERVER;Initial Catalog=taskList_Kiryshin;Integrated security=true";
       public void openConnection()
       {
           try
           {
               dataSource = textBoxDataSource.Text.ToString();
               initialCatalog = textBoxInitialCatalog.Text.ToString();
               if (comboBoxIntegratedSecurity.SelectedItem == comboBoxIntegratedSecurity.Items[0])
               {
                   integratedSecurity = "false";
                   userID = textBoxUserID.Text.ToString();
                   password = textBoxPassword.Text.ToString();
               }
               else
               {
                   integratedSecurity = "true";
               }
           }
           catch
           {
               return;
           }
           FormMain.conn.ConnectionString = "Data Source=" + dataSource +
                                  ";Initial Catalog=" + initialCatalog + ";";
           if (comboBoxIntegratedSecurity.SelectedItem == comboBoxIntegratedSecurity.Items[0])
           {
               FormMain.conn.ConnectionString += "User ID=" + userID +
                                       ";Password=" + password + ";";
           }
           else
           {
               FormMain.conn.ConnectionString += "Integrated Security=" + integratedSecurity + ";";
           }
           try
           {
               FormMain.conn.Open();
               MessageBox.Show("Подключение успешно выполнено", "Проверка подключения", MessageBoxButtons.OK);
               buttonTest.Visible = false;
               this.Hide();
               // buttonCancel.Visible = true;
           }
           catch (System.Data.SqlClient.SqlException ex1)
           {
               MessageBox.Show("Не удалось выполнить подключение, проверьте корректность введенных данных", "Проверка подключения", MessageBoxButtons.OK);
           }
       }
    }
}
