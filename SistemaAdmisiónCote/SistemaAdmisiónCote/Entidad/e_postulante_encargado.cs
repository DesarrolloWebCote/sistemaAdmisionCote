using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6
{
    public class e_mantenimiento_usuario
    {
        //Crear constructor de postulante con getters y setters
     
            public string correo_electronico { get; set; }
            public string colegio_procedencia { get; set; }
            public string primera_opcion { get; set; }
            public string segunda_opcion { get; set; }
            public int identificacion { get; set; }
            public string nacionalidad { get; set; }
            public string nombre { get; set; }
            public int edad { get; set; }
            public string sexo { get; set; }
            public string apellido { get; set; }
            public string segundo_apellido { get; set; }
            public int telefono { get; set; }
            public string fecha_nacimiento { get; set; }
            public string correo_electronico_en { get; set; }
            public int identificacion_usuario_en { get; set; }
	        public string ocupacion_en { get; set; }
	        public string nombre_en { get; set; }
	        public string apellido_en { get; set; }
	        public string segundo_apellido_en { get; set; }
	        public int telefono_en { get; set; }
	        public int telefono_op_en { get; set; }
	        public int numero_postulante { get; set; }
	        public string tipo_encargado { get; set; }
            
    }
}