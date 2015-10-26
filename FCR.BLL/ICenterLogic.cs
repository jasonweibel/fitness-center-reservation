using System.Collections.Generic;
using FCR.DomainModel;

namespace FCR.BLL
{
    public interface ICenterLogic
    {
        List<FitnessCenter> GetCenterInfo();
    }
}