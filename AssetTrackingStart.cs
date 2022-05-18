using AssetTrakingSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTrackingSystem {
    internal class AssetTrackingStart {
        static void Main(string[] args) {
            AssetTracking assestTracking = new AssetTracking();
            assestTracking.Dashboard();
        }
    }


    class AssetTracking {

        private List<Assets> assets = new();

        //reference from https://stackoverflow.com/questions/14987156/one-key-to-multiple-values-dictionary-in-c

        //private Dictionary<string, dynamic> country = new();


        private Dictionary<string, (double currentRate, string currency)> country = new() {
            { "Sweden", Currency("Sweden") },
            { "sweden", Currency("Sweden") },
            { "Finland", Currency("Finland") },
            { "finland", Currency("Finland") },
            { "Spain", Currency("Spain") },
            { "spain", Currency("Spain") },
            { "UK", Currency("UK") },
            { "uk", Currency("UK") },
        };

        private static (double currentRate, string currency) Currency(string inputString) {
            var currencyString = (currentRate: 1.0, currency: "$");
            if (inputString == "Sweden") {
                currencyString = (currentRate: 9.95, currency: "SEK");
            }
            if (inputString == "Finland") {
                currencyString = (currentRate: 0.95, currency: "EUR");
            }
            if (inputString == "Spain") {
                currencyString = (currentRate: 0.95, currency: "EUR");
            }
            if (inputString == "UK") {
                currencyString = (currentRate: 0.81, currency: "£");
            }


            return currencyString;
        }

        public void Dashboard() {
            /* country["Sweden"] = new System.Dynamic.ExpandoObject(); ;
             country["Sweden"].currentRate = 9.95;
             country["Sweden"].currency = "SEK";
             country["Finland"] = new System.Dynamic.ExpandoObject();
             country["Finland"].currentRate = 0.95;
             country["Finland"].currency = "EUR";
             country["Spain"] = new System.Dynamic.ExpandoObject();
             country["Spain"].currentRate = 0.95;
             country["Spain"].currency = "EUR";
             country["UK"] = new System.Dynamic.ExpandoObject();
             country["UK"].currentRate = 0.81;
             country["UK"].currency = "£"; */

            bool exit = true;
            while (exit) {
                Console.Clear();
                Console.WriteLine("Office Assets!");
                Console.WriteLine("------------");
                Console.WriteLine("Enter");
                Console.WriteLine("'Add/a' to Add Assets");
                Console.WriteLine("'Quit/q' to Quit Assets");
                Console.WriteLine("'Show/s' to Show Assets");

                string Choice = Console.ReadLine();
                if (Choice == "q") {
                    System.Environment.Exit(0);
                } else if (Choice == "a") {
                    Add();
                } else if (Choice == "s") {
                    Show();
                }

            }
        }

        public void Show() {
            Console.Clear();


            List<Assets> sortedAssets = assets.OrderBy(assets => assets.Office).ThenBy(assets => assets.PurchaseDate).ToList();

            Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Office".PadRight(15) +
                                 "PurchaseDate".PadRight(15) + "Model".PadRight(15) + "Price in USD".PadRight(15) +
                                 "Currency".PadRight(15) + "Local Price Today".PadRight(15) + "\n");

            foreach (Assets assets in sortedAssets) {

                DateTime expiry = assets.PurchaseDate.AddYears(3);

                TimeSpan timeLeft = expiry - DateTime.Today;

                if (timeLeft.Days <= 90) {
                    Console.ForegroundColor = ConsoleColor.Red;

                } else if ((timeLeft.Days <= 180)) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine(assets.Type.PadRight(15) + assets.Brand.PadRight(15) + assets.Office.PadRight(15)
                     + assets.PurchaseDate.ToString("dd/MM/yyyy").PadRight(15) + assets.Model.PadRight(15) + assets.Price.PadRight(15)
                     + country[assets.Office].currency.PadRight(15) + country[assets.Office].currentRate * double.Parse(assets.Price));
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.ReadLine();

        }

        public void Add() {

           /* assets.Add(new Phone("Phone", "Iphone", "Sweden", DateTime.Parse("01/07/2019"), "i13", "900"));
            assets.Add(new Phone("Phone", "Iphone", "Sweden", DateTime.Parse("11/10/2019"), "i12", "990"));
            assets.Add(new Phone("Phone", "Samsung", "Sweden", DateTime.Parse("01/04/2022"), "A20", "500"));
            assets.Add(new Computer("Computer", "lenovo", "Sweden", DateTime.Parse("01/04/2022"), "g650", "500"));
            assets.Add(new Computer("Computer", "Dell", "UK", DateTime.Parse("15/03/2022"), "z50", "500"));
            assets.Add(new Computer("Computer", "Dell", "Spain", DateTime.Parse("14/03/2022"), "z50", "400"));
            Console.Clear();
            return;*/
            Console.WriteLine("Type");
            string Type = Console.ReadLine();

            Console.WriteLine("Brand");
            string Brand = Console.ReadLine();

            Console.WriteLine("Office");
            string Office = Console.ReadLine();

            Console.WriteLine("PurchaseDate");
            string PurchaseDate = Console.ReadLine();

            Console.WriteLine("Model");
            string Model = Console.ReadLine();

            Console.WriteLine("Price in $USD");
            string Price = Console.ReadLine();

            if (Type == "phone" || Type == "p" || Type == "Phone") {
                Phone phone = new Phone("Phone", Brand, Office, DateTime.Parse(PurchaseDate), Model, Price);
                assets.Add(phone);
            } else {
                Computer computer = new Computer("Computer", Brand, Office, DateTime.Parse(PurchaseDate), Model, Price);
                assets.Add(computer);

            }
        }
    }


}