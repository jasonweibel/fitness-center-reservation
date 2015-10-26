using System;
using System.Collections.Generic;
using System.Linq;
using FCR.DomainModel;

namespace FCR.BLL
{
    public class CenterLogic : ICenterLogic
    {
        private FCR.DAL.FCRContext _dal;

        public CenterLogic(FCR.DAL.FCRContext dal)
        {
            _dal = dal;
        }

        public List<FitnessCenter> GetCenterInfo()
        {
            return _dal.FitnessCenters.ToList();
        }

        public void SaveCenterInfo(FitnessCenter center)
        {
            var exists = _dal.FitnessCenters.FirstOrDefault(x => x.Id == center.Id);

            if (exists != null)
            {
                _dal.FitnessCenters.Add(center);
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
            _dal.SaveChanges();
        }

        public void DeleteCenterInfo(FitnessCenter center)
        {
            var exists = _dal.FitnessCenters.FirstOrDefault(x => x.Id == center.Id);

            if (exists == null)
            {
                throw new ApplicationException("You are bad!");
            }

            _dal.FitnessCenters.Remove(center);
            _dal.SaveChanges();
        }

    }
}