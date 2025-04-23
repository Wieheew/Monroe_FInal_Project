/*
* File Name: LeetCode-Problem-502.cs

* Name: {required}
* email:  {required}
* Assignment Number: Assignment nn  {required}
* Due Date:   {required}
* Course #/Section:   {required}
* Semester/Year:   {required}
* Brief Description of the assignment:  {required}

* Brief Description of what this module does. {Do not copy/paste from a previous assignment. Put some thought into this. required}
* Citations: (1) https://chatgpt.com/c/6808ea21-4914-800e-bc3f-d862fe72ee37
*            (2) https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.priorityqueue-2?view=net-9.0
* Anything else that's relevant:
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monroe_FInal_Project
{
    public class LeetCode_Problem_502
    {
        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            int n = profits.Length;

            // Min-heap for capital requirements (sorted by capital)
            PriorityQueue<(int capital, int profit), int> minHeap = new PriorityQueue<(int, int), int>();
            // Max-heap for profits (sorted by profit)
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            // Insert all projects into the min-heap
            for (int i = 0; i < n; i++)
            {
                minHeap.Enqueue((capital[i], profits[i]), capital[i]);
            }

            int currentCapital = w;

            for (int i = 0; i < k; i++)
            {
                // Move projects that can be unlocked with the current capital to the max-heap
                while (minHeap.Count > 0 && minHeap.Peek().capital <= currentCapital)
                {
                    var project = minHeap.Dequeue();
                    maxHeap.Enqueue(project.profit, project.profit);
                }

                // If no projects can be started, break
                if (maxHeap.Count == 0)
                {
                    break;
                }

                // Select the project with the maximum profit
                currentCapital += maxHeap.Dequeue();
            }

            return currentCapital;
        }
    }
}