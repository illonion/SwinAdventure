using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc, Location location) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = location;
        }

        public override string FullDescription
        {
            get
            {
                return base.FullDescription + "\nYou are carrying " + _inventory.ItemList;
            }
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id)) { return this; }
            else if (_inventory.HasItem(id)) { return _inventory.Fetch(id); }
            return Location.Locate(id);
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        // 
    }
}
