namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Rule rule = new(args);
                ComputerMove computerMove = new(rule);
                computerMove.ShowHash();
                Table table = new(rule);
                UserMove userMove = new(rule, table);
                userMove.ShowMove();
                computerMove.ShowMove();
                Rule.ShowResult(rule.GetResult(userMove.Move, computerMove.Move));
                computerMove.ShowKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message +
                    "\nTip: You should enter odd number of different options from three or more!");
            }
        }
    }
}