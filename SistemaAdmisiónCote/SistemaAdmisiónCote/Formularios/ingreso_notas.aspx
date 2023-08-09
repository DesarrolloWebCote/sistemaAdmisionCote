<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoNotas1.aspx.cs" Inherits="Ingreso_de_notas.IngresoNotas1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link href="bootstrap-5.0.2-dist/css/bootstrap.css" rel="stylesheet" />
     <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-2">

                </div>              
                <div class="col-1">

                </div>
                <div class="col-8">
                    <div class="mt-5">
                        <h1 class="fs-1">INGRESO DE NOTAS DE: </h1>
                    </div>

                    <div class="row mt-4" >
                        <div class="col-2">
                            <label class="fs-5">Identificación</label>
                        </div>
                        <div class="col-5">
                            <asp:TextBox CssClass="w-100 form-control " BorderStyle="None" ID="txt_identificacion" runat="server"  BackColor="#EEEEEE"></asp:TextBox>
                        </div>
                        <div class="col-1">
                            <button style="width:50px" class=" btn btn-primary" runat="server"><i class='bx bx-search-alt'></i></button>
                        </div>
                     </div>


                    <div class="row mt-3 ">
                        <div class="col-2">
                            
                        </div>
                        <div class="col-3 text-center">
                            <p class="fw-bold">8°</p>
                        </div>
                        <div class="col-3 text-center">
                            <p class="fw-bold">9°</p>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-2">
                            <label class="fs-5">Español</label>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control " ID="TextBox14" runat="server" BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox15" runat="server"  BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-2">
                            <label class="fs-5">Matemáticas</label>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox1" runat="server" BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox2" runat="server"  BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-2">
                            <label class="fs-5">Ciencias</label>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox3" runat="server" BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox4" runat="server"  BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-2">
                            <label class="fs-5">Inglés</label>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox5" runat="server" BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox6" runat="server"  BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-2">
                            <label class="fs-5">Est. Sociales</label>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox7" runat="server" BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox8" runat="server"  BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-2">
                            <label class="fs-5">Cívica</label>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox9" runat="server" BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox10" runat="server"  BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-2">
                            <label class="fs-5">Conducta</label>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox11" runat="server" BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                        <div class="col-3 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox12" runat="server"  BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-2">
                            <label class="fs-5">Promedio</label>
                        </div>
                        <div class="col-6 text-center">
                             <asp:TextBox CssClass="w-100 form-control" ID="TextBox13" runat="server" BackColor="#EEEEEE" BorderStyle="None"></asp:TextBox>
                        </div>
                        <div class="col-1 text-center">
                           
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-3">
                            
                        </div>
                        <div class="col-2">
                            <asp:Button Text="Guardar" runat="server" CssClass="btn btn-success m-sm-2 px-3 rounded-3 fs-4" />
                        </div>
                        <div class="col-2">
                            <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger m-sm-2 px-3 rounded-3 fs-4 " />
                        </div>
                    </div>
                </div>
                </div>
                <div class="col-1">
                   
                </div>
        </div>
    </form>
</body>
</html>
