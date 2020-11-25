﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.ViewModels
{
    public class EnterNameViewModel
    {
        public string RoomCode { get; set; }

        [Required]
        public string GifterName { get; set; }

        
    }
}
