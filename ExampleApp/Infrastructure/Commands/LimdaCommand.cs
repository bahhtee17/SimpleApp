using ExampleApp.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Infrastructure.Commands
{
    internal class LimdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute; 


        public LimdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            
            this._Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            this._CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;




        public override void Execute(object parameter) => _Execute(parameter);
        
            
        
    }
}
