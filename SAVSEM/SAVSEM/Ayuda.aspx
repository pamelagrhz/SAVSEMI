<%@ Page Language="C#" Inherits="SAVSEM.Ayuda" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{ margin: 50px; padding: 50px; line-height: 1.75; }
		.content2{ line-height: 1.75; text-align: center; }
		h1{text-align: center; font-family: fantasy; color: #DF7401;}
		h2{font-family: sans-serif; color: grey;}, h3{font-family: monospace;}, span, p{text-align:left; }
		.userSession input[type=text] {width: 80%;}
		.Mensaje{width: 80%; height: 100px;}
		.botonEnviar{text-align: right;}
		.messageError{color: red;}
		.center {
 			   display: block;
    			margin-left: auto;
    			margin-right: auto;

				}
		.button{background-color: #DF7401;; 
				color: white;
				width:150px;
				height:60px;
				font-family: fantasy;
				font-size: 150%
				}
		.link { font-weight: bold; }
	</style>
	<div class="content">
		<p class="link"><asp:HyperLink id="hpHome" Text="Home" NavigateUrl="Default.aspx" runat="server" /> > Ayuda</p>
		<h1>Preguntas Frecuentes</h1>
		<asp:Image ImageUrl="~/img/question1.png" runat="server" class="center" />
		<br>
		<h2>¿Qué es SAVSEMI?</h2>
		<span>SAVSEMI es un sistema de venta y compra de semillas.</span>
		<br><br>
		<h2>¿A quién va dirigido?</h2>
		<span>A todo el público agricultor, especialmente a los agricultores de la zona de Juchitepec.</span>
		<br><br>
		<h2>¿Cómo puedo realizar una compra?</h2>
		<span>Para realizar una compra es necesario que cuentes con una cuenta de usuario. Posteriormente
		podras dar clic al producto que te interese comprar, configurar la cantidad de producto que requieres,
		y le das en comprar. Finalmente el productor se pondrá en contacto con usted para acordar la dirección de entrega.</span>
		<br><br>
		<h2>¿Cómo puedo realizar una cuenta de usuario?</h2>
		<span>¡Fácil!. Solo tienes que darle clic en el lado superiro derecho donde dice "Registrar Aquí" y llenar el formulario.
		La creación de una cuenta de Usuario no generará costo alguno.</span>
		<br><br>
		<h2>¿Cómo puedo vender mis propios productos?</h2>
		<span>Para ello debes de contar con un plan de venta, las cuales se muestran en la sección de ¿Cómo puedo vender mis productos?
		donde además encontrarás más información.</span>
		<br><br>
		<div class="content2">
			<h3>¿No encontró la mejor ayuda a su problema?</h3>
			<span>Mandenos un mensaje por este medio, solo llene sus datos y envienos su pregunta.
			Nosotros nos aseguramos de que su problema sea atendido lo más pronto posible.</span>
			<br><br>
			<asp:Panel id="userSession" CssClass="userSession" runat="server">
				<asp:Label Text="Correo: "  runat="server"/> 
				<asp:TextBox id="txtAyTexto"  placeholder="sucorreo@dominio.com.mx" TextMode="Email" runat="server" maxlength="50" size="50" />
			</asp:Panel> 
			<p>
				<asp:TextBox id="txtAyMensaje" placeholder="Escriba su mensaje." AutoCompleteType="Disabled" CssClass="Mensaje" TextMode="MultiLine" runat="server"/>
				<br>
				<asp:Button id="btnAyEnviar" Text="Enviar" OnClick="btnAyEnviar_Click" class="button" runat="server"/>
			</p>
			<asp:Label id="messageError" CssClass="messageError" runat="server"/>
		</div>
	</div>
</asp:Content>
