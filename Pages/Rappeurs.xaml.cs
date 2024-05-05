using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Tsp;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using static System.Net.WebRequestMethods;


namespace wpf_application.Pages
{
    public partial class Rappeurs : Page
    {
        // Objets nécessaires pour SQL
        const string _dsn = "server=localhost;port=3306;database=raptest;username=root;password=;";
        private MySqlConnection _connexion = new MySqlConnection(_dsn);
        private MySqlCommand _command;
        private MySqlDataAdapter _adapter;

        private DataTable _dt;  // Ne fait pas partie de MySql.Data (objet .NET)
        public Rappeurs()
        {
            InitializeComponent();
            afficher();
        }
        private void afficher()
        {
            try
            {
                _adapter = new MySqlDataAdapter("SELECT * FROM rappeurs;", _connexion); // Instancie un adapter
                _dt = new DataTable();  // Instancie une DataTable
                _adapter.Fill(_dt);     // Adapter remplit la DataTable
                dgRappeurs.ItemsSource = _dt.DefaultView;  // Transfère les données de _dt vers dgRappeurs
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
            SAI_note_globale.Text = "";
            SAI_vignette.Content = "";
            SAI_picture.Content = "";
            SAI_lien.Text = "";
            SAI_musique.Content = "";

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string _sql = "INSERT INTO rappeurs(nom, note_globale, vignette, picture, lien, musique) VALUES(@nom, @note_globale, @vignette, @picture, @lien,  @musique)";

            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@nom", SAI_nom.Text);
                _command.Parameters.AddWithValue("@note_globale", decimal.Parse(SAI_note_globale.Text));
                _command.Parameters.AddWithValue("@vignette", SAI_vignette.Content);
                _command.Parameters.AddWithValue("@picture", SAI_picture.Content);
                _command.Parameters.AddWithValue("@lien", SAI_lien.Text);
                _command.Parameters.AddWithValue("@musique", SAI_musique.Content);


                _connexion.Open();
                _command.ExecuteNonQuery();

                // Upload vignette
                bool resultat = true;
                FTP ftp = new FTP("ftp://ftp.kuph3194.odns.fr", "rap@ifcsio2022.fr", "fah9NadTO$Qx");
                
                if (SAI_vignette_path.Text!=string.Empty)
                    resultat = ftp.Upload(SAI_vignette_path.Text, "vignettes/" + SAI_vignette.Content);

                // Upload image
                if (SAI_picture_path.Text != string.Empty)
                    resultat = ftp.Upload(SAI_picture_path.Text, "pictures/" + SAI_picture.Content);

                // Upload musique
                if (SAI_musique_path.Text != string.Empty)
                    resultat = ftp.Upload(SAI_musique_path.Text, "song/" + SAI_musique.Content);

                afficher();
                effacer();

                if (resultat)
                    MessageBox.Show("Rappeur crée", "Nouveau rappeur", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Rappeur crée. !!!ATTENTION, Upload vignette failed!!!", "Nouveau rappeur", MessageBoxButton.OK, MessageBoxImage.Information);

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
            string _sql = "UPDATE rappeurs SET nom = @nom, note_globale = @note_globale, vignette = @vignette, picture = @picture, lien = @lien, musique = @musique WHERE id = @Id";
            try
            {
                _command = new MySqlCommand(_sql, _connexion);
                _command.Parameters.AddWithValue("@Id", txtId.Content);
                _command.Parameters.AddWithValue("@nom", SAI_nom.Text);
                _command.Parameters.AddWithValue("@note_globale", decimal.Parse(SAI_note_globale.Text));
                _command.Parameters.AddWithValue("@vignette", SAI_vignette.Content);
                _command.Parameters.AddWithValue("@picture", SAI_picture.Content);
                _command.Parameters.AddWithValue("@lien", SAI_lien.Text);
                _command.Parameters.AddWithValue("@musique", SAI_musique.Content);

                _connexion.Open();
                _command.ExecuteNonQuery();

                // Upload vignette
                bool resultat = true;
                FTP ftp = new FTP("ftp://ftp.kuph3194.odns.fr", "rap@ifcsio2022.fr", "fah9NadTO$Qx");

                if (SAI_vignette_path.Text != string.Empty)
                    resultat = ftp.Upload(SAI_vignette_path.Text, "vignettes/" + SAI_vignette.Content);

                // Upload image
                if (SAI_picture_path.Text != string.Empty)
                    resultat = ftp.Upload(SAI_picture_path.Text, "pictures/" + SAI_picture.Content);

                // Upload musique
                if (SAI_musique_path.Text != string.Empty)
                    resultat = ftp.Upload(SAI_musique_path.Text, "song/" + SAI_musique.Content);


                afficher();

                MessageBox.Show("Rappeur modifié", "changer Rappeur", MessageBoxButton.OK, MessageBoxImage.Information);
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

            string _sql = "DELETE FROM rappeurs WHERE id = @Id;";

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

        private void dgRappeurs_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((DataRowView)dgRappeurs.SelectedItem != null)
            {
                DataRowView _drv = (DataRowView)dgRappeurs.SelectedItem;

                txtId.Content = _drv.Row["id"].ToString();  // Supposant que 'id' est le champ pour l'identifiant dans votre base de données
                SAI_nom.Text = _drv.Row["nom"].ToString();
                SAI_note_globale.Text = _drv.Row["note_globale"].ToString();
                SAI_vignette.Content = _drv.Row["vignette"].ToString();
                SAI_picture.Content = _drv.Row["picture"].ToString();
                SAI_lien.Text = _drv.Row["lien"].ToString();
                SAI_musique.Content = _drv.Row["musique"].ToString();

            }
        }

        private void btnVignette_Click(object sender, RoutedEventArgs e)
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
                SAI_vignette.Content = filename;
                SAI_vignette_path.Text = path;
            }

        }


        private void btnPicture_Click(object sender, RoutedEventArgs e)
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
                SAI_picture.Content = filename;
                SAI_picture_path.Text = path;
            }

        }

        private void btnMusique_Click(object sender, RoutedEventArgs e)
        {

            // Instanciation d'un objet OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();

            // Filtre
            ofd.Filter = "(*.mp3) | *.mp3";

            // Dossier initial (ATTENTION à l'échappement du backslash)
            //ofd.InitialDirectory = "D:\\Formation\\IFC Avignon";

            // Sélection unique
            ofd.Multiselect = false;

            // Titre du dialog
            ofd.Title = "Veuillez choisir un fichier son";

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
                SAI_musique.Content = filename;
                SAI_musique_path.Text = path;
            }

        }

    }
}
