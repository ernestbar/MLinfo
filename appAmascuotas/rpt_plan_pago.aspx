<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rpt_plan_pago.aspx.cs" Inherits="appAmascuotas.rpt_plan_pago" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="content" class="content">
    <rsweb:ReportViewer ID="rptvwReportes" runat="server" Height="689px" Width="1053px" ShowBackButton="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowRefreshButton="False" ShowZoomControl="False"></rsweb:ReportViewer>
        </div>
</asp:Content>
