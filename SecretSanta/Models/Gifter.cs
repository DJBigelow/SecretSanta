using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Models
{
    public class Gifter 
    {
        public Guid ID { get; }

        public string Name { get; }

        public string RecipientName { get; set; }

        public Gifter(Guid id, string name )
        {
            ID = id;
            Name = name;
        }
    }
}
