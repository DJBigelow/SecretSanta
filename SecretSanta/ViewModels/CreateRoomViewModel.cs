using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.ViewModels
{
    public class CreateRoomViewModel
    {
        [Required(ErrorMessage = "Please enter a room code")]
        [MaxLength(6, ErrorMessage = "Room code must be six characters or less")]
        public string RoomCode { get; set; }
    }
}
