<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="editar_seccion.aspx.cs" Inherits="appAmascuotas.editar_seccion" %>
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
			<h1 class="page-header">AmasCuotas <small>ediciones persona natural</small></h1>
        
    <asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>    
			<asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
            <asp:MultiView ID="MultiView2" runat="server">
                <asp:View ID="View1" runat="server">
					<div class="row">
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
              
                <asp:View ID="View2" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Generales</legend>
										<asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false"></asp:Label>
										<!-- begin form-group row -->
										
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
											<%--<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatos" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatos_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>--%>
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
												<asp:DropDownList ID="ddlEstCivil" class="form-control" DataSourceID="odsEstadoCivil" AutoPostBack="true" OnSelectedIndexChanged="ddlEstCivil_SelectedIndexChanged" OnDataBound="ddlEstCivil_DataBound" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
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
                <asp:View ID="View3" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos de Conyugue</legend>
										<asp:Label ID="lblCodConyugue" runat="server" Text="" Visible="false"></asp:Label>
										<!-- begin form-group row -->
										<%--<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Busqueda por Nombre:(Paterno+Materno+Nombres)</label>
											<div class="col-md-5">
												<asp:TextBox ID="txtNombreCompletoCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
											<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosNombreCon" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatosCon_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>
										</div>--%>
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
											<%--<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosCon" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatosCon_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>--%>
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
                <asp:View ID="View4" runat="server">
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
                <asp:View ID="View5" runat="server">
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
                <asp:View ID="View6" runat="server">
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
                <asp:View ID="View7" runat="server">
					<!-- begin fieldset -->
							<fieldset>
								<!-- begin row -->
								<div class="row">
									<!-- begin col-8 -->
									<div class="col-md-8 offset-md-2">
										<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Garante</legend>
										<asp:Label ID="lblCodGarante" runat="server" Text="" Visible="false"></asp:Label>
										<asp:Label ID="lblCodSolicitud" runat="server" Text="" Visible="false"></asp:Label>
										<asp:Label ID="lblCodSolicitudDetalle" runat="server" Text="" Visible="false"></asp:Label>
										<asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
										<!-- begin form-group row -->
										<%--<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Busqueda por Nombre:(Paterno+Materno+Nombres)</label>
											<div class="col-md-5">
												<asp:TextBox ID="txtNombreCompletoCon" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
											<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosNombreCon" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatosCon_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>
										</div>--%>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-12">
											<label class="col-md-3 text-md-right col-form-label">Documento de identidad:</label>
											<div class="col-md-3">
                                                <asp:TextBox ID="txtCiGar" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCiCon" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
											<label class="col-md-0 text-md-right col-form-label">- Complemento:</label>
											<div class="col-md-1">
                                                <asp:TextBox ID="txtComplementoGar" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
											</div>
											<%--<label class="col-md-0 text-md-right col-form-label">-</label>
											<div class="col-md-1">
                                                <asp:LinkButton ID="lbtnTraerDatosGar" class="btn btn-default btn-icon btn-circle btn-lg" CausesValidation="false" OnClick="lbtnTraerDatosGar_Click" runat="server"><i class="fas fa-check-square"></i></asp:LinkButton>
											</div>--%>
										</div>
										<!-- end form-group row -->
										
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Expedido en:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlExpedidoGar" class="form-control" DataSourceID="odsExpedido" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlExpedidoCon_DataBound" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlExpedidoCon" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido Paterno:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPaternoGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPaternoGar" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido Materno:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtMaternoGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Apellido de Casada:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCasadaGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Primer Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtPrimerNombreGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPrimerNombreGar" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Segundo Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtSegundoNombreGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Tercer Nombre:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTercerNombreGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Sexo:</label>
											<div class="col-md-6">
                                                <asp:RadioButtonList ID="rblSexoGar" DataSourceID="odsSexo" CellPadding="5" RepeatDirection="Horizontal"  DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="rblSexoGar" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Lugar de Nacimiento:</label>
											<div class="col-md-6">
                                                <asp:DropDownList ID="ddlLugarNacimientoGar" class="form-control" DataSourceID="odsLugarNac" DataTextField="descripcion" OnDataBound="ddlLugarNacimientoGar_DataBound" DataValueField="codigo" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlLugarNacimientoGar" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nacionalidad:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNalGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNalGar" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Edad:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEdadGar" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEdadGar" Font-Bold="True"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtEdadCon" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nivel de educacion:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlNivelEduGar" class="form-control" DataSourceID="odsNivelEdu" DataTextField="descripcion" OnDataBound="ddlNivelEduGar_DataBound" DataValueField="codigo" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNivelEduGar" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Estado Civil:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlEstadoCivilGar" class="form-control" DataSourceID="odsEstadoCivil" DataTextField="descripcion" OnDataBound="ddlEstadoCivilGar_DataBound" DataValueField="codigo" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator82" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlEstadoCivilGar" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Fecha de nacimiento:</label>
											<div class="col-md-6">
												<div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlNacDiaGar" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacDiaGar" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlNacMesGar" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacMesGar" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlNacAñoGar" class="form-control" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacAñoGar" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Profesion:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtProfesionGar" placeholder="" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator83" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator85" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtProfesionGar" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono Celular:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCelGar" placeholder="" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelGar" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Email Personal:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEmailPerGar" placeholder="" class="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator86" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmailPerGar" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
							<!-- end fieldset -->
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
											<asp:Label ID="lblCodDatoLaboralGar" runat="server" Text="" Visible="false"></asp:Label>
											<div class="col-md-8">
												<asp:RadioButtonList ID="rblSituacionLaboralGar" Font-Size="Small" DataSourceID="odsSituacionLaboral" OnSelectedIndexChanged="rblSituacionLaboralGar_SelectedIndexChanged" AutoPostBack="true"  RepeatDirection="Horizontal" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator75" ControlToValidate="rblSituacionLaboralGar" runat="server" ErrorMessage="*" ForeColor="Red" InitialValue=""></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Relacion Laboral:</label>
											<div class="col-md-8">
                                                <asp:RadioButtonList ID="rblRelacionLaboralGar" Font-Size="Smaller" DataSourceID="odsRelacionLaboral" RepeatDirection="Horizontal" DataTextField="descripcion" DataValueField="codigo" class="checkbox" runat="server"></asp:RadioButtonList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator76" ControlToValidate="rblRelacionLaboralGar" runat="server" ErrorMessage="*" ForeColor="Red" InitialValue=""></asp:RequiredFieldValidator>
												<label class="col-md-3 text-md-right col-form-label">Otra</label>
												<div class="col-md-6">
													<asp:TextBox ID="txtOtrosRelLabGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												</div>
											</div>
											
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Antiguedad:</label>
											<div class="col-md-2">
												<asp:TextBox ID="txtAntiguedadGar" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator77" ControlToValidate="txtAntiguedadGar" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtAntiguedadCon" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
											<div class="col-md-4">
                                                <asp:DropDownList ID="ddlTipoAntiguedadGar" class="form-control" DataSourceID="odsTipoAntiguedad" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Cargo que ocupa:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtCargoGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator78" ControlToValidate="txtCargoGar" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Empresa donde trabaja:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEmpresaGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator79" ControlToValidate="txtEmpresaGar" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Direccion de la empresa:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtDirEmpresaGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator80" ControlToValidate="txtDirEmpresaGar" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Telefono:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtTelfLabGar" style="text-transform:uppercase" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator81" ControlToValidate="txtTelfLabGar" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtTelf" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Email:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtEmailLabGar" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator88" ControlToValidate="txtEmailLabGar" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Ingreso mensual promedio en Bs.:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtIngresoPromGar" placeholder="" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator89" ControlToValidate="txtIngresoPromGar" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
												<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txtIngresoPromedio" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										
									</div>
									<!-- end col-8 -->
								</div>
								<!-- end row -->
							</fieldset>
							<!-- end fieldset -->
                </asp:View>
                <asp:View ID="View8" runat="server">
					<div class="jumbotron m-b-0 text-center">
								<h2 class="text-inverse">Felicidades no se olvide imprimir su formulario</h2>
								<p class="m-b-30 f-s-16">Presione el boton continuar <br />para seguir el flujo. </p>
								<p><asp:Button ID="btnGrabar" class="btn btn-primary btn-lg" OnClick="btnGrabar_Click" runat="server" Text="CONTINUAR" /></p>
							</div>
                </asp:View>
             
            </asp:MultiView>
			<asp:HiddenField ID="hfCustomerId" runat="server" />
			<asp:HiddenField ID="hfCustomerId2" runat="server" />
            <asp:Panel ID="Panel_opciones" Visible="false" runat="server">
					
								<div class="btn-toolbar mr-2 sw-btn-group float-right p-3" role="group">
												
											<p><asp:Button ID="btnGuardar" class="btn btn-primary btn-sm"    OnClick="btnGuardar_Click" runat="server" Text="Guardar" /></p>
												<p><asp:Button ID="btnCancelar" class="btn btn-primary btn-sm" CausesValidation="false" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" /></p>
										</div>
									
            </asp:Panel>
			</div>
	<script type="text/javascript">
        $(function () {
            $("[id$=txtCiGar]").autocomplete({
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

        
    </script>
</asp:Content>
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