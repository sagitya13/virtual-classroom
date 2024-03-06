using classroom.models;

namespace classroom.services.Interface
{
    public interface IMaterialsService
    {

        void CreateMaterial(Materials material);

        List<Materials> GetMaterialBycourseId(int courseId);
    }
}

