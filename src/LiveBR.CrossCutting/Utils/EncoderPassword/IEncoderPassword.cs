namespace LiveBR.CrossCutting.Utils.EncoderPassword
{
    public interface IEncoderPassword
    {
        public string HashPassword(string plainPassword, int salt, bool value);

        public bool VerifyPassword(string plainPassword, string hashedPassword);
    }
}