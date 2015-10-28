namespace StartFinish
{
    public class Member
    {
        public Member(long value)
        {
            this.Value = value;
        }

        public Member(long value, Member predecessor)
            : this(value)
        {
            this.Predecessor = predecessor;
        }

        public long Value { get; set; }

        public Member Predecessor { get; set; }
    }
}
