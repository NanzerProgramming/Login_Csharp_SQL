using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region CONECCION
            SqlConnection conn = new SqlConnection("Password=7d26t13ar4;Persist Security Info=True;User ID=Nanzer_SQLLogin_1;Initial Catalog=ProyectoNanzerClima;Data Source=ProyectoNanzerClima.mssql.somee.com"); //CONEXION PÚBLICA
        #endregion

        #region EVENTOS
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            //Abro la db
            conn.Open();

            //Genero una consulta
            SqlCommand consulta = new SqlCommand("SELECT Usuario, Contrasena FROM Login WHERE Usuario = @Usu AND Contrasena = @Contra", conn);

            //Busco en la tabla los datos que se vinculan a los que ingresa el cliente por pantalla
            consulta.Parameters.AddWithValue("@Usu", txtUsu.Text);
            consulta.Parameters.AddWithValue("Contra", txtContra.Text);

            //Traigo los resultados
            SqlDataReader resultado = consulta.ExecuteReader();

            //Si son correctos me lleva al HOME
            if (resultado.Read())
            {
                conn.Close();
                Home pantalla = new Home();
                pantalla.Show();
            }
            //Si no son correctos me limpia los textbox para que cargue de nuevo!
            else
            {
                conn.Close();
                Clear();
                txtUsu.Focus();
            }
        }
        //Front
        private void txtUsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContra.Focus();
            }
        }
        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAcceder.Focus();
            }
        }
        private void Login_Shown(object sender, EventArgs e)
        {
            txtUsu.Focus();
        }
        #endregion

        #region FUNCIONES
        private void Clear()
        {
            txtUsu.Text = string.Empty;
            txtContra.Text = string.Empty;
        }
        #endregion

    }
}
