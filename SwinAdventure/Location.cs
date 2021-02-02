using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _path;
        public Location(string[] idents, string name, string desc) :base(idents, name, desc)
        {
            _inventory = new Inventory();
            _path = new List<Path>();
        }

        public GameObject Locate(string id)
        {
            if(AreYou(id)) { return this; }
            return _inventory.Fetch(id);
        }

        public Inventory Inventory { get { return _inventory; } }

        public void AddPath(Path p)
        {
            _path.Add(p);
        }

        public Path ReturnPath(string id)
        {
            foreach (Path p in _path)
            {
                if (p.AreYou(id)) { return p; }
            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return "You are located in " + Name + ".\nThis is " + base.FullDescription + ".\n In " + Name + ", you can see: \n" + Inventory.ItemList;
            }
        }

        public List<Path> Path { get { return _path; } }
    }
}
