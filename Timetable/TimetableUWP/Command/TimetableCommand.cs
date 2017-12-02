using System;
using System.Windows.Input;

namespace TimetableUWP.Command
{
    public class TimetableCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action ExecuteFunction;
        private Func<bool> CanFunctionExecute;

        public TimetableCommand(Action action, Func<bool> predicate)
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

        public void Update()
        {
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
