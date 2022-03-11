/// <summary>
/// Rosales Martínez Javier
/// 210509386
/// j.rosales@alumnos.udg.mx
/// 05-03-22 10:00
/// </summary>
using System;
using System.Windows.Forms;
using MySqlConnector;
using Npgsql;

namespace ConexionMySQL
{
    /// <summary>
    /// Creación del formulario Conexión SQL
    /// </summary>
    public partial class ConexionSQL : Form
    {
        #region Propiedades
        private MySqlConnection conexionMySQL;
        private NpgsqlConnection conexionPostgre;
        #endregion

        #region Constructor
        public ConexionSQL()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Creación del evento click del botón conectar
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHost.Text))
            {
                MessageBox.Show("El HOST es capmpo requerido");
                return;
            }
            else if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("El USER es capmpo requerido");
                return;
            }
            else if (string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("La PWD es capmpo requerido");
                return;
            }
            if (cbbGestor.Text == "MySQL")
            {
                try
                {
                    conexionMySQL = new MySqlConnection();
                    conexionMySQL.ConnectionString = "server=" + txtHost.Text + ";" + "user id=" + txtUser.Text + ";" + "password=" + txtPwd.Text + ";";
                    conexionMySQL.Open();
                    MessageBox.Show("LA CONEXIÓN SE REALIZÓ CORRECTAMENTE");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Hubo un error al conectar!: " + ex.Message);
                }
                finally
                {
                    if (conexionMySQL.State == System.Data.ConnectionState.Open)
                        conexionMySQL.Close();
                }
            }
            else 
            {
                if (string.IsNullOrEmpty(txtDB.Text))
                {
                    MessageBox.Show("La DB es capmpo requerido");
                    return;
                }
                try
                {
                    conexionPostgre = new NpgsqlConnection();
                    conexionPostgre.ConnectionString = "Server = " + txtHost.Text + ";" + "Port = " + txtPort.Text + ";" + "Database = " + txtDB.Text + ";" + "User Id=" + txtUser.Text + ";" + "Password=" + txtPwd.Text + ";";
                    conexionPostgre.Open();
                    MessageBox.Show("LA CONEXIÓN SE REALIZÓ CORRECTAMENTE");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Hubo un error al conectar!: " + ex.Message);
                }
                finally
                {
                    if (conexionPostgre.State == System.Data.ConnectionState.Open)
                        conexionPostgre.Close();
                }
            }
        }

        /// <summary>
        /// Creación del evento Checked del checkBoxPwd
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void checkBoxPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPwd.Checked)
            {
                txtPwd.UseSystemPasswordChar = false;
            }
            else
            {
                txtPwd.UseSystemPasswordChar = true;
            }
        }
        #endregion
    }
}
