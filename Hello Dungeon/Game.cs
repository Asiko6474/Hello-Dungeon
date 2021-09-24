using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Dungeon
{
    public enum Scene
    {
        INTRODUCTION
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

        void GetPlayerName()
        {
            Console.WriteLine("Placeholder name entry");
            Console.Write("> ");
            _playerName = Console.ReadLine();
            Console.WriteLine("Your name is: " + _playerName);
        }

        void CharacterClassSelection()
        {
            int choice = GetInput("OH! A new one! Just select your class here and I wil get you the appropiate gear", "Scout","Man-At-Arms","Heavy");

            if (choice == 0)
            {
                _class = "Scout";
            }

            if (choice == 1)
            {
                _class = "Man-At-Arms";
            }

            if (choice == 2)
            {
                _class = "Man-At-Arms";
            }
        }

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

        void MainMenu()
        {

        }

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
