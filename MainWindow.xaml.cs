using System.Windows;
using System.Windows.Controls;
using wpf_application.Pages;

namespace wpf_application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            navframe.Navigate(new Accueil());
        }

        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavButton _selected = (NavButton)menu.SelectedItem;
            navframe.Navigate(_selected.NavLink);
        }

        private void NavButton_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void navframe_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void navframe_Navigated_1(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void NavButton_Selected_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
