using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Look_Command : Command
    {
        public Look_Command(string[] ids) : base(ids) { }
        public override string Execute(Player p, string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = text[i].ToLower();
            }

            if (text.Length == 1 && text[0] == "look") { return p.Location.FullDescription; }
            if (!(text.Length == 3 || text.Length == 5)) { return "I don't know how to look like that."; }
            if (text[0] != "look") { return "Error in look input."; }
            if (text[1] != "at") { return "What do you want to look at?"; }

            IHaveInventory _container;
            switch (text.Length)
            {
                case 3:
                    _container = p as IHaveInventory;
                    break;
                case 5:
                    _container = FetchContainer(p, text[4]);
                    break;
                default:
                    _container = null;
                    break;
            }
            
            if (_container == null) { return "I cannot find the " + text[4]; }
            return LookAtIn(text[2], _container);
        }

        private IHaveInventory FetchContainer(Player p, string containerid)
        {
            return p.Locate(containerid) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            }
            else { return "I can not find the " + thingId + "."; }
        }
    }
}
