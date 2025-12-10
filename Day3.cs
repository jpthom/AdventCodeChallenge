namespace CodeChallenge
{
    public static class Day3
    {
        public static void PerformDay3()
        {
            var batteryBanks = File.ReadAllLines("C:\\Temp\\CodeChallenge\\3\\input.txt");

            var sum = 0;
            foreach(var batteryBankString in batteryBanks)
            {
                var batteryBank = new BatteryBank(batteryBankString);
                var currentJoltage = batteryBank.GetMaxJoltage();
                sum += currentJoltage;

                Console.WriteLine($"Joltage for {batteryBankString} is {currentJoltage}");
            }

            Console.WriteLine($"Total sum is {sum}");
            Console.ReadLine();
        }

        public class BatteryBank
        {
            private string _batteries { get; set; }

            public BatteryBank(string batteryBank)
            {
                _batteries = batteryBank;
            }

            public int GetMaxJoltage()
            {
                int? maxIndex1 = null;
                int? maxIndex2 = null;
                int maxSoFar = -1;
                for (var i = 0; i < _batteries.Length - 1; i++)
                {
                    var currentVal = _batteries[i] - '0';
                    if (currentVal > maxSoFar)
                    {
                        maxSoFar = currentVal;
                        maxIndex1 = i;
                    }
                }
                maxSoFar = -1;
                for (var i = maxIndex1 + 1; i < _batteries.Length; i++)
                {
                    var currentVal = _batteries[i.Value] - '0';
                    if (currentVal > maxSoFar)
                    {
                        maxSoFar = currentVal;
                        maxIndex2 = i;
                    }
                }
                return int.Parse($"{_batteries[maxIndex1!.Value]}{_batteries[maxIndex2!.Value]}");
            }
        }
    }
}
