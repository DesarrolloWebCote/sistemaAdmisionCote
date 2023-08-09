using mantenimientoUsuarios.DATOS;
using mantenimientoUsuarios.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace mantenimientoUsuarios.NEGOCIO
{
    public class n_mantenimiento_usuarios
    {
        //Instancia de la clase de datos
        d_mantenimiento_usuarios capa_de_datos = new d_mantenimiento_usuarios();

        //Función para crear nuevo usuario
        public void nCrearUsuario(e_mantenimiento_usuarios objeto_nuevo_usuario)
        {
            capa_de_datos.crearUsuario(objeto_nuevo_usuario);
        }

        //Función para buscar un usuario existente
        public DataTable nBuscarUsuario(e_mantenimiento_usuarios objeto_usuario_existente)
        {
            return capa_de_datos.buscarUsuario(objeto_usuario_existente);
        }

        //Función para eliminar el usuario existente
        public void nEliminarUsuario(e_mantenimiento_usuarios objeto_usuario_existente)
        {
            capa_de_datos.eliminarUsuario(objeto_usuario_existente);
        }

        //Función para modificar un usuario existente
        public void nModificarUsuario(e_mantenimiento_usuarios objeto_usuario_existente)
        {
            capa_de_datos.modificarUsuario(objeto_usuario_existente);
        }

        //Función para verificar la existencia de un usuario
        public bool nVerificarUsuario(e_mantenimiento_usuarios objeto_usuario_existente)
        {
            return capa_de_datos.verificarUsuario(objeto_usuario_existente);
        }
    }
}