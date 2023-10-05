using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox10_3v2
{
    internal class Konsultant : IChange
    {
        protected string Passport { get { return "*******"; } }
        public Konsultant() { }

        protected Account acc = new Account();
        protected string ToString(Account acc)
        {
            string vivod = $"|{acc._lastName,-15}|{acc._firstName,-10}|{acc._patronymic,-14}|{acc._phoneNumber,-15}|{this.Passport}";
            if (acc._timeDataChange == acc.defaultDate)
            {
                return $"{vivod}";
            }
            else
            {
                return $"{vivod} {acc._timeDataChange} {acc._changing} {acc._typeChange} {acc._whoChange}";
            }
        }
        public void Print()
        {
            List<Account> accs = acc.Read();
            Console.Clear();
            for (int i = 0; i < accs.Count; i++)
            {
                Console.WriteLine($"{i} {this.ToString(accs[i])}");
            }
        }
        public void Changing()
        {
            List<Account> lst = new List<Account>();
            lst = acc.Read();
            Console.WriteLine("введите id аккаунта на котором хотите поменять номер телефона");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новый номер телефона");
            lst[id]._phoneNumber = Console.ReadLine();
            lst[id]._timeDataChange = DateTime.Now;
            lst[id]._changing = "PhoneNumber";
            lst[id]._typeChange = "изменение номера телефона";
            lst[id]._whoChange = "Консультант";
            acc.Write(lst);
        }
    }
}
