namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> first;
        public int size;

        public MyLinkedList(int size = 0)
        {
            this.size = 0;
            first = null;
        }

        public void AddFirst(T data)
        {
            var newNode = new MyLinkedListNode<T>(data);
            newNode.next = first;
            first = newNode;
            size++;
        }

        public T GetFirst()
        {
            if (first == null)
            {
                throw new MyLinkedListEmptyException();
            }
            return first.data;
        }

        public void RemoveFirst()
        {
            if (first == null)
            {
                throw new MyLinkedListEmptyException();
            }
            first = first.next;
            size--;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            first = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > size)
            {
                throw new MyLinkedListIndexOutOfRangeException();
            }

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            var newNode = new MyLinkedListNode<T>(data);
            var current = first;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }

            newNode.next = current.next;
            current.next = newNode;
            size++;
        }

        public override string ToString()
        {
            if (first == null) return "NIL";

            var current = first;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("[");

            while (current != null)
            {
                sb.Append(current.data);
                if (current.next != null)
                {
                    sb.Append(",");
                }
                current = current.next;
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}