using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SAVSEM
{
	public partial class Administrador : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;

		DataSet dst;

		protected void Page_Load(Object sender, EventArgs e){
			AbrirConexion ();
			dst = CrearEstructura ();
			//Llenamos la tabla de Usuarios
			CargarUsuarios ();
			tbUsers.DataSource = dst.Tables ["Usuarios"];

			//Llenamos la tabla de Productos.
			CargarProductos ();
			tbProductos.DataSource = dst.Tables ["Productos"];

			//Llenamos la tabla de Mensajes.
			CargarMensajes ();
			tbMensajes.DataSource = dst.Tables ["Mensajes"];

			if (!IsPostBack) {
				tbUsers.Visible = false;
				tbProductos.Visible = false;
				tbMensajes.Visible = false;
				this.DataBind ();
			}
		}

		protected void lkbtnMosAUs_Click(Object sender, EventArgs e)
		{
			if (lkbtnMosAUs.Text == "Mostrar") {
				lkbtnMosAUs.Text = "Esconder";
				tbUsers.Visible = true;
			}else{
				lkbtnMosAUs.Text = "Mostrar";
				tbUsers.Visible = false;
			}
		}


		protected void lkbtnMosAPe_Click(Object sender, EventArgs e)
		{
			if (lkbtnMosAPe.Text == "Mostrar") {
				lkbtnMosAPe.Text = "Esconder";
				tbProductos.Visible = true;
			}else{
				lkbtnMosAPe.Text = "Mostrar";
				tbProductos.Visible = false;
			}
		}


		protected void lkbtnMosAMa_Click(Object sender, EventArgs e)
		{
			if (lkbtnMosAMa.Text == "Mostrar") {
				lkbtnMosAMa.Text = "Esconder";
				tbMensajes.Visible = true;
			}else{
				lkbtnMosAMa.Text = "Mostrar";
				tbMensajes.Visible = false;
			}
		}

		protected void tbUsers_ItemCommand(Object source, DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName){
			case "btnEliminarUs":
				{
					cmd.CommandText = "DELETE FROM Usuarios WHERE ID='" + dst.Tables ["Usuarios"].Rows [e.Item.ItemIndex] ["ID"].ToString () + "';";
					cmd.Connection = sqlcnx;
					cmd.ExecuteNonQuery ();

					CargarUsuarios ();
					tbUsers.DataSource = dst.Tables ["Usuarios"];
					this.DataBind ();
				}
				break;
			default:
				break;
			}
		}


		protected void tbProductos_ItemCommand(Object source, DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName){
			case "btnCancelarP":
				{
					cmd.CommandText = "DELETE FROM Productos WHERE ID='" + dst.Tables ["Productos"].Rows [e.Item.ItemIndex] ["ID"].ToString () + "';";
					cmd.Connection = sqlcnx;
					cmd.ExecuteNonQuery ();

					CargarProductos ();
					tbProductos.DataSource = dst.Tables ["Productos"];
					this.DataBind ();
				}
				break;
			default:
				break;
			}
		}

		private DataSet CrearEstructura (){
				DataSet dst = new DataSet ("base");
				DataTable tbl = new DataTable ("Usuarios") {
					Columns = {
						new DataColumn ("ID", Type.GetType("System.String")),
						new DataColumn ("Nombre", Type.GetType("System.String")),
						new DataColumn ("Dirección", Type.GetType("System.String")),
						new DataColumn ("CP", Type.GetType("System.String")),
						new DataColumn ("Teléfono", Type.GetType("System.String")),
						new DataColumn ("Correo", Type.GetType("System.String")),
						new DataColumn ("Usuario", Type.GetType("System.String")),
						new DataColumn ("Estado", Type.GetType("System.String"))
					}
				};
				dst.Tables.Add (tbl);

				tbl = new DataTable ("Productos") {
					Columns = {
						new DataColumn ("ID", Type.GetType("System.String")),
						new DataColumn ("Prodcuto", Type.GetType("System.String")),
						new DataColumn ("Vendedor", Type.GetType("System.String")),
						new DataColumn ("Precio", Type.GetType("System.String")),
						new DataColumn ("Unidades", Type.GetType("System.String")),
						new DataColumn ("Cantidad", Type.GetType("System.String")),
						new DataColumn ("Fecha de publicación", Type.GetType("System.String")),
						new DataColumn ("Comentario", Type.GetType("System.String"))
					}
				};
				dst.Tables.Add (tbl);

				tbl = new DataTable ("Mensajes") {
					Columns = {
						new DataColumn ("Fecha", Type.GetType("System.String")),
						new DataColumn ("Destinatario", Type.GetType("System.String")),
						new DataColumn ("Estado", Type.GetType("System.String")),
						new DataColumn ("Mensaje", Type.GetType("System.String"))
					}
				};
				dst.Tables.Add (tbl);

				return dst;
		}

		private void CargarUsuarios(){
			if (dst.Tables ["Usuarios"].Rows.Count > 0) {
				dst.Tables ["Usuarios"].Rows.Clear ();
			}
			cmd.CommandText = "SELECT * FROM Usuarios;";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			while (data.Read ()) {
				DataRow row;
				row = dst.Tables ["Usuarios"].NewRow ();
				row["ID"] = data[0].ToString();
				row["Nombre"] = data[1].ToString() + " " + data[2].ToString();
				row["Dirección"] = data[3].ToString();
				row["CP"] = data[4].ToString();
				row["Teléfono"] = data[5].ToString();
				row["Correo"] = data[6].ToString();
				row["Usuario"] = data[7].ToString();
				if (data [10].ToString () == "True") {
					row["Estado"] = "Vendedor";
				} else {
					row["Estado"] = "Usuario";
				}
				dst.Tables ["Usuarios"].Rows.Add (row);
			}
			data.Close ();
		}

		private void CargarProductos(){
			ArrayList VendedorID = new ArrayList();
			if (dst.Tables ["Productos"].Rows.Count > 0) {
				dst.Tables ["Productos"].Rows.Clear ();
			}
			cmd.CommandText = "SELECT * FROM Productos;";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			while (data.Read ()) {
				DataRow row;
				row = dst.Tables ["Productos"].NewRow ();
				row["ID"] = data[0].ToString();
				VendedorID.Add (data[1].ToString());
				row["Prodcuto"] = data[2].ToString();
				row["Precio"] = "$ " + Convert.ToDouble(data[3].ToString()).ToString("0.00");
				row["Unidades"] = data[4].ToString();
				row["Cantidad"] = data[5].ToString();
				row["Fecha de publicación"] = data[7].ToString();
				row["Comentario"] = data[8].ToString();
				dst.Tables ["Productos"].Rows.Add (row);
			}
			data.Close ();

			int i = 0;
			foreach (String s in VendedorID) {
				cmd.CommandText = "SELECT * FROM Usuarios WHERE ID=" + s + ";";
				cmd.Connection = sqlcnx;
				data = cmd.ExecuteReader ();
				while (data.Read ()) {
					dst.Tables ["Productos"].Rows[i]["Vendedor"] = data[1].ToString() + " " + data[2].ToString();
				}
				data.Close ();
				i++;
			}
		}

		private void CargarMensajes(){
			if (dst.Tables ["Mensajes"].Rows.Count > 0) {
				dst.Tables ["Mensajes"].Rows.Clear ();
			}
			cmd.CommandText = "SELECT * FROM Mensaje;";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			while (data.Read ()) {
				DataRow row;
				String user;
				row = dst.Tables ["Mensajes"].NewRow ();
				row["Fecha"] = data[3].ToString();
				row["Destinatario"] = data[0].ToString();
				row["Mensaje"] = data[2].ToString();
				user = data [1].ToString ();
				if (Convert.ToBoolean(user)) {
					row ["Estado"] = "Usuario";
				} else {
					row ["Estado"] = "No usuario";
				}
				dst.Tables ["Mensajes"].Rows.Add (row);
			}
			data.Close ();
		}

		private void AbrirConexion(){
			//1)Abrimos la conexión de la cadena
			cnxstr = System.Configuration.ConfigurationManager.ConnectionStrings ["SQLServer2017"].ConnectionString;

			//2)Abrir la conexión con la base de datos
			sqlcnx.ConnectionString = cnxstr;
			sqlcnx.Open ();
		}

		private void CerrarConexion(){
			sqlcnx.Close();
		}
	}
}