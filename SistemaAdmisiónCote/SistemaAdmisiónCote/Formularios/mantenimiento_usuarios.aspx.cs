using mantenimientoUsuarios.NEGOCIO;
using mantenimientoUsuarios.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mantenimientoUsuarios
{
    public partial class Mantenimiento_usuarios : System.Web.UI.Page
    {
        //Método inicial al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Adición del evento de servidor para el botón de búsqueda
            btnBuscar.ServerClick += new EventHandler(this.buscarUsuarioClick);
        }

        //Instancia de la clase de datos
        n_mantenimiento_usuarios capa_de_negocio = new n_mantenimiento_usuarios();
        //Instancia de la clase de negocio
        e_mantenimiento_usuarios capa_de_entidad = new e_mantenimiento_usuarios();

        //Método de click para crear usuario
        protected void btnGuardarClick(object sender, EventArgs e)
        {
            //Validación de la cédula como número
            if (validarDatos(txtIdentificacion.Text.Trim(), "1"))
            {
                //Si la cédula es un número, se añade la cédula a una instancia de la clase de
                //entidad
                capa_de_entidad.identificacion = Convert.ToInt32(txtIdentificacion.Text.Trim());
                //Verifica que el usuario exista en la base de datos
                if (capa_de_negocio.nVerificarUsuario(capa_de_entidad))
                {
                    //Si el usuario existe, modifica la información existente
                    modificarUsuarioExistente();
                }
                else
                {
                    //Si el usuario no existe, crea un nuevo usuario
                    crearNuevoUsuario();
                }
            } else
            {
                //Si la cédula no es un número, alerta al usuario de la incidencia
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'La identificación agregada no es válida.', 'error')", true);
            }
        }

        //Método de click para eliminar un usuario existente
        protected void btnEliminarClick(object sender, EventArgs e)
        {
            //Ejecuta la función para eliminar un usuario
            eliminarUsuarioExistente();
        }

        //Método de click para buscar un usuario existente
        protected void buscarUsuarioClick(object sender, EventArgs e)
        {
            //Ejecuta la función para buscar un usuario existente
            buscarUsuarioExistente();
        }

        //Método para crear un nuevo usuario
        public void crearNuevoUsuario () 
        {
            //Valida que los datos de identificación y tipo de usuario sean válidos
            bool validacionDatos = validarDatos(txtIdentificacion.Text, ddlTipoUsuario.SelectedValue);

            //Si la validación es afirmativa
            if (validacionDatos)
            {
                //Asigna a un objeto de la capa de entidad, todos los datos del usuario
                capa_de_entidad.identificacion = Convert.ToInt32(txtIdentificacion.Text.Trim());
                capa_de_entidad.nombre = txtNombre.Text;
                capa_de_entidad.primer_apellido = txtPrimerApellido.Text;
                capa_de_entidad.segundo_apellido = txtSegundoApellido.Text;
                capa_de_entidad.usuario = txtNombreUsuario.Text;
                capa_de_entidad.contrasena = txtContrasena.Text;
                capa_de_entidad.tipo_de_usuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);

                //Función para crear el usuario con los datos ingresados
                capa_de_negocio.nCrearUsuario(capa_de_entidad);
                //Alerta del guardado satisfactorio de datos
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Listo", $"swal('¡Listo!', 'Se registró el usuario.', 'success')", true);

                //Limpieza de los inputs de datos
                espaciosEnBlanco();
            } else
            {
                //Si la validación es negativa, alerta al usuario de que la información no es
                //correcta
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'La identificación o el tipo de usuario no son válidos.', 'error')", true);
            }
        }

        //Método para validar los datos de ingreso
        public bool validarDatos(string identificacion, string tipo_usuario)
        {
            //Intenta convertir la identificación a número para verificar que sea
            //un dato numérico
            try
            {
                Convert.ToInt32(identificacion);
                //Si el valor del tipo de usuario es diferente de 0 (docente o administrador),
                //devuelve verdadero
                if(tipo_usuario != "0")
                {
                    return true;
                } else {
                    //Si el valor del tipo de usuario es 0 (es decir el default), devuelve falso
                    return false; 
                }

            } catch(Exception ex)
            {
                //Si la identificación no es un número, retorna falso
                return false;
            }
        }

        //Método para buscar un usuario existente
        public void buscarUsuarioExistente()
        {
            //Intenta la búsqueda del usuario, si existe ejecuta el código
            try
            {
                //Busca el usuario por medio de la cédula ingresada por el usuario
                capa_de_entidad.identificacion = Convert.ToInt32(txtIdentificacion.Text.Trim());
                //Devuelve una tabla (matriz) con la información encontrada
                DataTable respuesta = capa_de_negocio.nBuscarUsuario(capa_de_entidad);

                //Ingresa los datos encontrados en los respectivos espacios de ingreso
                //de datos
                txtIdentificacion.Text = Convert.ToString(respuesta.Rows[0][0]);
                txtNombre.Text = Convert.ToString(respuesta.Rows[0][1]);
                txtPrimerApellido.Text = Convert.ToString(respuesta.Rows[0][2]);
                txtSegundoApellido.Text = Convert.ToString(respuesta.Rows[0][3]);
                txtNombreUsuario.Text = Convert.ToString(respuesta.Rows[0][4]);
                txtContrasena.Text = Convert.ToString(respuesta.Rows[0][5]);
                ddlTipoUsuario.SelectedValue = Convert.ToString(respuesta.Rows[0][6]);

                //Convierte el campo de ingreso de indentificación a solo lectura, para que
                //no sea modificado
                txtIdentificacion.ReadOnly = true;

                //Alerta al usuario de que el usuario se encontró
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Perfecto", $"swal('¡Perfecto!', 'El usuario fue encontrado.', 'success')", true);
            }
            catch (Exception ex)
            {
                //Si la identificación no es válida o no se encuentra, alerta al usuario
                //de esta incidencia
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'No se encontró ningún usuario con esta identificacion.', 'error')", true);
            }
        }

        //Método para eliminar un usuario existente
        public void eliminarUsuarioExistente()
        {
            //Intenta eliminar el usuario, si existe ejecuta el código
            try
            {
                //Añade el dato de identificación a un objeto de la clase entidad
                capa_de_entidad.identificacion = Convert.ToInt32(txtIdentificacion.Text.Trim());
                //Ejecuta la función para eliminar el usuario según la identificación ingresada
                capa_de_negocio.nEliminarUsuario(capa_de_entidad);
                //Alerta al usuario de que el usuario se eliminó
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Listo", $"swal('¡Listo!', 'Se eliminó el usuario existente.', 'success')", true);
                
                //Limpieza de los inputs de datos
                espaciosEnBlanco();
            }
            catch (Exception ex)
            {
                //Si la identificación no puede eliminar el usuario, alerta al usuario de 
                //esta incidencia
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'No existe ningún usuario registrado con esa identificación.', 'error')", true);
            }
        }

        //Método para modificar un usuario existente
        public void modificarUsuarioExistente()
        {
            //Valida que los datos de identificación y tipo de usuario sean válidos
            bool validacionDatos = validarDatos(txtIdentificacion.Text, ddlTipoUsuario.SelectedValue);

            //Si la validación es afirmativa
            if (validacionDatos)
            {
                //Asigna a un objeto de la capa de entidad, todos los datos del usuario a cambiar
                capa_de_entidad.identificacion = Convert.ToInt32(txtIdentificacion.Text.Trim());
                capa_de_entidad.nombre = txtNombre.Text;
                capa_de_entidad.primer_apellido = txtPrimerApellido.Text;
                capa_de_entidad.segundo_apellido = txtSegundoApellido.Text;
                capa_de_entidad.usuario = txtNombreUsuario.Text;
                capa_de_entidad.contrasena = txtContrasena.Text;
                capa_de_entidad.tipo_de_usuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);

                //Función para modificar el usuario con los datos ingresados
                capa_de_negocio.nModificarUsuario(capa_de_entidad);

                //Limpieza de los inputs de datos
                espaciosEnBlanco();

                //Alerta de la modificación satisfactorio de datos
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Listo", $"swal('¡Listo!', 'Se ha modificado el usuario existente.', 'success')", true);
            }
            else
            {
                //Si la validación es negativa, alerta al usuario de que la información no es
                //correcta
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'La información no es válida.', 'error')", true);
            }
        }

        //Método para borrar las casillas de ingreso de datos
        public void espaciosEnBlanco()
        {
            //Vacía todos los campos de entrada de datos
            txtIdentificacion.ReadOnly = false;
            txtIdentificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrimerApellido.Text = string.Empty;
            txtSegundoApellido.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            //Devuelve el valor del tipo de usuario al mensaje predeterminado
            ddlTipoUsuario.SelectedValue = "0";
        }
    }
}