<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="simulador_detalle.aspx.cs" Inherits="appAmascuotas.simulador_detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ObjectDataSource ID="odsClienteDetalle" runat="server" SelectMethod="Lista_clientes_detalle" TypeName="appAmascuotas.simular">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodCliente" Name="PV_COD_CLIENTE" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
	<asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblAviso" runat="server" Text="" Visible="true"></asp:Label>
	<asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <div id="content" class="content">
			<!-- begin breadcrumb -->
			<%--<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Home</a></li>
				<li class="breadcrumb-item"><a href="javascript:;">Tables</a></li>
				<li class="breadcrumb-item"><a href="javascript:;">Managed Tables</a></li>
				<li class="breadcrumb-item active">ColReorder</li>
			</ol>--%>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">AmasCuotas<small> simulaciones detalle</small></h1>
			<!-- end page-header -->
			<!-- begin row -->
			<div class="row">
				<!-- begin col-2 -->
				<%--<div class="col-lg-2">
					<h5>
						Key features include:
					</h5>
					<ul class="p-l-25 m-b-15">
						<li>Very easy integration with DataTables</li>
						<li>Tight integration with all other DataTables plug-ins</li>
						<li>The ability to exclude the first (or more) column from being movable</li>
						<li>Predefine a column order</li>
						<li>Save staving integration with DataTables</li>
					</ul>
					<p class="m-b-20">
						<a href="http://www.datatables.net/extensions/colreorder/" target="_blank" class="btn btn-inverse btn-sm">View Official Website</a>
					</p>
				</div>--%>
				<!-- end col-2 -->
				<!-- begin col-10 -->
				<div class="col-lg-10">
					<!-- begin panel -->
					<div class="panel panel-inverse">
						<!-- begin panel-heading -->
						<div class="panel-heading">
							<div class="panel-heading-btn">
								<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
								<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
								<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
								<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
							</div>
							<h4 class="panel-title">Simulaciones</h4>
						</div>
						<!-- end panel-heading -->
						<!-- begin alert -->
						<%--<div class="alert alert-success fade show">
							<button type="button" class="close" data-dismiss="alert">
							<span aria-hidden="true">&times;</span>
							</button>
							ColReorder adds the ability for the end user to click and drag column headers to reorder a table as they see fit, to DataTables. <br />
							Try to drag over any table header below.
						</div>--%>
						<!-- end alert -->
						<!-- begin panel-body -->
						<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">FECHA</th>
															<th class="text-nowrap">COD SIMULADOR</th>
															<th class="text-nowrap">MONTO A FINANCIAR EN BS</th>
															<th class="text-nowrap">PLAZO</th>
															<th class="text-nowrap">VALOR TOTAL PASAJES</th>
															<th class="text-nowrap">CUOTA INICIAL</th>
															<th class="text-nowrap">% CUOTA INICIAL</th>
															<th class="text-nowrap">PRIMA</th>
															<th class="text-nowrap">OPCIONES</th>
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater2" DataSourceID="odsClienteDetalle" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<td><asp:Label ID="lblFecha" runat="server" Text='<%# Eval("FECHA") %>'></asp:Label></td>
															<td><asp:Label ID="lblCodSim" runat="server" Text='<%# Eval("COD_SUMULADOR") %>'></asp:Label></td>
															<td><asp:Label ID="lblPrestamo" runat="server" Text='<%# Eval("PRESTAMO_BS") %>'></asp:Label></td>
															<td><asp:Label ID="lblPlazo" runat="server" Text='<%# Eval("PLAZO") %>'></asp:Label></td>
															<td><asp:Label ID="lblAmortizacion" runat="server" Text='<%# Eval("TOTAL_PRESTAMO") %>'></asp:Label></td>
															<td><asp:Label ID="lblSeguro" runat="server" Text='<%# Eval("SALDO_INICIAL") %>'></asp:Label></td>
																<td><asp:Label ID="lblSpreed" runat="server" Text='<%# Eval("CUOTA_INICIAL") %>'></asp:Label></td>
																<td><asp:Label ID="lblInteres" runat="server" Text='<%# Eval("PRIMA") %>'></asp:Label></td>
																<td><asp:Button ID="btnPlanPago" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_SUMULADOR") %>' OnClick="btnPlanPago_Click" runat="server" Text="Imprimir" ToolTip="Imprime el plan pago" /></td>
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>
								</div>
						<!-- end panel-body -->
					</div>
					<!-- end panel -->
				</div>
				<!-- end col-10 -->
			</div>
			<!-- end row -->
		<!-- begin form-group row -->
										<div class="form-group">
											
											<div class="col-md-3 float-right">
                                                <asp:Button ID="btnVolverDetalle" class="btn-sm btn-success btn-block float-right" OnClick="btnVolverDetalle_Click" runat="server" Text="Volver" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
		</div>
		<!-- end #content -->
					
	
</asp:Content>
