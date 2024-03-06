using classroom.models;
using classroom.Repository;
using classroom.Repository.Interface;
using classroom.services.Interface;
using classroom.services;

namespace classroom.services
{
    public class MaterialsService : IMaterialsRepo
    {
        private readonly IMaterialsRepo _materialrepo;
        private List<Materials> materialsList = new List<Materials>();

        public List<Materials> GetMaterialBycourseId(int CourseId)
        {
            return _materialrepo.GetMaterialBycourseId(CourseId);
        }

        public void CreateMaterial(Materials material)
        {
            _materialrepo.CreateMaterial(material);
        }

 
    }
}




