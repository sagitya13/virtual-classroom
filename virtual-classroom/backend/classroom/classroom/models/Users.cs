using classroom.models;
using System.ComponentModel.DataAnnotations;

namespace classroom.models
{
    public class Users
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }

    }



