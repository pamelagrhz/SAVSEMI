using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace SAVSEM
{
	public partial class Ayuda : System.Web.UI.Page
	{
		string cnxstr = string.Empty;
		SqlConnection sqlcnx = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		SqlDataAdapter data = new SqlDataAdapter();
		DataSet us = new DataSet();

		protected void Page_Load(Object sender, EventArgs ev){
			//Abrimos la conexión
			AbrirConexion ();

			//Habilitaremos la sección de poner el correo en caso de que el usuario no esté registrado
			if (Session ["user"] != null) {
				userSession.Visible = false;
			} else {
				userSession.Visible = true;
			}
		}

		protected void btnAyEnviar_Click(Object sender, EventArgs e)
		{
			//1)Suponemos desde el principio que el usuario no está registrado
			//por ello tomamos el correo aunque este vacio.
			DateTime dt = DateTime.Now;
			string fecha = String.Format ("{0:yyy-MM-dd HH:mm:ss}", dt); 
			bool usuario = false;
			string correo = txtAyTexto.Text;

			//2)Definimos la conexión a la base de datos
			cmd.Connection = sqlcnx;

			//3)Verificamos que el usuario haya llenado todos los campos
			if(txtAyMensaje.Text == "" || (txtAyTexto.Text == "" && Session["user"] == null)){
				messageError.Text = "Por favor, llene todos los datos debidamente";
			}else{		
				//4)Verificamos si ya es un usuario con cuenta.
				if(Session["user"]!=null){
					//4.1)Debido a que el usuario ya tiene cuenta, obtenemos el dato desde su sesión.
					correo = Session["email"].ToString();
				}
				//5)Ingresamos el mensaje a la Base de datos
				cmd.CommandText = "INSERT INTO Mensaje(Destinatario, IsUsuario, Mensaje, Fecha) " +
					"VALUES('" + correo +  "', '" + usuario.ToString() + "', '" + txtAyMensaje.Text + "', '" + fecha + "');";
				try{
					cmd.ExecuteNonQuery();
					txtAyTexto.Text = "";
					txtAyMensaje.Text = "";
				}catch(Exception ex){
					messageError.Text = "Ha ocurrido algun error, no se pudo mandar el mensaje." + ex;
				}
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
			//Cerramos la conexión con la base de datos.
			sqlcnx.Close();
		}
	}
}

