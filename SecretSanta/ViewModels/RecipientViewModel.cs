using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.ViewModels
{
    public class RecipientViewModel
    {
        public string RecipientName {get;}

        public RecipientViewModel(string recipientName)
        {
            RecipientName = recipientName;
        }
    }
}
