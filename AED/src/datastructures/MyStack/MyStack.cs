namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        public MyLinkedList<T> list = new MyLinkedList<T>();
        public bool IsEmpty()
        {
            if (list.first == null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public T Pop()
        {
            if (list.first == null) {
                throw new MyStackEmptyException();
            }
            var topItem = list.GetFirst();
            list.RemoveFirst();
            return topItem;
        }

        public void Push(T data)
        {
            list.AddFirst(data);
        }

        public T Top()
        {
            if (list.first == null)
            {
                throw new MyStackEmptyException();
            }
            return list.GetFirst();
        }

    }
}
