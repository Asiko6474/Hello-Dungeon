using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Dungeon
{
    class Player : Entity
    {
        private Item[] _items;
        private Item _currentItem;
        private int _currentItemIndex;
        private string _job;
        private int _gold;
        private Item[] _inventory;

        public Player()
        {
            _gold = 1000;
            _inventory = new Item[3];
        }
        // Whe the player uses a store, this allows the player to actually buy things from said store.
        public bool Buy(Item item, int inventoryIndex)
        {
            //if the player has more gold than the cost of the item
            if(_gold >= item.cost)
            {
                _gold -= item.cost;
                _inventory[inventoryIndex] = item;
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

        public int GetGold()
        {
            return _gold;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

    }
}
