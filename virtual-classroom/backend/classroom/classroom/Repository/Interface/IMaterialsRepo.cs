using classroom.models;

namespace classroom.Repository.Interface
{
   
    public interface IMaterialsRepo
    {
          
        void CreateMaterial(Materials material);

        List<Materials> GetMaterialBycourseId(int courseId);
    }
}
