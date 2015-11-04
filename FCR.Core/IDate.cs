using System;

namespace FCR.Core
{
    public interface IDate
    {
        DateTime Today { get; }
        DateTime Now { get; }
        DateTime UtcNow { get; }
        DateTimeOffset OffsetNow { get; }
    }
}