﻿namespace NuVirtualApi.Domain.Models.ToolsModel
{
    public class PasswordOptions
    {
        public int RequiredLength { get; set; }
        public int RequiredUniqueChars { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireUppercase { get; set; }
    }
}
