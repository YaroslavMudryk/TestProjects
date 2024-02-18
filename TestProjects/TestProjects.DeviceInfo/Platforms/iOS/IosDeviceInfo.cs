using TestProjects.DeviceInfo.Services;
using UIKit;

namespace TestProjects.DeviceInfo.Platforms.iOS
{
    internal class IosDeviceInfo : IGetDeviceInfo
    {
        public string GetDeviceId()
        {
            return UIDevice.CurrentDevice.IdentifierForVendor.AsString().Replace("-", "");
        }
    }
}
