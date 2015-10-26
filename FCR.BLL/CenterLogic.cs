using System.Collections.Generic;
using FCR.DomainModel;

namespace FCR.BLL
{
    public class CenterLogic : ICenterLogic
    {
        

        public List<FitnessCenter> GetCenterInfo()
        {
            return new List<FitnessCenter>() {new FitnessCenter() {Id = 1, CenterDescription = "Test" } };
        }
    }
}