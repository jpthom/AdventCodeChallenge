namespace CodeChallenge
{
    public static class Day2
    {
        public static void PerformDay2()
        {
            var input = File.ReadAllText("C:\\Temp\\CodeChallenge2\\input.txt").Replace("\r\n", string.Empty);
            var sequenceStrings = input.Split(',');
            var allInvalidIds = new List<long>();

            foreach (var sequence in sequenceStrings)
            {
                var sequenceSplit = sequence.Split('-');
                var numberRange = new NumberRange(long.Parse(sequenceSplit[0]), long.Parse(sequenceSplit[1]));
                var invalidIds = numberRange.GetInvalidNumbers();
                Console.WriteLine($"{sequence} has {invalidIds.Count} invalid IDs");
                allInvalidIds.AddRange(invalidIds);
            }

            Console.WriteLine($"Sum: {allInvalidIds.Sum()}");
            Console.ReadLine();
        }

        public class NumberRange
        {
            public long Min { get; private set; }
            public long Max { get; private set; }

            public NumberRange(long min, long max)
            {
                Min = min;
                Max = max;
            }

            public List<long> GetInvalidNumbers()
            {
                var invalid = new List<long>();
                for (var i = Min; i <= Max; i++)
                {
                    if (i.ToString().Length % 2 != 0) continue; // Ignore odd since they can't have repeating halves
                    var numberString = i.ToString();
                    var halfLength = numberString.Length / 2;
                    var firstHalf =  numberString.Substring(0, halfLength);
                    var secondHalf = numberString.Substring(halfLength);
                    if (firstHalf.Equals(secondHalf)) invalid.Add(i);
                }

                return invalid;
            }
        }
    }
}
