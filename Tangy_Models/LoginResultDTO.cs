﻿namespace Tangy_Models
{

    public class LoginResultDTO
    {
        public bool Successful { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
    }
}

