using System.Collections.Generic;
using FCR.WebApiModel;

namespace FCR.Core
{
    public interface IEquipmentLogic
    {
        List<EquipmentForCenter> GetEquipmentForFitnessCenter(int fitnessCenterId);
        EquipmentForCenter GetEquipmentById(int equipmentId);
        List<EquipmentForCenter> GetAllEquipment();

    }
}