using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace classroom.models
{
    
        public class course
        {
            [Key]
             
            public int id { get; set; }

        
            public string name { get; set; }
 
            
          
            public string description { get; set; }

             
            public int Material_id { get; set; }

            

             
            public int teacher_id { get; set; }

        
            public string type { get; set; }
   
            public DateTime date { get; set; }

        
            public TimeSpan start_time { get; set; }

 

        public int Student_id { get; set; }
        }
       
    
}
