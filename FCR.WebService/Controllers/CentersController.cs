using System.Linq;
using System.Web.Http;
using FCR.BLL;
using FCR.DAL;

namespace FCR.WebService.Controllers
{
    [RoutePrefix("api/centers")]
    public class CentersController : BaseApiController
    {
        private readonly ICenterLogic _centerLogic;

        public CentersController()
        {
            _centerLogic = new CenterLogic(new FCRContext());
        }

        public CentersController(ICenterLogic centerLogic)
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

        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}