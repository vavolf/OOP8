using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab8
{
    class ClassCollectionType<T> : GenericInterface<T> /*where T: struct*/
    {
        private T[] container;
        private int size;
        private int capacity;
        // конструктор
        public ClassCollectionType(int initialCapacity)
        {
            capacity = initialCapacity;
            container = new T[initialCapacity];
        }

        // реализация методов интерфейса

        public void Add(T elem)
        {
            if (size == capacity)
            {
                capacity++;
                Array.Resize(ref container, capacity);
            }
            try
            {
                if (size > capacity)
                    throw new IndexOutOfRangeException("Выход за границы массива");
                container[size] = elem;
                size++;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally выполняется независимо того, возникает ошибка или нет");
            }

        }

        public void Remove()
        {
            if (size == 0)
            {
                Console.WriteLine("Список не содержит элементов");
            }
            else
            {
                size--;
                Array.Resize(ref container, container.Length - 1);
            }
        }

        public void Display()
        {
            for (int i = 0; i < container.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {container[i]}");
            }
        }

        public void ToFile()
        {
            using (StreamWriter sw = new StreamWriter(@"D:\C#\lab8\lab8\note.txt"))
            {
                foreach (T obj in container)
                {
                    sw.WriteLine(obj);
                }
            }
        }

        public void FromFileToConsole()
        {
            string str = "";
            using (StreamReader sr = new StreamReader(@"D:\C#\lab8\lab8\note.txt"))
            {
                while ((str = sr.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }
        }

        // индексатор
        public T this[int index]
        {
            get => container[index];
            set => container[index] = value;
        }

        // свойства

        public T[] GetContainer() => container;

        // методы
        public void Prepend(T elem)   //вспомогательный метод по вставке элемента в начало списка
        {
            T[] newContainer = new T[size + 1];
            newContainer[0] = elem;
            Array.Copy(container, 0, newContainer, 1, size);
            container = newContainer;
            size++;
        }
        public override bool Equals(object obj)
        {
            if (obj is ClassCollectionType<T> list)
            {
                return container.Equals(list.container);
            }
            else
            {
                return false;
            }
        }
        public int indexOf(int elem) => Array.IndexOf(container, elem); //индекс элемента списка

        //перегрузка операторов 
        public static ClassCollectionType<T> operator +(T item, ClassCollectionType<T> list)  //добавление в начало списка
        {
            list.Prepend(item);
            return list;
        }
        public static ClassCollectionType<T> operator --(ClassCollectionType<T> list)   //удаление первого элемента из списка
        {
            Array.Copy(list.container, 1, list.container, 0, list.size - 1);
            list.size--;
            return list;
        }
        public static bool operator ==(ClassCollectionType<T> list1, ClassCollectionType<T> list2) => list1.Equals(list2);
        public static bool operator !=(ClassCollectionType<T> list1, ClassCollectionType<T> list2) => !(list1 == list2);
        public static ClassCollectionType<T> operator *(ClassCollectionType<T> list1, ClassCollectionType<T> list2)   //объединение двух списков
        {
            for (int i = 0; i < list2.container.Length; i++)
            {
                ((GenericInterface<T>)list1).Add(list2.container[i]);
            }
            return list1;
        }
    }
}
