using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using OdataSample.App.Models;
using OdataSample.App.Services;
using OdataSample.App.Services.Interfaces;

namespace OdataSample.App.Controllers
{
    [ODataRoutePrefix("Teams")]
    public class TeamsOdataController : ODataController
    {
        public IRepository<Team> Set { get; set; }

        public TeamsOdataController(IUnitOfWork unitOfWork)
        {
            Set = unitOfWork.Teams;
        }

        [HttpGet]
        [ODataRoute]
        [EnableQuery]
        public IActionResult GetAll()
        {
            return Ok(Set.Queryable());
        }

        [HttpGet]
        [ODataRoute("{id}")]
        [EnableQuery]
        public ActionResult Get([FromODataUri] int id)
        {
            var entity = Set.Find(id);
            if (entity == null)
                return NotFound();

            return Ok(Set.Queryable().Where(t => t == entity));
        }


    }
}