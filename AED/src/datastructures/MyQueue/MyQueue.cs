using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        private MyQueueNode<T> front;
        private MyQueueNode<T> back;
        private int size = 0;
        
        public bool IsEmpty()
        {
            if(front == null) return true;
            else
            {
                return false;
            }
        }

        public void Enqueue(T data)
        {
            var newNode = new MyQueueNode<T>(data, null);

            if (back == null)
            {
                // queue is leeg front en back zijn nu nieuwe node
                front = newNode;
                back = newNode;
            }
            else
            {
                // link oude back naar nieuwe
                back.next = newNode;
                back = newNode;
            }

            size++;
        }

        public T GetFront()
        {
            if (front == null)
            {
                throw new MyQueueEmptyException();
            }
            return front.data;
        }

        public T Dequeue()
        {

            if (front == null)
            {
                throw new MyQueueEmptyException();
            }

            var value = front.data;
            front = front.next;

            if (front == null)
            {
                back = null;
            }

            size--;
            return value;
        }

        public void Clear()
        {
            front = null;
            back = null;
            throw new System.NotImplementedException();
        }

    }
}