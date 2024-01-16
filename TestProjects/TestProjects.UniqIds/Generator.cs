using System.Security.Cryptography;
using System.Text;

namespace TestProjects.UniqIds
{
    public static class Generator
    {
        private static long counter = 0;
        private static object lockObject = new object();

        public static string GetV1()
        {
            long num = DateTime.Now.Ticks, nbase = 36;
            String chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (nbase < 2 || nbase > chars.Length)
                return "";

            long r;
            String newNumber = "";

            while (num >= nbase)
            {
                r = num % nbase;
                newNumber = chars[(int)r] + newNumber;
                num = num / nbase;
            }

            newNumber = chars[(int)num] + newNumber;

            return newNumber.ToLower();
        }

        public static string GetV2()
        {
            return DateTime.Now.Ticks.ToString().GetHashCode().ToString("x");
        }

        public static string GetV3()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);

            return random.ToString();
        }

        public static string GetV4()
        {
            return DateTime.Now.ToString("yymmddhhmmssfff");
        }

        public static string GetV5()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            long uniqueId = (int)(timestamp % int.MaxValue) + counter;
            counter++;

            return uniqueId.ToString();
        }

        public static string GetV6()
        {
            lock (lockObject)
            {
                long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                long combinedValue = (timestamp << 20) | (counter++ % (1 << 20));

                char[] CharacterSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
                int Base = CharacterSet.Length;

                string result = string.Empty;

                do
                {
                    result = CharacterSet[combinedValue % Base] + result;
                    combinedValue /= Base;
                } while (combinedValue > 0);

                return result;
            }
        }

        public static string GetV7()
        {
            Guid guid = Guid.NewGuid();

            string base64String = Convert.ToBase64String(guid.ToByteArray());

            string shortId = base64String
                .Replace("/", "_")
                .Replace("+", "-")
                .TrimEnd('=');

            return shortId;
        }

        public static string GetV8()
        {
            Guid uniqueValue = Guid.NewGuid();

            string combinedData = uniqueValue.ToString("N") + DateTime.UtcNow.Ticks;

            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedData));
            }

            string shortId = BitConverter.ToString(hashBytes, 0, 4).Replace("-", "").ToLower();

            return shortId;
        }

        public static string GetV9()
        {
            var ticks = DateTime.Now.Ticks;
            var bytes = BitConverter.GetBytes(ticks);
            var id = Convert.ToBase64String(bytes);
            return id.Replace('+', '_').Replace('/', '-').TrimEnd('=');
        }
    }
}
