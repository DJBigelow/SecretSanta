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

        private bool recipientsAssigned = false;

        public void AssignSecretSantas()
        {
            if (!recipientsAssigned)
            {
                recipientsAssigned = true;

                Gifters.Shuffle();

                for(int i = 0; i < Gifters.Count; ++i)
                {
                    //Wrap around list like circular array
                    string recipentName = Gifters[(i + 1) % Gifters.Count].Name;
                    Gifters[i].RecipientName = recipentName;
                }

            }
        }
    }
}
