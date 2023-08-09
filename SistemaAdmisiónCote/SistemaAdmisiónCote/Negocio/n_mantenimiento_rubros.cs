using MantenimientoDeRubros.Datos;
using MantenimientoDeRubros.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MantenimientoDeRubros.Negocio
{
    public class n_mantenimiento_rubros
    {
        d_mantenimiento_rubros D_Sistema_Admision = new d_mantenimiento_rubros();

        //Métodos que funcionan como mediador entre la clase Datos y la clase Entidad
        //Estos métodos reciben los valores que tienen los constructores de la clase entidad
        //y la enviamos hasta datos para ser utilizados
        public void reg(e_mantenimiento_rubros e_Sistema)
        {
            D_Sistema_Admision.EnvioDatos(e_Sistema);
        }
        public DataTable Tabla_Rubros(e_mantenimiento_rubros e_Sistema)
        {
            return D_Sistema_Admision.TablaRubros(e_Sistema);
        }
        public void Eliminar(e_mantenimiento_rubros e_Sistema)
        {
            D_Sistema_Admision.ElminarRubros(e_Sistema);
        }
        
    }
}