using System;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace TimeConstantCompare
{
    class Program
    {
        static void Main()
        {
            Test("fred",        "jim",      false);
            Test("",            "",         true);
            Test("Mike",        "Mike",     true);
            Test("Michael",     "Michaela", false);
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
            bool same = TimeConstantCompare(s1, s2);
            string passfail = (same == expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{passfail} [{s1}] == [{s2}]?");
        }

        /// <summary>
        /// TimeConstCompare
        /// </summary>
        /// <param name="s1">String 1</param>
        /// <param name="s2">String 2</param>
        /// <returns>True when the strings are equal, false otherwise</returns>
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]        
        static bool TimeConstantCompare(string s1, string s2)
        {
            int accum = s1.Length ^ s2.Length;
            int mn = Math.Min(s1.Length, s2.Length);

            for (int i = 0; i < mn; i++)
                accum |= (s1[i] ^ s2[i]);

            return accum == 0 ? true : false;
        }
    }
}



