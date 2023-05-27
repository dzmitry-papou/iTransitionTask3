namespace task3
{
    internal class Rule
    {
        public Dictionary<string, string> Options { get; }

        public List<string> OptionList { get; }

        public string OptionsToDisplay { get; }

        public Rule(string[] options)
        {
            OptionList = new List<string>();
            Options = new Dictionary<string, string>();
            CheckNumberOfParameters(options);
            SetOptionsAndOptionList(options);
            OptionsToDisplay = SetOptionsToDisplay(Options);
        }

        private void SetOptionsAndOptionList(string[] options)
        {
            int i = 0;
            foreach (string option in options)
            {
                CheckDuplicateParameters(option);
                Options.Add(Convert.ToString(++i), option);
                OptionList.Add(option);
            }
        }

        private static string SetOptionsToDisplay(Dictionary<string, string> options)
        {
            string optionsToDisplay = "Available moves:\n";
            foreach (KeyValuePair<string, string> option in options)
            {
                optionsToDisplay += option.Key + " - " + option.Value + "\n";
            }
            return optionsToDisplay;
        }

        public string GetResult(string userMove, string computerMove)
        {
            int currentPosition = OptionList.IndexOf(userMove);
            if (currentPosition == OptionList.IndexOf(computerMove))
            {
                return "Draw";
            }
            for (int i = 0; i < OptionList.Count / 2; i++)
            {
                currentPosition++;
                if (currentPosition == OptionList.Count)
                {
                    currentPosition = 0;
                }
                if (currentPosition == OptionList.IndexOf(computerMove))
                {
                    return "Lose";
                }
            }
            return "Win";
        }

        public static void ShowResult(string result)
        {
            switch (result)
            {
                case "Win":
                    Console.WriteLine("You win!");
                    break;
                case "Lose":
                    Console.WriteLine("You lose!");
                    break;
                default:
                    Console.WriteLine("Draw");
                    break;
            };
        }

        private static void CheckNumberOfParameters(string[] options)
        {
            if (options.Length < 3)
            {
                throw new Exception("Error: You have not entered enough options!");
            }
            if (options.Length % 2 == 0)
            {
                throw new Exception("Error: You have entered even number of options!");
            }
        }

        private void CheckDuplicateParameters(string option)
        {
            if (Options.ContainsValue(option))
            {
                throw new Exception("Error: You have entered duplicate options!");
            }
        }
    }
}