namespace TestProjects.DeviceCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Device deviceOld = new Device
            {
                DeviceId = "12345",
                Brand = "Samsung",
                Model = "Galaxy S20",
                VendorModel = "SM-G981U1",
                Type = "Smartphone",
                Os = "Android",
                OsVersion = "10",
                OsShortName = "Android",
                OsUI = "One UI",
                OsPlatform = "ARM"
            };

            Device deviceNew = new Device
            {
                DeviceId = "12345",
                Brand = "Samsung",
                Model = "Galaxy S20",
                VendorModel = "SM-G981U1",
                Type = "Smartphone",
                Os = "Android",
                OsVersion = "10",
                OsShortName = "Android",
                OsUI = "One UI",
                OsPlatform = "ARM"
            };

            string generatedOldDeviceHash = DeviceUtility.GenerateHash(deviceOld);

            ValidationStatus status = DeviceUtility.ValidateHash(deviceNew, generatedOldDeviceHash);
            Console.WriteLine($"Validation Status: {status}");
        }
    }
}
