using classroom.models;

namespace classroom.services.Interface
{
    public interface IAssignmentService
    {

        void CreateAssignment(Assignment assignment);
        List<Assignment> GetAssignmentById(int id);
        void DeleteAssignment(int id);
        List<Assignment> GetAssignments();
    }
}

