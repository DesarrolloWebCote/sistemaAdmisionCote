using sistemaAdmision_Reportes.Entidad;
using sistemaAdmision_Reportes.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace sistemaAdmision_Reportes.Negocio
{
    public class n_mantenimientoUsuarios
    {
        d_mantenimientoUsuarios ob_d_MantenimientoUsuarios = new d_mantenimientoUsuarios();                             //Tramita objetos entre la capa de datos y el aspx del lado del servidor
        public DataTable nBusqueda(e_mantenimientoUsuarios ob_e_mantenimientoUsuario)
        {
            return ob_d_MantenimientoUsuarios.ObtenerPostulantesClasificados(ob_e_mantenimientoUsuario);
        }
        public DataTable nBusquedaPorID(e_mantenimientoUsuarios ob_e_mantenimientoUsuario)
        {
            DataTable dt = ob_d_MantenimientoUsuarios.busquedaPostulante(ob_e_mantenimientoUsuario);
            return dt;
        }
    }
}