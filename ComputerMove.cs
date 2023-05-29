using System.Text;
using System.Security.Cryptography;

namespace task3
{
    internal class ComputerMove
    {

        private readonly string move;

        public string Move { get { return move; } }

        private readonly string key;

        private readonly string hash;

        public ComputerMove(Rule rule) 
        {
            Random random = new();
            int optionKey = random.Next(1, rule.Options.Keys.Count + 1);
            move = rule.Options[Convert.ToString(optionKey)];
            key = GenerateKey(32);
            hash = HMACHASH(move, key);
        }

        public void ShowHash()
        {
            Console.WriteLine("HMAC: {0}", hash);
        }

        public void ShowMove()
        {
            Console.WriteLine("Computer move: {0}", move);
        }

        public void ShowKey() 
        {
            Console.WriteLine("HMAC key: {0}", key);
        }

        private static string HMACHASH(string str, string key)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);
            using var hmac = new HMACSHA256(bkey);
            byte[] bstr = Encoding.Default.GetBytes(str);
            var bhash = hmac.ComputeHash(bstr);
            return BitConverterToString(bhash);
        }

        private static string GenerateKey(int size)
        {
            using var generator = RandomNumberGenerator.Create();
            var key = new byte[size];
            generator.GetBytes(key);
            return BitConverterToString(key);
        }

        private static string BitConverterToString(byte[] b)
        {
            return BitConverter.ToString(b).Replace("-", string.Empty).ToLower();
        }
    }
}