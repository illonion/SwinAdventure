using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand(string[] ids) : base(ids) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length > 2 || text.Length < 1) { return "This path does not exist."; }
            if (text.Length == 1) { return "Where do you want to go?"; }

            if (text[0] != "move" && text[0] != "leave" && text[0] != "go" && text[0] != "head")
            {
                return "Error in move command.";
            }
            else
            {
                Location loc = p.Location;
                Path path = loc.ReturnPath(text[1]);

                if (path == null) { return "The path was not found."; }
                else
                {
                    path.Go(p);
                    return "You head " + path.Name + ".\nYou travel through " + path.FullDescription + ".\nYou arrive at " + path.Final.Name;
                }
            }
        }
    }
}
