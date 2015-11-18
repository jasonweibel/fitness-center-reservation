using System;
using System.Collections.Generic;
using System.Linq;
using FCR.DAL;
using FCR.DomainModel;
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

        public ExistingReservation GetReservation(int reservationId)
        {
            var reservation = _entities.Reservations.FirstOrDefault(x => x.Id == reservationId);

            if (reservation == null) throw new ApplicationException("Reservation Does Not Exist.");

            var resource = _entities.Resources.FirstOrDefault(x => x.Id == reservation.Resource.Id);

            if (resource == null) throw new ApplicationException("Resources Does Not Exist.");

            var center = _entities.FitnessCenters.FirstOrDefault(x => x.Id == resource.FitnessCenter.Id);

            if (center == null) throw new ApplicationException("FitnessCenters Does Not Exist.");

            // TODO - This is wrong...
            var sites = _entities.Sites.FirstOrDefault(x => x.Id == center.Id);

            if (sites == null) throw new ApplicationException("Sites Does Not Exist.");

            var user = _entities.User.FirstOrDefault(x => x.Id == reservation.User.Id);

            if (user == null) throw new ApplicationException("User Does Not Exist.");

            var resourceType = _entities.ResourceTypes.FirstOrDefault(x => x.Id == resource.ResourceType.Id);

            if (user == null) throw new ApplicationException("User Does Not Exist.");

            return ExistingReservationMapper(reservation, resource, resourceType, user, center);
        }

        public List<ExistingReservation> GetAllExistingReservations()
        {
            //var results = new List<ExistingReservation>();

            //var reservations = entities.allReservations
            //    .Where(x => x.reservationDate >= _defaultStartDate && x.reservationDate < _defaultEndDate)
            //    .ToList();

            //reservations.ForEach(x =>
            //{
            //    MapReservationData(x, results);
            //});

            var reservation = _entities.Reservations;
            var resource = _entities.Resources;
            var center = _entities.FitnessCenters;
            var sites = _entities.Sites;
            var user = _entities.User;
            var resourceType = _entities.ResourceTypes;

            var reservations = from r in reservation
                from re in resource.Where(x => x.Id == r.Resource.Id).DefaultIfEmpty()
                from c in center.Where(x => x.Id == re.FitnessCenter.Id).DefaultIfEmpty()
                from s in sites.Where(x => x.Id == c.Id).DefaultIfEmpty()
                // TODO This is wrong too.
                from u in user.Where(x => x.Id == r.User.Id).DefaultIfEmpty()
                from rt in resourceType.Where(x => x.Id == re.ResourceType.Id)
                select new List<ExistingReservation>()
                {
                    ExistingReservationMapper(r, re, rt, u, c)
                };

            // TODO - figure this out.
            return reservations;
        }

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

        private static ExistingReservation ExistingReservationMapper(Reservation reservation, Resource resource, ResourceType resourceType, User user, FitnessCenter center)
        {
            return new ExistingReservation()
            {
                Id = reservation.Id,
                DayId = cmn.GetDayId(reservation.ReservationDate),
                EquipmentId = resource.Id,
                EquipmentName = resource.ResourceName,
                EquipmentTypeDescription = resourceType.ResourceTypeDescription,
                EquipmentTypeId = resource.ResourceType.Id,
                FirstName = user.FirstName,
                FitnessCenterId = center.Id,
                IntervalLength = cmn.IntervalLength(center.Id), 
                LastName = user.LastName,
                StartMinutesSinceMidnight = cmn.IntervalLength(center.Id) * reservation.ReservationTimeUnitStart, 
                StartTime = cmn.GetDateTime(reservation.ReservationDate, reservation.ReservationTimeUnitStart, center.Id).ToLongTimeString(),
                UserId = user.Id,
                UserName = user.UserName
            };
        }


    }
}
