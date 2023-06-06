using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezEnfermeriaEscolarEntities context = new DL.AGutierrezEnfermeriaEscolarEntities())
                {
                    var query = context.AlumnosGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.Matricula = item.Matricula;
                            alumno.Nombre = item.Nombre;
                            alumno.ApellidoPaterno = item.ApellidoPaterno;
                            alumno.ApellidoMaterno = item.ApellidoMaterno;
                            alumno.FechaNacimiento = item.FechaNacimiento;
                            alumno.NombreCompleto = alumno.Matricula + "-" + alumno.Nombre + " " + alumno.ApellidoPaterno + " " + alumno.ApellidoMaterno;

                            result.Objects.Add(alumno);
                            result.Correct = true;
                        }

                    }

                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;

        }
    }
}
