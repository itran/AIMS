using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Legacy.WPFRegionalManager.Client.Command
{
    /// <summary>
    /// Implementation inspired by https://johnthiriet.com/mvvm-going-async-with-async-command/ and http://jake.ginnivan.net/awaitable-delegatecommand/
    /// </summary>
    public class AsyncCommand : IAsyncCommand
    {
        private bool isExecuting;
        private readonly Func<Task> method;
        private readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AsyncCommand(Func<Task> method) : this(method, null)
        { }

        public AsyncCommand(Func<Task> method, Func<bool> canExecute)
        {
            if (method == null && canExecute == null)
            {
                throw new ArgumentNullException(nameof(method), "Execute Method cannot be null.");
            }

            this.method = method;
            this.canExecute = canExecute;
        }

        public bool CanExecute() => !isExecuting && (canExecute?.Invoke() ?? true);

        bool ICommand.CanExecute(object parameter) => CanExecute();

        async void ICommand.Execute(object parameter) => await ExecuteAsync();

        public async Task ExecuteAsync()
        {
            try
            {
                isExecuting = true;
                RaiseCanExecuteChanged();
                await method();
            }
            finally
            {
                isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}