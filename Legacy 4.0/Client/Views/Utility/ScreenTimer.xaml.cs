using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Horizon.Client.Modules.Engine.Utility
{
    /// <summary>
    /// Interaction logic for ScreenTimer.xaml
    /// </summary>
    public partial class ScreenTimer : UserControl
    {
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public TimeSpan ElapsedSeconds { get; set; }
        private DispatcherTimer dispatcherTimer;

        public ScreenTimer()
        {
            InitializeComponent();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            StartTimer();
        }

        public void StartTimer()
        {
            StartTime = DateTime.Now;
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ElapsedSeconds = (DateTime.Now - StartTime);
            textBlockTimer.Text = String.Format("{0:00}", ElapsedSeconds.Minutes) + ":" + String.Format("{0:00}", ElapsedSeconds.Seconds);
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
