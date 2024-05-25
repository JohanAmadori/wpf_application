using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace wpf_application.Pages
{
    public partial class Users : Page
    {
        // Objets nécessaires pour SQL
        const string _dsn = "server=localhost;port=3306;database=kuph3194_rap;username=kuph3194_johan;password=fah9NadTO$Qx;";
        private MySqlConnection _connexion = new MySqlConnection(_dsn);
        private MySqlCommand _command;
        private MySqlDataAdapter _adapter;

        private DataTable _dt;  // Ne fait pas partie de MySql.Data (objet .NET)
        public Users()
        {
            InitializeComponent();
            afficher();
        }
        private void afficher()
        {
            try
            {
                _adapter = new MySqlDataAdapter("SELECT * FROM users;", _connexion); // Instancie un adapter
                _dt = new DataTable();  // Instancie une DataTable
                _adapter.Fill(_dt);     // Adapter remplit la DataTable
                dgUsers.ItemsSource = _dt.DefaultView;  // Transfère les données de _dt vers dgRappeurs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void effacer()
        {
            txtId.Content = "";
            SAI_name.Text = "";
            SAI_password.Text = "";
            SAI_points.Text = "";
            SAI_tentatives.Text = "";

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string _sql = "INSERT INTO users(name, password, points, tentatives) VALUES(@name, @password, @points, @tentatives)";

            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@name", SAI_name.Text);
                _command.Parameters.AddWithValue("@password", SAI_password.Text);
                _command.Parameters.AddWithValue("@name", SAI_name.Text);
                _command.Parameters.AddWithValue("@tentatives", SAI_tentatives.Text);

                _connexion.Open();
                _command.ExecuteNonQuery();

                afficher();
                effacer();

                MessageBox.Show("User crée", "Nouvel user", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _command.Dispose();
                _connexion.Close();
            }


        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            string _sql = "UPDATE users SET name = @name, password = @password, points = @points, tentatives = @tentatives WHERE id = @Id";
            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@Id", txtId.Content);
                _command.Parameters.AddWithValue("@name", SAI_name.Text);
                _command.Parameters.AddWithValue("@password", SAI_password.Text);
                _command.Parameters.AddWithValue("@points", SAI_points.Text);
                _command.Parameters.AddWithValue("@tentatives", SAI_tentatives.Text);

                _connexion.Open();
                _command.ExecuteNonQuery();

                afficher();

                MessageBox.Show("User modifié", "changements User", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _command.Dispose();
                _connexion.Close();
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {

            string _sql = "DELETE FROM users WHERE id = @Id;";

            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@Id", txtId.Content);
                _connexion.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _command.Dispose();
                _connexion.Close();
            }

            afficher();
            effacer();
        }

        private void dgUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((DataRowView)dgUsers.SelectedItem != null)
            {
                DataRowView _drv = (DataRowView)dgUsers.SelectedItem;

                txtId.Content = _drv.Row["id"].ToString();  // Supposant que 'id' est le champ pour l'identifiant dans votre base de données
                SAI_name.Text = _drv.Row["name"].ToString();
                SAI_password.Text = _drv.Row["password"].ToString();
                SAI_points.Text = _drv.Row["points"].ToString();
                SAI_tentatives.Text = _drv.Row["tentatives"].ToString();

            }
        }


    }
}
