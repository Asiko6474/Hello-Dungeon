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

        public override float DefenseLevel
        {
            get
            {
                if (_currentItem.Type == ItemType.DEFENSE)
                    return base.DefenseLevel + _currentItem.StatBoost;

                return base.DefenseLevel;
            }
        }

    }
}
