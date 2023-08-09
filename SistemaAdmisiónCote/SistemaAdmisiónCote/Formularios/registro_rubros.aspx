<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro_rubros.aspx.cs" Inherits="Machote_Formulario.RegistroDatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="bootstrap-5.0.2-dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../boxicons+sweatalert/Boxicons/boxicons.min.css" rel="stylesheet" />
    <script src="../boxicons+sweatalert/SweatAlert/sweatalert.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row justify-content-center">
            <div class="col-3">
            </div>

            <div class="col-8 align-content-center align-content-between ">

                <div class="">
                    <asp:Label ID="lbl_nombre" runat="server" Text="Registro de datos de:" CssClass="h2"></asp:Label>
                </div>

                <div class="">
                    <asp:Label ID="lbl_postulante" runat="server" Text="Num Postulante: " CssClass="h3"></asp:Label>
                </div>

                <div class="row">
                    <div class="input-group mt-2">

                        <div class="col-2">
                            <asp:Label ID="Label1" runat="server" Text="Identificacion: " CssClass="form-label"></asp:Label>
                        </div>

                        <div class="col-5">
                            <asp:TextBox ID="txt_identificacion" runat="server" CssClass="form-control w-100" type="number"></asp:TextBox>
                        </div>

                        <div class="col-2 ms-1">
                            <span class="input-group-btn">
                                <asp:LinkButton CssClass="btn btn-info" runat="server" ID="btn_buscar" OnClick="btn_buscar_Click">
                                    <i class="bi bi-search"></i>
                                </asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="input-group mt-2">
                        <div class="col-2">
                            <asp:Label ID="Label2" runat="server" Text="Notas:   " class="form-label"></asp:Label>
                        </div>

                        <div class="col-5">
                            <asp:TextBox ID="txt_notas" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="input-group mt-2">
                        <div class="col-2">
                            <asp:Label ID="Label3" runat="server" Text="Examen: " class="form-label"></asp:Label>
                        </div>

                        <div class="col-5">
                            <asp:TextBox ID="txt_examen" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="input-group mt-2">
                        <div class="col-2">
                            <asp:Label ID="Label4" runat="server" Text="Entrevista: " class="form-label"></asp:Label>
                        </div>

                        <div class="col-5">
                            <asp:TextBox ID="txt_entrevista" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                </div>


                <div class="row">
                    <div class="input-group mt-2">
                        <div class="col-2">
                            <asp:Label ID="Label5" runat="server" Text="Estrategia: " class="form-label"></asp:Label>
                        </div>

                        <div class="col-5">
                            <asp:TextBox ID="txt_estrategia" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>


                    <div class="col-1 mt-2">
                        <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btn_guardar_Click" />
                    </div>
                    <div class="col-1 mt-2">
                        <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger ms-1" OnClick="btn_eliminar_Click" />
                    </div>
                    <div class="col-1 mt-2">
                        <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary ms-1" OnClick="btn_cancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
