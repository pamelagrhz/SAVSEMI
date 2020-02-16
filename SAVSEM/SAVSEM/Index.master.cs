using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SAVSEM
{
	public partial class Index : System.Web.UI.MasterPage
	{
		string cnxstr = string.Empty;
		SqlConnection sqlcnx = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		SqlDataReader data;

		protected void Page_Load(Object sender, EventArgs ev){
			//Abrimos la conexión con la base de datos.
			AbrirConexion ();
			//Depende de como esté la sesión se mostrará la pantalla.
			if (Session["user"]!=null) {
				lgUser.Visible = false;
				userData.Visible = true;
				lblBienvenido.Text = "Bienvenido " + Session ["user"].ToString ();
				if (Convert.ToBoolean (Session ["vendedor"].ToString ())) {
					linkVenta.Visible = true;
				} else {
					linkVenta.Visible = false;
				}
			} else {
				lgUser.Visible = true;
				userData.Visible = false;
			}
		}

		protected void btnIngresar_Click(Object sender, EventArgs e)//Botón para que el usuario ingrese a su cuenta
		{
			//1)Buscamos al usuario en la base de datos, y que coincida con su password.
			cmd.CommandText = "SELECT * FROM Usuarios WHERE Usuario='" + lgUser.UserName + "' and Contrasenia='" + lgUser.Password + "';";
			cmd.Connection = sqlcnx;
			try{
				data = cmd.ExecuteReader();
				while(data.Read()){
					Session ["ID"] = data[0].ToString();
					Session ["nombre"] = data[1].ToString();
					Session ["apellido"] = data[2].ToString();
					Session ["direccion"] = data[3].ToString();
					Session ["cp"] = data[4].ToString();
					Session ["telefono"] = data[5].ToString();
					Session ["email"] = data[6].ToString();
					Session ["user"] = data[7].ToString();
					Session ["pass"] = data[8].ToString();
					Session ["admin"] = data[9].ToString();
					Session ["vendedor"] = data[10].ToString();
				}
				if(Session["user"] != null){
					//Recargamos la página pero ya con el usuario.
					Response.Redirect (Request.Url.AbsolutePath);
				}else{
					//Mandamos que el usuario o contraseña son incorrectos.
					lgUser.FailureText="El usuario o contraseña son incorrectos.";
				}
			}catch(Exception ex){
				//En caso de algun error desconocido, posiblemente sea
				//debido a que el usuario no anotó su usuario y contraseña o
				//pusó algun carácter no reconocido.
				lgUser.FailureText="Ha ocurrido un error, intentelo de nuevo.";
			}

		}

		protected void imbtnBuscar_Click(Object sender, EventArgs e)
		{
			if (txtBuscar.Text != "") {
				Session["busqueda"] = txtBuscar.Text;
				Response.Redirect ("Buscar.aspx");
			}
		}

		protected void linkCompra_Click(Object sender, EventArgs e)
		{
			Response.Redirect ("Compras.aspx");
		}

		protected void linkVenta_Click(Object sender, EventArgs e)
		{
			Response.Redirect ("Ventas.aspx");
		}

		protected void linkGestion_Click(Object sender, EventArgs e)//Botón para acceder al menú de gestión de la cuenta del usuario
		{
			Response.Redirect ("GestionUsuario.aspx");
		}

		protected void lnkbtnSalir_Click(Object sender, EventArgs e) //Botón para que el usuario finalice sesión
		{
			Session.Remove ("user");
			Response.Redirect ("~/");
		}

		private void AbrirConexion(){
			//1)Abrimos la conexión de la cadena
			cnxstr = System.Configuration.ConfigurationManager.ConnectionStrings ["SQLServer2017"].ConnectionString;

			//2)Abrir la conexión con la base de datos
			sqlcnx.ConnectionString = cnxstr;
			sqlcnx.Open ();
		}

		private void CerrarConexion(){
			//Cerramos la conexión con la base de datos.
			sqlcnx.Close();
		}
	}
}