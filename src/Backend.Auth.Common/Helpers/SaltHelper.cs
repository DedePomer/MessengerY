using System.Security.Cryptography;

namespace Backend.Auth.Common.Helpers;

public static class SaltHelper
{
    public static string GenerateSalt16()
    {
        const int length = 16;
        var salt = new byte[length];
        RandomNumberGenerator.Fill(salt);
        return Convert.ToBase64String(salt);
    }
}