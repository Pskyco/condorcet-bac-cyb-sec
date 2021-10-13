namespace Static.Extensions
{
    public static class StringExtensions
    {
        public static string PrettyPrintNationalNumber(this string rawNationalNumber)
        {
            // 00000011122
            // 00.00.00-111.22
            return $"{rawNationalNumber.Substring(0, 2)}." +
                   $"{rawNationalNumber.Substring(2, 2)}." +
                   $"{rawNationalNumber.Substring(4, 2)}-" +
                   $"{rawNationalNumber.Substring(6, 3)}." +
                   $"{rawNationalNumber.Substring(9, 2)}";
        }
    }
}