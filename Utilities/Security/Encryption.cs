using System.Security.Cryptography;
using System.Text;

namespace Utilities.Security
{
    public class Encryption
    {
        public static string EncriptarSHA256(string input)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder resultado = new();
            foreach (byte b in bytes)
            {
                resultado.Append(b.ToString("x2"));
            }
            return resultado.ToString();
        }
    }
}

//Scaffold-DbContext "Server=DESKTOP-8CQM9OG\SQLSEXPRESS;Database=SISTEMA_CINE;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context DBContext -f
