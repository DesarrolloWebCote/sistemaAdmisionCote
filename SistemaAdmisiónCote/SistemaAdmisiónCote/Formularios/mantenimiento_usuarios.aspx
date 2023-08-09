<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mantenimiento_usuarios.aspx.cs" Inherits="mantenimientoUsuarios.Mantenimiento_usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<%-- Cabeza del documento --%>
<head runat="server">
    <%-- Configuraciones de la página --%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%-- Enlace a la hoja de estilos Bootstrap --%>
    <link href="bootstrap-5.0.2-dist/bootstrap-5.0.2-dist/css/bootstrap.css" rel="stylesheet" />
    <%-- Enlace a la hoja de estilos de los íconos --%>

    <link href="../boxicons+sweatalert/Boxicons/boxicons.min.css" rel="stylesheet" />
    <script src="../boxicons+sweatalert/SweatAlert/sweatalert.min.js"></script>
    <%-- Título de la página web --%>
    <title>Mantenimiento de Usuarios</title>
</head>
<body>
    <%-- Formulario principal --%>
    <form id="form1" runat="server">
        <%-- Contenedor con el contenido principal --%>
        <div class="container" style="margin-top: 6em">
            <%-- Clase de CSS Grid principal --%>
            <div class="row">
                <%-- Espacio en blanco --%>
                <div class="col-2"></div>
                <%-- Espacio en blanco --%>
                <div class="col-1"></div>
                <%-- División con el contenido del formulario --%>
                <div class="col-8">
                    <%-- Título del registro de usuario --%>
                    <h1 class="fs-1" style="margin: 0em 0em 1em 1.5em">REGISTRO DE USUARIOS</h1>
                    <%-- Grupo de identificación con botón de buscar --%>
                    <div class="row">
                        <div class="col-2">
                            <%-- Label de identificación --%>
                            <label class="fs-5">Identificación</label>
                        </div>
                        <div class="col-5">
                            <%-- Caja de texto de identificación --%>
                            <asp:TextBox ID="txtIdentificacion" runat="server" class="w-100 p-2 form-control" BackColor="#eeeeee" BorderStyle="None" placeholder="XXXXXXXXX. Sin guiones ni espacios." required></asp:TextBox>
                        </div>
                        <div class="col-1">
                            <%-- Botón de buscar --%>
                            <button style="width: 50px" class="btn btn-primary" id="btnBuscar" runat="server"><i class="bx bx-search-alt"></i></button>
                        </div>
                    </div>
                    <div class="row">
                        <%-- Labels de las cajas de datos a ingresar --%>
                        <div class="col-2">
                            <label class="fs-5" style="text-align: center; margin: 1.3em 0em 0em 0em;">Nombre</label>
                            <label class="fs-5" style="text-align: center; margin: 1.7em 0em 0em 0em;">1<sup>er</sup> Apellido</label>
                            <label class="fs-5" style="text-align: center; margin: 1.7em 0em 0em 0em;">2<sup>do</sup> Apellido</label>
                            <label class="fs-5" style="text-align: center; margin: 1.7em 0em 0em 0em;">Usuario</label>
                            <label class="fs-5" style="text-align: center; margin: 1.7em 0em 0em 0em;">Contraseña</label>
                            <label class="fs-5" style="text-align: center; margin: 1.8em 0em 0em 0em;">Tipo</label>
                        </div>
                        <%-- Cajas de texto para el ingreso de datos --%>
                        <div class="col-6">
                            <asp:TextBox ID="txtNombre" runat="server" class="form-control w-100 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required></asp:TextBox>
                            <asp:TextBox ID="txtPrimerApellido" runat="server" class="form-control w-100 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required></asp:TextBox>
                            <asp:TextBox ID="txtSegundoApellido" runat="server" class="form-control w-100 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required></asp:TextBox>
                            <asp:TextBox ID="txtNombreUsuario" runat="server" class="form-control w-100 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required></asp:TextBox>
                            <asp:TextBox ID="txtContrasena" runat="server" class="form-control w-100 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None" required></asp:TextBox>
                            <%-- Lista del tipo "select" para seleccionar el tipo de usuario --%>
                            <div class="dropdown">
                                <asp:DropDownList ID="ddlTipoUsuario" runat="server" class="form-control w-100 p-2 mt-4" BackColor="#eeeeee" BorderStyle="None">
                                    <asp:ListItem Text="Tipo de Usuario" Value="0" class="dropdown-item"></asp:ListItem>
                                    <asp:ListItem Text="Administrador" Value="1" class="dropdown-item"></asp:ListItem>
                                    <asp:ListItem Text="Docente" Value="2" class="dropdown-item"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%-- Contenedor con los botones --%>
                        <div class="row mt-4">
                            <%-- Espacio en blanco --%>
                            <div class="col-3"></div>
                            <div class="col-2">
                                <%-- Botón de guardar y modificar --%>
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success m-sm-2 px-3 rounded-3 fs-4" OnClick="btnGuardarClick" />
                            </div>
                            <div class="col-2">
                                <%-- Botón de eliminar  --%>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger m-sm-2 px-3 rounded-3 fs-4" OnClick="btnEliminarClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <%-- Enlace al script de bootstrap --%>
    <script src="bootstrap-5.0.2-dist/bootstrap-5.0.2-dist/js/bootstrap.js"></script>
</body>
</html>
