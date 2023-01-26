<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="solicitudes_gerencial.aspx.cs" Inherits="appAmascuotas.solicitudes_gerencial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ObjectDataSource ID="odsSolicitudesFlujo" runat="server" SelectMethod="GET_SOLICITUDES_FLUJO" TypeName="appAmascuotas.Clases.solicitudes">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodSolicitud" Name="pV_ESTADO" DefaultValue="" />
			<asp:ControlParameter ControlID="lblUsuario" Name="pV_USUARIO" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsSolicitudesAdcionales" runat="server" SelectMethod="GET_SOLICITUDES_ADICIONALES" TypeName="appAmascuotas.Clases.solicitudes_detalle">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodSolicitudDetalle" Name="pV_COD_SOLICITUD_DETALLE" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
	  <asp:ObjectDataSource ID="odsFormularioDinamico" runat="server" SelectMethod="GET_DAD_SOLICITUDES_DETALLE" TypeName="appAmascuotas.Clases.solicitudes_detalle">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblCodSolicitudDetalle" Name="pV_COD_SOLICITUD_DETALLE" DefaultValue="" />
			<asp:ControlParameter ControlID="lblTipoAccion" Name="pV_TIPO_ACCION" DefaultValue="" />
			<asp:ControlParameter ControlID="lblUsuario" Name="pV_USUARIO" DefaultValue="" />
			<asp:ControlParameter ControlID="lblAviso" Name="pV_MOTIVO" DefaultValue="" />
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
	        <asp:Label ID="lblCodSolicitudDetalle" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblCodSolicitud" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblTipoAccion" runat="server" Text="" Visible="false"></asp:Label>
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
													<h4 class="panel-title">Detalle de solicitudes</h4>
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
															<th class="text-wrap">COD ETAPA</th>
															<th class="text-nowrap">NOMBRE/RAZON SOCIAL</th>
															<th class="text-nowrap">RUTA ORIGEN</th>
															<th class="text-nowrap">RUTA DESTINO</th>
															<th class="text-nowrap">CANTIDAD PASAJES</th>
															<th class="text-nowrap">VALOR PASAJES</th>
															<th class="text-nowrap">CUOTA INICIAL</th>
															<th class="text-nowrap">MONTO FINANCIADO</th>
															<th class="text-nowrap">PLAZO MESES</th>
															
															<th class="text-nowrap">ESTADO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsSolicitudesFlujo" runat="server">
														<ItemTemplate>
															
															<tr class="gradeA">
																<td><asp:Label ID="Label6" runat="server" Text='<%# Eval("NRO") %>'></asp:Label></td>
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("FECHA_SOLICITUD") %>'></asp:Label></td>
															<td><asp:Label ID="lblCodEtapa" runat="server" Text='<%# Eval("ETAPA_ACTUAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblDetalle" runat="server" Text='<%# Eval("NOMBRE_RAZON_SOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblUsuarioEtapa" runat="server" Text='<%# Eval("DESC_RUTA_ORIGEN") %>'></asp:Label></td>
															<td><asp:Label ID="lblFechaIni" runat="server" Text='<%# Eval("DESC_RUTA_DESTINO") %>'></asp:Label></td>
															<td><asp:Label ID="lblFechaFin" runat="server" Text='<%# Eval("CANT_PASAJES") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("VALOR_PASAJE") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("CUOTA_INICIAL") %>'></asp:Label></td>
																<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("MONTO_FINANCIADO") %>'></asp:Label></td>
																<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("PLAZO_MES") %>'></asp:Label></td>
																
															<td><asp:Label ID="lblEstado" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<%--<div class="btn-group btn-sm">--%>
																	  
																<%--<asp:Button ID="btnAprobar" class="btn btn-success"  CommandArgument='<%# Eval("COD_SOLICITUD_DETALLE") %>' OnClick="btnAprobar_Click" runat="server" Text="Aprobar" ToolTip="Aprobar solicitud" />--%> <%--Visible='<%# Eval("APROBAR").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' Enabled='<%# (String.IsNullOrEmpty(Eval("FECHA_FIN").ToString())) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>'--%>
																	<%--<asp:Button ID="btnRechazar" class="btn btn-success"  CommandArgument='<%# Eval("COD_SOLICITUD_DETALLE") %>'  OnClick="btnRechazar_Click" runat="server" Text="Rechazar" ToolTip="Rechazar solicitud" />--%> <%--Visible='<%# Eval("RECHAZAR").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' Enabled='<%# (String.IsNullOrEmpty(Eval("FECHA_FIN").ToString())) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')"--%>
																		<asp:Button ID="btnConsultar" class="btn btn-success"  CommandArgument='<%# Eval("COD_SOLICITUD")+ "|" + Eval("COD_SOLICITUD_DETALLE")+ "|" + Eval("COD_CLIENTE")+ "|" + Eval("TIPO_CLIENTE") %>' OnClick="btnConsultar_Click" runat="server" Text="Detalles" ToolTip='<%# Eval("COD_CLIENTE") %>' />
																
																	 
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
					<div class="col-md-12 offset-md-1">
						<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Requisitos</legend>
                        <asp:Repeater ID="Repeater2" DataSourceID="odsFormularioDinamico" OnDataBinding="Repeater2_DataBinding" runat="server">
							<ItemTemplate>
								<asp:ObjectDataSource ID="odsCombo" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
									<SelectParameters>
										<asp:ControlParameter ControlID="lblDominio" Name="PV_DOMINIO" DefaultValue="" />
									</SelectParameters>
								</asp:ObjectDataSource>
									<!-- begin form-group row -->
									<div class="form-group row m-b-10">
                                        <asp:Label ID="lblTitulo" class="col-md-3 text-md-right col-form-label" runat="server" Text='<%# Eval("DENOMINACION") %>'></asp:Label>
										<div class="col-md-8">
											<div class="row row-space-6">
												<div class="col-8">
                                                    <asp:Label ID="lblDominio" runat="server" Text='<%# Eval("LISTA") %>'></asp:Label>
                                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" ToolTip='<%# Eval("COD_SOLICITUD_ADICIONAL") %>' Visible='<%# Eval("TIPO_DATO").ToString().Equals("URL".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' runat="server" />   
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FileUpload1" runat="server" InitialValue="" Enabled='<%# Eval("OBLIGATORIO").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <asp:TextBox ID="TextBox1" TextMode="MultiLine" Height="80px" CssClass="form-control" ToolTip='<%# Eval("COD_SOLICITUD_ADICIONAL") %>' Visible='<%# Eval("TIPO_DATO").ToString().Equals("TEXTO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' runat="server"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox1" runat="server" InitialValue="" Enabled='<%# Eval("OBLIGATORIO").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <asp:DropDownList ID="DropDownList1" DataSourceID="odsCombo"  DataTextField="descripcion" DataValueField="codigo" ToolTip='<%# Eval("COD_SOLICITUD_ADICIONAL") %>' CssClass="form-control" Visible='<%# Eval("TIPO_DATO").ToString().Equals("LISTA".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' runat="server"></asp:DropDownList>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="DropDownList1" runat="server" InitialValue="" Enabled='<%# Eval("OBLIGATORIO").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' ErrorMessage="*"></asp:RequiredFieldValidator>
												</div>
												<div class="col-4">
												</div>
											</div>
										</div>
									</div>
									<!-- end form-group row -->
							</ItemTemplate>
                        </asp:Repeater>
						<div class="form-group">
											
						<div class="col-md-3 float-right">
								<asp:Button ID="btnGuardar" class="btn-sm btn-success btn-block float-right" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />	
							<asp:Button ID="btnCancelarForm" class="btn-sm btn-success btn-block float-right" CausesValidation="false" OnClick="btnCancelarForm_Click" runat="server" Text="Volver" />
							<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
						</div>
					</div>				
					</div>
                  
				</div>
				<!-- end row -->
            </asp:View>
            <asp:View ID="View3" runat="server">
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
													<h4 class="panel-title">Consulta de requisitos</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default1" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">CODIGO</th>
															<th class="text-nowrap">DENOMINACION</th>
															<th class="text-nowrap">DETALLE</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater3" DataSourceID="odsSolicitudesAdcionales" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<td><asp:Label ID="lblCodEtapa" runat="server" Text='<%# Eval("COD_SOLICITUD_ADICIONAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblUsuarioEtapa" runat="server" Text='<%# Eval("DENOMINACION") %>'></asp:Label></td>
															<td><asp:Label ID="lblDetalle" runat="server" Text='<%# Eval("DETALLE") %>'></asp:Label></td>
															<td>
																<%--<div class="btn-group btn-sm">--%>
																	  <%--Enabled='<%# (String.IsNullOrEmpty(Eval("FECHA_FIN").ToString())) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' CommandArgument='<%# Eval("COD_SOLICITUD_DETALLE") %>'--%>
																<asp:Button ID="btnDescargar" class="btn btn-success" CommandArgument='<%# Eval("DETALLE") %>' Visible='<%# Eval("TIPO_DATO").ToString().Equals("URL".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' Enabled='<%# Eval("DETALLE").ToString().Equals("".ToString()) ? Convert.ToBoolean(0) : Convert.ToBoolean(1) %>'  OnClick="btnDescargar_Click" runat="server" Text="Descargar" ToolTip="Descargar archivo" />
																
																	 
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
                                                <asp:Button ID="btnVolverConsulta" class="btn-sm btn-success btn-block float-right" OnClick="btnVolverConsulta_Click" runat="server" Text="Volver" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										</div>
            </asp:View>
        </asp:MultiView>
										
    </div>
</asp:Content>
