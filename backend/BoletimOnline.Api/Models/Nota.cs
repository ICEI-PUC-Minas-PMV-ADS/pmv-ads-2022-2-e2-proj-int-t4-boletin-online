using System.ComponentModel.DataAnnotations;

namespace BoletimOnline.Api.Models
{
    public class Nota
    {
        [Key]
        public int Id_nota { get; set; }

        public float Vl_nota { get; set; }

        public virtual Student Student { get; set; }
        //public int Student { get; set; }

        public virtual Professor Professor { get; set; }
        //public int Professor { get; set; }

        public virtual Disciplina Disciplina { get; set; }
        //public int Disciplina { get; set; }

        public virtual Curso Curso { get; set; }
        //public int Curso { get; set; }
    }
}

