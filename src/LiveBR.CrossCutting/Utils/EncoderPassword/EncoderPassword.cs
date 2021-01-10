using BC = BCrypt.Net.BCrypt;
namespace LiveBR.CrossCutting.Utils.EncoderPassword
{
    public class EncoderPassword: IEncoderPassword
    {
        public string HashPassword(string plainPassword, int salt, bool value)
        {
            return BC.HashPassword(plainPassword, salt, value);
        }

        public bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            var isMatch = BC.Verify(plainPassword, hashedPassword);

            return isMatch;
        }
    }
}