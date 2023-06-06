using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class RecetaAlumno
    {
        public int IdRecetaAlumno { get; set; }
        public ML.Receta Receta { get; set; }
        public ML.Alumno Alumno { get; set; }
        public List<object> RecetasAlumnos { get; set; }

    }
}
