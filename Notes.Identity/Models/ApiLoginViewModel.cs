﻿using System.ComponentModel.DataAnnotations;

namespace Notes.Identity.Models
{
    public class ApiLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
