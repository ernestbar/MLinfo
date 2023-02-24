<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="cliente_admin.aspx.cs" Inherits="appAmascuotas.cliente_admin" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc" %>
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

    
     <asp:ObjectDataSource ID="odsClientes" runat="server" SelectMethod="PR_CLI_GET_CLIENTES" TypeName="appAmascuotas.Clases.Clientes">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoCliente" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="CLIENT TYPE" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTypeComunication" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="MODE COMMUNICATION" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsPais" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
            <asp:Parameter DefaultValue="COUNTRY" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsPais2" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
            <asp:Parameter DefaultValue="COUNTRY" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCiudad" runat="server" SelectMethod="PR_PAR_GET_DATA_CITY" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
			<asp:ControlParameter ControlID="ddlPais" Name="PV_COUNTRY" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCiudad2" runat="server" SelectMethod="PR_PAR_GET_DATA_CITY" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
			<asp:ControlParameter ControlID="ddlPais2" Name="PV_COUNTRY" Type="String" />
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
			<asp:SiteMapPath ID="SiteMapPath1" Runat="server" Font-Names="Verdana" Font-Size="0.8em" PathSeparator=" : ">
                <CurrentNodeStyle ForeColor="#333333" />
                <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
                <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
                <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
			</asp:SiteMapPath>
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblIdCliente" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
            <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-12" style="text-align:right">
												<asp:LinkButton ID="lbtNuevo" class="btn btn-primary btn-md" OnClick="lbtNuevo_Click" runat="server"><i class="fa fa-user-plus"></i><br /> New client </asp:LinkButton>
                                                <%--<asp:Button ID="btnNuevo" class="btn btn-success btn-sm" OnClick="btnNuevo_Click" runat="server" Text="New Client" />--%>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Client Admin <small></small></h1>
											
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
												<%--<table id="data-table-default" class="table table-striped table-bordered">--%>
													<table id="tabla1" class="table table-striped table-bordered">
													<thead>
														<tr>
															<%--<th class="text-wrap">TYPE CLIENT</th>
																<th class="text-nowrap">SOCIETY</th>--%>
																<th>NAME</th>
																<%--<th class="text-nowrap">SURNAMES</th>
																<th class="text-nowrap">DATE_BIRTH</th>--%>
																<th>ADDRESS</th>
																<%--<th class="text-nowrap">COUNTRY</th>
																<th class="text-nowrap">CITY</th>
																<th class="text-nowrap">VILLAGE_NAME</th>
																<th class="text-nowrap">POSTALE_CODE</th>
																<th class="text-nowrap">LONGITUD</th>
																<th class="text-nowrap">LATITUD</th>
																<th class="text-nowrap">EMAIL</th>
																<th class="text-nowrap">PHONE</th>
																<th class="text-nowrap">MOBILE</th>
																<th class="text-nowrap">FAX</th>
																<th class="text-nowrap">TYPE COMMUNICATION</th>
																<th class="text-nowrap">ESTADO</th>--%>
															<th>AAAA</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsClientes" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="odd gradeX">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
															<%--<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("DESC_TYPE_CLIENT") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("SOCIETY") %>'></asp:Label></td>--%>
																<%--<td><asp:Label ID="Label15" runat="server" Text='<%# Eval("NAME") %>'></asp:Label></td>--%>
																<td>
																	<asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("ID_CLIENT") %>' OnClick="LinkButton1_Click" runat="server"><%# Eval("NAME") %></asp:LinkButton>
																</td>
																<%--<td><asp:Label ID="Label25" runat="server" Text='<%# Eval("SURNAMES") %>'></asp:Label></td>
																<td><asp:Label ID="Label35" runat="server" Text='<%# Eval("DATE_BIRTH") %>'></asp:Label></td>--%>
																<td><asp:Label ID="Label45" runat="server" Text='<%# Eval("ADDRESS") %>'></asp:Label></td>
																<%--<td><asp:Label ID="Label55" runat="server" Text='<%# Eval("DESC_COUNTRY") %>'></asp:Label></td>
																<td><asp:Label ID="Label65" runat="server" Text='<%# Eval("CITY") %>'></asp:Label></td>
																<td><asp:Label ID="Label75" runat="server" Text='<%# Eval("VILLAGE_NAME") %>'></asp:Label></td>
																<td><asp:Label ID="Label85" runat="server" Text='<%# Eval("POSTALE_CODE") %>'></asp:Label></td>
																<td><asp:Label ID="Label95" runat="server" Text='<%# Eval("LONGITUD") %>'></asp:Label></td>
																<td><asp:Label ID="Label1115" runat="server" Text='<%# Eval("LATITUD") %>'></asp:Label></td>
																<td><asp:Label ID="Label125" runat="server" Text='<%# Eval("EMAIL") %>'></asp:Label></td>
																<td><asp:Label ID="Label135" runat="server" Text='<%# Eval("PHONE") %>'></asp:Label></td>
																<td><asp:Label ID="Label145" runat="server" Text='<%# Eval("MOBILE") %>'></asp:Label></td>
																<td><asp:Label ID="Label1415" runat="server" Text='<%# Eval("FAX") %>'></asp:Label></td>
																<td><asp:Label ID="Label1425" runat="server" Text='<%# Eval("DESC_TYPE_COMMUNICATION") %>'></asp:Label></td>--%>
																<%--<td><asp:Label ID="Label14215" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>--%>
															<td>
																<asp:ImageButton ID="ibtnMapa" CommandArgument='<%# Eval("LATITUD") +"|" + Eval("LONGITUD") %>' OnClick="ibtnMapa_Click" ImageUrl="~/Imagenes/google_maps.png" runat="server" />
															<%--	<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("ID_CLIENT") %>' OnClick="btnEditar_Click" runat="server" Text="Edit" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("ID_CLIENT") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click" runat="server" Text="Activate/Desactivate" ToolTip="Activate or desactivate clients" />
																<asp:Button ID="btnContacts" class="btn btn-success btn-sm" CommandArgument='<%# Eval("ID_CLIENT") %>' OnClick="btnContacts_Click" runat="server" Text="Contacts" ToolTip="Contacts Management" />--%>
                                                                
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
				<div class="col-md-8">
					<hr style="background-color:blue"/>
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Data Client</legend>
					<hr />
					<table border="0"  width="100%" class="table table-striped dataTable">
						<tbody>
							<tr>
								<asp:LinkButton ID="lbtnEditarR" class="btn btn-primary btn-md" OnClick="lbtnEditarR_Click" runat="server"><i class="fa fa-user"></i><br /> Edit </asp:LinkButton>
								<asp:LinkButton ID="lbtnVoler2" CssClass="btn btn-secondary btn-sm" runat="server" CausesValidation="false" OnClick="lbtnVoler2_Click"><i class="fa fa-arrow-alt-circle-left"></i><br /> Cancel </asp:LinkButton>
							</tr>
							<tr>
								<td>
									<label class="col-md-3 text-md-right col-form-label">Society:</label>
								</td>
								<td>
									<asp:Label ID="lblSocietyR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Client:</label>
								</td>
								<td>
									<asp:Label ID="lblClientR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">BirthDate:</label>
								</td>
								<td>
									<asp:Label ID="lblBirthDateR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Addess:</label>
								</td>
								<td>
									<asp:Label ID="lblAddressR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Municipality:</label>
								</td>
								<td>
									<asp:Label ID="lblCityR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">City:</label>
								</td>
								<td>
									<asp:Label ID="lblVillageR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Email:</label>
								</td>
								<td>
									<asp:Label ID="lblEmailR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Telephone:</label>
								</td>
								<td>
									<asp:Label ID="lblTelphoneR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Celular:</label>
								</td>
								<td>
									<asp:Label ID="lblCelularR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Fax:</label>
								</td>
								<td>
									<asp:Label ID="lblFaxR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Type Comunication:</label>
								</td>
								<td>
									<asp:Label ID="lblComunicationR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
										<label class="col-md-3 text-md-right col-form-label">Postale Code:</label>
								</td>
								<td>
									<asp:Label ID="lblPostaleR" runat="server" Text=""></asp:Label>
								</td>
							</tr>
						</tbody>
					</table>
					<cc:GMap ID="Gmap3" runat="server" mapType="Normal" Height="350px" Width="100%" enableServerEvents="True" enableGoogleBar="True" />
				</div>
				
				<!-- end form-group row -->
				<div class="col-md-4">
					<hr style="background-color:red"/>
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Vehicles</legend>
					<hr />
					<asp:LinkButton ID="LinkButton4" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-car"></i><br /> List of sold vehicles </asp:LinkButton>
					<hr style="background-color:red"/>
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Labour</legend>
					<hr />
					<asp:LinkButton ID="LinkButton3" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-plus-circle"></i><br /> New intervention </asp:LinkButton>
					<asp:LinkButton ID="LinkButton5" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-car"></i><br /> New offset </asp:LinkButton>
					<asp:LinkButton ID="LinkButton6" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-car"></i><br /> New offset ofert </asp:LinkButton>
					<asp:LinkButton ID="LinkButton7" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> List of interventions </asp:LinkButton>
					<hr style="background-color:red"/>
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Materials</legend>
					<hr />
					<asp:LinkButton ID="LinkButton8" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-plus-circle"></i><br /> New material</asp:LinkButton>
					<asp:LinkButton ID="LinkButton9" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-plus-circle"></i><br /> New command</asp:LinkButton>
					<asp:LinkButton ID="LinkButton10" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-arrow-up"></i><br /> Stock materials</asp:LinkButton>
					<asp:LinkButton ID="LinkButton11" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-plus-circle"></i><br /> New purchase order</asp:LinkButton>
					<asp:LinkButton ID="LinkButton12" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> List of materials </asp:LinkButton>
					<asp:LinkButton ID="LinkButton13" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> List of commands </asp:LinkButton>
					<asp:LinkButton ID="LinkButton14" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> List of purchase orders </asp:LinkButton>
					<hr style="background-color:red"/>
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Customer billing</legend>
					<hr />
					<asp:LinkButton ID="LinkButton15" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-file"></i><br /> New bill</asp:LinkButton>
					<asp:LinkButton ID="LinkButton16" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-file"></i><br /> Generate QR</asp:LinkButton>
					<asp:LinkButton ID="LinkButton17" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-file"></i><br /> New invoice class</asp:LinkButton>
					<asp:LinkButton ID="LinkButton18" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-plus-circle"></i><br />New deposit</asp:LinkButton>
					<asp:LinkButton ID="LinkButton19" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-plus-circle"></i><br /> New pay</asp:LinkButton>
					<asp:LinkButton ID="LinkButton20" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-file-archive"></i><br /> Bill list </asp:LinkButton>
					<asp:LinkButton ID="LinkButton21" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-file-archive"></i><br /> Bill QR list </asp:LinkButton>
					<asp:LinkButton ID="LinkButton22" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> Quota list </asp:LinkButton>
					<asp:LinkButton ID="LinkButton23" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> Pay list</asp:LinkButton>
					<asp:LinkButton ID="LinkButton24" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list-ol"></i><br /> Account status</asp:LinkButton>
					<hr style="background-color:red"/>
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Offers</legend>
					<hr />
					<asp:LinkButton ID="LinkButton25" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-plus-circle"></i><br /> New labour</asp:LinkButton>
					<asp:LinkButton ID="LinkButton26" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-plus-circle"></i><br /> New maerial</asp:LinkButton>
					<asp:LinkButton ID="LinkButton27" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-file"></i><br /> New offert</asp:LinkButton>
					<asp:LinkButton ID="LinkButton28" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br />Labour list</asp:LinkButton>
					<asp:LinkButton ID="LinkButton29" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> Material list</asp:LinkButton>
					<asp:LinkButton ID="LinkButton30" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> Offert list</asp:LinkButton>
					<hr style="background-color:red"/>
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Resources</legend>
					<hr />
					<asp:LinkButton ID="LinkButton31" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-upload"></i><br /> Files</asp:LinkButton>
					<asp:LinkButton ID="LinkButton32" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> List of accounts and devices</asp:LinkButton>
					<asp:LinkButton ID="LinkButton33" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br /> List of device</asp:LinkButton>
					<asp:LinkButton ID="LinkButton34" class="btn btn-primary btn-md mt-1" Width="130px" runat="server"><i class="fa fa-list"></i><br />List contacts</asp:LinkButton>
				</div>
				

				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		<asp:View ID="View3" runat="server">
			<!-- begin row -->
			<div class="row">
				<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">New Client</legend>
				<hr style="background-color:blue"/>
				<hr />
				<!-- begin col-8 -->
				<div class="col-md-6">
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Personal information</legend>
					<hr />
					<!-- begin form-group row -->
					<label class="col-md-12 text-md-left col-form-label">Client Type:</label>
					<div class="col-md-12">
									<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoCliente" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
								<asp:DropDownList ID="ddlTipoCliente" DataSourceID="odsTipoCliente" DataTextField="descripcion" OnDataBound="ddlTipoCliente_DataBound" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
							</div>
						<!-- end form-group row -->
					<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Society:</label>
							<div class="col-md-12">
									<asp:TextBox ID="txtSociety" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSociety" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						<!-- end form-group row -->
						<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Name:</label>
							<div class="col-md-12">
									<asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtName" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						<!-- end form-group row -->
						<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Surname:</label>
							<div class="col-md-12">
									<asp:TextBox ID="txtSurname" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSurname" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						<!-- end form-group row -->
						<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Birthdate:</label>
							<div class="col-md-12">
								<asp:Label ID="lblFechaDesde" Visible="false" runat="server" Text=""></asp:Label>
								<input id="fecha_salida" class="form-control" onfocus="bloquear()" onchange="recuperarFechaSalida()" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
							</div>
						<!-- end form-group row -->
						<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Address:</label>
							<div class="col-md-12">
									<asp:TextBox ID="txtAddres" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSociety" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						<!-- end form-group row -->
						<asp:UpdatePanel ID="UpdatePanel1" runat="server">
											
										<ContentTemplate>
										<%--<script type="text/javascript">
											function pageLoad(sender, args) {
												if (args.get_isPartialLoad()) {
													$('#<%= UpdatePanel1.ClientID %> .ddlCiudad').ddlCiudad();
												}
											}
                                        </script>--%>
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Country:</label>
											<div class="col-md-12">
													<asp:DropDownList ID="ddlPais" class="form-control" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged" OnDataBound="ddlPais_DataBound" AutoPostBack="true"  DataSourceID="odsPais" DataTextField="descripcion" DataValueField="codigo" ForeColor="Black" runat="server"></asp:DropDownList>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPais" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>  
										<!-- end form-group row -->  
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Municipality search:</label>
											<div class="form-group row m-b-10">
												<div class="col-md-10">
													 <asp:DropDownList ID="ddlCiudad"  class="default-select2 form-control" OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged" AutoPostBack="true" DataSourceID="odsCiudad" OnDataBound="ddlCiudad_DataBound" DataTextField="city" DataValueField="cod_city"  ForeColor="Black" runat="server"></asp:DropDownList>
													<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMesssage="*" ForeColor="Red" ControlToValidate="ddlCiudad" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>--%>
											</div>
											<div class="col-md-1">
												<asp:ImageButton ID="imgNew" OnClick="imgNew_Click" ImageUrl="~/Imagenes/agregar.png" CausesValidation="false" Height="40px" ToolTip="Add new city" runat="server" />
											</div>
											</div>
											
										<!-- end form-group row -->
											<asp:TextBox ID="txtCiudad" class="form-control" Visible="false"  runat="server"></asp:TextBox>
										 <!-- begin form-group row -->
										<%--<label class="col-md-12 text-md-left col-form-label">Municipality:</label>
											<div class="col-md-12">
											</div>--%>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">City:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtVillage" class="form-control" Enabled="false" runat="server"></asp:TextBox>
												<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtLatitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
											</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Postal code:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtPostalCode" class="form-control" Enabled="false" runat="server"></asp:TextBox>
												<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtLatitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
											</div>
										<!-- end form-group row -->
											<asp:TextBox ID="txtLatitud" class="form-control" Visible="false"  runat="server"></asp:TextBox>
										<!-- begin form-group row -->
										<%--<label class="col-md-12 text-md-left col-form-label">Latitude:</label>
											<div class="col-md-12">
												
											</div>--%>
										<!-- end form-group row -->
											<asp:TextBox ID="txtLongitud" class="form-control" Visible="false"   runat="server"></asp:TextBox>
										<!-- begin form-group row -->
										<%--<label class="col-md-12 text-md-left col-form-label">Length:</label>
											<div class="col-md-12">
											</div>--%>
										<!-- end form-group row -->
										 <!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label"><input type="button" class="btn-sm btn-success btn-block" value="My location" onclick="javascript: showlocation()" />
												<asp:Button ID="btnVerUbi"  CausesValidation="false" OnClientClick="recuperarFechaSalida()" OnClick="btnVerUbi_Click" runat="server" CssClass="bg-transparent border-0" Text="" Visible="true" />
												<asp:HiddenField ID="hfLatitud" runat="server" EnableViewState="true"  />
												<asp:HiddenField ID="hfLongitud" runat="server" EnableViewState="true" /></label>
											<div class="col-md-6">
												<cc:GMap ID="Gmap2" runat="server" mapType="Normal" Height="350px" Width="100%" enableServerEvents="True" OnClientClick="recuperarFechaSalida()" enableGoogleBar="True"  serverEventsType="AspNetPostBack" OnClick="Gmap2_Click" />
												<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtLongitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->

											</ContentTemplate>
									</asp:UpdatePanel>
				</div>
				<!-- end form-group row -->
				<div class="col-md-6">
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Contact details</legend>
					<hr />
					<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Email:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Phone:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtPhone" class="form-control" runat="server"></asp:TextBox>
											</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Mobile:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtMobile" class="form-control"  runat="server"></asp:TextBox>
											</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Fax:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtFax" class="form-control" runat="server"></asp:TextBox>
											</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Type Comunication:</label>
											<div class="col-md-12">
												 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTypeComunication" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
											   <asp:DropDownList ID="ddlTypeComunication" DataSourceID="odsTypeComunication" DataTextField="descripcion" OnDataBound="ddlTypeComunication_DataBound" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
											</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Door Number:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtDoorNumber" class="form-control"  runat="server"></asp:TextBox>
											</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Floor:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtFloor" class="form-control" runat="server"></asp:TextBox>
											</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Comments:</label>
											<div class="col-md-12">
												<asp:TextBox ID="txtComments" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
											</div>
										<!-- end form-group row -->
					<br />
					<div id="accordion" class="card-accordion">
						<!-- begin card -->
						<div class="card">
							<div class="card-header bg-blue text-white pointer-cursor collapsed" data-toggle="collapse" data-target="#collapseTwo">
								Billing Data
							</div>
							<div id="collapseTwo" class="collapse" data-parent="#accordion">
								<div class="card-body">
									<asp:UpdatePanel ID="UpdatePanel2" runat="server">
										<ContentTemplate>
										<!-- begin form-group row -->
											<label class="col-md-12 text-md-left col-form-label">Address:</label>
												<div class="col-md-12">
													 <asp:TextBox ID="txtBillingAddress" class="form-control" runat="server"></asp:TextBox>
													<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSociety" Font-Bold="True"></asp:RequiredFieldValidator>--%>
												</div>
											<!-- end form-group row -->
											<!-- begin form-group row -->
											<label class="col-md-12 text-md-left col-form-label">Country:</label>
												<div class="col-md-12">
														<asp:DropDownList ID="ddlPais2" class="form-control"  OnDataBound="ddlPais2_DataBound" AutoPostBack="true"  DataSourceID="odsPais2" DataTextField="descripcion" DataValueField="codigo" ForeColor="Black" runat="server"></asp:DropDownList>
														<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPais2" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>--%>
												</div>  
											<!-- end form-group row -->  
											<!-- begin form-group row -->
											<label class="col-md-12 text-md-left col-form-label">Municipality search:</label>
											<div class="form-group row m-b-10">
												
												<div class="col-md-10">
														 <asp:DropDownList ID="ddlCiudad2"  class="default-select2 form-control" OnSelectedIndexChanged="ddlCiudad2_SelectedIndexChanged" AutoPostBack="true" DataSourceID="odsCiudad2" OnDataBound="ddlCiudad2_DataBound" DataTextField="city" DataValueField="cod_city"  ForeColor="Black" runat="server"></asp:DropDownList>
														<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMesssage="*" ForeColor="Red" ControlToValidate="ddlCiudad" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>--%>
												</div>
												<div class="col-md-1">
													<asp:ImageButton ID="ibtnNewBilling" OnClick="imgNew_Click" ImageUrl="~/Imagenes/agregar.png" CausesValidation="false" Height="40px" ToolTip="Add new city" runat="server" />
												</div>
											</div>
											<!-- end form-group row -->
												<asp:TextBox ID="txtBillingCity" class="form-control"  Visible="false" runat="server"></asp:TextBox>
											 <!-- begin form-group row -->
											<%--<label class="col-md-12 text-md-left col-form-label">Municipality:</label>
												<div class="col-md-12">
												
												</div>--%>
											<!-- end form-group row -->
											
											<!-- begin form-group row -->
											<label class="col-md-12 text-md-left col-form-label">City:</label>
												<div class="col-md-12">
													<asp:TextBox ID="txtBillingVillage" class="form-control"  Enabled="false" runat="server"></asp:TextBox>
												</div>
											<!-- end form-group row -->
											<!-- begin form-group row -->
											<label class="col-md-12 text-md-left col-form-label">Postal code:</label>
												<div class="col-md-12">
													<asp:TextBox ID="txtBillingPostaleCode" class="form-control" Enabled="false" runat="server"></asp:TextBox>
												</div>
											<!-- end form-group row -->
											<asp:TextBox ID="txtBillingLatitud" class="form-control" Visible="false" runat="server"></asp:TextBox>
											<!-- begin form-group row -->
											<%--<label class="col-md-12 text-md-left col-form-label">Latitude:</label>
												<div class="col-md-12">
													
												</div>--%>
											<!-- end form-group row -->
											<asp:TextBox ID="txtBillingLongitud" class="form-control"  Visible="false" runat="server"></asp:TextBox>
											<!-- begin form-group row -->
											<%--<label class="col-md-12 text-md-left col-form-label">Length:</label>
												<div class="col-md-12">
													
												</div>--%>
											<!-- end form-group row -->
											 <!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label"><input type="button" class="btn-sm btn-success btn-block" value="My location" onclick="javascript: showlocation()" />
													<asp:Button ID="btnBillingVerUbi"  CausesValidation="false" OnClick="btnBillingVerUbi_Click1" runat="server" CssClass="bg-transparent border-0" Text="" Visible="true" />
													<asp:HiddenField ID="hfBillingLatitud" runat="server" EnableViewState="true"  />
													<asp:HiddenField ID="hfBillingLongitud" runat="server" EnableViewState="true" /></label>
												<div class="col-md-6">
													<cc:GMap ID="Gmap1" runat="server" mapType="Normal" Height="350px" Width="100%" enableServerEvents="True" enableGoogleBar="True"  serverEventsType="AspNetPostBack" OnClick="Gmap1_Click1" />
													<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtLongitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
												</div>
											</div>
											<!-- end form-group row -->
										</ContentTemplate>
									</asp:UpdatePanel>
								</div>
							</div>
						</div>
					</div>
					<!-- end #accordion -->

				</div>

				</div>	
			<div class="row">
				<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
					<asp:LinkButton ID="lbtnGuardar" CssClass="btn btn-success btn-sm" runat="server" OnClientClick="recuperarFechaSalida()" OnClick="btnGuardar_Click"><i class="fa fa-plus"></i><br /> Save client </asp:LinkButton>
					<asp:LinkButton ID="lbtnVolver" CssClass="btn btn-secondary btn-sm" runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click"><i class="fa fa-arrow-alt-circle-left"></i><br /> Cancel </asp:LinkButton>
					<%--<asp:Button ID="btnGuardar" CssClass="btn btn-success btn-lg" runat="server"  Text="Save" />
					<asp:Button ID="btnVolverAlta" CssClass="btn btn-secondary btn-lg"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancel" />--%>
					</div>
			</div>
				<!-- end col-8 -->
				
			
					
		</asp:View>
    </asp:MultiView>
	
			
		</div>
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
			document.getElementById('<%= hfLongitud.ClientID %>').value = lon;
            document.getElementById('<%= txtBillingLatitud.ClientID %>').innerHTML = lat;
            document.getElementById('<%= txtBillingLongitud.ClientID %>').innerHTML = lon;
            document.getElementById('<%= hfBillingLatitud.ClientID %>').value = lat;
            document.getElementById('<%= hfBillingLongitud.ClientID %>').value = lon;
            document.getElementById("<%= btnVerUbi.ClientID %>").click();
            document.getElementById("<%= btnBillingVerUbi.ClientID %>").click();
        }

    </script>
	<script type="text/javascript">

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
		}
        function setearFechaSalida() {
            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
		}
        
    </script>
	<script>
		$(document).ready(function () {
			//var table = $('#data-table-default').DataTable();
            $('div.dataTables_filter input', $('#data-table-default').DataTable().table().container()).focus();
        });
    </script>
</asp:Content>
