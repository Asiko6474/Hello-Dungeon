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

        private Item _greatsword;
        private Item _shortsword;
        private Item _obtainiumArmor;
        private Item _ironArmor;
        private Item _medKit;
        int _currentEnemyIndex;
        bool _gameOver;
        private Entity[] _enemies;
        string _playerName;
        private Player _player;
        string _class;
        private Entity _currentEnemy;
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

        public void initilizeEnemies()
        {
            _currentEnemyIndex = 0;

            Entity Lamia = new Entity("Lamia", 20, 40, 10);
            Entity Centaur = new Entity("Centaur", 50, 40, 20);
            Entity Human = new Entity("Human", 75, 50, 50);

            Entity Zombie = new Entity("Zombie", 25, 100, 30);
            Entity Demoness = new Entity("Demoness", 75, 75, 0);
            Entity Victoria = new Entity("???", 125, 65, 30);

            _enemies = new Entity[] { Lamia, Centaur, Human, Zombie, Demoness, Victoria };

            _currentEnemy = _enemies[_currentEnemyIndex];
        }

        public void DisplayEquipItemMenu()
        {
            //Get item index
            int choice = GetInput("Select an item to equip.", _player.GetItemNames());

            //Equip item at given index
            if (!_player.TryEquipItem(choice))
                Console.WriteLine("You couldn't find that item in your bag.");

            //Print feedback
            Console.WriteLine("You equipped " + _player.CurrentItem.Name + "!");
        }

        public void Battle()
        {
            float damageDealt = 0;

            DisplayStats(_player);
            DisplayStats(_currentEnemy);

            if (_currentEnemyIndex == 3)
            {
                _currentScene++;
            }

            int choice = GetInput("You see a " + _currentEnemy.Name + ". What will you do?", "Fight", "Equip Item", "Remove current item", "punch self");
            if (choice == 0)
            {
                damageDealt = _player.Attack(_currentEnemy);
                Console.WriteLine("You dealt " + damageDealt + " damage!");
            }
            else if (choice == 1)
            {
                DisplayEquipItemMenu();
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            else if (choice == 2)
            {
                if (!_player.TryRemoveCurrentItem())
                    Console.WriteLine("You only have your fists, you can't unequip them.");
                else
                    Console.WriteLine("You put away the item.");

                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            else if (choice == 3)
            {
                Console.WriteLine("Why are your hitting yourself?");
            }


            damageDealt = _currentEnemy.Attack(_player);
            Console.WriteLine("The " + _currentEnemy.Name + " dealt " + damageDealt, " damage!");

            Console.ReadKey(true);
            Console.Clear();
        }

        void CheckBattleResults()
        {
            if (_player.Health <= 0)
            {
                Console.WriteLine("You were slain...");
                Console.ReadKey(true);
                Console.Clear();
            }
            else if (_currentEnemy.Health <= 0)
            {
                Console.WriteLine("You slayed the " + _currentEnemy.Name);
                Console.ReadKey();
                Console.Clear();
                _currentEnemyIndex++;

                if (_currentEnemyIndex >= _enemies.Length)
                {
                    Console.WriteLine("You've slain all the enemies! You are a true warrior.");
                    return;
                }

                _currentEnemy = _enemies[_currentEnemyIndex];
            }
        }

            private void InitItems()
        {
            _greatsword.Name = "Great Sword";
            _greatsword.cost = 1000;
            _shortsword.Name = "Short Sword";
            _shortsword.cost = 500;
            _obtainiumArmor.Name = "Legendary Obtainium Armor!!!!";
            _obtainiumArmor.cost = 180000;
            _ironArmor.Name = "Iron Armour";
            _ironArmor.cost = 200;
            _medKit.Name = "Medical Kit";
            _medKit.cost = 400;
        }

        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ", " + inventory[i].Name + inventory[i].cost);
            }
        }



        //This is to select the player's class in the game
        void CharacterClassSelection()
        {
            int choice = GetInput("OH! A new one! Just select your class here and I wil get you the appropiate gear", "Scout ( 50 health, 125 attack, 50 defense) ",
                "Man-At-Arms (75 health, 75 attack, 75 defense) ",
                "Heavy (75 health, 50 attack, 100 defense) ");

            //This is to turn into a scout which make the player's stats 50 health, 125 attack, 50 defense. The class name will be stated afterwards followed by 200 gold
            if (choice == 0)
            {
                _player = new Player(_playerName, 50, 125, 50, "scout", 200);
                _currentScene++;
            }
            //this is to turn into a Man-At-Arms which make the player's stats 75 for health, attack, and defense. The class name will be stated afterwards followed by 200 gold
            if (choice == 1)
            {
                _player = new Player(_playerName, 75, 75, 75, "Man-At-Arms", 200);
                _currentScene++;
            }
            //This is the turn into a Heavy, which make the player's stats 75 health, 50 attack, 100 defense. The class name will be stated afterwards followed by 200 gold
            if (choice == 2)
            {
                _player = new Player(_playerName, 75, 50, 100, "Heavy", 200);
                _currentScene++;
            }
        }

        void DisplayStats(Entity character)
        {
            Console.WriteLine("Name: " + character.Name);
            Console.WriteLine("Health: " + character.Health);
            Console.WriteLine("Attack: " + character.AttackLevel);
            Console.WriteLine("Defense: " + character.DefenseLevel);
            Console.WriteLine();
        }


        //This function will keep playing the game in the appropiate order.
        void DisplayCurrentScene()
        {
           
        }


        void FightingRoom1()
        {

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
