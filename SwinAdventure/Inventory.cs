using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item toReturn = null;
            foreach (Item i in _items.ToList())
            {
                if (i.AreYou(id))
                {
                    _items.Remove(i);
                    toReturn = i;
                }
            }
            return toReturn;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id)) return i;
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string itemList = "";
                foreach (Item i in _items)
                {
                    itemList += i.ShortDescription.ToString();
                    itemList += "\n";
                }
                return itemList;
            }
        }
    }
}
