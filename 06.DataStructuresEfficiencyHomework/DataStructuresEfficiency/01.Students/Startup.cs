namespace Students
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var students = new SortedDictionary<string, SortedSet<Student>>();
            foreach (string line in File.ReadAllLines("../../students.txt"))
            {
                string[] components = line.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                string courseName = components[2].Trim();
                if (!students.ContainsKey(courseName))
                {
                    students[courseName] = new SortedSet<Student>();
                }

                students[courseName].Add(new Student
                {
                    FirstName = components[0].Trim(),
                    LastName = components[1].Trim()
                });
            }

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value)}");
            }
        }
    }
}
