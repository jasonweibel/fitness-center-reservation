using System.Web.Http;
using FCR.Core;

namespace FCR.WebService.Controllers
{
    [RoutePrefix("api/equipment")]
    public class EquipmentController : BaseApiController
    {
        private readonly IEquipmentLogic _equipmentLogic;

        public EquipmentController(IEquipmentLogic equipmentLogic)
        {
            _equipmentLogic = equipmentLogic;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_equipmentLogic.GetAllEquipment());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_equipmentLogic.GetEquipmentById(id));
        }

    }
}
