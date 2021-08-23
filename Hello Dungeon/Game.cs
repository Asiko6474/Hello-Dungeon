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
            bool finalDecision = false;
            int health;
            bool validinput = false;
            bool dummyChoice = false;
            bool Dead = false;
            bool faction1Favor = true;
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
            void MakeTextDarkRed()
            {
                Console.ForegroundColor
                = ConsoleColor.DarkRed;
            }
            void MakeTextRed()
            {
                Console.ForegroundColor
                = ConsoleColor.Red;
            }
            void MakeTextDarkBlue()
            {
                Console.ForegroundColor
                    = ConsoleColor.DarkBlue;
            }
            void MakeTextBlue()
            {
                Console.ForegroundColor
                    = ConsoleColor.Blue;
            }
            // function to show off stats

            void DisplayStats()
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Class: " + characterJob);
                Console.WriteLine("health: " + health);
                Console.WriteLine("Strength: " + strength);
            }
            /// <summary>
            /// Rewrties the Dummy loop if the wrong answer was given
            /// </summary>
            void Displaydummy()
            {
                Console.WriteLine("You see a training dummy infront of you. It is staring at you...menacingly!");
                Console.WriteLine("1. Attack it!");
                Console.WriteLine("1. Say Hi!");
                Console.Write(">");
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
            while (dummyChoice == false)
            {
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("The dummy falls over before bouncing back. The man nods at your strike");
                    dummyChoice = true;
                }
                else if (choice == "2")
                {
                    Console.WriteLine("The man sighs at you, dissapointed in your inability to fight.");
                    dummyChoice = true;
                }
                else
                {
                    Console.WriteLine("invalid input");
                    Console.ReadKey();
                    Console.Clear();
                    Displaydummy();
                }
            }
            Console.WriteLine();

            // This is entirely story on entering the dungeon.

            Console.WriteLine("Looking around you, you see several others running around, quickly gearing up, confused, you look at the man and as him what is going on.");
            Console.ReadLine();

            MakeTextYellow();

            Console.WriteLine("'It looks like you joined at the right time, we are getting ready to enter a dungeon.'");
            Console.WriteLine("'As you know, there exists creatures out there that eat people like us, no matter if you are human, elven, or dwarf.'");
            Console.WriteLine("'This is where we come in, we are a private army dedicated to hunting these creatures for everyone's safety.'");
            Console.ReadLine();

            MakeTextWhite();

            Console.WriteLine("Eager to join in, you ask where you can find your equipment, he sits in silence for a moment to think it over.");
            Console.WriteLine("He ends up walking off and comes back handing you your equipment personally.");
            Console.WriteLine("He points to the rest of the soldiers marching, and you start to follow them.");
            Console.WriteLine("After some time of marching the soldiers stop at a door, and on the door there is a riddle.");
            Console.ReadLine();

            MakeTextYellow();

            Console.WriteLine("This here lies a dungeon, these dungeons are home to these creatures, their sanctuary.");
            Console.WriteLine("Usually, dungeons require physical keys, but this one is locked with a riddle.");
            Console.WriteLine("Considering you are the new recruit, you can go ahead and try solving the riddle.");
            Console.WriteLine("Don't worry, nothing will happen to you if you can't solve them.");
            Console.ReadLine();

            MakeTextWhite();

            Console.WriteLine("You eagerly head to the door, looking at the riddle.");
            Console.ReadLine();
            Console.Clear();

            // This section is the riddle door, remember, the answer is darkness!
            int attempts = 3;
            string answer;
            for (int i = 0; i <= attempts; i++)
            {
                Console.WriteLine("The more there is of me, the less you see, what am I?");
                answer = Console.ReadLine();
                int attemptsRemaining = attempts - i;
                if (answer == "darkness" || answer == "Darkness" || answer == "dARKNESS" || answer == "DARKNESS")
                {
                    Console.WriteLine("The door swings open, you seem to have gotten the right answer.");
                    Console.ReadLine();

                    MakeTextYellow();

                    Console.WriteLine("Well well well, looks like you got it.");
                    break;
                }
                else
                {
                    Console.WriteLine("That did not seem to be the answer.");
                    Console.WriteLine("Attempts Remaining: " + attemptsRemaining);
                }
                if (attemptsRemaining == 0)
                {

                    MakeTextYellow();

                    Console.WriteLine("'The answer is darkness.'");
                    Console.WriteLine("Really the answer could be anything, but this is a riddle I seen before.");
                    Console.WriteLine("Don't beat yourself up over this");
                }
                else
                {
                    
                }
            }
            Console.ReadLine();
            Console.Clear();
            // Going back to the story, this time what happens when you enter the dungeon

            MakeTextWhite();

            Console.WriteLine("The army enters the dungeon, the walls and floors seem to be made out of marble.");
            Console.WriteLine("There is a torch once every few feet, each one is lit.");
            Console.WriteLine("As you look ahead you see a throne, however it is empty.");
            Console.ReadLine();

            MakeTextYellow();

            Console.WriteLine("Men, keep a look out, this one can be anywhere.");
            Console.WriteLine("Look above, on the walls, keep checking behind your back and your ears open.");
            Console.WriteLine("Always remember that these creatures are capable of anything, only if you give them the advantage.");
            Console.ReadLine();

            MakeTextDarkRed();

            Console.WriteLine("My My, all these men just for me?");
            Console.WriteLine("This is truely getting pathetic you know.");
            Console.WriteLine("This doesn't even begin to make it a fair fight...");
            Console.ReadLine();

            MakeTextWhite();

            // Final practice with (for)
            Console.WriteLine("You see a figure flying directly at you, 4 options quickly race to your mind");
            Console.WriteLine("1. Sit and wait for someone to help you,");
            Console.WriteLine("2. Hold out your weapon trying to get the figure to run into the weapon,");
            Console.WriteLine("3. Swing at the figure trying to hit it like a baseball");
            Console.WriteLine("4. Dodge");
            void LethalEncounter()
            { 
              string answers;
                for (int i = 0; i <= attempts; i++)
                {
                    answers = Console.ReadLine();
                    int attemptsRemaining = attempts - i;

                    if (answers == "4")
                    {
                        Console.WriteLine("You dodge the figure and during that moment and arrow is fired above you, hitting the figure causing it to crash down.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No wait, that can't work...");
                        Console.WriteLine("Moments Remaining: " + attemptsRemaining);
                    }
                    if (attemptsRemaining == 0)
                    {
                        Dead = true;
                    }
                    else
                    {

                    }
                }
            }
            LethalEncounter();
            if (Dead == true)
            {
                Console.WriteLine("The figure flies past you, thinking you are safe you try to take a moment to breath, only for your head to fall off...");
                Console.WriteLine("You Died...press 1 to Try again, Press any other button to exit");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    LethalEncounter();
                }
                else
                {
                    Console.WriteLine("goodbye quitter!");
                    Console.ReadLine();
                }
            }
            //If the player manages to survive, we will move to the last encounter here

            MakeTextDarkBlue();
            Console.WriteLine("W-we got it! we got the monster!");

            MakeTextWhite();

            Console.WriteLine("Every solder starts to crowd the creature, you follow and start to look at it.");
            Console.WriteLine("You are shocked to see that the creature resembled a girl, seemingly to be in her mid 20s.");
            Console.WriteLine("Her eyes are red, surrounded with black instead of white, her hair is a white stained with blood.");
            Console.WriteLine("You see that her leg was struck by the arrow, she is kneeling down looking up at the crowd.");
            Console.WriteLine("You see tears in her eyes, her face is red with rage.");
            Console.ReadLine();

            MakeTextDarkRed();

            Console.WriteLine("You guys think you are heroes...");
            Console.WriteLine("Hunting us...one by one...");
            Console.WriteLine("And for what reason? We eat your dead?");
            Console.WriteLine("It is not our fault we are like this...but you...you never see it like that.");
            Console.ReadLine();

            MakeTextYellow();

            Console.WriteLine("Silence...there is no excuse for you kind.");
            Console.WriteLine("Your kind is the humanoid mosquitoe, but at least mosquitoes know their place.");
            Console.WriteLine("If anything, you should be thanking us for putting your kind out of their misery.");
            Console.WriteLine(name + "! Go ahead, make her your first kill.");
            Console.ReadLine();

            MakeTextWhite();

            Console.WriteLine("The crowd pushes you in front of her, she looks directly up at you.");
            Console.WriteLine("You want to kill her, she would kill your if you did not...but...do you really want to?");
            Console.WriteLine("Would kiling her make you any better of a person?");
            Console.WriteLine("No no no, she is a monster, she eats your kind, she has too...just like you have to kill her.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Should I kill her?");
            Console.WriteLine("1. Yes, monster deserve to die.");
            Console.WriteLine("2. No, I don't want to become a monster.");
            while (finalDecision == false)
            {
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("You raise your weapon, but as you swing down to her she grabs you by the wrist.");
                    Console.WriteLine("She pushes you away, looking back at her shows she had wings pushed out her back, demonic looking wings.");
                    Console.WriteLine("She flies out of the room through the entrance you came in from.");
                    Console.ReadLine();

                    MakeTextYellow();

                    Console.WriteLine("That was Victoria, the queen of these beasts...");
                    Console.WriteLine("Don't beat yourself up for not being able to kill her, no one was able to kill her yet");
                    Console.WriteLine("But you managed to survive your encounter, you are now one of us!");
                    Console.WriteLine("Tell your new brothers your name! Loud and Proud!");
                    Console.ReadLine();

                    MakeTextBlue();

                    Console.Clear();
                    Console.WriteLine(name);
                }
                if (choice == "2")
                {
                    faction1Favor = false;
                    faction2Favor = true;
                    Console.WriteLine("You drop your weapon, you just can't bring yourself to kill her.");

                    MakeTextYellow();

                    Console.WriteLine("YOU TRAITOR!");

                    MakeTextWhite();

                    Console.WriteLine("The man swings his weapon before the girl grabs his wrist, pushing him back.");
                    Console.WriteLine("She stares at you, wraping an arm around you and demonic wings are pushed out her back.");
                    Console.WriteLine("With you in her arms, she flies out the way you came in, away from everyone.");
                    Console.ReadLine();

                    MakeTextDarkRed();

                    Console.WriteLine("I...");
                    Console.WriteLine("You will be hunted along with me from that choice you made...");
                    Console.WriteLine("Foolish to make the right choice.");
                    Console.WriteLine("My name is Victoria, please, tell me yours.");
                    Console.ReadLine();

                    MakeTextRed();

                    Console.Clear();
                    Console.WriteLine(name);
                }
            }
        }
    }
}
