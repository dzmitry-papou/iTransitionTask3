#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace task3
{
    internal class UserMove
    {
        private readonly string move;

        public string Move { get { return move; } }

        public UserMove(Rule rule, Table table)
        {
            move = GetMove(rule, table);
        }

        private static string GetMove(Rule rule, Table table)
        {
            string userInput = string.Empty;
            while (!rule.Options.ContainsKey(userInput))
            {
                ShowMenu(rule);
                try
                {
                    userInput = GetUserInput(rule, table);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: You have entered a non-existent option!\n" +
                        "Tip: Enter the correct option!");
                }
            }
            return rule.Options[userInput];
        }

        public void ShowMove()
        {
            Console.WriteLine("Your move: {0}", move);
        }

        private static void ShowMenu(Rule rule)
        {
            Console.Write(rule.OptionsToDisplay);
            Console.Write("0 - exit\n? - help\nEnter your move: ");
        }

        private static string GetUserInput(Rule rule, Table table)
        {
            string userInput = Console.ReadLine().Trim();
            switch (userInput)
            {
                case "?":
                    table.ShowTable();
                    break;
                case "0":
                    System.Environment.Exit(0);
                    break;
                default:
                    if (!rule.Options.ContainsKey(userInput))
                    {
                        throw new Exception();
                    }
                    break;
            }
            return userInput;
        }
    }
}