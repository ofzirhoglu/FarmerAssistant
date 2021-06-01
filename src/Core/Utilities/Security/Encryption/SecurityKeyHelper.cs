using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public static class SecurityKeyHelper
    {
        // Parametre olarak verilen string tipindeki 'securityKey' değerini 
        // byte dizisine cevirerek SymmetricSecurityKey oluşturuyor
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}