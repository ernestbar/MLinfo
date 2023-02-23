<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mapa_cliente.aspx.cs" Inherits="appAmascuotas.mapa_cliente" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MlInfo</title>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB6XhmQ0TrlvdgfDu59q1lTyBp5NskGo7I&region=BO&callback=initMap"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc:GMap ID="Gmap3" runat="server" mapType="Normal" Height="840" Width="1024" enableGoogleBar="True" />
        </div>
    </form>
</body>
</html>
