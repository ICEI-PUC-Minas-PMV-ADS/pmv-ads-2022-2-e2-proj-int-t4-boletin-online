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
    
    [Required] 
    public string Login { get; set; }
    
    [Required] 
    public string Password { get; set; }


    public Responsibile(string name, string cpf, string email, string login, string password)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
        Login = login;
        Password = password;
    }
    
    public Responsibile()
    {
    
    }
}