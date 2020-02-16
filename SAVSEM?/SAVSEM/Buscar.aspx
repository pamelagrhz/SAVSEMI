<%@ Page Language="C#" Inherits="SAVSEM.Buscar" MasterPageFile="~/Index.master"%>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 20px; padding: 20px; margin-bottom: 150px; display: inline-block;}
		.gvImage{width: 100px; height: 100px;margin: 0px;padding: 0px;}
		.Tabla table {
		    border: white;
		    border-bottom-color: green;
		}
		.Tabla td {
    		text-align: center;
    		padding: 20px;
		}
		.Tabla tr:hover {background-color: #f5f5f5;}
		.link { font-weight: bold; }
		h2{font-family: sans-serif; color: grey; text-align: center;}
		.filtros{
			background-color: #e6e6e6;
			display: inline-block;
			margin: 10px;
		    padding: 10px;
		    text-align: left;
		    float: left;
		}
		.Info{
			text-align: left;
		    margin: 0px;
		    padding: 0px;
		}
		.Producto{
			font-size: x-large;
		    font-family: sans-serif;
		    font-weight: bold;
		    text-decoration: none;
		}
		.Etiqueta{
			font-size: small;
    		font-family: sans-serif;
   			font-weight: bold;
		}
		.Precio{
			font-size: large;
		}
		.Boton{
			color: white;
			background-color: #53bd53;
		    border: none;
		    padding: 10px;
		    margin: 10px;
		    font-size: small;
		    font-weight: bold;
		}
		.Boton:hover {
			background-color: #6af26a;
		}	
		.Tabla{
			display: inline-block;
    		margin: 0px;
    		position: relative;
    		padding: 10px;
		}	
		.Controles{
			width: 100%;
			margin-top: 10px;
		}
		.Botones{
			color: white;
			padding: 2px;
			width: 100%;
			margin-top: 10px;
			background-color: #53bd53;
		    border: none;
		    font-size: small;
		    font-weight: bold;
		}
		.Botones:hover{
			background-color: #53bd53;
		}
	</style>
	<div class="content">
		<p><asp:HyperLink id="hpHome" Text="Home " NavigateUrl="Default.aspx" runat="server" class="link" />> Buscar</p>
		<br>
		<h2>
			<asp:Label id="lblBusqueda" runat="server" />
		</h2>
		<div class="filtros">
			<h3>Ordenar por:</h3>
			<asp:DropDownList id="ddlOrder" CssClass="Controles" runat="server">
				<asp:ListItem Value="Ascendente">Ascendente</asp:ListItem>
				<asp:ListItem Value="Descendente">Descendente</asp:ListItem>
			</asp:DropDownList>
			<br>
			<asp:DropDownList id="ddlColumn" CssClass="Controles" runat="server">
				<asp:ListItem Value="Precio">Precio</asp:ListItem>
				<asp:ListItem Value="UnidadesDidsponibles">Disponibilidad</asp:ListItem>
				<asp:ListItem Value="Fecha">Fecha</asp:ListItem>
			</asp:DropDownList>
			<br>
			<asp:Button id="btnOrdenar" Text="Aplicar" CssClass="Botones" OnClick="btnOrdenar_Click" runat="server"/>
			<br><br>
			<h3>Filtrar por precio:</h3>
			<asp:DropDownList id="ddlOrderPrec" CssClass="Controles" runat="server">
				<asp:ListItem Value="Mayor">Mayor que</asp:ListItem>
				<asp:ListItem Value="Menor">Menor que</asp:ListItem>
			</asp:DropDownList>
			<br>
			<asp:TextBox id="txtBusPrec" CssClass="Controles" TextMode="Number" placeholder="Precio" runat="server"/>
			<br>
			<asp:Button id="txtFilPrec" Text="Aplicar" CssClass="Botones" OnClick="txtFilPrec_Click" runat="server"/>
			<br>
			<h3>Filtrar por cantidad:</h3>
			<asp:DropDownList id="ddlOrderCant" CssClass="Controles" runat="server">
				<asp:ListItem Value="Mayor">Mayor que</asp:ListItem>
				<asp:ListItem Value="Menor">Menor que</asp:ListItem>
			</asp:DropDownList>
			<br>
			<asp:TextBox id="txtBuscCant" CssClass="Controles" TextMode="Number" placeholder="Cantidad" runat="server"/>
			<br>
			<asp:Button id="txtFilCant" Text="Aplicar" CssClass="Botones" OnClick="txtFilCant_Click" runat="server"/>
			<br>
			<h3>Filtrar por vendedor:</h3>
			<asp:TextBox id="txtFilVend" CssClass="Controles" placeholder="Vendedor" runat="server"/>
			<br>
			<asp:Button id="btnFilVend" Text="Aplicar" CssClass="Botones" OnClick="btnFilVend_Click" runat="server"/>
			<br>
			<br>
			<asp:Button id="btnVerTodo" Text="Ver todo" CssClass="Botones" OnClick="btnVerTodo_Click" runat="server"/>
		</div>
		<div class="Tabla">
			<asp:GridView id="tbBusqueda" AutoGenerateColumns="false" OnRowCommand="tbBusqueda_RowCommand" runat="server">
				<Columns>
					<asp:TemplateField HeaderText="">
						<ItemTemplate>
							<asp:ImageButton id="gvImage" CssClass="gvImage" ImageUrl='<%# Bind("Imagen") %>' CommandName="VerImg" runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="">
						<ItemTemplate>
							<div class="Info">
								<asp:LinkButton id="gvlblProducto" CssClass="Producto" Text='<%# Bind("Producto") %>' CommandName="VerLnk" runat="server"/>
								<br>
								<asp:Label Text="Precio: " CssClass="Etiqueta" runat="server" />
								<asp:Label id="gvlblPrecio" CssClass="Precio" Text='<%# Bind("Precio") %>' runat="server" />
								<br>
								<asp:Label CssClass="Etiqueta" Text="Cantidad: " runat="server" />
								<asp:Label id="gvlblCantidad" CssClass="Cantidad" Text='<%# Bind("Cantidad") %>' runat="server" />
								<br>
								<asp:Label CssClass="Etiqueta" Text="Vendedor: " runat="server" />
								<asp:Label id="gvlblVendedor" CssClass="Vendedor" Text='<%# Bind("Vendedor") %>' runat="server" />
								<br>
							</div>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="">
						<ItemTemplate>
							<asp:Label id="gvlblFecha" CssClass="Fecha" Text='<%# Bind("Fecha") %>' runat="server" />
							<br>
							<asp:Button id="btnVer" CssClass="Boton" Text="Ver Semilla" CommandName="Ver" runat="server"/>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
			</asp:GridView>
		</div>
	</div>
</asp:Content>
