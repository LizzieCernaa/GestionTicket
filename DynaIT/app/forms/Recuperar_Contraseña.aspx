<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recuperar_Contraseña.aspx.cs" Inherits="DynaIT.app.forms.Recuperar_Contraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DynamicsIT</title>
     <link href="../style/Style.css" rel="stylesheet" />
    <script src="../../js/Validacion_JavaScript.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="../style/style_login.css" rel="stylesheet" />
    <script src="../js/Validacion_JavaScript.js"></script>
</head>
<body>
    <form id="Recuperar_contraseña" runat="server">    
            <div class="wrapper fadeInDown" >
             <div class="formContent" style="margin-top:60px;">                 
                  <div style="margin: 30px;">
                        <img src="../img/dynamics.jpg" />
                  </div>
                
                 <div>
                     <asp:TextBox ID="Txt_correo_recupera" runat="server" CssClass="" placeholder="Correo de recuperación" ></asp:TextBox>
                    <asp:Button Text="Recuperar" CssClass="fadeIn fourth" runat="server" ID="btn_recupera_contraseña" OnClick="btn_recupera_contraseña_Click" />
                 </div>
                 <div style="text-align:center;">
                     <a href="../login.aspx" style="color:#000000">Cancelar</a>
                 </div>
                 

             </div>  
            </div>
    </form>
</body>
</html>
