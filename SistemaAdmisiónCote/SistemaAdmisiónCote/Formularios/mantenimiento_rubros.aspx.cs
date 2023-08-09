using MantenimientoDeRubros.Datos;
using MantenimientoDeRubros.Entidad;
using MantenimientoDeRubros.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MantenimientoDeRubros
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Tabla donde se muestra el valor de los rubros de evaluacion para cada etapa.
        DataTable dt = new DataTable();//CREAMOS DATA TABLE
        //Objeto de la clase Negocio.
        n_mantenimiento_rubros N_Sistema_Admision = new n_mantenimiento_rubros();
        //Objeto de la clase Entidad.
        e_mantenimiento_rubros E_Sistema_Admision = new e_mantenimiento_rubros();
        //Método que envia la tabla en la cual se mostraran los datos
        public void busqueda()
        {
            //Indicamos que la tabla dt tendra el metodo Tabla_rubros 
            dt = N_Sistema_Admision.Tabla_Rubros(E_Sistema_Admision);
        }
        //Método que carga los datos de la tabla
        public void mostrargrid(GridView gridBusca)
        {
            busqueda(); //Método busqueda
            gridBusca.DataSource = dt; //indicamos los datos que va a cargar y donde estan
            gridBusca.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es la primera vez que se va a cargar la página
            //muestra la tabla con los respectivos datos.
            if (!IsPostBack)
            {
                busqueda();
                mostrargrid(grid_prueba);
            }
        }
        protected void btn_guardar_click(object sender, EventArgs e)
        {
            //Obtenemos el valor que se ingreso en la textbox es decir obtenemos el
            //valor de cada uno de los rubros de evaluación
            int Examen = Convert.ToInt32(txt_Examen.Text);
            int Entrevista = Convert.ToInt32(txt_Entrevista.Text);
            int Notas = Convert.ToInt32(txt_Notas.Text);
            int Estrategia = Convert.ToInt32(txt_Estrategia.Text);
            int Etapa = Convert.ToInt32(txt_Etapa.SelectedValue);
            int total_Rubros = Examen + Entrevista + Notas + Estrategia;
            //Validación, si el valor es menor o mayor a 100 no enviará los datos que se ingresan a la BD
            if (total_Rubros == 100)
            {
                //Enviamos a la clase E_Sistema_Admision el valor de los datos para cada constructor.
                E_Sistema_Admision.Examen = Examen;
                E_Sistema_Admision.Entrevista = Entrevista;
                E_Sistema_Admision.Notas = Notas;
                E_Sistema_Admision.Estrategia = Estrategia;
                E_Sistema_Admision.Etapa = Etapa;
                //Cargamos los datos que tendra los constructores.
                N_Sistema_Admision.reg(E_Sistema_Admision);
                //Limipamos las textbox 
                txt_Examen.Text = string.Empty;
                txt_Entrevista.Text = string.Empty;
                txt_Notas.Text = string.Empty;
                txt_Estrategia.Text = string.Empty;
                //Volvemos a cargar la tabla con los valores de la base de datos
                busqueda();
                mostrargrid(grid_prueba);
            }
            else
            {
                //Mostramos alerta de que los valores son mayores o menores a 100
                ScriptManager.RegisterStartupScript(HttpContext.Current.Handler as Page, typeof(Page), "alert", $"swal('Alto!', 'Lau sumatoria de los rubros de evaluacion deben ser 100', 'error');", true);
            }
        }
        protected void grid_prueba_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Obtenemos el valor de la columna que se preciono el boton de eliminar
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid_prueba.Rows[index];
            //Validación del nombre del botón, si el botón presionado es eliminarRegistro entrará.
            if (e.CommandName == "Eliminar_Rubros")
            {
                //Mostramos la ventana de la alerta de la eliminación
                ventana_Eliminar.Visible = true;
                //Guardamos en una variable de tipo Session el valor de la celda 1 en la columna que se precionó.
                Session["Etapa"]  = row.Cells[1].Text;
                //Título de la alerta con la respectiva etapa a eliminar
                title.InnerText = $"¿Está seguro que quiere eliminar los rubros de {row.Cells[1].Text} ?";
            }
        }
        protected void btn_confirmar_Eliminar_Click(object sender, EventArgs e)
        {
            //Recibimos el valor de la session etapa que fue enviada en el evetno grid_prueba_RowCommand y
            //se lo enviamos al constructor que corresponde. 
            E_Sistema_Admision.Etapa = Convert.ToInt32(Session["Etapa"]);
            //Enviamos al evento Eliminar los valores de la clase o el valor del constructor necesario
            N_Sistema_Admision.Eliminar(E_Sistema_Admision);
            //Ocultamos la alerta de eliminar
            ventana_Eliminar.Visible = false;
            //Recargamos nuevamente la tabla con la información
            busqueda();
            mostrargrid(grid_prueba);
        }
        //Botón de cancelar o cerrar la alerta de eliminar
        protected void btn_cancelar_Eliminar_Click(object sender, EventArgs e)
        {
            //Cerramos la alerta de la ventana eliminar
            ventana_Eliminar.Visible = false;
        }
    }
}