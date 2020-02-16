<%@ Page Language="C#" Inherits="SAVSEM.Producto" MasterPageFile="~/Index.master"%>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 20px; padding: 25px; line-height: 1.75; text-align:center;}
		.imagen{width: 250px; height: 250px;}
		p{ font-weight: bold; }
		h2{font-family: sans-serif; color: grey;}
	</style>
	<div class="content">
		<h2>Producto</h2>
		<asp:Label id="tituloProducto" runat="server"/>
		<br>
		<asp:Image id="imageProducto" CssClass="imagen" runat="server"/>
		<br>
		<asp:Label Text="Precio: " runat="server"/>
		$ <asp:Label id="precioProducto" runat="server"/>
		<asp:Label id="unidadProducto" runat="server"/>
		<br>
		<asp:Label Text="Unidades disponibles: " runat="server"/>
		<asp:Label id="uDisProducto" runat="server"/>
		<br>
		<asp:Label Text="Información del producto: " runat="server"/>
		<br>
		<asp:Label id="comProducto" runat="server"/>
		<br>
		<asp:Label Text="Vendedor: " runat="server"/>
		<asp:Label id="VendedorProducto" runat="server"/>
		<br>
		<p>
			Para más información puede contactar directamente con el vendedor a la siguiente dirección
			de correo electrónico: 
		</p>
		<asp:Label id="emailProducto" runat="server"/>
		<br>
		<br>
		<h2>Configurar el pedido</h2>
		<p>
			<asp:Label Text="Unidades a comprar: " runat="server"/>
			<asp:TextBox id="txtUniCompra" TextMode="Number" OnTextChanged="txtUniCompra_TextChanged" runat="server"/>
			<asp:LinkButton id="lkbtnCalcular" Text="Calcular" OnClick="lkbtnCalcular_Click" runat="server"/>
		</p>
		<p>
			<asp:Label Text="Costo total: " runat="server"/>
			<asp:TextBox id="txtCostTotal" ReadOnly="true" runat="server"/>
		</p>
		<br>
		<asp:Label id="errorCompra" Style="color:red;" runat="server"/>
		<br>
		<asp:Button id="btnPedir" Text="Solicitar pedido" OnClick="btnPedir_Click" runat="server"/>
	</div>
</asp:Content>