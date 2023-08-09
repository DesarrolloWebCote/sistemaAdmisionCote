using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAdmision_Reportes.Entidad
{
    public class e_mantenimientoUsuarios
    {
        //constructor que hila todos los parametros del aspx
        public int idUsuario { get; set; } //Constructor del la caja de texto "txt_ID"

        public string esepecialType { get; set; }   //constructor del downlist "list_Especialidad"

        public int etapaType { get; set; } //constructor del downlist "list_Etapa"
    }
}