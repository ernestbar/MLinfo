<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="type_clients.aspx.cs" Inherits="appAmascuotas.type_clients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .dataTables_wrapper .myfilter .dataTables_filter {
        float:left
    }
    .dataTables_wrapper .mylength .dataTables_length {
        float:right
    }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            // Se inicializa la tabla con las opciones requeridas
            $('#tabla1').dataTable({
                dom: '<"myfilter"f><"mylength"l>Brtip',
                buttons: [
                    //{ extend: 'copy', className: 'btn-sm', text: 'Copiar' },
                    //{ extend: 'csv', className: 'btn-sm', text: 'CSV' },
                    //{ extend: 'excel', className: 'btn-sm', text: 'Excel' },
                    //{ extend: 'pdf', className: 'btn-sm', text: 'PDF' },
                    //{ extend: 'print', className: 'btn-sm', text: 'Imprimir' }
                ],
                responsive: true,
                autoFill: true,
                colReorder: true,
                keys: true,
                rowReorder: false,
                select: 'single',
                language: {
                    "decimal": "",
                    "emptyTable": "No information",
                    "info": "Showing _START_ of _TOTAL_ entries",
                    "infoEmpty": "Showing 0 of 0 entries",
                    "infoFiltered": "(Filtered of _MAX_ total records)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Show _MENU_ records",
                    "loadingRecords": "Loadin...",
                    "processing": "Processing...",
                    "search": "Filter records:",
                    "zeroRecords": "No records found",
                    "paginate": {
                        "first": "First",
                        "last": "Last",
                        "next": "Next",
                        "previous": "Previous"
                    },
                    "select": {
                        rows: "%d fila(s) seleccionada(s)"
                    }
                }
            });

            var table = $('#tabla-rol').DataTable();
            $('div.dataTables_filter input', table.table().container()).focus();


            var dt = $('#tabla-rol').DataTable();

            //********** Para ocultar columnas
            dt.column(0).visible(true)

            //********** Manejo de selección de filas
            // Seleccionar fila
           <%-- $('#tabla-rol tbody').on('click', 'tr', function () {
                var hfIdRol = document.getElementById('<%=hfIdRol.ClientID%>');
                if (dt.rows(this).count() > 0) {
                    var id_rol = dt.row(this).data()[0];
                    hfIdRol.value = id_rol;
                }
                else {
                    hfIdRol.value = "";
                }
            });--%>
            //********** Manejo de selección de filas
        });

    </script>
    <asp:ObjectDataSource ID="odsTypeClients" runat="server" SelectMethod="PR_PAR_GET_CLIENT_TYPES" TypeName="appAmascuotas.Clases.Client_types">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTypeClientsHist" runat="server" SelectMethod="PR_PAR_GET_CLIENT_TYPES_HIST" TypeName="appAmascuotas.Clases.Client_types">
		<SelectParameters>
				<asp:ControlParameter ControlID="lblIdTypeCliente" Name="PV_ID_CLIENTS_TYPE_" Type="String" />
			</SelectParameters>
		</asp:ObjectDataSource>
	<style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
	<script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
	<!-- begin #content -->
		<div id="content" class="content">
			<asp:SiteMapPath ID="SiteMapPath1" Runat="server" Font-Names="Verdana" Font-Size="0.8em" PathSeparator=" : ">
                <CurrentNodeStyle ForeColor="#333333" />
                <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
                <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
                <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
			</asp:SiteMapPath>
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblIdTypeCliente" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
            <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-success btn-sm" OnClick="btnNuevo_Click" runat="server" Text="New type of client" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Type of Clients Admin <small></small></h1>
											
										<!-- end page-header -->
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
													<h4 class="panel-title">Records</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="tabla1" class="table table-striped table-bordered">
													<thead>
														<tr>
																<th class="text-nowrap">CLIENT TYPE CODE</th>
																<th class="text-nowrap">DESCRIPTION</th>
																<th class="text-nowrap">HOURLY RATE</th>
																<th class="text-nowrap">TRAVEL FEE</th>
																<th class="text-nowrap">REMINDER FEE FIRST</th>
																<th class="text-nowrap">REMINDER FEE SECOND</th>
																<th class="text-nowrap">REMINDER FEE THIRD</th>
																<th class="text-nowrap">RATE LATE PAYMENT</th>
																<th class="text-nowrap">STATE</th>
															<th class="text-nowrap" data-orderable="false">OPTIONS</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsTypeClients" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
																<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("ID_CLIENTS_TYPE") %>'></asp:Label></td>
																<td><asp:Label ID="Label34" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label></td>
																<td><asp:Label ID="Label21" runat="server" Text='<%# Eval("HOURLY_RATE") %>'></asp:Label></td>
																<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("TRAVEL_FEE") %>'></asp:Label></td>
																<td><asp:Label ID="Label23" runat="server" Text='<%# Eval("REMINDER_FEE_FIRST") %>'></asp:Label></td>
																<td><asp:Label ID="Label24" runat="server" Text='<%# Eval("REMINDER_FEE_SECOND") %>'></asp:Label></td>
																<td><asp:Label ID="Label25" runat="server" Text='<%# Eval("REMINDER_FEE_THIRD") %>'></asp:Label></td>
																<td><asp:Label ID="Label26" runat="server" Text='<%# Eval("RATE_LATE_PAYMENT") %>'></asp:Label></td>
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("ID_CLIENTS_TYPE") %>' OnClick="btnEditar_Click" runat="server" Text="Edit" ToolTip="Edit" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("ID_CLIENTS_TYPE") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click" runat="server" Text="Activate/Desactivate" ToolTip="Activate or desactivate records" />
																<asp:Button ID="btnHistory" class="btn btn-success btn-sm" CommandArgument='<%# Eval("ID_CLIENTS_TYPE") %>' OnClick="btnHistory_Click" runat="server" Text="Historical" ToolTip="Historical" />
															</td>
															
															
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
        </asp:View>
		 <asp:View ID="View2" runat="server">
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-6 offset-md-2">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Data type of client</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Client type code:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtClientTypeCode" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtClientTypeCode" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Description:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtDescripcion" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDescripcion" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Hourly rate:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtHourlyDate" class="form-control" Text="0" runat="server"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtHourlyDate" runat="server" ErrorMessage="*Only Numbers" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Travel fee:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtTravelFee" class="form-control" Text="0" runat="server"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTravelFee" runat="server" ErrorMessage="*Only Numbers" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Reminder fee first:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtRemind1" class="form-control" Text="0" runat="server"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtRemind1" runat="server" ErrorMessage="*Only Numbers" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Reminder fee second:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtRemind2" class="form-control" Text="0" runat="server"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtRemind2" runat="server" ErrorMessage="*Only Numbers" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Reminder fee third:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtRemind3" class="form-control" Text="0" runat="server"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtRemind3" runat="server" ErrorMessage="*Only Numbers" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Rate late payment:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtRateLate" class="form-control" Text="0" runat="server"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtRateLate" runat="server" ErrorMessage="*Only Numbers" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
						</div>
					</div>
					<!-- end form-group row -->
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" OnClick="btnGuardar_Click" Text="Save" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancel" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		<asp:View ID="View3" runat="server">
			<!-- begin page-header -->
											<h1 class="page-header">Client types historical<small></small></h1>
												<!-- begin form-group row -->
												
											<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnVolverUser" class="btn btn-success btn-sm" OnClick="btnVolverUser_Click" runat="server" Text="Return" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
												<!-- end form-group row -->
											<!-- end page-header -->
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
													<h4 class="panel-title">Records</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">DESCRIPTION</th>
																<th class="text-nowrap">HOURLY RATE</th>
																<th class="text-nowrap">TRAVEL FEE</th>
																<th class="text-nowrap">REMINDER FEE FIRST</th>
																<th class="text-nowrap">REMINDER FEE SECOND</th>
																<th class="text-nowrap">REMINDER FEE THIRD</th>
																<th class="text-nowrap">RATE LATE PAYMENT</th>
																<th class="text-nowrap">DATE</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater2" DataSourceID="odsTypeClientsHist" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
														<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label></td>
																<td><asp:Label ID="Label21" runat="server" Text='<%# Eval("HOURLY_RATE") %>'></asp:Label></td>
																<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("TRAVEL_FEE") %>'></asp:Label></td>
																<td><asp:Label ID="Label23" runat="server" Text='<%# Eval("REMINDER_FEE_FIRST") %>'></asp:Label></td>
																<td><asp:Label ID="Label24" runat="server" Text='<%# Eval("REMINDER_FEE_SECOND") %>'></asp:Label></td>
																<td><asp:Label ID="Label25" runat="server" Text='<%# Eval("REMINDER_FEE_THIRD") %>'></asp:Label></td>
																<td><asp:Label ID="Label26" runat="server" Text='<%# Eval("RATE_LATE_PAYMENT") %>'></asp:Label></td>
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("DATE") %>'></asp:Label></td>
															
															
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
		</asp:View>

    </asp:MultiView>
	
			
		</div>
		<!-- end #content -->
</asp:Content>
