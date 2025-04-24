using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Monroe_FInal_Project
{
    public class LeetCode_Problem_753
    {
        public string CrackSafe(int n, int k)
        {
            HashSet<string> visited = new HashSet<string>();
            StringBuilder result = new StringBuilder();

            string start = new string('0', n - 1);
            DFS(start, visited, result, n, k);

            result.Append(start); // append the start to complete the sequence
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
    }
}
