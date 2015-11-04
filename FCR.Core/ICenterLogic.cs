using System.Collections.Generic;
using FCR.DomainModel;

namespace FCR.BLL
{
    public interface ICenterLogic
    {
        List<FitnessCenter> GetCenterInfo();
        void SaveCenterInfo(FitnessCenter center);
        void DeleteCenterInfo(FitnessCenter center);
        void DeleteCenterInfo(int centerId);
    }
}