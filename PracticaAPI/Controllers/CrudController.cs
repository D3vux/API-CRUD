using API.Busines;
using Microsoft.AspNetCore.Mvc;
using API.Entity;
namespace PracticaAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CrudController : ControllerBase
    {
        private readonly IManagerCRUD _manager;

        public CrudController(IManagerCRUD manager)
        {
            _manager = manager;
        }
        [HttpPost("insertPeople")]
        [ProducesResponseType(typeof(Response<bool>), 200)]


    }

}
