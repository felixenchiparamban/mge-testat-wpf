using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.ui.ViewModel
{
    class NewGadgetViewModel : BindableBase
    {
        private LibraryAdminService Service { get; set; }
        private Gadget Gadget { get; set; }

        public NewGadgetViewModel()
        {

        }
    }
}
