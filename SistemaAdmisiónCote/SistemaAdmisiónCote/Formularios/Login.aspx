<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sql_proyecto.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet"/>

	    <link href="bootstrap-5.0.2-dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../boxicons+sweatalert/Boxicons/boxicons.min.css" rel="stylesheet" />
    <script src="../boxicons+sweatalert/SweatAlert/sweatalert.min.js"></script>
   <link rel="stylesheet" href="css/StyleSheet1.css" /> 
</head>
<body>
    <form id="form1" runat="server">
        <section class="ftco-section">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-6 col-lg-5">
                        <div class="login-wrap p-4 p-md-5">
                            <div class="icon d-flex align-items-center justify-content-center">
                                <span class="fa fa-user-o"></span>
                            </div>

                            <%-- Caja de texto para nombre de usuario --%>
                            <div class="form-group">
                                <asp:TextBox ID="TxtNombreUsuario" runat="server" type="text" class="form-control rounded-left" placeholder="Nombre de Usuario" required=""></asp:TextBox>
                            </div>

                            <%-- Caja de texto para contrasena --%>
                            <div class="form-group d-flex">
                                <asp:TextBox ID="TxtContrasena" runat="server" type="password" class="form-control rounded-left" placeholder="Password" required=""></asp:TextBox>
                            </div>

                            <%-- Boton de ingreso --%>
                            <div class="row justify-content-center">
                                <asp:Button ID="BtnIngresar" runat="server" Text="Inicio sesión" type="submit" class="btn btn-primary rounded submit p-3 px-5" OnClick="BtnIngresar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
