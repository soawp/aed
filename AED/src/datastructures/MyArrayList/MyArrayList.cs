﻿using System;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        public int[] data;
        public int size;

        public MyArrayList(int capacity)
        {
            data = new int[capacity];
            size = 0;
        }

        public void Add(int n)
        {
            if (size == data.Length)
            {
                throw new MyArrayListFullException();
            }

            data[size] = n;
            size++;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            return data[index];
        }

        public void Set(int index, int n)
        {
            if (index < 0 || index >= size)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            data[index] = n;
        }

        public int Capacity()
        {
            return data.Length;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            size = 0;
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
        }

        public int CountOccurences(int n)
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (data[i] == n)
                {
                    count++;
                }
            }
            return count;
        }
        public override string ToString()
            {
                if (size == 0)
                {
                    return "NIL";
                }

                string result = "[";
                for (int i = 0; i < size; i++)
                {
                    result += data[i];
                    if (i < size - 1)
                    {
                        result += ",";
                    }
                }
                result += "]";
                return result;
            }
        }
    }
