using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace breach
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("Enter password to hash: ");
                string passwordToHash = Console.ReadLine();

                Hash passwordHash = new Hash(passwordToHash);

                Console.WriteLine(passwordHash.hash);
                Console.WriteLine(passwordHash.regenerateHash());
            }
        }
    }

    class Hash
    {
        public string hash;
        private string password;
        public Hash(string inputPassword)
        {
            //store for regeneration later
            password = inputPassword;

            Guid passwordGuid = GenerateNonZeroGuid();
            hash = GetSHA1Hash(passwordGuid, inputPassword);
            
        }

        public string regenerateHash()
        {
            Guid passwordGuid = GenerateNonZeroGuid();
            hash = GetSHA1Hash(passwordGuid, password);

            return hash;
        }


        private Guid GenerateNonZeroGuid()
        {
            Guid passwordGuid = Guid.NewGuid();

            //Ensure that guid is not all zeros
            while(passwordGuid == Guid.Empty)
            {
                passwordGuid = Guid.NewGuid();
            }

            return passwordGuid;
        }

        private string GetSHA1Hash(Guid passwordGuid, string password)
        {
            string combo = passwordGuid + password;

            SHA1 hash = SHA1.Create();

            byte[] computedHash = hash.ComputeHash(Encoding.UTF8.GetBytes(combo));

            //Convert the computed hash back to human-readable form
            StringBuilder hashPrinter = new StringBuilder();
            for (int i = 0; i < computedHash.Length; i++)
            {
                hashPrinter.Append(computedHash[i].ToString("x2"));
            }

            
            return hashPrinter.ToString();

            
        }
    }
}
