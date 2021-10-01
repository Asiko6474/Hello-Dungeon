using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hello_Dungeon
{
	class Player : Entity
	{
        int _gold;
        Item[] _inventory;
		private Item _currentItem;
		private string _job;
		private int _currentItemIndex;
		public int Gold()
        {
            return _gold;
        }

		//initializes the player 
		public Player(string name, float health, float attackLevel, float defenseLevel, string job, int gold) : base(name, health, attackLevel, defenseLevel)
		{
			_job = job;
			_gold = gold;
			//makes a new inventory with 5 empty slots
			_inventory = new Item[5];
		}

		//This allows the pleyer to buy items from a shop
		public bool Buy(Item item, int playerInventory)
        {
			//checks to see if the player has more money than the cost of the item they want to buy
            if (_gold >= item.cost)
            {
                _gold -= item.cost;

                _inventory[playerInventory] = item;

                return true;
            }
			//if the player can't afford the item, then the purchase is false
            return false;
        }

		//alows armor to increase defense
		public override float DefenseLevel
		{
			get
			{
				if (_currentItem.Type == ItemType.DEFENSE)
					return base.DefenseLevel + _currentItem.StatBoost;

				return base.DefenseLevel;
			}
		}
		//allows weapons to increase attack
		public override float AttackLevel
		{
			get
			{
				if (_currentItem.Type == ItemType.ATTACK)
					return base.AttackLevel + _currentItem.StatBoost;

				return base.AttackLevel;
			}
		}
		//allows health items to heal
		public override float Health
		{
			get
			{
				if (_currentItem.Type == ItemType.HEALTH)
					return base.Health + _currentItem.StatBoost;

				return base.Health;
			}
		}
		public Item CurrentItem
		{
			get
			{
				return _currentItem;
			}
		}
		//allows other classes to call the player inventory with this function
		public Item[] GetInventory()
		{
			return _inventory;
		}

		public bool TryEquipItem(int index)
		{
			//If the index is out of bounds...
			if (index >= _inventory.Length || index < 0)
			{
				//...return false
				return false;
			}

			_currentItemIndex = index;

			//Set the current item to be the array at the given index
			_currentItem = _inventory[_currentItemIndex];

			return true;
		}

		public bool TryRemoveCurrentItem()
		{
			//If the current item is set to nothing...
			if (CurrentItem.Name == "Nothing")
			{
				//...return false
				return false;
			}

			_currentItemIndex = -1;

			//Set item to be nothing
			_currentItem = new Item();
			_currentItem.Name = "Nothing";

			return true;
		}
		//gets the names of items in an inventory
		public string[] GetItemNames()
		{
			string[] itemNames = new string[_inventory.Length];

			for (int i = 0; i < _inventory.Length; i++)
			{
				itemNames[i] = _inventory[i].Name;
			}

			return itemNames;
		}

		//saves the palyer class 
		public override void Save(StreamWriter writer)
		{
			base.Save(writer);
			writer.WriteLine(_currentItemIndex);
		}

		public override bool Load(StreamReader reader)
		{
			//If the base loading function fails..
			if (!base.Load(reader))
				//...return false
				return false;

			//If the current line can't be converted into an int...
			if (!int.TryParse(reader.ReadLine(), out _currentItemIndex))
				//...return false
				return false;

			//Return whether or not the item was equipped successfully
			return TryEquipItem(_currentItemIndex);
		}
	}
}
