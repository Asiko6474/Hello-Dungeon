using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Dungeon
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop()
        {
            _gold = 3000;
            _inventory = new Item[5];
        }

        public Shop(Item[] items)
        {
            _gold = 100;
            //Set our inventory array to be the array of items that was passed in.
            _inventory = items;
        }

        public bool Sell(Player player, int itemIndex, int playerInventory)
        {
            //Find the item to buy in the inventory array
            Item itemToBuy = _inventory[itemIndex];
            //Check to see if the player ourchased the item successfully.
            if (player.Buy(itemToBuy, playerInventory))
            {
                //Increase shops gold by item cost to complete the transaction
                _gold += itemToBuy.cost;
                return true;
            }
            return false;
        }
    }   
}
