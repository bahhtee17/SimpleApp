using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleApp.ViewModel.Base;

namespace ExampleApp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string title;

        public string Title
        {
            get => title;
            set => Set(ref title, value);





        }
    }
    
}
