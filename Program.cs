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
            return ($"The dinosaur's name is {Name}. Their diet type is {DietType} and their weight is {Weight} pounds. They were acquired {WhenAcquired}. You can find this dino in enclosure number {EnclosureNumber}.");
        }
    }
    // class DinosaurDatabase
    // {
    //     //not sure what goes here
    // }
    class Program
    {
        static void WelcomeMessage()
        {
            Console.WriteLine(new string('*', 26));
            Console.WriteLine("The Jurassic Park Database");
            Console.WriteLine(new string('*', 26));
        }
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userStringInput = Console.ReadLine();
            return userStringInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userIntInput = int.Parse(Console.ReadLine());
            return userIntInput;
        }
        static void Main(string[] args)
        {

            WelcomeMessage();

            //Make a list of Dinosaurs-
            var dinosaurs = new List<Dinosaur>()
             {   //not sure if I was supposed to do this part or not:
                 new Dinosaur(){Name = "Swulf", DietType = "carnivore", Weight = 65000, EnclosureNumber = 42},
                 new Dinosaur(){Name = "Yarbo", DietType = "herbivore", Weight = 48000, EnclosureNumber = 32},
                 new Dinosaur(){Name = "Dina", DietType = "herbivore", Weight = 72000, EnclosureNumber = 22},
                 new Dinosaur(){Name = "Felix", DietType = "carnivore", Weight = 95000, EnclosureNumber = 52},

             };

            // var database = new DinosaurDatabase();

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
                //VIEW - show all the dinosaurs in the list, ordered by WhenAcquired
                // if there aren't any dinosaurs in the park then print out a message that there aren't any.
                else if (choice == "view")
                {
                    Console.WriteLine("The dinos in the zoo, sorted by when they were acquired:");

                    var sorted = dinosaurs.OrderBy(dinosaur => dinosaur.WhenAcquired);

                    foreach (var dinosaur in dinosaurs)
                    {
                        Console.WriteLine(dinosaur.Name);
                        Console.WriteLine(dinosaur.WhenAcquired);
                    }

                }
                //ADD - This command will let the user type in the information for a dinosaur and add it to the list. 
                // Prompt for the Name, Diet Type, Weight and Enclosure Number, but the WhenAcquired must be supplied by the code.
                else if (choice == "add")
                {
                    var newDino = new Dinosaur();

                    newDino.Name = PromptForString("Please enter the dino's name: ");
                    newDino.DietType = PromptForString("Please enter the dino's diet type, either carnivore or herbivore: ");
                    newDino.Weight = PromptForInteger("Please enter the dino's weight in pounds: ");
                    newDino.EnclosureNumber = PromptForInteger("Please enter the dino's enclosure number: ");

                    dinosaurs.Add(newDino);

                    Console.WriteLine($"You have added {newDino.Name} to the database.");

                }
                //REMOVE - will prompt the user for a dinosaur name then find and delete the dinosaur with that name.
                else if (choice == "remove")
                {
                    Console.WriteLine("Which dino do you want to delete?");
                    var removeName = Console.ReadLine().ToUpper();

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
