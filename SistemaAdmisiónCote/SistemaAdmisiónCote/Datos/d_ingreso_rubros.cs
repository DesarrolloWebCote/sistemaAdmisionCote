using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Machote_Formulario.Entidad;
using Machote_Formulario.Negocio;
using System.Data;
using System.Drawing;

namespace Machote_Formulario.Datos
{
    public class d_ingreso_rubros
    {
        //Conexion a la base de datos
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public void abrirConexion()
        {
            conexion.Open(); //Abre la base de datos para poder manipularla 
        }

        //Verifico la persona y saco su numero de postulante de la tabla de rubros
        public int verificarPersona(int valor)
        {
            SqlCommand comando = new SqlCommand("verificacion", conexion);

            abrirConexion();
            
            comando.CommandType = CommandType.StoredProcedure;

            //Le asigno el valor de la identificacion agregada
            comando.Parameters.Add("@identificacion", SqlDbType.Int).Value = valor;

            //Ejecuta el procedimiento y devuelve el promer valor encontrado 
            object resultado = comando.ExecuteScalar();

            if (resultado != null)
            {
                //Devuelvo el numero de postulante como parte de la verficacion de usuario y para asignarlo al momento de enviar los datos
                //a la tabla de rubros
                conexion.Close();
                return Convert.ToInt32(resultado.ToString());

            }
            else
            {
                conexion.Close();
                return 0;
            }
        }
        
        //En esta funcion se busca buscar un registro en base del numero de postulante 
        //obtenido en la funcion "verificarPersona"
        public int verificarRegistro(int numero)
        {
            SqlCommand comando = new SqlCommand("verificarRegistro", conexion);

            abrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@numPostulante", SqlDbType.Int).Value = numero;

            int resultado = Convert.ToInt32(comando.ExecuteScalar());

            if (resultado != 0)
            {
                //Este valor proveniente de la tabla de rubros sera comparado con 
                conexion.Close();
                return Convert.ToInt32(resultado.ToString());

            }
            else
            {
                conexion.Close();
                return 0;
            }
        }

        public bool ingresoDatos(e_mantenimiento_postulante ob_postulante) //Toma la informacion del constructor
        {
            SqlCommand comando = new SqlCommand("ingresarRubros", conexion);
            
            try
            {
                abrirConexion();
                //Ingreso los datos correspondientes
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@numPostulante", SqlDbType.Int).Value = ob_postulante.numeroPostulante;
                comando.Parameters.Add("@notas", SqlDbType.Int).Value = ob_postulante.notas;
                comando.Parameters.Add("@examen", SqlDbType.Int).Value = ob_postulante.examen;
                comando.Parameters.Add("@estrategia", SqlDbType.Int).Value = ob_postulante.estrategia;
                comando.Parameters.Add("@entrevista", SqlDbType.Int).Value = ob_postulante.entrevista;
                comando.ExecuteNonQuery(); //Ejecuta la consulta de Sql
                conexion.Close();
                Console.WriteLine("Add parameters Passed");
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}