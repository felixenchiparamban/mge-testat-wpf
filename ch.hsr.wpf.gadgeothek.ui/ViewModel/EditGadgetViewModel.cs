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
    class EditGadgetViewModel
    {
        public event EventHandler CanClose;
        
        private LibraryAdminService Service { get; set; }

        public Gadget EditGadget { get; set; } = new Gadget();

        public ICommand ConfirmEditCommand { get; set; }

        public ICommand CancelEditCommand { get; set; }

        public EditGadgetViewModel(Gadget gadget)
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["serverGadgeothek"];
            Service = new LibraryAdminService(url);

            EditGadget = gadget;

            ConfirmEditCommand = new RelayCommand.RelayCommand<Object>((o) => ConfirmEdit());
            CancelEditCommand = new RelayCommand.RelayCommand<Object>((o) => CancelEdit());
        }

        public void ConfirmEdit()
        {
            if (Service.UpdateGadget(EditGadget))
            {
                MessageBox.Show("Update was Successful");
                CanClose?.Invoke(this, new EventArgs());
            }
        }

        public void CancelEdit()
        {
            CanClose?.Invoke(this, new EventArgs());
        }
    }
}
