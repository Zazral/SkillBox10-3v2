using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox10_3v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IChange acc;
            Console.WriteLine("Вы 1-консультант, 2-менеджер");
            int chose = int.Parse(Console.ReadLine());
            if (chose == 1)
            {
                Konsultant kons = new Konsultant();
                kons.Print();
                Console.WriteLine("хотите изменить номер телефона?\n1-да, 2-нет");
                chose = int.Parse(Console.ReadLine());
                if (chose == 1)
                {
                    acc = new Konsultant();
                    acc.Changing();
                    kons.Print();
                }
            }
            else
            {
                Manager man = new Manager();
                man.Print();
                Console.WriteLine("хотите\n1-добавить пользователя\n2-изменить данные");
                chose = int.Parse(Console.ReadLine());
                if (chose == 1) { man.Add(); }
                else
                {
                    acc = new Manager();
                    acc.Changing();
                }
                man.Print();
            }
            Console.ReadKey();
        }
    }
}
