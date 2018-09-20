namespace _02.MVVM
{
    using System;
    using System.Windows.Input;

    public class LambdaCommand : ICommand
    {
        private readonly Action action;

        public event EventHandler CanExecuteChanged;

        public LambdaCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action.Invoke();
        }
    }
}
