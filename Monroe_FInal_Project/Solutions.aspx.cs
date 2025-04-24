using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Monroe_FInal_Project
{
    public partial class Solutions : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CmdShowSolution753_Click(object sender, EventArgs e)
        {
            lblProblem.Text = @"There is a safe protected by a password. The password is a sequence of n digits 
where each digit can be in the range [0, k - 1]. The safe checks the most recent n digits typed. 
Return any string of minimum length that will unlock the safe at some point of entering it.";

            int n = 2, k = 2; // You can customize these values
            string result = CrackSafe(n, k);

            lblSolution.Text = $"For n = {n}, k = {k}, a valid sequence is: {result}";
        }

        private string CrackSafe(int n, int k)
        {
            HashSet<string> visited = new HashSet<string>();
            StringBuilder result = new StringBuilder();
            string start = new string('0', n - 1);
            DFS(start, visited, result, n, k);
            result.Append(start); // Complete the circular sequence
            return result.ToString();
        }

        private void DFS(string node, HashSet<string> visited, StringBuilder result, int n, int k)
        {
            for (int i = 0; i < k; i++)
            {
                string next = node + i;
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    DFS(next.Substring(1), visited, result, n, k);
                    result.Append(i);
                }
            }
        }

        protected void CmdShowSolution123_Click(object sender, EventArgs e)
        {

            lblProblem.Text = "Problem: Find the maximum profit with at most two stock transactions for prices {3,3,5,0,0,3,1,4}.";

            int[] prices = { 3, 3, 5, 0, 0, 3, 1, 4 };
            int result = MaxProfit(prices);

            lblSolution.Text = "Max Profit: " + result.ToString();
        }
        private int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            if (n == 0) return 0;

            int[] left = new int[n];
            int[] right = new int[n];

            int minPrice = prices[0];
            for (int i = 1; i < n; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                left[i] = Math.Max(left[i - 1], prices[i] - minPrice);
            }

            int maxPrice = prices[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxPrice = Math.Max(maxPrice, prices[i]);
                right[i] = Math.Max(right[i + 1], maxPrice - prices[i]);
            }

            int maxProfit = 0;
            for (int i = 0; i < n; i++)
            {
                maxProfit = Math.Max(maxProfit, left[i] + right[i]);
            }

            return maxProfit;
        }
        protected void CmdShowSolution68_Click(object sender, EventArgs e)
        {
            // Show problem
            lblProblem.Text = @"Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.

Use a greedy approach to pack as many words as possible into each line.
Pad spaces so that each line is exactly maxWidth characters wide.
Distribute extra spaces as evenly as possible between words.
Left-justify the last line.

Example:
Input:
words = [""Science"",""is"",""what"",""we"",""understand"",""well"",""enough"",""to"",""explain"",""to"",""a"",""computer."",""Art"",""is"",""everything"",""else"",""we"",""do""]
maxWidth = 20";

            // Justify using example 3
            string[] words = {
        "Science", "is", "what", "we", "understand", "well",
        "enough", "to", "explain", "to", "a", "computer.",
        "Art", "is", "everything", "else", "we", "do"
    };
            int maxWidth = 20;

            var lines = FullJustify(words, maxWidth);

            StringBuilder sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.AppendLine(line);
            }

            litSolution.Text = Server.HtmlEncode(sb.ToString());
        }

        private List<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> result = new List<string>();
            int index = 0;

            while (index < words.Length)
            {
                int count = words[index].Length;
                int last = index + 1;

                while (last < words.Length)
                {
                    if (count + 1 + words[last].Length > maxWidth) break;
                    count += 1 + words[last].Length;
                    last++;
                }

                StringBuilder sb = new StringBuilder();
                int wordCount = last - index;
                // Check if last line or line has only one word
                if (last == words.Length || wordCount == 1)
                {
                    for (int i = index; i < last; i++)
                    {
                        sb.Append(words[i]);
                        if (i < last - 1)
                            sb.Append(" ");
                    }

                    int remaining = maxWidth - sb.Length;
                    sb.Append(' ', remaining);
                }
                else
                {
                    int totalSpaces = maxWidth - (count - (wordCount - 1));
                    int spaceBetween = totalSpaces / (wordCount - 1);
                    int extraSpaces = totalSpaces % (wordCount - 1);

                    for (int i = index; i < last; i++)
                    {
                        sb.Append(words[i]);
                        if (i < last - 1)
                        {
                            int spaces = spaceBetween + (extraSpaces-- > 0 ? 1 : 0);
                            sb.Append(' ', spaces);
                        }
                    }
                }

                result.Add(sb.ToString());
                index = last;
            }

            return result;
        }
    
    protected void CmdClear_Click(object sender, EventArgs e)
        {
            lblProblem.Text = "";
            litSolution.Text = "";
            lblSolution.Text = "";
        }

    } 
}

    
