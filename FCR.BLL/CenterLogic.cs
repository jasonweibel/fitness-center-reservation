using System;
using System.Collections.Generic;
using System.Linq;
using FCR.DomainModel;

namespace FCR.BLL
{
    public class CenterLogic : ICenterLogic
    {
        private readonly DAL.IFCRContext _entities;

        public CenterLogic(DAL.IFCRContext entities)
        {
            _entities = entities;
        }

        public List<FitnessCenter> GetCenterInfo()
        {
            return _entities.FitnessCenters.ToList();
        }

        public void SaveCenterInfo(FitnessCenter center)
        {
            var exists = _entities.FitnessCenters.FirstOrDefault(x => x.Id == center.Id);

            if (exists != null)
            {
                _entities.FitnessCenters.Add(center);
            }
            else
            {
                exists.CenterDescription = center.CenterDescription;
                exists.MaxConcurrentUnits = center.MaxConcurrentUnits;
                exists.MaxDaysOutForReservation = center.MaxDaysOutForReservation;
                exists.OperationTimeUnitLength = center.OperationTimeUnitLength;
                exists.OperationTimeUnitStart = center.OperationTimeUnitStart;
                exists.UnitIntervalMinutes = center.UnitIntervalMinutes;
            }
            _entities.SaveChanges();
        }

        public void DeleteCenterInfo(int centerId)
        {
            var center = _entities.FitnessCenters.FirstOrDefault(x => x.Id == centerId);

            if (center == null)
            {
                throw new ApplicationException("You are bad!");
            }

            DeleteCenterInfo(center);
        }

        public void DeleteCenterInfo(FitnessCenter center)
        {
            var exists = _entities.FitnessCenters.FirstOrDefault(x => x.Id == center.Id);

            if (exists == null)
            {
                throw new ApplicationException("You are bad!");
            }

            _entities.FitnessCenters.Remove(center);
            _entities.SaveChanges();
        }

    }
}