<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plan_pagos.aspx.cs" Inherits="appAmascuotas.plan_pagos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Amascuotas</title>
	<!-- ================== BEGIN BASE CSS STYLE ================== -->
	<link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
	<link href="assets/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
	<link href="assets/plugins/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/font-awesome/5.3/css/all.min.css" rel="stylesheet" />
	<link href="assets/plugins/animate/animate.min.css" rel="stylesheet" />
	<link href="assets/css/default/style.min.css" rel="stylesheet" />
	<link href="assets/css/default/style-responsive.min.css" rel="stylesheet" />
	<link href="assets/css/default/theme/default.css" rel="stylesheet" id="theme" />
	<!-- ================== END BASE CSS STYLE ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL STYLE ================== -->
	<link href="assets/plugins/jquery-smart-wizard/src/css/smart_wizard.css" rel="stylesheet" />
	<!-- ================== END PAGE LEVEL STYLE ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL CSS STYLE ================== -->
	<link href="assets/plugins/jquery-jvectormap/jquery-jvectormap.css" rel="stylesheet" />
	<link href="assets/plugins/bootstrap-calendar/css/bootstrap_calendar.css" rel="stylesheet" />
	<link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" />
	<link href="assets/plugins/nvd3/build/nv.d3.css" rel="stylesheet" />

	<link href="assets/plugins/DataTables/media/css/dataTables.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/RowReorder/css/rowReorder.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/Responsive/css/responsive.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/Buttons/css/buttons.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/ColReorder/css/colReorder.bootstrap.min.css" rel="stylesheet" />
	<!-- ================== END PAGE LEVEL CSS STYLE ================== -->
	<link href="assets/plugins/parsley/src/parsley.css" rel="stylesheet" />
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/pace/pace.min.js"></script>
	<!-- ================== END BASE JS ================== -->
</head>
<body>
    <form id="form1" runat="server">
		<asp:Label ID="lblCodSimulador" runat="server" Text="0" Visible="false"></asp:Label>
		 <asp:ObjectDataSource ID="odsPlanPago" runat="server" SelectMethod="Lista_plan_pago" TypeName="appAmascuotas.simular">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodSimulador" Name="PV_COD_SIMULADOR" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
       <div id="content" >
			<h1 class="page-header">AmasCuotas <small>Plan Pago</small></h1>
			<!-- end page-header -->
			<!-- begin row -->
			<div class="row">
				
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
							<h4 class="panel-title">Plan de pago</h4>
						</div>
						<asp:Label ID="lblAviso" runat="server" Visible="true" Text=""></asp:Label> 
						<!-- end panel-heading -->
						<!-- begin alert -->
						<%--<div class="alert alert-warning fade show">
							<button type="button" class="close" data-dismiss="alert">
							<span aria-hidden="true">&times;</span>
							</button>
							The Buttons extension for DataTables provides a common set of options, API methods and styling to display buttons on a page that will interact with a DataTable. The core library provides the based framework upon which plug-ins can built.
						</div>--%>
						<!-- end alert -->
						<!-- begin panel-body -->
						<div class="panel-body">
							<table id="data-table-buttons" class="table table-striped table-bordered">
								<thead>
									<tr><th></th>
										<th>SIMULADOR AMASCUOTAS</th>
										<th>CLIENT</th>
										<th></th>
										<th></th>
										<th></th>
										<th></th>
									</tr>
									<tr>
										<th class="text-nowrap">NRO</th>
															<th class="text-nowrap">SALDO CAPITAL</th>
															<th class="text-nowrap">INTERES</th>
															<th class="text-nowrap">CAPITAL</th>
															<th class="text-nowrap">SEGURO</th>
															<th class="text-nowrap">CUOTA</th>
															<th class="text-nowrap">FECHA</th>
									</tr>
								</thead>
								<tbody>
										<asp:Repeater ID="Repeater3" DataSourceID="odsPlanPago" runat="server">
														<ItemTemplate>
															<tr>
																
															<td><asp:Label ID="lblNRO" runat="server" Text='<%# Eval("NRO") %>'></asp:Label></td>
															<td><asp:Label ID="lblSaldoCap" runat="server" Text='<%# Eval("SALDO_CAPITAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblInt" runat="server" Text='<%# Eval("INTERES") %>'></asp:Label></td>
															<td><asp:Label ID="lblCap" runat="server" Text='<%# Eval("CAPITAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblSeg" runat="server" Text='<%# Eval("SEGURO") %>'></asp:Label></td>
															<td><asp:Label ID="lblCuo" runat="server" Text='<%# Eval("CUOTA") %>'></asp:Label></td>
															<td><asp:Label ID="lblFech" runat="server" Text='<%# Eval("FECHA") %>'></asp:Label></td>
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
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <%--<asp:Button ID="btnVolverDetalle" class="btn-sm btn-success btn-block" OnClick="btnVolverDetalle_Click" runat="server" Text="Volver" />--%>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
		</div>
		<!-- end #content -->
    </form>
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/jquery/jquery-3.3.1.min.js"></script>
	<script src="assets/plugins/jquery-ui/jquery-ui.min.js"></script>
	<script src="assets/plugins/bootstrap/4.1.3/js/bootstrap.bundle.min.js"></script>
	<!--[if lt IE 9]>
		<script src="assets/crossbrowserjs/html5shiv.js"></script>
		<script src="assets/crossbrowserjs/respond.min.js"></script>
		<script src="assets/crossbrowserjs/excanvas.min.js"></script>
	<![endif]-->
	<script src="assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>
	<script src="assets/plugins/js-cookie/js.cookie.js"></script>
	<script src="assets/js/theme/default.min.js"></script>
	<script src="assets/js/apps.min.js"></script>
	<!-- ================== END BASE JS ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL JS ================== -->
	<script src="assets/plugins/d3/d3.min.js"></script>
	<script src="assets/plugins/nvd3/build/nv.d3.js"></script>
	<script src="assets/plugins/jquery-jvectormap/jquery-jvectormap.min.js"></script>
	<script src="assets/plugins/jquery-jvectormap/jquery-jvectormap-world-merc-en.js"></script>
	<script src="assets/plugins/bootstrap-calendar/js/bootstrap_calendar.min.js"></script>
	<%--<script src="assets/plugins/gritter/js/jquery.gritter.js"></script>--%>
	<script src="assets/js/demo/dashboard-v2.min.js"></script>
	<script src="assets/js/demo/form-wizards.demo.min.js"></script>
	<script src="assets/plugins/jquery-smart-wizard/src/js/jquery.smartWizard.js"></script>

	<script src="assets/plugins/DataTables/media/js/jquery.dataTables.js"></script>
	<script src="assets/plugins/DataTables/media/js/dataTables.bootstrap.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/RowReorder/js/dataTables.rowReorder.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/ColReorder/js/dataTables.colReorder.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/dataTables.buttons.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.bootstrap.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.flash.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/jszip.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/pdfmake.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/vfs_fonts.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.html5.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.print.min.js"></script>
	<script src="assets/js/demo/table-manage-default.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-buttons.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-rowreorder.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-colreorder.demo.min.js"></script>
	<!-- ================== END PAGE LEVEL JS ================== -->

	
	<script>
		$(document).ready(function() {
			App.init();
			DashboardV2.init();
            FormWizard.init();
            TableManageDefault.init();
			TableManageRowReorder.init();
			TableManageButtons.init();
            TableManageResponsive.init();
			TableManageColReorder.init();
            
            
		});
    </script>
</body>
</html>
