<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="simulador.aspx.cs" Inherits="appAmascuotas.simulador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- begin #content -->
		<div id="content" class="content">
            <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
					<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevaSimulacion" class="btn-sm btn-info btn-block" OnClick="btnNuevaSimulacion_Click" runat="server" Text="Simulacion cliente nuevo" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Solicitudes <small>recientes</small></h1>
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
													<h4 class="panel-title">Prospectos registrados</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">COD.CLIENTE</th>
															<th class="text-nowrap">TIPO CLIENTE</th>
															<th class="text-nowrap">RAZON SOCIAL/NOMBRE</th>
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
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsClientesSim" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<td><asp:Label ID="lblCodCliente1" runat="server" Text='<%# Eval("cod_cliente") %>'></asp:Label></td>
															<td><asp:Label ID="lblTipoCliente" runat="server" Text='<%# Eval("tipo_cliente") %>'></asp:Label></td>
															<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("razon_social") %>'></asp:Label></td>
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
				<asp:View ID="View2" runat="server">
                    <!-- begin breadcrumb -->
			<%--<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Home</a></li>
				<li class="breadcrumb-item"><a href="javascript:;">Form Stuff</a></li>
				<li class="breadcrumb-item active">Wizards</li>
			</ol>--%>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">AmasCuotas <small>simulador de credito</small></h1>
			<!-- end page-header -->
			
			
				<!-- begin wizard -->
				<div id="wizard">
					<!-- begin wizard-step -->
					<ul>
						
						<li class="col-md-3 col-sm-4 col-6">
							<a href="#step-1">
								<span class="number">1</span> 
								<span class="info text-ellipsis">
									Datos cliente
									<%--<small class="text-ellipsis">Name, Address, IC No and DOB</small>--%>
								</span>
							</a>
						</li>
						<li class="col-md-3 col-sm-4 col-6">
							<a href="#step-2">
								<span class="number">2</span> 
								<span class="info text-ellipsis">
									Datos del credito
									<%--<small class="text-ellipsis">Name, Address, IC No and DOB</small>--%>
								</span>
							</a>
						</li>
						<li class="col-md-3 col-sm-4 col-6">
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
					<!-- begin wizard-content -->
					<div>
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
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Tipo cliente</label>
											<div class="col-md-6">
                                                <asp:RadioButtonList ID="rblTipoCliente" class="checkbox"  data-parsley-required="true" DataSourceID="odsTipoCliente" DataTextField="descripcion" DataValueField="codigo" AutoPostBack="true" OnSelectedIndexChanged="rblTipoCliente_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
											<%--	<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
                                <asp:Panel ID="Panel_natural" Visible="false" runat="server">
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nombre:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Paterno:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtPaterno" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Materno:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtMaterno" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nro de documento:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtCi" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Espedido:</label>
											<div class="col-md-6">
                                                <asp:DropDownList ID="ddlexpedido" class="dropdown-item" DataSourceID="odsExpedido" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
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
                                                <asp:TextBox ID="txtCel" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Email:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
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
                                                <asp:TextBox ID="txtRazonSocial" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">NIT:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtNit" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									 	<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Departamento:</label>
											<div class="col-md-6">
                                                <asp:DropDownList ID="ddlExpedidoJ" class="dropdown-item" DataSourceID="odsExpedido" DataTextField="descripcion" DataValueField="codigo"  runat="server"></asp:DropDownList>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<%--<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono fijo:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtTelJ" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />
											</div>
										</div>--%>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono celular:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtCelJ" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Email:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtEmailJ" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
                                </asp:Panel>
																		
									
									<!-- end col-8 -->
								</fieldset>
								<!-- end fieldset -->
							</div>
						<!-- end step-1 -->
						
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
											<label class="col-md-3 text-md-right col-form-label">Monto a financiar en Bs.:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtMonto" class="form-control"  data-parsley-required="true" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Plazo en meses:</label>
											<div class="col-md-6">
                                                <asp:TextBox ID="txtMeses" class="form-control" runat="server"></asp:TextBox>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
											
										
										<!-- end form-group row -->
										
									
								</fieldset>
							<!-- end fieldset -->
								</div>
								<!-- end row -->
							<!-- begin step-10 -->
						
						
						<!-- end step-2 -->
						<div id="step-3">
							<div class="jumbotron m-b-0 text-center">
								<h2 class="text-inverse">Simulacion terminada</h2>
								<%--<p class="m-b-30 f-s-16">La solicitud se registro correctamente <br />, se realizara la evaluacion y analisis de la misma, vea su administrador de solicitudes para ver los avances. </p>--%>
								<%--<p><a href="javascript:;" class="btn btn-primary btn-lg">Imprimir plan de pagos</a></p>--%>
                                <asp:Button ID="btnGuardar" class="btn btn-primary btn-lg" OnClick="btnGuardar_Click" runat="server" Text="Terminar operacion" />
								
							</div>
						</div>
						<!-- end step-10 -->
				</div>
			</div>
					<!-- end wizard-content -->
					<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnCancelar" class="btn-sm btn-info btn-block" OnClick="btnCancelar_Click" runat="server" Text="Cancelar simulacion" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
				</asp:View>
               
            </asp:MultiView>
			
		</div>
	
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
	<asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblCodSimulador" runat="server" Text="" Visible="false"></asp:Label>
	
</asp:Content>
