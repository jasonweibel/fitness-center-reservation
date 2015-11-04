using System.Linq;
using System.Web.Http;
using FCR.BLL;
using FCR.DomainModel;

namespace FCR.WebService.Controllers
{
    [RoutePrefix("api/centers")]
    public class CenterController : BaseApiController
    {
        private readonly ICenterLogic _centerLogic;

        public CenterController(ICenterLogic centerLogic)
        {
            _centerLogic = centerLogic;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_centerLogic.GetCenterInfo());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_centerLogic.GetCenterInfo().FirstOrDefault(x => x.Id == id));
        }

        public IHttpActionResult Post([FromBody]FitnessCenter value)
        {
            _centerLogic.SaveCenterInfo(value);
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody]FitnessCenter value)
        {
            _centerLogic.SaveCenterInfo(value);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            _centerLogic.DeleteCenterInfo(id);
            return Ok();
        }
    }
}