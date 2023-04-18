using System;

namespace Oadr.Library
{
    public class RandomHex
    {
        private static RandomHex _randomHex;
        private readonly Random _random;

        private RandomHex()
        {
            _random = new Random();
        }

        public static RandomHex Instance()
        {
            return _randomHex ?? (_randomHex = new RandomHex());
        }

        public string GenerateRandomHex(int length)
        {            
            var output = string.Empty;
            for (var index = 0; index < length; index++)
            {
                var val = _random.Next(16);
                output += val.ToString("x");
            }
            return output;
        }
    }
}
