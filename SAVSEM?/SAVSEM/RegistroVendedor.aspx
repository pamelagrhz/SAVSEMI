<%@ Page Language="C#" Inherits="SAVSEM.RegistroVendedor" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 50px; padding: 50px; line-height: 1.75;margin-bottom: 150px; display: inline-block;}
		.content2{ line-height: 1.75; text-align: center; }
		.etiqueta{font-weight: bold;}
		h1{text-align: center; font-family: fantasy; color: #DBA901;}
		h2{font-family: sans-serif; color: grey;}, h3{font-family: monospace;}, span, p{text-align:left; }
		h3{font-family: monospace; text-align:center;}
		.center {
 			   display: block;
    			margin-left: auto;
    			margin-right: auto;

				}
		.button{background-color: #DBA901; 
				color: white;
				width:300px;
				height:60px;
				font-family: fantasy;
				font-size: 150%
				}
		.iframe {width:1000px; height:1000px;}
		.input1 {width: 100%;}
		.link { font-weight: bold; }
	</style>
	<div class="content">
		<p><asp:HyperLink id="hpHome" Text="Home" NavigateUrl="Default.aspx" runat="server" class="link"/> > Proveedor</p>
		<h1>Registrate como Vendedor</h1>
		<asp:Image ImageUrl="~/img/productor1.png" runat="server" class="center"/>
		<br>
		<p><span>Sabemos que es muy complicado realizar acuerdos con personas que se encuentran
		lejos de usted, y más aún esperar a la temporada de semillas. Por ello usted puede
		avisar a la comunidad de que cuenta con el producto en este mismo instante sólo publicando
		el tipo de semilla y la cantidad que usted posee. El sistema le permitirá obtener los datos
		de contacto con el cliente para que usted pueda acordar tiempo y cantidad en la venta.</span></p>
		<br>
		<asp:Panel id="sessionNoStart" CssClass="sessionNoStart" runat="server">
			<h2>Ingresa tu cuenta</h2>
			<p><span>Necesitas contar con una cuenta de usuario para utilizar este servicio.</span></p>
			<p>
				<asp:Label Text="Usuario: " CssClass="etiqueta" runat="server"/>
				<asp:TextBox id="txtRegUser" runat="server" class="input1" />
			</p>
			<p>
				<asp:Label Text="Contraseña: " CssClass="etiqueta" runat="server"/>
				<asp:TextBox id="txtRegPass" type="password" runat="server" class="input1" />
			</p>
			<p>
				¿No tienes usuario? <asp:HyperLink id="linkRegistro" NavigateUrl="Registro.aspx" Text="Registrate aquí" CssClass="registroRegistro" runat="server"/>
			</p>
		</asp:Panel>
		<br>
		<br>
		<div class="content2">
		<h3>Términos y condiciones</h3>
		<p>
			<iframe runat="server" id="myPDF" src="docs/LicenciaUsoProductor.pdf" class="iframe"></iframe> 
		</p>
		<p>
			<asp:CheckBox id="cbxAceptar" Text="Acepto los términos y condiciones." runat="server"/>
		</p>
		<p>
			<asp:Label id="lbCondicion" runat="server" Style="color:red;"/>
		</p>
		<br>
		<p>
			<asp:Button id="btnRegReg" Text="Registrarse como vendedor" OnClick="btnRegReg_Click" runat="server" class="button"/>
		</p>
		</div>
	</div>
</asp:Content>