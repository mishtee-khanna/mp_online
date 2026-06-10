using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class FilePriorityComparer : IComparer<string>
    {
        private int GetPriority(string file)
        {
            if (file.StartsWith("URGENT"))
            {
                return 1;
            }
            if (file.StartsWith("NORMAL"))
            {
                return 2;
            }

            return 3; // Default priority for other files
        }



        public int Compare(string x, string y)
        {

            int priorityComparision = GetPriority(x).CompareTo(GetPriority(y));
            return priorityComparision;



        }
    }
    internal class CustomSort
    {
        public static void Main()
        {
            List<string> files = new List<string>
            {
                "NORMAL_Report.docx",
                "URGENT_Presentation.pptx",
                "OTHER_Notes.txt",
                "URGENT_Budget.xlsx",
                "NORMAL_Summary.docx"
            };
            files.Sort(new FilePriorityComparer());
            Console.WriteLine("Files sorted by priority:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}

