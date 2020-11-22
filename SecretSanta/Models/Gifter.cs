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

        public Guid AssignedGifteeID { get; set; }

        public Gifter(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
        }
    }
}
