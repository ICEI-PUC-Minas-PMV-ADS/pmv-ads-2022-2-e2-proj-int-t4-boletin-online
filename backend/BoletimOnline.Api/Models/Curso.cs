namespace BoletimOnline.Api.Models
{
    public class Curso
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Nota> Notas { get; set; }

    }
}
