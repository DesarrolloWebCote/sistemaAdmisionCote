using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ingreso_de_notas
{
    public partial class IngresoNotas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void holaMundo()
        {
            Response.Write("<script>alert('Hola Munde')</script>");
        }
    }
}