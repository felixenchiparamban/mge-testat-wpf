using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using ch.hsr.wpf.gadgeothek.ui.RelayCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ch.hsr.wpf.gadgeothek.ui.ViewModel
{
    class DeleteGadgetViewModel : BindableBase
    {
        private LibraryAdminService Service { get; set; }

        public Gadget Gadget { get; set; } = new Gadget();

        public ICommand ConfirmDeleteGadgetCommand { get; set; }

        public ICommand CancelDeleteGadgetCommand { get; set; }

        public DeleteGadgetViewModel()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["serverGadgeothek"];
            Service = new LibraryAdminService(url);

            ConfirmDeleteGadgetCommand = new RelayCommand<Object>((o) => ConfirmDeleteGadget());
            CancelDeleteGadgetCommand = new RelayCommand<Window>((o) => CancelDeleteGadget(o));
        }
        
        public void ConfirmDeleteGadget()
        {
            if (!Service.DeleteGadget(Gadget))
            {
                MessageBox.Show("Error while deleting the Gadget.");
            }
        }

        public void CancelDeleteGadget(Window window)
        {
            window.Close();
        }
    }
}
