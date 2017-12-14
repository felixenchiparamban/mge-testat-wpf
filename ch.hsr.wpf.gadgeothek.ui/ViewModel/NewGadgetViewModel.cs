using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ch.hsr.wpf.gadgeothek.ui.ViewModel
{
    class NewGadgetViewModel : BindableBase
    {
        public event EventHandler CanClose;

        private LibraryAdminService Service { get; set; }

        public Gadget Gadget { get; set; } = new Gadget();

        public ICommand SaveCommand { get; set; } 
        public ICommand CancelCommand { get; set; }

        public NewGadgetViewModel()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["serverGadgeothek"];
            Service = new LibraryAdminService(url);

            SaveCommand = new RelayCommand.RelayCommand<Object>((o) => Save());
            CancelCommand = new RelayCommand.RelayCommand<Object>((o) => Cancel());
        }

        public void Save()
        {
            if (!Service.AddGadget(Gadget))
            {
                MessageBox.Show("Error while adding your new gadget");
            } else
            {
                CanClose?.Invoke(this, new EventArgs());
            }
        }

        public void Cancel()
        {
            CanClose?.Invoke(this, new EventArgs());
        }
    }
}
