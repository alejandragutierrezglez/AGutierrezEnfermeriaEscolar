using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RecetaController : Controller
    {
        // GET: Receta
        [HttpGet]
        public ActionResult Form(int? IdRecetaAlumno)
        {
            ML.RecetaAlumno recetaAlumno = new ML.RecetaAlumno();
            recetaAlumno.Alumno = new ML.Alumno();

            ML.Result resultAlumnos = BL.Alumno.GetAll();

            if (IdRecetaAlumno == null)
            {
                recetaAlumno.Alumno.Alumnos = resultAlumnos.Objects;
                return View(recetaAlumno);
            }
            else
            {
                return View(recetaAlumno);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.RecetaAlumno recetaAlumno)
        {
            ML.Result result = new ML.Result();
            ML.Result resultAlumnos = BL.Alumno.GetAll();

            ServiceReferenceRecetaAlumno.ServiceRecetaAlumnoClient recetaAlumnoClient = new ServiceReferenceRecetaAlumno.ServiceRecetaAlumnoClient();
            result = recetaAlumnoClient.Add(recetaAlumno);

            if (result.Correct)
            {
                recetaAlumno.Alumno.Alumnos = resultAlumnos.Objects;
                return View(recetaAlumno);

            }
            else
            {

                return View(recetaAlumno);
            }
        }
    }
}