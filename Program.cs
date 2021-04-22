using System;
using JurasicPark.Models;
using System.Linq;
using System.Collections.Generic;

namespace JurasicPark
{
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        public DateTime WhenAcquired { get; set; } = DateTime.Now;

        public string Description()
        {
            var newDescription = ($"The dinosaur's name is {Name}. Their diet type is {DietType} and their weight is {Weight} pounds. They were acquired {WhenAcquired}. You can find this dino in enclosure number {EnclosureNumber}.");

            return newDescription;
        }
    }
    class DinosaurDatabase
    {
        //not sure what goes here
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dinosaurs = new List<Dinosaur>()
             {
                 new Dinosaur(){Name = "Swulf", DietType = "carnivore", Weight = 65000, EnclosureNumber = 42},
                 new Dinosaur(){Name = "Yarbo", DietType = "herbivore", Weight = 48000, EnclosureNumber = 32},
                 new Dinosaur(){Name = "Dina", DietType = "herbivore", Weight = 72000, EnclosureNumber = 22},
                 new Dinosaur(){Name = "Felix", DietType = "carnivore", Weight = 95000, EnclosureNumber = 52},

             };

            var database = new DinosaurDatabase();

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("Do you want to View, Summarize, Add, Remove, Transfer, or Quit? ");
                var choice = Console.ReadLine().ToLower();

                //QUIT - this will stop the program
                if (choice == "quit")
                {
                    keepGoing = false;
                }
                //SUMMARIZE - this will display the number of carnivores and the number of herbivores
                else if (choice == "summarize")
                {
                    var foundHerb = dinosaurs.Count(dinosaur => dinosaur.DietType == "herbivore");
                    var foundCarn = dinosaurs.Count(dinosaur => dinosaur.DietType == "carnivore");

                    Console.WriteLine($"There are {foundCarn} carnivores and {foundHerb} herbivores in the dino zoo.");
                }
                //VIEW - show all the dinosaurs in the list, ordered by WhenAcquired. *not sure how to do this*
                // if there aren't any dinosaurs in the park then print out a message that there aren't any.
                else if (choice == "view")
                {
                    Console.WriteLine("The dinos in the zoo:");

                    var sorted = dinosaurs.OrderBy(dinosaur => dinosaur.WhenAcquired);

                    foreach (var dinosaur in dinosaurs)
                    {
                        Console.WriteLine(dinosaur.Name);
                    }

                }
                //ADD - This command will let the user type in the information for a dinosaur and add it to the list. 
                // Prompt for the Name, Diet Type, Weight and Enclosure Number, but the WhenAcquired must be supplied by the code.
                else if (choice == "add")
                {
                    var newDino = new Dinosaur();

                    Console.WriteLine("Please enter the dino's name: ");
                    newDino.Name = Console.ReadLine();
                    Console.WriteLine("Please enter the dino's diet, either herbivore or carnivore: ");
                    newDino.DietType = Console.ReadLine();
                    Console.WriteLine("Please enter the dino's weight: ");
                    newDino.Weight = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the dino's enclosure number: ");
                    newDino.EnclosureNumber = int.Parse(Console.ReadLine());

                    dinosaurs.Add(newDino);

                    Console.WriteLine($"You have added {newDino.Name} to the database.");

                }
                //REMOVE - will prompt the user for a dinosaur name then find and delete the dinosaur with that name.
                else if (choice == "remove")
                {
                    Console.WriteLine("Which dino do you want to delete?");
                    var removeName = Console.ReadLine();

                    Dinosaur removedDino = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == removeName);

                    dinosaurs.Remove(removedDino);

                    Console.WriteLine($"You have deleted {removeName} from the database.");
                }
                // TRANSFER will prompt the user for a dinosaur name and a new EnclosureNumber and update that dino's information.
                else
                {

                    Console.WriteLine("Which dino do you want to update? ");

                    var dinoToUpdate = Console.ReadLine();

                    Dinosaur dinoUpdate = dinosaurs.First(dinosaur => dinosaur.Name == dinoToUpdate);

                    Console.WriteLine("What is their new enclosure number?");

                    var newNumber = int.Parse(Console.ReadLine());

                    dinoUpdate.EnclosureNumber = newNumber;

                    Console.WriteLine("Thank you for updating the database.");


                }
            }



        }
    }
}
