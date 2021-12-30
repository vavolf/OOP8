using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    interface GenericInterface<T>
    {
        void Add(T elem);
        void Remove();
        void Display();
    }
}
