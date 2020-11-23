using SecretSanta;
using SecretSanta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Services
{
    public class SecretSantaRoom
    {
        public List<Gifter> Gifters { get; } = new List<Gifter>();

        public void AssignSecretSantas()
        {
            Gifters.Shuffle();

            for(int i = 0; i < Gifters.Count; ++i)
            {
                //Wrap around list like circular array
                Guid gifteeId = Gifters[(i + 1) % Gifters.Count].ID;
                Gifters[i].AssignedGifteeID = gifteeId;
            }
        }
    }
}
