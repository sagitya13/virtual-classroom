using System.ComponentModel.DataAnnotations;

namespace classroom.models
{
    public class Student
    {
        public int? Id { get; set; }

 
        public int? UsersId { get; set; }

        
        public string Password { get; set; }
    }
}
