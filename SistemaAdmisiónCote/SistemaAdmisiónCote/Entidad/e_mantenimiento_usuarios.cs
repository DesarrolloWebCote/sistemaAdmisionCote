using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mantenimientoUsuarios.ENTIDAD
{
    public class e_mantenimiento_usuarios
    {
        //Definicion de getters y setters correspondientes al usuario
        public int identificacion { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int tipo_de_usuario { get; set; }
    }
}