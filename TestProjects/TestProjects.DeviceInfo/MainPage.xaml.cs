using TestProjects.DeviceInfo.Services;

namespace TestProjects.DeviceInfo
{
    public partial class MainPage : ContentPage
    {
        private readonly IGetDeviceInfo _getDeviceInfo;
        int count = 0;

        public MainPage(IGetDeviceInfo getDevice)
        {
            InitializeComponent();
            _getDeviceInfo = getDevice;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var deviceId = _getDeviceInfo.GetDeviceId();

            var device = Microsoft.Maui.Devices.DeviceInfo.Current;

            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
