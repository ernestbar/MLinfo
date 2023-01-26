<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reporteContrato.aspx.cs" Inherits="appAmascuotas.reporteContrato" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
	<asp:Label ID="lblCodSolicitud" runat="server" Text="0" Visible="false"></asp:Label>
	<asp:Label ID="lblCodCliente" runat="server" Text="0" Visible="false"></asp:Label>
	<asp:Label ID="lblTipoCliente" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblAviso" runat="server" Visible="true" Text=""></asp:Label> 
	<asp:Label ID="lblGarante" runat="server" Visible="false" Text=""></asp:Label> 
<!-- begin #content -->
	<div id="content" class="content">
		<div class="row">
			<h1 class="page-header">AmasCuotas <small>Formulario Juridica</small></h1>
			<br />
			 <div style="overflow-y: auto; height:600px;width:90%">
			<rsweb:ReportViewer ID="rv" runat="server" Height="100%" Width="90%" ShowZoomControl="False" ShowRefreshButton="False" ShowPageNavigationControls="True" ShowFindControls="False" ShowBackButton="False" SizeToReportContent="True"></rsweb:ReportViewer>
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-3 float-right">
				<asp:Button ID="btnVolver"   class="btn-sm btn-success btn-block float-right" OnClick="btnVolver_Click" runat="server" Text="Volver" />
			</div>	
		</div>
<!-- end #content -->
	</div>
</asp:Content>