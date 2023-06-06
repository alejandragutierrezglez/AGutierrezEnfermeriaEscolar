using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Receta
    {
        public static ML.Result Update(ML.Receta receta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezEnfermeriaEscolarEntities context = new DL.AGutierrezEnfermeriaEscolarEntities())
                {
                    var query = context.RecetaUpdate(receta.IdReceta, receta.Fecha, receta.Diagnostico, receta.Tratamiento);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
