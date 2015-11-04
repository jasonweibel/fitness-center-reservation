using System.Collections.Generic;
using System.Linq;
using FCR.Core;
using FCR.DAL;
using FCR.DomainModel;
using FCR.WebApiModel;

namespace FCR.BLL
{
    public class EquipmentLogic : IEquipmentLogic
    {
        private readonly IFCRContext _entities;

        public EquipmentLogic(IFCRContext entities)
        {
            _entities = entities;
        }

        public List<EquipmentForCenter> GetEquipmentForFitnessCenter(int fitnessCenterId)
        {
            var equipment = _entities.Resources
                .Where(x => x.FitnessCenter.Id == fitnessCenterId)
                .ToList();

            var results = new List<EquipmentForCenter>();
            equipment.ForEach(x =>
            {
                results.Add(MapEquipmentData(x));
            });

            return results;
        }

        public EquipmentForCenter GetEquipmentById(int equipmentId)
        {
            var equipment = _entities.Resources.First(x => x.Id == equipmentId);
            return MapEquipmentData(equipment);
        }

        public List<EquipmentForCenter> GetAllEquipment()
        {
            var equipment = _entities.Resources.ToList();

            var results = new List<EquipmentForCenter>();

            equipment.ForEach(x =>
            {
                results.Add(MapEquipmentData(x));
            });

            return results;
        }

        private static EquipmentForCenter MapEquipmentData(Resource x)
        {
            var row = new EquipmentForCenter
            {
                Id = x.Id,
                FitnessCenterId = x.FitnessCenter.Id,
                Name = x.ResourceName,
                TypeId = x.ResourceType.Id,
                TypeDesc = x.ResourceType.ResourceTypeDescription,
                FullName = x.ResourceDescription
            };

            return row;
        }
    }
}
