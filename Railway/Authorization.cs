using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Railway {

    public partial class Authorization : Form {

        public Authorization() {
            InitializeComponent();
            InitializeListeners();
        }

        private void InitializeListeners() {

            /*
             \ Auth buttons listeners
             */
            authWithCredentialButton.Click  += AuthWithCredentialButton_Click;
            authWithWindowsButton.Click     += AuthWithWindowsButton_Click;

            /*
             \ Input switches
             */
            activateDatabaseName.Click  += ActivateDatabaseName_Click;
            activateServerName.Click    += ActivateServerName_Click;

        }

        /*
         \ Switching
         */

        private void ActivateServerName_Click(object sender, EventArgs e) {
            SwitchServerNameInput();
        }

        private void ActivateDatabaseName_Click(object sender, EventArgs e) {
            SwitchDatabaseNameInput();
        }

        private void SwitchDatabaseNameInput() {

            if (activateDatabaseName.Checked) {
                databaseNameField.Enabled = true;
                databaseNameField.Text = "";
            } else {
                databaseNameField.Enabled = false;
                databaseNameField.Text = "corsew";
            }
        }

        private void SwitchServerNameInput() {

            if (activateServerName.Checked) {
                serverNameField.Enabled = true;
                serverNameField.Text = "";
            } else {
                serverNameField.Enabled = false;
                serverNameField.Text = "DESKTOP-KJBH8PO\\SQLEXPRESS";
            }
        }


        /*
         \ Authorization
         */

        private void AuthWithWindowsButton_Click(object sender, EventArgs e) {
            AuthWithWindows();
        }

        private void AuthWithCredentialButton_Click(object sender, EventArgs e) {
            AuthWithCredential();
        }

        private void AuthWithWindows() {
            var config                      = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection    = (ConnectionStringsSection) config.GetSection("connectionStrings");

            connectionStringsSection
                .ConnectionStrings["DbConnectionString"]
                .ConnectionString = $"Integrated Security=true;Persist Security Info=false;Initial Catalog={databaseNameField.Text};Data Source={serverNameField.Text}";

            using (SqlConnection sqlConnection = new SqlConnection(connectionStringsSection.ConnectionStrings["DbConnectionString"].ConnectionString)) {

                try {
                    sqlConnection.Open();
                } catch (SqlException) {
                    MessageBox.Show("Неправильный логин или пароль!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            RunMainWindow();
        }

        private void AuthWithCredential() {
            var config                      = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection    = (ConnectionStringsSection) config.GetSection("connectionStrings");

            connectionStringsSection
                .ConnectionStrings["DbConnectionString"]
                .ConnectionString = $"Password={passwordField.Text};Persist Security Info=false;User ID={loginFeild.Text};Initial Catalog={databaseNameField.Text};Data Source={serverNameField.Text}";

            using (SqlConnection sqlConnection = new SqlConnection(connectionStringsSection.ConnectionStrings["DbConnectionString"].ConnectionString)) {

                try {
                    sqlConnection.Open();
                } catch (SqlException) {
                    MessageBox.Show("Неправильный логин или пароль!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            RunMainWindow();
        }

        /// <summary>
        /// Run main window after auth
        /// </summary>
        private void RunMainWindow() {
            new Railway().Show();
            Close();
        }

    }
}
