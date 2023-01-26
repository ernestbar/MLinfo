<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="simulador_wiz.aspx.cs" Inherits="appAmascuotas.simulador_wiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ObjectDataSource ID="odsTipoCliente" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="TIPO CLIENTE" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsExpedido" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="EXPEDIDO" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsClientesSim" runat="server" SelectMethod="Lista_clientes_sim" TypeName="appAmascuotas.simular">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsClienteDetalle" runat="server" SelectMethod="Lista_clientes_detalle" TypeName="appAmascuotas.simular">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodCliente" Name="PV_COD_CLIENTE" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsPlanPago" runat="server" SelectMethod="Lista_plan_pago" TypeName="appAmascuotas.simular">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodSimulador" Name="PV_COD_SIMULADOR" DefaultValue="" />
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
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
	<asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblCodSimulador" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			<asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView2" runat="server">
        <asp:View ID="View4" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn-sm btn-info btn-block" OnClick="btnNuevaSimulacion_Click" runat="server" Text="Simulacion cliente nuevo" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Simulaciones <small></small></h1>
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
													<h4 class="panel-title">Simulaciones registradas</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">RAZON SOCIAL/NOMBRE</th>
															<th class="text-wrap">COD.CLIENTE</th>
															<th class="text-nowrap">TIPO CLIENTE</th>
															
															<th class="text-nowrap">TIPO DOCUMENTO</th>
															<th class="text-nowrap">NUMERO</th>
															<th class="text-nowrap">EXPEDIDO</th>
															<%--<th class="text-nowrap">TELF. FIJO</th>
															<th class="text-nowrap">TELF. CELULAR</th>
															<th class="text-nowrap">EMAIL</th>--%>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsClientesSim" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
															<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("razon_social") %>'></asp:Label></td>	
															<td><asp:Label ID="lblCodCliente1" runat="server" Text='<%# Eval("cod_cliente") %>'></asp:Label></td>
															<td><asp:Label ID="lblTipoCliente" runat="server" Text='<%# Eval("tipo_cliente") %>'></asp:Label></td>
															
															<td><asp:Label ID="lblTipoDoc" runat="server" Text='<%# Eval("tipo_documento") %>'></asp:Label></td>
															<td><asp:Label ID="lblNumero" runat="server" Text='<%# Eval("numero_documento") %>'></asp:Label></td>
															<td><asp:Label ID="lblExpedido" runat="server" Text='<%# Eval("expedido") %>'></asp:Label></td>
															<%--<td><asp:Label ID="lblTelFijo" runat="server" Text='<%# Eval("telefono_fijo") %>'></asp:Label></td>
															<td><asp:Label ID="lblTelCel" runat="server" Text='<%# Eval("telefono_celular") %>'></asp:Label></td>
															<td><asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label></td>--%>
																<td>
																	<%--<div class="btn-group btn-sm">--%>
																	  
																		<asp:Button ID="btnDetalles" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnDetalles_Click" runat="server" Text="Detalles" ToolTip="Ver detalles" />
																		<%--<asp:Button ID="btnEditar" class="btn btn-success" CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																		<asp:Button ID="btnEliminar" class="btn btn-success" CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnEliminar_Click" runat="server" Text="Eliminar" ToolTip="Eliminar" />--%>
																		<asp:Button ID="btnNuevo" class="btn btn-success btn-sm" CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnNuevo_Click1" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />
																		  
																	 
																	<%--</div>--%>
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
		 <asp:View ID="View5" runat="server">
			 <!-- begin breadcrumb -->
			<%--<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Home</a></li>
				<li class="breadcrumb-item"><a href="javascript:;">Form Stuff</a></li>
				<li class="breadcrumb-item active">Wizards + Validation</li>
			</ol>--%>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">AmasCuotas <small>simulador plan de pagos</small></h1>
			<!-- end page-header -->
			
			
				<!-- begin wizard -->
				<div id="wizard">
					<!-- begin wizard-step -->
					<ul>
						
						<li id="p1" class="col-md-3 col-sm-4 col-6">
							<a href="#step-1">
								<span class="number">1</span> 
								<span class="info text-ellipsis">
									Datos cliente
									<%--<small class="text-ellipsis">Name, Address, IC No and DOB</small>--%>
								</span>
							</a>
						</li>
						<li id="p2" class="col-md-3 col-sm-4 col-6">
							<a href="#step-2">
								<span class="number">2</span> 
								<span class="info text-ellipsis">
									Datos del credito
									<%--<small class="text-ellipsis">Name, Address, IC No and DOB</small>--%>
								</span>
							</a>
						</li>
						<li id="p3" class="col-md-3 col-sm-4 col-6">
							<a href="#step-3">
								<span class="number">3</span> 
								<span class="info text-ellipsis">
									Finalizar
									<%--<small class="text-ellipsis">Email and phone no. is required</small>--%>
								</span>
							</a>
						</li>
						
					</ul>
					
			
					<!-- end wizard-step -->
				
				</div>
				<!-- end wizard -->
			<asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
					<!-- begin step-1 -->
						<div id="step-1">
							<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										</div>
										</div>
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos del cliente</legend>
										<!-- begin form-group row -->
										<div class="form-group row m-b-12">
											<label class="col-md-3 text-md-right col-form-label">Tipo cliente</label><asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rblTipoCliente" InitialValue="" ErrorMessage="*"></asp:RequiredFieldValidator>
											<div class="col-md-6">
                                                <asp:RadioButtonList ID="rblTipoCliente" class="form-check-label"   DataSourceID="odsTipoCliente" DataTextField="descripcion" DataValueField="codigo" AutoPostBack="true" OnSelectedIndexChanged="rblTipoCliente_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal" CellPadding="10"></asp:RadioButtonList>
											</div>
										</div>
                                <asp:Panel ID="Panel_natural" Visible="false" runat="server">
										<!-- begin form-group row -->
										<div class="form-group row m-b-9">
											<label class="col-md-3 text-md-right col-form-label">Primer Nombre:</label>
											<div class="col-md-2">
                                                <asp:TextBox ID="txtNombre" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtNombre" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
											<label class="col-md-0 text-md-right col-form-label">Segundo Nombre:</label>
											<div class="col-md-2">
                                                <asp:TextBox ID="txtNombre2" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
											</div>
											<label class="col-md-0 text-md-right col-form-label">Tercer Nombre:</label>
											<div class="col-md-2">
                                                <asp:TextBox ID="txtNombre3" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido Paterno:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtPaterno" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ControlToValidate="txtPaterno" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido Materno:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtMaterno" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-12">
											<label class="col-md-3 text-md-right col-form-label">Nro de documento:</label>
											<div class="col-md-3">
                                                <asp:TextBox ID="txtCi" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtCi" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
											<label class="col-md-0 text-md-right col-form-label">- Complemento:</label>
											<div class="col-md-1">
                                                <asp:TextBox ID="txtExt" class="form-control" runat="server"></asp:TextBox>
											</div>
											<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatos" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatos_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Expedido:</label>
											<div class="col-md-6">
                                                <asp:DropDownList ID="ddlexpedido" class="dropdown-item" DataSourceID="odsExpedido" DataTextField="descripcion" OnDataBound="ddlexpedido_DataBound" DataValueField="codigo" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="ddlexpedido" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
												
											</div>
										</div>
										<!-- end form-group row -->
										
										
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono fijo:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtTel" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono celular:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtCel" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtCel" Font-Bold="True"></asp:RequiredFieldValidator>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Email:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtEmail" style="text-transform:lowercase" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="*Correo invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
                                </asp:Panel>
								 <asp:Panel ID="Panel_juridica" Visible="false" runat="server">
									 <!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Razon Social:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtRazonSocial" class="form-control" style="text-transform:uppercase" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtRazonSocial" Font-Bold="True"></asp:RequiredFieldValidator>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">NIT:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtNit" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtNit" Font-Bold="True"></asp:RequiredFieldValidator>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
											<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosJ" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatosJ_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									 	<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Departamento:</label>
											<div class="col-md-6">
                                                <asp:DropDownList ID="ddlExpedidoJ" class="dropdown-item" DataSourceID="odsExpedido" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlExpedidoJ_DataBound" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="ddlExpedidoJ" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nombre contacto:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtContactoJ" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtContactoJ" Font-Bold="True"></asp:RequiredFieldValidator>
												
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono celular:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtCelJ" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtCelJ" Font-Bold="True"></asp:RequiredFieldValidator>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<%--<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Email:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtEmailJ" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>--%>
										<!-- end form-group row -->
									 <!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Pagina web:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtPaginaWebJ" class="form-control" style="text-transform:lowercase" runat="server"></asp:TextBox>
												
											</div>
										</div>
										<!-- end form-group row -->
                                </asp:Panel>
																		
									
									<!-- end col-8 -->
								</fieldset>
								<!-- end fieldset -->
							</div>
						<!-- end step-1 -->

                </asp:View>
				<asp:View ID="View2" runat="server">
					<!-- begin step-2 -->
						<div id="step-2">
							<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										</div>
										</div>
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos del credito</legend>
											<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Monto total en Bs.:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtMontoTotal" class="form-control"  data-parsley-required="true" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtMontoTotal" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtMontoTotal" runat="server" ErrorMessage="*Solo numeros" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Cuota inicial en Bs.:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtAportePropio" class="form-control" OnTextChanged="txtAportePropio_TextChanged" AutoPostBack="true"  data-parsley-required="true" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtAportePropio" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtAportePropio" runat="server" ErrorMessage="*Solo numeros" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											<asp:Label ID="lblPorcentaje" ForeColor="Red" Font-Size="X-Small" runat="server" Text=""></asp:Label>	
											</div>
										</div>
										<!-- end form-group row -->
											<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Monto a financiar en Bs.:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtMonto" class="form-control"  data-parsley-required="true" runat="server" ReadOnly="True"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtMonto" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
												
											</div>
                                            
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Plazo en meses:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtMeses" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtMeses" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtMeses" runat="server" ErrorMessage="*Solo numeros" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
												<asp:Label ID="lblPlazo" ForeColor="Red" Font-Size="X-Small" runat="server" Text=""></asp:Label>	
											</div>
										</div>
										<!-- end form-group row -->
											
										
										<!-- end form-group row -->
										
									
								</fieldset>
							<!-- end fieldset -->
								</div>
				</asp:View>
				<asp:View ID="View3" runat="server">
					<!-- end step-2 -->
						<div id="step-3">
							<div class="jumbotron m-b-0 text-center">
								<h2 class="text-inverse">Simulacion terminada</h2>
								<%--<p class="m-b-30 f-s-16">La solicitud se registro correctamente <br />, se realizara la evaluacion y analisis de la misma, vea su administrador de solicitudes para ver los avances. </p>--%>
								<%--<p><a href="javascript:;" class="btn btn-primary btn-lg">Imprimir plan de pagos</a></p>--%>
                                <asp:Button ID="btnGuardar" class="btn btn-primary btn-lg" OnClick="btnGuardar_Click" runat="server" Text="Generar plan de pagos" />
								
							</div>
						</div>
				</asp:View>
            </asp:MultiView>
            	<div class="btn-toolbar mr-2 sw-btn-group float-right p-3" role="group">
					
				<asp:Button ID="btnAnterior" CssClass="btn btn-success" runat="server" OnClick="btnAnterior_Click" Text="Anterior" />
				<asp:Button ID="btnSiguiente" CssClass="btn btn-success" runat="server" OnClick="btnSiguiente_Click" Text="Siguiente" />
				<asp:Button ID="btnCancelarWizard" CssClass="btn btn-danger" runat="server" CausesValidation="false" OnClick="btnCancelarWizard_Click" Text="Cancelar" />
						
			</div>
        </asp:View>
    </asp:MultiView>
	
			<asp:HiddenField ID="hfCustomerId" runat="server" />
			<asp:HiddenField ID="hfCustomerId2" runat="server" />
            <asp:HiddenField ID="hfLat" runat="server" />
			<asp:HiddenField ID="hfLon" runat="server" />
		</div>
		<!-- end #content -->
	
	
    <script type="text/javascript">
        $(function () {
            $("[id$=txtCi]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCustomers") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('|')[0],
                                    val: item.split('|')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
		});

        $(function () {
            $("[id$=txtNit]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCustomersJ") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('|')[0],
                                    val: item.split('|')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId2]").val(i.item.val);
                },
                minLength: 1
            });
		});

        var map, mapOptions;
        function LoadMap() {
            mapOptions = {
                center: new google.maps.LatLng(19.0883595, 72.82652380000002),
                zoom: 10,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);

            for (var i = 0; i < markers.length; i++) {
                var data = markers[i];
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title
                });
            }
        };
        function Export() {
            //URL of Google Static Maps.
            var staticMapUrl = "https://maps.googleapis.com/maps/api/staticmap";

            //Set the Google Map Center.
            staticMapUrl += "?center=" + mapOptions.center.lat() + "," + mapOptions.center.lng();

            //Set the Google Map Size.
            staticMapUrl += "&size=350x350";

            //Set the Google Map Zoom.
            staticMapUrl += "&zoom=" + mapOptions.zoom;

            //Set the Google Map Type.
            staticMapUrl += "&maptype=" + mapOptions.mapTypeId;

            //Loop and add Markers.
            for (var i = 0; i < markers.length; i++) {
                staticMapUrl += "&markers=color:red|" + markers[i].lat + "," + markers[i].lng;
            }

            //Save the Image Url of Google Map.
            document.getElementById("hfImageUrl").value = staticMapUrl + "&key=AIzaSyB6XhmQ0TrlvdgfDu59q1lTyBp5NskGo7I";
        }
           
        
    </script>
</asp:Content>
