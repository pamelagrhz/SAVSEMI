<%@ Page Language="C#" Inherits="SAVSEM.Buscar" MasterPageFile="~/Index.master"%>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 20px; padding: 20px;}
		.gvImage{width: 100px; height: 100px;}
		table {
   			width: 100%;
			}

		th {
    		height: 50px;
    		background-color: #4CAF50;
    		color: white;

			}
		td {
    		padding: 15px;
    		text-align: left;

			}
		tr:hover {background-color: #f5f5f5;}
		tr:nth-child(even) {background-color: #f2f2f2;}
		.link { font-weight: bold; }
		h2{font-family: sans-serif; color: grey; text-align: center;}
	</style>
	<div class="content">
		<p><asp:HyperLink id="hpHome" Text="Home " NavigateUrl="Default.aspx" runat="server" class="link" />> Buscar</p>
		<br>
		<h2>
			<asp:Label id="lblBusqueda" runat="server" />
		</h2>
		<p>
			<asp:GridView id="tbBusqueda" AutoGenerateColumns="false" OnRowCommand="tbBusqueda_RowCommand" runat="server">
				<Columns>
					<asp:TemplateField HeaderText="Imagen">
						<ItemTemplate>
						<asp:ImageButton id="gvImage" CssClass="gvImage" ImageUrl='<%# Bind("Imagen") %>' CommandName="VerImg" runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Producto">
						<ItemTemplate>
							<asp:LinkButton id="gvlblProducto" Text='<%# Bind("Producto") %>' CommandName="VerLnk" runat="server"/>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Cantidad">
						<ItemTemplate>
							<asp:Label id="gvlblCantidad" Text='<%# Bind("Cantidad") %>' runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Precio">
						<ItemTemplate>
							<asp:Label id="gvlblPrecio" Text='<%# Bind("Precio") %>' runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Fecha de publicación">
						<ItemTemplate>
							<asp:Label id="gvlblFecha" Text='<%# Bind("Fecha") %>' runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Vendedor">
						<ItemTemplate>
							<asp:Label id="gvlblVendedor" Text='<%# Bind("Vendedor") %>' runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="">
						<ItemTemplate>
							<asp:Button id="btnVer" Text="Ver Semilla" CommandName="Ver" runat="server"/>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
			</asp:GridView>
		</p>
	</div>
</asp:Content>
