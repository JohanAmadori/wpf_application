using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace wpf_application.Pages
{
    public partial class Classement : Page
    {
        // Objets nécessaires pour SQL
        const string _dsn = "server=localhost;port=3306;database=kuph3194_rap;username=kuph3194_johan;password=fah9NadTO$Qx;";
        private MySqlConnection _connexion = new MySqlConnection(_dsn);
        private MySqlCommand _command;
        private MySqlDataAdapter _adapter;

        private DataTable _dt;  // Ne fait pas partie de MySql.Data (objet .NET)
        public Classement()
        {
            InitializeComponent();
            afficher();
        }
        private void afficher()
        {
            try
            {
                _adapter = new MySqlDataAdapter("SELECT * FROM users ORDER BY points desc;", _connexion); // Instancie un adapter
                _dt = new DataTable();  // Instancie une DataTable
                _adapter.Fill(_dt);     // Adapter remplit la DataTable
                dgClassement.ItemsSource = _dt.DefaultView;  // Transfère les données de _dt vers dgRappeurs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
