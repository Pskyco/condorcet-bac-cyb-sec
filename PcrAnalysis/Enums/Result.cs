namespace PcrAnalysis.Enums
{
    public enum ResultEnum
    {
        // we should always precise the integer value to avoid data corruption in case of addition
        // (c# compute it automatically otherwise)
        NotDone = 0,
        Positive = 1,
        Negative = 2,
        NonConclusive = 3,
        Other = 4,
        Lost = 5
    }
}