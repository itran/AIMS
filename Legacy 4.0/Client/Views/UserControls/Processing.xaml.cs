using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Horizon.Client.Modules.Engine.UserControls
{
    /// <summary>
    /// Interaction logic for Processing.xaml
    /// </summary>
    public partial class Processing : UserControl
    {
        public Processing()
        {
            InitializeComponent();

            Loaded += (sender, args) => {
                SpinnerScale.ScaleX = Width/150;
                SpinnerScale.ScaleY = Height/150;

                var processingAnimation = (Storyboard)SpinnerCanvas.FindResource("ProcessingAnimation");
                Storyboard.SetTargetName(processingAnimation, "SpinnerRotate");

                IsVisibleChanged += (senderv, argsv) => {
                    if ((bool)argsv.NewValue)
                        processingAnimation.Begin(this, true);
                    else
                        processingAnimation.Stop(this);
                };
            };
        }
    }
}
