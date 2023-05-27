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
            key = GetSha256hash();
            hash = GetSha256hash(this.key + move);
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

        private static string GetSha256hash(string value)
        {
            Encoding enc = Encoding.UTF8;
            Byte[] result = SHA256.HashData(enc.GetBytes(value));
            return GetStringFromByteArray(result);
        }

        private static string GetSha256hash()
        {
            Byte[] result = SHA256.HashData(RandomNumberGenerator.GetBytes(64));
            return GetStringFromByteArray(result);
        }

        private static string GetStringFromByteArray(Byte[] result)
        {
            StringBuilder Sb = new();
            foreach (Byte b in result)
                Sb.Append(b.ToString("x2"));
            return Sb.ToString();
        }
    }
}