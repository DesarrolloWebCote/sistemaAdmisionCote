using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Ingreso_de_notas.Datos;
using Ingreso_de_notas.Entidad;

namespace Ingreso_de_notas.Negocio
{
    //Clase N_mantenimiento.
    public class n_mantenimiento_notas
    {
       //Objeto para interactuar con las funciones de d_mantenimiento.
        d_mantenimiento_notas ob_dmantenimiento = new d_mantenimiento_notas();
        //Interacción con la clase d_mantenimiento y los constructores de la clase e_mantenimiento
        public bool nVerificarExistenciaId(e_mantenimiento_notas e_mantenimiento)
        {
            return ob_dmantenimiento.verificarIdPersona(e_mantenimiento);
        }
        public int nBusquedaNumPostulante(e_mantenimiento_notas e_mantenimiento)
        {
            return ob_dmantenimiento.busquedaIdPersona(e_mantenimiento);
        }

        public string nBusquedaNombre(e_mantenimiento_notas e_manteniento)
        {
            return ob_dmantenimiento.busquedaNombrePostulante(e_manteniento);
        }
        public float nGuardarNotas(e_mantenimiento_notas e_mantenimiento)
        {
            return ob_dmantenimiento.guardarNotas(e_mantenimiento);
        }
        public bool nVerficarPostulante(e_mantenimiento_notas e_mantenimiento)
        {
            return ob_dmantenimiento.verificarPostulante(e_mantenimiento);
        }
        public DataTable nCargarNotas(e_mantenimiento_notas e_mantenimiento)
        {
            return ob_dmantenimiento.CargarNotas(e_mantenimiento);
        }
        public float nModificarNotas(e_mantenimiento_notas e_mantenimiento)
        {
            return ob_dmantenimiento.modificarNotas(e_mantenimiento);
        }
        public void nEliminarNotas(e_mantenimiento_notas e_mantenimiento)
        {
             ob_dmantenimiento.EliminarNotas(e_mantenimiento);
        }   
    }
}