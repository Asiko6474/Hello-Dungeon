using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hello_Dungeon
{
    public enum Scene
    {
        INTRODUCTION,
        ROOMONE,
        ROOMTWO,
        ROOMTHREE,
        RESTARTMENU
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
        private Item[] _shopInventory;
        private Item _greatsword;
        private Item _shortsword;
        private Item _obtainiumArmor;
        private Item _ironArmor;
        private Item _medKit;
        private Shop _shop;
        int _currentEnemyIndex;
        bool _gameOver;
        private Entity[] _enemies;
        string _playerName;
        private Player _player;
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
        //sets up the game's starting conditions
        public void Start()
        {
            _gameOver = false;
            _currentScene = 0;
            initilizeEnemies();
            InitItems();
            _shopInventory = new Item[] { _greatsword, _shortsword, _obtainiumArmor, _ironArmor, _medKit };
            _shop = new Shop(_shopInventory);
            //Gives the player a choice to start a new game or to load an old one
            int choice = GetInput("Do you want to start a new game or load an old one?");
            if (choice == 1)
            {
                Console.WriteLine("Starting new game");
                Console.ReadKey(true);
                Console.Clear();
            }
            if (choice == 2)
            {
                Load();
            }
        }
        // The function that allows to main gameplay loop to actually be a loop
        void Update()
        {
            DisplayCurrentScene();
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
            Entity Human = new Entity("Human", 100, 25, 50);

            Entity Zombie = new Entity("Zombie", 25, 50, 30);
            Entity Demoness = new Entity("Demoness", 75, 75, 0);
            Entity Victoria = new Entity("???", 125, 60, 20);

            _enemies = new Entity[] { Lamia, Centaur, Human, Zombie, Demoness, Victoria };

            _currentEnemy = _enemies[_currentEnemyIndex];
        }
        //Shows what items the player can equip
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
        //starts a battle with a set of enemies
        public void Battle()
        {
            float damageDealt = 0;
            //displays each enemy's stats before each turn
            DisplayStats(_player);
            DisplayStats(_currentEnemy);
            //gives the palyer a choice of what they can do during each turn 
            int choice = GetInput("You see a " + _currentEnemy.Name + ". What will you do?", "Fight", "Equip Item", "Remove current item", "punch self", "Save");

            //Attacks the enemy
            if (choice == 0)
            {
                damageDealt = _player.Attack(_currentEnemy);
                Console.WriteLine("You dealt " + damageDealt + " damage!");
            }
            //equips an item
            else if (choice == 1)
            {
                DisplayEquipItemMenu();
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            //remove and equiped item
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
            //the player can hit themself
            else if (choice == 3)
            {
                Console.WriteLine("Why are your hitting yourself?");
            }
            //saves the game
            else if (choice == 4)
            {
                Save();
                Console.WriteLine("You saved the game");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            //the enemy attacks the player
            damageDealt = _currentEnemy.Attack(_player);
            Console.WriteLine("The " + _currentEnemy.Name + " dealt " + damageDealt, " damage!");

            Console.ReadKey(true);
            Console.Clear();
        }
        //checks to see if the fight is over
        void CheckBattleResults()
        {
            //if the player dies
            if (_player.Health <= 0)
            {
                Console.WriteLine("You were slain...");
                Console.ReadKey(true);
                Console.Clear();
                RestartMenu();
            }
            // if the enemy dies
            else if (_currentEnemy.Health <= 0)
            {
                Console.WriteLine("You slayed the " + _currentEnemy.Name);
                Console.ReadKey();
                Console.Clear();
                _currentEnemyIndex++;

                //if all enemies are dead
                if (_currentEnemyIndex >= _enemies.Length)
                {
                    Console.WriteLine("All the enemies are now dead.");
                    _currentScene++;
                    return;
                }

                _currentEnemy = _enemies[_currentEnemyIndex];
            }
        }

        //initializes the items for use
        private void InitItems()
        {
            _greatsword = new Item { Name = "Great Sword ", StatBoost = 50, Type = ItemType.ATTACK };
            _greatsword.cost = 1000;
            _shortsword = new Item { Name = "Short Sword ", StatBoost = 25, Type = ItemType.ATTACK };
            _shortsword.cost = 500;
            _obtainiumArmor = new Item { Name = "The Legendary Obtainium Armor!!! ", StatBoost = 100, Type = ItemType.DEFENSE };
            _obtainiumArmor.cost = 180000;
            _ironArmor = new Item { Name = "Iron Armor ", StatBoost = 25, Type = ItemType.DEFENSE };
            _ironArmor.cost = 200;
            _medKit = new Item { Name = "Medical Equipment  ", StatBoost = 50, Type = ItemType.HEALTH };
            _medKit.cost = 400;
        }
        //prints an inventory for the player to see
        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].Name + "$" + inventory[i].cost);
            }
        }
       
        //This is to select the player's class in the game
        void CharacterClassSelection()
        {
            int choice = GetInput("OH! A new one! Just select your class here and I wil get you the appropiate gear", "Scout ( 50 health, 125 attack, 50 defense) ",
                "Man-At-Arms (75 health, 75 attack, 75 defense) ",
                "Heavy (75 health, 50 attack, 100 defense) ");

            //This is to turn into a scout which make the player's stats 50 health, 125 attack, 50 defense. The class name will be stated afterwards followed by 1000 gold
            if (choice == 0)
            {
                _player = new Player(_playerName, 50, 125, 50, "scout", 1000);
                _currentScene++;
            }
            //this is to turn into a Man-At-Arms which make the player's stats 75 for health, attack, and defense. The class name will be stated afterwards followed by 1000 gold
            if (choice == 1)
            {
                _player = new Player(_playerName, 75, 75, 75, "Man-At-Arms", 1000);
                _currentScene++;
            }
            //This is the turn into a Heavy, which make the player's stats 75 health, 50 attack, 100 defense. The class name will be stated afterwards followed by 1000 gold
            if (choice == 2)
            {
                _player = new Player(_playerName, 75, 50, 100, "Heavy", 1000);
                _currentScene++;
            }
        }
        //Shows the player's stats
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
           switch (_currentScene)
            {
                case Scene.INTRODUCTION:
                    GetPlayerName();
                    CharacterClassSelection();
                    break;
                case Scene.ROOMONE:
                    FightingRoom1();
                    break;
                case Scene.ROOMTWO:
                    Shop();
                    break;
                case Scene.ROOMTHREE:
                    FightingRoom2();
                    break;
                case Scene.RESTARTMENU:
                    RestartMenu();
                    break;
            }
        }
        //asks the player if they want to restart or not
        void RestartMenu()
        {
            
            int choice = GetInput("do you want to play again", "Yes", "No");

            if (choice == 0)
            {
                Start();
            }
            if (choice == 1)
            {
                _gameOver = true;
            }
        }
        //The first room you fight in
        void FightingRoom1()
        {
            Battle();
            CheckBattleResults();
            if (_currentEnemyIndex == 3)
            {
                _currentScene++;
            }
        }
        //the secon room you fight in
        void FightingRoom2()
        {
            Battle();
            CheckBattleResults();
        }
        //Exits the game
        void Exit()
        {
           
                Console.WriteLine("Well you did not have to be rude about it");
                Console.ReadKey(true);
            
        }
        //opens the in game shop
        void Shop()
        {

            Console.WriteLine("Welcome! Please select an item.");
            //Shows the player the amount of money they have left
            Console.WriteLine("\nYou have: $" + _player.Gold());
            //shows the palyer what the shop has
            PrintInventory(_shopInventory);
            char input = Console.ReadKey().KeyChar;
            int itemIndex = -1;
            switch (input)
            {
                //each case is an item to buy
                case '1':
                    {
                        itemIndex = 0;
                        break;
                    }
                case '2':
                    {
                        itemIndex = 1;
                        break;
                    }
                case '3':
                    {
                        itemIndex = 2;
                        break;
                    }
                case '4':
                    {
                        itemIndex = 3;
                        break;
                    }
                case '5':
                    {
                        itemIndex = 4;
                        break;
                    }
                case '6':
                    {
                        _currentScene++;
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
            //Checks to see if the player can afford the item they want 
            if (_player.Gold() < _shopInventory[itemIndex].cost)
            {
                Console.WriteLine("You cant afford this.");
                return;
            }
            //allows the palyer to place the item they want in the slot of their choice
            Console.WriteLine("Choose a slot to replace.");
            //shows the player inventory 
            PrintInventory(_player.GetInventory());
            input = Console.ReadKey().KeyChar;

            int playerIndex = -1;
            //each case is a slot the player can put an item into
            switch (input)
            {
                case '1':
                    {
                        playerIndex = 0;
                        break;
                    }
                case '2':
                    {
                        playerIndex = 1;
                        break;
                    }
                case '3':
                    {
                        playerIndex = 2;
                        break;
                    }
                case '4':
                    {
                        playerIndex = 3;
                        break;
                    }
                case '5':
                    {
                        playerIndex = 4;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            //The shop sells the item the player wants to the player
            _shop.Sell(_player, itemIndex, playerIndex);


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

        //saves the game
        public void Save()
        {
            //Create a new stream writer
            StreamWriter writer = new StreamWriter("SaveData.txt");

            //Save current enemy index
            writer.WriteLine(_currentEnemyIndex);

            //Save player and enemy stats
            _player.Save(writer);
            _currentEnemy.Save(writer);

            //Close writer when done saving
            writer.Close();
        }
        //loads the game
        public bool Load()
        {
            bool loadSuccessful = true;

            //If the file doesn't exist...
            if (!File.Exists("SaveData.txt"))
                //...return false
                loadSuccessful = false;

            //Create a new reader to read from the text file
            StreamReader reader = new StreamReader("SaveData.txt");

            //Checks to see if the first line can be converted into an integer
            if (!int.TryParse(reader.ReadLine(), out _currentEnemyIndex))
                loadSuccessful = false;

            if (!_player.Load(reader))
                loadSuccessful = false;

            //Create a new instance and try to load the enemy
            _currentEnemy = new Entity();
            if (!_currentEnemy.Load(reader))
                loadSuccessful = false;

            //Update the array to match the current enemy stats
            _enemies[_currentEnemyIndex] = _currentEnemy;

            //Close the reader once loading is finished
            reader.Close();

            return loadSuccessful;
        }

        //runs the game
        public void Run()
        {
            Start();
            //While not game over
            while(!_gameOver)
            {
                //update the game
                Update();
                //if the game is over
            }
            //exit the game
            Exit();
        }
    }
}
