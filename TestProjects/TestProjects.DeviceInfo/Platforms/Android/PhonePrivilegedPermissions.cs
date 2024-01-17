namespace TestProjects.DeviceInfo.Platforms.Android
{
    public class PhonePrivilegedPermissions : Permissions.BasePlatformPermission
    {
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
            new List<(string androidPermission, bool isRuntime)>
            {
                ("android.permission.READ_PRIVILEGED_PHONE_STATE", false),
            }.ToArray();
    }
}
