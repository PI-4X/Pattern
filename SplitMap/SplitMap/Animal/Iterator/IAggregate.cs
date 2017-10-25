using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Iterator
{
    public interface IAggregate<T> where T : class
    {
        IIterator<T> GetIterator();
        //This will handle manipulation of objects in the array
        T this[int itemIndex] { set; get; }
        int Count { get; }
        void SetCollection(IEnumerable<T> collection);

    }
}
