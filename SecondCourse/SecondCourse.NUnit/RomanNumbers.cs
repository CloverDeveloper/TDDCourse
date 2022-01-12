using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondCourse.NUnit
{
    [TestFixture]
    public class RomanNumbers
    {
        /// <summary>
        /// Ⅰ（1）、Ⅴ（5）、Ⅹ（10）、Ⅼ（50）、Ⅽ（100）、Ⅾ（500）和 Ⅿ（1000）
        /// 右加左減
        /// 在較大的羅馬數字的右邊記上較小的羅馬數字，表示大數字加小數字
        /// 在較大的羅馬數字的左邊記上較小的羅馬數字，表示大數字減小數字
        /// </summary>
        [TestCase(1,"I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(45, "XLV")]
        [TestCase(99, "XCIX")]
        [TestCase(8,"VIII")]
        public void RomanNumberTest(int expect,string romanNum) 
        {
            Assert.AreEqual(expect, Roman.Parse(romanNum));
        }
    }

    public static class Roman
    {
        private static Dictionary<char, int> romanDic = new Dictionary<char, int>()
        {
            { 'I',1},
            { 'V',5},
            { 'X',10},
            { 'L',50},
            { 'C',100},
            { 'D',500},
            { 'M',1000}
        };

        public static int Parse(string romanNumbers)
        {
            int res = 0;
            for (int i = 0; i < romanNumbers.Length; i += 1) 
            {
                // 在較大的羅馬數字的左邊記上較小的羅馬數字，表示大數字減小數字
                if (i + 1 < romanNumbers.Length && CheckSub(romanNumbers[i], romanNumbers[i + 1]))
                {
                    res -= romanDic[romanNumbers[i]];
                }
                else 
                {
                    res += romanDic[romanNumbers[i]];
                }
            }

            return res;
        }

        private static bool CheckSub(char c1, char c2) 
        {
            return romanDic[c1] < romanDic[c2];
        }
    }
}
