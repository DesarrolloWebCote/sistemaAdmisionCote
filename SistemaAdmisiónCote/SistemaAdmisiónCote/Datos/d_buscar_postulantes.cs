using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Machote_Formulario.Entidad;
using System.Configuration;

namespace Machote_Formulario.Datos
{
    public class d_buscar_postulantes
    {
        //Conectar con la base de datos
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        //Funcion par buscar postulantes
        public DataTable buscarPostulante(e_mantenimiento_postulante ob_postulante)
        {
            //Metodo para devolver una tabla con los datos que se almacenan
            SqlCommand comando = new SqlCommand("busquedaPersona", conexion);

            //Abre la base de datos
            conexion.Open();

            comando.CommandType = CommandType.StoredProcedure;

            //Aca envio la identificacion al procedimiento almacenado para luego obtener los datos
            //correspondientes a la persona
            comando.Parameters.Add("@identificacion", SqlDbType.Int).Value = ob_postulante.identificacion;

            //Aca el SqlDataAdapter recupera guarda datos
            SqlDataAdapter datos = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();

            //Este metodo llena la tabla que se va a retirnar con los datos
            datos.Fill(tabla);
            
            //Este metodo cierra la base de datos
            conexion.Close();

            Console.WriteLine("Searching Passed");

            //Retorna la tabla con los datos
            return tabla;
        }
    }
}