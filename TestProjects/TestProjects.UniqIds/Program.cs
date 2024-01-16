namespace TestProjects.UniqIds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var count = 100000;
            CheckUniq(Generator.GetV1, count);
            CheckUniq(Generator.GetV2, count);
            CheckUniq(Generator.GetV3, count);
            CheckUniq(Generator.GetV4, count);
            CheckUniq(Generator.GetV5, count);
            CheckUniq(Generator.GetV6, count);
            CheckUniq(Generator.GetV7, count);
            CheckUniq(Generator.GetV8, count);
            CheckUniq(Generator.GetV9, count);
        }

        public static void CheckUniq(Func<string> action, int count)
        {
            Dictionary<string, int> uniq = new Dictionary<string, int>();

            for (int i = 0; i < count; i++)
            {
                var id = action();

                if (uniq.ContainsKey(id))
                {
                    uniq[id]++;
                }
                else
                {
                    uniq.Add(id, 1);
                }
            }

            var repeatability = uniq.Where(s => s.Value > 1).OrderByDescending(s => s.Value).ToList();

            Console.WriteLine($"Frequency is {(repeatability.Count * 100) / uniq.Count}%, repeated: {string.Join(',', repeatability.Select(s=> $"{s.Key}:{s.Value}"))}");
        }
    }
}
