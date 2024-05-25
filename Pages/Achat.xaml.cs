using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace wpf_application.Pages
{
    public partial class Achat : Page
    {
        // Objets nécessaires pour SQL
        const string _dsn = "server=localhost;port=3306;database=kuph3194_rap;username=kuph3194_johan;password=fah9NadTO$Qx;";
        private MySqlConnection _connexion = new MySqlConnection(_dsn);
        private MySqlCommand _command;
        private MySqlDataAdapter _adapter;

        private DataTable _dt;  // Ne fait pas partie de MySql.Data (objet .NET)
        public Achat()
        {
            InitializeComponent();
            afficher();
        }
        private void afficher()
        {
            try
            {
                _adapter = new MySqlDataAdapter("SELECT * FROM paniers;", _connexion); // Instancie un adapter
                _dt = new DataTable();  // Instancie une DataTable
                _adapter.Fill(_dt);     // Adapter remplit la DataTable
                dgAchat.ItemsSource = _dt.DefaultView;  // Transfère les données de _dt vers dgRappeurs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void effacer()
        {
            txtId.Content = "";
            SAI_user_id.Text = "";
            SAI_articles_id.Text = "";
            SAI_valeur.Text = "";
            SAI_quantité.Text = "";

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string _sql = "INSERT INTO paniers(user_id, articles_id,valeur, quantité) VALUES(@user_id, @articles_id, @valeur, @quantité)";

            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@user_id", SAI_user_id.Text);
                _command.Parameters.AddWithValue("@articles_id", SAI_articles_id.Text);
                _command.Parameters.AddWithValue("@valeur", SAI_valeur.Text);
                _command.Parameters.AddWithValue("@quantité", SAI_quantité.Text);

                _connexion.Open();
                _command.ExecuteNonQuery();

                afficher();
                effacer();

                MessageBox.Show("Achat crée", "Nouvel achat", MessageBoxButton.OK, MessageBoxImage.Information);
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
            string _sql = "UPDATE paniers SET user_id = @user_id,articles_id = @articles_id,valeur = @valeur, quantité = @quantité WHERE id = @Id";
            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@Id", txtId.Content);
                _command.Parameters.AddWithValue("@user_id", SAI_user_id.Text);
                _command.Parameters.AddWithValue("@articles_id", SAI_articles_id.Text);
                _command.Parameters.AddWithValue("@valeur", SAI_valeur.Text);
                _command.Parameters.AddWithValue("@quantité", SAI_quantité.Text);

                _connexion.Open();
                _command.ExecuteNonQuery();

                afficher();

                MessageBox.Show("Achat modifié", "changements Achat", MessageBoxButton.OK, MessageBoxImage.Information);
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

            string _sql = "DELETE FROM paniers WHERE id = @Id;";

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

        private void dgAchat_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((DataRowView)dgAchat.SelectedItem != null)
            {
                DataRowView _drv = (DataRowView)dgAchat.SelectedItem;

                txtId.Content = _drv.Row["id"].ToString();
                SAI_user_id.Text = _drv.Row["user_id"].ToString();
                SAI_articles_id.Text = _drv.Row["achats_id"].ToString();
                SAI_quantité.Text = _drv.Row["valeur"].ToString();
                SAI_quantité.Text = _drv.Row["quantité"].ToString();
            }
        }


    }
}
