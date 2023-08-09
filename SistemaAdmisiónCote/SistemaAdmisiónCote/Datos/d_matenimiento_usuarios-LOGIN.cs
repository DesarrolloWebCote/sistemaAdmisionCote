using sql_proyecto.entity;
using sql_proyecto.negotiation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace sql_proyecto.data
{
    public class d_matenimiento_usuarios
    {
        //se conecta con la base de datos usando un objeto
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings
            ["conexion"].ConnectionString);

        //metodo para extraer datos de la base para verificacion 
        public bool verificarExisteID(e_mantenimiento_usuarios ob_e_mantenimiento)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("VerificarID", conexion);

            //extrae los datos ingresados de la caja de texto y los anade al parametro 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombreUsuario", SqlDbType.NChar).Value = ob_e_mantenimiento.usuario;
            cmd.Parameters.Add("@contrasena", SqlDbType.NChar).Value = ob_e_mantenimiento.contrasena;

            //obtiene si existe o no el usuario y su tipo de acceso 
            SqlParameter resultado = new SqlParameter("@Resultado", SqlDbType.Bit);
            SqlParameter tipo = new SqlParameter("@id_tipoUsuario", SqlDbType.Int);

            resultado.Direction = ParameterDirection.Output;
            tipo.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultado);
            cmd.Parameters.Add(tipo);
            
            cmd.ExecuteNonQuery();
            conexion.Close();
            bool resultado_obtenido = (bool)cmd.Parameters["@Resultado"].Value;
            
            

            //verifica que el usuario exista en la base de datos 
            if (resultado_obtenido)
            {
                int tipo_obtenido = Convert.ToInt32(cmd.Parameters["@id_tipoUsuario"].Value);

                //verifica el tipo de acceso que tiene el usuario 
                if (tipo_obtenido == 1) 
                {
                    HttpContext.Current.Response.Redirect("WebForm2.aspx");

                }else if (tipo_obtenido == 2)
                {

                    HttpContext.Current.Response.Redirect("WebForm3.aspx");

                }

                return false;
                
            }
            else
            {
                return true;
            }
        }
    }
}