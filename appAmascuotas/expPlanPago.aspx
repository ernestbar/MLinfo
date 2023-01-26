<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="expPlanPago.aspx.cs" Inherits="appAmascuotas.expPlanPago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>AmasCuotas reporte de plande pagos</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.1/css/bootstrap.css">
	<link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css">
	<link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.5.2/css/buttons.bootstrap4.min.css">
	<link rel="stylesheet" href="https://cdn.datatables.net/responsive/2.2.3/css/responsive.bootstrap4.min.css">
</head>
<body>
    <form id="form1" runat="server">
		<asp:Label ID="lblCodSimulador" runat="server" Text="0" Visible="false"></asp:Label>
		 <asp:ObjectDataSource ID="odsPlanPago" runat="server" SelectMethod="Lista_plan_pago" TypeName="appAmascuotas.simular">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodSimulador" Name="PV_COD_SIMULADOR" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
		   <asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
        <div class="container-fluid">
            <table id="example" class="table table-striped table-bordered dt-responsive nowrap" style="width:100%">
        <thead>
														<tr class="gradeA">
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
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnVolverSimuldores" class="btn-sm btn-success btn-block" OnClick="btnVolverSimuldores_Click" runat="server" Text="Volver" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.bootstrap4.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.print.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.colVis.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.2.3/js/dataTables.responsive.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.2.3/js/responsive.bootstrap4.min.js"></script>
    <script>
	$(document).ready(function() {
	    var table = $('#example').DataTable( {
			lengthChange: false,
	        buttons: [ 'pdf' ]
	    } );
	 
	    table.buttons().container()
	        .appendTo( '#example_wrapper .col-md-6:eq(0)' );
	} );
    </script>
</body>
</html>
