using TestProjects.DeviceInfo.Services;

namespace TestProjects.DeviceInfo
{
    public partial class App : Application
    {
        public App(IGetDeviceInfo getDevice)
        {
            InitializeComponent();

            var d = getDevice.GetDeviceId();

            var device = Microsoft.Maui.Devices.DeviceInfo.Current;

            MainPage = new AppShell();
        }
    }
}
