using TestProjects.DeviceInfo.Platforms.Android;
using TestProjects.DeviceInfo.Services;

namespace TestProjects.DeviceInfo
{
    public partial class MainPage : ContentPage
    {
        private readonly IGetDeviceInfo _getDeviceInfo;
        private readonly IReadPhoneState _readPhoneState;
        int count = 0;

        public MainPage(IGetDeviceInfo getDevice, IReadPhoneState readPhoneState)
        {
            InitializeComponent();
            _getDeviceInfo = getDevice;
            _readPhoneState = readPhoneState;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                PermissionStatus res = default;

                do
                {
                    res = await Permissions.RequestAsync<PhonePrivilegedPermissions>();
                }
                while (res != PermissionStatus.Granted);

            }
            catch (Exception ex)
            {

                throw;
            }

            var d = _getDeviceInfo.GetDeviceId();

            var s = _readPhoneState.GetPhoneIMEI();

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
