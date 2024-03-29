﻿using System.Security.Cryptography;
using System.Text;

namespace HarmonogramyWebAPI;

public class Security
{
    private static int keySize = 64;
    private static int iterations = 350000;
    private static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

    public static string GetPasswordHash(IConfiguration configuration, string password)
    {
        var salt = configuration["AppSettings:Salt"]!;
        var saltBytes = Encoding.UTF8.GetBytes(salt);
        
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            saltBytes,
            iterations,
            hashAlgorithm,
            keySize);
        
        return Convert.ToHexString(hash);
    }
    
    public static bool VerifyPassword(IConfiguration configuration, string password, string hash)
    {
        var salt = configuration["AppSettings:Salt"]!;
        var saltBytes = Encoding.UTF8.GetBytes(salt);
        var hashToCompare = Rfc2898DeriveBytes
            .Pbkdf2(password, saltBytes, iterations, hashAlgorithm, keySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
}