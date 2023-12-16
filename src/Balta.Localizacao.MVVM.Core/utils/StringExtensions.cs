namespace Balta.Localizacao.MVVM.Core.utils
{
    public static class StringExtensions
    {
        public static bool IsOnlyNumbers(this string str)
        {
            return int.TryParse(str, out var result);
        }
        
        public static bool HasMaxLength(this string str, int maxLength)
        {
            return str.Length <= maxLength;
        }
    }
}
