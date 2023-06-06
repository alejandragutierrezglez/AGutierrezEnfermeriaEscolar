using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RecetaAlumnoController : Controller
    {
        // GET: RecetaAlumno
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            ML.RecetaAlumno recetaAlumno = new ML.RecetaAlumno();
            ML.Result resultAlumnos = BL.Alumno.GetAll();
            recetaAlumno.Alumno = new ML.Alumno();

            ServiceReferenceRecetaAlumno.ServiceRecetaAlumnoClient recetaAlumnoClient = new ServiceReferenceRecetaAlumno.ServiceRecetaAlumnoClient();
            result = recetaAlumnoClient.GetAll();
            if (result.Correct)
            {
                recetaAlumno.Alumno.Alumnos = resultAlumnos.Objects;
                recetaAlumno.RecetasAlumnos = result.Objects;
                return View(recetaAlumno);
            }
            else
            {
                return View(recetaAlumno);
            }
        }
       


    }
}