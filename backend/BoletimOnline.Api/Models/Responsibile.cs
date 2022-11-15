using System.ComponentModel.DataAnnotations;

namespace BoletimOnline.Api.Models;


public class Responsibile
{
    public int Id { get; set; }

    [Required] 
    public string Name { get; set; }
    
    [Required] 
    public string Cpf { get; set; }
    
    [Required] 
    public string Email { get; set; }


    public Responsibile(string name, string cpf, string email)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
    }
    
    public Responsibile()
    {
    
    }
}