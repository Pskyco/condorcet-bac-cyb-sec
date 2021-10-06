using System;

namespace EnumFlags.Enums
{
    // Flags means that we can have a combination of enums.
    [Flags]
    public enum ColorEnum
    {
        None = 0,
        Black = 1,
        Red = 2,
        Green = 4,
        Blue = 8
    }
}