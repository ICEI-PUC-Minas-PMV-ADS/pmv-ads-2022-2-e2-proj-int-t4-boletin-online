using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletimOnline.Api.Models
{
    public class Nota
    {
        [Key]
        public int Id_nota { get; set; }

        public float Vl_nota { get; set; }

        public string aluno { get; set; }

        public float VL_avaliacao_x { get; set; }

        public float VL_avaliacao_y { get; set; }

        public float VL_trabalho { get; set; }

        public float VL_atividades { get; set; }

        //public virtual Student Student { get; set; }
        //public int StudentId { get; set; }

        //public virtual Professor Professor { get; set; }
        //public int ProfessorId { get; set; }

        //public virtual Disciplina Disciplina { get; set; }
        //public int DisciplinaId { get; set; }

        //public virtual Curso Curso { get; set; }
        //public int CursoId { get; set; }
    }
}

