<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listasPrueba.aspx.cs" Inherits="DynaIT.app.forms.listasPrueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../style/Style.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="../js/js.js"></script>
</head>
<body>
    
    <form id="form1" runat="server">
         <input type="button" value="Genera una tabla" onclick="genera_tabla()"/>
            <div class="bodyTicket">
                             
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                   
          
        </div>
       <%-- <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </asp:Panel>--%>
       </form>

</body>
</html>
