using Android.Content;
using TestProjects.DeviceInfo.Platforms.Android;
using TestProjects.DeviceInfo.Services;

namespace TestProjects.DeviceInfo
{
    public class ReadPhoneState : IReadPhoneState
    {
        public string GetPhoneIMEI()
        {
            try
            {
                var s = (Android.Telephony.TelephonyManager)Android.App.Application.Context.GetSystemService(Context.TelephonyService);
                return s.Imei;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
