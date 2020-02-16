using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SAVSEM
{
	public partial class Buscar : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;
		DataSet dst;

		protected void Page_Load(Object sender, EventArgs e){
			lblBusqueda.Text = "Busqueda de " + Session ["busqueda"].ToString ();

			AbrirConexion ();
			dst = CrearEstructura ();
			LeerTabla ();

			tbBusqueda.DataSource = dst.Tables [0];

			if (!IsPostBack) {
				this.DataBind ();
			}
		}

		protected void tbBusqueda_RowCommand(Object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Ver") {
				GridViewRow rowSelect = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
				int rowindex = rowSelect.RowIndex;
				Session["ProductoID"] = dst.Tables [0].Rows [rowindex]["ID"].ToString();
				Response.Redirect ("Producto.aspx");
			}
			if (e.CommandName == "VerImg") {
				GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
				int rowindex = rowSelect.RowIndex;
				Session["ProductoID"] = dst.Tables [0].Rows [rowindex]["ID"].ToString();
				Response.Redirect ("Producto.aspx");
			}
			if (e.CommandName == "VerLnk") {
				GridViewRow rowSelect = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
				int rowindex = rowSelect.RowIndex;
				Session["ProductoID"] = dst.Tables [0].Rows [rowindex]["ID"].ToString();
				Response.Redirect ("Producto.aspx");
			}
		}

		private DataSet CrearEstructura(){
			DataSet dst = new DataSet ("base");
			DataTable tbl = new DataTable ("Productos") {
				Columns = {
					new DataColumn ("ID", Type.GetType ("System.String")),
					new DataColumn ("Imagen", Type.GetType ("System.String")),
					new DataColumn ("Producto", Type.GetType ("System.String")),
					new DataColumn ("Cantidad", Type.GetType ("System.String")),
					new DataColumn ("Precio", Type.GetType ("System.String")),
					new DataColumn ("Fecha", Type.GetType ("System.String")),
					new DataColumn ("Vendedor", Type.GetType ("System.String"))
				}
			};
			dst.Tables.Add (tbl);
			return dst;
		}

		private void LeerTabla(){
			ArrayList vendedorID = new ArrayList ();
			cmd.CommandText = "SELECT * FROM Productos WHERE Nombre LIKE '%" + Session["busqueda"].ToString() + "%';";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			if (dst.Tables [0].Rows.Count > 0) {
				dst.Tables [0].Rows.Clear ();
			}
			while (data.Read ()) {
				DataRow row;
				row = dst.Tables [0].NewRow ();
				row ["ID"] = data [0].ToString ();
				row ["Imagen"] = data [6].ToString();
				row ["Producto"] = data [2].ToString();
				row ["Cantidad"] = data [5].ToString();
				row ["Precio"] = "$" + Convert.ToDouble (data [3].ToString()).ToString ("0.00") + " c/" + data [4].ToString();
				row ["Fecha"] = data [7].ToString();
				vendedorID.Add(data [1].ToString());
				dst.Tables [0].Rows.Add (row);
			}
			data.Close ();
			int i = 0;
			foreach(string s in vendedorID) {
				cmd.CommandText = "SELECT * FROM Usuarios WHERE ID='" + s + "';";
				data = cmd.ExecuteReader ();
				while (data.Read ()) {
					dst.Tables [0].Rows [i] ["Vendedor"] = data [1].ToString () + " " + data [2].ToString ();
					i++;
				}
				data.Close ();
			}

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

