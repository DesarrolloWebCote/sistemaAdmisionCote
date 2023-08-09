using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Machote_Formulario.Datos;
using Machote_Formulario.Entidad;
using Machote_Formulario.Negocio;

namespace Machote_Formulario
{
    public partial class RegistroDatos : System.Web.UI.Page
    {
        n_buscar_postulante negocio = new n_buscar_postulante();    
        e_mantenimiento_postulante postulante = new e_mantenimiento_postulante();
        DataTable datoCargado = new DataTable();
        d_ingreso_rubros dato = new d_ingreso_rubros();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void buscar()
        {
            //Aca el objeto de la clase le envia el dato necesario al metodo para buscar al sujeto
            //Le doy como parametro la identificacion de la persona
            try
            {
                if (string.IsNullOrEmpty(txt_identificacion.Text))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'No deje este espacio en blanco.', 'warning')", true);

                }
                else
                {
                    postulante.identificacion = Convert.ToInt32(txt_identificacion.Text);
                    datoCargado = negocio.buscar(postulante);
                }
            }
            catch (OverflowException ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'El tipo de dato no es correcto', 'error')", true);

            }

        }

        //Metodo que abre la ventana emergente
        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            buscar();

            //Mediante este if verifico si el dato ingresado existe o no en la base de datos
            if (datoCargado.Rows.Count > 0)
            {
                string nombreCompleto = ($"Registro de datos de: {datoCargado.Rows[0][0].ToString()} {datoCargado.Rows[0][1].ToString()} {datoCargado.Rows[0][2].ToString()}");

                lbl_nombre.Text = nombreCompleto;
                lbl_postulante.Text = $"Num Postulante: {datoCargado.Rows[0][3].ToString()}";

                //Deshabilito la caja de texto de ID para evitar registros erroneos a otros postulantes
                txt_identificacion.Enabled = false;

                //Habilito las cajas de texto hasta que se haya buscado el postulante
                btn_guardar.Enabled = true;
                btn_eliminar.Enabled = true;

                txt_notas.Enabled = true;
                txt_examen.Enabled = true;
                txt_estrategia.Enabled = true;
                txt_entrevista.Enabled = true;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'Este postulante no está registrado.', 'error')", true);
                lbl_nombre.Text = "Registro de datos de: ";
                lbl_postulante.Text = "Num Postulante: ";
            }
        }

        public void guardarDatos()
        {
            //Llamo al objeto de la clase
            
            if(string.IsNullOrEmpty(txt_identificacion.Text) || string.IsNullOrEmpty(txt_notas.Text) || string.IsNullOrEmpty(txt_examen.Text) || 
                string.IsNullOrEmpty(txt_estrategia.Text) || string.IsNullOrEmpty(txt_entrevista.Text))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Ojo!', 'No deje espacios en blanco.', 'warning')", true);

                txt_identificacion.Enabled = true;
                txt_notas.Enabled = true;
                txt_examen.Enabled = true;
                txt_estrategia.Enabled = true;
                txt_entrevista.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(txt_identificacion.Text))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'Complete el espacio de identificación.', 'error')", true);
                }
                else
                {
                    postulante.identificacion = Convert.ToInt32(txt_identificacion.Text);
                    datoCargado = negocio.buscar(postulante);

                    //Retorna el numero de postulante de la tabla "rubros"
                    int mumeroPostulante = Convert.ToInt32(datoCargado.Rows[0][3]);
                    int retornoRubros = dato.verificarRegistro(mumeroPostulante);

                    //Retorna el numero postulante de la tabla "persona"
                    int valor = Convert.ToInt32(txt_identificacion.Text);
                    int retornoPersona = dato.verificarPersona(valor);


                    if (retornoRubros == retornoPersona)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'Este registro ya existe.', 'error')", true);
                    }
                    else
                    {
                        //Al objeto postulante del constructor le asigno la identificacion para verificar la existencia de nuevo
                        int identificacion = Convert.ToInt32(txt_identificacion.Text);

                        //Guardo el valor retornado de la funcion que verifica para asignarselo al objeto
                        int datoRetornado = dato.verificarPersona(identificacion);

                        //Asigno los datos
                        postulante.numeroPostulante = datoRetornado;
                        postulante.notas = Convert.ToInt32(txt_notas.Text);
                        postulante.examen = Convert.ToInt32(txt_examen.Text);
                        postulante.estrategia = Convert.ToInt32(txt_estrategia.Text);
                        postulante.entrevista = Convert.ToInt32(txt_entrevista.Text);
                        negocio.ingresarRubros(postulante);

                        //ENVIAR MENSAJE DE PROCESO EXITOSO AQUI
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Almacenado!', 'Registro exitoso.', 'success')", true);

                        txt_identificacion.Enabled = true;
                        txt_identificacion.Text = String.Empty;
                        txt_notas.Text = String.Empty;
                        txt_examen.Text = String.Empty;
                        txt_estrategia.Text = String.Empty;
                        txt_entrevista.Text = String.Empty;

                        txt_notas.Enabled = false;
                        txt_examen.Enabled = false;
                        txt_estrategia.Enabled = false;
                        txt_entrevista.Enabled = false;

                        lbl_nombre.Text = "Registro de datos de:";
                        lbl_postulante.Text = "Num Postulante: ";
                    }
                }
            }
        }
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            //Llamo la funcion de guardar
            guardarDatos();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            d_ingreso_rubros dato = new d_ingreso_rubros();

            try
            {
                //Segun el ID enviado se retorna el numero de postulante para enviarlo como parametro
                //y eliminar el registro relacionado a esa identificacion
                int id = Convert.ToInt32(txt_identificacion.Text);
                int retorno = dato.verificarPersona(id);

                postulante.numeroPostulante = retorno;
                negocio.eliminarRegistro(postulante);
                txt_identificacion.Enabled = true;

                txt_identificacion.Enabled = true;
                txt_identificacion.Text = String.Empty;
                txt_notas.Text = String.Empty;
                txt_examen.Text = String.Empty;
                txt_estrategia.Text = String.Empty;
                txt_entrevista.Text = String.Empty;
                lbl_nombre.Text = "Registro de datos de:";
                lbl_postulante.Text = "Num Postulante: ";

                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Eliminado!', 'Registro eliminado satisfactoriamente.', 'success')", true);


                txt_notas.Enabled = false;
                txt_examen.Enabled = false;
                txt_estrategia.Enabled = false;
                txt_entrevista.Enabled = false;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", $"swal('¡Error!', 'Error en la operación.', 'error')", true);

            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            lbl_nombre.Text = "Registro de datos de: ";
            lbl_postulante.Text = "Num Postulante: ";

            txt_identificacion.Enabled = true;
            txt_identificacion.Text = String.Empty;
            txt_notas.Text = String.Empty;
            txt_examen.Text = String.Empty;
            txt_estrategia.Text = String.Empty;
            txt_entrevista.Text = String.Empty;

            txt_identificacion.Enabled = true;
            txt_notas.Enabled = false;
            txt_examen.Enabled = false;
            txt_estrategia.Enabled = false;
            txt_entrevista.Enabled = false;
        }
    }
}