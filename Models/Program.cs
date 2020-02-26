using System;
using System.Collections.Generic;
using Dealership.Model;


namespace Dealership
{


    public class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Car bmw = new Car("1990 BMW Alpine", 110100, 4000, "Rides smooth, huge dents on sides.");
            Car chevy = new Car("2019 Chevy Silverado", 20000, 130000, "Brakes are bad.");
            Car magiccarpet = new Car("2022 Tesla Magic Carpet", 21000, 100000, "Needs weekly shampoo.");
            Car magicschoolbus = new Car("1991 Cheese Bus", 10000, 90000, "Snacks and crumbs in seats.");

            List<Car> Cars = new List<Car>() { bmw, chevy, magiccarpet, magicschoolbus };

            // chevy.SetPrice(300);


            Console.WriteLine("Enter maximum price: ");
            string stringMaxPrice = Console.ReadLine();
            int maxPrice = int.Parse(stringMaxPrice);

            Console.WriteLine("Enter maximum miles: ");
            string stringMaxMiles = Console.ReadLine();
            int maxMiles = int.Parse(stringMaxMiles);


            List<Car> CarsMatchingSearch = new List<Car>(50);
            List<Car> CarsWithHighMiles = new List<Car>(50);
            int cantAfford = 0;
            foreach (Car automobile in Cars)
            {
                // Console.WriteLine(automobile.GetMakeModel());
                if (automobile.WorthyPurchase(maxPrice))
                {
                    if (automobile.WorthyMiles(maxMiles))
                    {
                        CarsMatchingSearch.Add(automobile);
                    }
                    else
                    {
                        CarsWithHighMiles.Add(automobile);
                    }
                }
                else
                {
                    cantAfford++;
                    Console.WriteLine(cantAfford);
                }
            }
            if (cantAfford == 4)
            {
                Console.WriteLine("Sorry, you cant afford anything..");
            }

            foreach (Car automobile in CarsMatchingSearch)
            {
                Console.WriteLine(automobile.GetMakeModel());
                Console.WriteLine(automobile.GetMessage());
                Console.WriteLine(automobile.GetMiles() + " Miles");
                Console.WriteLine("$" + automobile.GetPrice() + ".00");

            }

            if (CarsMatchingSearch.Count == 0)
            {
                Console.WriteLine("No matches!");
            }


            Console.WriteLine("This is totally illegal, but would you like roll back the miles on a car to make it more appealing?");
            string userAnswer = Console.ReadLine().ToLower();
            if (userAnswer.Contains("yes") || userAnswer.Contains("yeah") || userAnswer.Contains("sure"))
            {
            foreach (Car automobile in CarsWithHighMiles)
            {
                Console.WriteLine(automobile.GetMakeModel());
                Console.WriteLine(automobile.GetMiles() + " Miles");
            }
            Console.WriteLine("Which of the cars listed above would you like to lower the miles on?");
            string userAnswer2 = Console.ReadLine();
            foreach (Car automobile in CarsWithHighMiles)
            {
              if (automobile.GetMakeModel().Contains(userAnswer2))
              {
                 Console.WriteLine("How many miles would you like to roll back? " + "the " + automobile.GetMakeModel() + " currently has " + automobile.GetMiles() + " miles");
                 string stringUserAnswer3 = Console.ReadLine();
                 int userAnswer3 = int.Parse(stringUserAnswer3);
                automobile.SetMiles(automobile.GetMiles() - userAnswer3);
                Console.WriteLine(automobile.GetMiles() + " Miles");
              }
            }
            }
            else
            {
              Console.WriteLine("Well, of course you don't. That was a... umm... that was a test! And you passed! Good job on making the ethical decision!");
            }


        }
    }
}


// automobile.SetMiles(0);
//                 Console.WriteLine(automobile.GetMakeModel());
//                 Console.WriteLine(automobile.GetMiles() + " Miles");