using System;
using System.Collections.Generic;
using System.Linq;
using FCR.DAL;
using FCR.WebApiModel;
using cmn = FCR.BLL.Common;

namespace FCR.BLL
{
    public class ReservationLogic
    {
        private readonly IFCRContext _entities;

        readonly DateTime _defaultStartDate = DateTime.Now.Date;
        readonly DateTime _defaultEndDate = DateTime.Now.AddDays(7).Date;

        public ReservationLogic(FCRContext entities)
        {
            _entities = entities;
        }

        //public ExistingReservation GetReservation(int reservationId)
        //{
        //    var results = new List<ExistingReservation>();
        //    var reservation = _entities.allReservations.First(x => x.reservationId == reservationId);

        //    MapReservationData(reservation, results);
        //    return results.First();
        //}

        //public List<ExistingReservation> GetAllExistingReservations()
        //{
        //    var results = new List<ExistingReservation>();

        //    var reservations = entities.allReservations
        //        .Where(x => x.reservationDate >= _defaultStartDate && x.reservationDate < _defaultEndDate)
        //        .ToList();

        //    reservations.ForEach(x =>
        //    {
        //        MapReservationData(x, results);
        //    });

        //    return results;
        //}

        //public List<ExistingReservation> GetExistingReservations(int fitnessCenterId)
        //{

        //    var reservations = entities.allReservations
        //        .Where(x => x.fitnessCenterId == fitnessCenterId && x.reservationDate >= _defaultStartDate && x.reservationDate < _defaultEndDate)
        //        .ToList();

        //    var results = new List<ExistingReservation>();

        //    reservations.ForEach(x =>
        //    {
        //        MapReservationData(x, results);
        //    });
        //    return results;
        //}

        //public List<ExistingReservation> GetExistingReservations(int fitnessCenterId, int dayId)
        //{

        //    var filterDate = cmn.GetDateTimeFromDayId(dayId);
        //    var endDate = filterDate.AddDays(1);

        //    var reservations = entities.allReservations
        //        .Where(x => x.fitnessCenterId == fitnessCenterId && x.reservationDate >= filterDate.Date && x.reservationDate < endDate)
        //        .ToList();

        //    var results = new List<ExistingReservation>();

        //    reservations.ForEach(x =>
        //    {
        //        MapReservationData(x, results);
        //    });
        //    return results;
        //}

        //public bool CreateReservation(RequestReservation request)
        //{
        //    var equipLogic = new EquipmentLogic().GetEquipmentById(request.EquipmentId);
        //    var centerInterval = new CenterLogic().GetCenterInfo().First(x => x.FitnessCenterId == equipLogic.FitnessCenterId);
        //    var unitStart = (int)Math.Truncate((double)request.StartMinutesSinceMidnight / (double)centerInterval.IntervalMinutes);
        //    return Reservations.CreateReservation(request.UserId, request.EquipmentId, cmn.GetDateTimeFromDayId(request.DayId), unitStart, 1);
        //}

        //public bool DeleteReservation(int reservationId)
        //{
        //    return Reservations.DeleteReservation(reservationId);
        //}

        //private static void MapReservationData(allReservation x, List<ExistingReservation> results)
        //{
        //    var row = new ExistingReservation();

        //    row.Id = x.ReservationId;
        //    row.DayId = cmn.GetDayId(x.reservationDate);
        //    row.FitnessCenterId = x.fitnessCenterId;
        //    row.StartTime = cmn.GetDateTime(x.reservationDate, x.reservationTimeUnitStart, x.fitnessCenterId).ToLongTimeString();
        //    row.StartMinutesSinceMidnight = cmn.IntervalLength(x.fitnessCenterId) * x.reservationTimeUnitStart;
        //    row.EquipmentId = x.resourceId;
        //    row.EquipmentName = x.resourceName;
        //    row.EquipmentTypeDescription = x.resourceTypeDescription;
        //    row.EquipmentTypeId = x.resourceTypeId;
        //    row.UserId = x.userId;
        //    row.UserName = x.userName;
        //    row.FirstName = x.firstName;
        //    row.LastName = x.lastName;
        //    row.IntervalLength = cmn.IntervalLength(x.fitnessCenterId);

        //    results.Add(row);
        //}



    }
}
