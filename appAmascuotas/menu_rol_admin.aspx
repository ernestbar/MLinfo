<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="menu_rol_admin.aspx.cs" Inherits="appAmascuotas.menu_rol_admin" %>
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
	<asp:ObjectDataSource ID="odsRolesActivos" runat="server" SelectMethod="PR_GET_ROLES" TypeName="appAmascuotas.Clases.Roles">
		<SelectParameters>
				<asp:Parameter DefaultValue="A" Name="PV_ESTADO" Type="String" />
			</SelectParameters>
    </asp:ObjectDataSource>
	
	<asp:ObjectDataSource ID="odsMenusNoAsignado" runat="server" SelectMethod="PR_SEG_GET_MENUS_A_ASIGNAR" TypeName="appAmascuotas.Clases.Menus_roles">
		<SelectParameters>
			<asp:ControlParameter ControlID="ddlRol" Name="PB_ROL_ID_ROL" Type="String" />
        </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsMenusAsignado" runat="server" SelectMethod="PR_SEG_GET_MENUS_ASIGNADOS" TypeName="appAmascuotas.Clases.Menus_roles">
		<SelectParameters>
			<asp:ControlParameter ControlID="ddlRol" Name="PB_ROL_ID_ROL" Type="String" />
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
			<asp:Label ID="lblCodMenu" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
            <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                               
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Assign menus to roles <small></small></h1>
											Role:
											<asp:DropDownList ID="ddlRol" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged"  DataSourceID="odsRolesActivos" DataTextField="DESCRIPCION" DataValueField="ROL" OnDataBound="ddlRol_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlRol" InitialValue="SELECT"  Font-Bold="True"></asp:RequiredFieldValidator>	
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
															<th class="text-wrap">MENU ASSIGN</th>
															<th class="text-nowrap">MENU UN ASSING</th>
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>
																<table id="asignados">
																	<tr>
																		
																		<td>
																			MENU
																		</td>
																		<td>
																			OPTIONS
																		</td>
																	</tr>
																	 <asp:Repeater ID="Repeater1" DataSourceID="odsMenusAsignado" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
																		<ItemTemplate>
																			<tr class="gradeA">
																			
																				<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																				<td>
																					<asp:Button ID="btnQuitar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("ROL_MENU")+ "|" + Eval("COD_MENU") %>' OnClick="btnQuitar_Click" runat="server" Text="DELETE" ToolTip="DELETE MENU ASSIGN" />
																				</td>
																			</tr>
																		</ItemTemplate>
																	</asp:Repeater>
																</table>
															</td>
															<td>
																<table id="noasignados">
																	<tr>
																		
																		<td>
																			MENU
																		</td>
																		<td>
																			OPTIONS
																		</td>
																	</tr>
																	 <asp:Repeater ID="Repeater2" DataSourceID="odsMenusNoAsignado" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
																		<ItemTemplate>
																			<tr class="gradeA">
																				
																				<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																				<td>
																					<asp:Button ID="btnAgregar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_MENU") %>' OnClick="btnAgregar_Click" runat="server" Text="ADD" ToolTip="ADD MENU" />
																				</td>
																			</tr>
																		</ItemTemplate>
																	</asp:Repeater>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
        
	
			
		</div>
		<!-- end #content -->
</asp:Content>
