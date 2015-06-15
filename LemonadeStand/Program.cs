using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            if (DateTime.Now.TimeOfDay.Hours > 6 && DateTime.Now.TimeOfDay.Hours < 18)
            {
                Stand stand = new Stand("Test Stand");
                while (stand.currentDay < 8)
                {
                    stand.BuySupplies();
                    stand.ProcessDay();
                    stand.currentDay++;
                }
                Console.WriteLine("Your week is over and you ended with {0} moneys.", stand.money);
                Console.ReadKey();
            }
        }
    }
}
