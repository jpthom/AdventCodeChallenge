// Setup dial class and variables
using System.Diagnostics;

var dialStart = 50;
var dial = new Dial(dialStart);
var input = File.ReadAllLines("C:\\Temp\\input.txt");
var password = 0;

// Run through inputs
var stopwatch = Stopwatch.StartNew();
foreach (var inputLine in input)
{
    // Making assumptions that the input is always good. Would do more validation if it felt important.
    var direction = inputLine[0].Equals('L') ? DialDirection.Left : DialDirection.Right;
    var amount = int.Parse(inputLine.Substring(1));

    var dialPosition = dial.RotateAlt(amount, direction);
    Console.WriteLine($"The dial is rotated {direction} {amount} to point at {dialPosition}");

    if (dialPosition == 0) password++;
}
stopwatch.Stop();
Console.WriteLine($"Time ms: {stopwatch.ElapsedMilliseconds}");

Console.WriteLine($"Password: {password}");
Console.ReadLine();

public class Dial
{
    private int _currentValue;

    public Dial(int initialValue)
    {
        _currentValue = initialValue;
    }

    public int Rotate(int value, DialDirection dialDirection)
    {
        if (dialDirection == DialDirection.Left)
        {
            _currentValue -= value % 100; // We only care about the tens and ones places, an extra 100 will take you to the same position.
            if (_currentValue < 0)
            {
                _currentValue = 100 - Math.Abs(_currentValue);
            }
        }
        else
        {
            _currentValue += value % 100;
            if (_currentValue > 99)
            {
                _currentValue = _currentValue - 100;
            }
        }

        return _currentValue;
    }

    public int RotateAlt(int value, DialDirection dialDirection)
    {
        if (dialDirection == DialDirection.Left)
        {
            for (var i = 0; i < value; i++)
            {
                _currentValue--;
                if (_currentValue == -1) _currentValue = 99;
            }
        }
        else
        {
            for (var i = 0; i < value; i++)
            {
                _currentValue++;
                if (_currentValue == 100) _currentValue = 0;
            }
        }

        return _currentValue;
    }

    public int GetValue() => _currentValue;
}

public enum DialDirection
{
    Left,
    Right
}