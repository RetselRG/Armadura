using System;
using System.Collections.Generic;
using System.Text;

namespace Armadura.Infrastructure
{
    using ViewModels;
    public class InstanceLocator
    {
        public MainViewModel Main 
        {
            get; 
            set; 
        }
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
