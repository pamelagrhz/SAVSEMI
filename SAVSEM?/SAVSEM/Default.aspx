<%@ Page Language="C#" Inherits="SAVSEM.Default" MasterPageFile="~/Index.master" %>
<asp:Content id="Content1" ContentPlaceHolderID="cl" runat="server">
	<style type="text/css">
		.content{margin: 50px; padding: 50px; line-height: 1.75; text-align: center; align-content: center;margin-bottom: 150px; display: inline-block;}
		h2{font-family: sans-serif; color: #6E6E6E; text-align:center;}
		.imagenProductos{width: 250px; height: 250px;}
		.slider {
				width:1200px;
				height:500px;
				margin: auto;
				overflow: hidden;
				}

		.slider ul {
					display: flex;
					padding: 0;
					width: 400%;
					animation: cambio 15s infinite alternate linear;
					}
		.slider li {
					width: 100%;
					list-style: none;
					}

		.slider img {
					width: 100%;
					}

		@keyframes cambio {
					0% {margin-left: 0;}
					20% {margin-left: 0;}
	
					25% {margin-left: -100%;}
					45% {margin-left: -100%;}
	
					50% {margin-left: -200%;}
					70% {margin-left: -200%;}
	
					75% {margin-left: -300%;}
					100% {margin-left: -300%;}
					}
		.ultAgregados{
			display: inline-block;
		}

		.Productos{
			margin: 2px;
			padding 0px;
			float: left;
		}

		.Productos a{
			color: black;
		    font-size: unset;
		    font-family: sans-serif;
		    text-decoration: none;
		    text-align: center;
		    font-weight: bold;
		    display: inline-block;
		}

		.Productos span{
			color: black;
		    text-align: center;
		    font-size: x-large;
		    font-weight: bolder;
		    display: contents;
		}

		.masVendidos{
			display: inline-block;
			margin-top: 50px;
		}


	</style>
	<div class="slider">
		<ul>
			<li>
  				<img src="~/img/carrousel/ca1.png" alt="">
 			</li>
			<li>
  				<img src="~/img/carrousel/ca2.png" alt="">
			</li>
			<li>
  				<img src="~/img/carrousel/ca3.png" alt="">
			</li>
			<li>
  				<img src="~/img/carrousel/ca4.png" alt="">
			</li>
		</ul>
	</div>
	<div class="content">
		<div class="ultAgregados">
			<h2>Ultimos agregados</h2>
			<br>
			<asp:Panel id="producto1" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto1" CssClass="imagenProductos" OnClick="imgProducto1_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto1" OnClick="lkbtnProducto1_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto1" runat="server"/>
			</asp:Panel>
			<asp:Panel id="producto2" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto2" CssClass="imagenProductos" OnClick="imgProducto2_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto2" OnClick="lkbtnProducto2_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto2" runat="server"/>
			</asp:Panel>
			<asp:Panel id="producto3" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto3" CssClass="imagenProductos" OnClick="imgProducto3_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto3" OnClick="lkbtnProducto3_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto3" runat="server"/>
			</asp:Panel>
			<asp:Panel id="producto4" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto4" CssClass="imagenProductos" OnClick="imgProducto4_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto4" OnClick="lkbtnProducto4_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto4" runat="server"/>
			</asp:Panel>
			<asp:Panel id="producto5" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto5" CssClass="imagenProductos" OnClick="imgProducto5_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto5" OnClick="lkbtnProducto5_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto5" runat="server"/>
			</asp:Panel>
		</div>
		<br>
		<div class="masVendidos">
			<h2>Los más vendidos</h2>
			<br>
			<asp:Panel id="producto6" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto6" CssClass="imagenProductos" OnClick="imgProducto6_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto6" OnClick="lkbtnProducto6_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto6" runat="server"/>
			</asp:Panel>
			<asp:Panel id="producto7" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto7" CssClass="imagenProductos" OnClick="imgProducto7_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto7" OnClick="lkbtnProducto7_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto7" runat="server"/>
			</asp:Panel>
			<asp:Panel id="producto8" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto8" CssClass="imagenProductos" OnClick="imgProducto8_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto8" OnClick="lkbtnProducto8_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto8" CssClass="Productos" runat="server"/>
			</asp:Panel>
			<asp:Panel id="producto9" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto9" CssClass="imagenProductos" OnClick="imgProducto9_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto9" OnClick="lkbtnProducto9_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto9" runat="server"/>
			</asp:Panel>
			<asp:Panel id="producto10" CssClass="Productos" runat="server">
				<asp:ImageButton id="imgProducto10" CssClass="imagenProductos" OnClick="imgProducto10_Click" runat="server"/>
				<br>
				<asp:LinkButton id="lkbtnProducto10" OnClick="lkbtnProducto10_Click" runat="server"/>
				<br>
				<asp:Label id="lblProducto10" runat="server"/>
			</asp:Panel>
		</div>
	</div>
</asp:Content>