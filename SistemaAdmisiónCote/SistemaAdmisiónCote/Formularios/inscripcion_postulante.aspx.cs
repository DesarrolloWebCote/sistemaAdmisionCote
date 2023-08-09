using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication6.Capa_Negocio;

namespace WebApplication6
{
    public partial class Figma : System.Web.UI.Page
    {
        n_mantenimiento_inscripcion negocio = new n_mantenimiento_inscripcion();
        e_encargado_postulante entidad = new e_encargado_postulante();

        protected void Page_Load(object sender, EventArgs e) { }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            entidad.identificacion = Convert.ToInt32(verificacion_id.Text);
            entidad.numero_postulante = Convert.ToInt32(consecutivo_num.Text);

            if (negocio.VerificarUser(entidad))
            {
                exampleModal.Visible = false;
                IdentificacionEs.Text = verificacion_id.Text;
                NumPos.Text = consecutivo_num.Text;
            }
            else
            {
                //Poner error en el placeholder de identificacion
                verificacion_id.Text = "";
                verificacion_id.Attributes["Placeholder"] = "Invalido";
                consecutivo_num.Text = "";
                consecutivo_num.Attributes["Placeholder"] = "Invalido";

                //Poner color rojo al placeholder
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            bool madreSeleccionada = chkEncargados.Items[0].Selected;
            // Verificar si el checkbox "Padre" está seleccionado
            bool padreSeleccionado = chkEncargados.Items[1].Selected;
            // Verificar si el checkbox "Encargado Legal" está seleccionado
            bool encargadoLegalSeleccionado = chkEncargados.Items[2].Selected;

            if (madreSeleccionada)
            {
                entidad.tipo_encargado = "Madre";
            }
            else if (padreSeleccionado)
            {
                entidad.tipo_encargado = "Padre";
            }
            else if (encargadoLegalSeleccionado)
            {
                entidad.tipo_encargado = "Encargado Legal";
            }
            else
            {
                // Display an alert using JavaScript
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Lo lamentamos', 'Por favor seleccione un encargado', 'warning')",
                    true
                );
                return; // Stop further execution if any field is empty
            }

            if (
                string.IsNullOrEmpty(IdentificacionEs.Text)
                || string.IsNullOrEmpty(NombreEs.Text)
                || string.IsNullOrEmpty(NombreEn.Text)
                || string.IsNullOrEmpty(NacionalidadEs.Text)
                || string.IsNullOrEmpty(FechaNacimientoEs.Text)
                || string.IsNullOrEmpty(SexoEs.Text)
                || string.IsNullOrEmpty(PrimerApellidoEs.Text)
                || string.IsNullOrEmpty(SegundoApellidoEs.Text)
                || string.IsNullOrEmpty(NumCelularEs.Text)
                || string.IsNullOrEmpty(CorreoElectronicoEs.Text)
                || string.IsNullOrEmpty(ColegioProcedencia.Text)
                || string.IsNullOrEmpty(PrimeraOpcion.Text)
                || string.IsNullOrEmpty(SegundaOpcion.Text)
                || string.IsNullOrEmpty(PrimerApellidoEn.Text)
                || string.IsNullOrEmpty(NumCelularEn.Text)
                || string.IsNullOrEmpty(TelefonoOpcionalEn.Text)
                || string.IsNullOrEmpty(OcupacionEn.Text)
                || string.IsNullOrEmpty(NumPos.Text)
            )
            {
                //Enfocar si algun campo esta vacio


                //Alert
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Lo lamentamos', 'Por favor llene todos los campos', 'warning')",
                    true
                );
                return;
            }

