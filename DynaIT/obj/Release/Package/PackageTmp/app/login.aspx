<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DynaIT.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DynamicsIT</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
   

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous" />

    <link href="style/style_login.css" rel="stylesheet" />
   <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</head>
<body>

    <div class="wrapper fadeInDown">
        <div id="formContent">
            <!-- Tabs Titles -->


            <!-- Icon -->
            <div class="fadeIn first" style="margin: 20px;">
                <img src="img/dynamics.jpg" class="" id="icon" alt="User Icon" />
            </div>

            <!-- Login Form -->
            <form runat="server">
                <asp:TextBox ID="Tex_correo" runat="server" CssClass="fadeIn second" placeholder="correo@correo.com"></asp:TextBox>
                <asp:TextBox ID="Text_password" runat="server" type="password" CssClass="fadeIn third" placeholder="Contraseña"></asp:TextBox>
                <asp:Button ID="Btn_ingresar" runat="server" Text="Ingresar" CssClass="fadeIn fourth" OnClick="Btn_ingresar_Click" />

            </form>

            <!-- Remind Passowrd -->
            <div id="formFooter">

                <a class="underlineHover" href="forms/Recuperar_Contraseña.aspx">¿Olvido su contraseña?</a>
            </div>

        </div>
    </div>


</body>
</html>
