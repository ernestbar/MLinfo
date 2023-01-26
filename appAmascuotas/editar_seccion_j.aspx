<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="editar_seccion_j.aspx.cs" Inherits="appAmascuotas.editar_seccion_j" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
	<asp:ObjectDataSource ID="odsClientesJuridica" runat="server" SelectMethod="Lista_clientes_juridica" TypeName="appAmascuotas.Clases.clientes">
		</asp:ObjectDataSource>
   <asp:ObjectDataSource ID="odsExpedido" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="EXPEDIDO" Name="PV_DOMINIO" Type="String" />
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
	<asp:ObjectDataSource ID="odsClaseSociedad" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="CLASE SOCIEDAD" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
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
			<h1 class="page-header">AmasCuotas <small>ediciones persona juridica</small></h1>
        
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label> 
             <asp:MultiView ID="MultiView2" runat="server">
                <asp:View ID="View3" runat="server">
					<div class="row">
                        <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Seleccione la secciona editar:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlSeccion" OnSelectedIndexChanged="ddlSeccion_SelectedIndexChanged" AutoPostBack="true" class="form-control" runat="server"></asp:DropDownList>
												<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlRuta1" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<div class="form-group row m-b-10">
										<label class="col-md-3 text-md-right col-form-label"></label>
										<div class="col-md-6">
												
											<p><asp:Button ID="btnVolverGrilla" class="btn btn-primary btn-sm"  OnClick="btnVolverGrilla_Click" runat="server" Text="Volver" /></p>
										</div>
									</div>
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
                </asp:View>
                <asp:View ID="View4" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Generales</legend>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nit</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNit" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNit" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
											<%--<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatos" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatos_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>--%>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nombre o Razon Social</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtRazonSocial" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRazonSocial" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
											<%--<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosName" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatos_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>--%>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Ciudad empresa:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlExpedido" class="form-control" DataSourceID="odsExpedido" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlExpedido_DataBound" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlExpedido" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Clase de sociedad</label>
											<div class="col-md-8">
												<asp:RadioButtonList ID="rblClaseSociedad" Font-Size="Smaller"  DataSourceID="odsClaseSociedad" OnSelectedIndexChanged="rblClaseSociedad_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="rblClaseSociedad" runat="server" InitialValue="" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<div class="col-md-12">
													<asp:TextBox ID="txtSociedadOtros" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												</div>
											</div>
											
										</div>
										<!-- end form-group row -->
										
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Fecha de fundacion</label>
											<div class="col-md-6">
												<div class="row row-space-6">
												<div class="col-4">
                                                        <asp:DropDownList ID="ddlFunDia" class="form-control" runat="server"></asp:DropDownList>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFunDia" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFunMes" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFunMes" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFunAño" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFunAño" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													</div>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Actividad de la empresa</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtActividad" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtActividad" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Rubro</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtRubro" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRubro" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Grupo economico</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtGrupoEconomico" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGrupoEconomico" Font-Bold="True"></asp:RequiredFieldValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTelefono" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTelefono" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Pagina web</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPaginaWeb" class="form-control" runat="server"></asp:TextBox>
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
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos representante(s) legal(es)</legend>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<!-- begin table-responsive -->
											<div class="table-responsive">
												<table class="table">
													<thead>
														<tr>
															<th>Nro</th>
															<th nowrap>Nombre completo</th>
															<th nowrap>Nro de poder</th>
															<th nowrap>Cargo</th>
															<th nowrap>E-mail</th>
															<th nowrap>Telefono</th>
															<th nowrap>Nro. CI</th>
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>1</td>
                                                            <asp:Label ID="lblCodRep1" runat="server" Text="" Visible="false"></asp:Label>
															<td><asp:TextBox ID="txtRepNombre1" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRepNombre1" Font-Bold="True"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRepNroPoder1" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRepNroPoder1" Font-Bold="True"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRepCargo1" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRepCargo1" Font-Bold="True"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRepEmail1" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRepEmail1" Font-Bold="True"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRepTelefono1" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRepTelefono1" Font-Bold="True"></asp:RequiredFieldValidator>
															</td>
															<td><asp:TextBox ID="txtRepCi1" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRepCi1" Font-Bold="True"></asp:RequiredFieldValidator>
															</td>
															
														</tr>
														<tr>
															<td>2</td><asp:Label ID="lblCodRep2" runat="server" Text="" Visible="false"></asp:Label>
															<td><asp:TextBox ID="txtRepNombre2" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepNroPoder2" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepCargo2" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepEmail2" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepTelefono2" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepCi2" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
														</tr>
														<tr>
															<td>3</td><asp:Label ID="lblCodRep3" runat="server" Text="" Visible="false"></asp:Label>
															<td><asp:TextBox ID="txtRepNombre3" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepNroPoder3" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepCargo3" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepEmail3" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepTelefono3" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepCi3" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
														</tr>
														<tr>
															<td>4</td><asp:Label ID="lblCodRep4" runat="server" Text="" Visible="false"></asp:Label>
															<td><asp:TextBox ID="txtRepNombre4" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepNroPoder4" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepCargo4" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepEmail4" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepTelefono4" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
															<td><asp:TextBox ID="txtRepCi4" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox></td>
														</tr>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
										</div>
									<!-- end col-8 -->
								</div>
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
										<!-- begin form-group row -->
										<asp:Label ID="lblCodDir" runat="server" Text="" Visible="false"></asp:Label>
										<%--<div class="form-group row m-b-10"><asp:Label ID="lblCodDir" runat="server" Text="" Visible="false"></asp:Label>--%>
											<%--<label class="col-md-3 text-md-right col-form-label">Tipo vivienda:</label>
											<div class="col-md-6">
												<asp:RadioButtonList ID="rblTipoVivienda" DataSourceID="odsTipoVivienda" CellPadding="3"  RepeatDirection="Horizontal" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator49" ControlToValidate="rblTipoVivienda" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>--%>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<%--<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Detalle:</label>
											<div class="col-md-6">
												<asp:RadioButtonList ID="rblDetalleVivienda" DataSourceID="odsDetalleVivienda"  RepeatDirection="Vertical" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="rblDetalleVivienda" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<label class="col-md-3 text-md-right col-form-label">Otra</label>
												<div class="col-md-9">
													<asp:TextBox ID="txtDetViviendaOtros" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												</div>
											</div>
											
										</div>--%>
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
															<td>Comercial</td><asp:Label ID="lblCodRef1" runat="server" Text="" Visible="false"></asp:Label><asp:Label ID="lblTipoRef1" runat="server" Text="" Visible="false"></asp:Label>
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
															<td>Comercial</td><asp:Label ID="lblCodRef2" runat="server" Text="" Visible="false"></asp:Label><asp:Label ID="lblTipoRef2" runat="server" Text="" Visible="false"></asp:Label>
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
															<td>Comercial</td><asp:Label ID="lblCodRef3" runat="server" Text="" Visible="false"></asp:Label><asp:Label ID="lblTipoRef3" runat="server" Text="" Visible="false"></asp:Label>
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
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
									<%--</div>--%>
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
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">BALANCE EMPRESA</legend><asp:Label ID="lblCodBalance" runat="server" Text="" Visible="false"></asp:Label>
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
										
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
							<!-- end fieldset -->
                </asp:View>
               
                <asp:View ID="View8" runat="server">
					<%--<fieldset>
						<div class="row">
							<div class="col-md-8 offset-md-2">
								<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">CROQUIS</legend>
									<div class="form-group row m-b-10">
										<label class="col-md-3 text-md-right col-form-label">Ubicacion del domicilio</label>
										<div class="col-md-6">
											<div id="mapa1" style="width: 100%; height: 350px">
												<br />
											</div>
										</div>
									</div>

									<div class="form-group row m-b-10">
										<label class="col-md-3 text-md-right col-form-label"></label>
											<input type="button" class="btn btn-primary"  value="Buscar mi ubicacion" onclick="javascript: mostrarUbicacionActual1()" />
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
                        <asp:HiddenField ID="hfLongitud" runat="server" />--%>
										<!-- end form-group row -->
				<%--	<div class="jumbotron m-b-0 text-center">
								<h2 class="text-inverse">Felicidades fin del formulario</h2>
								<p class="m-b-30 f-s-16">Presione el boton finalizar <br />para guardar los datos del formulario en la base de datos. </p>
								<p><asp:Button ID="btnGrabar" class="btn btn-primary btn-lg"  OnClick="btnGrabar_Click" runat="server" Text="FINALIZAR" /></p>
							</div>--%>
				
                </asp:View>
                <%--<asp:View ID="View9" runat="server">
						
                </asp:View>--%>
            </asp:MultiView>
			 <asp:Panel ID="Panel_opciones" Visible="false" runat="server">
					
								<div class="btn-toolbar mr-2 sw-btn-group float-right p-3" role="group">
												
											<p><asp:Button ID="btnGuardar" class="btn btn-primary btn-sm"    OnClick="btnGuardar_Click" runat="server" Text="Guardar" /></p>
												<p><asp:Button ID="btnCancelar" class="btn btn-primary btn-sm" CausesValidation="false" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" /></p>
										</div>
									
            </asp:Panel> 
            
            
            </div>
</asp:Content>
