<%@ Page Language="C#" Inherits="SAVSEM.Compras" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 20px; padding: 20px; line-height: 1.75;}
		.link { font-weight: bold; }
		h2{font-family: sans-serif; color: grey; text-align: center;}, h3{font-family: monospace;} 
		table {
   			width: 100%;
			}
		td {
    		padding: 15px;
    		text-align: left;
			}
		tr:hover {background-color: #f5f5f5;}
		tr:nth-child(even) {background-color: #f2f2f2;}
		tr:nth-child(1){
			height: 50px;
			background-color: #4CAF50;
    		color: white;
       		vertical-align: bottom;
       		padding: 15px;
    		text-align: center;
		}
	</style>
	<div class="content">
		<p class="link"><asp:HyperLink id="hpHome" Text="Home " NavigateUrl="Default.aspx" runat="server" /> 
		> <asp:HyperLink id="hpUsuario" Text="Usuario " NavigateUrl="GestionUsuario.aspx" runat="server" /> 
		> Pedidos</p>
		<br>
		<asp:Panel id="productorModo" runat="server">
			<h2>Pedidos recibidos</h2>
			<asp:LinkButton id="lkbtnMosRec" Text="Mostrar" OnClick="lkbtnMosRec_Click" runat="server"/>
			<br>
			<asp:DataGrid id="tbRecibidos" AutoGenerateColumns="true" OnItemCommand="tbRecibidos_ItemCommand" runat="server">
			<Columns>
				<asp:ButtonColumn HeaderText="" ButtonType="LinkButton" Text="Cancelar pedido" CommandName="btnCancelarPR"/>
			</Columns>
		</asp:DataGrid>
		</asp:Panel>
		<br>
		<br>
		<h2>Pedidos realizados</h2>
		<asp:LinkButton id="lkbtnMosRea" Text="Mostrar" OnClick="lkbtnMosRea_Click" runat="server"/>
		<br>
		<asp:DataGrid id="tbRealizados" AutoGenerateColumns="true" OnItemCommand="tbRealizados_ItemCommand" runat="server">
			<Columns>
				<asp:ButtonColumn HeaderText="" ButtonType="LinkButton" Text="Cancelar pedido" CommandName="btnCancelarP"/>
			</Columns>
		</asp:DataGrid>
		<asp:Label id="indicador" Style="color:red;" runat="server"/>
	</div>
</asp:Content>