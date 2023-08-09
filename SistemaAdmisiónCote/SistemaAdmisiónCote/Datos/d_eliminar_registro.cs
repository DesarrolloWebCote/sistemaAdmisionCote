using Machote_Formulario.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Machote_Formulario.Datos
{
    public class d_eliminar_registro
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public void eliminarRegistro(e_mantenimiento_postulante postulante)
        {
            SqlCommand comando = new SqlCommand("eliminarRegistro", conexion);

            conexion.Open();

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@eliminarRubros", SqlDbType.Int).Value = postulante.numeroPostulante;
            comando.ExecuteNonQuery();
            conexion.Close();

            Console.WriteLine("Deleting Passed");
        }

    }
}