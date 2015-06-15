using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Stand
    {
        public double money = 20;
        public int currentDay = 1;

        int lemonsPerPitcher = 4;
        int sugarPerPitcher = 4;
        int cupsInPitcher = 0;
        int weather;
        int lemons = 12;
        int sugar = 12;
        int cups = 36;

        double pricePerCup = .50;
        double costPerLemon = .60;
        double costPerSugar = .4;
        double costPerCup = .1;

        string name;
        Random rand = new Random();

        public Stand(string name)
        {
            this.name = name;
            weather = rand.Next(1, 5);
        }

        public bool ProcessDay()
        {
            int people = rand.Next(20 * weather, 40 * weather);
            int cupsBought = 0;
            for (int i = 0; i < people; i++)
            {
                if (rand.Next(0, 100) < ((weather * 10) - (pricePerCup * 5)))
                {
                    if (cupsInPitcher == 0)
                    {
                        if (!CreatePitcher())
                        {
                            return false;
                        }
                    }

                    if (cups > 0)
                    {
                        money += pricePerCup;
                        cupsInPitcher--;
                        cupsBought++;
                        cups--;
                    }
                }
            }
            weather = rand.Next(1, 5);
            cupsInPitcher = 0;
            Console.WriteLine("You sold {0} cups of lemonade today for {1} moneys.", cupsBought, (cupsBought * pricePerCup));
            return true;
        }

        public void BuySupplies()
        {
            Console.WriteLine("Today is the {0} day. You have {1} days left.", currentDay, 7 - currentDay);
            Console.WriteLine("Its going to be " + (weather == 1 ? "rainy " : weather == 2 ? "sprinkling " : weather == 3 ? "warm " : weather == 4 ? " nice " : "hot ") + " outside today.");
            string choice = "b";
            while (choice != "p" || lemons < lemonsPerPitcher || sugar < sugarPerPitcher)
            {
                if (choice == "l")
                {
                    Console.Write("How many lemons would you like to buy: ");
                    choice = Console.ReadLine();
                    try
                    {
                        int count = Convert.ToInt32(choice);
                        if (money - (costPerLemon * count) >= 0)
                        {
                            money -= costPerLemon * count;
                            lemons += count;
                        }
                    }
                    catch (Exception e)
                    {
                        choice = "l";
                    }
                }
                else if (choice == "s")
                {
                    Console.Write("How many sugars would you like to buy: ");
                    choice = Console.ReadLine();
                    try
                    {
                        int count = Convert.ToInt32(choice);
                        if (money - (costPerSugar * count) >= 0)
                        {
                            money -= costPerSugar * count;
                            sugar += count;
                        }
                    }
                    catch (Exception e)
                    {
                        choice = "s";
                    }
                }
                else if (choice == "c")
                {
                    Console.Write("How many cups would you like to buy: ");
                    choice = Console.ReadLine();
                    try
                    {
                        int count = Convert.ToInt32(choice);
                        if (money - (costPerCup * count) >= 0)
                        {
                            money -= costPerCup * count;
                            cups += count;
                        }
                    }
                    catch (Exception e)
                    {
                        choice = "c";
                    }
                }
                else if (choice == "r")
                {
                    Console.Write("How much is it per cup: ");
                    choice = Console.ReadLine();
                    try
                    {
                        double cost = Convert.ToDouble(choice);
                        pricePerCup = cost;
                    }
                    catch (Exception e)
                    {
                        choice = "r";
                    }
                }
                else
                {
                    try
                    {
                        if (choice.StartsWith("-"))
                        {
                            ConsoleColor color = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), choice.Replace("-", ""), true);
                            Console.ForegroundColor = color;
                        }
                        else if (choice.StartsWith("+"))
                        {
                            ConsoleColor color = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), choice.Replace("+", ""), true);
                            Console.BackgroundColor = color;
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    Console.WriteLine("You have {0} lemons, {1} sugars, {2} cups, and {3} moneys. What would you like to do.", lemons, sugar, cups, money);
                    Console.WriteLine("l: Buy Lemons ({0} ea) ({1} per pitcher).", costPerLemon, lemonsPerPitcher);
                    Console.WriteLine("s: Buy Sugars ({0} ea) ({1} per pitcher).", costPerSugar, sugarPerPitcher);
                    Console.WriteLine("c: Buy Cups ({0} ea) (12 per pitcher).", costPerCup);
                    Console.WriteLine("r: Change Price Per Cup (${0})", pricePerCup);
                    Console.WriteLine("p: Play round.");
                    Console.Write("> ");
                    choice = Console.ReadLine();
                }
            }
        }

        private bool CreatePitcher()
        {
            if (lemons >= lemonsPerPitcher && sugar >= sugarPerPitcher)
            {
                lemons -= lemonsPerPitcher;
                sugar -= sugarPerPitcher;
                cupsInPitcher += 12;
                return true;
            }
            return false;
        }
    }
}
