using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Timers;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace ch.hsr.wpf.gadgeothek.ui.ViewModel
{
    class GadgetViewModel : BindableBase
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
                SetProperty(ref gadgets, value);
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
                SetProperty(ref loans, value);
            }
        }

        public Gadget SelectedGadget { get; set; }

        public ICommand EditGadgetCommand { get; set; }
        public ICommand DeleteGadgetCommand { get; set; }

        private static System.Timers.Timer aTimer;

        public GadgetViewModel()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["serverGadgeothek"];
            Service = new LibraryAdminService(url);

            Gadgets = Service.GetAllGadgets();
            Loans = Service.GetAllLoans();

            EditGadgetCommand = new RelayCommand.RelayCommand<Object>((o) => EditGadget());
            DeleteGadgetCommand = new RelayCommand.RelayCommand<Object>((o) => DeleteGadget());

            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        public void EditGadget()
        {
            if(SelectedGadget == null)
            {
                MessageBox.Show("Please select the gadget first.");
            }
            else
            {
                EditGadget editGadget = new EditGadget(SelectedGadget);
                editGadget.Show();
            }
        }

        public void DeleteGadget()
        {
            if(SelectedGadget == null)
            {
                MessageBox.Show("Please select the gadget first.");
            }
            else
            {
                DeleteGadget deleteGadget = new DeleteGadget(SelectedGadget);
                deleteGadget.Show();
            }
        }

        private void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.CurrentDispatcher.Invoke(() => {
                Gadgets = new List<Gadget>();
                Gadgets = Service.GetAllGadgets();

                Loans = new List<Loan>();
                Loans = Service.GetAllLoans();

            });
        }
    }
}
