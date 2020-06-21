using System;

namespace CardfileDotNet.Data
{
    internal class LimitedStack<T>
    {
        private int count;
        private int size;
        private int head;
        private T[] data;

        public LimitedStack(int capacity)
        {
            this.size = capacity;
            this.count = 0;
            this.data = new T[capacity];
        }

        public int Count => count;
        public bool Empty => count == 0;

        public void Clear()
        {
            for (int i = 0; i < size; ++i)
                data[i] = default;
            head = 0;
        }

        public void Push(T item)
        {
            data[head] = item;
            head = (head + 1) % size;
            if (count < size) ++count;
        }

        public T Pop()
        {
            if (count <= 0)
                throw new InvalidOperationException("stack is empty");
            --count;
            head = (head - 1) % size;
            if (head < 0) head += size;
            T popped = data[head];
            data[head] = default;
            return popped;
        }
    }
}