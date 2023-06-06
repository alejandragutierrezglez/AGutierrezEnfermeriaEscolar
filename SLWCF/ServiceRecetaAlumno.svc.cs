using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceRecetaAlumno" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceRecetaAlumno.svc o ServiceRecetaAlumno.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceRecetaAlumno : IServiceRecetaAlumno
    {
        public ML.Result GetAll()
        {
            ML.Result result = BL.RecetasAlumnos.GetAll();

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public ML.Result Add(ML.RecetaAlumno recetaAlumno)
        {
            ML.Result result = BL.RecetasAlumnos.Add(recetaAlumno);
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public ML.Result Update(ML.Receta receta)
        {
            ML.Result result = BL.Receta.Update(receta);
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
