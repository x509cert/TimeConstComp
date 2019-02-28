using System;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace TimeConstantCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("fred",        "jim",      false);
            Test("",            "",         true);
            Test("Mike",        "Mike",     true);
            Test("",            " ",        false);
            Test(" ",           "  ",       false);
            Test("\uD802",      "\uD8ff",   false);
            Test("Jimmy!",      "jimmy!",   false);
            Test("\u007F",      " ",        false);
            Test("\u007F",      "",         false);
            Test("/mytext",     "⁄mytext",  false);
            Test("\u00C0",      "A",        false);
            Test("\u00C1",      "A",        false);
            Test("\u00C2",      "A",        false);
            Test("\u00C3",      "A",        false);
            Test("\u00C4",      "A",        false);
            Test("\u00C5",      "A",        false);
            Test("\u00C6",      "A",        false);
            Test("Security",    "Securit￥",false);
        }

        static void Test(string s1, string s2, bool expected)
        {
            int same = TimeConstantCompare("SHA256", s1, s2);
            bool bsame = ((same == 0) & expected);
            Console.WriteLine($"[{s1}] == [{s2}]? {bsame}");
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]        
        static int TimeConstantCompare(string hashName, string s1, string s2)
        {
            var h1 = HashAlgorithm.Create(hashName).ComputeHash(GetRawBytes(s1));
            var h2 = HashAlgorithm.Create(hashName).ComputeHash(GetRawBytes(s2));

            int accum = 0;
            for (int i = 0; i < h1.Length; i++)
                accum |= (h1[i] ^ h2[i]);

            return accum;
        }

        private static byte[] GetRawBytes(string s)
        {
            byte[] bytes = new byte[s.Length * sizeof(char)];
            System.Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}



