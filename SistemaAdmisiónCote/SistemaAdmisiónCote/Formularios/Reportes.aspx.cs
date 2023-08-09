using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using sistemaAdmision_Reportes.Entidad;
using sistemaAdmision_Reportes.Negocio;


namespace sistemaAdmision_Reportes.Aspx
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        n_mantenimientoUsuarios nMantenimiento = new n_mantenimientoUsuarios();                             //objeto para interactuar con la capa de negocio
        e_mantenimientoUsuarios eMantenimiento = new e_mantenimientoUsuarios();                            //objeto para interactuar con la capa de entidad
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grid_prueba_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex < 8)                              //condicional y ciclo para recorrer las primeras 8 comlunas del gridView y pintarlas
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.FromArgb(32, 201, 151);
                }
            }

            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)      //condicional que inicia desde el encabezado de la base de datos y asi poder manipular el gridview completo
            {
                if (list_Etapa.SelectedValue == "1")
                {
                    e.Row.Cells[5].Visible = false;                                                         //condicional que valida que si el valor de etapa es uno oculte la quinta fila y si es 2 la muestre
                }
                else if (list_Etapa.SelectedValue == "2")
                {
                    e.Row.Cells[5].Visible = true;
                }
            }
        }

        public void busquedaUsuario()
        {
            eMantenimiento.etapaType = int.Parse(list_Etapa.SelectedValue);                                    //Metodo que envia el para la busqueda
            string especialidad = list_Especialidad.SelectedItem.Text;                                        //Selecciona el valor string del downlist y los el valor int

            eMantenimiento.esepecialType = especialidad;
            dt = nMantenimiento.nBusqueda(eMantenimiento);
            eMantenimiento.etapaType = int.Parse(list_Etapa.SelectedValue);
            txt_ID.Text = String.Empty;                                                                          //Limpia el textbox por motivos de estetica
        }
        public void busquedaPorID()                                                                            //Metodo para realizar la busqueda por id
        {
            int idUsuario;

            if (int.TryParse(txt_ID.Text.Trim(), out idUsuario))                                              //Resive el constructor y lo convierte en un estilo boolean que devuelva false o true mediante(1 o 0)
            {
                eMantenimiento.idUsuario = idUsuario;
                dt = nMantenimiento.nBusquedaPorID(eMantenimiento);
                if (dt == null || dt.Rows.Count == 0)                                                        //condicional que valida si el valor existe en la base de datos o si es nulo
                {
                    ShowSweetAlert("Oops", "ID no encontrado en la base de datos.", "error");
                    return;
                }
            }
            else
            {
                ShowSweetAlert("Atención", "Por favor, ingrese un ID válido o deje el campo en blanco para buscar por especialidad.", "warning");
                return;
            }

            txt_ID.Text = String.Empty;                                                                           //Limpia el textbox por motivos de estetica
        }
        private void ExportToExcel(DataTable dt)                                                                //Metodo que guarda los datos en excell mediante la libreria EPPLUS
        {
            if (list_Etapa.SelectedValue == "1" && dt.Columns.Contains("Estrategia"))                        // Si es la primer estapa elimina la comluna de estrategia para no imprimirla en excell
            {
                dt.Columns.Remove("Estrategia");
            }
            string path = "C:\\Users\\aa507\\OneDrive\\Área de Trabalho\\Prueba.xlsx";                        //Ruta en el directorio para validar el acceso al libro de excell
            SLDocument sl;                                                                                   //variable para intermediar entre l pagina y el libro

            if (System.IO.File.Exists(path))                                                               //Valida si el libro de excel existe en el sistema o no.
            {
                sl = new SLDocument(path);
                string newSheetName = "Reporte_" + DateTime.Now.ToString("yyyy-MMdd-HHmmss");                 //Si el libro si existe agarra la fecha del actual en el servidor para validar.
                sl.AddWorksheet(newSheetName);                                                              //Crea una nueva hoja en el libro de excell con el nuevo reporte con el nombre Reporte_fecha que retorno el servidor
                sl.SelectWorksheet(newSheetName);                                                          //Setea los datos del data table a la hoja que se acaba de crear
            }
            else                                                                                         //Si no crea un libro nuevo de excell
            {
                sl = new SLDocument();
            }

            sl.ImportDataTable(1, 1, dt, true);                                                           //Indica que que la primera fila se utiliza como encabezado                        
            SLStyle style = sl.CreateStyle();
            style.Fill.SetPatternType(PatternValues.Solid);                                             //Metodo interno de la libreria para llenar las celdas en el libro de excell
            style.Fill.SetPatternForegroundColor(System.Drawing.Color.Green);

            int colCount = dt.Columns.Count;
            int rowCount = dt.Rows.Count;                                                             // Aquí determinamos el número real dentro del datTable

            for (int col = 1; col <= colCount; col++)                                                //Recorremos el datTable para pintar el numero real de comlunas seteado.
            {                                                                                                      
             for (int row = 2; row <= 1 + Math.Min(rowCount, 8); row++)                             // Definimos que pinte las comlunas desde el minimo hasta el maximo que seria 8
                {
                    sl.SetCellStyle(row, col, style);
                }
            }
            sl.SaveAs(path);                                                                      //Guarda el documento
        }
        public void mostrarGrid()
        {

            grid_prueba.DataSource = dt;                                                           //Metodo que muestra el grid con los datos del datTable
            grid_prueba.DataBind();                                                               //Rellena el grid con los datos que tenga el data table
            Session["DataTableToExport"] = dt;                                                   //Almacena los datos del grid en una memoria dinamica para poder gurdarlos en el excell
            btn_Print.Visible = dt != null && dt.Rows.Count > 0;                                //Oculta el btn_Print hasta que el grid sea visible
        }
        protected void btn_busqueda_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ID.Text.Trim()))                                  //condicional para mostrar el usuario por id y si no que muestre los postulantes por especialidad
            {
                busquedaPorID();
            }
            else
            {
                busquedaUsuario();
            }
            mostrarGrid();
        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            busquedaUsuario();                                                                           //Llama al nmetodo y muestra el grid con los postulantes por especialidad
            mostrarGrid();
        }
        private void ShowSweetAlert(string title, string message, string type)                           //Metodo del sweet alert
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"showSweetAlert('{title}', '{message}', '{type}');", true);
        }

        protected void btn_Print_Click(object sender, EventArgs e)                                      //Btn que confirma la accion de guardar los datos en el libro de excell
        {
            DataTable dtToExport = Session["DataTableToExport"] as DataTable;                           //Obtirne los datos almacenados en la memoria dinamica
            if (dtToExport != null && dtToExport.Rows.Count > 0)                                        //Condicional que valida si los datos existe para guardarlos o no
            {
                ExportToExcel(dtToExport);
                ShowSweetAlert("Éxito", "Datos exportados a Excel correctamente.", "success");
            }
            else
            {
                ShowSweetAlert("Atención", "No hay datos para exportar.", "warning");
            }
        }
    }
}