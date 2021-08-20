using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Dungeon
{
    class Game
    {
        public void Run()
        {
            //This was important note
            //!A && !B
            //!(A || B)
            //!(imputReceived == 1 || inputReceived == 2)
            // yeaah
            string name = "";
            string characterJob;
            int health;
            bool validinput = false;
            bool Dead = false;
            bool faction1Favor = false;
            bool faction2Favor = false;
            float strength = 5;

            // This section is for my color changing functions

            void MakeTextYellow()
            {
                Console.ForegroundColor
                = ConsoleColor.Yellow;
            }
            void MakeTextWhite()
            {
                Console.ForegroundColor
                = ConsoleColor.White;
            }
            // function to show off stats

            void DisplayStats()
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Class: " + characterJob);
                Console.WriteLine("health: " + health);
                Console.WriteLine("Strength: " + strength);
            }

            // All that this is is the intro message, don't expect it to be good, I really did not think much about it. (yet)

            //I keep using the "WriteLine" command to space out the sentences and the "ReadLine" command to move the story forward when an input is made, this way the player can read at their own pace and not get bombarded by words.
            Console.WriteLine("There is a man infront of you, shrouded in mostly darkness, speaking in a deep vice..");

            MakeTextYellow();

            Console.ReadLine();
            Console.WriteLine("'So are you the new guy that was supposed to be coming in today?'");
            Console.ReadLine();

            MakeTextWhite();

            Console.WriteLine("You nod hesitantly, he pulls a book infront of you and gives you a pen.");
            Console.ReadLine();

            MakeTextYellow();

            Console.WriteLine("'Write down your information and head to the training grounds.'");
            Console.WriteLine("");

            MakeTextWhite();

            Console.WriteLine("Write your name:");
            Console.Write("> ");
            name = Console.ReadLine();
            Console.WriteLine("");

            MakeTextYellow();

            Console.WriteLine("'So you're " + name + "...Very well, the training ground is in the back'");
            Console.ReadLine();

            MakeTextWhite();

            Console.WriteLine("The man guides you to the back, you see a number of soldiers in a line, they seem to be waiting your arrival");
            Console.ReadLine();

            MakeTextYellow();

            Console.WriteLine("'These men will be your family from now on, in our situation, we are all we have now.'");
            Console.ReadLine();
            Console.WriteLine("'There is a training dummy over there, go on and head to it.'");
            Console.ReadLine();

            MakeTextWhite();

            Console.WriteLine("Before you walk over to the dummy the man grabs you by the shoulder. 'Before you do, we need to discuss your class.'");

            // This is where I am going to program the moose.

            // IF I CAN FIND ONE!


            // This is the class section
            Console.WriteLine("What class are you?");
            Console.WriteLine("1. Bard");
            Console.WriteLine("2. Mage");
            while (validinput == false)
            {
                string input = Console.ReadLine();
                if (input == "1" || input == "Bard")
                {
                    characterJob = "Bard";
                    health = 100;
                    strength = 10;
                    validinput = true; 
                    Console.WriteLine("Ah so you are a Bard.");
                    Console.WriteLine("");
                    DisplayStats();
                }
                else if (input == "2" || input == "Mage")
                {
                    characterJob = "Mage";
                    health = 75;
                    strength = 5;
                    validinput = true;
                    Console.WriteLine("Ah so you are a Mage");
                    Console.WriteLine("");
                    DisplayStats();
                }
                else if (input == "-1")
                {
                    characterJob = "Pessimist";
                    health = 10;
                    strength = 3;
                    validinput = true;
                    Console.WriteLine("Ah so you are a Pessimist");
                    Console.WriteLine("");
                    DisplayStats();
                }
                else
                {
                    Console.WriteLine("That is not a class option");
                }
            }

            Console.WriteLine("Alright then, NOW head to the training dummy for practice");
            Console.ReadLine();
            Console.Clear();

            //This is the first encounter in the game thus far.
            Console.WriteLine("");
            Console.WriteLine("You see a training dummy infront of you. It is staring at you...menacingly!");
            Console.WriteLine("1. Attack it!");
            Console.WriteLine("1. Say Hi!");
            Console.Write(">");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("You punched the dummy, it pulls out a gun and shoots you...you die");
            }
            else if (choice == "2")
            {
                Console.WriteLine("The Dummy smiles at you and pulls out a cake, you both enjoy cake.");
            }
            else
            {
                Console.WriteLine("invalid input");
            }
            Console.Clear();

            // this is just a section of me practicing (for) code
            int attempts = 3;
            string answer;
            for (int i = 0; i < attempts; i++)
            {
                Console.WriteLine("The more there is of me, the less you see, what am I?");
                answer = Console.ReadLine();
                int attemptsRemaining = attempts - i;
             if (answer == "darkness")
                {
                    Console.WriteLine("Correct!");
                    break;
                }
                else
                {
                    Console.WriteLine("wrong, try again!");
                    Console.WriteLine("Attempts Remaining: " + attemptsRemaining);
                }
            }
            Console.Clear();
            // Final practice with (for)
            Console.WriteLine("The Dummy had 4 arms, only one arm is the key to the candy. Which arm do you pull?");
            Console.WriteLine("1. pink one? " +
                "2. blue one? " +
                "3. green one? " +
                "4 red one");
            string answers;
            for (int i = 0; i < attempts; i++)
            {
                answers = Console.ReadLine();
                int attemptsRemaining = attempts - i;
                
                if (answers == "4")
                {
                    Console.WriteLine("Correct!");
                    break;
                }
                else
                {
                    Console.WriteLine("wrong, try again!");
                    Console.WriteLine("Attempts Remaining: " + attemptsRemaining);
                }
            }
        }
    }
}
