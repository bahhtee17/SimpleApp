using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExampleApp.Infrastructure.Commands.Base
{
    internal class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
