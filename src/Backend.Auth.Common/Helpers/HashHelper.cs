using System.Security.Cryptography;
using System.Text;

namespace Backend.Auth.Common.Helpers;

public static class HashHelper
{
    
    public static byte[] GetHash(string data)
    {
        var hashByte = Encoding.UTF8.GetBytes(data);
        
        return SHA256.HashData(hashByte);
    }
}