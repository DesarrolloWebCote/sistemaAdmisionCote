using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using Ingreso_de_notas.Entidad;
using System.Data;

namespace Ingreso_de_notas.Datos
{
    //Clase D_mantenimiento.
    public class d_mantenimiento_notas
    {
        //Conexión con la base de datos.
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        
        //Función para obtener el número del postulante.
        public int busquedaIdPersona(e_mantenimiento_notas ob_Emantenimiento){
            conexion.Open();
            SqlCommand cmd = new SqlCommand("busquedaIdPersona", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@busquedaIdPersona", SqlDbType.Int).Value = ob_Emantenimiento.id_persona;
            int numPostulante =Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();
            return numPostulante;
            
        }
        //Función para obtener el nombre del postulante.
        public string busquedaNombrePostulante(e_mantenimiento_notas ob_Emantenimiento)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand("obtenerNombre", conexion);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@idPersona", SqlDbType.Int).Value = ob_Emantenimiento.id_persona;
            string nombrePostulante = Convert.ToString(cmd2.ExecuteScalar());
            conexion.Close();
            return nombrePostulante;
        }

        //Función para verificar la existencia de la identificación del postulante.
        public bool verificarIdPersona(e_mantenimiento_notas ob_Emantenimiento)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("verificarId", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = ob_Emantenimiento.id_persona;
            int verificacion = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();
            if(verificacion == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //Función para guardar las notas.
        public float guardarNotas(e_mantenimiento_notas ob_Emantenimiento)
        {
           
            SqlCommand cmd = new SqlCommand("guardarNotas", conexion);
            conexion.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NumPostulante", SqlDbType.Int).Value = ob_Emantenimiento.numPostulante;
            float espanol_8= Convert.ToSingle( cmd.Parameters.Add("@Espanol8", SqlDbType.Float).Value = ob_Emantenimiento.espanol_8);
            float espanol_9 = Convert.ToSingle(cmd.Parameters.Add("@Espanol9", SqlDbType.Float).Value = ob_Emantenimiento.espanol_9);
            float matematicas_8 = Convert.ToSingle(cmd.Parameters.Add("@Matematicas8", SqlDbType.Float).Value = ob_Emantenimiento.matematicas_8);
            float matematicas_9 = Convert.ToSingle(cmd.Parameters.Add("@Matematicas9", SqlDbType.Float).Value = ob_Emantenimiento.matematicas_9);
            float ciencias_8 = Convert.ToSingle(cmd.Parameters.Add("@Ciencias8", SqlDbType.Float).Value = ob_Emantenimiento.ciencias_8);
            float ciencias_9 = Convert.ToSingle(cmd.Parameters.Add("@Ciencias9", SqlDbType.Float).Value = ob_Emantenimiento.ciencias_9);
            float ingles_8 = Convert.ToSingle(cmd.Parameters.Add("@Ingles8", SqlDbType.Float).Value = ob_Emantenimiento.ingles_8);
            float ingles_9 = Convert.ToSingle(cmd.Parameters.Add("@Ingles9", SqlDbType.Float).Value = ob_Emantenimiento.ingles_9);
            float sociales_8 = Convert.ToSingle(cmd.Parameters.Add("@Sociales8", SqlDbType.Float).Value = ob_Emantenimiento.sociales_8);
            float sociales_9 = Convert.ToSingle(cmd.Parameters.Add("@Sociales9", SqlDbType.Float).Value = ob_Emantenimiento.sociales_9);
            float civica_8 = Convert.ToSingle(cmd.Parameters.Add("@Civica8", SqlDbType.Float).Value = ob_Emantenimiento.civica_8);
            float civica_9 = Convert.ToSingle(cmd.Parameters.Add("@Civica9", SqlDbType.Float).Value = ob_Emantenimiento.civica_9);
            float conducta_8 = Convert.ToSingle(cmd.Parameters.Add("@Conducta8", SqlDbType.Float).Value = ob_Emantenimiento.conducta_8);
            float conducta_9 = Convert.ToSingle(cmd.Parameters.Add("@Conducta9", SqlDbType.Float).Value = ob_Emantenimiento.conducta_9);
           cmd.ExecuteNonQuery();
            conexion.Close();
            float promedio = (espanol_8 + espanol_9 + matematicas_8 + matematicas_8 + matematicas_8 + matematicas_9 +
                 ingles_8 + ingles_9 + ciencias_8+ ciencias_9+ sociales_8 + sociales_9 + civica_8 + civica_9 + conducta_8 + conducta_9)/14;
            return promedio;
        }
        //Verifica si al postulante ya se le han ingresado las notas.
        public bool verificarPostulante(e_mantenimiento_notas ob_Emantenimiento)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("verificarPostulante", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@numPostulante", SqlDbType.Int).Value = ob_Emantenimiento.numPostulante;
            int verificacion = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();
            if (verificacion == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //Función para mostrar las notas existentes del postulante.
        public DataTable CargarNotas (e_mantenimiento_notas ob_Emantenimiento)
        {
            SqlCommand cmd = new SqlCommand("CargarNotas", conexion);
            conexion.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@numPostulante", SqlDbType.Int).Value = ob_Emantenimiento.numPostulante;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            conexion.Close();
            return dt;

        }
        //Función para modificar las notas del postulante.
        public float modificarNotas(e_mantenimiento_notas ob_Emantenimiento)
        {
            SqlCommand cmd = new SqlCommand("modificarNotas", conexion);
            conexion.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NumPostulante", SqlDbType.Int).Value = ob_Emantenimiento.numPostulante;
            float espanol_8 = Convert.ToSingle(cmd.Parameters.Add("@Espanol8", SqlDbType.Float).Value = ob_Emantenimiento.espanol_8);
            float espanol_9 = Convert.ToSingle(cmd.Parameters.Add("@Espanol9", SqlDbType.Float).Value = ob_Emantenimiento.espanol_9);
            float matematicas_8 = Convert.ToSingle(cmd.Parameters.Add("@Matematicas8", SqlDbType.Float).Value = ob_Emantenimiento.matematicas_8);
            float matematicas_9 = Convert.ToSingle(cmd.Parameters.Add("@Matematicas9", SqlDbType.Float).Value = ob_Emantenimiento.matematicas_9);
            float ciencias_8 = Convert.ToSingle(cmd.Parameters.Add("@Ciencias8", SqlDbType.Float).Value = ob_Emantenimiento.ciencias_8);
            float ciencias_9 = Convert.ToSingle(cmd.Parameters.Add("@Ciencias9", SqlDbType.Float).Value = ob_Emantenimiento.ciencias_9);
            float ingles_8 = Convert.ToSingle(cmd.Parameters.Add("@Ingles8", SqlDbType.Float).Value = ob_Emantenimiento.ingles_8);
            float ingles_9 = Convert.ToSingle(cmd.Parameters.Add("@Ingles9", SqlDbType.Float).Value = ob_Emantenimiento.ingles_9);
            float sociales_8 = Convert.ToSingle(cmd.Parameters.Add("@Sociales8", SqlDbType.Float).Value = ob_Emantenimiento.sociales_8);
            float sociales_9 = Convert.ToSingle(cmd.Parameters.Add("@Sociales9", SqlDbType.Float).Value = ob_Emantenimiento.sociales_9);
            float civica_8 = Convert.ToSingle(cmd.Parameters.Add("@Civica8", SqlDbType.Float).Value = ob_Emantenimiento.civica_8);
            float civica_9 = Convert.ToSingle(cmd.Parameters.Add("@Civica9", SqlDbType.Float).Value = ob_Emantenimiento.civica_9);
            float conducta_8 = Convert.ToSingle(cmd.Parameters.Add("@Conducta8", SqlDbType.Float).Value = ob_Emantenimiento.conducta_8);
            float conducta_9 = Convert.ToSingle(cmd.Parameters.Add("@Conducta9", SqlDbType.Float).Value = ob_Emantenimiento.conducta_9);
            cmd.ExecuteNonQuery();
            conexion.Close();
            float promedio = (espanol_8 + espanol_9 + matematicas_8 + matematicas_8 + matematicas_8 + matematicas_9 +
                 ingles_8 + ingles_9 + ciencias_8 + ciencias_9 + sociales_8 + sociales_9 + civica_8 + civica_9 + conducta_8 + conducta_9) / 14;
            return promedio;
        }
        //Función para eliminar las notas del postulante.
        public void EliminarNotas(e_mantenimiento_notas ob_Emantenimiento)
        {
            SqlCommand cmd = new SqlCommand("eliminarNotas", conexion);
            conexion.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NumPostulante", SqlDbType.Int).Value = ob_Emantenimiento.numPostulante;
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}