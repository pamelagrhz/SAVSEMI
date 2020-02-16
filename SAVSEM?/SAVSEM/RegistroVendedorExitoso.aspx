<%@ Page Language="C#" Inherits="SAVSEM.RegistroVendedorExitoso" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 20px; padding: 20px; line-height: 1.75; text-align: center; margin-bottom: 150px; display: inline-block;}
		.etiqueta{font-weight: bold;}
		h1 {
    		color: #DBA901; 
    		font-family: fantasy;}
		.center {
 			   display: block;
    			margin-left: auto;
    			margin-right: auto;
				}
		.link { font-weight: bold; }
	</style>
	<div class="content">
		<h1>¡¡¡Felicidades ahora eres un vendedor!!!!</h1>
		<asp:Image ImageUrl="~/img/success2.png" runat="server" class="center"/>
		<span>
		Comienza a enlazar a tus clientes.
		<br>
		Ahora no tendrás que salir a buscar clientes, ni los clientes vendrán de vez en cuando a preguntar
		a tu casa si ya tienes algo de semillas...
		</span>
		<p class="link">
		<asp:HyperLink id="linkInicio" NavigateUrl="Default.aspx" Text="Presiona para Continuar" runat="server" />
		</p>
		<!--
		Aquí va un tutorial de como publicar productos, contactar a los clientes y administrar la cuenta de vendedor.
		-->
	</div>
</asp:Content>