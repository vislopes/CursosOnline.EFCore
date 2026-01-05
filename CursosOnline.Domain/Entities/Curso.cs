using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosOnline.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
