<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="personal_admin.aspx.cs" Inherits="appAmascuotas.personal_admin" %>
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
	<asp:ObjectDataSource ID="odsPersonalClientes" runat="server" SelectMethod="PR_PAR_GET_PERSONAL" TypeName="appAmascuotas.Clases.Usuarios">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsUsuarios" runat="server" SelectMethod="PR_PAR_GET_USUARIOS" TypeName="appAmascuotas.Clases.Usuarios">
		<SelectParameters>
			<asp:ControlParameter ControlID="lblCodPersonal" Name="PV_COD_PERSONAL" Type="String" />
		</SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsRoles" runat="server" SelectMethod="PR_GET_ROLES" TypeName="appAmascuotas.Clases.Roles">
		<SelectParameters>
				<asp:Parameter DefaultValue="A" Name="PV_ESTADO" Type="String" />
			</SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoDocumento" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="DOCUMENT TYPE" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCargo" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="POST" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsExpedido" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="ISSUED" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	
	
	<asp:ObjectDataSource ID="odsPais" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.Clases.Paises">
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsSucursal" runat="server" SelectMethod="PR_PAR_GET_SUCURSALES" TypeName="appAmascuotas.Clases.Sucursales">
		 </asp:ObjectDataSource>
	
	<%--<asp:ObjectDataSource ID="odsCiudad" runat="server" SelectMethod="Lista" TypeName="appRRHHadmin.Clases.Ciudades">
			<SelectParameters>
				<asp:ControlParameter Name="PI_ID_PAIS" ControlID="ddlPaisRes" DefaultValue="0" />
			</SelectParameters>
		 </asp:ObjectDataSource>--%>
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
			<asp:Label ID="lblCodPersonal" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodUsuario" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
             <asp:Label ID="lblCodUsuarioI" runat="server" Visible="false" Text=""></asp:Label>
			<asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-success btn-sm" OnClick="btnNuevo_Click" runat="server" Text="New staff" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Staff Admin<small></small></h1>
												<!-- begin form-group row -->
												
											
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
															<th class="text-wrap"></th>
															<th class="text-wrap">NAME</th>
															<th class="text-nowrap">TYPE DOC.</th>
															<th class="text-nowrap">NUMBER DOC.</th>
															<th class="text-nowrap">ISSUED</th>
															<th class="text-nowrap">POST</th>
															<th class="text-nowrap">CELULAR</th>
															<th class="text-nowrap">PHONE</th>
															<th class="text-nowrap">INTERNAL</th>
															<th class="text-nowrap">EMAIL</th>
															<th class="text-nowrap">STATE</th>
															<th class="text-nowrap" data-orderable="false">OPTIONS</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsPersonalClientes" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<td><asp:Image ID="Image1" Height="30px" runat="server" ImageUrl='<%# "~/Imagenes/usuarios/" + Eval("NUMERO_DOCUMENTO") +".jpg" %>' /></td>
															<td><asp:Label ID="lblNombre" runat="server" Text='<%# Eval("NOMBRE_COMPLETO") %>'></asp:Label></td>
																<td><asp:Label ID="lblPaterno" runat="server" Text='<%# Eval("TIPO_DOCUMENTO") %>'></asp:Label></td>
																<td><asp:Label ID="lblMaterno" runat="server" Text='<%# Eval("NUMERO_DOCUMENTO") %>'></asp:Label></td>
																<td><asp:Label ID="lblMarital" runat="server" Text='<%# Eval("EXPEDIDO") %>'></asp:Label></td>
																<td><asp:Label ID="lblTipoDoc" runat="server" Text='<%# Eval("COD_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNumDoc" runat="server" Text='<%# Eval("CELULAR") %>'></asp:Label></td>
																<td><asp:Label ID="lblComplemento" runat="server" Text='<%# Eval("FIJO") %>'></asp:Label></td>
																<td><asp:Label ID="lblExpedido" runat="server" Text='<%# Eval("INTERNO") %>'></asp:Label></td>
																<td><asp:Label ID="lblSucursal" runat="server" Text='<%# Eval("EMAIL") %>'></asp:Label></td>
															<td><asp:Label ID="lblArea" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_PERSONAL") %>' OnClick="btnEditar_Click" runat="server" Text="Edit" ToolTip="Edit" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("COD_PERSONAL") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('Are you shure to delete register???')" runat="server" Text="Activate/Deactivate" ToolTip="Borrar registro" />
																<asp:Button ID="btnUsuarios" class="btn btn-success btn-sm" CommandArgument='<%# Eval("COD_PERSONAL") %>' OnClick="btnUsuarios_Click" runat="server" Text="Users" ToolTip="User of staff" />
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
				<div class="col-md-8 offset-md-1">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Staff</legend>
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Immediate supervisor:</label>
						<div class="col-md-6">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlSupervisor" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						   <asp:DropDownList ID="ddlSupervisor" DataSourceID="odsPersonalClientes" DataTextField="nombre_completo" OnDataBound="ddlSupervisor_DataBound" DataValueField="cod_personal"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>  
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Branch office:</label>
						<div class="col-md-6">
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlSucursal" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						    <asp:DropDownList ID="ddlSucursal"  ForeColor="Black" DataSourceID="odsSucursal" OnDataBound="ddlSucursal_DataBound" DataTextField="DESCRIPCION" DataValueField="COD_SUCURSAL" class="form-control" runat="server"></asp:DropDownList>
						</div>
                        
					</div>
					<!-- end form-group row -->
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Name complete:</label>
						<div class="col-md-6">
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtnombres" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtNombres" runat="server" class="form-control" ForeColor="Black" placeholder="NAMES"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Type Document:</label>
						<div class="col-md-6">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoDocumento" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
						   <asp:DropDownList ID="ddlTipoDocumento" DataSourceID="odsTipoDocumento" DataTextField="descripcion" OnDataBound="ddlTipoDocumento_DataBound" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Number Document:</label>
						<div class="col-md-6">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNumeroDocumento" Font-Bold="True"></asp:RequiredFieldValidator>
						    <asp:TextBox ID="txtNumeroDocumento" ForeColor="Black" class="form-control" runat="server"  placeholder="NUMBER DOCUMENT"></asp:TextBox>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Issued:</label>
						<div class="col-md-6">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoDocumento" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
						    <asp:DropDownList ID="ddlExpedido"  ForeColor="Black" DataSourceID="odsExpedido" OnDataBound="ddlExpedido_DataBound" DataTextField="descripcion" DataValueField="codigo" class="form-control" runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Post:</label>
						<div class="col-md-6">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCargo" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlCargo" DataSourceID="odsCargo" OnDataBound="ddlCargo_DataBound" DataTextField="descripcion" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Celular:</label>
						<div class="col-md-6">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
						     <asp:TextBox ID="txtCelular" ForeColor="Black" class="form-control" runat="server" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Phone:</label>
						<div class="col-md-6">
						     <asp:TextBox ID="txtFijo" ForeColor="Black" class="form-control" runat="server" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Internal:</label>
						<div class="col-md-6">
						     <asp:TextBox ID="txtInterno" ForeColor="Black" class="form-control" runat="server" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Email:</label>
						<div class="col-md-6">
							                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtEmail" ForeColor="Black" class="form-control" runat="server"  placeholder="Correo Electronico"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<%--<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">User Name:</label>
						<div class="col-md-6">
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsuario" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtUsuario" runat="server" class="form-control" ForeColor="Black" placeholder="USER NAME"></asp:TextBox>
						</div>
					</div>--%>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<%--<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Passsord:</label>
						<div class="col-md-6">
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtPassword" runat="server" class="form-control" ForeColor="Black" placeholder="PASSWORD USUARIO"></asp:TextBox>
						</div>
					</div>--%>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Role:</label>
						<div class="col-md-6">
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlRol" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
						    <asp:DropDownList ID="ddlRol"  ForeColor="Black" DataSourceID="odsRoles" OnDataBound="ddlRol_DataBound" DataTextField="DESCRIPCION" DataValueField="ROL" class="form-control" runat="server"></asp:DropDownList>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Date from:</label>
						<div class="col-md-6">
							<asp:Label ID="lblFechaDesde" Visible="false" runat="server" Text=""></asp:Label>
						    <input id="fecha_salida" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Date to:</label>
						<div class="col-md-6">
							<asp:Label ID="lblFechaHasta" Visible="false" runat="server" Text=""></asp:Label>
						    <input id="fecha_retorno" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaRetorno" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Description:</label>
						<div class="col-md-6">
						                <asp:TextBox ID="txtDescripcion" ForeColor="Black" TextMode="MultiLine"  class="form-control" runat="server" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Photo:</label>
						<div class="col-md-6">
							<asp:FileUpload ID="fuPhoto" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" OnClientClick="recuperarFechaSalida()" OnClick="btnGuardar_Click" Text="Save" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancel" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		<asp:View ID="View3" runat="server">
										
										<!-- begin page-header -->
											<h1 class="page-header">User Admin<small></small></h1>
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
															<%--<th class="text-wrap">FOTO</th>--%>
															<th class="text-wrap">USER NAME</th>
															<th class="text-nowrap">ROL</th>
															<th class="text-nowrap">DATE FROM</th>
															<th class="text-nowrap">DATE TO</th>
															<th class="text-nowrap">DESCRIPTION</th>
															<th class="text-nowrap">ESTATE</th>
															<th class="text-nowrap" data-orderable="false">OPTIONS</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater2" DataSourceID="odsUsuarios" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("filecontent"))  %>' /></td>--%>
															<td><asp:Label ID="lblNombre" runat="server" Text='<%# Eval("USUARIO") %>'></asp:Label></td>
																<td><asp:Label ID="lblPaterno" runat="server" Text='<%# Eval("DESC_ROL") %>'></asp:Label></td>
																<td><asp:Label ID="lblMaterno" runat="server" Text='<%# Eval("FECHA_DESDE") %>'></asp:Label></td>
																<td><asp:Label ID="lblMarital" runat="server" Text='<%# Eval("FECHA_HASTA") %>'></asp:Label></td>
																<td><asp:Label ID="lblTipoDoc" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
															<td><asp:Label ID="lblArea" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnResetear" class="btn btn-success btn-sm" CommandArgument='<%# Eval("USUARIO") %>' OnClick="btnResetear_Click" OnClientClick="return confirm('Are you shure reset your password???')" runat="server" Text="Reset Password" ToolTip="Reset password to 123" />
																<asp:Button ID="btnCambiarPassword" class="btn btn-success btn-sm" CommandArgument='<%# Eval("USUARIO") %>' OnClick="btnCambiarPassword_Click" runat="server" Text="Change Password" ToolTip="Change current password" />
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
		<asp:View ID="View4" runat="server">
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-8 offset-md-1">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Change password</legend>
			<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Current Password:</label>
						<div class="col-md-6">
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPasswordAnterior" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtPasswordAnterior" runat="server" class="form-control" ForeColor="Black" TextMode="Password" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">New Password:</label>
						<div class="col-md-6">
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtPassword" runat="server" class="form-control" ForeColor="Black" TextMode="Password" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- end form-group row -->
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar2" CssClass="btn btn-success" runat="server"  OnClick="btnGuardar2_Click" Text="Save" />
							<asp:Button ID="btnCancelar2" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnCancelar2_Click" Text="Cancel" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
		</asp:View>
    </asp:MultiView>
	
		</div>
		<!-- end #content -->
	<script type="text/javascript">

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
            document.getElementById('<%=hfFechaRetorno.ClientID%>').value = document.getElementById('fecha_retorno').value;
		}
        function setearFechaSalida() {
            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
		}
        function setearFechaRetorno() {
            document.getElementById('fecha_retorno').value = document.getElementById('<%=hfFechaRetorno.ClientID%>').value;
        }
    </script>
</asp:Content>
