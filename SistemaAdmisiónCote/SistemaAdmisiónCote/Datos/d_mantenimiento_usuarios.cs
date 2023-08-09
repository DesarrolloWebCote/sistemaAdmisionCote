using mantenimientoUsuarios.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace mantenimientoUsuarios.DATOS
{
    public class d_mantenimiento_usuarios
    {
        //Conexión con la base de datos
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        //Función para crear (guardar el usuario en la base de datos)
        public void crearUsuario(e_mantenimiento_usuarios objeto_nuevo_usuario)
        {
            //Conexión con el procedimiento almacenado de creación de usuario
            SqlCommand comandos = new SqlCommand("crearUsuario", conexion);

            //Apertura de la secuencia de comandos
            conexion.Open();
            //Definición del tipo de comando (procedimiento almacenado)
            comandos.CommandType = CommandType.StoredProcedure;
            //Adición de los datos a la base de datos
            comandos.Parameters.Add("@IDENTIFICACION", SqlDbType.Int).Value = objeto_nuevo_usuario.identificacion;
            comandos.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = objeto_nuevo_usuario.nombre;
            comandos.Parameters.Add("@PRIMER_APELLIDO", SqlDbType.NVarChar).Value = objeto_nuevo_usuario.primer_apellido;
            comandos.Parameters.Add("@SEGUNDO_APELLIDO", SqlDbType.NVarChar).Value = objeto_nuevo_usuario.segundo_apellido;
            comandos.Parameters.Add("@TELEFONO_RESIDENCIA", SqlDbType.Int).Value = 0;
            comandos.Parameters.Add("@TELEFONO_CELULAR", SqlDbType.Int).Value = 0;
            comandos.Parameters.Add("@NOMBRE_USUARIO", SqlDbType.NVarChar).Value = objeto_nuevo_usuario.usuario;
            comandos.Parameters.Add("@CONTRASENA", SqlDbType.NVarChar).Value = objeto_nuevo_usuario.contrasena;
            comandos.Parameters.Add("@TIPO_USUARIO", SqlDbType.Int).Value = objeto_nuevo_usuario.tipo_de_usuario;
            //Ejecucion del procedimiento almacenado
            comandos.ExecuteNonQuery();
            //Cierre de la secuencia de comandos
            conexion.Close();
        }

        //Función para buscar los datos del usuario según la identificación
        public DataTable buscarUsuario(e_mantenimiento_usuarios objeto_usuario_existente)
        {
            //Conexión con el procedimiento almacenado de creación de usuario
            SqlCommand comandos = new SqlCommand("buscarUsuario", conexion);

            //Apertura de la secuencia de comandos
            conexion.Open();
            //Definición del tipo de comando (procedimiento almacenado)
            comandos.CommandType = CommandType.StoredProcedure;
            //Búsqueda de la información con identificacion
            comandos.Parameters.Add("@IDENTIFICACION", SqlDbType.Int).Value = objeto_usuario_existente.identificacion;
            //Ejecucion del procedimiento almacenado
            comandos.ExecuteNonQuery();
            //Cierre de la secuencia de comandos
            conexion.Close();

            //Crear la tabla con los datos devueltos por la búsqueda
            SqlDataAdapter adaptador = new SqlDataAdapter(comandos);
            DataTable tabla_de_datos = new DataTable();
            //LLenar la tabla con los datos encontrados
            adaptador.Fill(tabla_de_datos);

            //Retornar la tabla con los valores encontrados
            return tabla_de_datos;
        }

        //Función para eliminar los datos del usuario
        public void eliminarUsuario(e_mantenimiento_usuarios objeto_usuario_existente)
        {
            //Conexión con el procedimiento almacenado de creación de usuario
            SqlCommand comandos = new SqlCommand("eliminarUsuario", conexion);

            //Apertura de la secuencia de comandos
            conexion.Open();
            //Definición del tipo de comando (procedimiento almacenado)
            comandos.CommandType = CommandType.StoredProcedure;
            //Búsqueda de la información con identificacion
            comandos.Parameters.Add("@IDENTIFICACION", SqlDbType.Int).Value = objeto_usuario_existente.identificacion;
            //Ejecucion del procedimiento almacenado
            comandos.ExecuteNonQuery();
            //Cierre de la secuencia de comandos
            conexion.Close();
        }

        //Función para modificar los datos ya existentes
        public void modificarUsuario(e_mantenimiento_usuarios objeto_usuario_existente)
        {
            //Conexión con el procedimiento almacenado de modificacion de datos
            SqlCommand comandos = new SqlCommand("modificarUsuario", conexion);

            //Apertura de la secuencia de comandos
            conexion.Open();
            //Definición del tipo de comando (procedimiento almacenado)
            comandos.CommandType = CommandType.StoredProcedure;
            //Búsqueda de la información con identificación
            comandos.Parameters.Add("@IDENTIFICACION", SqlDbType.Int).Value = objeto_usuario_existente.identificacion;
            comandos.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = objeto_usuario_existente.nombre;
            comandos.Parameters.Add("@PRIMER_APELLIDO", SqlDbType.NVarChar).Value = objeto_usuario_existente.primer_apellido;
            comandos.Parameters.Add("@SEGUNDO_APELLIDO", SqlDbType.NVarChar).Value = objeto_usuario_existente.segundo_apellido;
            comandos.Parameters.Add("@NOMBRE_USUARIO", SqlDbType.NVarChar).Value = objeto_usuario_existente.usuario;
            comandos.Parameters.Add("@CONTRASENA", SqlDbType.NVarChar).Value = objeto_usuario_existente.contrasena;
            comandos.Parameters.Add("@TIPO_USUARIO", SqlDbType.Int).Value = objeto_usuario_existente.tipo_de_usuario;
            //Ejecución del procedimiento almacenado
            comandos.ExecuteNonQuery();
            //Cierre de la secuencia de comandos
            conexion.Close();
        }

        //Función para verficar que un usuario existe
        public bool verificarUsuario(e_mantenimiento_usuarios objeto_usuario_existente)
        {
            //Conexión con el procedimiento almacenado de creación de usuario
            SqlCommand comandos = new SqlCommand("verificarUsuario", conexion);

            //Apertura de la secuencia de comandos
            conexion.Open();
            //Definición del tipo de comando (procedimiento almacenado)
            comandos.CommandType = CommandType.StoredProcedure;
            //Búsqueda de la información con identificacion
            comandos.Parameters.Add("@IDENTIFICACION", SqlDbType.Int).Value = objeto_usuario_existente.identificacion;
            //Ejecucion del procedimiento almacenado
            int verificacion = Convert.ToInt32(comandos.ExecuteScalar());
            //Cierre de la secuencia de comandos
            conexion.Close();

            //Si la verificación es un número mayor a 0, es decir, si la consulta encontró
            //resultados se devuelve verdadero
            if(verificacion > 0)
            {
                return true;
            //Si la consulta no encontró resultados devuelve falso
            } else
            {
                return false;
            }
        }
    }
}