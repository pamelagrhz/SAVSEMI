<%@ Page Language="C#" Inherits="SAVSEM.Administrador" MasterPageFile="~/Index.master"%>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 20px; padding: 20px; line-height: 1.75;margin-bottom: 150px; display: inline-block;}
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
		> Administración</p>
		<h2>Administración de Usuarios</h2>
		<asp:LinkButton id="lkbtnMosAUs" Text="Mostrar" OnClick="lkbtnMosAUs_Click" runat="server"/>
		<br>
		<asp:DataGrid id="tbUsers" AutoGenerateColumns="true" OnItemCommand="tbUsers_ItemCommand" runat="server">
			<Columns>
				<asp:ButtonColumn HeaderText="" ButtonType="LinkButton" Text="Eliminar Usuario" CommandName="btnEliminarUs"/>
			</Columns>
		</asp:DataGrid>
		<h2>Administración de Productos</h2>
		<asp:LinkButton id="lkbtnMosAPe" Text="Mostrar" OnClick="lkbtnMosAPe_Click" runat="server"/>
		<br>
		<asp:DataGrid id="tbProductos" AutoGenerateColumns="true" OnItemCommand="tbProductos_ItemCommand" runat="server">
			<Columns>
				<asp:ButtonColumn HeaderText="" ButtonType="LinkButton" Text="Eliminar producto" CommandName="btnCancelarP"/>
			</Columns>
		</asp:DataGrid>
		<h2>Mensajes de ayuda</h2>
		<asp:LinkButton id="lkbtnMosAMa" Text="Mostrar" OnClick="lkbtnMosAMa_Click" runat="server"/>
		<asp:DataGrid id="tbMensajes" AutoGenerateColumns="true" runat="server">
		</asp:DataGrid>
		<br>
	</div>
</asp:Content>