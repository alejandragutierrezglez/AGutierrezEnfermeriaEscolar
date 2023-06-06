using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceRecetaAlumno" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceRecetaAlumno
    {
        [OperationContract]
        ML.Result Add(ML.RecetaAlumno recetaAlumno);

        [OperationContract]
        ML.Result Update(ML.Receta receta);

        [OperationContract]
        [ServiceKnownType(typeof(ML.RecetaAlumno))]
        ML.Result GetAll();
    }
}
