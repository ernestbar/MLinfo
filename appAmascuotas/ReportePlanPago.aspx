<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ReportePlanPago.aspx.cs" Inherits="appAmascuotas.ReportePlanPago" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
	<asp:Label ID="lblCodSimulador" runat="server" Text="0" Visible="false"></asp:Label>
	<asp:Label ID="lblCodCliente" runat="server" Text="0" Visible="false"></asp:Label>
		<asp:Label ID="lblAviso" runat="server" Text="" Visible="true"></asp:Label>
		 <asp:ObjectDataSource ID="odsPlanPago" runat="server" SelectMethod="Lista_plan_pago" TypeName="appAmascuotas.simular">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodSimulador" Name="PV_COD_SIMULADOR" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
<!-- begin #content -->
		<div id="content" class="content">
			<div class="row">
			<!-- begin breadcrumb -->
		<%--	<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Home</a></li>
				<li class="breadcrumb-item"><a href="javascript:;">Tables</a></li>
				<li class="breadcrumb-item"><a href="javascript:;">Managed Tables</a></li>
				<li class="breadcrumb-item active">Buttons</li>
			</ol>--%>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">AmasCuotas <small>Plan Pago</small></h1>
			<!-- end page-header -->
				<br />
				
										
												<rsweb:ReportViewer ID="rv" runat="server" Height="600px" Width="90%" ShowZoomControl="False" ShowRefreshButton="False" ShowPageNavigationControls="False" ShowFindControls="False" ShowBackButton="False"></rsweb:ReportViewer>
		
				</div>
			
				<div class="form-group">
											
											<div class="col-md-3 float-right">
											
												<asp:Button ID="btnVolver"   class="btn-sm btn-success btn-block float-right" OnClick="btnVolver_Click" runat="server" Text="Volver" />
										</div>	
					</div>
		
		<!-- end #content -->
	</div>
</asp:Content>
