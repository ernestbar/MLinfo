<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="solicitudes.aspx.cs" Inherits="appAmascuotas.solicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	
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
	<asp:ObjectDataSource ID="odsSolicitudCliente" runat="server" SelectMethod="Lista_solcitiudes_cliente" TypeName="appAmascuotas.Clases.solicitudes">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodCliente" Name="PV_COD_CLIENTE" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
 <%--   <asp:ObjectDataSource ID="odsPlanPago" runat="server" SelectMethod="Lista_plan_pago" TypeName="appAmascuotas.simular">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodSimulador" Name="PV_COD_SIMULADOR" DefaultValue="" />
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
    <div id="content" class="content">
            <asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblTipoCliente" runat="server" Text="" Visible="false"></asp:Label>
	        <asp:Label ID="lblCodSolicitud" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
	        <asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
		<asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
        <!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <%--<asp:Button ID="btnNuevaSimulacion" class="btn-sm btn-info btn-block" OnClick="btnNuevaSimulacion_Click" runat="server" Text="Simulacion cliente nuevo" />--%>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <!-- begin page-header -->
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
													<h4 class="panel-title">Solicitudes registradas</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">NRO</th>
															<th class="text-nowrap">FECHA SOLICITUD</th>
															<th class="text-nowrap">CODIGO</th>
															<th class="text-nowrap">RUTA ORIGEN</th>
															<th class="text-nowrap">RUTA DESTINO</th>
															<th class="text-nowrap">TIPO RUTA</th>
															<th class="text-nowrap">CANT. PASAJES</th>
															<th class="text-nowrap">VALOR PASAJE</th>
															<th class="text-nowrap">CUOTA INICIAL</th>
															<th class="text-nowrap">MONTO FINANCIADO</th>
															<th class="text-nowrap">PLAZO MESES</th>
															<th class="text-nowrap">DESCRIPCION</th>
															<th class="text-nowrap">ESTADO</th>
															
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsSolicitudCliente" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
															<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("NRO") %>'></asp:Label></td>	
																<td><asp:Label ID="lblFechaSolicitud" runat="server" Text='<%# Eval("FECHA_SOLICITUD") %>'></asp:Label></td>	
															<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("COD_SOLICITUD") %>'></asp:Label></td>
																<td><asp:Label ID="lblRutaOrigen" runat="server" Text='<%# Eval("DESC_RUTA_ORIGEN") %>'></asp:Label></td>
															<td><asp:Label ID="lblRutaDestino" runat="server" Text='<%# Eval("DESC_RUTA_DESTINO") %>'></asp:Label></td>
															<td><asp:Label ID="lblTipoRuta" runat="server" Text='<%# Eval("TIPO_RUTA") %>'></asp:Label></td>
															<td><asp:Label ID="lblCantPasajes" runat="server" Text='<%# Eval("CANT_PASAJES") %>'></asp:Label></td>
															<td><asp:Label ID="lblValorPasaje" runat="server" Text='<%# Eval("VALOR_PASAJE") %>'></asp:Label></td>
															<td><asp:Label ID="lblCuotaIni" runat="server" Text='<%# Eval("CUOTA_INICIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblMontoFin" runat="server" Text='<%# Eval("MONTO_FINANCIADO") %>'></asp:Label></td>
															<td><asp:Label ID="lblPlazo" runat="server" Text='<%# Eval("PLAZO_MES") %>'></asp:Label></td>
															<td><asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("OBSERVACION") %>'></asp:Label></td>
																<td><asp:Label ID="lblEstado" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
																
																<td>
																	<%--<div class="btn-group btn-sm">--%>
																	  
																		<asp:Button ID="btnEditar" class="btn btn-success" Enabled='<%# Eval("DESC_ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' CommandArgument='<%# Eval("COD_SOLICITUD") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																		<asp:Button ID="btnEliminar" class="btn btn-success" Enabled='<%# Eval("DESC_ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' CommandArgument='<%# Eval("COD_SOLICITUD") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" ToolTip="Eliminar" />
																		  <asp:Button ID="btnContinuar" class="btn btn-success" Enabled='<%# Eval("DESC_ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' CommandArgument='<%# Eval("COD_SOLICITUD") %>' OnClick="btnContinuar_Click" runat="server" Text="Continuar" ToolTip="Inciar la solicitud" />
																	<asp:Button ID="btnDetalles" class="btn btn-success" Enabled='<%# Eval("DESC_ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(0) : Convert.ToBoolean(1) %>' CommandArgument='<%# Eval("COD_SOLICITUD") %>' OnClick="btnDetalles_Click" runat="server" Text="Detalles" ToolTip="Detalles de la solicitud" />
																	<asp:Button ID="btnFormulario" class="btn btn-success" Enabled='<%# Eval("DESC_ESTADO").ToString().Equals("PENDIENTE".ToString()) ? Convert.ToBoolean(0) : Convert.ToBoolean(1) %>' CommandArgument='<%# Eval("COD_SOLICITUD") %>' OnClick="btnFormulario_Click" runat="server" Text="Imprimir Solicitud" ToolTip="Imprimir formulario" />
																	 <asp:Button ID="btnDocumentos" class="btn btn-success" Visible='<%# Eval("DESC_ESTADO").ToString().Equals("APROBADO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' CommandArgument='<%# Eval("COD_SOLICITUD") %>' OnClick="btnDocumentos_Click" runat="server" Text="Imprimir Documentos" ToolTip="Imprimir documentos" />
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
												<div class="form-group">
											
											<div class="col-md-3 float-right">
                                                <asp:Button ID="btnVolverDetalle" class="btn-sm btn-success btn-block float-right" OnClick="btnVolverDetalle_Click" runat="server" Text="Volver" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										</div>
            </asp:View>
            <asp:View ID="View2" runat="server">
				<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Editar solicitud</legend>
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
										<div class="form-group">
											
											<div class="col-md-3 float-right">
                                                <asp:Button ID="btnGuardar" class="btn-sm btn-success btn-block float-right" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
												<asp:Button ID="btnVolverEdit" class="btn-sm btn-success btn-block float-right" CausesValidation="false" OnClick="btnVolverEdit_Click" runat="server" Text="Volver" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
            </asp:View>
            <asp:View ID="View3" runat="server">
				<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Eliminar solicitud</legend>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Motivo:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtMotivo1"  class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtMotivo1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtCantPasajes" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- end form-group row -->
										<div class="form-group">
											
											<div class="col-md-3 float-right">
                                                <asp:Button ID="btnEliminar" class="btn-sm btn-success btn-block float-right" OnClick="btnEliminar_Click1" runat="server" Text="Eliminar" />
												<asp:Button ID="btnVolverEliminar" class="btn-sm btn-success btn-block float-right" CausesValidation="false" OnClick="btnVolverEliminar_Click" runat="server" Text="Volver" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
            </asp:View>
        </asp:MultiView>
										
    </div>
</asp:Content>
