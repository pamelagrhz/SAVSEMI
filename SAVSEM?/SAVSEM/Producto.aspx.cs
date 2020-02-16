using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SAVSEM
{
	public partial class Producto : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;
		DataSet dst;

		protected void Page_Load(Object sender, EventArgs e){
			AbrirConexion ();
			CargarDatos ();
			if (!IsPostBack) {
				if (Session ["user"] != null) {
					btnPedir.Enabled = true;
				} else {
					btnPedir.Enabled = false;
					errorCompra.Text = "Necesitas iniciar sesión para poder solicitar un pedido.";
				}
			}
		}

		protected void lkbtnCalcular_Click(Object sender, EventArgs e)
		{
			txtCostTotal.Text = "$ " + (Convert.ToDouble (txtUniCompra.Text) * Convert.ToDouble (precioProducto.Text)).ToString("0.00");
		}

		protected void txtUniCompra_TextChanged(Object sender, EventArgs e)
		{
			txtCostTotal.Text = "$ " + (Convert.ToDouble (txtUniCompra.Text) * Convert.ToDouble (precioProducto.Text)).ToString("0.00");
		}

		protected void btnPedir_Click(Object sender, EventArgs e)
		{
			//Obtenemos los datos del producto para observar que
			//en lo que el usuario decide, no se haya realizado otra compra

			CargarDatos();
			//Validamos el caso de que deje la caja vacia.
			if (txtUniCompra.Text == "") {
				errorCompra.Text = "Debe definir las unidades que va a requerir.";
				txtUniCompra.Focus ();
			} else {
				//Validamos de que las unidades que va a pedir son positivas
				if (Convert.ToDouble (txtUniCompra.Text) > 0) {
					//Verificamos que aún quede producto disponible
					if (Convert.ToInt32 (txtUniCompra.Text) <= Convert.ToInt32 (uDisProducto.Text)) {
						//Obtenemos los datos del pedido
						DateTime dt = DateTime.Now;
						string fecha = String.Format ("{0:yyy-MM-dd HH:mm:ss}", dt); 
						string correoVendedor = emailProducto.Text;
						string cantidad = txtUniCompra.Text;
						string precUni = precioProducto.Text;
						string precTotal = (Convert.ToDouble (cantidad) * Convert.ToDouble (precUni)).ToString ("0.00");


						//Registramos el pedido
						cmd.CommandText = "INSERT INTO Pedidos(CompradorID, Producto, Cantidad, PrecioUnitario, PrecioTotal, Fecha, CorreoVendedor)" +
						"VALUES (" + Session ["ID"].ToString () + ", " + Session ["ProductoID"].ToString () + ", " + cantidad + "," +
						" " + precUni + ", " + precTotal + ", '" + fecha + "', '" + correoVendedor + "');";
						cmd.Connection = sqlcnx;
						try {
							cmd.ExecuteNonQuery ();

							//Disminuimos la cantidad de producto en disponibilidad.
							string unidades = (Convert.ToDouble (uDisProducto.Text) - Convert.ToDouble (cantidad)).ToString ();
							cmd.CommandText = "UPDATE Productos SET UnidadesDidsponibles=" + unidades + "WHERE ID=" + Session ["ProductoID"].ToString () + ";";
							cmd.ExecuteNonQuery ();

							int compra = 0;
							string nombreProd = string.Empty;
							string vendedorID = string.Empty;
							cmd.CommandText = "SELECT * FROM Productos WHERE ID='" + Session ["ProductoID"].ToString () + "';";
							data = cmd.ExecuteReader ();
							while (data.Read ()) {
								vendedorID = data[1].ToString();
								nombreProd = data [2].ToString ();
								compra = Convert.ToInt32 (data [9].ToString ());
							}
							data.Close ();
							compra++;

							cmd.CommandText = "UPDATE Productos SET Compras='" + compra + "' WHERE ID='" + Session ["ProductoID"].ToString () + "';";
							cmd.ExecuteNonQuery ();

							//Registramos en ambos historiales
							//Usuario
							cmd.CommandText = "INSERT INTO Historial(UsuarioID, Accion, Fecha)" +
								"VALUES (" + Session["ID"].ToString() + ", 'Compró " + cantidad + " unidades de " + nombreProd + "" +
								"con un total de $" + (Convert.ToDouble(precTotal)).ToString("0.00") + ".', '" + fecha + "');";
							cmd.ExecuteNonQuery ();

							//Vendedor
							cmd.CommandText = "INSERT INTO Historial(UsuarioID, Accion, Fecha)" +
								"VALUES (" + vendedorID + ", 'Vendió a " + Session["nombre"].ToString() + " " + Session["apellido"].ToString() + cantidad + " unidades de " + nombreProd + "" +
								"con un total de $" + (Convert.ToDouble(precTotal)).ToString("0.00") + ".', '" + fecha + "');";
							cmd.ExecuteNonQuery ();

							//Redirigimos al usuario
							Response.Redirect ("Compras.aspx");
						} catch (Exception ex) {
							errorCompra.Text = "Ha ocurrido un error. Por favor, intentelo de nuevo." ;
						}
					} else {
						errorCompra.Text = "No hay suficiente producto para vender, lo sentimos.";
					}
				} else {
					errorCompra.Text = "Debes pedir unidades mayores a 0.";
				}
			}
		}

		private void CargarDatos(){
			string vendedorID = string.Empty;
			//Obtenemos los datos del producto
			cmd.CommandText = "SELECT * FROM Productos WHERE ID='" + Session["ProductoID"].ToString() + "';";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			while (data.Read ()) {
				tituloProducto.Text = data[2].ToString();
				imageProducto.ImageUrl = data[6].ToString();
				precioProducto.Text = (Convert.ToDouble(data [3])).ToString ("0.00");
				unidadProducto.Text = " c/" + data[4].ToString();
				uDisProducto.Text = data[5].ToString();
				comProducto.Text = data [8].ToString ();
				vendedorID = data [1].ToString ();
			}
			data.Close();
			//Obtenemos la información del productor.
			cmd.CommandText = "SELECT * FROM Usuarios WHERE ID='" + vendedorID + "';";
			data = cmd.ExecuteReader ();
			while (data.Read ()) {
				VendedorProducto.Text = data[1].ToString() + " " + data[2].ToString();
				emailProducto.Text = data[6].ToString();
			}
			data.Close();
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

