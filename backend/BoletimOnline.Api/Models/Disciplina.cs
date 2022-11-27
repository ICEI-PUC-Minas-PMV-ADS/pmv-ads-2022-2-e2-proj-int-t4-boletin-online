namespace BoletimOnline.Api.Models
{
    public class Disciplina
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Area { get; set; }


        public ICollection<Nota> Notas { get; set; }

    }
}
