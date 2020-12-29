using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Director RomanSt = new Director { name = "RomanSt", cash = 150, promote = 2 };
            Director VladSt = new Director { name = "VladSt", cash = 100, promote = 1 };
            Director RomanTu = new Director { name = "RomanTu", cash = 200, promote = 4 };
            Director VladTu = new Director { name = "VladTu", cash = 125, promote = 1 };
            RomanSt.notify += Display;
            RomanTu.notify += Display;
            VladSt.notify += Display;
            VladTu.notify += Display;
            RomanSt.ToPromote();
            RomanSt.Fine();
            VladSt.ToPromote();
            VladTu.ToPromote();
            RomanTu.Fine();
            Console.Read();
        }
        static void Display(string message)
        {
            //Func<string> op = Str;
            //  message = op();
            Console.WriteLine(message);
            //op = Delete_symbol;
            //message = op();
            //Console.WriteLine(message);
            //op = Probel;
            //message = op();
            //Console.WriteLine(message);
            //op = Upper;
            //message = op();
            //Console.WriteLine(message);
            /*
            string Str() => message.Replace("a", "XXX");
            string Delete_symbol() => message.Replace("e", "");
            string Probel() => message.Insert(5, ",");
            string Upper() => message.ToUpper();
            */
        }
        public class Director
        {
            public delegate void directorHandler(string message);
            public event directorHandler notify;
            public string name;
            public int promote = 0;
            public int cash = 100;
            public string[] toPromotes = new string[5] { "Jun", "Mid", "Sen", "Lead", "PM" };
            public void ToPromote()
            {
                promote++;
                cash += 25;
                notify?.Invoke($"{name} вы повышены до {toPromotes[promote]}");
                notify?.Invoke($"{name} теперь ваша зарплата {cash}");
            }
            public void Fine()
            {
                promote--;
                cash -= 25;
                if (promote >= 0)
                {
                    notify?.Invoke($"{name} вы оштрафованы до {toPromotes[promote]}");
                    notify?.Invoke($"{name} теперь ваша зарплата {cash}");
                }
                else
                {
                    promote++;
                }

            }
        }
    }
}
