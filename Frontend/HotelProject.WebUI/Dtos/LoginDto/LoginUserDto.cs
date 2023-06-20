﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Şifre Giriniz")]
        public string? Password { get; set; }
    }
}
