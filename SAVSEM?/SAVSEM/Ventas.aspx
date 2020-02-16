<%@ Page Language="C#" Inherits="SAVSEM.Ventas" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 20px; padding: 20px; line-height: 1.75; font-weight: bold;margin-bottom: 150px; display: inline-block;}
		.content2{ line-height: 1.75; text-align: center; align-content: center;}
		.imagePreview{width: 250px; height: 250px;}
		.gvImage{width: 150px; height: 150px;}
		.errorAniadir{color:red;}
		.button{background-color: #bddf26; 
				color: white;
				width:300px;
				height:60px;
				font-family: fantasy;
				font-size: 150%

				}
		.button2{background-color: #26d2df; 
				color: white;
				width:300px;
				height:60px;
				font-family: fantasy;
				font-size: 150%
				}
		.center {
 			   display: block;
    			margin-left: auto;
    			margin-right: auto;
				}
		h1{text-align: center; font-family: fantasy;  font-weight:bold;
 			 -webkit-text-fill-color: #bddf26;
  			 -webkit-text-stroke-color: gray;
 			 -webkit-text-stroke-width: 0.75px;}
 		h2{font-family: sans-serif; color: grey;}, h3{font-family: monospace;}, span, p{text-align:left; }
 		.input1 {width: 100%;}
 		.imagen{ margin: 0px; padding: 0px; width: 100%; height: 100%; text-align: center;}
 		table {
   			width: 100%;
			}

		th {
    		height: 50px;
    		background-color: #4CAF50;
    		color: white;
    		vertical-align: bottom;
			}
		td {
    		padding: 15px;
    		text-align: left;
    		vertical-align: bottom;
			}
		tr:hover {background-color: #f5f5f5;}
		tr:nth-child(even) {background-color: #f2f2f2;}
	</style>
	<div class="content">
		<p><asp:HyperLink id="hpHome" Text="Home " NavigateUrl="Default.aspx" runat="server" /> 
		> <asp:HyperLink id="hpUsuario" Text="Usuario " NavigateUrl="GestionUsuario.aspx" runat="server" /> 
		> Publicaciones</p>
		<br>
		<h1>Vende tus Productos</h1>
		<asp:Image ImageUrl="~/img/add3.png" runat="server" class="center"/>
		<br>
		<div class="content2">
		<p><asp:Button id="btnAniadir" Text="Añadir producto para vender" OnClick="btnAniadir_Click" runat="server" class="button"/></p>
		</div>
		<asp:Panel id="panelAniadir" runat="server">

			<h2>Información del nuevo producto</h2>
			<p>
				<asp:Label Text="Nombre del producto:" runat="server"/>
				<asp:TextBox id="txtNomProd" placeholder="Ingrese el nombre del producto" AutoCompleteType="Disabled" runat="server" class="input1"/>
			 </p>
			 <p>
				<asp:Label Text="Unidades disponibles:" runat="server"/>
				<asp:TextBox id="txtUniDisp" TextMode="Number" AutoCompleteType="Disabled" runat="server" class="input1"/>
			 </p>
			 <p>
				<asp:Label Text="Tipo de unidad:" runat="server"/>
				<asp:TextBox id="txtTipUni" runat="server" class="input1"/>
			 </p>
			 <p>
				<asp:Label Text="Precio:" runat="server"/>
				<asp:TextBox id="txtPrecio" TextMode="Number" AutoCompleteType="Disabled" runat="server" class="input1"/>
			 </p>
			 <p>
				<asp:Label Text="Información del producto:" runat="server"/>
				<br>
				<asp:TextBox id="txtComenProd" TextMode="MultiLine" AutoCompleteType="Disabled" runat="server" class="input1"/>
			 </p>
			 <div class="content2">
			  <h2>Imagen del producto:</h2>
			  <asp:FileUpload id="fuImage" runat="server"/>
			  <br>
			  <asp:Button id="btnUploadImage" Text="Subir imagen" OnClick="btnUploadImage_Click" runat="server"/>
			  <br>
			  <asp:Image id="imgPreview" CssClass="imagePreview" ImageUrl="img/noimage.png" runat="server" />
			  <p>
			  	<asp:Label id="lblErrorPublicar" CssClass="errorAniadir" runat="server"/>
			  </p>
			  <p>
				<asp:Button id="btnPublicar" Text="Publicar para vender" OnClick="btnPublicar_Click" runat="server" class="button"/>
			 </p>
			 </div>
		</asp:Panel>
		<br>
		<h1>Productos en venta</h1>
		<br>
		<div style="overflow-x:auto;">
		<p>
		<asp:GridView id="tbVentas" AutoGenerateColumns="false" OnRowEditing="tbVentas_RowEditing" OnRowCancelingEdit="tbVentas_RowCancelingEdit" OnRowUpdating="tbVentas_RowUpdating" OnRowDeleting="tbVentas_RowDeleting" runat="server">
			<Columns>
				<asp:TemplateField HeaderText="ID">
					<ItemTemplate>
						<asp:Label id="gvlblID" Text='<%# Bind("ID") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Fecha de publicación">
					<ItemTemplate>
						<asp:Label id="gvlblFecha" Text='<%# Bind("Fecha") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Veces comprado">
					<ItemTemplate>
						<asp:Label id="gvlblComprado" Text='<%# Bind("VecesPedido") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Nombre">
					<EditItemTemplate>
						<asp:TextBox id="gvtxtNombre" Text='<%# Bind("Nombre") %>' runat="server" />
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label id="gvlblNombre" Text='<%# Bind("Nombre") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Precio">
					<EditItemTemplate>
						<asp:TextBox id="gvtxtPrecio" Text='<%# Bind("Precio") %>' runat="server" />
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label id="gvlblPrecio" Text='<%# Bind("Precio") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Unidad de Venta">
					<EditItemTemplate>
						<asp:TextBox id="gvtxtUVenta" Text='<%# Bind("UVenta") %>' runat="server" />
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label id="gvlblUVenta" Text='<%# Bind("UVenta") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Disponibilidad">
					<EditItemTemplate>
						<asp:TextBox id="gvtxtDisponibles" Text='<%# Bind("Disponibles") %>' runat="server" />
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label id="gvlblDisponibles" Text='<%# Bind("Disponibles") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Comentario">
					<EditItemTemplate>
						<asp:TextBox id="gvtxtComentario" TextMode="MultiLine" Text='<%# Bind("Comentario") %>' runat="server" />
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label id="gvlblComentario" Text='<%# Bind("Comentario") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Foto">
					<EditItemTemplate>
						<asp:Label id="gvlblFoto" Visible="false" Text='<%# Bind("Foto") %>' runat="server"/>
						<asp:FileUpload id="gvfuFoto" runat="server"/>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Image id="gvImage" CssClass="gvImage" ImageUrl='<%# Bind("Foto") %>' runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:CommandField ShowDeleteButton="true" ShowEditButton="true" />
			</Columns>
		</asp:GridView>
		</p>
		</div>
		 <p>
			<asp:Label id="lblErrorPrueba" CssClass="errorAniadir" runat="server"/>
		</p>
	</div>
</asp:Content>