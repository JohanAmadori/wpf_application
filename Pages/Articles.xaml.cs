using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace wpf_application.Pages
{
    public partial class Articles : Page
    {
        // Objets nécessaires pour SQL
        const string _dsn = "server=localhost;port=3306;database=raptest;username=root;password=;";
        private MySqlConnection _connexion = new MySqlConnection(_dsn);
        private MySqlCommand _command;
        private MySqlDataAdapter _adapter;

        private DataTable _dt;  // Ne fait pas partie de MySql.Data (objet .NET)
        public Articles()
        {
            InitializeComponent();
            afficher();
        }
        private void afficher()
        {
            try
            {
                _adapter = new MySqlDataAdapter("SELECT * FROM articles;", _connexion); // Instancie un adapter
                _dt = new DataTable();  // Instancie une DataTable
                _adapter.Fill(_dt);     // Adapter remplit la DataTable
                dgArticles.ItemsSource = _dt.DefaultView;  // Transfère les données de _dt vers dgRappeurs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void effacer()
        {
            txtId.Content = "";
            SAI_nom.Text = "";
            SAI_note.Text = "";
            SAI_prix_public.Text = "";
            SAI_img.Content = "";
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string _sql = "INSERT INTO articles(nom, note, prix_public, img) VALUES(@nom, @note, @prix_public, @img)";

            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@nom", SAI_nom.Text);
                _command.Parameters.AddWithValue("@note", SAI_note.Text);
                _command.Parameters.AddWithValue("@prix_public", SAI_prix_public.Text);
                _command.Parameters.AddWithValue("@img", SAI_img.Content);


                _connexion.Open();
                _command.ExecuteNonQuery();


                afficher();
                effacer();

                MessageBox.Show("Article créé", "Nouvel article", MessageBoxButton.OK, MessageBoxImage.Information);
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
            string _sql = "UPDATE articles SET nom = @nom, note = @note, prix_public = @prix_public, img = @img WHERE id = @Id";
            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@Id", txtId.Content);
                _command.Parameters.AddWithValue("@nom", SAI_nom.Text);
                _command.Parameters.AddWithValue("@note", SAI_note.Text);
                _command.Parameters.AddWithValue("@prix_public", SAI_prix_public.Text);
                _command.Parameters.AddWithValue("@img", SAI_img.Content);


                _connexion.Open();
                _command.ExecuteNonQuery();

                afficher();

                MessageBox.Show("Article modifié", "changer Article", MessageBoxButton.OK, MessageBoxImage.Information);
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

            string _sql = "DELETE FROM articles WHERE id = @Id;";

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

        private void dgArticles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((DataRowView)dgArticles.SelectedItem != null)
            {
                DataRowView _drv = (DataRowView)dgArticles.SelectedItem;

                txtId.Content = _drv.Row["id"].ToString();  // Supposant que 'id' est le champ pour l'identifiant dans votre base de données
                SAI_nom.Text = _drv.Row["nom"].ToString();
                SAI_note.Text = _drv.Row["note"].ToString();
                SAI_prix_public.Text = _drv.Row["prix_public"].ToString();
                SAI_img.Content = _drv.Row["img"].ToString();

            }
        }

        private void btnImg_Click(object sender, RoutedEventArgs e)
        {

            // Instanciation d'un objet OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();

            // Filtre
            ofd.Filter = "(*.bmp, *.jpg) | *.bmp; *.jpg";

            // Dossier initial (ATTENTION à l'échappement du backslash)
            //ofd.InitialDirectory = "D:\\Formation\\IFC Avignon";

            // Sélection unique
            ofd.Multiselect = false;

            // Titre du dialog
            ofd.Title = "Veuillez choisir un fichier image";

            // Affichage d'un modal (Attente du choix de l'utilisateur)
            bool? success = ofd.ShowDialog();
            // !! ATTENTION : bool? peut avoir 3 états, donc pas possible de faire if (success) !!
            if (success == true)   // returns true si un fichier a été sélectionné
            {
                // Pour récupérer le chemin complet :
                string path = ofd.FileName;

                // Pour récupérer seulement le nom du fichier
                string filename = ofd.SafeFileName;

                // Affichage du résultat
                SAI_img.Content = filename;
                SAI_img_path.Text = path;
            }

        }


    }
}
