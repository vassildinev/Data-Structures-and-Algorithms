namespace StartFinish
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            var members = new Queue<Member>();
            var head = new Member(start);
            Member tail;

            members.Enqueue(head);
            while (true)
            {
                Member currentMember = members.Dequeue();

                var smallestSuccessor = new Member(currentMember.Value + 1, currentMember);
                var mediumSuccessor = new Member(currentMember.Value + 2, currentMember);
                var largestSuccessor = new Member(currentMember.Value * 2, currentMember);

                if (smallestSuccessor.Value == end)
                {
                    tail = smallestSuccessor;
                    break;
                }

                if (mediumSuccessor.Value == end)
                {
                    tail = mediumSuccessor;
                    break;
                }

                if (largestSuccessor.Value == end)
                {
                    tail = largestSuccessor;
                    break;
                }

                members.Enqueue(smallestSuccessor);
                members.Enqueue(mediumSuccessor);
                members.Enqueue(largestSuccessor);
            }

            PrintMemberHiearchy(tail);
            Console.WriteLine();
        }

        private static void PrintMemberHiearchy(Member child)
        {
            if (child.Predecessor == null)
            {
                Console.Write($"{child.Value}");
                return;
            }

            PrintMemberHiearchy(child.Predecessor);
            Console.Write($" -> {child.Value}");
        }
    }
}
