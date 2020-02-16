using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SAVSEM
{
	public partial class Ventas : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;
		DataSet dst;

		protected void Page_Load(Object sender, EventArgs e){
			AbrirConexion ();
			dst = CrearEstructura ();
			LeerTabla ();

			tbVentas.DataSource = dst.Tables [0];

			if (!IsPostBack) {
				panelAniadir.Visible = false;
				this.DataBind ();
			}
		}

		protected void btnAniadir_Click(Object sender, EventArgs e)
		{
			//Cambiamos el estado del panel a su opuesto, es decir:
			//Si es visible -> Se ocultará
			//Si está oculto -> Se mostrará
			panelAniadir.Visible = !panelAniadir.Visible;
			//Dependiendo de nuevo estado mostraremos el botón y los controles.
			if (panelAniadir.Visible == true)
				//Cambiamos el texto del botón a "cancelar".
				btnAniadir.Text = "Cancelar";
			else {
				//Ya que se ha cancelado regresamos los controles a sus valores vacios.
				//y escondemos el panel.
				txtNomProd.Text = "";
				txtUniDisp.Text = "";
				txtTipUni.Text = "";
				txtPrecio.Text = "";
				txtComenProd.Text = "";
				imgPreview.ImageUrl = "";
				lblErrorPublicar.Text = "";
				btnAniadir.Text = "Añadir producto para vender";
			}
		}

		protected void btnUploadImage_Click(Object sender, EventArgs e)
		{ 
			//Verificamos que se haya cargado una imagen
			if(fuImage.HasFile){
				//Verificamos si ya se habia cargado una imagen previa
				if(imgPreview.HasAttributes)
					imgPreview.ImageUrl = ""; 
				//Convertimos la imagen en arreglo de bytes
				byte[] arr = fuImage.FileBytes;
				string img = Convert.ToBase64String (arr, 0, arr.Length);
				//Mostramos la imagen através de una ruta de bytes.
				imgPreview.ImageUrl = "data:image/png;base64," + img;  
			}
		}

		protected void btnPublicar_Click(Object sender, EventArgs e)
		{
			//Obtenemos los datos.
			string nombreProd = txtNomProd.Text;
			string unidadVenta = txtTipUni.Text;
			string unidades = txtUniDisp.Text;
			string precio = txtPrecio.Text;
			string comentario = txtComenProd.Text;
			string URLFoto = imgPreview.ImageUrl;
			DateTime dt = DateTime.Now;
			string fecha = String.Format("{0:yyy-MM-dd HH:mm:ss}", dt); 
			//Validamos que todos los datos se hayan llenado correctamente.
			if(nombreProd != "" && unidadVenta != "" && unidades != "" && precio !="" && comentario != "" && URLFoto != "img/noimage.png"){
				cmd.CommandText = "INSERT INTO Productos(VendedorID, Nombre, Precio, UnidadVenta, UnidadesDidsponibles, Foto, Fecha,  Comentario, Compras)" +
					"VALUES (" + Session["ID"].ToString() + ", '" + nombreProd + "', " + precio + ", '" + unidadVenta + "', " + unidades + "," +
					" '" + URLFoto + "', '" + fecha + "', '" + comentario + "', 0);";
				cmd.Connection = sqlcnx;
				try {
					//Ejecutamos el query.
					cmd.ExecuteNonQuery ();

					//Registramos la publicación en el historial
					cmd.CommandText = "INSERT INTO Historial(UsuarioID, Accion, Fecha)" +
						"VALUES (" + Session["ID"].ToString() + ", 'Publicó " + nombreProd + " para vender.', '" + fecha + "');";
					cmd.ExecuteNonQuery ();

					//Preparamos los controles para una siguiente publicación
					txtNomProd.Text = "";
					txtUniDisp.Text = "";
					txtTipUni.Text = "";
					txtPrecio.Text = "";
					txtComenProd.Text = "";
					imgPreview.ImageUrl = "";
					lblErrorPublicar.Text = "";
					//Cerramos el panel para añadir productos
					panelAniadir.Visible = false;
					btnAniadir.Text = "Añadir producto para vender";

					//6)Refrescamos la página
					Response.Redirect ("Ventas.aspx");
				} catch (Exception ex) {
					lblErrorPublicar.Text = "Ha ocurrido un error, intente de nuevo.\n" + ex;
				}
			}else{
				lblErrorPublicar.Text = "Todos los datos deben estar llenados correctamente.";
			}
		}
			
		protected void tbVentas_RowDeleting(Object sender, GridViewDeleteEventArgs e)
		{
			DateTime dt = DateTime.Now;
			string fecha = String.Format("{0:yyy-MM-dd HH:mm:ss}", dt); 

			cmd.CommandText = "DELETE FROM Productos WHERE ID=" + ((Label)tbVentas.Rows[e.RowIndex].FindControl("gvlblID")).Text + ";";
			cmd.Connection = sqlcnx;
			cmd.ExecuteNonQuery ();
			//Registramos la eliminación en el historial
			cmd.CommandText = "INSERT INTO Historial(UsuarioID, Accion, Fecha)" +
				"VALUES (" + Session["ID"].ToString() + ", 'Eliminó " + ((Label)tbVentas.Rows[e.RowIndex].FindControl("gvlblNombre")).Text + ".', '" + fecha + "');";
			cmd.ExecuteNonQuery ();
			LeerTabla ();
			tbVentas.DataSource = dst.Tables [0];
			this.DataBind ();
		}

		protected void tbVentas_RowEditing(Object sender, GridViewEditEventArgs e)
		{
			tbVentas.EditIndex = e.NewEditIndex;
			this.DataBind ();
		}

		protected void tbVentas_RowUpdating(Object sender, GridViewUpdateEventArgs e)
		{
			//Obtenemos los datos.
			string id = ((Label)tbVentas.Rows[e.RowIndex].FindControl("gvlblID")).Text;
			string nombreProd = ((TextBox)tbVentas.Rows[e.RowIndex].FindControl("gvtxtNombre")).Text;
			string unidadVenta = ((TextBox)tbVentas.Rows[e.RowIndex].FindControl("gvtxtUVenta")).Text;
			string unidades = ((TextBox)tbVentas.Rows[e.RowIndex].FindControl("gvtxtDisponibles")).Text;
			string precio = ((TextBox)tbVentas.Rows[e.RowIndex].FindControl("gvtxtPrecio")).Text;
			string comentario = ((TextBox)tbVentas.Rows[e.RowIndex].FindControl("gvtxtComentario")).Text;
			string URLFoto = string.Empty;
			DateTime dt = DateTime.Now;
			string fecha = String.Format("{0:yyy-MM-dd HH:mm:ss}", dt); 

			//Obtenemos la ruta de la imagen y la convertimos a una cadena valida
			if (((FileUpload)tbVentas.Rows [e.RowIndex].FindControl ("gvfuFoto")).HasFile) {
				//Convertimos la imagen en arreglo de bytes
				byte[] arr = ((FileUpload)tbVentas.Rows [e.RowIndex].FindControl ("gvfuFoto")).FileBytes;
				URLFoto = "data:image/png;base64," + Convert.ToBase64String (arr, 0, arr.Length);
			} else {
				URLFoto = ((Label)tbVentas.Rows [e.RowIndex].FindControl ("gvlblFoto")).Text;
			}
			cmd.CommandText = "UPDATE Productos SET Nombre='" + nombreProd + "', Precio=" + precio + ", " +
				"UnidadVenta='" + unidadVenta + "', UnidadesDidsponibles=" + unidades + ", Comentario='" + comentario + "'," +
				" Foto='" + URLFoto + "' WHERE ID=" + id + ";";
			cmd.Connection = sqlcnx;
			try{
				cmd.ExecuteNonQuery ();

				//Registramos la actualización en el historial
				cmd.CommandText = "INSERT INTO Historial(UsuarioID, Accion, Fecha)" +
					"VALUES (" + Session["ID"].ToString() + ", 'Actualizó los datos de " + ((TextBox)tbVentas.Rows[e.RowIndex].FindControl("gvtxtNombre")).Text + ".', '" + fecha + "');";
				cmd.ExecuteNonQuery ();

			}catch(Exception ex){
				lblErrorPrueba.Text = "Ha ocurrido un error, intente de nuevo.";
			}
			tbVentas.EditIndex = -1;
			LeerTabla ();
			tbVentas.DataSource = dst.Tables [0];
			this.DataBind ();
		}

		protected void tbVentas_RowCancelingEdit(Object sender, GridViewCancelEditEventArgs e)
		{
			tbVentas.EditIndex = -1;
			this.DataBind ();
		}
		private void AbrirConexion(){
			//1)Abrimos la conexión de la cadena
			cnxstr = System.Configuration.ConfigurationManager.ConnectionStrings ["SQLServer2017"].ConnectionString;

			//2)Abrir la conexión con la base de datos
			sqlcnx.ConnectionString = cnxstr;
			sqlcnx.Open ();
		}

		private DataSet CrearEstructura(){
			DataSet dst = new DataSet ("base");
			DataTable tbl = new DataTable ("Productos") {
				Columns = {
					new DataColumn ("ID", Type.GetType ("System.Int32")),
					new DataColumn ("Nombre", Type.GetType ("System.String")),
					new DataColumn ("Precio", Type.GetType ("System.Double")),
					new DataColumn ("UVenta", Type.GetType ("System.String")),
					new DataColumn ("Disponibles", Type.GetType ("System.Double")),
					new DataColumn ("Comentario", Type.GetType ("System.String")),
					new DataColumn ("Foto", Type.GetType ("System.String")),
					new DataColumn ("Fecha", Type.GetType ("System.String")),
					new DataColumn ("VecesPedido", Type.GetType ("System.String"))
				}
			};
			dst.Tables.Add (tbl);
			return dst;
		}

		private void LeerTabla(){
			cmd.CommandText = "SELECT * FROM Productos WHERE VendedorID=" + Session["ID"].ToString() + ";";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			if (dst.Tables [0].Rows.Count > 0) {
				dst.Tables [0].Rows.Clear ();
			}
			while (data.Read ()) {
				DataRow row;
				row = dst.Tables [0].NewRow ();
				row ["ID"] = data [0];
				row ["Nombre"] = data [2];
				row ["Precio"] = data [3];
				row ["UVenta"] = data [4];
				row ["Disponibles"] = data [5];
				row ["Comentario"] = data [8];
				row ["Foto"] = data [6].ToString();
				row ["Fecha"] = data [7].ToString();
				row ["VecesPedido"] = data [9].ToString();
				dst.Tables [0].Rows.Add (row);
			}
			data.Close ();
		}

		private void CerrarConexion(){
			sqlcnx.Close();
		}
	}
}

