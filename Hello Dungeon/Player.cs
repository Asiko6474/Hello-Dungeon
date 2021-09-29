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

		public Player(string name, float health, float attackLevel, float defenseLevel, string job, int gold) : base(name, health, attackLevel, defenseLevel)
		{
			_job = job;
			_gold = gold;
			_inventory = new Item[5];
		}


		public bool Buy(Item item, int playerInventory)
        {
            if (_gold >= item.cost)
            {
                _gold -= item.cost;

                _inventory[playerInventory] = item;

                return true;
            }
            return false;
        }
		public override float DefenseLevel
		{
			get
			{
				if (_currentItem.Type == ItemType.DEFENSE)
					return base.DefenseLevel + _currentItem.StatBoost;

				return base.DefenseLevel;
			}
		}

		public override float AttackLevel
		{
			get
			{
				if (_currentItem.Type == ItemType.ATTACK)
					return base.AttackLevel + _currentItem.StatBoost;

				return base.AttackLevel;
			}
		}

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

		public string[] GetItemNames()
		{
			string[] itemNames = new string[_inventory.Length];

			for (int i = 0; i < _inventory.Length; i++)
			{
				itemNames[i] = _inventory[i].Name;
			}

			return itemNames;
		}


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
