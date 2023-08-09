using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantenimientoDeRubros.Entidad
{
    public class E_SistemaAdmision
    {
        //Constructores que utiliza el proyecto
        public string Etapa { get; set; }
        public int Examen { get; set; }
        public int Entrevista { get; set; }
        public int Notas { get; set; }
        public int Estrategia { get; set; }
    }
}