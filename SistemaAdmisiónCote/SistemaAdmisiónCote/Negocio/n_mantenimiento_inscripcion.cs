using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication6.Capa_Negocio
{
    public class n_mantenimiento_inscripcion
    {
        d_mantenimiento_inscripcion dato_entidad = new d_mantenimiento_inscripcion();

        public string GuardarForms(e_encargado_postulante entidad_Mantenimiento)
        {
            return dato_entidad.GuardarForms(entidad_Mantenimiento);
        }

        public bool VerificarUser(e_encargado_postulante entitidad_Mantenimiento)
        {
            return dato_entidad.Verificar(entitidad_Mantenimiento);
        }

        public void CrearPdf(
            string ruta_archivo_html,
            string ruta_archivo_pdf,
            string colegio_procedencia,
            string primera_opcion,
            string id_estudiante,
            string segunda_opcion,
            string nombre,
            string nacionalidad,
            string fecha_nacimiento,
            string primer_apellido,
            string segundo_apellido,
            string sexo,
            string edad,
            string telefono,
            string correo,
            string identificacion_encargado,
            string ocupacion_encargado,
            string nombre_encargado,
            string celular_encargado,
            string apellido_encargado,
            string telefono_encargado,
            string tipo_encargado
        )
        {
            dato_entidad.ConvertirHTMLaPDFDesdeArchivo(
                ruta_archivo_html,
                ruta_archivo_pdf,
                colegio_procedencia,
                primera_opcion,
                id_estudiante,
                segunda_opcion,
                nombre,
                nacionalidad,
                fecha_nacimiento,
                primer_apellido,
                segundo_apellido,
                sexo,
                edad,
                telefono,
                correo,
                identificacion_encargado,
                ocupacion_encargado,
                nombre_encargado,
                celular_encargado,
                apellido_encargado,
                telefono_encargado,
                tipo_encargado
            );
        }

        public void EnviarCorreo(
            string correo,
            string nombre,
            string apellido,
            string ruta_archivo_adjunto
        )
        {
            dato_entidad.EnviarCorreo(correo, nombre, apellido, ruta_archivo_adjunto);
        }
    }
}
