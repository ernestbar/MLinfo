<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" ValidateRequest = "False" CodeBehind="interventions_admin.aspx.cs" Inherits="appAmascuotas.interventions_admin" %>
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
	<asp:ObjectDataSource ID="odsInterventions" runat="server" SelectMethod="PR_CLI_GET_INTERVENTIOS_CLIENT" TypeName="appAmascuotas.Clases.Interventions">
			<SelectParameters>
				<asp:ControlParameter ControlID="ddlCliente" Name="PV_ID_CLIENT" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTypeService" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="TYPE SERVICE" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTypeIntervention" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
            <asp:Parameter DefaultValue="TYPE INTERVENTION" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTypeFixedPrice" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
            <asp:Parameter DefaultValue="TYPE FIXED PRICE" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
<%--	<asp:ObjectDataSource ID="odsCiudad" runat="server" SelectMethod="PR_PAR_GET_DATA_CITY" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
			<asp:ControlParameter ControlID="ddlPais" Name="PV_COUNTRY" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCiudad2" runat="server" SelectMethod="PR_PAR_GET_DATA_CITY" TypeName="appAmascuotas.Clases.Dominios">
        <SelectParameters>
			<asp:ControlParameter ControlID="ddlPais2" Name="PV_COUNTRY" Type="String" />
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
												<%--<asp:LinkButton ID="lbtNuevo" class="btn btn-primary btn-md" OnClick="lbtNuevo_Click" runat="server"><i class="fa fa-user-plus"></i><br /> New client </asp:LinkButton>--%>
                                                <%--<asp:Button ID="btnNuevo" class="btn btn-success btn-sm" OnClick="btnNuevo_Click" runat="server" Text="New Client" />--%>
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Interventions Admin <small></small></h1>
											<!-- begin form-group row -->
										<label class="col-md-12 text-md-left col-form-label">Client:</label>
										<div class="col-md-12">
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
								<asp:DropDownList ID="ddlCliente" DataSourceID="odsClientes" DataTextField="nombre_concatenado" OnDataBound="ddlCliente_DataBound" AutoPostBack="true" DataValueField="id_client"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
							</div>
			<br />
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
																<th>NUM.</th>
															<th class="text-nowrap">ESTADO</th>	
															<th>date</th>
																<th class="text-nowrap">DESCRIPTION</th>
																<th class="text-nowrap">PRICE</th>
															<th></th>
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsInterventions" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="odd gradeX">
																<td><asp:Label ID="Label15" runat="server" Text='<%# Eval("Num") %>'></asp:Label></td>
																<td><asp:Label ID="Label35" runat="server" CssClass="form-control rounded-circle" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("state").ToString()) %>' ></asp:Label></td>
																<td><asp:Label ID="Label51" runat="server" Text='<%# Eval("date") %>'></asp:Label></td>
																<td>
																	<asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("ID") %>'  runat="server"><%# Eval("description") %></asp:LinkButton>
																</td>
																<td><asp:Label ID="Label45" runat="server" Text='<%# Eval("price") %>'></asp:Label></td>
																<td><asp:LinkButton ID="lbtnDelete" class="btn btn-primary btn-md" runat="server"><i class="fa fa-trash"></i><br /> Delete </asp:LinkButton></td>
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
				<div class="col-md-6">
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Registration of a new intervention - </legend> <asp:Label ID="lblCliente" Visible="true" runat="server" Text=""></asp:Label>
					<hr />
					<!-- begin form-group row -->
					<label class="col-md-12 text-md-left col-form-label">Intervention standard:</label>
					<div class="col-md-12">
									<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoCliente" InitialValue="SELECT" Font-Bold="True"></asp:RequiredFieldValidator>
								<asp:DropDownList ID="ddlTipoCliente" DataSourceID="odsTipoCliente" DataTextField="descripcion" OnDataBound="ddlTipoCliente_DataBound" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>--%>
							</div>
						<!-- end form-group row -->
					<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Attribution of the intervention:</label>
							<div class="col-md-12">
								<asp:DropDownList ID="ddlTipoInterventions" DataSourceID="odsTypeIntervention" DataTextField="descripcion" OnDataBound="ddlTipoInterventions_DataBound" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
							</div>
						<!-- end form-group row -->
						<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Type de Service:</label>
							<div class="col-md-12">
								<asp:DropDownList ID="ddlTypeService" DataSourceID="odsTypeService" DataTextField="descripcion" OnDataBound="ddlTypeService_DataBound" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
							</div>
						<!-- end form-group row -->
						
						<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Date:</label>
							<div class="col-md-12">
								
								<input id="fecha_salida" class="form-control" onchange="recuperarFechaSalida()" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
							</div>
						<!-- end form-group row -->
					<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Type:</label>
							<div class="col-md-12">
								<asp:RadioButtonList ID="rblType" DataSourceID="odsTypeIntervention" RepeatDirection="Horizontal" AutoPostBack="true" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:RadioButtonList>
							
					<asp:Panel ID="Panel_duracion" runat="server">
						<table>
							<tr>
								<td>
									Duration:
								</td>
								<td>
									<asp:DropDownList ID="ddlHour" runat="server"></asp:DropDownList>
								</td>
								<td>
									Hour(s)
								</td>
								<td>
									<asp:DropDownList ID="ddlMinute" runat="server"></asp:DropDownList>
								</td>
								<td>
									Minute(s)
								</td>
							</tr>
						</table>
					</asp:Panel>
					<asp:Panel ID="Panel_prixFixe" runat="server">
						<table>
							<tr>
								<td>
									Prix Fixe:
								</td>
								<td>
									<asp:RadioButtonList ID="rblPrixFix" DataSourceID="odsTypeFixedPrice" RepeatDirection="Horizontal" AutoPostBack="true" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:RadioButtonList>
								</td>
							</tr>
						</table>
						<div class="col-md-12">
									<asp:TextBox ID="txtPrixFixe" class="form-control" runat="server"></asp:TextBox>
							</div>
					</asp:Panel>
								</div>
						<!-- end form-group row -->
						<!-- begin form-group row -->
						<label class="col-md-12 text-md-left col-form-label">Description court:</label>
							<div class="col-md-12">
								<div class="panel-body">
									<form action="/" name="wysihtml5" method="POST">
										<textarea class="textarea form-control" id="wysihtml5" onchange="recuperarFechaSalida()" placeholder="Enter text ..." rows="12"></textarea>
									</form>
								</div>
								<asp:HiddenField ID="hfDescripcion" runat="server" />
								<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSociety" Font-Bold="True"></asp:RequiredFieldValidator>--%>
							</div>
			
						<!-- end form-group row -->
				
						
				</div>
				<!-- end form-group row -->

				</div>	
			<div class="row">
				<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
					<asp:LinkButton ID="lbtnGuardar" CssClass="btn btn-success btn-sm" runat="server" OnClientClick="recuperarDescripcion()" OnClick="lbtnGuardar_Click"><i class="fa fa-plus"></i><br /> Save client </asp:LinkButton>
				<%--	
					<asp:LinkButton ID="lbtnVolver" CssClass="btn btn-secondary btn-sm" runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click"><i class="fa fa-arrow-alt-circle-left"></i><br /> Cancel </asp:LinkButton>--%>
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

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
		}
        function setearFechaSalida() {
            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
		}
        function recuperarDescripcion() {

            document.getElementById('<%=hfDescripcion.ClientID%>').value = document.getElementById('wysihtml5').value;
		}
        function setearDescripcion() {
            document.getElementById('wysihtml5').value = document.getElementById('<%=hfDescripcion.ClientID%>').value;
        }
    </script>
	<script>
        $(document).ready(function () {
            //var table = $('#data-table-default').DataTable();
            $('div.dataTables_filter input', $('#data-table-default').DataTable().table().container()).focus();
        });
    </script>
</asp:Content>
