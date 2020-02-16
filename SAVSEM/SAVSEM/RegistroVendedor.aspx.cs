using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SAVSEM
{
	public partial class RegistroVendedor : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;

		protected void Page_Load(Object sender, EventArgs ev){
			//Depende de como esté la sesión se mostrará la pantalla.
			AbrirConexion();
			myPDF.Attributes.Add ("src", "docs/LicenciaUsoProductor.pdf");
			if (Session["user"]!=null) {
				sessionNoStart.Visible = false;
				if (Convert.ToBoolean (Session ["vendedor"].ToString ())) {
					cbxAceptar.Checked = true;
					cbxAceptar.Enabled = false;
					btnRegReg.Enabled = false;
					lbCondicion.Text = "Este usuario actualmente ya se encuentra registrado en el programa de vendedores.";
				} else {
					btnRegReg.Enabled = true;
					lbCondicion.Text = "";
				}
			} else {
				sessionNoStart.Visible = true;
				btnRegReg.Enabled = true;
				lbCondicion.Text = "";
			}
		}

		protected void btnRegReg_Click(Object sender, EventArgs e){
			//Verificamos que el usuario esté deacuerdo con los terminos y condiciones.
			if (cbxAceptar.Checked) {
				if (Session ["user"] != null) {
					cmd.CommandText = "UPDATE Usuarios SET Vendedor='True' WHERE Usuario='" + Session ["user"].ToString () + "';";
					cmd.Connection = sqlcnx;
					try {
						//Ejecutamos el query.
						cmd.ExecuteNonQuery ();
						Session ["vendedor"] = "True";

						//Mandamos a la página
						Response.Redirect ("RegistroVendedorExitoso.aspx");
					} catch (Exception ex) {
						lbCondicion.Text = "Ha ocurrido un error, intente de nuevo.";
					}
				} else {
					//Iniciamos sesión
					//Buscamos al usuario en la base de datos, y que coincida con su password.
					cmd.CommandText = "SELECT * FROM Usuarios WHERE Usuario='" + txtRegUser.Text + "' and Contrasenia='" + txtRegPass.Text + "';";
					cmd.Connection = sqlcnx;
					try{
						data = cmd.ExecuteReader();
						while(data.Read()){
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
						data.Close();
						if(Session["user"] != null){
							if(Convert.ToBoolean(Session["vendedor"].ToString())){
								lbCondicion.Text= "El usuario actualmente ya se encuentra inscrito como vendedor.";
								Response.Redirect (Request.Url.AbsolutePath);
							}else{
								//Ingresamos el query para actualizar el dato.
								cmd.CommandText = "UPDATE Usuarios SET Vendedor='True' WHERE Usuario='" + Session ["user"].ToString () + "';";
								cmd.Connection = sqlcnx;
								//Ejecutamos el query.
								cmd.ExecuteNonQuery ();
								//Actualizamos de manera local la variable Session["Vendedor"] para ahorrar una consulta simple a la base de Datos
								Session["vendedor"] = "True";
								//Recargamos la página pero ya con el usuario.
								Response.Redirect ("RegistroVendedorExitoso.aspx");
							}
						}else{
							//Mandamos que el usuario o contraseña son incorrectos.
							lbCondicion.Text= "El usuario o contraseña son incorrectos.";
						}
					}catch(Exception ex){
						//En caso de algun error desconocido, posiblemente sea
						//debido a que el usuario no anotó su usuario y contraseña o
						//pusó algun carácter no reconocido.
						lbCondicion.Text="Ha ocurrido un error, intentelo de nuevo.";
					}
				}
			} else {
				lbCondicion.Text = "Debes aceptar los términos y condiciones para poder registrate como vendedor.";
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

