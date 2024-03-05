using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IAssignmentRepo
    {
        public void CreateAssignment(Assignment assignment);
        public List<Assignment> GetAssignmentById(int id);
        void DeleteAssignment(int id);
        public List<Assignment> GetAssignments();

      
    }
}

