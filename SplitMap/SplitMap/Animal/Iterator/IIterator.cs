using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Iterator
{
    public interface IIterator<T> where T : class
    {
        T FirstItem { get; }
        T NextItem { get; }
        T CurrentItem { get; }
        bool IsDone { get; }
        
    }
}
