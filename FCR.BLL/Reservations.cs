using System;
using System.Linq;
using FCR.DAL;
using FCR.DomainModel;

namespace FCR.BLL
{

    public class Reservations
    {
        private readonly IFCRContext _entities;

        public Reservations(IFCRContext entities)
        {
            _entities = entities;
        }

        public bool IsReservationAvailable(int resourceId, DateTime reservationDate, int unitStart, int unitLength)
        {
            var returnValue = false;

            try
            {
                var formattedDate = new DateTime(reservationDate.Year, reservationDate.Month, reservationDate.Day);
                var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                //can't have dates in the past...
                if (formattedDate < today)
                {
                    return false;
                }

                var r = (from resrources in _entities.Resources where resrources.Id == resourceId select resrources).FirstOrDefault();
                if (r == null)
                {

                    //bad resource ID
                    return false;
                }

                var fc = (from centers in _entities.FitnessCenters where centers.Id == r.Id select centers).FirstOrDefault();
                if (fc == null)
                {
                    //bad fitness center ID
                    return false;
                }

                var lastValidDate = today.AddDays(fc.MaxDaysOutForReservation);
                if (formattedDate > lastValidDate)
                {
                    //to far in advance for this fitness center
                    return false;
                }

                if (unitLength > fc.MaxConcurrentUnits)
                {
                    //to many units for this fitness center
                    return false;
                }

                if (!(unitStart >= fc.OperationTimeUnitStart && unitStart + unitLength - 1 <= fc.OperationTimeUnitStart + fc.OperationTimeUnitLength - 1))
                {
                    //outside of operation hours....
                    return false;
                }

                var t = from reservations in _entities.Reservations
                        where

                            reservations.Id == resourceId &&
                            reservations.ReservationDate == formattedDate &&
                            (
                                (
                                    (
                                        unitStart >= reservations.ReservationTimeUnitStart &&
                                        unitStart <= (reservations.ReservationTimeUnitStart + reservations.ReservationTimeUnitLength - 1)
                                    ) ||
                                    (
                                        (unitStart + unitLength - 1) >= reservations.ReservationTimeUnitStart &&
                                        (unitStart + unitLength - 1) <= (reservations.ReservationTimeUnitStart + reservations.ReservationTimeUnitLength - 1)
                                    )
                                )
                                ||
                                (
                                    (
                                        reservations.ReservationTimeUnitStart >= unitStart &&
                                        reservations.ReservationTimeUnitStart <= (unitStart + unitLength - 1)
                                    ) ||
                                    (
                                        (reservations.ReservationTimeUnitStart + reservations.ReservationTimeUnitLength - 1) >= unitStart &&
                                        (reservations.ReservationTimeUnitStart + reservations.ReservationTimeUnitLength - 1) <= (unitStart + unitLength - 1)
                                    )
                                )
                            )
                        select reservations;


                if (!t.Any())
                {
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public bool CreateReservation(int userId, int resourceId, DateTime reservationDate, int unitStart, int unitLength)
        {
            var returnValue = false;

            try
            {

                if (IsReservationAvailable(resourceId, reservationDate, unitStart, unitLength))
                {
                    _entities.Reservations.Add(

                        new Reservation()
                        {
                            ReservationDate = reservationDate,
                            ReservationTimeUnitStart = unitStart,
                            ReservationTimeUnitLength = unitLength,
                            Id = resourceId,
                            Description = ""
                        }
                        );
                    _entities.SaveChanges();
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;

        }

        public bool DeleteReservation(int reservationID)
        {
            var returnValue = false;

            try
            {
                var r = new Reservation { Id = reservationID };
                _entities.Reservations.Attach(r);
                _entities.Reservations.Remove(r);
                _entities.SaveChanges();
                returnValue = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;

        }

        public bool ValidateReservation(int reservationID)
        {
            var returnValue = false;

            try
            {
                var r = (from reservation in _entities.Reservations where reservation.Id == reservationID select reservation).FirstOrDefault();
                r.Validated = true;
                _entities.SaveChanges();
                returnValue = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;

        }

        //public static List<AllReservation> GetTodaysReservationsByUser(int userID)
        //{
        //    List<allReservation> returnValue = new List<allReservation>();

        //    try
        //    {
        //        PhitnessEntities entities = new PhitnessEntities();
        //        DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //        returnValue = (from res in entities.allReservations where res.reservationDate == today && res.userId == userID && res.validated == false select res).ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return returnValue;
        //}

        //public static HeatMap GetHeatMap(int fitnessCenterId, DateTime startDate, DateTime endDate)
        //{

        //    startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
        //    endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day);

        //    HeatMap returnValue = new HeatMap();
        //    returnValue.HeatMapItems = new List<HeatMapItem>();

        //    PhitnessEntities entities = new PhitnessEntities();
        //    FitnessCenter fc = (from fitnessCenter in entities.FitnessCenters where fitnessCenter.fitnessCenterId == fitnessCenterId select fitnessCenter).FirstOrDefault();
        //    List<Resource> rc = (from resources in entities.Resources where resources.fitnessCenterFK == fitnessCenterId select resources).ToList();

        //    int totalUnits = fc.operationTimeUnitLength * rc.Count;


        //    List<allReservationsByCenterCount> allReservations = (from res in entities.allReservationsByCenterCounts where res.reservationDate >= startDate && res.reservationDate <= endDate select res).ToList();
        //    double colorUnit = 256d / (double)totalUnits;

        //    foreach (allReservationsByCenterCount ar in allReservations)
        //    {
        //        HeatMapItem hmi = new HeatMapItem();
        //        hmi.Day = ar.reservationDate;
        //        hmi.totalUnits = (int)ar.TotalUnits;
        //        int colorScale = 255 - (int)(colorUnit * hmi.totalUnits);
        //        Color c = Color.FromArgb(255, colorScale, colorScale);
        //        hmi.HexColor = ColorTranslator.ToHtml(c);
        //        hmi.RGBColor = c.ToArgb();

        //        returnValue.HeatMapItems.Add(hmi);
        //    }

        //    //Color c = new Color()


        //    return returnValue;


        //}

        //public Models.ResourceMatrix GetResourceMatrix(int fitnessCenterId, DateTime startDate, DateTime endDate)
        //{
        //    Models.ResourceMatrix returnValue = new Models.ResourceMatrix();

        //    startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
        //    endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day);



        //    PhitnessEntities entities = new PhitnessEntities();
        //    FitnessCenter fc = (from fitnessCenter in entities.FitnessCenters where fitnessCenter.fitnessCenterId == fitnessCenterId select fitnessCenter).FirstOrDefault();
        //    List<Resource> rc = (from resources in entities.Resources where resources.fitnessCenterFK == fitnessCenterId select resources).ToList();

        //    int totalUnits = fc.operationTimeUnitLength * rc.Count;
        //    for (int resourceNum = 0; resourceNum < rc.Count; resourceNum++)
        //    {
        //        List<bool> lb = new List<bool>();
        //        for (int unitNumber = fc.operationTimeUnitStart; unitNumber < fc.operationTimeUnitStart + fc.operationTimeUnitLength; unitNumber++)
        //        {
        //            lb.Add(false);
        //        }
        //        returnValue.TheMatrix.Add(lb);
        //    }


        //    List<allReservationsByCenterCount> allReservations = (from res in entities.allReservationsByCenterCounts where res.reservationDate >= startDate && res.reservationDate <= endDate select res).ToList();
        //    double colorUnit = 256d / (double)totalUnits;

        //    foreach (allReservationsByCenterCount ar in allReservations)
        //    {
        //        Models.HeatMapItem hmi = new Models.HeatMapItem();
        //        hmi.Day = ar.reservationDate;
        //        hmi.totalUnits = (int)ar.TotalUnits;
        //        int colorScale = 255 - (int)(colorUnit * hmi.totalUnits);
        //        Color c = Color.FromArgb(255, colorScale, colorScale);
        //        hmi.HexColor = ColorTranslator.ToHtml(c);
        //        hmi.RGBColor = c.ToArgb();

        //        returnValue.HeatMapItems.Add(hmi);
        //    }

        //    //Color c = new Color()


        //    return returnValue;

        //    return returnValue;

        //}
    }
}