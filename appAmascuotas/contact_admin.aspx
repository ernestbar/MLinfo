<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="contact_admin.aspx.cs" Inherits="appAmascuotas.contact_admin" %>
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
       <asp:ObjectDataSource ID="odsClientes" runat="server" SelectMethod="PR_CLI_GET_CLIENTES" TypeName="appAmascuotas.Clases.Clientes">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsContacts" runat="server" SelectMethod="PR_CLI_GET_CONTACTS" TypeName="appAmascuotas.Clases.Contacts">
			<SelectParameters>
				<asp:ControlParameter Name="pB_ID_CLIENT" ControlID="lblIdCliente" Type="Int64" />
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
			<asp:Label ID="lblIdCliente" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
            <asp:Label ID="lblIdContact" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-success btn-sm" OnClick="btnNuevo_Click" runat="server" Text="New Contact" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Contact Admin <small></small></h1>
											<!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Client:</label>
												<div class="col-md-6">
													   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
												   <asp:DropDownList ID="ddlCliente" AutoPostBack="true" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" DataSourceID="odsClientes" DataTextField="nombre_concatenado" OnDataBound="ddlCliente_DataBound" DataValueField="ID_CLIENT"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
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
												<table id="tabla1" class="table table-striped table-bordered">
													<thead>
														<tr>
																<th class="text-nowrap">NAME</th>
																<th class="text-nowrap">SURNAMES</th>
																<th class="text-nowrap">EMAIL</th>
																<th class="text-nowrap">PHONE</th>
																<th class="text-nowrap">MOBILE</th>
																<th class="text-nowrap">COMMENTS</th>
																<th class="text-nowrap">ESTADO</th>
															<th class="text-nowrap" data-orderable="false">OPTIONS</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsContacts" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
																<td><asp:Label ID="Label15" runat="server" Text='<%# Eval("NAME") %>'></asp:Label></td>
																<td><asp:Label ID="Label25" runat="server" Text='<%# Eval("SURNAMES") %>'></asp:Label></td>
																<td><asp:Label ID="Label125" runat="server" Text='<%# Eval("EMAIL") %>'></asp:Label></td>
																<td><asp:Label ID="Label135" runat="server" Text='<%# Eval("PHONE") %>'></asp:Label></td>
																<td><asp:Label ID="Label145" runat="server" Text='<%# Eval("MOBILE") %>'></asp:Label></td>
																<td><asp:Label ID="Label1425" runat="server" Text='<%# Eval("COMMENTS") %>'></asp:Label></td>
																<td><asp:Label ID="Label14251" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("ID_CONTACT") %>' OnClick="btnEditar_Click" runat="server" Text="Edit" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("ID_CONTACT") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click" runat="server" Text="Activate/Desactivate" ToolTip="Activa o desactiva el registro" />
                                                                
																<%--<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />--%>
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
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Data Contact</legend>
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Client:</label>
						<div class="col-md-6">
                               <asp:TextBox ID="txtCliente" Enabled="false" class="form-control" runat="server"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
				
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Name:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtName" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Surname:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtSurname" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSurname" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Email:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Phone:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtPhone" class="form-control" runat="server"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Mobile:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtMobile" class="form-control"  runat="server"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Comments:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtComments" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server"  OnClick="btnGuardar_Click" Text="Save" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancel" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
    </asp:MultiView>
	
			
		</div>
		<!-- end #content -->
	


       
</asp:Content>
