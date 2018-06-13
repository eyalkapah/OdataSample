using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using OdataSample.App.Models;
using OdataSample.App.Services;
using OdataSample.App.Services.Interfaces;

namespace OdataSample.App.Controllers
{
    [ODataRoutePrefix("Groups")]
    public class GroupsOdataController : ODataController
    {
        public IRepository<Group> Set { get; set; }

        public GroupsOdataController(IUnitOfWork unitOfWork)
        {
            Set = unitOfWork.Groups;
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