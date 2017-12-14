using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ch.hsr.wpf.gadgeothek.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LibraryAdminService Service { get; set; }

        private List<Gadget> gadgets;

        public List<Gadget> Gadgets
        {
            get
            {
                return gadgets;
            }
            set
            {
                gadgets = value;
            }
        }

        private List<Loan> loans;

        public List<Loan> Loans
        {
            get
            {
                return loans;
            }
            set
            {
                loans = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            var url = System.Configuration.ConfigurationManager.AppSettings["serverGadgeothek"];
            Service = new LibraryAdminService(url);
            Gadgets = Service.GetAllGadgets();
            Loans = Service.GetAllLoans();
        }
    }
}
