namespace CustomLinkedList
{
    public class ListItem<T>
    {
        T Value { get; set; }

        ListItem<T> NextItem { get; set; }
    }
}
