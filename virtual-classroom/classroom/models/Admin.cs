using System.ComponentModel.DataAnnotations;

namespace classroom.models
{
    public class Admin
    {
        public int AdminId { get; set; }

      
        public string AdminName { get; set; }
 
        public string PassWord { get; set; }
    }
}
