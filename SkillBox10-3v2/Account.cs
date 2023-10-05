using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox10_3v2
{
    internal class Account
    {
        public string _lastName;
        public string _firstName;
        public string _patronymic;
        public string _phoneNumber;
        public string _passport;
        public DateTime _timeDataChange;
        public string _changing;
        public string _typeChange;
        public string _whoChange;
        public DateTime defaultDate = new DateTime();
        public Account() { }
        public Account(string lastName, string firstName, string patronymic, string phoneNumber, string passport)
        {

            _lastName = lastName;
            _firstName = firstName;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passport = passport;
        }
        public List<Account> Read()
        {
            StreamReader sr = new StreamReader("Accounts.txt");
            List<Account> accs = new List<Account>();
            List<string> acc = new List<string>();
            while (!sr.EndOfStream)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('#');
                    foreach (string part in parts)
                    {
                        acc.Add(part);
                    }
                    Account ac = new Account(acc[0], acc[1], acc[2], (acc[3]), acc[4]);
                    if (acc.Count > 5)
                    {
                        ac._timeDataChange = Convert.ToDateTime(acc[5]);
                        ac._changing = acc[6];
                        ac._typeChange = acc[7];
                        ac._whoChange = acc[8];
                    }
                    accs.Add(ac);
                    acc.Clear();
                }

            }
            sr.Close();
            return accs;
        }
        private string ToFile(string sep)
        {
            if (this._timeDataChange == defaultDate)
            {
                return $"{this._lastName}{sep}{this._firstName}{sep}{this._patronymic}{sep}{this._phoneNumber}{sep}{this._passport}";
            }
            else
            {
                return $"{this._lastName}{sep}{this._firstName}{sep}{this._patronymic}{sep}{this._phoneNumber}{sep}{this._passport}{sep}{_timeDataChange}" +
                    $"{sep}{_changing}{sep}{_typeChange}{sep}{_whoChange}";
            }
        }
        public void Write(List<Account> list)
        {
            StreamWriter sw = new StreamWriter("Accounts.txt");
            foreach (Account el in list)
            {
                sw.WriteLine(el.ToFile("#"));
            }
            sw.Close();
        }

    }
}
