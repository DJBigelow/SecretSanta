using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.ViewModels
{
    public class JoinRoomViewModel
    {
        [Required]
        public string RoomCode { get; set; }

        public bool RoomExists { get; set; }
    }
}
