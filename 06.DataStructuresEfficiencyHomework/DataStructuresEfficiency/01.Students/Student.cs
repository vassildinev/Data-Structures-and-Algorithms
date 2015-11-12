namespace Students
{
    using System;

    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            return (other.LastName + "  " + other.FirstName).CompareTo(this.LastName + " " + this.FirstName);
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
