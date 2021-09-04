using System;
using System.Collections.Generic;

namespace DataGenerator
{
    class DataSource
    {
        public List<DataStructure> data = new List<DataStructure>();

        DataStructure person_1 = new DataStructure() { Surname = "Магомедов", Name = "Мухаммад", Lastname = "Абдулаевич", Age = 22, Gender = 'M', INN = "9911368825", Login = "login", Password = "Password", Mail = "domovski@mail.ru", Passport_Code = "8212", Passport_Number = "291333" };
        
        DataStructure person_2 = new DataStructure() { Surname = "Магомедов", Name = "Багав", Lastname = "Абдулаевич", Age = 31, Gender = 'M', INN = "9911368825", Login = "login", Password = "Password", Mail = "domovski@mail.ru", Passport_Code = "8212", Passport_Number = "291333" };

        public List<string> Names = new List<string>();
        public List<string> Surnames = new List<string>();

        public void FillData()
        {
            // Тут по-хорошему запустить бы цикл
            data.Add(person_1);
            data.Add(person_2);
        }
        

        /// <summary>
        /// There filling names
        /// </summary>
        public void FillNames()
        {
            Names.Add("Али");
            Names.Add("Ахмад");
            Names.Add("Асхаб");
            Names.Add("Абдулла");
            Names.Add("Бадр");
            Names.Add("Бахлюль");
            Names.Add("Вагаб");
            Names.Add("Валид");
        }

        /// <summary>
        /// There filling surnames
        /// </summary>
        public void FillSurname()
        {
            Surnames.Add("Абдулаев");
            Surnames.Add("Ахмадов");
            Surnames.Add("Абакаров");
            Surnames.Add("Алиев");
            Surnames.Add("Будулаев");
            Surnames.Add("Давудов");
            Surnames.Add("Вадимов");
        }

        public Random rand = new Random();
        public void Start()
        {


            FillNames(); FillData(); FillSurname();

            for (int i = 0; i < 10; i++)
            {
                DataStructure user = new DataStructure() { 
                    Name = Names[rand.Next(Names.Count)], 
                    Surname = Surnames[rand.Next(Surnames.Count)],
                    Age = rand.Next(99),
                    Password = PasswordGenerator(),
                    Login = "post" + Surnames[rand.Next(Surnames.Count)] + "@mail.ru"
                    
                };
                data.Add(user);
            }
        }

        public string PasswordGenerator()
        {
            string alphabet = "QWERTYUIOPASDFGHJKLMNBVCXZ1234567890qwertyuioplkjhgfdsazxcvbnm";
            string password = "";
            for (int i = 0; i < 10; i++)
            {
                password += alphabet[rand.Next(alphabet.Length)];
            }

            return password;
        }
    }
}
