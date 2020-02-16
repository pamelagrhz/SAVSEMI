<%@ Page Language="C#" Inherits="SAVSEM.RegistroExitoso" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 20px; padding: 20px; line-height: 1.75; text-align: center; margin-bottom: 150px; display: inline-block;}
		.etiqueta{font-weight: bold;}
		h1 {
    		color: #00FF40; 
    		font-family: fantasy;}
    	.center {
 			   display: block;
    			margin-left: auto;
    			margin-right: auto;
				}
		.link { font-weight: bold; }
	</style>
	<div class="content">
		<h1> ¡El usuario ha sido registrado con éxito!</h1>
		<asp:Image ImageUrl="~/img/success1.png" runat="server" class="center"/>
		<br>
		<span>
		Ahora puede disfrutar de los servicios que ofrece su cuenta de usuario.
		</span>
		<p class="link">
		<asp:HyperLink id="linkInicio" NavigateUrl="Default.aspx" Text="Presiona para Continuar" runat="server" />
		</p>
		<!--
		Aquí va tutorial de como administrar la cuenta, y como contactar al vendedor.
		-->
	</div>
</asp:Content>