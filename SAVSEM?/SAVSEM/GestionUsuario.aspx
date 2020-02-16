<%@ Page Language="C#" Inherits="SAVSEM.GestionUsuario" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{ margin: 20px; padding: 20px; line-height: 1.75; text-align: left; font-weight: bold;margin-bottom: 150px; display: inline-block;}
		.content2{ line-height: 1.75; text-align: center; align-content: center;}
		h1{text-align: center; font-family: fantasy;  font-weight:bold;
 			 -webkit-text-fill-color: #9CFDFF;
  			 -webkit-text-stroke-color: black;
 			 -webkit-text-stroke-width: 0.75px;}
		h2{font-family: sans-serif; color: #6E6E6E; text-align:left;}
		.center {
 			   display: block;
    			margin-left: auto;
    			margin-right: auto;
				}
		.link { font-weight: bold; }
		.Tabla {
   			display: inline-block;
		    margin: 0px;
		    padding: 0px;
		    float: left;
		    position: absolute;
			}
		td {
    		padding: 15px;
    		text-align: left;
			}
		tr:hover {background-color: #f5f5f5;}
		tr:nth-child(even) {background-color: #f2f2f2; font-weight: normal;}
		tr:nth-child(1){
			font-weight: bold;
			height: 50px;
			background-color: #4CAF50;
    		color: white;
       		vertical-align: bottom;
       		padding: 15px;
    		text-align: center;
		}
		tr{
			font-weight: normal;
		}
		.UsuarioDatos{
			color: black;
			background-color: #f2f2f2;;
		    display: inline-block;
		    padding: 20px;
		    border-radius: 10px;
		    margin: 10px;
		    font-weight: normal;
		}
		.Etiqueta{
			font-weight: bold;
		}
	</style>
	<div class="content">
		<p class="link"><asp:HyperLink id="hpHome" Text="Home " NavigateUrl="Default.aspx" runat="server" />> Usuario</p>
		<br>
		<h1>Administra tus datos </h1>
		<!--	<asp:Image ImageUrl="~/img/edit1.png" runat="server" class="center"/> -->
		<br>
		<div class="UsuarioDatos">
			<h2>Información de la cuenta</h2>
			<p>
				<asp:Label id="errorUserGes" Style="color:red;" runat="server"/>
			</p>
			<p>
				<asp:Label Text="Usuario: " CssClass="Etiqueta" runat="server"/>
				<asp:Label id="lblGesUser" runat="server"/>
				<asp:LinkButton id="lkbtnGesUser" Text="Editar" OnClick="lkbtnGesUser_Click" runat="server"/>
				<br><asp:Label id="lblGesUsuarioMod" CssClass="Etiqueta"  Text="Nuevo nombre de usuario: " runat="server"/>
				<asp:TextBox id="txtGesUser" runat="server"/>
				<asp:LinkButton id="lkbtnGesUserConfirm" Text="Modificar" OnClick="lkbtnGesUserConfirm_Click" runat="server"/>
			</p>
			<p>
				<asp:Label Text="Contraseña" CssClass="Etiqueta"  runat="server"/>
				<asp:LinkButton id="lkbtnGesPass" Text="Editar" OnClick="lkbtnGesPass_Click" runat="server"/>
				<br><asp:Label id="lblGesOldPassMod" CssClass="Etiqueta"  Text="Contraseña anterior: " runat="server"/>
				<asp:TextBox id="txtGesOldPass" TextMode="Password" runat="server"/>
				<br><asp:Label id="lblGesPassMod" CssClass="Etiqueta"  Text="Nuevo Contraseña: " runat="server"/>
				<asp:TextBox id="txtGesPass" TextMode="Password" runat="server"/>
				<br><asp:Label id="lblGesPassConfMod" CssClass="Etiqueta"  Text="Confirmar nueva contraseña: " runat="server"/>
				<asp:TextBox id="txtGesPassConfirm" TextMode="Password" runat="server"/>
				<asp:LinkButton id="lkbtnGesPassConfirm" Text="Modificar" OnClick="lkbtnGesPassConfirm_Click" runat="server"/>
			</p>

			<h2>Información del usuario</h2>
			<p>
				<asp:Label Text="Nombre: " CssClass="Etiqueta"  runat="server"/>
				<asp:Label id="lblGesNombre" runat="server"/>
				<asp:LinkButton id="lkbtnGesNombre" Text="Editar" OnClick="lkbtnGesNombre_Click" runat="server"/>
				<br><asp:Label id="lblGesNombreMod" CssClass="Etiqueta"  Text="Modificar nombre: " runat="server"/>
				<asp:TextBox id="txtGesNombre" runat="server"/>
				<asp:LinkButton id="lkbtnGesNombreConfirm" Text="Modificar" OnClick="lkbtnGesNombreConfirm_Click" runat="server"/>
			</p>
			<p>
				<asp:Label Text="Apellidos: " CssClass="Etiqueta"  runat="server"/>
				<asp:Label id="lblGesApellido" runat="server"/>
				<asp:LinkButton id="lkbtnGesApellido" Text="Editar" OnClick="lkbtnGesApellido_Click" runat="server"/>
				<br><asp:Label id="lblGesApellidoMod" CssClass="Etiqueta"  Text="Modificar apellido: " runat="server"/>
				<asp:TextBox id="txtGesApellido" runat="server"/>
				<asp:LinkButton id="lkbtnGesApellidoConfirm" Text="Modificar" OnClick="lkbtnGesApellidoConfirm_Click" runat="server"/>
			</p>
			<p>
				<asp:Label Text="Dirección: " CssClass="Etiqueta"  runat="server"/>
				<asp:Label id="lblGesDireccion" runat="server"/>
				<asp:LinkButton id="lkbtnGesDireccion" Text="Editar" OnClick="lkbtnGesDireccion_Click" runat="server"/>
				<br><asp:Label id="lblGesDireccionMod" CssClass="Etiqueta"  Text="Nueva dirección: " runat="server"/>
				<asp:TextBox id="txtGesDireccion" runat="server"/>
				<asp:LinkButton id="lkbtnGesDireccionConfirm" Text="Modificar" OnClick="lkbtnGesDireccionConfirm_Click" runat="server"/>
			</p>
			<p>
				<asp:Label Text="Código Postal: " CssClass="Etiqueta"  runat="server"/>
				<asp:Label id="lblGesCP" runat="server"/>
				<asp:LinkButton id="lkbtnGesCP" Text="Editar" OnClick="lkbtnGesCP_Click" runat="server"/>
				<br>
				<asp:Label id="lblGesCPMod" CssClass="Etiqueta"  Text="Nuevo código postal: " runat="server"/>
				<asp:TextBox id="txtGesCP" runat="server"/>
				<asp:LinkButton id="lkbtnGesCPConfirm" Text="Modificar" OnClick="lkbtnGesCPConfirm_Click" runat="server"/>
			</p>
			<p>
				<asp:Label Text="Teléfono: " CssClass="Etiqueta"  runat="server"/>
				<asp:Label id="lblGesTelefono" runat="server"/>
				<asp:LinkButton id="lkbtnGesTelefono" Text="Editar" OnClick="lkbtnGesTelefono_Click" runat="server"/>
				<br><asp:Label id="lblGesTelefonoMod" CssClass="Etiqueta"  Text="Nuevo teléfono: " runat="server"/>
				<asp:TextBox id="txtGesTelefono" TextMode="Phone" runat="server"/>
				<asp:LinkButton id="lkbtnGesTelefonoConfirm" Text="Modificar" OnClick="lkbtnGesTelefonoConfirm_Click" runat="server"/>
			</p>
			<p>
				<asp:Label Text="Correo: " CssClass="Etiqueta"  runat="server"/>
				<asp:Label id="lblGesCorreo" runat="server"/>
				<asp:LinkButton id="lkbtnGesCorreo" Text="Editar" OnClick="lkbtnGesCorreo_Click" runat="server"/>
				<br><asp:Label id="lblGesCorreoMod" CssClass="Etiqueta"  Text="Nuevo correo: " runat="server"/>
				<asp:TextBox id="txtGesCorreo" TextMode="Email" runat="server"/>
				<asp:LinkButton id="lkbtnGesCorreoConfirm" Text="Modificar" OnClick="lkbtnGesCorreoConfirm_Click" runat="server"/>
			</p>
			<br>
		</div>
		<asp:DataGrid id="tbHistorial" CssClass="Tabla" AutoGenerateColumns="true" runat="server">
		</asp:DataGrid>

	</div>
</asp:Content>