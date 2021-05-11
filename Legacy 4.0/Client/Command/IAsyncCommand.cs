using System.Threading.Tasks;

namespace Legacy.WPFRegionalManager.Client.Command
{
    /// <summary>
    /// Implementation inspired by https://johnthiriet.com/mvvm-going-async-with-async-command/ and http://jake.ginnivan.net/awaitable-delegatecommand/
    /// </summary>
    public interface IAsyncCommand : IAsyncCommandBase
    {
        Task ExecuteAsync();

        bool CanExecute();
    }
}