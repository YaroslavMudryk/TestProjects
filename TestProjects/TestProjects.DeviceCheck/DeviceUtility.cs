using System.Text;

namespace TestProjects.DeviceCheck;

public class DeviceUtility
{
    public static string GenerateHash(Device device)
    {
        string part1 = Encrypt($"{device.DeviceId}_{device.Brand}_{device.Model}_{device.VendorModel}_{device.Type}");
        string part2 = Encrypt($"{device.Os}_{device.OsVersion}_{device.OsShortName}_{device.OsUI}_{device.OsPlatform}");
        string part3 = Encrypt($"{device.Browser}_{device.BrowserVersion}_{device.BrowserType}_{device.BrowserEngine}_{device.BrowserEngineVersion}");

        return $"{part1}:{part2}:{part3}";
    }

    public static ValidationStatus ValidateHash(Device device, string hash)
    {
        string[] oldParts = hash.Split(':');
        var oldOsHash = oldParts[1];

        if (oldParts.Length != 3)
            return ValidationStatus.Failed;

        var newHash = GenerateHash(device);

        string[] newOsParts = newHash.Split(':');

        var newOsHash = newOsParts[1];

        if (oldParts[0] != newOsParts[0] || oldParts[2] != newOsParts[2])
            return ValidationStatus.Failed;

        return CheckOs(oldOsHash, newOsHash);
    }

    private static ValidationStatus CheckOs(string oldOsHash, string newOsHash)
    {
        var oldOs = Decrypt(oldOsHash);
        var oldOsParts = oldOs.Split('_');
        var oldVersion = Convert.ToInt32(oldOsParts[1]);
        oldOs = oldOs.Remove(oldOs.IndexOf('_'), oldVersion.ToString().Length + 1);

        var newOs = Decrypt(newOsHash);
        var newOsParts = newOs.Split('_');
        var newVersion = Convert.ToInt32(newOsParts[1]);
        newOs = newOs.Remove(newOs.IndexOf('_'), newVersion.ToString().Length + 1);

        if (oldOs != newOs)
            return ValidationStatus.Failed;

        if (oldVersion == newVersion)
            return ValidationStatus.Success;
        if (oldVersion < newVersion)
            return ValidationStatus.OsUpdated;

        return ValidationStatus.Failed;
    }

    private static string Encrypt(string text)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }

    private static string Decrypt(string encryptedText)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(encryptedText));
    }
}
