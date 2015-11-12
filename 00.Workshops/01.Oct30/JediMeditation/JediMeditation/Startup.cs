namespace JediMeditation
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfJedi = int.Parse(Console.ReadLine());

            string[] jedi = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var masters = new HashSet<string>();
            var knights = new HashSet<string>();
            var padawans = new HashSet<string>();

            for (int i = 0; i < jedi.Length; i++)
            {
                string currentJedi = jedi[i];
                char jediLevel = currentJedi[0];
                switch (jediLevel)
                {
                    case 'm':
                        masters.Add(currentJedi);
                        break;
                    case 'k':
                        knights.Add(currentJedi);
                        break;
                    case 'p':
                        padawans.Add(currentJedi);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", padawans));
        }
    }
}
