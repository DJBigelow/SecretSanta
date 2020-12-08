using SecretSanta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.ViewModels
{
    public class RoomViewModel
    {
        public SecretSantaRoom Room { get; }
        public string RoomCode { get; }

        public RoomViewModel(SecretSantaRoom room, string roomCode) => (Room, RoomCode) = (room, roomCode);
    }
}
