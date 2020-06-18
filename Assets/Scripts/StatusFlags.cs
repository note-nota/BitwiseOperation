using System;

namespace BitwiseOperation
{
    [Flags]
    public enum StatusFlags
    {
        None      = 0,
        Poisoned  = 1 << 0,
        Blind     = 1 << 1,
        Asleep    = 1 << 2,
        Stunned   = 1 << 3,
        Silenced  = 1 << 4,
        Paralysed = 1 << 5
    }
}