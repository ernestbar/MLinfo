<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="vuelos.aspx.cs" Inherits="appAmascuotas.vuelos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="odsTipoCliente" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="EXPEDIDO" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsRuta" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="RUTA" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoRuta" runat="server" SelectMethod="Lista" TypeName="appAmascuotas.dominio">
        <SelectParameters>
            <asp:Parameter DefaultValue="TIPO RUTA" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<div id="content" class="content">
		<h1 class="page-header">Disponibilidad de vuelos Amaszonas <small></small></h1>
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
				<h4 class="panel-title">Elija su vuelo</h4>
			</div>
			</div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Adultos:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtAdultos" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ControlToValidate="txtAdultos" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Infante:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtInfante" style="text-transform:uppercase" class="form-control" runat="server"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Ruta</label>
						<div class="col-md-6">
							<div class="row row-space-6">
								<div class="col-4">
                                    <asp:DropDownList ID="ddlRuta1" DataSourceID="odsRuta" DataTextField="descripcion" DataValueField="codigo"  class="form-control" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="ddlRuta1" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
								</div>
								<div class="col-4">
									<asp:DropDownList ID="ddlRuta2" DataSourceID="odsRuta" DataTextField="descripcion" DataValueField="codigo"  class="form-control" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddlRuta2" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
								</div>
							</div>
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Fecha de vuelo:</label>
					<div class="col-md-6">
						<div class="row row-space-6">
						<div class="col-4">
                                <asp:DropDownList ID="ddlDia" class="form-control" runat="server"></asp:DropDownList>
							</div>
							<div class="col-4">
								<asp:DropDownList ID="ddlMes" class="form-control" runat="server"></asp:DropDownList>
							</div>
							<div class="col-4">
								<asp:DropDownList ID="ddlAño" class="form-control" runat="server"></asp:DropDownList>
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
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="rblTipoRuta" runat="server" InitialValue="" ErrorMessage="*"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
				<div class="btn-toolbar mr-2 sw-btn-group float-left" role="group">
				<asp:Button ID="btnConsultar" CssClass="btn btn-success" runat="server" CausesValidation="false" OnClick="btnConsultar_Click" Text="CONSULTAR" />
			</div>
            </asp:View>
            <asp:View ID="View2" runat="server">
				<!-- begin #accordion -->
				<div id="accordion" class="card-accordion">
					<asp:Repeater ID="Repeater1" DataSourceID="odsTipoCliente" runat="server">
					<ItemTemplate>
						<!-- begin card -->
						<div class="card">
							<div class="card-header bg-black text-white pointer-cursor collapsed" data-toggle="collapse" data-target='#<%# Eval("VALOR_CARACTER") %>'>
								Vuelo disponible de:<asp:Label ID="Label1" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
							</div>
							<div id='<%# Eval("VALOR_CARACTER") %>' class="collapse" data-parent="#accordion">
								<div class="card-body">
									Aqui vendria los otros item que se ve en la pantalla que muestran en el video.
									Utilice un repeater con el dominio de EXPEDIDO
								</div>
							</div>
						</div>
						<!-- end card -->
					</ItemTemplate>
					</asp:Repeater>
				</div>			
            </asp:View>
        </asp:MultiView>
        
						
    </div>
</asp:Content>
