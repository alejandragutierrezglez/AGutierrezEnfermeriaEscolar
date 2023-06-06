using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RecetasAlumnos
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezEnfermeriaEscolarEntities context = new DL.AGutierrezEnfermeriaEscolarEntities())
                {
                    var query = context.RecetasAlumnosGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.RecetaAlumno recetaAlumno = new ML.RecetaAlumno();
                            recetaAlumno.IdRecetaAlumno = item.IdRecetasAlumnos;
                            recetaAlumno.Receta = new ML.Receta();
                            recetaAlumno.Receta.IdReceta = item.IdReceta.Value;

                            recetaAlumno.Alumno = new ML.Alumno();
                            recetaAlumno.Alumno.Matricula = item.Matricula;
                            recetaAlumno.Alumno.Nombre = item.Nombre;
                            recetaAlumno.Alumno.ApellidoPaterno = item.ApellidoPaterno;
                            recetaAlumno.Alumno.ApellidoMaterno = item.ApellidoMaterno;
                            recetaAlumno.Alumno.FechaNacimiento = item.FechaNacimiento;
                            recetaAlumno.Alumno.NombreCompleto = recetaAlumno.Alumno.Matricula + "-" + recetaAlumno.Alumno.Nombre + " " + recetaAlumno.Alumno.ApellidoPaterno + " " + recetaAlumno.Alumno.ApellidoMaterno;
                         


                            result.Objects.Add(recetaAlumno);
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
        public static ML.Result Add(ML.RecetaAlumno recetaAlumno)
        { 
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezEnfermeriaEscolarEntities context = new DL.AGutierrezEnfermeriaEscolarEntities())
                {
                    var query = context.RecetaAdd(recetaAlumno.Receta.Fecha, recetaAlumno.Receta.Diagnostico, recetaAlumno.Receta.Tratamiento, recetaAlumno.Receta.IdReceta, recetaAlumno.Alumno.Matricula);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else 
                    { 
                        result.Correct= false;
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
