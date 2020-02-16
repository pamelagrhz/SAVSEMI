using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SAVSEM
{
	public partial class Default : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;
		DataSet dst;

		protected void Page_Load(Object sender, EventArgs e){
			AbrirConexion ();
			dst = CrearEstructura ();
			CargarDatos ();

			switch (dst.Tables ["UAgregados"].Rows.Count) {
			case 0:
				{
					producto1.Visible = false;
					producto2.Visible = false;
					producto3.Visible = false;
					producto4.Visible = false;
					producto5.Visible = false;
				}
				break;
			case 1:
				{
					producto1.Visible = true;
					producto2.Visible = false;
					producto3.Visible = false;
					producto4.Visible = false;
					producto5.Visible = false;
				}
				break;
			case 2:
				{
					producto1.Visible = true;
					producto2.Visible = true;
					producto3.Visible = false;
					producto4.Visible = false;
					producto5.Visible = false;
				}
				break;
			case 3:
				{
					producto1.Visible = true;
					producto2.Visible = true;
					producto3.Visible = true;
					producto4.Visible = false;
					producto5.Visible = false;
				}
				break;
			case 4:
				{
					producto1.Visible = true;
					producto2.Visible = true;
					producto3.Visible = true;
					producto4.Visible = true;
					producto5.Visible = false;
				}
				break;
			case 5:
				{
					producto1.Visible = true;
					producto2.Visible = true;
					producto3.Visible = true;
					producto4.Visible = true;
					producto5.Visible = true;
				}
				break;
			default:
				{
					producto1.Visible = false;
					producto2.Visible = false;
					producto3.Visible = false;
					producto4.Visible = false;
					producto5.Visible = false;
				}
				break;
			}

			switch (dst.Tables ["MVendidos"].Rows.Count) {
			case 0:
				{
					producto6.Visible = false;
					producto7.Visible = false;
					producto8.Visible = false;
					producto9.Visible = false;
					producto10.Visible = false;
				}
				break;
			case 1:
				{
					producto6.Visible = true;
					producto7.Visible = false;
					producto8.Visible = false;
					producto9.Visible = false;
					producto10.Visible = false;
				}
				break;
			case 2:
				{
					producto6.Visible = true;
					producto7.Visible = true;
					producto8.Visible = false;
					producto9.Visible = false;
					producto10.Visible = false;
				}
				break;
			case 3:
				{
					producto6.Visible = true;
					producto7.Visible = true;
					producto8.Visible = true;
					producto9.Visible = false;
					producto10.Visible = false;
				}
				break;
			case 4:
				{
					producto6.Visible = true;
					producto7.Visible = true;
					producto8.Visible = true;
					producto9.Visible = true;
					producto10.Visible = false;
				}
				break;
			case 5:
				{
					producto6.Visible = true;
					producto7.Visible = true;
					producto8.Visible = true;
					producto9.Visible = true;
					producto10.Visible = true;
				}
				break;
			default:
				{
					producto6.Visible = false;
					producto7.Visible = false;
					producto8.Visible = false;
					producto9.Visible = false;
					producto10.Visible = false;
				}
				break;
			}

			CargarImagenes ();

			if (!IsPostBack) {
				this.DataBind ();
			}
		}

		protected void lkbtnProducto1_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[0][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto1_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[0][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto2_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[1][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto2_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[1][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto3_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[2][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto3_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[2][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto4_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[3][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto4_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[3][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto5_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[4][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto5_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["UAgregados"].Rows[4][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto6_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [0][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto6_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [0][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto7_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [1][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto7_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [1][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto8_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [2][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto8_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [2][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto9_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [3][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto9_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [3][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void imgProducto10_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [4][0].ToString();
			Response.Redirect ("Producto.aspx");
		}


		protected void lkbtnProducto10_Click(Object sender, EventArgs e)
		{
			Session["ProductoID"] = dst.Tables ["MVendidos"].Rows [4][0].ToString();
			Response.Redirect ("Producto.aspx");
		}

		private void CargarImagenes (){
			//Cargar los elementos que se encuentran en el DataSet de los ultimos agregados.
			if (dst.Tables ["UAgregados"].Rows.Count >= 5) {
				imgProducto5.ImageUrl = dst.Tables ["UAgregados"].Rows[4][4].ToString();
				lkbtnProducto5.Text = dst.Tables ["UAgregados"].Rows [4][1].ToString();
				lblProducto5.Text = "$ " + dst.Tables ["UAgregados"].Rows [4][2].ToString() + " c/" + dst.Tables ["UAgregados"].Rows [4][3].ToString();
			}
			if (dst.Tables ["UAgregados"].Rows.Count >= 4) {
				imgProducto4.ImageUrl = dst.Tables ["UAgregados"].Rows[3][4].ToString();
				lkbtnProducto4.Text = dst.Tables ["UAgregados"].Rows [3][1].ToString();
				lblProducto4.Text = "$ " + dst.Tables ["UAgregados"].Rows [3][2].ToString() + " c/" + dst.Tables ["UAgregados"].Rows [3][3].ToString();
			}
			if (dst.Tables ["UAgregados"].Rows.Count >= 3) {
				imgProducto3.ImageUrl = dst.Tables ["UAgregados"].Rows[2][4].ToString();
				lkbtnProducto3.Text = dst.Tables ["UAgregados"].Rows [2][1].ToString();
				lblProducto3.Text = "$ " + dst.Tables ["UAgregados"].Rows [2][2].ToString() + " c/" + dst.Tables ["UAgregados"].Rows [2][3].ToString();
			}
			if (dst.Tables ["UAgregados"].Rows.Count >= 2) {
				imgProducto2.ImageUrl = dst.Tables ["UAgregados"].Rows[1][4].ToString();
				lkbtnProducto2.Text = dst.Tables ["UAgregados"].Rows [1][1].ToString();
				lblProducto2.Text = "$ " + dst.Tables ["UAgregados"].Rows [1][2].ToString() + " c/" + dst.Tables ["UAgregados"].Rows [1][3].ToString();
			}
			if (dst.Tables ["UAgregados"].Rows.Count >= 1) {
				imgProducto1.ImageUrl = dst.Tables ["UAgregados"].Rows[0][4].ToString();
				lkbtnProducto1.Text = dst.Tables ["UAgregados"].Rows [0][1].ToString();
				lblProducto1.Text = "$ " + dst.Tables ["UAgregados"].Rows [0][2].ToString() + " c/" + dst.Tables ["UAgregados"].Rows [0][3].ToString();
			}

			//Cargar los elementos que se encuentran en la lista de los más vendios.
			if (dst.Tables ["MVendidos"].Rows.Count >= 5) {
				imgProducto10.ImageUrl = dst.Tables ["MVendidos"].Rows[4][4].ToString();
				lkbtnProducto10.Text = dst.Tables ["MVendidos"].Rows [4][1].ToString();
				lblProducto10.Text = "$ " + dst.Tables ["MVendidos"].Rows [4][2].ToString() + " c/" + dst.Tables ["MVendidos"].Rows [4][3].ToString();
			}
			if (dst.Tables ["MVendidos"].Rows.Count >= 4) {
				imgProducto9.ImageUrl = dst.Tables ["MVendidos"].Rows[3][4].ToString();
				lkbtnProducto9.Text = dst.Tables ["MVendidos"].Rows [3][1].ToString();
				lblProducto9.Text = "$ " + dst.Tables ["MVendidos"].Rows [3][2].ToString() + " c/" + dst.Tables ["MVendidos"].Rows [3][3].ToString();
			}
			if (dst.Tables ["MVendidos"].Rows.Count >= 3) {
				imgProducto8.ImageUrl = dst.Tables ["MVendidos"].Rows[2][4].ToString();
				lkbtnProducto8.Text = dst.Tables ["MVendidos"].Rows [2][1].ToString();
				lblProducto8.Text = "$ " + dst.Tables ["MVendidos"].Rows [2][2].ToString() + " c/" + dst.Tables ["MVendidos"].Rows [2][3].ToString();
			}
			if (dst.Tables ["MVendidos"].Rows.Count >= 2) {
				imgProducto7.ImageUrl = dst.Tables ["MVendidos"].Rows[1][4].ToString();
				lkbtnProducto7.Text = dst.Tables ["MVendidos"].Rows [1][1].ToString();
				lblProducto7.Text = "$ " + dst.Tables ["MVendidos"].Rows [1][2].ToString() + " c/" + dst.Tables ["MVendidos"].Rows [1][3].ToString();
			}
			if (dst.Tables ["MVendidos"].Rows.Count >= 1) {
				imgProducto6.ImageUrl = dst.Tables ["MVendidos"].Rows[0][4].ToString();
				lkbtnProducto6.Text = dst.Tables ["MVendidos"].Rows [0][1].ToString();
				lblProducto6.Text = "$ " + dst.Tables ["MVendidos"].Rows [0][2].ToString() + " c/" + dst.Tables ["MVendidos"].Rows [0][3].ToString();
			}
		}

		private void CargarDatos(){
			cmd.CommandText = "SELECT TOP(5) * FROM Productos WHERE UnidadesDidsponibles > 0 ORDER BY Fecha DESC ;";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			while(data.Read()){
				DataRow row;
				row = dst.Tables ["UAgregados"].NewRow ();
				row ["ID"] = data [0];
				row ["Nombre"] = data [2];
				row ["Precio"] = data [3];
				row ["UVenta"] = data [4];
				row ["Foto"] = data [6].ToString();
				dst.Tables ["UAgregados"].Rows.Add (row);
			}
			data.Close();

			cmd.CommandText = "SELECT TOP(5) * FROM Productos WHERE UnidadesDidsponibles > 0 ORDER BY Compras DESC;";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			while(data.Read()){
				DataRow row;
				row = dst.Tables ["MVendidos"].NewRow ();
				row ["ID"] = data [0];
				row ["Nombre"] = data [2];
				row ["Precio"] = data [3];
				row ["UVenta"] = data [4];
				row ["Foto"] = data [6].ToString();
				dst.Tables ["MVendidos"].Rows.Add (row);
			}
			data.Close();
		}

		private DataSet CrearEstructura(){
			DataSet dst = new DataSet ("base");
			DataTable tbl = new DataTable ("UAgregados") {
				Columns = {
					new DataColumn ("ID", Type.GetType ("System.Int32")),
					new DataColumn ("Nombre", Type.GetType ("System.String")),
					new DataColumn ("Precio", Type.GetType ("System.Double")),
					new DataColumn ("UVenta", Type.GetType ("System.String")),
					new DataColumn ("Foto", Type.GetType ("System.String"))
				}
			};
			dst.Tables.Add (tbl);
			tbl = new DataTable ("MVendidos") {
				Columns = {
					new DataColumn ("ID", Type.GetType ("System.Int32")),
					new DataColumn ("Nombre", Type.GetType ("System.String")),
					new DataColumn ("Precio", Type.GetType ("System.Double")),
					new DataColumn ("UVenta", Type.GetType ("System.String")),
					new DataColumn ("Foto", Type.GetType ("System.String"))
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

