using System;
using System.Security.Cryptography;
using System.Text;

namespace TimeConstantCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = {"fred", "jim",
                             "","",
                             ""," ",
                             "","Hey",
                             "Bruce","",
                             "uehdkjhakjsd","asjdfhwe",
                             "Jimmy!","jimmy!",
                             "Password","Passwor"};
            for (int i = 0; i < test.Length; i += 2)
            {
                bool same = TimeConstantCompare("SHA256", test[i], test[i + 1]);
                Console.WriteLine($"String1[{test[i]}] String2[{test[i + 1]}] Same[{same}]");
            }
        }

        static bool TimeConstantCompare(string hashName, string s1, string s2)
        {
            var h1 = HashAlgorithm.Create(hashName).ComputeHash(Encoding.UTF8.GetBytes(s1));
            var h2 = HashAlgorithm.Create(hashName).ComputeHash(Encoding.UTF8.GetBytes(s2));

            int accum = 0;
            for (int i = 0; i < h1.Length; i++)
                accum |= (h1[i] ^ h2[i]);

            return accum == 0;
        }
    }
}

