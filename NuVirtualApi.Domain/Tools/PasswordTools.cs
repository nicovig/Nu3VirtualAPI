﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

public static class PasswordTool
{
    public static string HashPassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.UTF8.GetBytes("saltForPasswordHashing"),
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return hashed;
    }
}