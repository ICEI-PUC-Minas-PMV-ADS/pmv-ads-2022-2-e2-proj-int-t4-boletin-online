using System.ComponentModel.DataAnnotations;

namespace BoletimOnline.Api.Models;


public class Student
{
    public int Id { get; set; }
    
    [Required]
    public int IdResponsibile { get; set; }
    
    [Required]
    public int Enrollment { get; set; }
    
    [Required]
    public string Name { get; set; }    
    
    [Required]

    public int IdCourse { get; set; }
    
    
    public Student(int id, int idResponsibile, int enrollment, string name, int idCourse)
    {
        Id = id;
        IdResponsibile = idResponsibile;
        Enrollment = enrollment;
        Name = name;
        IdCourse = idCourse;
    }
    
    public Student(int idResponsibile, int enrollment, string name, int idCourse)
    {
        IdResponsibile = idResponsibile;
        Enrollment = enrollment;
        Name = name;
        IdCourse = idCourse;
    }
    
    public Student()
    {
    
    }
}