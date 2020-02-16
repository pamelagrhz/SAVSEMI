using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SAVSEM
{
	public partial class Registro : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;

		protected void Page_Load(Object sender, EventArgs ev){
			AbrirConexion ();
			myPDF.Attributes.Add ("src", "docs/LicenciaUsoComprador.pdf");
		}

		protected void btnRegistrar_Click(Object sender, EventArgs e)
		{
			//1)Obtenemos los datos del formulario dado al usuario
			string nombre = txtNombre.Text;
			string apellidos = txtApellidos.Text;
			string direccion = txtDireccion.Text;
			string cp = txtCP.Text;
			string telefono = txtTelefono.Text;
			string correo = txtCorreo.Text;
			string usuario = txtUsuario.Text;
			string pass = txtContrasenia.Text;
			string passRept = txtContraseniaRep.Text;
			bool registrar = true;
			//2)Lo registraremos sólo si a marcado el CheckBox de que acepta las condiciones del servicio.
			if (cbxAceptar.Checked 
				&& (pass == passRept)
				&& nombre != ""
				&& apellidos != ""
				&& direccion != ""
				&& cp != ""
				&& telefono != ""
				&& correo != ""
				&& usuario != ""
				&& pass != ""
				&& passRept != ""){
				lbCondicion.Text = "";

				//3)Buscamos que el usuario no se haya registrado antes en base a su email
				cmd.CommandText = "SELECT * FROM Usuarios WHERE Correo='" + correo + "';";
				cmd.Connection = sqlcnx;
				try {
					//Ejecutamos el query
					data = cmd.ExecuteReader ();
					while (data.Read ()) {
						if (data [6].ToString () == correo) {
							registrar = false;
							lbCondicion.Text = "Este correo ya ha sido previamente registrado. Si ha olvidado su contraseña consulte la sección de Ayuda.";
						}
					}
					data.Close ();
				} catch (Exception ex) {
					lbCondicion.Text = "Ha ocurrido un error, intente de nuevo.";
					registrar = false;
				}

				if (registrar) {
					//4)Buscamos que no exista un nombre de usuario identico
					cmd.CommandText = "SELECT * FROM Usuarios WHERE Usuario='" + usuario + "';";
					cmd.Connection = sqlcnx;
					try {
						//Ejecutamos el query
						data = cmd.ExecuteReader ();
						string getdata = string.Empty;
						while (data.Read ()) {
							getdata = data [7].ToString ();
							if (data [7].ToString () == usuario) {
								registrar = false;
								lbCondicion.Text = "Este nombre de usuario ya está en uso. Pruebo con otro nombre de usuario.";
							}
						}
						data.Close ();
					} catch (Exception ex) {
						lbCondicion.Text = "Ha ocurrido un error, intente de nuevo.";
						registrar = false;
					}
				}
				if (registrar) {
					//5)Preparamos el query y lo ejecutamos
					cmd.CommandText = "INSERT INTO Usuarios(Nombre, Apellidos, Direccion, CP, Telefono, Correo, Usuario, Contrasenia, Administrador, Vendedor) VALUES('" + nombre + "', '" + apellidos + "', '" + direccion + "', '" + cp + "', '" + telefono + "', '" + correo + "', '" + usuario + "', '" + pass + "', 'False', 'False');";
					cmd.Connection = sqlcnx;
					try {
						//Ejecutamos el query.
						cmd.ExecuteNonQuery ();

						//Iniciamos sesion
						cmd.CommandText = "SELECT * FROM Usuarios WHERE Usuario='" + usuario + "' and Contrasenia='" + pass + "';";
						cmd.Connection = sqlcnx;
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

						//6)Mandamos a la página
						Response.Redirect ("RegistroExitoso.aspx");
					} catch (Exception ex) {
						lbCondicion.Text = "Ha ocurrido un error, intente de nuevo.";
					}
				}
			} else if (!cbxAceptar.Checked) {
				//En caso de que no se haya tildado el checkbox.
				lbCondicion.Text = "Debes de aceptar los términos y condiciones para poder registrarte.";
			} else if (pass != passRept) {
				//En caso de que la contraseña no coincida, le solicitaremos que la ingrese de nuevo.
				lbCondicion.Text = "La contraseña no coincide, intentelo de nuevo.";
				txtContrasenia.Text = "";
				txtContraseniaRep.Text = "";
			} else {
				//En caso de que algun dato falte.
				lbCondicion.Text = "Todos los datos deben estár correctamente llenados.";
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

