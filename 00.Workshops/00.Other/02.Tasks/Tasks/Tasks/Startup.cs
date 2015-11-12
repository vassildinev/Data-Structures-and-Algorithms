namespace Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int tasksCount = int.Parse(Console.ReadLine());

            var tasks = new SortedSet<Task>();
            for (int i = 0; i < tasksCount; i++)
            {
                string[] commandComponents = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string commandName = commandComponents[0].ToLower();

                int taskComplexity = 0;
                string taskName = string.Empty;
                if (commandComponents.Length > 1)
                {
                    taskComplexity = int.Parse(commandComponents[1]);
                    taskName = commandComponents[2];
                }

                switch (commandName)
                {
                    case "new":
                        {
                            tasks.Add(new Task
                            {
                                Complexity = taskComplexity,
                                Name = taskName
                            });

                            break;
                        }

                    case "solve":
                        {
                            if (tasks.Count == 0)
                            {
                                Console.WriteLine("Rest");
                                break;
                            }

                            Console.WriteLine($"{tasks.First().Complexity} - {tasks.First().Name}");
                            tasks.Remove(tasks.First());
                            break;
                        }

                    default:
                        break;
                }
            }
        }
    }
}
