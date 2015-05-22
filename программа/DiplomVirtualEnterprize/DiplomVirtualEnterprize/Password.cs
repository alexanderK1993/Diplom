using System;
namespace DiplomVirtualEnterprize
{
    /// <summary>
    /// Класс для генерации паролей
    /// </summary>
   public class Password
    {
       /// <summary>
        ///  /// <summary>
        /// Сгенерировать случайный пароль
       /// </summary>
       /// <param name="lenght">длина пароля</param>
        /// <returns>возвращает сгенирированный пароль</returns>
            public string GeneratePassword(int lenght)
            {
                int[] arr = new int[lenght]; 
                Random rnd = new Random();
                string Password = "";

                for (int i = 0; i < arr.Length; i++)
                {
                   //генерируем случайное число и заменяем на символ согласно таблице ASC
                    arr[i] = rnd.Next(48, 122);
                    Password += (char)arr[i];
                }
                return Password;
            }
     
    }
}
