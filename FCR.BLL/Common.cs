using System;
using System.Globalization;
using System.Linq;

namespace FCR.BLL
{
    public static class Common
    {
      
        public static int IntervalLength(int fitnessCenterId)
        {
            var entities = new FCR.DAL.FCRContext();
            return
                entities.FitnessCenters.Where(x => x.Id == fitnessCenterId)
                    .Select(x => x.UnitIntervalMinutes)
                    .First();
        }


        public static int GetDayId(DateTime? dateTime)
        {
            if (!dateTime.HasValue) throw new ApplicationException(string.Format("Date provided is null. "));
            return Convert.ToInt32(dateTime.Value.ToString("yyyyMMdd"));
        }

        public static string GetDayId(string dateTime)
        {
            DateTime result;
            if (DateTime.TryParse(dateTime, out result))
            {
                return result.ToString("yyyyMMdd");
            }
            else
            {
                throw new ApplicationException(string.Format("Date {0} provided is not valid ", dateTime));
            }
        }

        public static DateTime GetDateTimeFromDayId(int dayId)
        {
            return DateTime.ParseExact(dayId.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);

        }

        public static DateTime GetDateTime(DateTime startDate, int intervalCount, int fitnessCenterId)
        {
            return startDate.Date.AddMinutes(IntervalLength(fitnessCenterId) * intervalCount);
        }

        public static DateTime GetDateTime(string startDate, int intervalCount, int fitnessCenterId)
        {
            DateTime result;
            if (DateTime.TryParse(startDate, out result))
            {
                return GetDateTime(result, intervalCount, fitnessCenterId);
            }
            else
            {
                throw new ApplicationException(string.Format("Start Date {0} provided is not valid ", startDate));
            }
        }


    }
}
