using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MantenimientoDeRubros.Entidad;
using MantenimientoDeRubros.Negocio;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MantenimientoDeRubros.Datos
{
    public class d_mantenimiento_rubros
    {
        //LLamamos a la cadena de conección del web.config, es decir, la cadena a la base de datos
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        //Método para el envío de los rubros a la base de datos
        public void EnvioDatos(e_mantenimiento_rubros e_Sistema)
        {
            //Indicamos el procedimineto almacenado a utilizar junto con la conexión
            SqlCommand cmd = new SqlCommand("GuardarRubros", con);
            //Abrimos la cadena de conexión
            con.Open();
            //Establecemos el tipo de comando que es un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Enviamos todos los parametros que reciben y se ocupan en la base de datos
            cmd.Parameters.Add("@Etapa", SqlDbType.Int).Value = e_Sistema.Etapa;
            cmd.Parameters.Add("@Examen", SqlDbType.Int).Value = e_Sistema.Examen;
            cmd.Parameters.Add("@Entrevista", SqlDbType.Int).Value = e_Sistema.Entrevista;
            cmd.Parameters.Add("@Notas", SqlDbType.Int).Value = e_Sistema.Notas;
            cmd.Parameters.Add("@Estrategia", SqlDbType.Int).Value = e_Sistema.Estrategia;
            //Obtenemos el valor del resultado que es un parametro de tipo output en la base de datos
            SqlParameter resultado = new SqlParameter("@Resultado", SqlDbType.Bit);
            resultado.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultado);
            //Ejecutamos la conexión
            cmd.ExecuteNonQuery();
            //Cerramos la cadena de conexión
            con.Close();
            //Variable de tipo booleano con el valor del resultado que se obtuvo en la consulta
            bool resultado_Obtenido = (bool)cmd.Parameters["@Resultado"].Value;
            //Validación de si los rubros ya exisen o aún no se han ingresado
            //Si el resultado es true o no existe, se muestra la alerta de que se ingresaron correctamente los datos
            if (resultado_Obtenido) { 
            //Alerta de que se ingresaron correctamente
            ScriptManager.RegisterStartupScript(HttpContext.Current.Handler as Page, typeof(Page), "alert", $"swal('Éxito!', 'Los rubros de evalucacion fueron agregados con exito', 'success');", true);
            }
            //Si el false los datos no se ingresan
            else
            {
                //Alerta de que ya existían los rubros de evaluación
                ScriptManager.RegisterStartupScript(HttpContext.Current.Handler as Page, typeof(Page), "alert", $"swal('Alto!', 'Debes eliminar las rubros de {e_Sistema.Etapa} para agregar nuevos', 'error');", true);
            }
        }
        //Método para mostrar los datos de los rubros de la base de datos en la tabla
        public DataTable TablaRubros(e_mantenimiento_rubros e_Sistema)
        {
            //Indicamos el procedimineto almacenado a utilizar junto con la conexión
            SqlCommand cmd = new SqlCommand("MostrarRubros", con);
            //Abrimos la conexión
            con.Open();
            //Establecemos el tipo de comando que es un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Creamos un objeto Adapter que funciona para ingresar los datos a la tabla
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //Ejecutamos la conexión
            cmd.ExecuteNonQuery();
            //Cerramos la conexión
            con.Close();
            //Creamos la tabla
            DataTable dt = new DataTable();
            //Cargamos los datos al adapter
            adapter.Fill(dt);
            //Retornamos los valores que tienen la tabla dt.
            return dt;
        }
        public void ElminarRubros(e_mantenimiento_rubros e_Sistema)
        {
            //Indicamos el procedimineto almacenado a utilizar junto con la conexión
            SqlCommand cmd = new SqlCommand("EliminarRubros", con);
            //Abrimos la conexion
            con.Open();
            //Establecemos el tipo de comando que es un procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            //Enviamos todos los parametros que reciben y se ocupan en la base de datos
            cmd.Parameters.Add("@Etapa", SqlDbType.Int).Value = e_Sistema.Etapa;
            //ejecutamos la conexión
            cmd.ExecuteNonQuery();
            //Cerramos la conexión
            con.Close();
            //Mostramos la alerta de que se eliminaron los datos.
            ScriptManager.RegisterStartupScript(HttpContext.Current.Handler as Page, typeof(Page), "alert", $"swal('Éxito!', 'Los rubros de la {e_Sistema.Etapa} fueron eliminados con exito', 'success');", true);
        }
    }
}