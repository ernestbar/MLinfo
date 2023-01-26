<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="natural_wiz.aspx.cs" Inherits="appAmascuotas.natural_wiz" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ObjectDataSource ID="odsClientesNatural" runat="server" SelectMethod="Lista_clientes_natural" TypeName="appAmascuotas.Clases.clientes">
		</asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsExpedido" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="EXPEDIDO" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="odsTipoAntiguedad" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="TIPO ANTIGUEDAD" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsSexo" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="SEXO" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsEstadoCivil" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="ESTADO CIVIL" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoRuta" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="TIPO RUTA" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsRuta" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="RUTA" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
		<asp:ObjectDataSource ID="odsSituacionLaboral" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="SITUACION LABORAL" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoVivienda" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="TIPO VIVIENDA" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsDetalleVivienda" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="DETALLE VIVIENDA" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsRelacionLaboral" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="RELACION LABORAL" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsLugarNac" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="LUGAR NAC" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsNivelEdu" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="NIVEL EDUCACION" Name="PV_DOMINIO" Type="String" />
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
			<!-- begin breadcrumb -->
			<%--<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Home</a></li>
				<li class="breadcrumb-item"><a href="javascript:;">Form Stuff</a></li>
				<li class="breadcrumb-item active">Wizards</li>
			</ol>--%>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">AmasCuotas <small></small></h1>
        <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
    <asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
			<asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                               				<asp:Button ID="btnNuevo" CssClass="btn btn-success" runat="server" CausesValidation="false" OnClick="btnNuevo_Click" Text="NUEVO FORMULARIO CLIENTE NATURAL" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Solicitud persona natural <small></small></h1>
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
															<th class="text-nowrap">TELF. FIJO</th>
															<th class="text-nowrap">TELF. CELULAR</th>
															<th class="text-nowrap">EMAIL</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsClientesNatural" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("razon_social") %>'></asp:Label></td>
															<td><asp:Label ID="lblCodCliente1" runat="server" Text='<%# Eval("cod_cliente") %>'></asp:Label></td>
															<td><asp:Label ID="lblTipoCliente" runat="server" Text='<%# Eval("tipo_cliente") %>'></asp:Label></td>
															
															<td><asp:Label ID="lblTipoDoc" runat="server" Text='<%# Eval("tipo_documento") %>'></asp:Label></td>
															<td><asp:Label ID="lblNumero" runat="server" Text='<%# Eval("numero_documento") %>'></asp:Label></td>
															<td><asp:Label ID="lblExpedido" runat="server" Text='<%# Eval("expedido") %>'></asp:Label></td>
															<td><asp:Label ID="lblTelFijo" runat="server" Text='<%# Eval("telefono_fijo") %>'></asp:Label></td>
															<td><asp:Label ID="lblTelCel" runat="server" Text='<%# Eval("telefono_celular") %>'></asp:Label></td>
															<td><asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label></td>
																<td>
																	<%--<div class="btn-group btn-sm">--%>
																	  
																		<asp:Button ID="btnDetalles" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnDetalles_Click" runat="server" Text="Detalles" ToolTip="Solicitudes" />
																		<%--<asp:Button ID="btnEditar" class="btn btn-success" CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																		<asp:Button ID="btnEliminar" class="btn btn-success" CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnEliminar_Click" runat="server" Text="Eliminar" ToolTip="Eliminar" />--%>
																		<asp:Button ID="btnNuevo" class="btn btn-success btn-sm" CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnNuevo_Click1" runat="server" Text="Nuevo" ToolTip="Nueva formulario" />
																	
																		  <asp:Button ID="btnEditar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("cod_cliente") %>' OnClick="btnEditar_Click" runat="server" Text="Edicion" ToolTip="Editar seccion" />
																	 
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
             <div id="wizard">
					<!-- begin wizard-step -->
					<ul>
						<li id="p1" class="col-md-3 col-sm-4 col-6">
							<a href="#step-1">
								<span class="number">1</span> 
								<span class="info text-ellipsis">
									Datos de la solicitud
								</span>
							</a>
						</li>
						<li id="p2" class="col-md-3 col-sm-4 col-6">
							<a href="#step-2">
								<span class="number">2</span> 
								<span class="info text-ellipsis">
									Datos generales
								</span>
							</a>
						</li>
						<li id="p3" class="col-md-3 col-sm-4 col-6">
							<a href="#step-3">
								<span class="number">3</span> 
								<span class="info text-ellipsis">
									Datos del conyugue
								</span>
							</a>
						</li>
						<li id="p4" class="col-md-3 col-sm-4 col-6">
							<a href="#step-4">
								<span class="number">4</span>
								<span class="info text-ellipsis">
									Datos del domicilio
								</span>
							</a>
						</li>
						<li id="p5" class="col-md-3 col-sm-4 col-6">
							<a href="#step-5">
								<span class="number">5</span> 
								<span class="info text-ellipsis">
									Datos laborales y referencias
								</span>
							</a>
						</li>
						<li id="p6" class="col-md-3 col-sm-4 col-6">
							<a href="#step-6">
								<span class="number">6</span> 
								<span class="info text-ellipsis">
									Balance y flujo ingresos
								</span>
							</a>
						</li>
						<%--<li id="p7" class="col-md-3 col-sm-4 col-6">
							<a href="#step-6">
								<span class="number">7</span> 
								<span class="info text-ellipsis">
									Ubicacion del domicilio
								</span>
							</a>
						</li>--%>
						<%--<li id="p7" class="col-md-3 col-sm-4 col-6">
							<a href="#step-7">
								<span class="number">7</span> 
								<span class="info text-ellipsis">
									Datos garante
								</span>
							</a>
						</li>
						<li id="p8" class="col-md-3 col-sm-4 col-6">
							<a href="#step-8">
								<span class="number">8</span> 
								<span class="info text-ellipsis">
									Croquis domicilio
								</span>
							</a>
						</li>--%>
						<li id="p7" class="col-md-3 col-sm-4 col-6">
							<a href="#step-7">
								<span class="number">8</span> 
								<span class="info text-ellipsis">
									Finalizar solicitud
								</span>
							</a>
						</li>
					</ul>
					<!-- end wizard-step -->
				</div>
            <asp:MultiView ID="MultiView2" runat="server">
                <asp:View ID="View3" runat="server">
					
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos de la solicitud</legend>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Ruta</label>
											<div class="col-md-6">
												<div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlRuta1" DataSourceID="odsRuta" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlRuta1_DataBound" class="form-control" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlRuta1" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlRuta2" DataSourceID="odsRuta" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlRuta2_DataBound" class="form-control" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlRuta2" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Tipo Ruta:</label>
											<div class="col-md-6">
												<asp:RadioButtonList ID="rblTipoRuta" DataSourceID="odsTipoRuta" RepeatDirection="Horizontal"  DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server" CellSpacing="5" CellPadding="6"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="rblTipoRuta" runat="server" InitialValue="" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Cantidad Pasajes:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCantPasajes"  class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtCantPasajes" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtCantPasajes" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Valor total de pasajes en Bs.:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtMontoTotal" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMontoTotal" runat="server" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtMontoTotal" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Cuota inicial en Bs.:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCuotaInicial" class="form-control" OnTextChanged="txtCuotaInicial_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCuotaInicial" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtMontoTotal" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
												<asp:Label ID="lblPorcentaje" ForeColor="Red" Font-Size="X-Small" runat="server" Text=""></asp:Label>	
											</div>
										</div>
										<!-- end form-group row -->
										
										
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Monto a financiar en Bs.:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtMontoFinanciar" ReadOnly="true" placeholder="0" class="form-control" runat="server">
												</asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtMontoFinanciar" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtMontoFinanciar" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Plazo en meses:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPlazoMeses"  class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtPlazoMeses" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtPlazoMeses" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Observaciones:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtObservacopmes" style="text-transform:uppercase" placeholder="" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
							<!-- end fieldset -->
                </asp:View>
                <asp:View ID="View4" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Generales</legend>
										<asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false"></asp:Label>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Busqueda por Nombre:(Paterno + Materno + Nombres)</label>
											<div class="col-md-5">
												<asp:TextBox ID="txtNombreCompleto" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
											<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosNombre" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatos_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-12">
											<label class="col-md-3 text-md-right col-form-label">Documento de identidad:</label>
											<div class="col-md-3">
                                                <asp:TextBox ID="txtCi" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCi" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
											<label class="col-md-0 text-md-right col-form-label">- Complemento:</label>
											<div class="col-md-1">
                                                <asp:TextBox ID="txtExt" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
											</div>
											<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatos" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatos_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>
										</div>
										<!-- end form-group row -->
										
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Expedido en:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlExpedido" class="form-control" DataSourceID="odsExpedido" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlExpedido_DataBound" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlExpedido" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido Paterno:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtApellidoPaterno" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtApellidoPaterno" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido Materno:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtApellidoMaterno" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido de Casada:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtApellidoCasada" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Primer Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPrimerNombre" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPrimerNombre" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Segundo Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtSegundoNombre" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Tercer Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTercerNombre" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Sexo:</label>
											<div class="col-md-6">
                                                <asp:RadioButtonList ID="rblSexo" DataSourceID="odsSexo" CellPadding="5" RepeatDirection="Horizontal"  DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="rblSexo" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Lugar de Nacimiento:</label>
											<div class="col-md-6">
                                                <asp:DropDownList ID="ddlLugarNacimiento" class="form-control" DataSourceID="odsLugarNac" DataTextField="descripcion" OnDataBound="ddlLugarNacimiento_DataBound" DataValueField="codigo" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlLugarNacimiento" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nacionalidad:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNacionalidad" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNacionalidad" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Edad:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEdad" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEdad" Font-Bold="True"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtEdad" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nivel de educacion:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlNivelEdu" class="form-control" DataSourceID="odsNivelEdu" DataTextField="descripcion" OnDataBound="ddlNivelEdu_DataBound" DataValueField="codigo" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNivelEdu" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Estado civil:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlEstCivil" class="form-control" DataSourceID="odsEstadoCivil" OnDataBound="ddlEstCivil_DataBound" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlEstCivil" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Fecha de nacimiento:</label>
                                           
											<div class="col-md-6">
												<div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlNacDia" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacDia" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlNacMes" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacMes" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlNacAño" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacAño" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
												 <asp:Label ID="lblClienteEdad" runat="server" ForeColor="Red" Font-Size="Small" Text=""></asp:Label>
											</div>
										</div>
										<!-- end form-group row -->
										
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Profesion/Ocupacion:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtProfesion" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtProfesion" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nro. de dependientes:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNroDependientes" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtNroDependientes" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtNroDependientes" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono Celular:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCelular" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">E-mail personal:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEmail" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtEmail" runat="server" ErrorMessage="*Correo invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
                </asp:View>
                <asp:View ID="View5" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos de Conyugue</legend>
										<asp:Label ID="lblCodConyugue" runat="server" Text="" Visible="false"></asp:Label>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Busqueda por Nombre:(Paterno+Materno+Nombres)</label>
											<div class="col-md-5">
												<asp:TextBox ID="txtNombreCompletoCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
											<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosNombreCon" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatosCon_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-12">
											<label class="col-md-3 text-md-right col-form-label">Documento de identidad:</label>
											<div class="col-md-3">
                                                <asp:TextBox ID="txtCiCon" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCiCon" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
											<label class="col-md-0 text-md-right col-form-label">- Complemento:</label>
											<div class="col-md-1">
                                                <asp:TextBox ID="txtExtCon" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
											</div>
											<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosCon" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatosCon_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>
										</div>
										<!-- end form-group row -->
										
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Expedido en:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlExpedidoCon" class="form-control" DataSourceID="odsExpedido" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlExpedidoCon_DataBound" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlExpedidoCon" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido Paterno:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtApellidoPaternoCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtApellidoPaternoCon" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido Materno:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtApellidoMaternoCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido de Casada:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtApellidoCasadaCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Primer Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPrimerNombreCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPrimerNombreCon" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Segundo Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtSegundoNombreCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Tercer Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTercerNombreCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Sexo:</label>
											<div class="col-md-6">
                                                <asp:RadioButtonList ID="rblSexoCon" DataSourceID="odsSexo" CellPadding="5" RepeatDirection="Horizontal"  DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="rblSexoCon" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Lugar de Nacimiento:</label>
											<div class="col-md-6">
                                                <asp:DropDownList ID="ddlLugarNacimientoCon" class="form-control" DataSourceID="odsLugarNac" DataTextField="descripcion" OnDataBound="ddlLugarNacimientoCon_DataBound" DataValueField="codigo" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlLugarNacimientoCon" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nacionalidad:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNacionalidadCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNacionalidadCon" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Edad:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEdadCon" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEdadCon" Font-Bold="True"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtEdadCon" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nivel de educacion:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlNivelEduCon" class="form-control" DataSourceID="odsNivelEdu" DataTextField="descripcion" OnDataBound="ddlNivelEduCon_DataBound" DataValueField="codigo" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNivelEduCon" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Fecha de nacimiento:</label>
											<div class="col-md-6">
												<div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlNacDiaCon" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacDiaCon" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlNacMesCon" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacMesCon" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlNacAñoCon" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacAñoCon" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
											</div>
										</div>
										<!-- end form-group row -->
										
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono Celular:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCelularCon" placeholder="" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelularCon" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Empresa donde trabaja:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEmpresaCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmpresaCon" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Profesion/Ocupacion:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtProfesionCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtProfesionCon" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<%--<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nro de dependientes:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNroDependientesCon" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="txtNroDependientes" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtNroDependientesCon" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
											</div>
										</div>--%>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Cargo:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCargoCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="txtCargoCon" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Antiguedad:</label>
											<div class="col-md-2">
												<asp:TextBox ID="txtAntiguedadCon" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="txtAntiguedadCon" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtAntiguedadCon" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
											<div class="col-md-4">
                                                <asp:DropDownList ID="ddlTipoAntiguedadCon" class="form-control" DataSourceID="odsTipoAntiguedad" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Direccion empresa:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtDireccionEmpresaCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="txtDireccionEmpresaCon" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono oficina:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTelfOficinaCon" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator47" ControlToValidate="txtTelfOficinaCon" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtTelfOficinaCon" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">E-mail:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEmailCon" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="txtEmailCon" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
							<!-- end fieldset -->
                </asp:View>
                <asp:View ID="View6" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos del domicilio</legend>
										<asp:Label ID="lblCodDireccion" runat="server" Text="" Visible="false"></asp:Label>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Tipo vivienda:</label>
											<div class="col-md-8">
												<asp:RadioButtonList ID="rblTipoVivienda" DataSourceID="odsTipoVivienda" CellPadding="3"  RepeatDirection="Horizontal" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator49" ControlToValidate="rblTipoVivienda" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Detalle:</label>
											<div class="col-md-8">
												<asp:RadioButtonList ID="rblDetalleVivienda" DataSourceID="odsDetalleVivienda" OnSelectedIndexChanged="rblDetalleVivienda_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<label class="col-md-3 text-md-right col-form-label">Otra</label>
												<div class="col-md-9">
													<asp:TextBox ID="txtDetViviendaOtros" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												</div>
											</div>
											
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Barrio:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtBarrio" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Condominio:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCondominio" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Urbanizacion:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtUrbanizacion" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Ciudad:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCiudad" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Avenida:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtAvenida" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Calle:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCalle" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Pasillo/Carretera:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPasilloCarretera" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nro:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNro" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Edificio:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEdif" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Piso:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPiso" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nro departamento:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNroDepto" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono domicilio:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTelDom" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Referencia:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtReferencia" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->

									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
							<!-- end fieldset -->
                </asp:View>
                <asp:View ID="View7" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos laborales y referencias:</legend>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Situacion laboral:</label>
											<asp:Label ID="lblCodDatoLaboral" runat="server" Text="" Visible="false"></asp:Label>
											<div class="col-md-8">
												<asp:RadioButtonList ID="rblSituacionLaboral" Font-Size="Small" DataSourceID="odsSituacionLaboral" OnSelectedIndexChanged="rblSituacionLaboral_SelectedIndexChanged" AutoPostBack="true"  RepeatDirection="Horizontal" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator50" ControlToValidate="rblSituacionLaboral" runat="server" ErrorMessage="*" ForeColor="Red" InitialValue=""></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Relacion Laboral:</label>
											<div class="col-md-8">
                                                <asp:RadioButtonList ID="rblRelLaboral" Font-Size="Smaller" DataSourceID="odsRelacionLaboral" RepeatDirection="Horizontal" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator51" ControlToValidate="rblRelLaboral" runat="server" ErrorMessage="*" ForeColor="Red" InitialValue=""></asp:RequiredFieldValidator>
												<label class="col-md-3 text-md-right col-form-label">Otra</label>
												<div class="col-md-6">
													<asp:TextBox ID="txtOtros" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												</div>
											</div>
											
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Antiguedad:</label>
											<div class="col-md-2">
												<asp:TextBox ID="txtAntiguedad" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="txtAntiguedad" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtAntiguedadCon" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
											<div class="col-md-4">
                                                <asp:DropDownList ID="ddlTipoAcntiguedadCli" class="form-control" DataSourceID="odsTipoAntiguedad" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Cargo que ocupa:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCargoOcupa" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator53" ControlToValidate="txtCargoOcupa" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Empresa donde trabaja:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEmpresaTrabaja" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator54" ControlToValidate="txtEmpresaTrabaja" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Direccion de la empresa:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtDirEmpresa" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="txtDirEmpresa" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTelf" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator56" ControlToValidate="txtTelf" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtTelf" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Email:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEmail2" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator58" ControlToValidate="txtEmail2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Ingreso mensual promedio en Bs.:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtIngresoPromedio" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator57" ControlToValidate="txtIngresoPromedio" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txtIngresoPromedio" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Referencias:</legend>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<!-- begin table-responsive -->
											<div class="table-responsive">
												<table class="table">
													<thead>
														<tr>
															<th>Referencias</th>
															<th nowrap>Nombre / Contacto</th>
															<th nowrap>Trabajo / Ocupacion</th>
															<th nowrap>Telefono de Contacto</th>
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>Personal</td><asp:Label ID="lblCodRef1" runat="server" Text="" Visible="false"></asp:Label>
															<td><asp:TextBox ID="txtRefNombre1" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator59" ControlToValidate="txtRefNombre1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															
															<td><asp:TextBox ID="txtRefTrabajo1" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator60" ControlToValidate="txtRefTrabajo1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRefTelfContacto1" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator61" ControlToValidate="txtRefTelfContacto1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															
														</tr>
														<tr>
															<td>Personal</td><asp:Label ID="lblCodRef2" runat="server" Text="" Visible="false"></asp:Label>
															<td><asp:TextBox ID="txtRefNombre2" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator62" ControlToValidate="txtRefNombre2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRefTrabajo2" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator63" ControlToValidate="txtRefTrabajo2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRefTelfContacto2" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator64" ControlToValidate="txtRefTelfContacto2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															
														</tr>
														<tr>
															<td>Laboral/Comercial</td><asp:Label ID="lblCodRef3" runat="server" Text="" Visible="false"></asp:Label>
															<td><asp:TextBox ID="txtRefNombre3" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator65" ControlToValidate="txtRefNombre3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRefTrabajo3" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator66" ControlToValidate="txtRefTrabajo3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRefTelfContacto3" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator67" ControlToValidate="txtRefTelfContacto3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
															</td>
															
														</tr>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
										</div>
										<!-- end form-group row -->
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
							<!-- end fieldset -->
                </asp:View>
                <asp:View ID="View8" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">BALANCE Y FLUJO DE INGRESOS/EGRESOS SOLICITANTE</legend>
										<asp:Label ID="lblCodBalance" runat="server" Text="" Visible="false"></asp:Label>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Total de Activos en $us.</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTotActSus" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator68" ControlToValidate="txtTotActSus" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtTotActSus" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Total de Pasivos en $us.(Deudas)</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTotPasSus" placeholder="" OnTextChanged="txtTotPasSus_TextChanged" AutoPostBack="true" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator69" ControlToValidate="txtTotActSus" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator17" ControlToValidate="txtTotActSus" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Patrimonio Neto en $us.</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPatNetoSus" ReadOnly="true" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator70" ControlToValidate="txtTotActSus" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtTotActSus" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
												<asp:Label ID="lblPatNeto" ForeColor="Red" Font-Size="X-Small" runat="server" Text=""></asp:Label>	
											</div>
										</div>
										<!-- end form-group row -->
										<div class="table-responsive">
											<table class="table">
													<thead>
														<tr>
															<th>INGRESOS</th>
															<th>EGRESOS</th>
															
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>
																<!-- begin table-responsive -->
											<div class="table-responsive">
												<table class="table">
													<thead>
														<tr>
															<th>INGRESOS</th>
															<th nowrap>Bs.</th>
															
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>Sueldos</td>
															<td><asp:TextBox ID="txtFlujoSueldo" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator71" ValidationGroup="gr1" ControlToValidate="txtFlujoSueldo" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator19" ValidationGroup="gr1" ControlToValidate="txtFlujoSueldo" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>Honorarios</td>
															<td><asp:TextBox ID="txtFlujoHonorarios" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator72" ValidationGroup="gr1" ControlToValidate="txtFlujoHonorarios" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator20" ValidationGroup="gr1" ControlToValidate="txtFlujoHonorarios" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>Rentas</td>
															<td><asp:TextBox ID="txtFlujoRentas" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator73" ValidationGroup="gr1" ControlToValidate="txtFlujoRentas" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator21" ValidationGroup="gr1" ControlToValidate="txtFlujoRentas" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>Utilidades</td>
															<td><asp:TextBox ID="txtFlujoUtil" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator74" ValidationGroup="gr1" ControlToValidate="txtFlujoUtil" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator22" ValidationGroup="gr1" ControlToValidate="txtFlujoUtil" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>Otros:<input type="text" name="barrio" placeholder="" class="form-control" /></td>
															<td><br /><asp:TextBox ID="txtFlujoOtros" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator75" ValidationGroup="gr1" ControlToValidate="txtFlujoOtros" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator23" ValidationGroup="gr1" ControlToValidate="txtFlujoOtros" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>TOTAL</td>
															<td><asp:TextBox ID="txtFlujoTotal" ReadOnly="true" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator76" ValidationGroup="gr1" ControlToValidate="txtFlujoTotal" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator24" ValidationGroup="gr1" ControlToValidate="txtFlujoTotal" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
															</td>
															<td>
																	<!-- begin table-responsive -->
											<div class="table-responsive">
												<table class="table">
													<thead>
														<tr>
															<th>EGRESOS</th>
															<th nowrap>Bs.</th>
															
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>Alquileres</td>
															<td><asp:TextBox ID="txtFluEgAlq" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator77" ValidationGroup="gr1" ControlToValidate="txtFluEgAlq" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator25" ValidationGroup="gr1" ControlToValidate="txtFluEgAlq" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>Alimentacion y servicios</td>
															<td><asp:TextBox ID="txtFluEgAlimentos" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator78" ValidationGroup="gr1" ControlToValidate="txtFluEgAlimentos" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator26" ValidationGroup="gr1" ControlToValidate="txtFluEgAlimentos" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>Educacion</td>
															<td><asp:TextBox ID="txtFluEgEducacion" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator79" ValidationGroup="gr1" ControlToValidate="txtFluEgEducacion" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator27" ValidationGroup="gr1" ControlToValidate="txtFluEgEducacion" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>Pago Creditos</td>
															<td><asp:TextBox ID="txtFluEgCred" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator80" ValidationGroup="gr1" ControlToValidate="txtFluEgCred" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator28" ValidationGroup="gr1" ControlToValidate="txtFluEgCred" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>Otros:<input type="text" name="barrio" placeholder="" class="form-control" /></td>
															<td><br /><asp:TextBox ID="txtFluEgOtros" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator81" ValidationGroup="gr1" ControlToValidate="txtFluEgOtros" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator29" ValidationGroup="gr1" ControlToValidate="txtFluEgOtros" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
														<tr>
															<td>TOTAL</td>
															<td><asp:TextBox ID="txtFluEgTotal"  ReadOnly="true" placeholder="" class="form-control" runat="server" Text=""></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator82" ValidationGroup="gr1" ControlToValidate="txtFluEgTotal" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
