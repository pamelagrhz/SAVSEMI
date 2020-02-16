using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SAVSEM
{
	public partial class Compras : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;

		DataSet dst;

		protected void Page_Load(Object sender, EventArgs e){
			if(Session["vendedor"].ToString() == "True"){
				productorModo.Visible = true;
			}else{
				productorModo.Visible = false;
			}

			AbrirConexion ();
			dst = CrearEstructura ();
			//Llenamos la tabla de pedidos realizados.
			CargarRealizados();
			tbRealizados.DataSource = dst.Tables ["Realizados"];

			//Llenamos la tabla de pedidos recibidos.
			CargarRecibidos();
			tbRecibidos.DataSource = dst.Tables ["Recibidos"];

			if (!IsPostBack) {
				tbRealizados.Visible = false;
				tbRecibidos.Visible = false;
				this.DataBind ();
			}

		}

		protected void lkbtnMosRec_Click(Object sender, EventArgs e)
		{
			if (lkbtnMosRec.Text == "Mostrar") {
				lkbtnMosRec.Text = "Esconder";
				tbRecibidos.Visible = true;
			}else{
				lkbtnMosRec.Text = "Mostrar";
				tbRecibidos.Visible = false;
			}
		}

		protected void lkbtnMosRea_Click(Object sender, EventArgs e)
		{
			if (lkbtnMosRea.Text == "Mostrar") {
				lkbtnMosRea.Text = "Esconder";
				tbRealizados.Visible = true;
			}else{
				lkbtnMosRea.Text = "Mostrar";
				tbRealizados.Visible = false;
			}
		}

		protected void tbRecibidos_ItemCommand(Object sender, DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName){
			case "btnCancelarPR":
				{
					string ProductoID = string.Empty;
					string cantidadCom = string.Empty;
					string cantidadAnt = string.Empty;
					string cantidadTot = string.Empty;

					cmd.CommandText = "SELECT * FROM Pedidos WHERE ID='" + dst.Tables ["Recibidos"].Rows [e.Item.ItemIndex] ["ID"].ToString () + "';";
					cmd.Connection = sqlcnx;
					data = cmd.ExecuteReader ();
					while (data.Read ()) {
						ProductoID = data[2].ToString();
						cantidadCom = data[3].ToString();
					}
					data.Close ();

					cmd.CommandText = "SELECT * FROM Productos WHERE ID='" + ProductoID + "';";
					data = cmd.ExecuteReader ();
					while (data.Read ()) {
						cantidadAnt = data[5].ToString();
					}
					data.Close ();

					cantidadTot = (Convert.ToDouble (cantidadCom) + Convert.ToDouble (cantidadAnt)).ToString ();
					cmd.CommandText = "UPDATE Productos SET UnidadesDidsponibles='" + cantidadTot + "' WHERE ID='" + ProductoID + "';";
					try{
						cmd.ExecuteNonQuery();

						cmd.CommandText = "DELETE FROM Pedidos WHERE ID='" + dst.Tables ["Recibidos"].Rows [e.Item.ItemIndex] ["ID"].ToString () + "';";
						cmd.ExecuteNonQuery();

						//Llenamos la tabla de pedidos realizados.
						CargarRealizados();
						tbRealizados.DataSource = dst.Tables ["Realizados"];

						//Llenamos la tabla de pedidos recibidos.
						CargarRecibidos();
						tbRecibidos.DataSource = dst.Tables ["Recibidos"];

						this.DataBind();
					}catch(Exception ex){
						indicador.Text = "Ha ocurrido un error. Por favor, intentelo otra vez." + ex;
					}
				}
				break;
			default:
				break;
			}
		}

		protected void tbRealizados_ItemCommand(Object sender, DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName){
			case "btnCancelarP":
				{
					string ProductoID = string.Empty;
					string cantidadCom = string.Empty;
					string cantidadAnt = string.Empty;
					string cantidadTot = string.Empty;

					cmd.CommandText = "SELECT * FROM Pedidos WHERE ID='" + dst.Tables ["Realizados"].Rows [e.Item.ItemIndex] ["ID"].ToString () + "';";
					cmd.Connection = sqlcnx;
					data = cmd.ExecuteReader ();
					while (data.Read ()) {
						ProductoID = data[2].ToString();
						cantidadCom = data[3].ToString();
					}
					data.Close ();

					cmd.CommandText = "SELECT * FROM Productos WHERE ID='" + ProductoID + "';";
					data = cmd.ExecuteReader ();
					while (data.Read ()) {
						cantidadAnt = data[5].ToString();
					}
					data.Close ();

					cantidadTot = (Convert.ToDouble (cantidadCom) + Convert.ToDouble (cantidadAnt)).ToString ();
					cmd.CommandText = "UPDATE Productos SET UnidadesDidsponibles='" + cantidadTot + "' WHERE ID='" + ProductoID + "';";
					try{
						cmd.ExecuteNonQuery();

						cmd.CommandText = "DELETE FROM Pedidos WHERE ID='" + dst.Tables ["Realizados"].Rows [e.Item.ItemIndex] ["ID"].ToString () + "';";
						cmd.ExecuteNonQuery();

						//Llenamos la tabla de pedidos realizados.
						CargarRealizados();
						tbRealizados.DataSource = dst.Tables ["Realizados"];

						//Llenamos la tabla de pedidos recibidos.
						CargarRecibidos();
						tbRecibidos.DataSource = dst.Tables ["Recibidos"];

						this.DataBind();
					}catch(Exception ex){
						indicador.Text = "Ha ocurrido un error. Por favor, intentelo otra vez." + ex;
					}
				}
				break;
			default:
				break;
			}
		}

		private void CargarRealizados(){
			ArrayList ProductoID = new ArrayList ();
			ArrayList VendedorID = new ArrayList ();

			if (dst.Tables ["Realizados"].Rows.Count > 0) {
				dst.Tables ["Realizados"].Rows.Clear ();
			}

			cmd.CommandText = "SELECT * FROM Pedidos WHERE CompradorID='" + Session["ID"].ToString() + "';";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			while (data.Read ()) {
				DataRow row;
				row = dst.Tables ["Realizados"].NewRow ();
				ProductoID.Add(data[2].ToString());
				row["ID"] = data[0].ToString();
				row["Cantidad"] = data[3].ToString();
				row["Precio Unitario"] = "$" + Convert.ToDouble(data[4].ToString()).ToString("0.00");
				row["Precio Total"] = "$" + Convert.ToDouble(data[5].ToString()).ToString("0.00");
				row["Fecha"] = data[6].ToString();
				dst.Tables ["Realizados"].Rows.Add (row);
			}
			data.Close ();

			int i = 0;
			foreach (string s in ProductoID) {
				cmd.CommandText = "SELECT * FROM Productos WHERE ID='" + s + "';";
				data = cmd.ExecuteReader ();
				while (data.Read ()) {
					VendedorID.Add(data [1].ToString ());
					dst.Tables ["Realizados"].Rows[i]["Producto"] = data [2].ToString ();
				}
				data.Close ();
				i++;
			}

			i = 0;
			foreach(string s2 in VendedorID){
				cmd.CommandText = "SELECT * FROM Usuarios WHERE ID='" + s2 + "';";
				data = cmd.ExecuteReader ();
				while (data.Read ()) {
					dst.Tables ["Realizados"].Rows[i]["Vendedor"] = data [1].ToString () + " " + data [2].ToString ();
					dst.Tables ["Realizados"].Rows[i]["Direccion"] = data [3].ToString ();
					dst.Tables ["Realizados"].Rows[i]["Telefono"] = data [5].ToString ();
					dst.Tables ["Realizados"].Rows[i]["Correo"] = data [6].ToString ();
				}
				data.Close ();
				i++;
			}
		}

		private void CargarRecibidos(){
			ArrayList ProductoID = new ArrayList ();
			ArrayList CompradorID = new ArrayList ();

			if (dst.Tables ["Recibidos"].Rows.Count > 0) {
				dst.Tables ["Recibidos"].Rows.Clear ();
			}
			cmd.CommandText = "SELECT * FROM Pedidos WHERE CorreoVendedor='" + Session["email"].ToString() + "';";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();

			while (data.Read ()) {
				DataRow row;
				row = dst.Tables ["Recibidos"].NewRow ();
				CompradorID.Add(data[1].ToString());
				ProductoID.Add(data[2].ToString());
				row["ID"] = data[0].ToString();
				row["Cantidad"] = data[3].ToString();
				row["Precio Unitario"] = "$" + Convert.ToDouble(data[4].ToString()).ToString("0.00");
				row["Precio Total"] = "$" + Convert.ToDouble(data[5].ToString()).ToString("0.00");
				row["Fecha"] = data[6].ToString();
				dst.Tables ["Recibidos"].Rows.Add (row);
			}
			data.Close ();

			int i = 0;
			foreach (string s in ProductoID) {
				cmd.CommandText = "SELECT * FROM Productos WHERE ID='" + s + "';";
				data = cmd.ExecuteReader ();
				while (data.Read ()) {
					dst.Tables ["Recibidos"].Rows[i]["Producto"] = data [2].ToString ();
				}
				data.Close ();
				i++;
			}

			i = 0;
			foreach (string s2 in CompradorID) {
				cmd.CommandText = "SELECT * FROM Usuarios WHERE ID='" + s2 + "';";
				data = cmd.ExecuteReader ();
				while (data.Read ()) {
					dst.Tables ["Recibidos"].Rows[i]["Comprador"] = data [1].ToString () + " " + data [2].ToString ();
					dst.Tables ["Recibidos"].Rows[i]["Direccion"] = data [3].ToString ();
					dst.Tables ["Recibidos"].Rows[i]["Telefono"] = data [5].ToString ();
					dst.Tables ["Recibidos"].Rows[i]["Correo"] = data [6].ToString ();
				}
				data.Close ();
				i++;
			}
		}

		private DataSet CrearEstructura (){
			DataSet dst = new DataSet ("base");
			DataTable tbl = new DataTable ("Realizados") {
				Columns = {
					new DataColumn ("ID", Type.GetType("System.String")),
					new DataColumn ("Fecha", Type.GetType("System.String")),
					new DataColumn ("Producto", Type.GetType("System.String")),
					new DataColumn ("Vendedor", Type.GetType("System.String")),
					new DataColumn ("Correo", Type.GetType("System.String")),
					new DataColumn ("Telefono", Type.GetType("System.String")),
					new DataColumn ("Direccion", Type.GetType("System.String")),
					new DataColumn ("Cantidad", Type.GetType("System.String")),
					new DataColumn ("Precio Unitario", Type.GetType("System.String")),
					new DataColumn ("Precio Total", Type.GetType("System.String"))
				}
			};
			dst.Tables.Add (tbl);

			tbl = new DataTable ("Recibidos") {
				Columns = {
					new DataColumn ("ID", Type.GetType("System.String")),
					new DataColumn ("Fecha", Type.GetType("System.String")),
					new DataColumn ("Producto", Type.GetType("System.String")),
					new DataColumn ("Comprador", Type.GetType("System.String")),
					new DataColumn ("Correo", Type.GetType("System.String")),
					new DataColumn ("Telefono", Type.GetType("System.String")),
					new DataColumn ("Direccion", Type.GetType("System.String")),
					new DataColumn ("Cantidad", Type.GetType("System.String")),
					new DataColumn ("Precio Unitario", Type.GetType("System.String")),
					new DataColumn ("Precio Total", Type.GetType("System.String"))
				}
			};
			dst.Tables.Add (tbl);

			return dst;
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

