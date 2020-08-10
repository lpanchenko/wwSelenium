using System;
using Xunit;
using Xunit.Abstractions;

namespace Question3
{
    public class MinimalNumberInRandomSet
    {
        private readonly ITestOutputHelper output;

        public MinimalNumberInRandomSet(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(1, 100, 500)]

        public void GenerateData(int min, int max, int count)
        {
            var array = new int[count];
            for (var i = 0; i < count; i++)
            {
                array[i] = RandomNumber(min, max);
            }

            var smallest = max;
            foreach (var i in array)
            {
                if (i < smallest)
                    smallest = i;
            }
            output.WriteLine(smallest.ToString());
        }

        // Generate a random number between min and max values
        public int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}
