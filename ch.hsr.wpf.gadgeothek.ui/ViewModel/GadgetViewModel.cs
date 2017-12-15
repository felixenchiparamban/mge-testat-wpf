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

namespace ch.hsr.wpf.gadgeothek.ui.ViewModel
{
    class GadgetViewModel : BindableBase
    {
        private LibraryAdminService Service { get; set; }

        public List<Gadget> Gadgets { get; set; }
        public List<Loan> Loans { get; set; }

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

            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerEvent);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
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
            Gadgets = Service.GetAllGadgets();
            Loans = Service.GetAllLoans();
        }
    }
}
