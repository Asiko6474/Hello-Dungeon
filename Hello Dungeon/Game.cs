using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Dungeon
{
    public enum Scene
    {
        INTRODUCTION,
        SHOP,
        ROOMONE,
        ROOMTWO,
        ROOMTHREE
    }

    public enum ItemType
    {
        DEFENSE,
        ATTACK,
        HEALTH,
        NONE
    }

    public struct Item
    {
        public string Name;
        public float StatBoost;
        public ItemType Type;
        public int cost;
    }
    class Game
    {
        bool _gameOver;
        string _playerName;
        string _class;
        Scene _currentScene;
        
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


            // this function is to get the plyer's name.
        void GetPlayerName()
        {
            //Starting with a simple introduction sentence
            Console.WriteLine("Placeholder name entry");
            Console.Write("> ");
            //This is how the player can put in the name
            _playerName = Console.ReadLine();
            //This is to test to see if the naming works
            Console.WriteLine("Your name is: " + _playerName);
        }

        //This is to select the player's class in the game
        void CharacterClassSelection()
        {
            int choice = GetInput("OH! A new one! Just select your class here and I wil get you the appropiate gear", "Scout","Man-At-Arms","Heavy");

            //This is to turn into a scout which make the player's stats 50 health, 125 attack, 50 defense.
            if (choice == 0)
            {
                _class = "Scout";
            }
            //this is to turn into a Man-At-Arms which make the player's stats 75 for health, attack, and defense.
            if (choice == 1)
            {
                _class = "Man-At-Arms";
            }
            //This is the turn into a Heavy, which make the player's stats 75 health, 50 attack, 100 defense.
            if (choice == 2)
            {
                _class = "Heavy";
            }
        }


        //This function will keep playing the game in the appropiate order.
        void DisplayCurrentScene()
        {
            switch(_currentScene)
            {
                case Scene.INTRODUCTION:
                    GetPlayerName();
                    CharacterClassSelection();
                    break;
            }
        }


        //This will be the first thing in the game that gives the player to start a new game, or to load a game
        void MainMenu()
        {

        }
        //This function allows the player to put in options
        int GetInput(string description, params string[] options)
        {
            string input = "";
            int inputReceived = -1;

            while (inputReceived == -1)
            {
                Console.WriteLine(description);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                Console.Write("> ");
                input = Console.ReadLine();

                if (int.TryParse(input, out inputReceived))
                {
                    inputReceived--;
                    if (inputReceived < 0 || inputReceived >= options.Length)
                    {
                        inputReceived = -1;
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                }
                else
                {

                    inputReceived = -1;
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey(true);
                }
                Console.Clear();
            }
            return inputReceived;
        }

        public void Run()
        {
            
        }
    }
}
