using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fitly_Domain.Business;

namespace Fitly_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller _controller = new Controller();
        public MainWindow()
        {
            {
                InitializeComponent();
                dtg.ItemsSource = _controller.GetDeelnemers();
                cmbWorkout.ItemsSource = _controller.GetWorkouts();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int getWorkout = 0;
            
            cmbWorkout.SelectedItem = getWorkout;
            dtgOefeningen.ItemsSource = _controller.GetOefeningsFromDB(getWorkout);
            
        }
    }

             
}