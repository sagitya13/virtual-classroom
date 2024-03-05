using classroom.models;
using classroom.Repository;
using classroom.Repository.Interface;
using classroom.services.Interface;

namespace classroom.services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepo _assignmentService; 
        public AssignmentService(IAssignmentRepo assignmentService) {
            _assignmentService = assignmentService;

        }

        public void CreateAssignment(Assignment assignment)
        {
            _assignmentService.CreateAssignment(assignment);
            return;
        }

        
        public List<Assignment> GetAssignments()
        {
            return _assignmentService.GetAssignments();
        }

        

        void IAssignmentService.DeleteAssignment(int id)
        {
            _assignmentService.DeleteAssignment(id);
        }

       

        public List<Assignment> GetAssignmentById(int id)
        {
            return _assignmentService.GetAssignmentById(id);
        }
    }
    
}
