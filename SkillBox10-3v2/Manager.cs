using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox10_3v2
{
    internal class Manager : Konsultant, IChange
    {
        public Manager() { }
        public void Add()
        {
            string[] addingAcc = new string[5];
            Console.WriteLine("\nпоочередно введите: фамилию, имя, отчество, номер телефона и паспортные данные разделяя кнопкой enter");
            for (int i = 0; i < 5; i++)
            {
                addingAcc[i] = Console.ReadLine();
            }
            Account newPerson = new Account(addingAcc[0], addingAcc[1], addingAcc[2], addingAcc[3], addingAcc[4]);
            newPerson._timeDataChange = DateTime.Now;
            newPerson._typeChange = "добавление данных";
            newPerson._changing = "добавлен новый счет";
            newPerson._whoChange = "менеджер";
            List<Account> accounts = acc.Read();
            accounts.Add(newPerson);
            acc.Write(accounts);
        }
        public void Changing()
        {
            List<Account> lst = acc.Read();
            Console.WriteLine("напишите Id чьи данные хотите изменить и номер столбца данных для изменения разделяя клавишой enter");
            int[] id = new int[2];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = int.Parse(Console.ReadLine());
            }
            string typeOfChage = "";
            switch (id[1])
            {
                case 1:
                    lst[id[0]]._lastName = Console.ReadLine();
                    typeOfChage = "Lastname";
                    break;
                case 2:
                    lst[id[0]]._firstName = Console.ReadLine();
                    typeOfChage = "Firstname";
                    break;
                case 3:
                    lst[id[0]]._patronymic = Console.ReadLine();
                    typeOfChage = "Patronymic";
                    break;
                case 4:
                    lst[id[0]]._phoneNumber = Console.ReadLine();
                    typeOfChage = "PhoneNumber";
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine($"старые паспортные данные{lst[id[0]]._passport}");
                    lst[id[0]]._passport = Console.ReadLine();
                    typeOfChage = "Passport";
                    break;
            }
            acc = lst[id[0]];
            lst[id[0]]._timeDataChange = DateTime.Now;
            lst[id[0]]._changing = typeOfChage;
            lst[id[0]]._typeChange = $"редактирование {typeOfChage}";
            lst[id[0]]._whoChange = "Менеджер";
            acc.Write(lst);
        }
    }
}
