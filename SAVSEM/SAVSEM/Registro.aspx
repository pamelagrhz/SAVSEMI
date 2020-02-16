<%@ Page Language="C#" Inherits="SAVSEM.Registro" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
<style type="text/css">
	.content{ margin: 50px; padding: 50px; line-height: 1.75; text-align: left; }
	.content2{ line-height: 1.75; text-align: center; align-content: center;}
	h1{text-align: center; font-family: fantasy; color: #2E9AFE}
	h2{font-family: sans-serif; color: #6E6E6E; text-align:left;}
	h3{font-family: monospace; text-align:center;}
	.center {
 			   display: block;
    			margin-left: auto;
    			margin-right: auto;
				}
	.button{background-color: #00BFFF; 
				color: white;
				width:150px;
				height:60px;
				font-family: fantasy;
				font-size: 150%
				}
	.iframe {width:1000px; height:1000px;}
	.input1 {width: 100%;}
	 p{ font-weight: bold; }
</style>
<div class="content">
	<p><asp:HyperLink id="hpHome" Text="Home" NavigateUrl="Default.aspx" runat="server" /> > Registro</p>
	<div class="Formulario">
		<h1> Registro </h1>
		<asp:Image ImageUrl="~/img/register1.png" runat="server" class="center"/>
		<br>
		<h2>Nombre de usuario y contraseña</h2>
		<p>
			<asp:Label Text="Usuario: " runat="server" />
			<asp:TextBox id="txtUsuario" placeholder="" runat="server" class="input1" />
		</p>
		<p>
			<asp:Label Text="Contraseña: " runat="server" />
			<asp:TextBox id="txtContrasenia" TextMode="Password" runat="server" class="input1" />
		</p>
		<p>
			<asp:Label Text="Repetir contraseña: " runat="server" />
			<asp:TextBox id="txtContraseniaRep" TextMode="Password" runat="server" class="input1" />
		</p>
		<br>
		<h2>Datos personales</h2>
		<p>
			<asp:Label Text="Nombre: " runat="server" />
			<asp:TextBox id="txtNombre" placeholder="Ingrese su nombre" runat="server" class="input1" />
		</p>
		<p>
			<asp:Label Text="Apellidos: " runat="server" />
			<asp:TextBox id="txtApellidos" placeholder="Ingrese su apellidos" runat="server" class="input1" />
		</p>
		<br>
		<h2>Datos de contacto</h2>
		<p>
			<asp:Label Text="Dirección: " runat="server" />
			<asp:TextBox id="txtDireccion" placeholder="Dirección" runat="server" class="input1" />
			<asp:Label Text=" C.P.: " runat="server"  />
			<asp:TextBox id="txtCP" placeholder="Código Postal" runat="server"  class="input1"/>
		</p>
		<p>
			<asp:Label Text="Teléfono: " runat="server" />
			<asp:TextBox id="txtTelefono" placeholder="(00) 00-00-00-00" TextMode="Phone" runat="server" class="input1"/>
			<asp:Label Text=" Correo electrónico: " runat="server" />
			<asp:TextBox id="txtCorreo" placeholder="user@domain.com" TextMode="Email" runat="server" class="input1" />
		</p>

		<div class="content2">
		<br>
		<h3>Terminos y condiciones</h3>
		<p>
			<iframe runat="server" id="myPDF" src="docs/LicenciaUsoComprador.pdf" class="iframe" ></iframe> 
		</p>
		<p>
			<asp:CheckBox id="cbxAceptar" Text="Acepto los términos y condiciones." runat="server"/>
		</p>
		<p>
			<asp:Label id="lbCondicion" runat="server" Style="color:red;"/>
		</p>
		<br>
		<p>
			<asp:Button id="btnRegistrar" Text="Registrarme" type="submit" OnClick="btnRegistrar_Click" runat="server" class="button" />
		</p>
		</div>

	</div>
</div>
</asp:Content>
