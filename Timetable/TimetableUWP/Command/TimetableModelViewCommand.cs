using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TimetableUWP.Command
{
    public class TimetableModelViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action ExecuteFunction;
        private Func<bool> CanFunctionExecute;

        public TimetableModelViewCommand(Action action, Func<bool> predicate)
        {
            ExecuteFunction = action;
            CanFunctionExecute = predicate;
        }

        public bool CanExecute(object parameter)
        {
            return CanFunctionExecute();
        }

        public void Execute(object parameter)
        {
            ExecuteFunction();
        }
    }
}
