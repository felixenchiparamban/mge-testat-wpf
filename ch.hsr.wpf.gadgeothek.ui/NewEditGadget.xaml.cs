using ch.hsr.wpf.gadgeothek.ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ch.hsr.wpf.gadgeothek.ui
{
    /// <summary>
    /// Interaction logic for NewEditGadget.xaml
    /// </summary>
    public partial class NewEditGadget : Window
    {
        private NewGadgetViewModel NewGadgetViewModel { get; set; }

        public NewEditGadget()
        {
            InitializeComponent();
            NewGadgetViewModel = new NewGadgetViewModel();
            DataContext = NewGadgetViewModel;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
