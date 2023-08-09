<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InscripcionPostulante.aspx.cs" Inherits="WebApplication6.Figma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inscripción Postulante</title>
    <link href="Estilo/bootstrap.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script
        src="https://code.jquery.com/jquery-3.7.0.min.js"
        integrity="sha256-2Pmvv0kuTBOenSvLm6bvfBSSHrUJ+3A7x6P5Ebd07/g="
        crossorigin="anonymous"></script>
    <script src="../boxicons+sweatalert/SweatAlert/sweatalert.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $("#exampleModal").modal('show');

            function mostrarInformacionEncargado() {
                if ($("#chkEncargados input[type=checkbox]:checked").length > 0) {
                    $("#InformacionEncargado").removeClass("d-none").addClass("d-flex");
                } else {
                    $("#InformacionEncargado").removeClass("d-flex").addClass("d-none");
                }
            }

            $("#chkEncargados input[type=checkbox]").change(function () {
                $("#chkEncargados input[type=checkbox]").prop("checked", false);
                $(this).prop("checked", true);
                mostrarInformacionEncargado();
            });

            // Mostrar 
            mostrarInformacionEncargado();

            $("#btnCerrar").click(function () {
                $("#exampleModal").modal('hide');
            });
        });
    </script>
</head>
<body class="bg-secondary ">
    <form id="form1" runat="server">

        <div id="exampleModal" runat="server" class="modal fade d-flex justify-content-center align-items-center" tabindex="-1" data-backdrop="static" data-keyboard="false" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Verificación de usuario</h5>
                    </div>
                    <div class="modal-body d-flex justify-content-center flex-column align-items-center">
                        <asp:Label Text="Identificación" runat="server" />
                        <asp:TextBox type="number" ID="verificacion_id" placeholder="" CssClass="form-control w-50" runat="server" />
                        <asp:Label Text="Consecutivo" runat="server" />
                        <asp:TextBox type="number" ID="consecutivo_num" placeholder="" required="true" CssClass="form-control w-50" runat="server" />
                    </div>
                    <div class="modal-footer">
                        <asp:Button Text="Verificar" CssClass="btn btn-success" OnClick="BtnLogin_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <div class="container  bg-white rounded-2  mt-5 p-4" style="border-radius: 10px">


            <h1 class="text-center">Formulario de Inscripción de Postulante</h1>
            <hr />
            <div class="row">
                <div class="col p-3 mb-2">
                    <h2>Datos del postulante</h2>
                </div>
                <div class="col p-3 mb-2">
                </div>
                <div class="col p-3 mb-2">
                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label text-muted">Consecutivo</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="text" ReadOnly="true" runat="server" CssClass="form-control" ID="NumPos" placeholder="" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col p-3 mb-2">
                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label">Colegio de procedencia</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="text" onkeydown="return /[a-z, ]/i.test(event.key)" runat="server" CssClass="form-control" ID="ColegioProcedencia" placeholder="" />

                        </div>
                    </div>
                </div>
                <div class="col p-3 mb-2 ">

                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label">Primera opción</label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="PrimeraOpcion" CssClass="btn btn-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server">
                                <asp:ListItem Text="1ra Opción" />
                                <asp:ListItem Text="Desarrollo Web" />
                                <asp:ListItem Text="Secretariado Ejecutivo" />
                                <asp:ListItem Text="Ciberseguridad" />
                                <asp:ListItem Text="Contabilidad y Finanzas" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col p-3 mb-2">
                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label">Segunda opción</label>
                        <div class="col-sm-5">
                            <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" ID="SegundaOpcion" runat="server">
                                <asp:ListItem Text="2da Opción" />
                                <asp:ListItem Text="Desarrollo Web" />
                                <asp:ListItem Text="Secretariado Ejecutivo" />
                                <asp:ListItem Text="Ciberseguridad" />
                                <asp:ListItem Text="Contabilidad y Finanzas" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col p-3 mb-2">
                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label mb-1">Nombre</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="text" runat="server" CssClass="form-control" ID="NombreEs" onkeydown="return /[a-z, ]/i.test(event.key)" placeholder="" />
                        </div>

                        <label for="" class="col-sm-4 col-form-label mb-1  text-muted ">Identificación</label>
                        <div class="col-sm-5">
                            <asp:TextBox ReadOnly="true" type="text" runat="server" CssClass="form-control" ID="IdentificacionEs" placeholder="" />
                        </div>


                        <label for="" class="col-sm-4 col-form-label mb-1">Nacionalidad</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="text" onkeydown="return /[a-z, ]/i.test(event.key)" runat="server" CssClass="form-control" ID="NacionalidadEs" placeholder="" />
                        </div>
                    </div>

                    <div class="form-group row">

                        <label for="" class="col-sm-4 col-form-label mb-1">Fecha de nacimiento</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="date" onkeydown="return false" runat="server" CssClass="form-control" ID="FechaNacimientoEs" placeholder="" />
                        </div>
                    </div>
                </div>
                <div class="col p-3 mb-2 ">

                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label mb-1">1er Apellido</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="text" runat="server" onkeydown="return /[a-z, ]/i.test(event.key)" CssClass="form-control" ID="PrimerApellidoEs" placeholder="" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label mb-1">Edad</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="number" runat="server" CssClass="form-control" ID="EdadEs" placeholder="" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label mb-1">Sexo</label>
                        <div class="col-sm-5">
                            <asp:DropDownList runat="server" CssClass="btn btn-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" ID="SexoEs">
                                <asp:ListItem Text="Genero"></asp:ListItem>
                                <asp:ListItem Text="Masculino"></asp:ListItem>
                                <asp:ListItem Text="Femenino"></asp:ListItem>
                                <asp:ListItem Text="?"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col p-3 mb-2">
                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label mb-1">2do Apellido</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="text" runat="server" onkeydown="return /[a-z, ]/i.test(event.key)" CssClass="form-control" ID="SegundoApellidoEs" placeholder="" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="" class="col-sm-4 col-form-label mb-1">Correo</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="email" runat="server" CssClass="form-control" ID="CorreoElectronicoEs" placeholder="" />
                        </div>
                        <label for="" class="col-sm-4 col-form-label mb-1">Celular</label>
                        <div class="col-sm-5">
                            <asp:TextBox type="number" runat="server" CssClass="form-control" ID="NumCelularEs" placeholder="" />
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col p-3 mb-2">
                    <h2>Datos del encargado</h2>
                    <div class=" d-inline-block">
                        <p>Seleccione a los encargados para continuar: </p>

                        <asp:CheckBoxList ID="chkEncargados" RepeatDirection="Horizontal" RepeatColumns="3" BorderColor="YellowGreen" runat="server">
                            <asp:ListItem Text="Madre" />
                            <asp:ListItem Text="Padre" />
                            <asp:ListItem Text="Encargado Legal" />
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>
            <div id="InformacionEncargado" class="col p-3 mb-2">
                <div class="row">
                    <div class="col p-3 mb-2">
                        <div class="form-group row">
                            <label for="" class="col-sm-4 col-form-label mb-1">Identificación</label>
                            <div class="col-sm-5">
                                <asp:TextBox type="number" runat="server" CssClass="form-control" ID="IdentificacionEn" placeholder="" />
                            </div>
                            <label for="" class="col-sm-4 col-form-label mb-1">Ocupación</label>
                            <div class="col-sm-5">
                                <asp:TextBox type="text" onkeydown="return /[a-z, ]/i.test(event.key)" runat="server" CssClass="form-control" ID="OcupacionEn" placeholder="" />
                            </div>
                        </div>
                    </div>
                    <div class="col p-3 mb-2">
                        <div class="form-group row">
                            <label for="" class="col-sm-4 col-form-label mb-1">Nombre</label>
                            <div class="col-sm-5">
                                <asp:TextBox type="text" runat="server" onkeydown="return /[a-z, ]/i.test(event.key)" CssClass="form-control" ID="NombreEn" placeholder="" />
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="" class="col-sm-4 col-form-label mb-1">Celular</label>
                            <div class="col-sm-5">
                                <asp:TextBox type="number" runat="server" CssClass="form-control" ID="NumCelularEn" placeholder="" />
                            </div>
                        </div>
                    </div>
                    <div class="col p-3 mb-2 ">
                        <div class="form-group row">
                            <label for="" class="col-sm-4 col-form-label mb-1">Apellido</label>
                            <div class="col-sm-5">
                                <asp:TextBox type="text" onkeydown="return /[a-z, ]/i.test(event.key)" runat="server" CssClass="form-control" ID="PrimerApellidoEn" placeholder="" />
                            </div>
                            <label for="" class="col-sm-4 col-form-label mb-1">Teléfono opcional</label>
                            <div class="col-sm-5">
                                <asp:TextBox type="number" runat="server" CssClass="form-control" ID="TelefonoOpcionalEn" placeholder="" />
                            </div>
                            <div class="col-sm-1">
                                <asp:Button Text="Enviar" CssClass="btn btn-success" runat="server" ID="btnEnviar" OnClick="btnEnviar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
