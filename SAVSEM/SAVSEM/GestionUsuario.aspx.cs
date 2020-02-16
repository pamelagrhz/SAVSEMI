using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace SAVSEM
{
	public partial class GestionUsuario : System.Web.UI.Page
	{
		private string cnxstr = string.Empty;
		private SqlConnection sqlcnx = new SqlConnection();
		private SqlCommand cmd = new SqlCommand();
		private SqlDataReader data;

		DataSet dst;

		protected void Page_Load(Object sender, EventArgs ev){
			AbrirConexion ();

			dst = CrearEstructura ();
			CargarHistorial ();
			tbHistorial.DataSource = dst.Tables [0];

			//Cargamos la información
			lblGesUser.Text = Session["user"].ToString();
			lblGesNombre.Text = Session["nombre"].ToString();
			lblGesApellido.Text = Session["apellido"].ToString();
			lblGesDireccion.Text = Session["direccion"].ToString();
			lblGesCP.Text = Session["cp"].ToString();
			lblGesTelefono.Text = Session["telefono"].ToString();
			lblGesCorreo.Text = Session["email"].ToString();

			if (!IsPostBack) {
				errorUserGes.Text = "";

				//Usuario
				lblGesUsuarioMod.Visible = false;
				txtGesUser.Visible = false;
				lkbtnGesUserConfirm.Visible = false;
				//Password
				lblGesOldPassMod.Visible = false;
				txtGesOldPass.Visible = false;
				lblGesPassMod.Visible = false;
				txtGesPass.Visible = false;
				lblGesPassConfMod.Visible = false;
				txtGesPassConfirm.Visible = false;
				lkbtnGesPassConfirm.Visible = false;
				//Nombre
				lblGesNombreMod.Visible = false;
				txtGesNombre.Visible = false;
				lkbtnGesNombreConfirm.Visible = false;
				//Apellidos
				lblGesApellidoMod.Visible = false;
				txtGesApellido.Visible = false;
				lkbtnGesApellidoConfirm.Visible = false;
				//Dirección
				lblGesDireccionMod.Visible = false;
				txtGesDireccion.Visible = false;
				lkbtnGesDireccionConfirm.Visible = false;
				//Código postal
				lblGesCPMod.Visible = false;
				txtGesCP.Visible = false;
				lkbtnGesCPConfirm.Visible = false;
				//Telefono
				lblGesTelefonoMod.Visible = false;
				txtGesTelefono.Visible = false;
				lkbtnGesTelefonoConfirm.Visible = false;
				//Correo
				lblGesCorreoMod.Visible = false;
				txtGesCorreo.Visible = false;
				lkbtnGesCorreoConfirm.Visible = false;

				this.DataBind ();
			}
		}

		protected void lkbtnGesUser_Click(Object sender, EventArgs e)
		{
			if (lkbtnGesUser.Text == "Editar") {
				lblGesUsuarioMod.Visible = true;
				txtGesUser.Visible = true;
				lkbtnGesUser.Text = "Cancelar";
				lkbtnGesUserConfirm.Visible = true;
			} else {
				lblGesUsuarioMod.Visible = false;
				txtGesUser.Visible = false;
				txtGesUser.Text = "";
				lkbtnGesUser.Text = "Editar";
				lkbtnGesUserConfirm.Visible = false;
			}
		}

		protected void lkbtnGesUserConfirm_Click(Object sender, EventArgs e)
		{
			bool registro = true;
			cmd.CommandText = "SELECT * FROM Usuarios WHERE Usuario='" + txtGesUser.Text + "';";
			cmd.Connection = sqlcnx;
			try {
				//Ejecutamos el query
				data = cmd.ExecuteReader ();
				while (data.Read ()) {
					if (data [7].ToString () == txtGesUser.Text) {
						errorUserGes.Text = "Este nombre de usuario ya está en uso. Pruebo con otro nombre de usuario.";
						registro = false;
					}
				}
				data.Close ();
				if(registro){
					cmd.CommandText = "UPDATE Usuarios SET Usuario='" + txtGesUser.Text + "' WHERE ID='" + Session["ID"].ToString() + "';";
					cmd.Connection = sqlcnx;
					try{
						cmd.ExecuteNonQuery ();
						errorUserGes.Text = "";
						CargarDatos();
						Response.Redirect("GestionUsuario.aspx");
					}catch(Exception ex){
						errorUserGes.Text = "Ha ocurrido un error, por favor intentelo de nuevo.";
					}
				}
			} catch (Exception ex) {
				errorUserGes.Text = "Ha ocurrido un error, intente de nuevo.";
			}
		}

		protected void lkbtnGesPass_Click(Object sender, EventArgs e)
		{
			if (lkbtnGesPass.Text == "Editar") {
				lkbtnGesPass.Text = "Cancelar";
				lblGesOldPassMod.Visible = true;
				txtGesOldPass.Visible = true;
				lblGesPassMod.Visible = true;
				txtGesPass.Visible = true;
				lblGesPassConfMod.Visible = true;
				txtGesPassConfirm.Visible = true;
				lkbtnGesPassConfirm.Visible = true;
			} else {
				lkbtnGesPass.Text = "Editar";
				lblGesOldPassMod.Visible = false;
				txtGesOldPass.Visible = false;
				lblGesPassMod.Visible = false;
				txtGesPass.Visible = false;
				lblGesPassConfMod.Visible = false;
				txtGesPassConfirm.Visible = false;
				lkbtnGesPassConfirm.Visible = false;

				txtGesOldPass.Text = "";
				txtGesPass.Text = "";
				txtGesPassConfirm.Text = "";
			}
		}

		protected void lkbtnGesPassConfirm_Click(Object sender, EventArgs e)
		{
			if (txtGesOldPass.Text == Session ["pass"].ToString ()) {
				if (txtGesPass.Text == txtGesPassConfirm.Text) {
					cmd.CommandText = "UPDATE Usuarios SET Contrasenia='" + txtGesPass.Text + "' WHERE ID='" + Session ["ID"].ToString () + "';";
					cmd.Connection = sqlcnx;
					try {
						cmd.ExecuteNonQuery ();
						errorUserGes.Text = "";
						CargarDatos ();
						Response.Redirect ("GestionUsuario.aspx");
					} catch (Exception ex) {
						errorUserGes.Text = "Ha ocurrido un error, por favor intentelo de nuevo.";
					}
				} else {
					txtGesPass.Text = "";
					txtGesPassConfirm.Text = "";
					errorUserGes.Text = "La contraseña nueva no se confirmo correctamente.";
				}
			} else {
				txtGesOldPass.Text = "";
				errorUserGes.Text = "La contraseña actual no es igual a la que se coloco en \"Contraseña anterior\".";
			}
		}

		protected void lkbtnGesNombre_Click(Object sender, EventArgs e)
		{			
			if (lkbtnGesNombre.Text == "Editar") {
				lkbtnGesNombre.Text = "Cancelar";
				lblGesNombreMod.Visible = true;
				txtGesNombre.Visible = true;
				lkbtnGesNombreConfirm.Visible = true;

			} else {
				lkbtnGesNombre.Text = "Editar";
				txtGesNombre.Text = "";
				lblGesNombreMod.Visible = false;
				txtGesNombre.Visible = false;
				lkbtnGesNombreConfirm.Visible = false;
			}
		}

		protected void lkbtnGesNombreConfirm_Click(Object sender, EventArgs e)
		{
			cmd.CommandText = "UPDATE Usuarios SET Nombre='" + txtGesNombre.Text + "' WHERE ID='" + Session ["ID"].ToString () + "';";
			cmd.Connection = sqlcnx;
			try {
				cmd.ExecuteNonQuery ();
				errorUserGes.Text = "";
				CargarDatos ();
				Response.Redirect ("GestionUsuario.aspx");
			} catch (Exception ex) {
				errorUserGes.Text = "Ha ocurrido un error, por favor intentelo de nuevo.";
			}
		}

		protected void lkbtnGesApellido_Click(Object sender, EventArgs e)
		{
			if (lkbtnGesApellido.Text == "Editar") {
				lkbtnGesApellido.Text = "Cancelar";
				lblGesApellidoMod.Visible = true;
				txtGesApellido.Visible = true;
				lkbtnGesApellidoConfirm.Visible = true;
			} else {
				lkbtnGesApellido.Text = "Editar";
				txtGesApellido.Text = "";
				lblGesApellidoMod.Visible = false;
				txtGesApellido.Visible = false;
				lkbtnGesApellidoConfirm.Visible = false;
			}
		}

		protected void lkbtnGesApellidoConfirm_Click(Object sender, EventArgs e)
		{
			cmd.CommandText = "UPDATE Usuarios SET Apellidos='" + txtGesApellido.Text + "' WHERE ID='" + Session ["ID"].ToString () + "';";
			cmd.Connection = sqlcnx;
			try {
				cmd.ExecuteNonQuery ();
				errorUserGes.Text = "";
				CargarDatos ();
				Response.Redirect ("GestionUsuario.aspx");
			} catch (Exception ex) {
				errorUserGes.Text = "Ha ocurrido un error, por favor intentelo de nuevo.";
			}
		}

		protected void lkbtnGesDireccion_Click(Object sender, EventArgs e)
		{
			if (lkbtnGesDireccion.Text == "Editar") {
				lkbtnGesDireccion.Text = "Cancelar";
				lblGesDireccionMod.Visible = true;
				txtGesDireccion.Visible = true;
				lkbtnGesDireccionConfirm.Visible = true;
			} else {
				lkbtnGesDireccion.Text = "Editar";
				txtGesDireccion.Text = "";
				lblGesDireccionMod.Visible = false;
				txtGesDireccion.Visible = false;
				lkbtnGesDireccionConfirm.Visible = false;
			}
		}

		protected void lkbtnGesDireccionConfirm_Click(Object sender, EventArgs e)
		{
			cmd.CommandText = "UPDATE Usuarios SET Direccion='" + txtGesDireccion.Text + "' WHERE ID='" + Session ["ID"].ToString () + "';";
			cmd.Connection = sqlcnx;
			try {
				cmd.ExecuteNonQuery ();
				errorUserGes.Text = "";
				CargarDatos ();
				Response.Redirect ("GestionUsuario.aspx");
			} catch (Exception ex) {
				errorUserGes.Text = "Ha ocurrido un error, por favor intentelo de nuevo.";
			}
		}

		protected void lkbtnGesCP_Click(Object sender, EventArgs e)
		{
			if (lkbtnGesCP.Text == "Editar") {
				lkbtnGesCP.Text = "Cancelar";
				lblGesCPMod.Visible = true;
				txtGesCP.Visible = true;
				lkbtnGesCPConfirm.Visible = true;
			} else {
				lkbtnGesCP.Text = "Editar";
				txtGesCP.Text = "";
				lblGesCPMod.Visible = false;
				txtGesCP.Visible = false;
				lkbtnGesCPConfirm.Visible = false;
			}
		}

		protected void lkbtnGesCPConfirm_Click(Object sender, EventArgs e)
		{
			cmd.CommandText = "UPDATE Usuarios SET CP='" + txtGesCP.Text + "' WHERE ID='" + Session ["ID"].ToString () + "';";
			cmd.Connection = sqlcnx;
			try {
				cmd.ExecuteNonQuery ();
				errorUserGes.Text = "";
				CargarDatos ();
				Response.Redirect ("GestionUsuario.aspx");
			} catch (Exception ex) {
				errorUserGes.Text = "Ha ocurrido un error, por favor intentelo de nuevo.";
			}
		}

		protected void lkbtnGesTelefono_Click(Object sender, EventArgs e)
		{
			if (lkbtnGesTelefono.Text == "Editar") {
				lkbtnGesTelefono.Text = "Cancelar";
				lblGesTelefonoMod.Visible = true;
				txtGesTelefono.Visible = true;
				lkbtnGesTelefonoConfirm.Visible = true;
			}else{
				lkbtnGesTelefono.Text = "Editar";
				txtGesTelefono.Text = "";
				lblGesTelefonoMod.Visible = false;
				txtGesTelefono.Visible = false;
				lkbtnGesTelefonoConfirm.Visible = false;
			}
		}

		protected void lkbtnGesTelefonoConfirm_Click(Object sender, EventArgs e)
		{
			cmd.CommandText = "UPDATE Usuarios SET Telefono='" + txtGesTelefono.Text + "' WHERE ID='" + Session ["ID"].ToString () + "';";
			cmd.Connection = sqlcnx;
			try {
				cmd.ExecuteNonQuery ();
				errorUserGes.Text = "";
				CargarDatos ();
				Response.Redirect ("GestionUsuario.aspx");
			} catch (Exception ex) {
				errorUserGes.Text = "Ha ocurrido un error, por favor intentelo de nuevo.";
			}
		}

		protected void lkbtnGesCorreo_Click(Object sender, EventArgs e)
		{
			if (lkbtnGesCorreo.Text == "Editar") {
				lkbtnGesCorreo.Text = "Cancelar";
				lblGesCorreoMod.Visible = true;
				txtGesCorreo.Visible = true;
				lkbtnGesCorreoConfirm.Visible = true;
			} else {
				lkbtnGesCorreo.Text = "Editar";
				txtGesCorreo.Text = "";
				lblGesCorreoMod.Visible = false;
				txtGesCorreo.Visible = false;
				lkbtnGesCorreoConfirm.Visible = false;
			}
		}

		protected void lkbtnGesCorreoConfirm_Click(Object sender, EventArgs e)
		{
			bool registro = true;
			cmd.CommandText = "SELECT * FROM Usuarios WHERE Correo='" + txtGesCorreo.Text + "';";
			cmd.Connection = sqlcnx;
			try {
				//Ejecutamos el query
				data = cmd.ExecuteReader ();
				while (data.Read ()) {
					if (data [6].ToString () == txtGesCorreo.Text) {
						errorUserGes.Text = "Este correo ya está en uso. Pruebo con otro correo.";
						registro = false;
					}
				}
				data.Close ();
				if(registro){
					cmd.CommandText = "UPDATE Usuarios SET Correo='" + txtGesCorreo.Text + "' WHERE ID='" + Session["ID"].ToString() + "';";
					cmd.Connection = sqlcnx;
					try{
						cmd.ExecuteNonQuery ();
						errorUserGes.Text = "";
						CargarDatos();
						Response.Redirect("GestionUsuario.aspx");
					}catch(Exception ex){
						errorUserGes.Text = "Ha ocurrido un error, por favor intentelo de nuevo.";
					}
				}
			} catch (Exception ex) {
				errorUserGes.Text = "Ha ocurrido un error, intente de nuevo.";
			}
		}

		private void AbrirConexion(){
			//1)Abrimos la conexión de la cadena
			cnxstr = System.Configuration.ConfigurationManager.ConnectionStrings ["SQLServer2017"].ConnectionString;

			//2)Abrir la conexión con la base de datos
			sqlcnx.ConnectionString = cnxstr;
			sqlcnx.Open ();
		}

		private void CargarDatos(){
			cmd.CommandText = "SELECT * FROM Usuarios WHERE ID='" + Session["ID"].ToString() + "';";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			while(data.Read()){
				Session ["nombre"] = data[1].ToString();
				Session ["apellido"] = data[2].ToString();
				Session ["direccion"] = data[3].ToString();
				Session ["cp"] = data[4].ToString();
				Session ["telefono"] = data[5].ToString();
				Session ["email"] = data[6].ToString();
				Session ["user"] = data[7].ToString();
				Session ["pass"] = data[8].ToString();
			}
			data.Close ();
		}

		private void CargarHistorial (){
			cmd.CommandText = "SELECT * FROM Historial WHERE UsuarioID=" + Session["ID"].ToString() + ";";
			cmd.Connection = sqlcnx;
			data = cmd.ExecuteReader ();
			if (dst.Tables [0].Rows.Count > 0) {
				dst.Tables [0].Rows.Clear ();
			}
			while(data.Read()){
				DataRow row;
				row = dst.Tables [0].NewRow ();
				row["Fecha"] = data[2].ToString();
				row["Actividad"] = data[3].ToString();
				dst.Tables [0].Rows.Add (row);
			}
			data.Close ();
		}

		private DataSet CrearEstructura(){
			DataSet dst = new DataSet ("base");
			DataTable tbl = new DataTable ("Historial") {
				Columns = {
					new DataColumn ("Fecha", Type.GetType("System.String")),
					new DataColumn ("Actividad", Type.GetType("System.String"))
				}
			};
			dst.Tables.Add (tbl);

			return dst;
		}

		private void CerrarConexion(){
			sqlcnx.Close();
		}
	}
}