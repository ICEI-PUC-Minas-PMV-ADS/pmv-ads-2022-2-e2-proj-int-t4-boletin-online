using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletimOnline.Api.Models
{
    public class CursoDisciplina
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }

        [ForeignKey("StudentId")]
        public Curso disciplina { get; set; }
    }
}
