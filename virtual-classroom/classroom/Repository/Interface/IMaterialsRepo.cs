using classroom.models;

namespace classroom.Repository.Interface
{
   
    public interface IMaterialsRepo
    {
         

        void CreateMaterial(Materials material);

        Materials GetMaterialBycourseId(int courseId);
    }
}
