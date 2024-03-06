using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace classroom.models
{
    public class Materials
    { 
        public string fileName { get; set; }
        public string filePath { get; set; }
        public int courseId { get; set; }
    }
}

