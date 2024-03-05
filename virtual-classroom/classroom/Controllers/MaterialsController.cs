using classroom.models;
using classroom.Repository;
using classroom.Repository.Interface;
using classroom.services;
using classroom.services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialsRepo _materialsRepo;

        public MaterialsController(IMaterialsRepo materialsRepo)
        {
            _materialsRepo = materialsRepo;
        }

        // GET: api/Materials/5
        [HttpGet("{courseId}")]
        public ActionResult<Materials> GetMaterialBycourseId(int courseId)
        {
            var material = _materialsRepo.GetMaterialBycourseId(courseId);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // POST: api/Materials
        [HttpPost]
        public ActionResult<Materials> CreateMaterial(Materials material)
        {
            _materialsRepo.CreateMaterial(material);

            return Ok("material added");
        }

      
        

        // GET: api/Materials
       /* [HttpGet]
        public ActionResult<IEnumerable<Materials>> GetAllMaterials()
        {
            return Ok(_materialsRepo.GetAllMaterials());
        }*/
    }
}

      
