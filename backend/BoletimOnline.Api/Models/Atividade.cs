using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletimOnline.Api.Models
{
    public class Atividade
    {
        [Key]
        public int Id { get; set; }
        
        public int DisciplinaId { get; set; }
        
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }

        public int StudentId { get; set; }
        
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        
        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }

        public string Tipo { get; set; }

        public decimal Nota { get; set; }

        public int Etapa { get; set; }



    }
}

