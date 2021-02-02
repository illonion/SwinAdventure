using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : Item
    {
        private Location _initial = null;
        private Location _final = null;

        public Path(string[] ids, string name, string desc, Location initial, Location final) : base(ids, name, desc)
        {
            _initial = initial;
            _final = final;
        }

        public void Go(Player p)
        {
            p.Location = Final;
        }

        public Location Initial { get { return _initial; } set { _initial = value; } }
        public Location Final { get { return _final; } set { _final = value; } }
    }
}
