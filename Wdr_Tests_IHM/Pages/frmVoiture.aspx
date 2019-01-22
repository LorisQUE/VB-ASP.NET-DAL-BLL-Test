<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmVoiture.aspx.vb" Inherits="Wdr_Tests_IHM.frmVoiture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Voiture</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblVoitNom" Text="Label de la voiture" />
        <asp:TextBox runat="server" ID="txtVoitNom" />
        <br />
        <asp:Label runat="server" ID="lblKm" Text="Nombre de Km de la voiture" />
        <asp:TextBox runat="server" ID="txtKm" />
        <br />
        <asp:Label runat="server" ID="lblImmat" Text="Plaque d'immat de la voiture" />
        <asp:TextBox runat="server" ID="txtImmat" />
        <br />
        <asp:Label runat="server" ID="lblCouleur" Text="Couleur:" />
        <asp:ListBox runat="server" ID="listCoul" />
        <br />
        <asp:Label runat="server" ID="lblMarque" Text="Marque:" />
        <asp:ListBox runat="server" ID="listMarque" />
    </div>
    </form>
</body>
</html>
