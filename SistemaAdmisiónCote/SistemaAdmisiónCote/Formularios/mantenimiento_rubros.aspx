<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mantenimiento_rubros.aspx.cs" Inherits="MantenimientoDeRubros.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%-- Se asigna un título a la página --%>
    <title>Mantimiento de rubros</title>
    <%-- Enlace a las hojas de estilo y funciones JS --%>    
    <link href="bootstrap-5.0.2-dist/css/bootstrap.css" rel="stylesheet" />
    <%-- Link css faltante --%>
        <link href="bootstrap-5.0.2-dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../boxicons+sweatalert/Boxicons/boxicons.min.css" rel="stylesheet" />
    <script src="../boxicons+sweatalert/SweatAlert/sweatalert.min.js"></script>
</head>
<body>
    <%-- Contenedor de todo el formulario --%>    
    <form id="form1" runat="server">
        <div class="container">
        <%-- División de la página en columnas --%>
            <div class="row">
                <div class="col-2">
                </div>
                <div class="col-1">
                </div>
                <div class="col-8 display: ">
                <%-- Nombres de los rubros a evaluar --%>
                    <h1 style="margin-top: 10%; font-weight: bold;">MANTENIMIENTO RÚBROS</h1>
                    <div class="row">
                        <div class="col-2">
                            <label class="fs-5" style="text-align: center; margin: 2.5em 0em 0em 1em;">Examen</label>
                            <label class="fs-5" style="text-align: center; margin: 1.6em 0em 0em 1em;">Entrevista</label>
                            <label class="fs-5" style="text-align: center; margin: 1.9em 0em 0em 1em;">Notas</label>
                            <label class="fs-5" style="text-align: left; margin: 1em 0em 0em 1em;">Estrategia técnica</label>
                            <label class="fs-5" style="margin: 1em 0em 0em 1em;">Etapa</label>
                        </div>

                        <div class="col-6">
                            <asp:TextBox runat="server" ID="txt_Examen" CssClass="form-control w-75 p-2 mt-5" BackColor="#eeeeee" BorderStyle="None" required="required" Textmode="Number" />
                            <asp:TextBox runat="server" ID="txt_Entrevista" CssClass="form-control w-75 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required="required" Textmode="Number"/>
                            <asp:TextBox runat="server" ID="txt_Notas" CssClass="form-control w-75 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required="required" Textmode="Number"/>
                            <asp:TextBox runat="server" ID="txt_Estrategia" CssClass="form-control w-75 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required="required" Textmode="Number"/>
                            <asp:DropDownList runat="server" ID="txt_Etapa" CssClass="dropdown-item w-75 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required="required">
                                <asp:ListItem Text="Etapa 1" Value="1" />
                                <asp:ListItem Text="Etapa 2" Value="2" />
                            </asp:DropDownList>
                            <div class="row" style="margin-top: 3em;">
                                <div class="col-5">
                                </div>
                                <%-- Botón para almacenar los datos en la base de datos --%>
                                <div class="col-1">
                                    <asp:Button ID="btn_guardar" Text="Guardar" runat="server" CssClass="btn btn-success m-sm-5 m-lg-2 px-3 rounded-3 fs-4 align-items-center" OnClick="btn_guardar_click" />
                                </div>
                            </div>
                            
                            
                        </div>

                    </div>
                    <div class="col-1">
                    </div>
                    <%-- Imprime el GRIDVIEW en la página --%>
                    <div class="col-8">
                                <div style="margin-top:2em;">
                                <asp:GridView ID="grid_prueba" runat="server" OnRowCommand="grid_prueba_RowCommand" class="table table-bordered p-5 p-xl-4 text-center">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Opciones
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            <%--BOTON ELIMINAR--%>
                                            <asp:LinkButton ID="btn_eliminado" CssClass="btn btn-danger" runat="server" CommandArgument="<%#Container.DisplayIndex %>" CommandName="Eliminar_Rubros">
                                                    <i class='bx bx-trash'></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </div>
                        </div>
                </div>
                <%--VENTANA EMERGENTE--%>
                <div id="ventana_Eliminar" runat="server" class="contenedorPrincipal" visible="false">
                    <div class="ventanaCard">
                        <div class="card">
                            <div class="card-header bg-light">
                                <h5 class="text-center" runat="server" id="title"></h5>
                            </div>
                            <div class="row" style="margin: 2em 0em 2em 2em;">
                                <%-- Botones con acciones según decisión del usuario --%>
                                <div class="col-6">
                                    <asp:LinkButton ID="btn_cancelar_Eliminar" runat="server" class="btn btn-danger col-10 p-2 fs-4" OnClick="btn_cancelar_Eliminar_Click"><i class='bx bxs-chevron-left'></i> Cancelar</asp:LinkButton>
                                </div>
                                <div class="col-6">
                                    <asp:LinkButton ID="btn_confirmar_Eliminar" runat="server" class="btn btn-success col-10 p-2 fs-4" OnClick="btn_confirmar_Eliminar_Click">Confirmar <i class='bx bxs-eraser'></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--TERMINA VENTANA EMERGENTE--%>
    </form>
    <%-- Enlace a acciones JS --%>
    <script src="bootstrap-5.0.2-dist/js/bootstrap.js"></script>
</body>
</html>