            entidad.identificacion = Convert.ToInt32(IdentificacionEs.Text);
            entidad.nombre = NombreEs.Text;
            entidad.nombre_en = NombreEn.Text;
            entidad.nacionalidad = NacionalidadEs.Text;
            entidad.fecha_nacimiento = FechaNacimientoEs.Text;
            entidad.sexo = SexoEs.Text;
            entidad.apellido = PrimerApellidoEs.Text;
            entidad.segundo_apellido = SegundoApellidoEs.Text;
            entidad.correo_electronico = CorreoElectronicoEs.Text;
            entidad.colegio_procedencia = ColegioProcedencia.Text;
            entidad.primera_opcion = PrimeraOpcion.Text;
            entidad.segunda_opcion = SegundaOpcion.Text;
            entidad.correo_electronico_en = CorreoElectronicoEs.Text;

            entidad.apellido_en = PrimerApellidoEn.Text;
            entidad.segundo_apellido_en = PrimerApellidoEn.Text;
            entidad.telefono_en = Convert.ToInt32(NumCelularEn.Text);
            entidad.telefono_op_en = Convert.ToInt32(TelefonoOpcionalEn.Text);
            entidad.ocupacion_en = OcupacionEn.Text;
            entidad.identificacion_usuario_en = Convert.ToInt32(IdentificacionEn.Text);
            entidad.numero_postulante = Convert.ToInt32(NumPos.Text);

            string result = negocio.GuardarForms(entidad);

            if (result == "Esta identificacion de estudiante ya existe")
            {
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Lo lamentamos', 'Esta identificacion ya existe', 'warning')",
                    true
                );
                return;
            }
            else if (result == "Esta identificacion de encargado ya existe")
            {
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Lo lamentamos', 'Esta identificacion de encargado ya existe', 'warning')",
                    true
                );
                return;
            }
            else if (result == "Este numero de postulante ya existe se encuentra inscrito")
            {
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Lo lamentamos', 'Este numero de postulante ya se encuentra inscrito', 'warning')",
                    true
                );

                return;
            }
            else if (result == "Este numero ya se encuentra en uso")
            {
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Lo lamentamos', 'Este numero se encuentra en uso', 'warning')",
                    true
                );
                return;
            }
            else if (result == "Success")
            {
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Hecho', 'Registro realizado correctamente', 'success')",
                    true
                );
            }
            else if (
                result
                == "La identificacion del estudiante no puede ser la misma que la del encargado"
            )
            {
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Lo lamentamos', 'La identificacion del estudiante no puede ser la misma que la del encargado', 'warning')",
                    true
                );
                return;
            }
            else if (result == "Las especialidades elegidas no pueden ser las mismas")
            {
                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "alert",
                    "swal('Lo lamentamos', 'Las especialidades tienen que ser distintas', 'warning')",
                    true
                );
                return;
            }
            else
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "alert",
                    "alert('Error');",
                    true
                );
                return;
            }

            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Hecho', 'Registro realizado satisfactoriamente', 'success')", true);



            negocio.CrearPdf(
                "D:\\Avance Proyecto\\WebApplication6\\Plantilla\\Plantilla.html",
                $"D:\\Avance Proyecto\\WebApplication6\\pdfs\\{NumPos.Text}-{IdentificacionEs.Text}.pdf",
                ColegioProcedencia.Text,
                PrimeraOpcion.Text,
                IdentificacionEs.Text,
                SegundaOpcion.Text,
                NombreEs.Text,
                NacionalidadEs.Text,
                FechaNacimientoEs.Text,
                PrimerApellidoEs.Text,
                SegundoApellidoEs.Text,
                SexoEs.Text,
                EdadEs.Text,
                NumCelularEs.Text,
                CorreoElectronicoEs.Text,
                IdentificacionEn.Text,
                OcupacionEn.Text,
                NombreEn.Text,
                NumCelularEn.Text,
                PrimerApellidoEn.Text,
                TelefonoOpcionalEn.Text,
                entidad.tipo_encargado
            );

            negocio.EnviarCorreo(
                CorreoElectronicoEs.Text,
                NombreEs.Text,
                PrimerApellidoEs.Text,
                $"D:\\Avance Proyecto\\WebApplication6\\pdfs\\{NumPos.Text}-{IdentificacionEs.Text}.pdf"
            );
        }
    }
}
