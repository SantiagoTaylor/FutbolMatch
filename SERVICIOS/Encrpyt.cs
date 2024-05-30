using System.Security.Cryptography;
using System.Text;

namespace SERVICES
{
    public class Encrpyt
    {
        public static string HashPassword(string password)
        {
            SHA256 encryptor = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream;
            StringBuilder sb = new StringBuilder();
            stream = encryptor.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static bool CompareHash(string toHash, string hashed)
        {
            return hashed.Equals(HashPassword(toHash));
        }
    }
}
