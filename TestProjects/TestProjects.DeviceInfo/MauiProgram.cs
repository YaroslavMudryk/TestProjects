using TestProjects.DeviceInfo.Platforms.iOS;
using TestProjects.DeviceInfo.Services;

namespace TestProjects.DeviceInfo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .Services
                .AddTransient<IGetDeviceInfo, IosDeviceInfo>()
                .AddScoped<MainPage>();

            return builder.Build();
        }
    }
}
