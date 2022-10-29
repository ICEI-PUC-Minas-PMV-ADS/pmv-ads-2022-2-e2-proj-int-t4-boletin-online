using System.ComponentModel.DataAnnotations;

namespace BoletimOnline.Api.Models;


public class Course
{
    public int Id { get; set; }

    [Required] public string Name { get; set; }


    public Course(string name)
    {
        Name = name;
    }
    
    public Course()
    {
    
    }
}
    
    
    
    
    