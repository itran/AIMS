using System.Windows.Input;

namespace Legacy.WPFRegionalManager.Client.Command
{
    /// <summary>
    /// Implementation inspired by https://johnthiriet.com/mvvm-going-async-with-async-command/ and http://jake.ginnivan.net/awaitable-delegatecommand/
    /// </summary>
    public interface IAsyncCommandBase : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}