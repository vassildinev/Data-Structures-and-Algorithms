namespace Tasks
{
    using System;

    public class Task : IComparable
    {
        public string Name { get; set; }

        public int Complexity { get; set; }

        public int CompareTo(object obj)
        {
            var otherTask = (Task)obj;
            if (this.Complexity > otherTask.Complexity)
            {
                return 1;
            }
            else if (this.Complexity < otherTask.Complexity)
            {
                return -1;
            }
            else
            {
                return -this.Name.CompareTo(otherTask.Name);
            }
        }
    }
}