<%--												<asp:RegularExpressionValidator ID="RegularExpressionValidator30" ValidationGroup="gr1" ControlToValidate="txtFluEgTotal" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
															</td>
															
														</tr>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
															</td>

														</tr>

													</tbody>
											</table>
										</div>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Superavit/Deficit</label>
											<div class="col-md-4">
												<asp:TextBox ID="txtPatrimonioBs" ReadOnly="true" placeholder=""  class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator84" ControlToValidate="txtPatrimonioBs" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator32" ControlToValidate="txtPatrimonioBs" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
												<asp:Label ID="lblPatrimonioBs" ForeColor="Red" Font-Size="X-Small" runat="server" Text=""></asp:Label>	
											</div>
											<div class="col-md-5">
												<asp:Button ID="btnVerificar" class="btn btn-primary btn-sm" OnClick="btnVerificar_Click" ValidationGroup="gr1" runat="server" Text="Verifica" />
											</div>
										</div>
										<!-- end form-group row -->
									</div>
										
										
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
							<!-- end fieldset -->
                </asp:View>
                <asp:View ID="View9" runat="server">
					<%--<fieldset>
						<div class="row">
							<div class="col-md-8 offset-md-2">
								<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">CROQUIS</legend>
									<div class="form-group row m-b-10">
										<label class="col-md-3 text-md-right col-form-label">Ubicacion del domicilio</label>
										<div class="col-md-6">
											<div id="mapa1" style="width: 100%; height: 350px">
											</div>
										</div>
									</div>

									<div class="form-group row m-b-10">
										<label class="col-md-3 text-md-right col-form-label">Presiona para ver tu ubicacion actual</label>
											<input type="button" class="btn btn-primary btn-sm"  value="Buscar mi ubicacion" onclick="javascript: mostrarUbicacionActual1()" />
									</div>
									<div class="form-group row m-b-10">
										<label class="col-md-3 text-md-right col-form-label">Latitud <span class="text-danger">*</span></label>
										<div class="col-md-6">
											<asp:Label ID="lblLatitud" runat="server" Text="Label"></asp:Label>
										</div>
									</div>
									<div class="form-group row m-b-10">
										<label class="col-md-3 text-md-right col-form-label">Longitud <span class="text-danger">*</span></label>
										<div class="col-md-6">
											<asp:Label ID="lblLongitud" runat="server" Text="Label"></asp:Label>
										</div>
									</div>
									<div class="form-group row m-b-10">
										<label class="col-md-3 text-md-right col-form-label"></label>
										<div class="col-md-6">
												
											<p><asp:Button ID="btnGuardarCorquis" class="btn btn-primary btn-sm"  OnClientClick="Export()" OnClick="btnGuardarCorquis_Click" runat="server" Text="Guardar Croquis" /></p>
										</div>
									</div>
									
										
								</div>
							</div>
						</fieldset>
                    <asp:Image ID="imgServer" runat="server" />
						<asp:HiddenField ID="hfLatitud" runat="server" />
                        <asp:HiddenField ID="hfLongitud" runat="server" />
										<!-- end form-group row -->--%>
					<div class="jumbotron m-b-0 text-center">
								<h2 class="text-inverse">Felicidades fin del formulario</h2>
								<p class="m-b-30 f-s-16">Presione el boton finalizar <br />para guardar los datos del formulario en la base de datos. </p><%--OnClientClick="alert('Alerta debes imprimir el formulario');"--%>
								<p><asp:Button ID="btnGrabar" class="btn btn-primary btn-lg" OnClick="btnGrabar_Click"  runat="server" Text="FINALIZAR" /></p>
								<p><asp:Button ID="btnContinuar" class="btn btn-primary btn-lg" OnClick="btnContinuar_Click" runat="server" Text="CONTINUAR" /></p>
							</div>
                </asp:View>
                
             
            </asp:MultiView>
			<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
				<asp:Button ID="btnAnterior" CssClass="btn btn-success" runat="server" CausesValidation="false" OnClick="btnAnterior_Click" Text="Anterior" />
				<asp:Button ID="btnSiguiente" CssClass="btn btn-success" runat="server" OnClick="btnSiguiente_Click" Text="Siguiente" />
				<asp:Button ID="btnCancelarWizard" CssClass="btn btn-danger" runat="server" CausesValidation="false" OnClick="btnCancelarWizard_Click" Text="Cancelar" />
			</div>
        </asp:View>
        
    </asp:MultiView>
			<asp:HiddenField ID="hfCustomerId" runat="server" />
			<asp:HiddenField ID="hfCustomerId2" runat="server" />
			<asp:HiddenField ID="hfLat" runat="server" />
			<asp:HiddenField ID="hfLon" runat="server" />
			<asp:HiddenField ID="hfImageUrl" runat="server" />
	</div>
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
            $("[id$=txtCiCon]").autocomplete({
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
                    $("[id$=hfCustomerId2]").val(i.item.val);
                },
                minLength: 1
            });
		});

        $(function () {
            $("[id$=txtNombreCompleto]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCustomersName") %>',
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
            $("[id$=txtNombreCompletoCon]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCustomersName") %>',
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
    </script>
	<%--<script type="text/javascript">
        function Export() {
            var mapOptions;
            mapOptions = {
                center: new google.maps.LatLng(document.getElementById('<%=hfLatitud.ClientID%>').value, document.getElementById('<%=hfLongitud.ClientID%>').value),
                zoom: 18,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("mapa1"), mapOptions);
            //URL of Google Static Maps.
            var staticMapUrl = "https://maps.googleapis.com/maps/api/staticmap";

            //Set the Google Map Center.
            staticMapUrl += "?center=" + mapOptions.center.lat() + "," + mapOptions.center.lng();

            //Set the Google Map Size.
            staticMapUrl += "&size=350x350";

            //Set the Google Map Size.
            //staticMapUrl += "&region:'BO'";

            //Set the Google Map Zoom.
            staticMapUrl += "&zoom=" + map.zoom;

            //Set the Google Map Type.
            staticMapUrl += "&maptype=" + map.mapTypeId;

            //Add Markers.
            staticMapUrl += "&markers=color:red|" + document.getElementById('<%=hfLatitud.ClientID%>').value + "," + document.getElementById('<%=hfLongitud.ClientID%>').value;

            //Save the Image Url of Google Map.
            document.getElementById('<%=hfImageUrl.ClientID%>').value = staticMapUrl + "&key=AIzaSyB6XhmQ0TrlvdgfDu59q1lTyBp5NskGo7I";

        };
    </script>
	
	<script type="text/javascript">
        window.onload = mostrarUbicacion();

        function mostrarUbicacion() {
            mostrarUbicacion1();

        };

        function mostrarUbicacion1() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(obtenerUbicacion1);
            }
            else {
                alert("La característica de Geo Localización no está disponible en este navegador");
            }
        };

        function mostrarUbicacion2() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(obtenerUbicacion2);
            }
            else {
                alert("La característica de Geo Localización no está disponible en este navegador");
            }
        };

        function mostrarUbicacionActual1() {
            document.getElementById('<%= lblLatitud.ClientID %>').value = "";
            document.getElementById('<%= lblLongitud.ClientID %>').value = "";
            document.getElementById('<%= hfLatitud.ClientID %>').value = "";
            document.getElementById('<%= hfLongitud.ClientID %>').value = "";
            mostrarUbicacion1();
        };



        function obtenerUbicacion1(position) {
            // Obtener posición actual
            var latitud = 0;
            var longitud = 0;

            // Obtener datos de controles
            var hfLatitud = document.getElementById('<%=hfLatitud.ClientID%>');
            var hfLongitud = document.getElementById('<%=hfLongitud.ClientID%>');
            var lblLatitud = document.getElementById('<%=lblLatitud.ClientID%>');
            var lblLongitud = document.getElementById('<%=lblLongitud.ClientID%>');

            if (hfLatitud == null) {
                return;
            }

            if (hfLongitud == null) {
                return;
            }

            // Si no hay latitud o longitud registrada tomar la actual
            if (hfLatitud.value == "" && hfLongitud.value == "") {
                latitud = position.coords.latitude;
                longitud = position.coords.longitude;

                lblLatitud.innerHTML = latitud;
                lblLongitud.innerHTML = longitud;
                hfLatitud.innerHTML = latitud;
                hfLongitud.innerHTML = longitud;

                document.getElementById('<%= lblLatitud.ClientID %>').value = latitud;
                document.getElementById('<%= lblLongitud.ClientID %>').value = longitud;
                document.getElementById('<%= hfLatitud.ClientID %>').value = latitud;
                document.getElementById('<%= hfLongitud.ClientID %>').value = longitud;
            }
            else {
                latitud = hfLatitud.value;
                longitud = hfLongitud.value;
                lblLatitud.innerHTML = latitud;
                lblLongitud.innerHTML = longitud;

                document.getElementById('<%= lblLatitud.ClientID %>').value = latitud;
                document.getElementById('<%= lblLongitud.ClientID %>').value = longitud;
            }

            // Inicializar el Mapa
            var LatLng = new google.maps.LatLng(latitud, longitud);
            var mapOpciones = {
                center: LatLng,
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var mapa = new google.maps.Map(document.getElementById("mapa1"), mapOpciones);

            var currentMarkerPos;

            var marker = new google.maps.Marker({
                position: LatLng,
                map: mapa,
                title: "Mi ubicación",
                draggable: true
            });

            google.maps.event.addListener(marker, "dragstart",
                function (event) {
                    currentMarkerPos = event.latLng;
                }
            );

            google.maps.event.addListener(marker, "dragend",
                function (event) {
                    var latitud = event.latLng.lat();
                    var longitud = event.latLng.lng();

                    var lblLatitud = document.getElementById('<%=lblLatitud.ClientID%>');
                    lblLatitud.innerHTML = latitud;
                    var lblLongitud = document.getElementById('<%=lblLongitud.ClientID%>');
                    lblLongitud.innerHTML = longitud;

                    var hfLatitud = document.getElementById('<%=hfLatitud.ClientID%>');
                    hfLatitud.innerHTML = latitud;
                    var hfLongitud = document.getElementById('<%=hfLongitud.ClientID%>');
                    hfLongitud.innerHTML = longitud;

                    document.getElementById('<%= lblLatitud.ClientID %>').value = latitud;
                    document.getElementById('<%= lblLongitud.ClientID %>').value = longitud;
                    document.getElementById('<%= hfLatitud.ClientID %>').value = latitud;
                    document.getElementById('<%= hfLongitud.ClientID %>').value = longitud;
                }
            );
        };

    </script>--%>
</asp:Content>
