using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AD
{
    public partial class MyLinkedListNode<T>
    {
        public T data;
        public MyLinkedListNode<T> next;

        public MyLinkedListNode(T Data)
        {
            data = Data;
            next = null;
        }
    }


}
