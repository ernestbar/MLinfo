<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="sucursal_admin.aspx.cs" Inherits="appAmascuotas.sucursal_admin" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc" %>
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
      
	<asp:ObjectDataSource ID="odsPais" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
            <asp:Parameter DefaultValue="COUNTRY" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCiudad" runat="server" SelectMethod="PR_PAR_GET_DATA_CITY" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
			<asp:ControlParameter ControlID="ddlPais" Name="PV_COUNTRY" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSucursales" runat="server" SelectMethod="PR_PAR_GET_SUCURSALES" TypeName="appAmascuotas.Clases.Sucursales">
	</asp:ObjectDataSource>    
	<!-- begin #content -->
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<Triggers>
			<asp:PostBackTrigger ControlID="Repeater1" />
		</Triggers>
		<ContentTemplate>--%>

		
		<div id="content" class="content">
			<asp:SiteMapPath ID="SiteMapPath1" Runat="server" Font-Names="Verdana" Font-Size="0.8em" PathSeparator=" : ">
                <CurrentNodeStyle ForeColor="#333333" />
                <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
                <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
                <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
			</asp:SiteMapPath>
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblCliente" runat="server" Text="0" Visible="false"></asp:Label>
			<asp:Label ID="lblCodSucursal" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodSucursalPadre" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
             <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevoCliente" class="btn btn-success btn-sm" OnClick="btnNuevoCliente_Click" runat="server" Text="New Branch Office" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Branch Office <small></small></h1>
          
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
															<th class="text-nowrap">CODIGO</th>
															<th class="text-nowrap">COUNTRY</th>
															<th class="text-nowrap">CITY</th>
															<th class="text-nowrap">POSTAL CODE</th>
															<th class="text-nowrap">NAME BRANCH OFFICE</th>
															<th class="text-nowrap">LATITUDE</th>
															<th class="text-nowrap">LENGTH</th>
															<th class="text-nowrap">STATE</th>
															<th class="text-nowrap" data-orderable="false">OPTIONS</th>															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsSucursales" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">																
															<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("COD_SUCURSAL") %>'></asp:Label></td>
																<td><asp:Label ID="lblPias" runat="server" Text='<%# Eval("DESC_PAIS") %>'></asp:Label></td>
															<td><asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("VILLAGE_NAME") %>'></asp:Label></td>
															<td><asp:Label ID="lblCiudad1" runat="server" Text='<%# Eval("POSTALE_CODE") %>'></asp:Label></td>
															<td><asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
															<td><asp:Label ID="lblLatitud" runat="server" Text='<%# Eval("LATITUD") %>'></asp:Label></td>
															<td><asp:Label ID="lblLongitud" runat="server" Text='<%# Eval("LONGITUD") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_SUCURSAL") %>' OnClick="btnEditar_Click" runat="server" Text="Edit" ToolTip="Edit" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("COD_SUCURSAL") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click"  runat="server" Text="Activate/Desactivate" ToolTip="Delete register" />
																<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("SUC_ID_SUCURSAL") +"|" + Eval("DESC_ESTADO")  %>' OnClick="btnEliminar_Click" runat="server" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" Text="Activar/Desactivar" ToolTip='<%# Eval("CLI_ESTADO") %>' />--%>
                                                                
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
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Data Branch Office</legend>
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Branch Code:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtCodigo" class="form-control" style="text-transform:uppercase" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtCodigo" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Branch Name:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtNombreSucursal" class="form-control" style="text-transform:uppercase" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNombreSucursal" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Direction:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtDireccion" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Country:</label>
						<div class="col-md-6">
						        <asp:DropDownList ID="ddlPais" class="form-control" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"  OnDataBound="ddlPais_DataBound" AutoPostBack="true"  DataSourceID="odsPais" DataTextField="descripcion" DataValueField="codigo" ForeColor="Black" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPais" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
                        </div>  
					</div>
					<!-- end form-group row -->  
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">City search:</label>
						<div class="col-md-6">
						         <asp:DropDownList ID="ddlCiudad"  class="default-select2 form-control" OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged" AutoPostBack="true" DataSourceID="odsCiudad" OnDataBound="ddlCiudad_DataBound" DataTextField="city" DataValueField="cod_city"  ForeColor="Black" runat="server"></asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMesssage="*" ForeColor="Red" ControlToValidate="ddlCiudad" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>--%>
                        </div>
						<div class="col-md-1">
							<asp:ImageButton ID="imgNew" OnClick="imgNew_Click" ImageUrl="~/Imagenes/agregar.png" CausesValidation="false" Height="40px" ToolTip="Add new city" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
					 <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">City:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtCiudad" class="form-control" Enabled="false" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtLatitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
				    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Village:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtVillage" class="form-control" Enabled="false" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtLatitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Postal code:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtPostalCode" class="form-control" Enabled="false" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtLatitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Latitude:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtLatitud" class="form-control" Enabled="false" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtLatitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Length:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtLongitud" class="form-control"  Enabled="false" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtLongitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
					 <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label"><input type="button" class="btn-sm btn-success btn-block" value="My location" onclick="javascript: showlocation()" />
							<asp:Button ID="btnVerUbi" OnClick="btnVerUbi_Click" runat="server" CssClass="bg-transparent border-0" Text="" Visible="true" />
							<asp:HiddenField ID="hfLatitud" runat="server" EnableViewState="true"  />
							<asp:HiddenField ID="hfLongitud" runat="server" EnableViewState="true" /></label>
						<div class="col-md-6">
                            <cc:GMap ID="Gmap2" runat="server" mapType="Normal" Height="350px" Width="100%" enableServerEvents="True" enableGoogleBar="True"  serverEventsType="AspNetPostBack" OnClick="Gmap2_Click" />
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtLongitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
				
					<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" OnClick="btnGuardar_Click" Text="Save" />
							<asp:Button ID="btnVolver" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolver_Click" Text="Cancel" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
        </asp:View>
    </asp:MultiView>
	
			<asp:HiddenField ID="hfCustomerId" runat="server" />
			<asp:HiddenField ID="hfCustomerId2" runat="server" />
            <asp:HiddenField ID="hfLat" runat="server" />
			<asp:HiddenField ID="hfLon" runat="server" />
		</div>
			<%--</ContentTemplate>
    </asp:UpdatePanel>--%>
		<!-- end #content -->
	<script type="text/javascript">



        function showlocation() {
            // One-shot position request.
            navigator.geolocation.getCurrentPosition(callback);
        }

        function callback(position) {

            var lat = position.coords.latitude;
            var lon = position.coords.longitude;

            document.getElementById('<%= txtLatitud.ClientID %>').innerHTML = lat;
            document.getElementById('<%= txtLongitud.ClientID %>').innerHTML = lon;
            document.getElementById('<%= hfLatitud.ClientID %>').value = lat;
            document.getElementById('<%= hfLongitud.ClientID %>').value	= lon;
            document.getElementById("<%= btnVerUbi.ClientID %>").click();
        }

    </script>
</asp:Content>
