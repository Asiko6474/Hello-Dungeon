using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Dungeon
{
    class Game
    {
        public void Run()
        {
            string name = "";
            int health;
            bool Dead = false;
            bool faction1Favor = false;
            bool faction2Favor = false;
            float Strength = 5;
            // All that this is is the intro message, don't expect it to be good, I really did not think much about it. (yet)

            //I keep using the "WriteLine" command to space out the sentences and the "ReadLine" command to move the story forward when an input is made, this way the player can read at their own pace and not get bombarded by words.
            Console.WriteLine("The land of Amidonia was a place that was destroyed by war.");
            Console.ReadLine();
            Console.WriteLine("2 factions have been at a stalemate for many years, both with waning supplies at a rapid rate.");
            Console.ReadLine();
            Console.WriteLine("This is where you come in, a traveler who was trapped in Amidonia, unable to leave due to both factions trying to limit any and all movement");
            Console.ReadLine();
            Console.WriteLine("Please, speak your name, speak and see if your name will be known through the lands. There is no reason for your journy if none know your name");
            Console.WriteLine("");
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Ah..." + name + "...Your name is in my memory, but go out and let your name be known to all of Amidonia");
            Console.ReadLine();
            Console.WriteLine("No matter what your goal is, no matter which of the two factions you support. I will be here for you");
            Console.ReadLine();
            Console.WriteLine("However because you told me your name, It is only right I tell you mine.");
            Console.ReadLine();
            Console.WriteLine("My name is....");
            Console.ReadLine();
            Console.WriteLine("Not Important!");
            
            // This is where I am going to program the moose.

            // IF I CAN FIND ONE!
        }
    }
}
