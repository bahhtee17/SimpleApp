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
        //Поле
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute; 

        //Пользовательский Конструктор 
        public LimdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            
            this._Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            this._CanExecute = CanExecute;
        }

        //Делаем оверрайд абстрактного возвращаемого метода из базового класса Command
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;



        //Делаем оверрайд абстрактного возвращаемого метода из базового класса Command
        public override void Execute(object parameter) => _Execute(parameter);
        
            
        
    }
}
