using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Machote_Formulario.Datos;
using Machote_Formulario.Entidad;



namespace Machote_Formulario.Negocio
{
    public class n_buscar_postulante
    {
        d_buscar_postulantes buscarPostulantes = new d_buscar_postulantes();
        d_eliminar_registro borrarRegistro = new d_eliminar_registro();
        d_ingreso_rubros ingresoPostulante = new d_ingreso_rubros();
        e_mantenimiento_postulante postulante = new e_mantenimiento_postulante();

        public DataTable buscar(e_mantenimiento_postulante postulante)
        {
            return buscarPostulantes.buscarPostulante(postulante);
        }

        public void ingresarRubros(e_mantenimiento_postulante postulante)
        {
            ingresoPostulante.ingresoDatos(postulante);
        }

        public void eliminarRegistro(e_mantenimiento_postulante postulante)
        {
            borrarRegistro.eliminarRegistro(postulante);
        }
    }
}