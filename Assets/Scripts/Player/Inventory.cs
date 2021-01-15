using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playerr
{
    public class Inventory
    {
        private int _Size { get; }

        public Item[] listItems;

        public Inventory(int size)
        {
            _Size = size;
            listItems = new Item[size];
        }

        public Item Get(int index)
        {
            return listItems[index];
        }

        public void Set(int index, Item item)
        {
            listItems[index] = item;
        }
    }
}
