using sql_proyecto.data;
using sql_proyecto.entity;
using sql_proyecto.negotiation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace sql_proyecto
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        //objeto de la capa de negocio
        n_mantenimiento_usuarios ob_n_mantenimientoUsuario = new n_mantenimiento_usuarios();
        //objeto de la capa de entidad
        e_mantenimiento_usuarios ob_e_mantenimientoUsuario = new e_mantenimiento_usuarios();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e) 
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            //ingreso de nombre y contrasena del usuario para ingreso 
            ob_e_mantenimientoUsuario.usuario = TxtNombreUsuario.Text;
            ob_e_mantenimientoUsuario.contrasena = TxtContrasena.Text;
            ob_n_mantenimientoUsuario.nVerificaExistencia(ob_e_mantenimientoUsuario);

            //validacion y alerta para usuarios no validos 
            if (ob_n_mantenimientoUsuario.nVerificaExistencia(ob_e_mantenimientoUsuario))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'El usuario ingresado no es valido.', 'error')", true);
            }





        }
    }
}