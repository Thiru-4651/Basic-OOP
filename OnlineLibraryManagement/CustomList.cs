using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class CustomList<Type> : IEnumerator,IEnumerable
    {
        private int _count;
        private int _capacity;
        public int Count { get { return _count; } set { _count = value; } }

        public int Capacity { get { return _capacity; } set { _capacity = value; } }

        private Type[] _array;
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }

        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }

        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }

        public void GrowSize()
        {
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count + elements.Count + 5;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            int j = 0;
            for (int i = _count; i < elements.Count; i++)
            {
                temp[i] = elements[j];
            }
            _array=temp;
            //Incraesing the count 
            _count+=elements.Count;
        }

        int position;
        public IEnumerator GetEnumerator()
        {
            position=-1;
            return(IEnumerator)this;
        }

        public bool MoveNext()
        {
            if(position<_count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position=-1;
        }

        public object Current{get{return _array[position];}}

    }
}