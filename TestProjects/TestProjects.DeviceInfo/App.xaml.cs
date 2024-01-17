using TestProjects.DeviceInfo.Services;

namespace TestProjects.DeviceInfo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
