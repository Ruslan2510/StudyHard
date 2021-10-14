using System.Text;

namespace StudyHard.Dto.Config
{
    public class JwtConfig
    {
        public const string Issuer  = "StudyHardIssuer";
        public const string Audience  = "StudyHardAudience";
        private static string SecretKey { get; set; } = "StudyHardSecretKey";

        public const double LifeTime = 60;

        public static byte[] GetSymmetricKey()
        {
            return Encoding.UTF8.GetBytes(SecretKey);
        }
    }
}