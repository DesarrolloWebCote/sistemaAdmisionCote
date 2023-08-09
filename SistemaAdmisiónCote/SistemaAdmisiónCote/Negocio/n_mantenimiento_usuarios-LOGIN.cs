using sql_proyecto.data;
using sql_proyecto.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace sql_proyecto.negotiation
{
    //conecta el metodo de verificacion 
    public class n_mantenimiento_usuarios
    {
        d_matenimiento_usuarios ob_d_mantenimiento = new d_matenimiento_usuarios();
        public bool nVerificaExistencia(e_mantenimiento_usuarios ob_e_mantenimiento)
        {
            return ob_d_mantenimiento.verificarExisteID(ob_e_mantenimiento);
        }
          
        

    }
}