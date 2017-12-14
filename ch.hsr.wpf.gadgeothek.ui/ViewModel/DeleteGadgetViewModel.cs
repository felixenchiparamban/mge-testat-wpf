using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch.hsr.wpf.gadgeothek.ui.ViewModel
{
    class DeleteGadgetViewModel : BindableBase
    {
        private LibraryAdminService Service { get; set; }

        public Gadget Gadget { get; set; } = new Gadget();


    }
}
