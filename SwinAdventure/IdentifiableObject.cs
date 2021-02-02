using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiable = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            for (int i = 0; i < idents.Length; i++)
            {
                idents[i].ToLower();
                _identifiable.Add(idents[i]);
            }
        }

        public bool AreYou(string id)
        {
            for (int i = 0; i < _identifiable.Count; i++)
            {
                id = id.ToLower();
                if (id == _identifiable.ElementAt(i))
                {
                    return true;
                }
            }
            return false;
        }

        public string FirstID
        {
            get
            {
                if (_identifiable.ElementAt(0) == null)
                {
                    return "";
                }
                return _identifiable.ElementAt(0);
            }
        }

        public void AddIdentifier(string id)
        {
            string lowerIdentifier = id.ToLower();
            _identifiable.Add(lowerIdentifier);

        }
    }
}
