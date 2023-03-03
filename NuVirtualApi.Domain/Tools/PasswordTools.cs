using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NuVirtualApi.Domain.Models.ToolsModel;
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

    /// <summary>
    /// Generates a Random Password
    /// respecting the given strength requirements.
    /// https://stackoverflow.com/questions/28480167/asp-net-identity-generate-random-password
    /// </summary>
    /// <param name="opts">A valid PasswordOptions object
    /// containing the password strength requirements.</param>
    /// <returns>A random password</returns>
    public static string GenerateRandomPassword()
    {
        PasswordOptions passwordOptions = new PasswordOptions
        {
            RequiredLength = 10,
            RequiredUniqueChars = 4,
            RequireDigit = true,
            RequireLowercase = true,
            RequireUppercase = true
        };

        string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
        };

        Random rand = new Random(Environment.TickCount);
        List<char> chars = new List<char>();

        if (passwordOptions.RequireUppercase)
            chars.Insert(rand.Next(0, chars.Count),
                randomChars[0][rand.Next(0, randomChars[0].Length)]);

        if (passwordOptions.RequireLowercase)
            chars.Insert(rand.Next(0, chars.Count),
                randomChars[1][rand.Next(0, randomChars[1].Length)]);

        if (passwordOptions.RequireDigit)
            chars.Insert(rand.Next(0, chars.Count),
                randomChars[2][rand.Next(0, randomChars[2].Length)]);

        for (int i = chars.Count; i < passwordOptions.RequiredLength
            || chars.Distinct().Count() < passwordOptions.RequiredUniqueChars; i++)
        {
            string rcs = randomChars[rand.Next(0, randomChars.Length)];
            chars.Insert(rand.Next(0, chars.Count),
                rcs[rand.Next(0, rcs.Length)]);
        }

        return new string(chars.ToArray());
    }
}