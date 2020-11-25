using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Models
{
    public class Gifter 
    {
        public string ID { get; }

        public string Name { get; }

        public string RecipientName { get; set; }

        public Gifter(string id, string name )
        {
            ID = id;
            Name = name;
        }
    }
}
