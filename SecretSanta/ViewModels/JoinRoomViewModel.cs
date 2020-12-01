using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.ViewModels
{
    public class JoinRoomViewModel
    {
        [Required(ErrorMessage = "Please enter a room code")]
        public string RoomCode { get; set; }
    }
}
