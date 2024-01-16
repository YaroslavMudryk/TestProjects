using System.Text;
using TestProjects.DeviceInfo.Services;
using static Android.Provider.Settings;

namespace TestProjects.DeviceInfo
{
    public class GetDeviceInfo : IGetDeviceInfo
    {
        public string GetDeviceId()
        {
            var context = Android.App.Application.Context;

            string id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Secure.AndroidId);

            return id;
        }
    }
}
