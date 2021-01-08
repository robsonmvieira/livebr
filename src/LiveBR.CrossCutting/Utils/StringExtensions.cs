namespace LiveBR.CrossCutting.Utils
{
    public static class StringExtensions
    {
        public static string RemoveCaracters(this string str, string[] separators, string newValue) {
            foreach (var chr in separators) str = str.Replace(chr, newValue);
            return str;
        }
    }
}