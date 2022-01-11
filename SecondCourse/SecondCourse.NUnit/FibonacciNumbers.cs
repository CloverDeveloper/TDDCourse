using NUnit.Framework;

namespace SecondCourse.NUnit
{
    [TestFixture]
    public class FibonacciNumbers
    {
        private int[] temps = new int[100];
        public FibonacciNumbers()
        {
            temps[0] = 0;
            temps[1] = 1;
        }

        /// <summary>
        /// Fibonacci Numbers 0 1 1 2 3 5 8 13 ...
        /// </summary>
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(13, 7)]
        public void FibonacciTest(int expect, int actual)
        {
            Assert.AreEqual(expect, this.GetFibonacci(actual));
        }

        private int GetFibonacci(int index)
        {
            if (index == 0) return this.temps[0];

            if (index == 1) return this.temps[1];

            if (this.temps[index] != 0) return this.temps[index];

            this.temps[index] = this.GetFibonacci(index - 1) + this.GetFibonacci(index - 2);

            return this.temps[index];
        }
    }
}