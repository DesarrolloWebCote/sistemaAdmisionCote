using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using sistemaAdmision_Reportes.Entidad;

namespace sistemaAdmision_Reportes.Datos
{
    public class d_mantenimientoUsuarios
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);                              //Conexion con la base de datos por medio de la cadena de string

        public DataTable ObtenerPostulantesClasificados(e_mantenimientoUsuarios ob_e_mantenimientoUsuario)                                      //Metodo para obtener todos los parametros neceasarios de la base de datos por medio de la especialidad y variando la etapa
        {
            SqlCommand cmd = new SqlCommand("sp_ClasificarPostulantes", connect);
            connect.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@especialidad", SqlDbType.NVarChar).Value = ob_e_mantenimientoUsuario.esepecialType;                         // Paramettros del procedimiento almacenado      
            cmd.Parameters.Add("@etapa", SqlDbType.Int).Value = ob_e_mantenimientoUsuario.etapaType;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);                                                                                                                   //llena el datTable
            connect.Close();
            return dt;
        }
        public DataTable busquedaPostulante(e_mantenimientoUsuarios ob_e_mantenimientoUsuario)                                           //metodo para hacer la busqueda de un postulando especifico por ID
        {
            SqlCommand cmd = new SqlCommand("sp_buscarPostulante", connect);
            connect.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id_persona", SqlDbType.Int).Value = ob_e_mantenimientoUsuario.idUsuario;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.Close();
            return dt;                                                                                                                  // Solo retorna el datTable, con datos o vacios

        }
    }
}