namespace LiveBR.CrossCutting.Utils.EncoderPassword
{
    public interface IEncoderPassword
    {
        public string HashPassword(string plainPassword);

        public bool VerifyPassword(string plainPassword, string hashedPassword);
    }
}