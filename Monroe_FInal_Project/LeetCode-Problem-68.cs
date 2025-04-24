/*File Name: LeetCode-Problem-68.cs
* Name: Pranavi Nallari 
* email: nallarpi @mail.uc.edu
* Assignment Number: Last Assignment
* Due Date: 4 / 29 / 2025
* Course #/Section: IS 30350/001
* Semester / Year: Spring 2025
* Brief Description of the assignment: Final Project-Create a webform that shows solutions to different leetcode problems
* Brief Description of what this module does: Learn how to use and create webforms in ASP.Net
* Citations: https://leetcode.com/problems/text-justification/solutions/3952161/beats-100-js-ts-java-c-c-c-python-python3-kotlin-php/
* https://chatgpt.com/share/6807eee6-d5c4-8005-82c2-1a534286b98a
* Anything else that's relevant: 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace Monroe_FInal_Project
{
    public class LeetCode_Problem_68
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> result = new List<string>();
            int index = 0;

            while (index < words.Length)
            {
                int totalChars = words[index].Length;
                int last = index + 1;

                // Determine how many words can fit in the current line
                while (last < words.Length)
                {
                    if (totalChars + 1 + words[last].Length > maxWidth) break;
                    totalChars += 1 + words[last].Length;
                    last++;
                }

                int wordCount = last - index;
                int spaceCount = maxWidth - totalChars + (wordCount - 1);
                System.Text.StringBuilder sb = new StringBuilder();

                // If it's the last line or only one word in the line, left-justify
                if (last == words.Length || wordCount == 1)
                {
                    for (int i = index; i < last; i++)
                    {
                        sb.Append(words[i]);
                        if (i < last - 1) sb.Append(" ");
                    }
                    // Fill the remaining space with spaces
                    int remaining = maxWidth - sb.Length;
                    sb.Append(' ', remaining);
                }
                else
                {
                    // Fully justify
                    int spaces = (maxWidth - (totalChars - (wordCount - 1))) / (wordCount - 1);
                    int extra = (maxWidth - (totalChars - (wordCount - 1))) % (wordCount - 1);

                    for (int i = index; i < last; i++)
                    {
                        sb.Append(words[i]);
                        if (i < last - 1)
                        {
                            sb.Append(' ', spaces + (extra-- > 0 ? 1 : 0));
                        }
                    }
                }

                result.Add(sb.ToString());
                index = last;
            }

            return result;
        }
    }
}
