using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public static class SigningCredentialsHelper
    {
        // Parametre olarak girilen 'securityKey' değerini 
        // SecurityAlgorithms.HmacSha512Signature algoritmasını ekleyerek 
        // geriye SigningCredentials olarak döner
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}