namespace task3
{
    internal class Table
    {
        private readonly string table;

        private readonly int firstTableWidth;

        public Table(Rule rule) 
        {
            table = "";
            firstTableWidth = GetFirstTableWidth(rule);
            string border = GetBorder(rule);
            string header = GetHeader(rule);
            List<string> body = GetBody(rule);
            table += border + "\n" + header + "\n" + border + "\n";
            foreach (string line in body)
            {
                table += line + "\n" + border + "\n";
            }
        }

        public void ShowTable()
        {
            Console.Write(table);
        }

        private string GetBorder(Rule rule)
        {
            string border = "+-";
            for (int i = 0; i < firstTableWidth; i++)
            {
                border += "-";
            }
            border += "-+";
            foreach (string item in rule.OptionList)
            {
                if (item.Length <= 4)
                {
                    border += "----";
                }
                else
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        border += "-";
                    }
                }
                border += "--+";
            }
            return border;
        }

        private string GetHeader(Rule rule)
        {
            string header = "| PC Moves";
            for (int i = 0; i < firstTableWidth; i++)
            {
                if (i < firstTableWidth - 8)
                {
                    header += " ";
                }
            }
            header += " |";
            foreach (string item in rule.OptionList)
            {
                header += " ";
                header += item;
                if (item.Length <= 4)
                {
                    for (int i = 0; i < 4 - item.Length; i++)
                    {
                        header += " ";
                    }
                }
                header += " |";
            }
            return header;
        }

        private List<string> GetBody(Rule rule)
        {
            List<string> body = new();
            foreach (string item in rule.OptionList)
            {
                string row = "| " + item;
                for (int i = 0; i < firstTableWidth - item.Length; i++)
                {
                    row += " ";
                }
                row += " |";
                GetTableResult(rule, item, ref row);
                body.Add(row);
            }
            return body;
        }

        private static void GetTableResult(Rule rule, string item, ref string row) 
        {
            foreach (var variable in rule.OptionList)
            {
                row += " ";
                string result = rule.GetResult(item, variable);
                row += result;
                if (result.Length == 3)
                {
                    row += " ";
                }
                for (int i = 0; i < variable.Length - 4; i++)
                {
                    row += " ";
                }
                row += " |";
            }
        }

        private static int GetFirstTableWidth(Rule rule)
        {
            string longest = rule.OptionList.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
            return longest.Length > 8 ? longest.Length : 8;
        }
    }
}