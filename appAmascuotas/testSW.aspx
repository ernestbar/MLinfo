<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="testSW.aspx.cs" Inherits="appAmascuotas.testSW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" class="content">
		<div class="row">
            <asp:TextBox ID="txtCodigoReserva" runat="server"></asp:TextBox>
    <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" Text="Button" />
    <asp:Label ID="lblResultado" runat="server" Text="Resultado"></asp:Label>
        </div></div>
</asp:Content>
