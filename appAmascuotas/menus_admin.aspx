<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="menus_admin.aspx.cs" Inherits="appAmascuotas.menus_admin" %>
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
	<asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_SEG_GET_MENUS" TypeName="appAmascuotas.Clases.Menus">
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
			<asp:Label ID="lblCodMenu" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
            <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-success btn-sm" OnClick="btnNuevo_Click" runat="server" Text="New Menu" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Menu Admin<small></small></h1>
										
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
												<table id="tabla1" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">CODE</th>
															<th class="text-nowrap">COD_MENU_FATHER</th>
																<th class="text-nowrap">ORDER</th>
																<th class="text-nowrap">DESCRIPTION</th>
																<th class="text-nowrap">DETAIL</th>
																<th class="text-nowrap">STATE</th>
															<th class="text-nowrap" data-orderable="false">OPTIONS</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsMenus" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("COD_MENU") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("COD_MENU_PADRE") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("LEVEL") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("DETALLE") %>'></asp:Label></td>
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_MENU") %>' OnClick="btnEditar_Click" runat="server" Text="Edit" ToolTip="Edit" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("COD_MENU") +"|" +Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click"  runat="server" Text="Activate/Descativate" ToolTip="Activate or descativate register" />
                                                                
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
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Data Menu</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Is father menu?</label>
						<div class="col-md-6">
                             <asp:DropDownList ID="ddlMenuPadre" class="form-control col-md-6" DataSourceID="odsMenus" DataTextField="descripcion" DataValueField="cod_menu" OnDataBound="ddlMenuPadre_DataBound" runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<%--<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Orden:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtOrden" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtOrden" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>--%>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Description:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtDescripcion" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDescripcion" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Details:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtDetalle" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDetalle" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" OnClick="btnGuardar_Click" Text="Save" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancel" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
			</asp:View>
		</asp:MultiView>
	
			
		</div>
		<!-- end #content -->
</asp:Content>
