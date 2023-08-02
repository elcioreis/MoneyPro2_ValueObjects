using System.Security.Cryptography;

namespace Money2.Shared.Functions;

public static partial class Tools
{
    public static string GenerateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();
            ;
        }
    }
}