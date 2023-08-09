<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="sistemaAdmision_Reportes.Aspx.WebForm1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reportes</title>
 <%--   Links de las clases bootstrap, css, js necesarias para el proyecto--%>
        <link href="bootstrap-5.0.2-dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../boxicons+sweatalert/Boxicons/boxicons.min.css" rel="stylesheet" />
    <script src="../boxicons+sweatalert/SweatAlert/sweatalert.min.js"></script>
    <script>
        function showSweetAlert(title, message, type) {
            Swal.fire({
                title: title,
                text: message,
                icon: type,
                confirmButtonText: 'OK'
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="form">
        <div class="row align-items-start mt-2">
            <div class="col ms-5">
                <h1 class="h1">Ingreso de datos</h1>
                <label for="etapa">etapa</label>
                <%--Lista de seleccion de la etapa--%>
                <asp:DropDownList ID="list_Etapa" runat="server">
                    <asp:ListItem Value="1">PRIMERA</asp:ListItem>
                    <asp:listitem Value="2">SEGUNDA</asp:listitem>
                </asp:DropDownList>
            </div>
            <div class="col me-5">
                <div class="input-group">
                        <%--Lista de seleccion de la especialidad--%>
                    <asp:DropDownList ID="list_Especialidad" runat="server" CssClass="form-select">
                        <asp:ListItem Value="1">Contabilidad y finanzas</asp:ListItem>
                        <asp:ListItem Value="2">Desarrollo web</asp:ListItem>
                        <asp:ListItem Value="3">Ciberseguridad</asp:ListItem>
                    </asp:DropDownList>
                         <%--Boton de cofirmar que esta relacionada con la especialidad y la etapa--%>
                    <span class="input-group-btn">
                        <asp:LinkButton ID="btn_confirmar" CssClass="btn" runat="server" OnClick="btn_confirmar_Click" style="margin-left: 10px;" >
                            <i class="bi bi-check"></i>
                        </asp:LinkButton>
                    </span>
                </div>
                <div class="input-group mt-1">
                    <asp:TextBox ID="txt_ID" runat="server" CssClass="form-control" placeholder="Identificación"></asp:TextBox>
                    <span class="input-group-btn">
                         <%--Boton de cofirmar que esta relacionada con la busqueda pore ID--%>
                        <asp:LinkButton ID="btn_busqueda" CssClass="btn" runat="server" OnClick="btn_busqueda_Click" style="margin-left: 10px;">
                            <i class="bi bi-search"></i>
                        </asp:LinkButton>
                    </span>
                </div>
            </div>  
                  <div class="row" style="overflow: scroll;">
                        <div class="col col-md-12 col-sm-12 col-12">
                            <br /><br />
                           <%-- Gridview por el cual se muestran los datos del servidor--%>
                            <asp:GridView ID="grid_prueba" runat="server"  OnRowDataBound="grid_prueba_RowDataBound" CssClass="table table-striped table-hover" GridLines="None">
                            </asp:GridView>
                              <div class="input-group mt-1">
                              <%--    Boton para guardar los datos en la hoja de excell--%>
                            <asp:LinkButton ID="btn_Print" CssClass="Btn" runat="server" Visible="false" OnClick="btn_Print_Click">
                                 <svg class="svgIcon" viewBox="0 0 384 512" height="1em" xmlns="http://www.w3.org/2000/svg"><path d="M169.4 470.6c12.5 12.5 32.8 12.5 45.3 0l160-160c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0L224 370.8 224 64c0-17.7-14.3-32-32-32s-32 14.3-32 32l0 306.7L54.6 265.4c-12.5-12.5-32.8-12.5-45.3 0s-12.5 32.8 0 45.3l160 160z"></path></svg>
                                       <span class="icon2"></span>
                            </asp:LinkButton>
                                  </div>                          
                        </div>
                    </div>
            </div>
    </form>
</body>
</html>
