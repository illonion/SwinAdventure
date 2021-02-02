using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;
        public Bag(string[] idents, string name, string desc) : base(idents, name, desc) { _inventory = new Inventory(); }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            return Inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get { return "In the " + Name + " you can see:\n" + Inventory.ItemList; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}