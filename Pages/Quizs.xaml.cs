using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace wpf_application.Pages
{
    public partial class Quizs : Page
    {
        // Objets nécessaires pour SQL
        const string _dsn = "server=localhost;port=3306;database=kuph3194_rap;username=kuph3194_johan;password=fah9NadTO$Qx;";
        private MySqlConnection _connexion = new MySqlConnection(_dsn);
        private MySqlCommand _command;
        private MySqlDataAdapter _adapter;

        private DataTable _dt;  // Ne fait pas partie de MySql.Data (objet .NET)
        public Quizs()
        {
            InitializeComponent();
            afficher();
        }
        private void afficher()
        {
            try
            {
                _adapter = new MySqlDataAdapter("SELECT * FROM quizs;", _connexion); // Instancie un adapter
                _dt = new DataTable();  // Instancie une DataTable
                _adapter.Fill(_dt);     // Adapter remplit la DataTable
                dgQuizs.ItemsSource = _dt.DefaultView;  // Transfère les données de _dt vers dgRappeurs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void effacer()
        {
            txtId.Content = "";
            SAI_rappeur_id.Text = "";
            SAI_question.Text = "";
            SAI_reponse1.Text = "";
            SAI_reponse2.Text = "";
            SAI_reponse3.Text = "";
            SAI_reponse4.Text = "";
            SAI_reponse.Text = "";

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string _sql = "INSERT INTO quizs(rappeur_id, question, reponse1, reponse2, reponse3, reponse4, reponse) VALUES(@rappeur_id, @question, @reponse1, @reponse2, @reponse3,@reponse4, @reponse)";

            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@rappeur_id", SAI_rappeur_id.Text);
                _command.Parameters.AddWithValue("@question", SAI_question.Text);
                _command.Parameters.AddWithValue("@reponse1", SAI_reponse1.Text);
                _command.Parameters.AddWithValue("@reponse2", SAI_reponse2.Text);
                _command.Parameters.AddWithValue("@reponse3", SAI_reponse3.Text);
                _command.Parameters.AddWithValue("@reponse4", SAI_reponse4.Text);
                _command.Parameters.AddWithValue("@reponse", SAI_reponse.Text);


                _connexion.Open();
                _command.ExecuteNonQuery();

                afficher();
                effacer();

                MessageBox.Show("Quiz créé", "Nouveau quiz", MessageBoxButton.OK, MessageBoxImage.Information);
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
            string _sql = "UPDATE quizs SET rappeur_id = @rappeur_id, question = @question, reponse1 = @reponse1, reponse2 = @reponse2, reponse3 = @reponse3, reponse4 = @reponse4 , reponse = @reponse WHERE id = @Id";
            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@Id", txtId.Content);
                _command.Parameters.AddWithValue("@rappeur_id", SAI_rappeur_id.Text);
                _command.Parameters.AddWithValue("@question", SAI_question.Text);
                _command.Parameters.AddWithValue("@reponse1", SAI_reponse1.Text);
                _command.Parameters.AddWithValue("@reponse2", SAI_reponse2.Text);
                _command.Parameters.AddWithValue("@reponse3", SAI_reponse3.Text);
                _command.Parameters.AddWithValue("@reponse4", SAI_reponse4.Text);
                _command.Parameters.AddWithValue("@reponse", SAI_reponse.Text);

                _connexion.Open();
                _command.ExecuteNonQuery();

                afficher();

                MessageBox.Show("Quiz modifié", "Quiz changé", MessageBoxButton.OK, MessageBoxImage.Information);
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

            string _sql = "DELETE FROM quizs WHERE id = @Id;";

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

        private void dgQuizs_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((DataRowView)dgQuizs.SelectedItem != null)
            {
                DataRowView _drv = (DataRowView)dgQuizs.SelectedItem;

                txtId.Content = _drv.Row["id"].ToString();  // Supposant que 'id' est le champ pour l'identifiant dans votre base de données
                SAI_rappeur_id.Text = _drv.Row["rappeur_id"].ToString();
                SAI_question.Text = _drv.Row["question"].ToString();
                SAI_reponse1.Text = _drv.Row["reponse1"].ToString();
                SAI_reponse2.Text = _drv.Row["reponse2"].ToString();
                SAI_reponse3.Text = _drv.Row["reponse3"].ToString();
                SAI_reponse4.Text = _drv.Row["reponse4"].ToString();
                SAI_reponse.Text = _drv.Row["reponse"].ToString();

            }
        }


    }
}
