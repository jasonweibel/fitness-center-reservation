using System;
using FCR.Core;

namespace FCR.BLL
{
    public class DateLogic :IDate
    {

        public DateTime Today => new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime Now =>  DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
        public DateTimeOffset OffsetNow => DateTimeOffset.Now;

    }
}