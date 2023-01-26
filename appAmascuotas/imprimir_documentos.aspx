<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="imprimir_documentos.aspx.cs" Inherits="appAmascuotas.imprimir_documentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="content" class="content">
            <asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblTipoCliente" runat="server" Text="" Visible="false"></asp:Label>
	        <asp:Label ID="lblCodSolicitud" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
		 <asp:Label ID="lblGarante" runat="server" Text="" Visible="false"></asp:Label>
	        <asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
        <!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <%--<asp:Button ID="btnNuevaSimulacion" class="btn-sm btn-info btn-block" OnClick="btnNuevaSimulacion_Click" runat="server" Text="Simulacion cliente nuevo" />--%>
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
													<h4 class="panel-title">Documentos para impresion</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">NOMBRE DOCUMENTO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
														<tr>
															<td><asp:Label ID="lblRutaOrigen" runat="server" Text="Recibo cuota inicial"></asp:Label></td>
																<td>
															
																	 <asp:Button ID="btnBoleta" class="btn btn-success" runat="server" OnClick="btnBoleta_Click" Text="Imprimir" ToolTip="Imprimir documentos" />
																</td>
														</tr>
														
														<tr>
															<td><asp:Label ID="Label2" runat="server" Text="Contrato base"></asp:Label></td>
																<td>
															
																	 <asp:Button ID="btnContratoBase" class="btn btn-success" OnClick="btnContratoBase_Click" runat="server" Text="Imprimir" ToolTip="Imprimir documentos" />
																</td>
														</tr>
														<%--<tr>
															<td><asp:Label ID="Label3" runat="server" Text="Contrato base garante"></asp:Label></td>
																<td>
															
																	 <asp:Button ID="btnContratoGarante" class="btn btn-success" OnClick="btnContratoGarante_Click"  runat="server" Text="Imprimir" ToolTip="Imprimir documentos" />
																</td>
														</tr>--%>
														<tr>
															<td><asp:Label ID="Label4" runat="server" Text="Certificado de cobertura"></asp:Label></td>
																<td>
															
																	 <asp:Button ID="btnCobertura" class="btn btn-success" OnClick="btnCobertura_Click" runat="server" Text="Imprimir" ToolTip="Imprimir documentos" />
																</td>
														</tr>
														<tr>
															<td><asp:Label ID="Label1" runat="server" Text="Plan de Pagos"></asp:Label></td>
																<td>
															
																	 <asp:Button ID="btnPlanPagos" class="btn btn-success" OnClick="btnPlanPagos_Click" runat="server" Text="Imprimir" ToolTip="Imprimir documentos" />
																</td>
														</tr>
														<%--<tr>
															<td><asp:Label ID="Label5" runat="server" Text="Pagare"></asp:Label></td>
																<td>
															
																	 <asp:Button ID="btnPagare" class="btn btn-success" OnClick="btnPagare_Click" runat="server" Text="Print" ToolTip="Imprimir documentos" />
																</td>
														</tr>--%>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
												<div class="form-group">
											
											<div class="col-md-3 float-right">
                                                <asp:Button ID="btnVolerSolicitudes" class="btn-sm btn-success btn-block float-right" OnClick="btnVolerSolicitudes_Click" runat="server" Text="Volver" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										</div>
        
										
    </div>
</asp:Content>
