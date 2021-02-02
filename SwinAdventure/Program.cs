using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Getting user input for name and description
            Console.WriteLine("Write your name!");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your character desription!");
            string desc = Console.ReadLine();
            
            // Adding player and location
            Location north = new Location(new string[] { "north" }, "the hallway", "the long, dark, scary hallway");
            Player p = new Player(name, desc, north);

            // Creation of items + Add to inventory
            Item _shovel = new Item(new string[] { "shovel", "spade" }, "shovel", "This might be a fine...");
            Item _pc = new Item(new string[] { "pc" }, "computer", "This computer can do a lot of things!");
            p.Inventory.Put(_shovel);
            p.Inventory.Put(_pc);

            // Create bag and add to inventory
            Bag _b1 = new Bag(new string[] { "lbag", "lpouch" }, "large pouch", "This is a large pouch.");
            p.Inventory.Put(_b1);

            // Create item and add to bag
            Item _sword = new Item(new string[] { "sword" }, "sword", "This is a fine looking sword.");
            _b1.Inventory.Put(_sword);

            Console.WriteLine("Lets test some look commands! Write a look command. Remember that they have to start with the word look!");
            Console.WriteLine("Type in finish if you want to stop looking.");

            Look_Command look = new Look_Command(new string[] { "look" });
            bool lookloop = true;

            while (lookloop == true)
            {
                string lookCommand = Console.ReadLine();

                if (lookCommand.ToLower() == "finish")
                {
                    lookloop = false;
                }
                string[] commandWords = lookCommand.Split(' ');
                Console.WriteLine(look.Execute(p, commandWords));

                Console.WriteLine("If you want to stop, type 'Finish'. If you want to keep testing, keep typing in commands!");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
