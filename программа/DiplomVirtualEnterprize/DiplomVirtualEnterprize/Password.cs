using System;
namespace DiplomVirtualEnterprize
{
    /// <summary>
    /// Класс для генерации паролей
    /// </summary>
   public class Password
    {
        /// <summary>
        /// Сгенерировать случайный пароль
        /// </summary>
        /// <returns></returns>
            public string GeneratePassword()
            {
                // сделаем длину пароля в 8 символов
                int[] arr = new int[8]; 
                Random rnd = new Random();
                string Password = "";

                for (int i = 0; i < arr.Length; i++)
                {
                   //генерируем случайное число и заменяем на символ
                    arr[i] = rnd.Next(48, 122);
                    Password += (char)arr[i];
                }
                return Password;
            }
     
    }
}
